using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EffiLog
{
    public partial class Form1 : Form
    {
        static Regex _rTrimAll = new Regex(@"[^ a - zA - Z']");
        static Regex _rTrimKeepNbr = new Regex(@"[^\d]");
        static Regex _rGetTime = new Regex(@"\[([^)]*)\]");
        static Regex _rGetSession = new Regex(@"(?:<|>)S*\b\w+");
        static Regex _rGetOperation = new Regex(@"[a-zA-Z][a-zA-Z]{4}.*");
        static Regex _rGetOpName = new Regex(@"^[^\(]+");
        static Regex _rGetCaps = new Regex(@"[A-Z][A-Z]{4}.*");
        static string path = AppDomain.CurrentDomain.BaseDirectory;

        public Form1()
        {
            InitializeComponent();
           // this.cb_picker.SelectedIndexChanged +=
            //   new System.EventHandler(cb_picker_SelectedIndexChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1 = new BackgroundWorker();
            circularProgressBar1.Visible = false;
            circularProgressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_Completed);
            getFiles();
        }

        public void SessionView()
        {
            DataTable sv = new DataTable();
            sv.Columns.Add("Line Nbr", typeof(int));
            sv.Columns.Add("Time");
            sv.Columns.Add("Session");
            sv.Columns.Add("Operation");
            sv.Columns.Add("Operation Name");
            sv.Columns.Add("Detail");
            sv.Columns.Add("ms", typeof(int));

            //find user 
            foreach (DataGridViewRow row in d_Output.Rows)
            {
                if (row.Cells[4].ToString() == "OpenUserSession")
                {
                    sv.Rows.Add(row);
                }
            }

            d_Output.Rows.Clear();

            this.d_Output.DataSource = sv;
            this.d_Output.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Gathers all usefull files from folder into combobox
        public void getFiles()
        {
            foreach (string s in Directory.GetFiles(path, "*.log").Select(Path.GetFileName))
            {
                cb_files.Items.Add(s);
            }
        }

        //Gather values for usercode
        //public void getSessions()
        //{
        //    var Sessions = d_Output.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[2].Value != null).Select(x => x.Cells[2].ToString()).Distinct().ToList();
        //    foreach(var x in Sessions)
        //    {
        //        cb_Session.Items.Add(x.ToString());
        //    }
        //}

        //ThreadSafe way to get filename out of combobox 'cb_files'
        private delegate object getFile();

        private object getFileName()
        {
            if(cb_files.InvokeRequired)
            {
                getFile f_Name = new getFile(getFileName);
                return cb_files.Invoke(f_Name);
            }
            else
            {
                return cb_files.SelectedItem;
            }

        }

        //Trigger on cb_Picker
        private void cb_picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Session.Items.Clear();
            //getSessions();
        }
  
        //Gather all data from logfile into gridview
        public void readLog()
        {
            int lineCount = 1;
            int rowCount = 0;
            int s_count = 0;
            string[] entities = { "cntr", "quot", "cont", "comp", "docu", "mail", "acti", "oppo", "stin", "repo", "clai" };
            string path = "";
            string line;
            string fileName = getFileName().ToString();

            DataTable dt = new DataTable();
            dt.Columns.Add("Line Nbr", typeof(int));
            dt.Columns.Add("Time");
            dt.Columns.Add("Session");
            dt.Columns.Add("Operation");
            dt.Columns.Add("Operation Name");
            dt.Columns.Add("Detail");
            dt.Columns.Add("ms", typeof(int));
            //IDEA : n records read in n time
            //IDEA : Populate username combobox while loading
            //INFO : Last perf test 1.29 minutes to process 35668449
            //INFO : lineCount.ToString(), logTime, session, operation, name, detail, ms

            path = AppDomain.CurrentDomain.BaseDirectory + fileName;
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                string milliseconds = Regex.Match(line, @"\(([^()]*)\(0\)\)").ToString();

                if (milliseconds.Contains("ms") == false)
                {
                    lineCount++;
                    continue;
                }

                string input = line;
                string logTime = _rGetTime.Match(line).ToString();
                string session = _rGetSession.Match(line).ToString();
                string rawLine = Regex.Match(line, @"(?<=" + session + @").*$").ToString();
                string operation = _rGetOperation.Match(rawLine).ToString();
                string name = Regex.Match(operation, @"^[^\(]+").ToString();
                string detail = _rGetCaps.Match(line).ToString();


                int pos = milliseconds.IndexOf("s");
                string ms = milliseconds.Substring(0, (pos + 1));
                if (ms.IndexOf("(") == 0)
                {
                    ms = milliseconds.Substring(1, (pos + 1));
                }

                ms = _rTrimKeepNbr.Replace(ms, string.Empty);

                dt.Rows.Add(lineCount.ToString(), logTime, session, operation, name, detail, ms);

                lineCount++;
                rowCount++;
            };

            //ThreadSafe way to fill datagridview
            if(InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    this.d_Output.DataSource = dt;
                    this.d_Output.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }));
            }else
            {
                this.d_Output.DataSource = dt;
                this.d_Output.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            
            file.Close();
        }
        
        public void allVisible()
        {
            foreach (DataGridViewRow row in d_Output.Rows)
            {
                row.Visible = true;
            }
        }

        private delegate void updateProgressDelegate();

        private void updateProgressBar()
        {
            circularProgressBar1.Visible = true;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new updateProgressDelegate(updateProgressBar));
            readLog();
            
        }

        private void backgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            circularProgressBar1.Visible = false;
        }

        private void b_ReadLog_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
        }

        private void b_unFilter_Click(object sender, EventArgs e)
        {
            allVisible();
        }

        private void cb_sort_Click(object sender, EventArgs e)
        {
            
        }

        private void cb_Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_Sort.SelectedItem.ToString() != "")
            {
                b_asc.Enabled = true;
                b_desc.Enabled = true;
            }
            else
            {
                b_asc.Enabled = false;
                b_desc.Enabled = false;
            }

        }

        private void b_asc_Click(object sender, EventArgs e)
        {
            switch (cb_Sort.SelectedItem.ToString())
            {
                case "Line Nbr":
                    d_Output.Sort(d_Output.Columns[0], ListSortDirection.Ascending); 
                    break;
                case "Session":
                    d_Output.Sort(d_Output.Columns[2], ListSortDirection.Ascending);
                    break;
                case "Operation Name":
                    d_Output.Sort(d_Output.Columns[4], ListSortDirection.Ascending);
                    break;
                case "Detail":
                    d_Output.Sort(d_Output.Columns[5], ListSortDirection.Ascending);
                    break;
                case "Milliseconds":
                    d_Output.Sort(d_Output.Columns[6], ListSortDirection.Ascending);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private void b_desc_Click(object sender, EventArgs e)
        {
            switch (cb_Sort.SelectedItem.ToString())
            {
                case "Line Nbr":
                    d_Output.Sort(d_Output.Columns[0], ListSortDirection.Descending);
                    break;
                case "Session":
                    d_Output.Sort(d_Output.Columns[2], ListSortDirection.Descending);
                    break;
                case "Operation Name":
                    d_Output.Sort(d_Output.Columns[4], ListSortDirection.Descending);
                    break;
                case "Detail":
                    d_Output.Sort(d_Output.Columns[5], ListSortDirection.Descending);
                    break;
                case "Milliseconds":
                    d_Output.Sort(d_Output.Columns[6], ListSortDirection.Descending);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SessionView();
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
