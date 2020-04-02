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
using System.Globalization;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using GMap.NET.WindowsForms;
using GMap.NET;

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
        Dictionary<string, DataLocal> localDataDaily_dict = new Dictionary<string, DataLocal>();
        List<string> timestamp_string_list = new List<string>();
        List<DateTime> timestamp_dt_list = new List<DateTime>();

        List<string> countryList = new List<string>();

        public event EventHandler _data_parsed_event;

        WaitForm waitForm;
        DataPlot dataPlot;
        DataMap dataMap;
        BackgroundWorker getData_bg;
        PlotView mainPlotView;
        PlotModel MainPlotModel;
        PlotModel mainGraphicPlotModel;
        PlotModel mainBarPlotModel;

        #region Initialization

        public MainScreen()
        {
            InitializeComponent();

            InitializeMainScreen();
            InitializePlotView();
            InitializeMapView();

            _data_parsed_event += _data_parsed_triggered;

            dataPlot = new DataPlot();
            dataMap = new DataMap();

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
            mainGraphicPlotModel = new PlotModel();
            mainBarPlotModel = new PlotModel();

            MainPlotModel.PlotType = PlotType.XY;
            mainPlotView.Model = MainPlotModel;
            MainPlotModel.LegendPosition = LegendPosition.LeftTop;
            //MainPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MaximumPadding = 0.1, MinimumPadding = 0.1 });
            MainPlotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "d/M" });
            MainPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1, MajorGridlineStyle = LineStyle.Solid });

            mainGraphicPlotModel.PlotType = PlotType.XY;
            mainGraphicPlotView.Model = mainGraphicPlotModel;
            mainGraphicPlotModel.LegendPosition = LegendPosition.LeftTop;
            mainGraphicPlotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "d/M" });
            mainGraphicPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1, MajorGridlineStyle = LineStyle.Solid });

            mainBarPlotModel.PlotType = PlotType.XY;
            mainBarPlotView.Model = mainBarPlotModel;
            mainBarPlotModel.LegendPosition = LegendPosition.BottomLeft;
            //mainBarPlotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "d/M" });
            //mainBarPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1, MajorGridlineStyle = LineStyle.Solid });

            mainPlotView.Dock = DockStyle.Fill;
            tableLayoutPanel3.Controls.Add(mainPlotView, 0, 0);

            plotTypeComboBox.DataSource = Enum.GetValues(typeof(PlotTypes));
            plotTypeComboBox.SelectedItem = PlotTypes.Confirmed_deaths_recovered.ToString();
        }

        private void InitializeMapView()
        {
            mainGMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
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

            dataParser.CSVParser(@"D:\COVID-19\csse_covid_19_data\csse_covid_19_time_series\time_series_covid19_confirmed_global.csv", out globalDataConfirmed_dict, out timestamp_string_list);
            dataParser.CSVParser(@"D:\COVID-19\csse_covid_19_data\csse_covid_19_time_series\time_series_covid19_deaths_global.csv", out globalDataDeaths_dict, out timestamp_string_list);
            dataParser.CSVParser(@"D:\COVID-19\csse_covid_19_data\csse_covid_19_time_series\time_series_covid19_recovered_global.csv", out globalDataRecovered_dict, out timestamp_string_list);

            // Get current datetime to get data from updated daily
            DateTime current_datetime = DateTime.Now;
            DateTime yesterday_datetime = current_datetime.AddDays(-1);
            string fileName = yesterday_datetime.ToString("MM-dd-yyyy") + ".csv";
            dataParser.CSVDailyParser(@"D:\COVID-19\csse_covid_19_data\csse_covid_19_daily_reports\" + fileName, out localDataDaily_dict);

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

        private void GetMainGlobalPlot()
        {
            if (isDataParsed)
            {
                List<List<PointF>> global_data = new List<List<PointF>>();
                List<string> series_name;

                global_data = dataPlot.GetListOfPoints_GlobalCDR(globalDataConfirmed_dict, globalDataDeaths_dict, globalDataRecovered_dict, out series_name);

                for (int i = 0; i < global_data.Count; i++)
                {
                    LineSeries serie = new LineSeries();

                    serie.MarkerSize = 2;
                    serie.MarkerFill = Color.Gray.ToOxyColor();
                    serie.MarkerType = MarkerType.Circle;
                    serie.LineStyle = LineStyle.Solid;
                    serie.Color = ColorTypes()[i].ToOxyColor();
                    serie.Title = series_name[i];
                    //serie.Smooth = true;

                    foreach (var item in global_data[i])
                    {
                        DataPoint point = new DataPoint(DateTimeAxis.ToDouble(timestamp_dt_list[(int)item.X]), item.Y);
                        serie.Points.Add(point);
                    }

                    mainGraphicPlotModel.Series.Add(serie);
                    mainGraphicPlotView.Invoke((Action)delegate
                    {
                        mainGraphicPlotView.InvalidatePlot(true);
                    });
                }

                // Configure datetime axis according to data
                DateTime firstEntry = DateTime.ParseExact(timestamp_string_list[0], "M/d/yy", CultureInfo.InvariantCulture);
                MainPlotModel.Axes[0].Minimum = DateTimeAxis.ToDouble(firstEntry);
                DateTime lastEntry = DateTime.ParseExact(timestamp_string_list[timestamp_string_list.Count - 1], "M/d/yy", CultureInfo.InvariantCulture);
                MainPlotModel.Axes[0].Maximum = DateTimeAxis.ToDouble(lastEntry);
            }
        }

        private void GetMainGlobalBarPlot()
        {
            if (isDataParsed)
            {
                var sorted_data = GetGlobalDataConfirmedSorted();
                int _bar_char_limit = 25;
                BarSeries serie = new BarSeries();
                var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };

                for (int i = 0; i < _bar_char_limit; i++)
                {
                    serie.Items.Add(new BarItem { Value = sorted_data[i].Item2 });
                    categoryAxis.Labels.Add(sorted_data[i].Item1);
                }
                mainBarPlotModel.Axes.Add(categoryAxis);
                mainBarPlotModel.Series.Add(serie);
                mainBarPlotView.Invoke((Action)delegate
                {
                    mainBarPlotView.InvalidatePlot(true);
                });
            }
        }

        private List<Tuple<string, int>> GetGlobalDataConfirmedSorted()
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();

            foreach(var item in globalDataConfirmed_dict)
            {
                string country = item.Key;
                int last_value = item.Value.NATIONAL_DATA.DATA[item.Value.NATIONAL_DATA.DATA.Keys.ToList()[item.Value.NATIONAL_DATA.DATA.Count - 1]];

                result.Add(new Tuple<string, int>(country, last_value));
            }

            result.Sort((a, b) => b.Item2.CompareTo(a.Item2));

            return result;
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
                DataPoint point = new DataPoint(DateTimeAxis.ToDouble(timestamp_dt_list[(int)item.X]), item.Y);
                serie.Points.Add(point);
            }

            MainPlotModel.Series.Add(serie);
            mainPlotView.InvalidatePlot(true);
        }

        private void refreshPlotButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDataParsed)
                {
                    // Clear plot
                    clearPlot();

                    List<string> SeriesNames = new List<string>();
                    List<List<PointF>> globalList = GetPlotType((PlotTypes)Enum.Parse(typeof(PlotTypes), plotTypeComboBox.SelectedItem.ToString()), out SeriesNames);

                    for (int i = 0; i < globalList.Count; i++)
                    {
                        PlotDataIntoView(globalList[i], ColorTypes()[i], SeriesNames[i]);
                    }

                    // Configure datetime axis according to data
                    DateTime firstEntry = DateTime.ParseExact(timestamp_string_list[0], "M/d/yy", CultureInfo.InvariantCulture);
                    MainPlotModel.Axes[0].Minimum = DateTimeAxis.ToDouble(firstEntry);
                    DateTime lastEntry = DateTime.ParseExact(timestamp_string_list[timestamp_string_list.Count - 1], "M/d/yy", CultureInfo.InvariantCulture);
                    MainPlotModel.Axes[0].Maximum = DateTimeAxis.ToDouble(lastEntry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while plotting. " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logScaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (logScaleCheckBox.Checked)
            {
                MainPlotModel.Axes[1].Reset();
                MainPlotModel.Axes[1] = new LogarithmicAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1, MajorGridlineStyle = LineStyle.Solid };
            }
            else
            {
                MainPlotModel.Axes[1].Reset();
                MainPlotModel.Axes[1] = new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1, MajorGridlineStyle = LineStyle.Solid };
            }
        }

        private void ConvertTimeStringToDT()
        {
            foreach(string item in timestamp_string_list)
            {
                timestamp_dt_list.Add(DateTime.ParseExact(item, "M/d/yy", CultureInfo.InvariantCulture));
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

        #region Map tab

        private void refreshMapButton_Click(object sender, EventArgs e)
        {
            if (isDataParsed)
            {
                mainGMapControl.Overlays.Clear();
                GMapOverlay overlayOne = new GMapOverlay("polygons");

                foreach(var item in localDataDaily_dict)
                {
                    DataLocal _dataDailyLocal = item.Value;
                    int _data = 0;
                    if (confirmedMapRadioButton.Checked)
                        _data = _dataDailyLocal.LOCAL_DATA.LOCAL_DAILY_CONFIRMED;
                    else if (deathsMapRadioButton.Checked)
                        _data = _dataDailyLocal.LOCAL_DATA.LOCAL_DAILY_DEATHS;
                    else if (recoveredMapRadioButton.Checked)
                        _data = _dataDailyLocal.LOCAL_DATA.LOCAL_DAILY_RECOVERED;
                    else
                        MessageBox.Show("No map salected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    string country_tag = "pol_" + item.Key;
                    double radious = Convert.ToDouble(_data) / (double)8000;
                    double coordinate_lat = _dataDailyLocal.LOCAL_DATA.COORDINATES[0];
                    double coordinate_lon = _dataDailyLocal.LOCAL_DATA.COORDINATES[1];

                    GMapPolygon gpol = dataMap.GetMapCircle(radious, new PointF((float)coordinate_lat, (float)coordinate_lon), country_tag);
                    gpol.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    gpol.Stroke = new Pen(Color.Red, 1);
                    overlayOne.Polygons.Add(gpol);
                }

                mainGMapControl.Overlays.Add(overlayOne);

                mainGMapControl.Update();
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

            // Get datetime data from string
            ConvertTimeStringToDT();

            GetMainGlobalPlot();
            GetMainGlobalBarPlot();
        }

        #region Plot types
        private enum PlotTypes : int
        {
            Confirmed_deaths_recovered = 0,
            Daily_confirmed = 1,
            Daily_deaths = 2,
            Letality = 3
        }

        private Color[] ColorTypes()
        {
            return new Color[] { Color.Black, Color.DarkBlue, Color.DarkRed, Color.DarkGoldenrod };
        }

        private List<List<PointF>> GetPlotType(PlotTypes plotTypes, out List<string> series_name)
        {
            List<List<PointF>> result = new List<List<PointF>>();
            series_name = new List<string>();
            switch (plotTypes)
            {
                case PlotTypes.Confirmed_deaths_recovered:
                    result = dataPlot.GetListOfPoints_CDR(globalDataConfirmed_dict, globalDataDeaths_dict, globalDataRecovered_dict, countryComboBox.Text, out series_name);

                    break;

                case PlotTypes.Daily_confirmed:
                    result = dataPlot.GetListOfPoints_dailyConfirmed(globalDataConfirmed_dict, countryComboBox.Text, out series_name);

                    break;

                case PlotTypes.Daily_deaths:
                    result = dataPlot.GetListOfPoints_dailyDeaths(globalDataDeaths_dict, countryComboBox.Text, out series_name);

                    break;

                case PlotTypes.Letality:
                    result = dataPlot.GetListOfPoints_dailyLetality(globalDataConfirmed_dict, globalDataDeaths_dict, countryComboBox.Text, out series_name);

                    break;

                default:
                    throw new Exception("Plot type selection error");
            }

            return result;
        }

        #endregion
    }
}
