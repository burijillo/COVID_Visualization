using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using COVID_Visualization.Forms;
using COVID_Visualization.Data;

namespace COVID_Visualization
{
    public partial class MainScreen : Form
    {
        private bool isDataParsed = false;
        Dictionary<string, DataNational> globalData_dict = new Dictionary<string, DataNational>();

        public event EventHandler _data_parsed_event;

        WaitForm waitForm;
        BackgroundWorker getData_bg;

        #region Initialization

        public MainScreen()
        {
            InitializeComponent();

            InitializeMainScreen();

            _data_parsed_event += _data_parsed_triggered;

            getData_bg = new BackgroundWorker();
            getData_bg.DoWork += GetData_bg_DoWork;
            getData_bg.RunWorkerCompleted += GetData_bg_RunWorkerCompleted;
        }

        private void InitializeMainScreen()
        {
            isDataParsed = false;

            mainDataPanel.Enabled = false;
        }

        #endregion

        #region DataTab

        private void getDataFromWebButton_Click(object sender, EventArgs e)
        {
            waitForm = new WaitForm("HOSTIA PILOTES");
            waitForm.Show();

            getData_bg.RunWorkerAsync();
        }

        private void GetData_bg_DoWork(object sender, DoWorkEventArgs e)
        {
            DataParser dataParser = new DataParser();

            dataParser.CSVParser(@"D:\COVID-19\csse_covid_19_data\csse_covid_19_time_series\time_series_covid19_confirmed_global.csv", out globalData_dict);
            _data_parsed_event?.Invoke(sender, e);
        }

        private void GetData_bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitForm.Close();
        }

        private void FillDataSet()
        {
            // Fill dataset with parsed data
            if (isDataParsed)
            {
                // Initialize mainDataGridView
                mainDataGridView.Invoke((Action)delegate
                {
                    mainDataGridView.ColumnCount = 2;
                    mainDataGridView.Columns[0].Name = "Country";
                    mainDataGridView.Columns[1].Name = "Confirmed cases";
                });

                foreach(var item in globalData_dict)
                {
                    string country = item.Key;
                    int confirmed = item.Value.NATIONAL_DATA.DATA.Values.ToArray()[item.Value.NATIONAL_DATA.DATA.Count - 1];
                    string[] row = new string[] { country, confirmed.ToString() };

                    mainDataGridView.Invoke((Action)delegate
                    {
                        mainDataGridView.Rows.Add(row);
                    });
                }
            }
        }

        #endregion

        public void _data_parsed_triggered(object sender, EventArgs e)
        {
            isDataParsed = true;

            mainDataPanel.Invoke((Action)delegate
            {
                mainDataPanel.Enabled = true;
            });

            mainDataGridView.Invoke((Action)delegate
            {
                mainDataGridView.Rows.Clear();
                mainDataGridView.Refresh();
            });

            FillDataSet();

            // Disable get data button
            getDataFromWebButton.Invoke((Action)delegate
            {
                getDataFromWebButton.Enabled = false;
            });
        }
    }
}
