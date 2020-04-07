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
using System.Net;
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
        Dictionary<string, DataNational> spainDataConfirmed_dict = new Dictionary<string, DataNational>();
        Dictionary<string, DataNational> globalDataDeaths_dict = new Dictionary<string, DataNational>();
        Dictionary<string, DataNational> spainDataDeaths_dict = new Dictionary<string, DataNational>();
        Dictionary<string, DataNational> globalDataRecovered_dict = new Dictionary<string, DataNational>();
        Dictionary<string, DataNational> spainDataRecovered_dict = new Dictionary<string, DataNational>();
        Dictionary<string, DataLocal> localDataDaily_dict = new Dictionary<string, DataLocal>();
        List<string> timestamp_string_list = new List<string>();
        List<string> timestampSpain_string_list = new List<string>();
        List<DateTime> timestamp_dt_list = new List<DateTime>();
        List<DateTime> timestampSpain_dt_list = new List<DateTime>();

        List<string> countryList = new List<string>();
        List<string> spainRegionList = new List<string>();

        public event EventHandler _data_parsed_event;
        public event EventHandler _model_data_event;

        WaitForm waitForm;
        DataPlot dataPlot;
        DataMap dataMap;
        Models models;
        BackgroundWorker getData_bg;
        PlotView mainPlotView;
        PlotModel MainPlotModel;
        PlotModel mainGraphicPlotModel;
        PlotModel mainBarPlotModel;
        PlotModel spainPlotModel;
        PlotModel modelPlotModel;

        #region Initialization

        public MainScreen()
        {
            InitializeComponent();

            InitializeMainScreen();
            InitializePlotView();
            InitializeMapView();
            InitializeModelsView();

            _data_parsed_event += _data_parsed_triggered;
            _model_data_event += _model_data_updated;

            dataPlot = new DataPlot();
            dataMap = new DataMap();
            models = new Models();

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
            spainPlotModel = new PlotModel();
            modelPlotModel = new PlotModel();

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

            spainPlotModel.PlotType = PlotType.XY;
            spainPlotView.Model = spainPlotModel;
            spainPlotModel.LegendPosition = LegendPosition.LeftTop;
            spainPlotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "d/M" });
            spainPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1, MajorGridlineStyle = LineStyle.Solid });

            modelPlotModel.PlotType = PlotType.XY;
            modelPlotView.Model = modelPlotModel;
            modelPlotModel.LegendPosition = LegendPosition.LeftTop;

            mainPlotView.Dock = DockStyle.Fill;
            tableLayoutPanel3.Controls.Add(mainPlotView, 0, 0);

            plotTypeComboBox.DataSource = Enum.GetValues(typeof(PlotTypes));
            plotTypeComboBox.SelectedItem = PlotTypes.Confirmed_deaths_recovered.ToString();
            spainPlotTypeComboBox.DataSource = Enum.GetValues(typeof(PlotTypes));
            spainPlotTypeComboBox.SelectedItem = PlotTypes.Confirmed_deaths_recovered.ToString();
        }

        private void InitializeMapView()
        {
            mainGMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
        }

        private void InitializeModelsView()
        {
            foreach(var item in Enum.GetNames(typeof(ModelTypes)))
            {
                modelsComboBox.Items.Add(item.ToString());
            }
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
                    List<List<PointF>> globalList = GetPlotType((PlotTypes)Enum.Parse(typeof(PlotTypes), plotTypeComboBox.SelectedItem.ToString()), false, out SeriesNames);

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

        private void ConvertTimeStringToDT(bool spain_data)
        {
            if (!spain_data)
            {
                foreach (string item in timestamp_string_list)
                {
                    timestamp_dt_list.Add(DateTime.ParseExact(item, "M/d/yy", CultureInfo.InvariantCulture));
                } 
            }
            else
            {
                foreach (string item in timestampSpain_string_list)
                {
                    timestampSpain_dt_list.Add(DateTime.ParseExact(item, "dd/MM/yyyy", CultureInfo.InvariantCulture));
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

        private void spainPlotRefreshButton_Click(object sender, EventArgs e)
        {
            clearSpainPlot();
            List<string> SeriesNames;
            List<List<PointF>> spainList = GetPlotType((PlotTypes)Enum.Parse(typeof(PlotTypes), spainPlotTypeComboBox.SelectedItem.ToString()), true, out SeriesNames);

            for (int i = 0; i < spainList.Count; i++)
            {
                LineSeries serie = new LineSeries();

                serie.MarkerSize = 2;
                serie.MarkerFill = Color.Gray.ToOxyColor();
                serie.MarkerType = MarkerType.Circle;
                serie.LineStyle = LineStyle.Solid;
                serie.Color = ColorTypes()[i].ToOxyColor();
                serie.Title = SeriesNames[i];
                //serie.Smooth = true;

                foreach (var item in spainList[i])
                {
                    DataPoint point = new DataPoint(DateTimeAxis.ToDouble(timestampSpain_dt_list[(int)item.X]), item.Y);
                    serie.Points.Add(point);
                }

                spainPlotModel.Series.Add(serie);
                spainPlotView.InvalidatePlot(true);
            }

            // Configure datetime axis according to data
            DateTime firstEntry = DateTime.ParseExact(timestampSpain_string_list[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            MainPlotModel.Axes[0].Minimum = DateTimeAxis.ToDouble(firstEntry);
            DateTime lastEntry = DateTime.ParseExact(timestampSpain_string_list[timestampSpain_string_list.Count - 1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            MainPlotModel.Axes[0].Maximum = DateTimeAxis.ToDouble(lastEntry);
        }

        private void spainLogScaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (spainLogScaleCheckBox.Checked)
            {
                spainPlotModel.Axes[1].Reset();
                spainPlotModel.Axes[1] = new LogarithmicAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1, MajorGridlineStyle = LineStyle.Solid };
            }
            else
            {
                spainPlotModel.Axes[1].Reset();
                spainPlotModel.Axes[1] = new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1, MajorGridlineStyle = LineStyle.Solid };
            }
        }

        private void clearSpainPlot()
        {
            spainPlotModel.Series.Clear();
            spainPlotModel.Axes[0].Reset();
            spainPlotModel.Axes[1].Reset();
            spainPlotView.InvalidatePlot(true);
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

        #region Spain data

        // This is not done in other thread as it is not recquired at this day
        private void spainGetDataButton_Click(object sender, EventArgs e)
        {
            using(var client = new WebClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                client.DownloadFile("https://covid19.isciii.es/resources/serie_historica_acumulados.csv", "tmp_spain_data.csv");
            }

            DataParser dataParser = new DataParser();
            dataParser.CSVSpainDataParser("tmp_spain_data.csv", out spainDataConfirmed_dict, out spainDataDeaths_dict, out spainDataRecovered_dict, out timestampSpain_string_list, out spainRegionList);

            // Fill region data combobox
            foreach (string region in spainRegionList)
            {
                spainRegionComboBox.Items.Add(region);
            }
            spainRegionComboBox.SelectedItem = "MD";

            ConvertTimeStringToDT(true);
        }

        #endregion

        #region Models

        private List<List<PointF>> getSelectedModelData(object sender, ModelTypes model_type, out List<string> series_name)
        {
            List<List<PointF>> result = new List<List<PointF>>();
            series_name = new List<string>();

            switch (model_type)
            {
                case ModelTypes.Simple:
                    // Check sender control
                    int _s_perc = ((TrackBar)(modelsTableLayoutPanel.GetControlFromPosition(0, 2)) as TrackBar).Value;
                    double _infected = 0;
                    double _removed = 0;
                    double _inf_rate = 0;
                    double _rec_rate = 0;
                    if (!string.IsNullOrEmpty(((TextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, 4)) as TextBox).Text))
                         _infected = Convert.ToDouble(((TextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, 4)) as TextBox).Text);
                    if (!string.IsNullOrEmpty(((TextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, 6)) as TextBox).Text))
                        _removed = Convert.ToDouble(((TextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, 6)) as TextBox).Text);
                    if (!string.IsNullOrEmpty(((TextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, 8)) as TextBox).Text))
                        _inf_rate = Convert.ToDouble(((TextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, 8)) as TextBox).Text.Replace('.',','));
                    if (!string.IsNullOrEmpty(((TextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, 10)) as TextBox).Text))
                        _rec_rate = Convert.ToDouble(((TextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, 10)) as TextBox).Text.Replace('.', ','));

                    result = models.simpleSIR_model(_s_perc, _infected, _removed, _inf_rate, _rec_rate, out series_name);

                    break;

                default:
                    MessageBox.Show("Wrong model selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }

            return result;
        }

        private void generateModelControls_Simple()
        {
            // TODO clear every control except main selector
            int row_count = modelsTableLayoutPanel.RowCount;
            for (int i = 1; i < row_count; i++)
            {
                Control c = modelsTableLayoutPanel .GetControlFromPosition(0, i);
                modelsTableLayoutPanel.Controls.Remove(c);
                modelsTableLayoutPanel.RowCount--;
            }

            // Generate susceptible population control input
            Label _trackbarLabel = new Label();
            _trackbarLabel.Text = "Susceptible population percentage";
            _trackbarLabel.Dock = DockStyle.Fill;
            _trackbarLabel.TextAlign = ContentAlignment.MiddleLeft;
            modelsTableLayoutPanel.RowCount += 1;
            modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            modelsTableLayoutPanel.Controls.Add(_trackbarLabel, 0, 1);

            TrackBar _trackbar = new TrackBar();
            _trackbar.Maximum = 100;
            _trackbar.Minimum = 0;
            _trackbar.Value = 90;
            _trackbar.Dock = DockStyle.Fill;
            _trackbar.ValueChanged += _modelControl_ValueChanged;
            modelsTableLayoutPanel.RowCount += 1;
            modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            modelsTableLayoutPanel.Controls.Add(_trackbar, 0, 2);

            // Generate infected population control input
            Label _infectedLabel = new Label();
            _infectedLabel.Text = "Initial infected";
            _infectedLabel.Dock = DockStyle.Fill;
            _infectedLabel.TextAlign = ContentAlignment.MiddleLeft;
            modelsTableLayoutPanel.RowCount += 1;
            modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            modelsTableLayoutPanel.Controls.Add(_infectedLabel, 0, 3);

            TextBox _infected_textBox = new TextBox();
            _infected_textBox.Text = "0";
            _infected_textBox.Dock = DockStyle.Fill;
            _infected_textBox.TextChanged += _modelControl_ValueChanged;
            modelsTableLayoutPanel.RowCount += 1;
            modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            modelsTableLayoutPanel.Controls.Add(_infected_textBox, 0, 4);

            // Generate removed population control input
            Label _removedLabel = new Label();
            _removedLabel.Text = "Initial removed";
            _removedLabel.Dock = DockStyle.Fill;
            _removedLabel.TextAlign = ContentAlignment.MiddleLeft;
            modelsTableLayoutPanel.RowCount += 1;
            modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            modelsTableLayoutPanel.Controls.Add(_removedLabel, 0, 5);

            TextBox _removed_textBox = new TextBox();
            _removed_textBox.Text = "0";
            _removed_textBox.Dock = DockStyle.Fill;
            _removed_textBox.TextChanged += _modelControl_ValueChanged;
            modelsTableLayoutPanel.RowCount += 1;
            modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            modelsTableLayoutPanel.Controls.Add(_removed_textBox, 0, 6);

            // Generate infected rate control input
            Label _infectedRateLabel = new Label();
            _infectedRateLabel.Text = "Infected rate";
            _infectedRateLabel.Dock = DockStyle.Fill;
            _infectedRateLabel.TextAlign = ContentAlignment.MiddleLeft;
            modelsTableLayoutPanel.RowCount += 1;
            modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            modelsTableLayoutPanel.Controls.Add(_infectedRateLabel, 0, 7);

            TextBox _infectedRate_textBox = new TextBox();
            _infectedRate_textBox.Text = "1.0";
            _infectedRate_textBox.Dock = DockStyle.Fill;
            _infectedRate_textBox.TextChanged += _modelControl_ValueChanged;
            modelsTableLayoutPanel.RowCount += 1;
            modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            modelsTableLayoutPanel.Controls.Add(_infectedRate_textBox, 0, 8);

            // Generate recovery rate control input
            Label _recoveryRateLabel = new Label();
            _recoveryRateLabel.Text = "Recovery rate";
            _recoveryRateLabel.Dock = DockStyle.Fill;
            _recoveryRateLabel.TextAlign = ContentAlignment.MiddleLeft;
            modelsTableLayoutPanel.RowCount += 1;
            modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            modelsTableLayoutPanel.Controls.Add(_recoveryRateLabel, 0, 9);

            TextBox _recoveryRate_textBox = new TextBox();
            _recoveryRate_textBox.Text = "1.0";
            _recoveryRate_textBox.Dock = DockStyle.Fill;
            _recoveryRate_textBox.TextChanged += _modelControl_ValueChanged;
            modelsTableLayoutPanel.RowCount += 1;
            modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            modelsTableLayoutPanel.Controls.Add(_recoveryRate_textBox, 0, 10);

            // Add summary log
            RichTextBox _log_richTextBox = new RichTextBox();
            _log_richTextBox.Dock = DockStyle.Fill;
            modelsTableLayoutPanel.RowCount += 1;
            //modelsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            modelsTableLayoutPanel.Controls.Add(_log_richTextBox, 0, 11);
        }

        private void _modelControl_ValueChanged(object sender, EventArgs e)
        {
            // This trackbar serves as input for the susceptible population percentage
            _model_data_event.Invoke(sender, e);
        }

        private void modelsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateModelControls_Simple();
            _model_data_event.Invoke(this, e);
        }

        private void refreshModelButton_Click(object sender, EventArgs e)
        {
            _model_data_event.Invoke(this, e);
        }

        private void _model_data_updated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(modelsComboBox.SelectedItem.ToString()))
            {
                // Get model data
                List<List<PointF>> model_data = new List<List<PointF>>();
                List<string> series_name;
                ModelTypes _model = (ModelTypes)Enum.Parse(typeof(ModelTypes), modelsComboBox.SelectedItem.ToString());
                model_data = getSelectedModelData(sender, _model, out series_name);

                paintModelsData(model_data, series_name);

                if (model_data[2].Count != 0)
                {
                    // Summary log
                    RichTextBox _log_richTextBox = (RichTextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, modelsTableLayoutPanel.RowCount - 1) as RichTextBox);
                    _log_richTextBox.Text = "Model data summary:\nIterations: " + model_data[2].Count + " \nRemoved: " + model_data[2][model_data[2].Count - 1].Y.ToString() + "\nSusceptible: " + model_data[0][model_data[0].Count - 1].Y.ToString() + "\nR_0: " + (Convert.ToDouble(((TextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, 8)) as TextBox).Text.Replace('.', ',')) / Convert.ToDouble(((TextBox)(modelsTableLayoutPanel.GetControlFromPosition(0, 10)) as TextBox).Text.Replace('.', ',')));
                }
            }
        }

        private void paintModelsData(List<List<PointF>> data, List<string> series_name)
        {
            // Clear plot data
            modelPlotModel.Series.Clear();
            //modelPlotModel.Axes[0].Reset();
            //modelPlotModel.Axes[1].Reset();
            modelPlotView.InvalidatePlot(true);

            // Plot data
            for (int i = 0; i < data.Count; i++)
            {
                LineSeries serie = new LineSeries();

                serie.MarkerSize = 2;
                serie.MarkerFill = ColorTypes()[i].ToOxyColor();
                serie.MarkerType = MarkerType.Circle;
                serie.LineStyle = LineStyle.Solid;
                serie.Color = ColorTypes()[i].ToOxyColor();
                serie.Title = series_name[i];

                foreach (var item in data[i])
                {
                    DataPoint point = new DataPoint(item.X, item.Y);
                    serie.Points.Add(point);
                }

                modelPlotModel.Series.Add(serie);
                modelPlotView.InvalidatePlot(true);
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
            ConvertTimeStringToDT(false);

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

        private List<List<PointF>> GetPlotType(PlotTypes plotTypes, bool spain_data, out List<string> series_name)
        {
            List<List<PointF>> result = new List<List<PointF>>();
            series_name = new List<string>();
            switch (plotTypes)
            {
                case PlotTypes.Confirmed_deaths_recovered:
                    if (!spain_data)
                        result = dataPlot.GetListOfPoints_CDR(globalDataConfirmed_dict, globalDataDeaths_dict, globalDataRecovered_dict, countryComboBox.Text, out series_name);
                    else
                        result = dataPlot.GetListOfPoints_CDR(spainDataConfirmed_dict, spainDataDeaths_dict, spainDataRecovered_dict, spainRegionComboBox.Text, out series_name);

                    break;

                case PlotTypes.Daily_confirmed:
                    if (!spain_data)
                        result = dataPlot.GetListOfPoints_dailyConfirmed(globalDataConfirmed_dict, countryComboBox.Text, out series_name);
                    else
                        result = dataPlot.GetListOfPoints_dailyConfirmed(spainDataConfirmed_dict, spainRegionComboBox.Text, out series_name);

                    break;

                case PlotTypes.Daily_deaths:
                    if (!spain_data)
                        result = dataPlot.GetListOfPoints_dailyDeaths(globalDataDeaths_dict, countryComboBox.Text, out series_name);
                    else
                        result = dataPlot.GetListOfPoints_dailyDeaths(spainDataDeaths_dict, spainRegionComboBox.Text, out series_name);

                    break;

                case PlotTypes.Letality:
                    if (!spain_data)
                        result = dataPlot.GetListOfPoints_dailyLetality(globalDataConfirmed_dict, globalDataDeaths_dict, countryComboBox.Text, out series_name);
                    else
                        result = dataPlot.GetListOfPoints_dailyLetality(spainDataConfirmed_dict, spainDataDeaths_dict, spainRegionComboBox.Text, out series_name);

                    break;

                default:
                    throw new Exception("Plot type selection error");
            }

            return result;
        }

        #endregion
    }
}
