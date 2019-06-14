namespace EffiLog
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_ReadLog = new System.Windows.Forms.Button();
            this.d_Output = new System.Windows.Forms.DataGridView();
            this.cb_Session = new System.Windows.Forms.ComboBox();
            this.l_Session = new System.Windows.Forms.Label();
            this.l_Stat = new System.Windows.Forms.Label();
            this.txtb_stats = new System.Windows.Forms.TextBox();
            this.b_unFilter = new System.Windows.Forms.Button();
            this.b_asc = new System.Windows.Forms.Button();
            this.b_desc = new System.Windows.Forms.Button();
            this.cb_Sort = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.cb_files = new System.Windows.Forms.ComboBox();
            this.cb_picker = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.d_Output)).BeginInit();
            this.SuspendLayout();
            // 
            // b_ReadLog
            // 
            this.b_ReadLog.Location = new System.Drawing.Point(208, 30);
            this.b_ReadLog.Name = "b_ReadLog";
            this.b_ReadLog.Size = new System.Drawing.Size(75, 23);
            this.b_ReadLog.TabIndex = 0;
            this.b_ReadLog.Text = "Read Log";
            this.b_ReadLog.UseVisualStyleBackColor = true;
            this.b_ReadLog.Click += new System.EventHandler(this.b_ReadLog_Click);
            // 
            // d_Output
            // 
            this.d_Output.AllowUserToAddRows = false;
            this.d_Output.AllowUserToDeleteRows = false;
            this.d_Output.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d_Output.Location = new System.Drawing.Point(12, 274);
            this.d_Output.Name = "d_Output";
            this.d_Output.Size = new System.Drawing.Size(1328, 531);
            this.d_Output.TabIndex = 1;
            // 
            // cb_Session
            // 
            this.cb_Session.FormattingEnabled = true;
            this.cb_Session.Location = new System.Drawing.Point(152, 156);
            this.cb_Session.Name = "cb_Session";
            this.cb_Session.Size = new System.Drawing.Size(121, 21);
            this.cb_Session.TabIndex = 4;
            // 
            // l_Session
            // 
            this.l_Session.AutoSize = true;
            this.l_Session.Location = new System.Drawing.Point(13, 140);
            this.l_Session.Name = "l_Session";
            this.l_Session.Size = new System.Drawing.Size(82, 13);
            this.l_Session.TabIndex = 5;
            this.l_Session.Text = "Search Specific";
            // 
            // l_Stat
            // 
            this.l_Stat.AutoSize = true;
            this.l_Stat.Location = new System.Drawing.Point(1094, 19);
            this.l_Stat.Name = "l_Stat";
            this.l_Stat.Size = new System.Drawing.Size(49, 13);
            this.l_Stat.TabIndex = 7;
            this.l_Stat.Text = "Statistics";
            // 
            // txtb_stats
            // 
            this.txtb_stats.Location = new System.Drawing.Point(1097, 44);
            this.txtb_stats.Multiline = true;
            this.txtb_stats.Name = "txtb_stats";
            this.txtb_stats.Size = new System.Drawing.Size(243, 170);
            this.txtb_stats.TabIndex = 9;
            // 
            // b_unFilter
            // 
            this.b_unFilter.Location = new System.Drawing.Point(1097, 244);
            this.b_unFilter.Name = "b_unFilter";
            this.b_unFilter.Size = new System.Drawing.Size(243, 23);
            this.b_unFilter.TabIndex = 10;
            this.b_unFilter.Text = "Show everything without filter";
            this.b_unFilter.UseVisualStyleBackColor = true;
            this.b_unFilter.Click += new System.EventHandler(this.b_unFilter_Click);
            // 
            // b_asc
            // 
            this.b_asc.Enabled = false;
            this.b_asc.Location = new System.Drawing.Point(362, 244);
            this.b_asc.Name = "b_asc";
            this.b_asc.Size = new System.Drawing.Size(58, 23);
            this.b_asc.TabIndex = 11;
            this.b_asc.Text = "asc";
            this.b_asc.UseVisualStyleBackColor = true;
            this.b_asc.Click += new System.EventHandler(this.b_asc_Click);
            // 
            // b_desc
            // 
            this.b_desc.Enabled = false;
            this.b_desc.Location = new System.Drawing.Point(425, 244);
            this.b_desc.Name = "b_desc";
            this.b_desc.Size = new System.Drawing.Size(58, 23);
            this.b_desc.TabIndex = 13;
            this.b_desc.Text = "desc";
            this.b_desc.UseVisualStyleBackColor = true;
            this.b_desc.Click += new System.EventHandler(this.b_desc_Click);
            // 
            // cb_Sort
            // 
            this.cb_Sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Sort.Items.AddRange(new object[] {
            "Line Nbr",
            "Session",
            "Operation Name",
            "Detail",
            "Milliseconds"});
            this.cb_Sort.Location = new System.Drawing.Point(362, 217);
            this.cb_Sort.Name = "cb_Sort";
            this.cb_Sort.Size = new System.Drawing.Size(121, 21);
            this.cb_Sort.TabIndex = 14;
            this.cb_Sort.SelectedIndexChanged += new System.EventHandler(this.cb_Sort_SelectedIndexChanged);
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.circularProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBar1.InnerColor = System.Drawing.SystemColors.AppWorkspace;
            this.circularProgressBar1.InnerMargin = -2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(495, 391);
            this.circularProgressBar1.MarqueeAnimationSpeed = 1500;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.White;
            this.circularProgressBar1.OuterMargin = -26;
            this.circularProgressBar1.OuterWidth = 26;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBar1.ProgressWidth = 25;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar1.Size = new System.Drawing.Size(329, 301);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 18;
            this.circularProgressBar1.Text = "Loading";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.Value = 68;
            this.circularProgressBar1.Visible = false;
            this.circularProgressBar1.Click += new System.EventHandler(this.circularProgressBar1_Click);
            // 
            // cb_files
            // 
            this.cb_files.FormattingEnabled = true;
            this.cb_files.Location = new System.Drawing.Point(16, 32);
            this.cb_files.Name = "cb_files";
            this.cb_files.Size = new System.Drawing.Size(186, 21);
            this.cb_files.TabIndex = 19;
            // 
            // cb_picker
            // 
            this.cb_picker.FormattingEnabled = true;
            this.cb_picker.Items.AddRange(new object[] {
            "Session",
            "Usercode"});
            this.cb_picker.Location = new System.Drawing.Point(12, 156);
            this.cb_picker.Name = "cb_picker";
            this.cb_picker.Size = new System.Drawing.Size(121, 21);
            this.cb_picker.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 817);
            this.Controls.Add(this.cb_picker);
            this.Controls.Add(this.cb_files);
            this.Controls.Add(this.circularProgressBar1);
            this.Controls.Add(this.cb_Sort);
            this.Controls.Add(this.b_desc);
            this.Controls.Add(this.b_asc);
            this.Controls.Add(this.b_unFilter);
            this.Controls.Add(this.txtb_stats);
            this.Controls.Add(this.l_Stat);
            this.Controls.Add(this.l_Session);
            this.Controls.Add(this.cb_Session);
            this.Controls.Add(this.d_Output);
            this.Controls.Add(this.b_ReadLog);
            this.Name = "Form1";
            this.Text = "EffiLog";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.d_Output)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_ReadLog;
        private System.Windows.Forms.DataGridView d_Output;
        private System.Windows.Forms.ComboBox cb_Session;
        private System.Windows.Forms.Label l_Session;
        private System.Windows.Forms.Label l_Stat;
        private System.Windows.Forms.TextBox txtb_stats;
        private System.Windows.Forms.Button b_unFilter;
        private System.Windows.Forms.Button b_asc;
        private System.Windows.Forms.Button b_desc;
        private System.Windows.Forms.ComboBox cb_Sort;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.ComboBox cb_files;
        private System.Windows.Forms.ComboBox cb_picker;
    }
}

