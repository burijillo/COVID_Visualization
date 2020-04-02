namespace COVID_Visualization
{
    partial class MainScreen
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.configTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.getDataFromWebButton = new System.Windows.Forms.Button();
            this.mainDataPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.mainGraphicPlotView = new OxyPlot.WindowsForms.PlotView();
            this.plotsTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.plotTypeComboBox = new System.Windows.Forms.ComboBox();
            this.refreshPlotButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.logScaleCheckBox = new System.Windows.Forms.CheckBox();
            this.mapTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.mainGMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.refreshMapButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.recoveredMapRadioButton = new System.Windows.Forms.RadioButton();
            this.deathsMapRadioButton = new System.Windows.Forms.RadioButton();
            this.confirmedMapRadioButton = new System.Windows.Forms.RadioButton();
            this.mainBarPlotView = new OxyPlot.WindowsForms.PlotView();
            this.mainTabControl.SuspendLayout();
            this.configTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.mainDataPanel.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.plotsTabPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mapTabPage.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.configTabPage);
            this.mainTabControl.Controls.Add(this.plotsTabPage);
            this.mainTabControl.Controls.Add(this.mapTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1263, 626);
            this.mainTabControl.TabIndex = 0;
            // 
            // configTabPage
            // 
            this.configTabPage.Controls.Add(this.tableLayoutPanel1);
            this.configTabPage.Location = new System.Drawing.Point(4, 22);
            this.configTabPage.Name = "configTabPage";
            this.configTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.configTabPage.Size = new System.Drawing.Size(1255, 600);
            this.configTabPage.TabIndex = 0;
            this.configTabPage.Text = "Data";
            this.configTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainDataPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.937799F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.0622F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1249, 594);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.19593F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.486F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.44529F));
            this.tableLayoutPanel2.Controls.Add(this.getDataFromWebButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1249, 41);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // getDataFromWebButton
            // 
            this.getDataFromWebButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getDataFromWebButton.Location = new System.Drawing.Point(3, 3);
            this.getDataFromWebButton.Name = "getDataFromWebButton";
            this.getDataFromWebButton.Size = new System.Drawing.Size(133, 35);
            this.getDataFromWebButton.TabIndex = 0;
            this.getDataFromWebButton.Text = "Get data";
            this.getDataFromWebButton.UseVisualStyleBackColor = true;
            this.getDataFromWebButton.Click += new System.EventHandler(this.getDataFromWebButton_Click);
            // 
            // mainDataPanel
            // 
            this.mainDataPanel.Controls.Add(this.tableLayoutPanel7);
            this.mainDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDataPanel.Location = new System.Drawing.Point(0, 41);
            this.mainDataPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainDataPanel.Name = "mainDataPanel";
            this.mainDataPanel.Size = new System.Drawing.Size(1249, 553);
            this.mainDataPanel.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 645F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanel7.Controls.Add(this.mainDataGridView, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.mainGraphicPlotView, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.mainBarPlotView, 2, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1249, 553);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDataGridView.Location = new System.Drawing.Point(3, 3);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(328, 547);
            this.mainDataGridView.TabIndex = 0;
            // 
            // mainGraphicPlotView
            // 
            this.mainGraphicPlotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGraphicPlotView.Location = new System.Drawing.Point(337, 3);
            this.mainGraphicPlotView.Name = "mainGraphicPlotView";
            this.mainGraphicPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.mainGraphicPlotView.Size = new System.Drawing.Size(639, 547);
            this.mainGraphicPlotView.TabIndex = 1;
            this.mainGraphicPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.mainGraphicPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.mainGraphicPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotsTabPage
            // 
            this.plotsTabPage.Controls.Add(this.tableLayoutPanel3);
            this.plotsTabPage.Location = new System.Drawing.Point(4, 22);
            this.plotsTabPage.Name = "plotsTabPage";
            this.plotsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.plotsTabPage.Size = new System.Drawing.Size(1255, 600);
            this.plotsTabPage.TabIndex = 1;
            this.plotsTabPage.Text = "Plots";
            this.plotsTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.38931F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.61069F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 594F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1249, 594);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.refreshPlotButton, 0, 9);
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.logScaleCheckBox, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(991, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 10;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(258, 594);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.plotTypeComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 40);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plot";
            // 
            // plotTypeComboBox
            // 
            this.plotTypeComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plotTypeComboBox.FormattingEnabled = true;
            this.plotTypeComboBox.Location = new System.Drawing.Point(0, 19);
            this.plotTypeComboBox.Name = "plotTypeComboBox";
            this.plotTypeComboBox.Size = new System.Drawing.Size(258, 21);
            this.plotTypeComboBox.TabIndex = 2;
            // 
            // refreshPlotButton
            // 
            this.refreshPlotButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshPlotButton.Location = new System.Drawing.Point(3, 522);
            this.refreshPlotButton.Name = "refreshPlotButton";
            this.refreshPlotButton.Size = new System.Drawing.Size(252, 69);
            this.refreshPlotButton.TabIndex = 0;
            this.refreshPlotButton.Text = "Refresh";
            this.refreshPlotButton.UseVisualStyleBackColor = true;
            this.refreshPlotButton.Click += new System.EventHandler(this.refreshPlotButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.countryComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 40);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Country";
            // 
            // countryComboBox
            // 
            this.countryComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(0, 19);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(258, 21);
            this.countryComboBox.TabIndex = 1;
            // 
            // logScaleCheckBox
            // 
            this.logScaleCheckBox.AutoSize = true;
            this.logScaleCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logScaleCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logScaleCheckBox.Location = new System.Drawing.Point(3, 83);
            this.logScaleCheckBox.Name = "logScaleCheckBox";
            this.logScaleCheckBox.Size = new System.Drawing.Size(252, 19);
            this.logScaleCheckBox.TabIndex = 5;
            this.logScaleCheckBox.Text = "Logarthmic scale";
            this.logScaleCheckBox.UseVisualStyleBackColor = true;
            this.logScaleCheckBox.CheckedChanged += new System.EventHandler(this.logScaleCheckBox_CheckedChanged);
            // 
            // mapTabPage
            // 
            this.mapTabPage.Controls.Add(this.tableLayoutPanel5);
            this.mapTabPage.Location = new System.Drawing.Point(4, 22);
            this.mapTabPage.Name = "mapTabPage";
            this.mapTabPage.Size = new System.Drawing.Size(1255, 600);
            this.mapTabPage.TabIndex = 2;
            this.mapTabPage.Text = "Map";
            this.mapTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.19522F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.80478F));
            this.tableLayoutPanel5.Controls.Add(this.mainGMapControl, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1255, 600);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // mainGMapControl
            // 
            this.mainGMapControl.Bearing = 0F;
            this.mainGMapControl.CanDragMap = true;
            this.mainGMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.mainGMapControl.GrayScaleMode = false;
            this.mainGMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mainGMapControl.LevelsKeepInMemory = 5;
            this.mainGMapControl.Location = new System.Drawing.Point(3, 3);
            this.mainGMapControl.MarkersEnabled = true;
            this.mainGMapControl.MaxZoom = 18;
            this.mainGMapControl.MinZoom = 2;
            this.mainGMapControl.MouseWheelZoomEnabled = true;
            this.mainGMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mainGMapControl.Name = "mainGMapControl";
            this.mainGMapControl.NegativeMode = false;
            this.mainGMapControl.PolygonsEnabled = true;
            this.mainGMapControl.RetryLoadTile = 0;
            this.mainGMapControl.RoutesEnabled = true;
            this.mainGMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mainGMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mainGMapControl.ShowTileGridLines = false;
            this.mainGMapControl.Size = new System.Drawing.Size(1013, 594);
            this.mainGMapControl.TabIndex = 0;
            this.mainGMapControl.Zoom = 3D;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.refreshMapButton, 0, 8);
            this.tableLayoutPanel6.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(1022, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 9;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(230, 594);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // refreshMapButton
            // 
            this.refreshMapButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.refreshMapButton.Location = new System.Drawing.Point(3, 568);
            this.refreshMapButton.Name = "refreshMapButton";
            this.refreshMapButton.Size = new System.Drawing.Size(224, 23);
            this.refreshMapButton.TabIndex = 0;
            this.refreshMapButton.Text = "Refresh";
            this.refreshMapButton.UseVisualStyleBackColor = true;
            this.refreshMapButton.Click += new System.EventHandler(this.refreshMapButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.recoveredMapRadioButton);
            this.panel3.Controls.Add(this.deathsMapRadioButton);
            this.panel3.Controls.Add(this.confirmedMapRadioButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 66);
            this.panel3.TabIndex = 1;
            // 
            // recoveredMapRadioButton
            // 
            this.recoveredMapRadioButton.AutoSize = true;
            this.recoveredMapRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.recoveredMapRadioButton.Location = new System.Drawing.Point(0, 34);
            this.recoveredMapRadioButton.Name = "recoveredMapRadioButton";
            this.recoveredMapRadioButton.Size = new System.Drawing.Size(230, 17);
            this.recoveredMapRadioButton.TabIndex = 2;
            this.recoveredMapRadioButton.Text = "Recovered";
            this.recoveredMapRadioButton.UseVisualStyleBackColor = true;
            // 
            // deathsMapRadioButton
            // 
            this.deathsMapRadioButton.AutoSize = true;
            this.deathsMapRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deathsMapRadioButton.Location = new System.Drawing.Point(0, 17);
            this.deathsMapRadioButton.Name = "deathsMapRadioButton";
            this.deathsMapRadioButton.Size = new System.Drawing.Size(230, 17);
            this.deathsMapRadioButton.TabIndex = 1;
            this.deathsMapRadioButton.Text = "Deaths";
            this.deathsMapRadioButton.UseVisualStyleBackColor = true;
            // 
            // confirmedMapRadioButton
            // 
            this.confirmedMapRadioButton.AutoSize = true;
            this.confirmedMapRadioButton.Checked = true;
            this.confirmedMapRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.confirmedMapRadioButton.Location = new System.Drawing.Point(0, 0);
            this.confirmedMapRadioButton.Name = "confirmedMapRadioButton";
            this.confirmedMapRadioButton.Size = new System.Drawing.Size(230, 17);
            this.confirmedMapRadioButton.TabIndex = 0;
            this.confirmedMapRadioButton.TabStop = true;
            this.confirmedMapRadioButton.Text = "Confirmed";
            this.confirmedMapRadioButton.UseVisualStyleBackColor = true;
            // 
            // mainBarPlotView
            // 
            this.mainBarPlotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainBarPlotView.Location = new System.Drawing.Point(982, 3);
            this.mainBarPlotView.Name = "mainBarPlotView";
            this.mainBarPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.mainBarPlotView.Size = new System.Drawing.Size(264, 547);
            this.mainBarPlotView.TabIndex = 2;
            this.mainBarPlotView.Text = "plotView1";
            this.mainBarPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.mainBarPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.mainBarPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 626);
            this.Controls.Add(this.mainTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainScreen";
            this.mainTabControl.ResumeLayout(false);
            this.configTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.mainDataPanel.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.plotsTabPage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mapTabPage.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage configTabPage;
        private System.Windows.Forms.TabPage plotsTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button getDataFromWebButton;
        private System.Windows.Forms.Panel mainDataPanel;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button refreshPlotButton;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.ComboBox plotTypeComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox logScaleCheckBox;
        private System.Windows.Forms.TabPage mapTabPage;
        private GMap.NET.WindowsForms.GMapControl mainGMapControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button refreshMapButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton deathsMapRadioButton;
        private System.Windows.Forms.RadioButton confirmedMapRadioButton;
        private System.Windows.Forms.RadioButton recoveredMapRadioButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private OxyPlot.WindowsForms.PlotView mainGraphicPlotView;
        private OxyPlot.WindowsForms.PlotView mainBarPlotView;
    }
}

