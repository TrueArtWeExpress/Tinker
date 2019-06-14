using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace AppPoolChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public object ConfigurationManager { get; }

        private void btn_Check_Click(object sender, EventArgs e)
        {

        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            // Get Server Credentials and Server Name from config file
            string UName = ConfigurationManager.AppSettings["User"];
            string Pwd = ConfigurationManager.AppSettings["Pass"];
            string ServerName = DT.Rows[i]["ServerName"].ToString().Trim(); //Server Names from db
            DirectoryEntries appPools = null;
            try
            {
                appPools = new DirectoryEntry("IIS://" + ServerName + "/W3SVC/AppPools", UName, Pwd).Children;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("serviceLogic -> InsertStatus() -> IIS Pool App Region -> DirectoryEntries -> Error: ", ex.Message.ToString());
            }

            log.Info("IIS App Pool Section Started for " + System.Environment.MachineName.ToString());
        }
    }
}
