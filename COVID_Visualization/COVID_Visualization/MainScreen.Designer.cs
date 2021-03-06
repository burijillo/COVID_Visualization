﻿namespace COVID_Visualization
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
            this.mainBarPlotView = new OxyPlot.WindowsForms.PlotView();
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
            this.spainDataTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.spainGetDataButton = new System.Windows.Forms.Button();
            this.spainPlotView = new OxyPlot.WindowsForms.PlotView();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.spainPlotTypeComboBox = new System.Windows.Forms.ComboBox();
            this.spainPlotRefreshButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.spainRegionComboBox = new System.Windows.Forms.ComboBox();
            this.spainLogScaleCheckBox = new System.Windows.Forms.CheckBox();
            this.modelsTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.modelPlotView = new OxyPlot.WindowsForms.PlotView();
            this.TableLayoutPanel35 = new System.Windows.Forms.TableLayoutPanel();
            this.modelsComboBox = new System.Windows.Forms.ComboBox();
            this.modelsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.refreshModelButton = new System.Windows.Forms.Button();
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
            this.spainDataTabPage.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.modelsTabPage.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.TableLayoutPanel35.SuspendLayout();
            this.modelsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.configTabPage);
            this.mainTabControl.Controls.Add(this.plotsTabPage);
            this.mainTabControl.Controls.Add(this.mapTabPage);
            this.mainTabControl.Controls.Add(this.spainDataTabPage);
            this.mainTabControl.Controls.Add(this.modelsTabPage);
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
            this.configTabPage.Text = "Global data";
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.050505F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.94949F));
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1249, 30);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // getDataFromWebButton
            // 
            this.getDataFromWebButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getDataFromWebButton.Location = new System.Drawing.Point(3, 3);
            this.getDataFromWebButton.Name = "getDataFromWebButton";
            this.getDataFromWebButton.Size = new System.Drawing.Size(133, 24);
            this.getDataFromWebButton.TabIndex = 0;
            this.getDataFromWebButton.Text = "Get data";
            this.getDataFromWebButton.UseVisualStyleBackColor = true;
            this.getDataFromWebButton.Click += new System.EventHandler(this.getDataFromWebButton_Click);
            // 
            // mainDataPanel
            // 
            this.mainDataPanel.Controls.Add(this.tableLayoutPanel7);
            this.mainDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDataPanel.Location = new System.Drawing.Point(0, 30);
            this.mainDataPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainDataPanel.Name = "mainDataPanel";
            this.mainDataPanel.Size = new System.Drawing.Size(1249, 564);
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
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1249, 564);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDataGridView.Location = new System.Drawing.Point(3, 3);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(328, 558);
            this.mainDataGridView.TabIndex = 0;
            // 
            // mainGraphicPlotView
            // 
            this.mainGraphicPlotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGraphicPlotView.Location = new System.Drawing.Point(337, 3);
            this.mainGraphicPlotView.Name = "mainGraphicPlotView";
            this.mainGraphicPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.mainGraphicPlotView.Size = new System.Drawing.Size(639, 558);
            this.mainGraphicPlotView.TabIndex = 1;
            this.mainGraphicPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.mainGraphicPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.mainGraphicPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // mainBarPlotView
            // 
            this.mainBarPlotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainBarPlotView.Location = new System.Drawing.Point(982, 3);
            this.mainBarPlotView.Name = "mainBarPlotView";
            this.mainBarPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.mainBarPlotView.Size = new System.Drawing.Size(264, 558);
            this.mainBarPlotView.TabIndex = 2;
            this.mainBarPlotView.Text = "plotView1";
            this.mainBarPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.mainBarPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.mainBarPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
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
            // spainDataTabPage
            // 
            this.spainDataTabPage.Controls.Add(this.tableLayoutPanel8);
            this.spainDataTabPage.Location = new System.Drawing.Point(4, 22);
            this.spainDataTabPage.Name = "spainDataTabPage";
            this.spainDataTabPage.Size = new System.Drawing.Size(1255, 600);
            this.spainDataTabPage.TabIndex = 3;
            this.spainDataTabPage.Text = "Spain data";
            this.spainDataTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.65737F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.34263F));
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.spainPlotView, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel10, 1, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1255, 600);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.19593F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.486F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.44529F));
            this.tableLayoutPanel9.Controls.Add(this.spainGetDataButton, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1075, 30);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // spainGetDataButton
            // 
            this.spainGetDataButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spainGetDataButton.Location = new System.Drawing.Point(3, 3);
            this.spainGetDataButton.Name = "spainGetDataButton";
            this.spainGetDataButton.Size = new System.Drawing.Size(114, 24);
            this.spainGetDataButton.TabIndex = 0;
            this.spainGetDataButton.Text = "Get data";
            this.spainGetDataButton.UseVisualStyleBackColor = true;
            this.spainGetDataButton.Click += new System.EventHandler(this.spainGetDataButton_Click);
            // 
            // spainPlotView
            // 
            this.spainPlotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spainPlotView.Location = new System.Drawing.Point(3, 33);
            this.spainPlotView.Name = "spainPlotView";
            this.spainPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.spainPlotView.Size = new System.Drawing.Size(1069, 564);
            this.spainPlotView.TabIndex = 2;
            this.spainPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.spainPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.spainPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.spainPlotRefreshButton, 0, 9);
            this.tableLayoutPanel10.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.spainLogScaleCheckBox, 0, 2);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(1075, 30);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 10;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(180, 570);
            this.tableLayoutPanel10.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.spainPlotTypeComboBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 40);
            this.panel4.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Plot";
            // 
            // spainPlotTypeComboBox
            // 
            this.spainPlotTypeComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spainPlotTypeComboBox.FormattingEnabled = true;
            this.spainPlotTypeComboBox.Location = new System.Drawing.Point(0, 19);
            this.spainPlotTypeComboBox.Name = "spainPlotTypeComboBox";
            this.spainPlotTypeComboBox.Size = new System.Drawing.Size(180, 21);
            this.spainPlotTypeComboBox.TabIndex = 2;
            // 
            // spainPlotRefreshButton
            // 
            this.spainPlotRefreshButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spainPlotRefreshButton.Location = new System.Drawing.Point(3, 504);
            this.spainPlotRefreshButton.Name = "spainPlotRefreshButton";
            this.spainPlotRefreshButton.Size = new System.Drawing.Size(174, 63);
            this.spainPlotRefreshButton.TabIndex = 0;
            this.spainPlotRefreshButton.Text = "Refresh";
            this.spainPlotRefreshButton.UseVisualStyleBackColor = true;
            this.spainPlotRefreshButton.Click += new System.EventHandler(this.spainPlotRefreshButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.spainRegionComboBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(180, 40);
            this.panel5.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Region";
            // 
            // spainRegionComboBox
            // 
            this.spainRegionComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spainRegionComboBox.FormattingEnabled = true;
            this.spainRegionComboBox.Location = new System.Drawing.Point(0, 19);
            this.spainRegionComboBox.Name = "spainRegionComboBox";
            this.spainRegionComboBox.Size = new System.Drawing.Size(180, 21);
            this.spainRegionComboBox.TabIndex = 1;
            // 
            // spainLogScaleCheckBox
            // 
            this.spainLogScaleCheckBox.AutoSize = true;
            this.spainLogScaleCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.spainLogScaleCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spainLogScaleCheckBox.Location = new System.Drawing.Point(3, 83);
            this.spainLogScaleCheckBox.Name = "spainLogScaleCheckBox";
            this.spainLogScaleCheckBox.Size = new System.Drawing.Size(174, 19);
            this.spainLogScaleCheckBox.TabIndex = 5;
            this.spainLogScaleCheckBox.Text = "Logarthmic scale";
            this.spainLogScaleCheckBox.UseVisualStyleBackColor = true;
            this.spainLogScaleCheckBox.CheckedChanged += new System.EventHandler(this.spainLogScaleCheckBox_CheckedChanged);
            // 
            // modelsTabPage
            // 
            this.modelsTabPage.Controls.Add(this.tableLayoutPanel11);
            this.modelsTabPage.Location = new System.Drawing.Point(4, 22);
            this.modelsTabPage.Name = "modelsTabPage";
            this.modelsTabPage.Size = new System.Drawing.Size(1255, 600);
            this.modelsTabPage.TabIndex = 4;
            this.modelsTabPage.Text = "Models";
            this.modelsTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.93227F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.06773F));
            this.tableLayoutPanel11.Controls.Add(this.modelPlotView, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.TableLayoutPanel35, 1, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(1255, 600);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // modelPlotView
            // 
            this.modelPlotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelPlotView.Location = new System.Drawing.Point(3, 3);
            this.modelPlotView.Name = "modelPlotView";
            this.modelPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.modelPlotView.Size = new System.Drawing.Size(1084, 594);
            this.modelPlotView.TabIndex = 1;
            this.modelPlotView.Text = "plotView1";
            this.modelPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.modelPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.modelPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TableLayoutPanel35
            // 
            this.TableLayoutPanel35.ColumnCount = 1;
            this.TableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel35.Controls.Add(this.modelsTableLayoutPanel, 0, 0);
            this.TableLayoutPanel35.Controls.Add(this.refreshModelButton, 0, 1);
            this.TableLayoutPanel35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel35.Location = new System.Drawing.Point(1093, 3);
            this.TableLayoutPanel35.Name = "TableLayoutPanel35";
            this.TableLayoutPanel35.RowCount = 2;
            this.TableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel35.Size = new System.Drawing.Size(159, 594);
            this.TableLayoutPanel35.TabIndex = 2;
            // 
            // modelsComboBox
            // 
            this.modelsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelsComboBox.FormattingEnabled = true;
            this.modelsComboBox.Location = new System.Drawing.Point(3, 3);
            this.modelsComboBox.Name = "modelsComboBox";
            this.modelsComboBox.Size = new System.Drawing.Size(153, 21);
            this.modelsComboBox.TabIndex = 0;
            this.modelsComboBox.SelectedIndexChanged += new System.EventHandler(this.modelsComboBox_SelectedIndexChanged);
            // 
            // modelsTableLayoutPanel
            // 
            this.modelsTableLayoutPanel.ColumnCount = 1;
            this.modelsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.modelsTableLayoutPanel.Controls.Add(this.modelsComboBox, 0, 0);
            this.modelsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.modelsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.modelsTableLayoutPanel.Name = "modelsTableLayoutPanel";
            this.modelsTableLayoutPanel.RowCount = 1;
            this.modelsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.modelsTableLayoutPanel.Size = new System.Drawing.Size(159, 564);
            this.modelsTableLayoutPanel.TabIndex = 2;
            // 
            // refreshModelButton
            // 
            this.refreshModelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshModelButton.Location = new System.Drawing.Point(3, 567);
            this.refreshModelButton.Name = "refreshModelButton";
            this.refreshModelButton.Size = new System.Drawing.Size(153, 24);
            this.refreshModelButton.TabIndex = 3;
            this.refreshModelButton.Text = "Refresh";
            this.refreshModelButton.UseVisualStyleBackColor = true;
            this.refreshModelButton.Click += new System.EventHandler(this.refreshModelButton_Click);
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
            this.spainDataTabPage.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.modelsTabPage.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.TableLayoutPanel35.ResumeLayout(false);
            this.modelsTableLayoutPanel.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage spainDataTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button spainGetDataButton;
        private OxyPlot.WindowsForms.PlotView spainPlotView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox spainPlotTypeComboBox;
        private System.Windows.Forms.Button spainPlotRefreshButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox spainRegionComboBox;
        private System.Windows.Forms.CheckBox spainLogScaleCheckBox;
        private System.Windows.Forms.CheckBox logScaleCheckBox;
        private System.Windows.Forms.TabPage modelsTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private OxyPlot.WindowsForms.PlotView modelPlotView;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel35;
        private System.Windows.Forms.ComboBox modelsComboBox;
        private System.Windows.Forms.TableLayoutPanel modelsTableLayoutPanel;
        private System.Windows.Forms.Button refreshModelButton;
    }
}

