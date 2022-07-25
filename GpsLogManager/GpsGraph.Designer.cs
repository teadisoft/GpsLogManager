namespace GpsLogManager
{
    partial class GpsGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.chtEle = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtSpeed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtCad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboGraphY = new System.Windows.Forms.ComboBox();
            this.cboMapProvider = new System.Windows.Forms.ComboBox();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.lblAvgSpeed = new System.Windows.Forms.Label();
            this.lblKcal = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLowEle = new System.Windows.Forms.Label();
            this.lblHighEle = new System.Windows.Forms.Label();
            this.lblHighCad = new System.Windows.Forms.Label();
            this.lblAvgCad = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.chtHeart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblAvgHR = new System.Windows.Forms.Label();
            this.lblHighHR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.chtTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGpxSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chtEle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtCad)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtHeart)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(0, 0);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(712, 296);
            this.gMap.TabIndex = 5;
            this.gMap.Zoom = 0D;
            // 
            // chtEle
            // 
            chartArea6.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea6.AxisX.MaximumAutoSize = 50F;
            chartArea6.Name = "ChartArea1";
            this.chtEle.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chtEle.Legends.Add(legend6);
            this.chtEle.Location = new System.Drawing.Point(9, 353);
            this.chtEle.Name = "chtEle";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "고도";
            series6.YValuesPerPoint = 2;
            this.chtEle.Series.Add(series6);
            this.chtEle.Size = new System.Drawing.Size(863, 144);
            this.chtEle.TabIndex = 6;
            this.chtEle.Text = "chart1";
            // 
            // chtSpeed
            // 
            chartArea7.Name = "ChartArea1";
            this.chtSpeed.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chtSpeed.Legends.Add(legend7);
            this.chtSpeed.Location = new System.Drawing.Point(11, 503);
            this.chtSpeed.Name = "chtSpeed";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.Name = "속도";
            series7.YValuesPerPoint = 2;
            this.chtSpeed.Series.Add(series7);
            this.chtSpeed.Size = new System.Drawing.Size(863, 144);
            this.chtSpeed.TabIndex = 7;
            this.chtSpeed.Text = "chart1";
            // 
            // chtCad
            // 
            chartArea8.Name = "ChartArea1";
            this.chtCad.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chtCad.Legends.Add(legend8);
            this.chtCad.Location = new System.Drawing.Point(11, 654);
            this.chtCad.Name = "chtCad";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "CAD";
            series8.YValuesPerPoint = 2;
            this.chtCad.Series.Add(series8);
            this.chtCad.Size = new System.Drawing.Size(863, 144);
            this.chtCad.TabIndex = 8;
            this.chtCad.Text = "chart1";
            // 
            // cboGraphY
            // 
            this.cboGraphY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGraphY.FormattingEnabled = true;
            this.cboGraphY.Location = new System.Drawing.Point(707, 10);
            this.cboGraphY.Name = "cboGraphY";
            this.cboGraphY.Size = new System.Drawing.Size(77, 20);
            this.cboGraphY.TabIndex = 36;
            this.cboGraphY.SelectedIndexChanged += new System.EventHandler(this.cboGraphY_SelectedIndexChanged);
            // 
            // cboMapProvider
            // 
            this.cboMapProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMapProvider.FormattingEnabled = true;
            this.cboMapProvider.Location = new System.Drawing.Point(563, 10);
            this.cboMapProvider.Name = "cboMapProvider";
            this.cboMapProvider.Size = new System.Drawing.Size(138, 20);
            this.cboMapProvider.TabIndex = 37;
            this.cboMapProvider.SelectedIndexChanged += new System.EventHandler(this.cboMapProvider_SelectedIndexChanged);
            // 
            // lblDistance
            // 
            this.lblDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(6, 23);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(53, 12);
            this.lblDistance.TabIndex = 38;
            this.lblDistance.Text = "주행거리";
            this.lblDistance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbltime
            // 
            this.lbltime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltime.AutoSize = true;
            this.lbltime.Location = new System.Drawing.Point(6, 44);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(53, 12);
            this.lbltime.TabIndex = 39;
            this.lbltime.Text = "주행시간";
            this.lbltime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAvgSpeed
            // 
            this.lblAvgSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvgSpeed.AutoSize = true;
            this.lblAvgSpeed.Location = new System.Drawing.Point(6, 64);
            this.lblAvgSpeed.Name = "lblAvgSpeed";
            this.lblAvgSpeed.Size = new System.Drawing.Size(53, 12);
            this.lblAvgSpeed.TabIndex = 40;
            this.lblAvgSpeed.Text = "평균속도";
            this.lblAvgSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblKcal
            // 
            this.lblKcal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKcal.AutoSize = true;
            this.lblKcal.Location = new System.Drawing.Point(6, 108);
            this.lblKcal.Name = "lblKcal";
            this.lblKcal.Size = new System.Drawing.Size(41, 12);
            this.lblKcal.TabIndex = 43;
            this.lblKcal.Text = "칼로리";
            this.lblKcal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lbltime);
            this.groupBox4.Controls.Add(this.lblAvgSpeed);
            this.groupBox4.Controls.Add(this.lblDistance);
            this.groupBox4.Location = new System.Drawing.Point(737, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(129, 89);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "거리 / 타이밍";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblLowEle);
            this.groupBox1.Controls.Add(this.lblHighEle);
            this.groupBox1.Location = new System.Drawing.Point(737, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 64);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "고도";
            // 
            // lblLowEle
            // 
            this.lblLowEle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLowEle.AutoSize = true;
            this.lblLowEle.Location = new System.Drawing.Point(6, 19);
            this.lblLowEle.Name = "lblLowEle";
            this.lblLowEle.Size = new System.Drawing.Size(53, 12);
            this.lblLowEle.TabIndex = 43;
            this.lblLowEle.Text = "최고해발";
            this.lblLowEle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHighEle
            // 
            this.lblHighEle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHighEle.AutoSize = true;
            this.lblHighEle.Location = new System.Drawing.Point(6, 41);
            this.lblHighEle.Name = "lblHighEle";
            this.lblHighEle.Size = new System.Drawing.Size(65, 12);
            this.lblHighEle.TabIndex = 42;
            this.lblHighEle.Text = "누적오르막";
            this.lblHighEle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHighCad
            // 
            this.lblHighCad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHighCad.AutoSize = true;
            this.lblHighCad.Location = new System.Drawing.Point(6, 22);
            this.lblHighCad.Name = "lblHighCad";
            this.lblHighCad.Size = new System.Drawing.Size(58, 12);
            this.lblHighCad.TabIndex = 42;
            this.lblHighCad.Text = "최고 CAD";
            this.lblHighCad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAvgCad
            // 
            this.lblAvgCad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvgCad.AutoSize = true;
            this.lblAvgCad.Location = new System.Drawing.Point(6, 43);
            this.lblAvgCad.Name = "lblAvgCad";
            this.lblAvgCad.Size = new System.Drawing.Size(58, 12);
            this.lblAvgCad.TabIndex = 41;
            this.lblAvgCad.Text = "평균 CAD";
            this.lblAvgCad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(9, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 12);
            this.lblTitle.TabIndex = 47;
            this.lblTitle.Text = "이동거리";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(507, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 23);
            this.btnNext.TabIndex = 48;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Location = new System.Drawing.Point(451, 8);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(50, 23);
            this.btnPrevious.TabIndex = 49;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // pnlMap
            // 
            this.pnlMap.Controls.Add(this.gMap);
            this.pnlMap.Location = new System.Drawing.Point(12, 46);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(712, 296);
            this.pnlMap.TabIndex = 51;
            // 
            // chtHeart
            // 
            chartArea9.Name = "ChartArea1";
            this.chtHeart.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chtHeart.Legends.Add(legend9);
            this.chtHeart.Location = new System.Drawing.Point(12, 804);
            this.chtHeart.Name = "chtHeart";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Legend = "Legend1";
            series9.Name = "심박";
            series9.YValuesPerPoint = 2;
            this.chtHeart.Series.Add(series9);
            this.chtHeart.Size = new System.Drawing.Size(863, 144);
            this.chtHeart.TabIndex = 52;
            this.chtHeart.Text = "chart1";
            this.chtHeart.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblKcal);
            this.groupBox3.Controls.Add(this.lblAvgHR);
            this.groupBox3.Controls.Add(this.lblHighHR);
            this.groupBox3.Controls.Add(this.lblAvgCad);
            this.groupBox3.Controls.Add(this.lblHighCad);
            this.groupBox3.Location = new System.Drawing.Point(737, 213);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(129, 129);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CAD / 심박 / kcal";
            // 
            // lblAvgHR
            // 
            this.lblAvgHR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvgHR.AutoSize = true;
            this.lblAvgHR.Location = new System.Drawing.Point(6, 86);
            this.lblAvgHR.Name = "lblAvgHR";
            this.lblAvgHR.Size = new System.Drawing.Size(65, 12);
            this.lblAvgHR.TabIndex = 43;
            this.lblAvgHR.Text = "평균심박수";
            this.lblAvgHR.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHighHR
            // 
            this.lblHighHR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHighHR.AutoSize = true;
            this.lblHighHR.Location = new System.Drawing.Point(6, 64);
            this.lblHighHR.Name = "lblHighHR";
            this.lblHighHR.Size = new System.Drawing.Size(65, 12);
            this.lblHighHR.TabIndex = 44;
            this.lblHighHR.Text = "최고심박수";
            this.lblHighHR.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(792, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "심박/온도";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(857, 13);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(15, 14);
            this.chkVisible.TabIndex = 55;
            this.chkVisible.UseVisualStyleBackColor = true;
            this.chkVisible.CheckedChanged += new System.EventHandler(this.chkVisible_CheckedChanged);
            // 
            // chtTemp
            // 
            chartArea10.Name = "ChartArea1";
            this.chtTemp.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chtTemp.Legends.Add(legend10);
            this.chtTemp.Location = new System.Drawing.Point(12, 804);
            this.chtTemp.Name = "chtTemp";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Legend = "Legend1";
            series10.Name = "온도";
            series10.YValuesPerPoint = 2;
            this.chtTemp.Series.Add(series10);
            this.chtTemp.Size = new System.Drawing.Size(863, 144);
            this.chtTemp.TabIndex = 56;
            this.chtTemp.Text = "온도";
            // 
            // btnGpxSave
            // 
            this.btnGpxSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGpxSave.Location = new System.Drawing.Point(362, 10);
            this.btnGpxSave.Name = "btnGpxSave";
            this.btnGpxSave.Size = new System.Drawing.Size(83, 23);
            this.btnGpxSave.TabIndex = 57;
            this.btnGpxSave.Text = "Gpx 저장";
            this.btnGpxSave.UseVisualStyleBackColor = true;
            this.btnGpxSave.Click += new System.EventHandler(this.btnGpxSave_Click);
            // 
            // GpsGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 959);
            this.Controls.Add(this.btnGpxSave);
            this.Controls.Add(this.chtTemp);
            this.Controls.Add(this.chkVisible);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chtHeart);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cboMapProvider);
            this.Controls.Add(this.cboGraphY);
            this.Controls.Add(this.chtCad);
            this.Controls.Add(this.chtSpeed);
            this.Controls.Add(this.chtEle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GpsGraph";
            this.Text = "Gpslog Manager";
            ((System.ComponentModel.ISupportInitialize)(this.chtEle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtCad)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtHeart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtEle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtSpeed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtCad;
        private System.Windows.Forms.ComboBox cboGraphY;
        private System.Windows.Forms.ComboBox cboMapProvider;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label lblAvgSpeed;
        private System.Windows.Forms.Label lblKcal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHighEle;
        private System.Windows.Forms.Label lblHighCad;
        private System.Windows.Forms.Label lblAvgCad;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtHeart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblAvgHR;
        private System.Windows.Forms.Label lblHighHR;
        private System.Windows.Forms.Label lblLowEle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtTemp;
        private System.Windows.Forms.Button btnGpxSave;
    }
}