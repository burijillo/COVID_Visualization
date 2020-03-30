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
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using OxyPlot.Annotations;

using COVID_Visualization.Forms;
using COVID_Visualization.Data;

namespace COVID_Visualization
{
    public partial class MainScreen : Form
    {
        private bool isDataParsed = false;
        Dictionary<string, DataNational> globalDataConfirmed_dict = new Dictionary<string, DataNational>();
        Dictionary<string, DataNational> globalDataDeaths_dict = new Dictionary<string, DataNational>();
        Dictionary<string, DataNational> globalDataRecovered_dict = new Dictionary<string, DataNational>();
        List<string> countryList = new List<string>();

        public event EventHandler _data_parsed_event;

        WaitForm waitForm;
        BackgroundWorker getData_bg;
        PlotView mainPlotView;
        PlotModel MainPlotModel;

        #region Initialization

        public MainScreen()
        {
            InitializeComponent();

            InitializeMainScreen();
            InitializePlotView();

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

        private void InitializePlotView()
        {
            MainPlotModel = new PlotModel();
            mainPlotView = new PlotView();

            MainPlotModel.PlotType = PlotType.XY;
            mainPlotView.Model = MainPlotModel;
            MainPlotModel.LegendPosition = LegendPosition.LeftTop;
            MainPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MaximumPadding = 0.1, MinimumPadding = 0.1 });
            MainPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1, MajorGridlineStyle = LineStyle.Solid });

            mainPlotView.Dock = DockStyle.Fill;
            tableLayoutPanel3.Controls.Add(mainPlotView, 0, 0);

            plotTypeComboBox.DataSource = Enum.GetValues(typeof(PlotTypes));
            plotTypeComboBox.SelectedItem = PlotTypes.Confirmed_deaths_recovered.ToString();
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

            dataParser.CSVParser(@"D:\COVID-19\csse_covid_19_data\csse_covid_19_time_series\time_series_covid19_confirmed_global.csv", out globalDataConfirmed_dict);
            dataParser.CSVParser(@"D:\COVID-19\csse_covid_19_data\csse_covid_19_time_series\time_series_covid19_deaths_global.csv", out globalDataDeaths_dict);
            dataParser.CSVParser(@"D:\COVID-19\csse_covid_19_data\csse_covid_19_time_series\time_series_covid19_recovered_global.csv", out globalDataRecovered_dict);
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
                    mainDataGridView.ColumnCount = 4;
                    mainDataGridView.Columns[0].Name = "Country";
                    mainDataGridView.Columns[1].Name = "Confirmed cases";
                    mainDataGridView.Columns[2].Name = "Deaths";
                    mainDataGridView.Columns[3].Name = "Recovered";
                });

                foreach(var item in globalDataConfirmed_dict)
                {
                    string country = item.Key;
                    int confirmed = item.Value.NATIONAL_DATA.DATA.Values.ToArray()[item.Value.NATIONAL_DATA.DATA.Count - 1];
                    int deaths = globalDataDeaths_dict[country].NATIONAL_DATA.DATA.Values.ToArray()[item.Value.NATIONAL_DATA.DATA.Count - 1];
                    int recovered = globalDataRecovered_dict[country].NATIONAL_DATA.DATA.Values.ToArray()[item.Value.NATIONAL_DATA.DATA.Count - 1];
                    string[] row = new string[] { country, confirmed.ToString(), deaths.ToString(), recovered.ToString() };

                    mainDataGridView.Invoke((Action)delegate
                    {
                        mainDataGridView.Rows.Add(row);
                    });
                }
            }
        }

        private void GetCountryList()
        {
            if (isDataParsed)
            {
                countryList = globalDataConfirmed_dict.Keys.ToList();
            }
        }

        #endregion

        #region Plot tab

        private void PlotDataIntoView(List<PointF> _plotPointsSerie, Color _colorSerie, string _nameSerie)
        {
            LineSeries serie = new LineSeries();

            serie.MarkerSize = 2;
            serie.MarkerFill = Color.Gray.ToOxyColor();
            serie.MarkerType = MarkerType.Circle;
            serie.LineStyle = LineStyle.Solid;
            serie.Color = _colorSerie.ToOxyColor();
            serie.Title = _nameSerie;
            //serie.Smooth = true;

            foreach (var item in _plotPointsSerie)
            {
                DataPoint point = new DataPoint(item.X, item.Y);
                serie.Points.Add(point);
            }

            MainPlotModel.Series.Add(serie);
            mainPlotView.InvalidatePlot(true);
        }

        private void refreshPlotButton_Click(object sender, EventArgs e)
        {
            if(isDataParsed)
            {
                // Clear plot
                clearPlot();

                List<string> SeriesNames = new List<string>();
                List<List<PointF>> globalList = GetListOfPointsToPlot((PlotTypes)Enum.Parse(typeof(PlotTypes), plotTypeComboBox.SelectedItem.ToString()), out SeriesNames);

                for (int i = 0; i < globalList.Count; i++)
                {
                    PlotDataIntoView(globalList[i], ColorTypes()[i], SeriesNames[i]);
                }
            }
        }

        private void clearPlot()
        {
            MainPlotModel.Series.Clear();
            MainPlotModel.Axes[0].Reset();
            MainPlotModel.Axes[1].Reset();
            mainPlotView.InvalidatePlot(true);
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

            GetCountryList();

            // List all countries to plot
            countryComboBox.Invoke((Action)delegate
            {
                foreach(string country in countryList)
                {
                    countryComboBox.Items.Add(country);
                }

                countryComboBox.SelectedItem = "Spain";
                countryComboBox.Enabled = true;
            });
        }

        #region Plot types

        private enum PlotTypes : int
        {
            Confirmed_deaths_recovered = 0,
            Confirmed = 1
        }

        private Color[] ColorTypes()
        {
            return new Color[] { Color.Black, Color.DarkBlue, Color.DarkRed, Color.DarkGoldenrod };
        }

        private List<List<PointF>> GetListOfPointsToPlot(PlotTypes plotType, out List<string> seriesNames)
        {
            List<List<PointF>> result = new List<List<PointF>>();
            seriesNames = new List<string>();

            switch (plotType)
            {
                case PlotTypes.Confirmed_deaths_recovered:
                    // Get confirmed cases
                    seriesNames.Add("Confirmed");
                    List<PointF> confirmed_pointList = new List<PointF>();
                    float counter = 0;
                    foreach (var item in globalDataConfirmed_dict[countryComboBox.Text].NATIONAL_DATA.DATA)
                    {
                        float value = (float)item.Value;
                        confirmed_pointList.Add(new PointF(counter, value));
                        counter++;
                    }
                    result.Add(confirmed_pointList);
                    counter = 0;

                    // Get death cases
                    seriesNames.Add("Deaths");
                    List<PointF> deaths_pointList = new List<PointF>();
                    foreach (var item in globalDataDeaths_dict[countryComboBox.Text].NATIONAL_DATA.DATA)
                    {
                        float value = (float)item.Value;
                        deaths_pointList.Add(new PointF(counter, value));
                        counter++;
                    }
                    result.Add(deaths_pointList);
                    counter = 0;

                    // Get recovered cases
                    seriesNames.Add("Recovered");
                    List<PointF> recovered_pointList = new List<PointF>();
                    foreach (var item in globalDataRecovered_dict[countryComboBox.Text].NATIONAL_DATA.DATA)
                    {
                        float value = (float)item.Value;
                        recovered_pointList.Add(new PointF(counter, value));
                        counter++;
                    }
                    result.Add(recovered_pointList);

                    break;
            }

            return result;
        }

        #endregion
    }
}
