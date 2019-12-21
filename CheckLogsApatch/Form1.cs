using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CheckLogsApatch
{
    public partial class Form1 : Form
    {
        ScanFile scanFileInst;

        public Form1()
        {
            InitializeComponent();
            scanFileInst = new ScanFile();
        }

        private void startScan_Click(object sender, EventArgs e)
        {
            if (!scanFileInst.checkFileByDefaultPath())
            {
                dialogOpenFile();
            }
            
            try
            {
                scanFileInst.readLogsFile();
            } catch (Exception error) {
                MessageBox.Show("[Error] Invalid file: " + error.Message);
            }

            updateUI();
        }

        public void updateUI()
        {
            BindingSource binding = new BindingSource();
            binding.DataSource = scanFileInst.logs;
            list.DataSource = binding;
        }

        private void dialogOpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|log files (*.log)|*.log|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    scanFileInst.path = openFileDialog.FileName;
                }
            }
        }
    }
}
