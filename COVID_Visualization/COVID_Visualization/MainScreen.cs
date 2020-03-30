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

namespace COVID_Visualization
{
    public partial class MainScreen : Form
    {
        private bool isDataParsed = false;

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
        }

        private void GetData_bg_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GetData_bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void _data_parsed_triggered(object sender, EventArgs e)
        {
            isDataParsed = true;

            mainDataPanel.Enabled = true;
        }
    }
}
