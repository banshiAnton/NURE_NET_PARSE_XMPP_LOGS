using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CheckLogsApatch
{
    public partial class Form1 : Form
    {
        ScanFile scanFileInst;

        BindingSource binding = null;

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

            setBindings();
            applyFilters();
        }

        public void setBindings()
        {
            binding = new BindingSource();
            binding.DataSource = scanFileInst.filteredLogs;
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

        public bool checkValidStatus(string resStatusStr)
        {
            var regDig = new Regex(@"\d");
            var regNoDig = new Regex(@"[^-0-9]");
            return !regNoDig.IsMatch(resStatusStr) && regDig.IsMatch(resStatusStr);
        }

        public void applyFilters()
        {
            DateTime pickDate = datePickerDate.Value;
            DateTime pickTime = datePickerTime.Value;

            DateTime filterDate = new DateTime(pickDate.Year, pickDate.Month, pickDate.Day, pickTime.Hour, pickTime.Minute, pickTime.Second);

            scanFileInst.filter.date = filterDate;
            scanFileInst.filter.ip = filterIP.Text.Trim();
            scanFileInst.filter.path = filterFileName.Text.Trim();

            string resStatusStr = filterResponseStatus.Text.Trim();

            if (checkValidStatus(resStatusStr))
            {
               scanFileInst.filter.responseStatus = int.Parse(resStatusStr);
            } else
            {
               scanFileInst.filter.responseStatus = -1;
            }
    

            Console.WriteLine($"[applyFilters] {scanFileInst.filter}");
            scanFileInst.filterLogs();
            if (binding != null)
            {
                binding.ResetBindings(true);
            }

            list.Columns.RemoveAt(7);

            foreach (DataGridViewColumn col in list.Columns)
            {
                col.ReadOnly = true;
            }

            foreach (DataGridViewRow row in list.Rows)
            {
                Log l = row.DataBoundItem as Log;
                if ((l != null) && l.accessError)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void filterFileName_TextChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void filterIP_TextChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void filterResponseStatus_TextChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void datePickerTime_ValueChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void datePickerDate_ValueChanged(object sender, EventArgs e)
        {
            applyFilters();
        }
    }
}
