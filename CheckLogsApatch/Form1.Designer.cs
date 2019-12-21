namespace CheckLogsApatch
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
            this.startScan = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.filterFileNameLabel = new System.Windows.Forms.Label();
            this.filterFileName = new System.Windows.Forms.TextBox();
            this.ipFilterLable = new System.Windows.Forms.Label();
            this.filterIP = new System.Windows.Forms.TextBox();
            this.filterResponseStatus = new System.Windows.Forms.TextBox();
            this.filterResponseStatusLable = new System.Windows.Forms.Label();
            this.list = new System.Windows.Forms.DataGridView();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responseSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.SuspendLayout();
            // 
            // startScan
            // 
            this.startScan.Location = new System.Drawing.Point(13, 13);
            this.startScan.Name = "startScan";
            this.startScan.Size = new System.Drawing.Size(85, 26);
            this.startScan.TabIndex = 0;
            this.startScan.Text = "Scan file";
            this.startScan.UseVisualStyleBackColor = true;
            this.startScan.Click += new System.EventHandler(this.startScan_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(13, 59);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // filterFileNameLabel
            // 
            this.filterFileNameLabel.AutoSize = true;
            this.filterFileNameLabel.Location = new System.Drawing.Point(158, 62);
            this.filterFileNameLabel.Name = "filterFileNameLabel";
            this.filterFileNameLabel.Size = new System.Drawing.Size(81, 13);
            this.filterFileNameLabel.TabIndex = 2;
            this.filterFileNameLabel.Text = "File name/path:";
            // 
            // filterFileName
            // 
            this.filterFileName.Location = new System.Drawing.Point(245, 59);
            this.filterFileName.Name = "filterFileName";
            this.filterFileName.Size = new System.Drawing.Size(100, 20);
            this.filterFileName.TabIndex = 3;
            // 
            // ipFilterLable
            // 
            this.ipFilterLable.AutoSize = true;
            this.ipFilterLable.Location = new System.Drawing.Point(351, 62);
            this.ipFilterLable.Name = "ipFilterLable";
            this.ipFilterLable.Size = new System.Drawing.Size(45, 13);
            this.ipFilterLable.TabIndex = 4;
            this.ipFilterLable.Text = "Filter IP:";
            // 
            // filterIP
            // 
            this.filterIP.Location = new System.Drawing.Point(402, 59);
            this.filterIP.Name = "filterIP";
            this.filterIP.Size = new System.Drawing.Size(100, 20);
            this.filterIP.TabIndex = 5;
            // 
            // filterResponseStatus
            // 
            this.filterResponseStatus.Location = new System.Drawing.Point(620, 59);
            this.filterResponseStatus.Name = "filterResponseStatus";
            this.filterResponseStatus.Size = new System.Drawing.Size(100, 20);
            this.filterResponseStatus.TabIndex = 6;
            // 
            // filterResponseStatusLable
            // 
            this.filterResponseStatusLable.AutoSize = true;
            this.filterResponseStatusLable.Location = new System.Drawing.Point(508, 62);
            this.filterResponseStatusLable.Name = "filterResponseStatusLable";
            this.filterResponseStatusLable.Size = new System.Drawing.Size(106, 13);
            this.filterResponseStatusLable.TabIndex = 7;
            this.filterResponseStatusLable.Text = "Filter response status";
            // 
            // list
            // 
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ip,
            this.date,
            this.method,
            this.path,
            this.protocol,
            this.responseStatus,
            this.responseSize});
            this.list.Location = new System.Drawing.Point(12, 103);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(708, 418);
            this.list.TabIndex = 8;
            // 
            // ip
            // 
            this.ip.DataPropertyName = "ip";
            this.ip.HeaderText = "IP";
            this.ip.Name = "ip";
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            // 
            // method
            // 
            this.method.DataPropertyName = "method";
            this.method.HeaderText = "Method";
            this.method.Name = "method";
            // 
            // path
            // 
            this.path.DataPropertyName = "path";
            this.path.HeaderText = "Path";
            this.path.Name = "path";
            // 
            // protocol
            // 
            this.protocol.DataPropertyName = "protocol";
            this.protocol.HeaderText = "Protocol";
            this.protocol.Name = "protocol";
            // 
            // responseStatus
            // 
            this.responseStatus.DataPropertyName = "responseStatus";
            this.responseStatus.HeaderText = "Response Status";
            this.responseStatus.Name = "responseStatus";
            // 
            // responseSize
            // 
            this.responseSize.DataPropertyName = "responseSize";
            this.responseSize.HeaderText = "Response Size";
            this.responseSize.Name = "responseSize";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 533);
            this.Controls.Add(this.list);
            this.Controls.Add(this.filterResponseStatusLable);
            this.Controls.Add(this.filterResponseStatus);
            this.Controls.Add(this.filterIP);
            this.Controls.Add(this.ipFilterLable);
            this.Controls.Add(this.filterFileName);
            this.Controls.Add(this.filterFileNameLabel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.startScan);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startScan;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label filterFileNameLabel;
        private System.Windows.Forms.TextBox filterFileName;
        private System.Windows.Forms.Label ipFilterLable;
        private System.Windows.Forms.TextBox filterIP;
        private System.Windows.Forms.TextBox filterResponseStatus;
        private System.Windows.Forms.Label filterResponseStatusLable;
        private System.Windows.Forms.DataGridView list;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn method;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
        private System.Windows.Forms.DataGridViewTextBoxColumn protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn responseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn responseSize;
    }
}

