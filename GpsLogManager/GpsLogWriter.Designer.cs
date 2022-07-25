namespace GpsLogManager
{
    partial class GpsLogWriter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GpsLogWriter));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splAll = new System.Windows.Forms.SplitContainer();
            this.splTop = new System.Windows.Forms.SplitContainer();
            this.gvGpsActivity = new System.Windows.Forms.DataGridView();
            this.tblDetail = new System.Windows.Forms.TabControl();
            this.tp01 = new System.Windows.Forms.TabPage();
            this.picTemp = new System.Windows.Forms.PictureBox();
            this.picAscent = new System.Windows.Forms.PictureBox();
            this.picKcal = new System.Windows.Forms.PictureBox();
            this.picSpeed = new System.Windows.Forms.PictureBox();
            this.picTime = new System.Windows.Forms.PictureBox();
            this.picDistance = new System.Windows.Forms.PictureBox();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblAscent = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblKcal = new System.Windows.Forms.Label();
            this.lblAvgSpeed = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.tb02 = new System.Windows.Forms.TabPage();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.lbl03 = new System.Windows.Forms.Label();
            this.lbl02 = new System.Windows.Forms.Label();
            this.lbl01 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtAvgHeart = new System.Windows.Forms.TextBox();
            this.txtHighHeart = new System.Windows.Forms.TextBox();
            this.txtAvgTemp = new System.Windows.Forms.TextBox();
            this.txtHighTemp = new System.Windows.Forms.TextBox();
            this.txtAvgCad = new System.Windows.Forms.TextBox();
            this.txtHighCad = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.txtAvgEle = new System.Windows.Forms.TextBox();
            this.txtLowEle = new System.Windows.Forms.TextBox();
            this.txtHighEle = new System.Windows.Forms.TextBox();
            this.txtDescent = new System.Windows.Forms.TextBox();
            this.txtAscent = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKcal = new System.Windows.Forms.TextBox();
            this.txtElapseTime = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtHighSpeed = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.splBottom = new System.Windows.Forms.SplitContainer();
            this.lblZoom = new System.Windows.Forms.Label();
            this.lblEle = new System.Windows.Forms.Label();
            this.lblLatLng = new System.Windows.Forms.Label();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.gvGpsLog = new System.Windows.Forms.DataGridView();
            this.chtGpslog = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMakerBtnVisible = new System.Windows.Forms.Button();
            this.btnReplay = new System.Windows.Forms.Button();
            this.chkHeart = new System.Windows.Forms.CheckBox();
            this.chkTemp = new System.Windows.Forms.CheckBox();
            this.chkCad = new System.Windows.Forms.CheckBox();
            this.chkSpeed = new System.Windows.Forms.CheckBox();
            this.chkEle = new System.Windows.Forms.CheckBox();
            this.cboGraphY = new System.Windows.Forms.ComboBox();
            this.cboGraphX = new System.Windows.Forms.ComboBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.cboMapProvider = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSum = new System.Windows.Forms.Button();
            this.cboLogCount = new System.Windows.Forms.ComboBox();
            this.lebel1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboDate = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.cboUtcLocal = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGpsImport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnMultiGpsLog = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.cboManager = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReplayEnd = new System.Windows.Forms.Button();
            this.btnMapFull = new System.Windows.Forms.Button();
            this.btnMarker = new System.Windows.Forms.Button();
            this.btnMapCancel = new System.Windows.Forms.Button();
            this.txtGoto = new System.Windows.Forms.TextBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnPngSave = new System.Windows.Forms.Button();
            this.chkToolTip = new System.Windows.Forms.CheckBox();
            this.cboMaker = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnChart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splAll)).BeginInit();
            this.splAll.Panel1.SuspendLayout();
            this.splAll.Panel2.SuspendLayout();
            this.splAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splTop)).BeginInit();
            this.splTop.Panel1.SuspendLayout();
            this.splTop.Panel2.SuspendLayout();
            this.splTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGpsActivity)).BeginInit();
            this.tblDetail.SuspendLayout();
            this.tp01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAscent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKcal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDistance)).BeginInit();
            this.tb02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splBottom)).BeginInit();
            this.splBottom.Panel1.SuspendLayout();
            this.splBottom.Panel2.SuspendLayout();
            this.splBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGpsLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtGpslog)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splAll
            // 
            this.splAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splAll.Location = new System.Drawing.Point(12, 12);
            this.splAll.Name = "splAll";
            this.splAll.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splAll.Panel1
            // 
            this.splAll.Panel1.Controls.Add(this.splTop);
            // 
            // splAll.Panel2
            // 
            this.splAll.Panel2.Controls.Add(this.splBottom);
            this.splAll.Size = new System.Drawing.Size(1080, 825);
            this.splAll.SplitterDistance = 234;
            this.splAll.TabIndex = 9;
            // 
            // splTop
            // 
            this.splTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splTop.Location = new System.Drawing.Point(0, 0);
            this.splTop.Name = "splTop";
            // 
            // splTop.Panel1
            // 
            this.splTop.Panel1.Controls.Add(this.gvGpsActivity);
            // 
            // splTop.Panel2
            // 
            this.splTop.Panel2.Controls.Add(this.tblDetail);
            this.splTop.Size = new System.Drawing.Size(1080, 234);
            this.splTop.SplitterDistance = 559;
            this.splTop.TabIndex = 11;
            // 
            // gvGpsActivity
            // 
            this.gvGpsActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGpsActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvGpsActivity.Location = new System.Drawing.Point(0, 0);
            this.gvGpsActivity.Name = "gvGpsActivity";
            this.gvGpsActivity.RowTemplate.Height = 23;
            this.gvGpsActivity.Size = new System.Drawing.Size(559, 234);
            this.gvGpsActivity.TabIndex = 45;
            this.gvGpsActivity.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGpsActivity_CellClick);
            this.gvGpsActivity.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGpsActivity_CellDoubleClick);
            // 
            // tblDetail
            // 
            this.tblDetail.Controls.Add(this.tp01);
            this.tblDetail.Controls.Add(this.tb02);
            this.tblDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDetail.Location = new System.Drawing.Point(0, 0);
            this.tblDetail.Name = "tblDetail";
            this.tblDetail.SelectedIndex = 0;
            this.tblDetail.Size = new System.Drawing.Size(517, 234);
            this.tblDetail.TabIndex = 0;
            // 
            // tp01
            // 
            this.tp01.Controls.Add(this.picTemp);
            this.tp01.Controls.Add(this.picAscent);
            this.tp01.Controls.Add(this.picKcal);
            this.tp01.Controls.Add(this.picSpeed);
            this.tp01.Controls.Add(this.picTime);
            this.tp01.Controls.Add(this.picDistance);
            this.tp01.Controls.Add(this.lblTemp);
            this.tp01.Controls.Add(this.lblAscent);
            this.tp01.Controls.Add(this.lblTime);
            this.tp01.Controls.Add(this.lblKcal);
            this.tp01.Controls.Add(this.lblAvgSpeed);
            this.tp01.Controls.Add(this.lblDistance);
            this.tp01.Location = new System.Drawing.Point(4, 22);
            this.tp01.Name = "tp01";
            this.tp01.Padding = new System.Windows.Forms.Padding(3);
            this.tp01.Size = new System.Drawing.Size(509, 208);
            this.tp01.TabIndex = 0;
            this.tp01.Text = "기본정보";
            this.tp01.UseVisualStyleBackColor = true;
            // 
            // picTemp
            // 
            this.picTemp.Image = global::GpsLogManager.Properties.Resources.temperature_2_32__1_;
            this.picTemp.Location = new System.Drawing.Point(261, 151);
            this.picTemp.Name = "picTemp";
            this.picTemp.Size = new System.Drawing.Size(32, 32);
            this.picTemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTemp.TabIndex = 17;
            this.picTemp.TabStop = false;
            // 
            // picAscent
            // 
            this.picAscent.Image = global::GpsLogManager.Properties.Resources.mountain_2_32__1_;
            this.picAscent.Location = new System.Drawing.Point(261, 88);
            this.picAscent.Name = "picAscent";
            this.picAscent.Size = new System.Drawing.Size(32, 32);
            this.picAscent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAscent.TabIndex = 16;
            this.picAscent.TabStop = false;
            // 
            // picKcal
            // 
            this.picKcal.Image = global::GpsLogManager.Properties.Resources.weightlift_32__1_;
            this.picKcal.Location = new System.Drawing.Point(55, 151);
            this.picKcal.Name = "picKcal";
            this.picKcal.Size = new System.Drawing.Size(32, 32);
            this.picKcal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picKcal.TabIndex = 15;
            this.picKcal.TabStop = false;
            // 
            // picSpeed
            // 
            this.picSpeed.Image = ((System.Drawing.Image)(resources.GetObject("picSpeed.Image")));
            this.picSpeed.Location = new System.Drawing.Point(55, 88);
            this.picSpeed.Name = "picSpeed";
            this.picSpeed.Size = new System.Drawing.Size(32, 32);
            this.picSpeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSpeed.TabIndex = 14;
            this.picSpeed.TabStop = false;
            // 
            // picTime
            // 
            this.picTime.Image = ((System.Drawing.Image)(resources.GetObject("picTime.Image")));
            this.picTime.Location = new System.Drawing.Point(261, 28);
            this.picTime.Name = "picTime";
            this.picTime.Size = new System.Drawing.Size(32, 32);
            this.picTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTime.TabIndex = 13;
            this.picTime.TabStop = false;
            // 
            // picDistance
            // 
            this.picDistance.Image = ((System.Drawing.Image)(resources.GetObject("picDistance.Image")));
            this.picDistance.Location = new System.Drawing.Point(55, 28);
            this.picDistance.Name = "picDistance";
            this.picDistance.Size = new System.Drawing.Size(32, 32);
            this.picDistance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDistance.TabIndex = 12;
            this.picDistance.TabStop = false;
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTemp.Location = new System.Drawing.Point(299, 151);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(116, 30);
            this.lblTemp.TabIndex = 11;
            this.lblTemp.Text = "평균 온도 :";
            // 
            // lblAscent
            // 
            this.lblAscent.AutoSize = true;
            this.lblAscent.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAscent.Location = new System.Drawing.Point(299, 90);
            this.lblAscent.Name = "lblAscent";
            this.lblAscent.Size = new System.Drawing.Size(74, 30);
            this.lblAscent.TabIndex = 10;
            this.lblAscent.Text = "누적 : ";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTime.Location = new System.Drawing.Point(299, 28);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(74, 30);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "시간 : ";
            // 
            // lblKcal
            // 
            this.lblKcal.AutoSize = true;
            this.lblKcal.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKcal.Location = new System.Drawing.Point(91, 151);
            this.lblKcal.Name = "lblKcal";
            this.lblKcal.Size = new System.Drawing.Size(95, 30);
            this.lblKcal.TabIndex = 8;
            this.lblKcal.Text = "칼로리 : ";
            // 
            // lblAvgSpeed
            // 
            this.lblAvgSpeed.AutoSize = true;
            this.lblAvgSpeed.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAvgSpeed.Location = new System.Drawing.Point(91, 88);
            this.lblAvgSpeed.Name = "lblAvgSpeed";
            this.lblAvgSpeed.Size = new System.Drawing.Size(74, 30);
            this.lblAvgSpeed.TabIndex = 7;
            this.lblAvgSpeed.Text = "평속 : ";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDistance.Location = new System.Drawing.Point(91, 28);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(74, 30);
            this.lblDistance.TabIndex = 6;
            this.lblDistance.Text = "거리 : ";
            // 
            // tb02
            // 
            this.tb02.Controls.Add(this.txtDistance);
            this.tb02.Controls.Add(this.lbl03);
            this.tb02.Controls.Add(this.lbl02);
            this.tb02.Controls.Add(this.lbl01);
            this.tb02.Controls.Add(this.label20);
            this.tb02.Controls.Add(this.label21);
            this.tb02.Controls.Add(this.label22);
            this.tb02.Controls.Add(this.txtAvgHeart);
            this.tb02.Controls.Add(this.txtHighHeart);
            this.tb02.Controls.Add(this.txtAvgTemp);
            this.tb02.Controls.Add(this.txtHighTemp);
            this.tb02.Controls.Add(this.txtAvgCad);
            this.tb02.Controls.Add(this.txtHighCad);
            this.tb02.Controls.Add(this.label11);
            this.tb02.Controls.Add(this.label12);
            this.tb02.Controls.Add(this.label13);
            this.tb02.Controls.Add(this.label14);
            this.tb02.Controls.Add(this.label15);
            this.tb02.Controls.Add(this.label16);
            this.tb02.Controls.Add(this.txtGrade);
            this.tb02.Controls.Add(this.txtAvgEle);
            this.tb02.Controls.Add(this.txtLowEle);
            this.tb02.Controls.Add(this.txtHighEle);
            this.tb02.Controls.Add(this.txtDescent);
            this.tb02.Controls.Add(this.txtAscent);
            this.tb02.Controls.Add(this.label10);
            this.tb02.Controls.Add(this.label9);
            this.tb02.Controls.Add(this.label8);
            this.tb02.Controls.Add(this.label7);
            this.tb02.Controls.Add(this.label6);
            this.tb02.Controls.Add(this.label5);
            this.tb02.Controls.Add(this.txtKcal);
            this.tb02.Controls.Add(this.txtElapseTime);
            this.tb02.Controls.Add(this.txtTime);
            this.tb02.Controls.Add(this.txtHighSpeed);
            this.tb02.Controls.Add(this.txtSpeed);
            this.tb02.Location = new System.Drawing.Point(4, 22);
            this.tb02.Name = "tb02";
            this.tb02.Padding = new System.Windows.Forms.Padding(3);
            this.tb02.Size = new System.Drawing.Size(509, 208);
            this.tb02.TabIndex = 1;
            this.tb02.Text = "전체정보";
            this.tb02.UseVisualStyleBackColor = true;
            // 
            // txtDistance
            // 
            this.txtDistance.BackColor = System.Drawing.SystemColors.Window;
            this.txtDistance.Location = new System.Drawing.Point(72, 24);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(82, 21);
            this.txtDistance.TabIndex = 48;
            // 
            // lbl03
            // 
            this.lbl03.AutoSize = true;
            this.lbl03.Location = new System.Drawing.Point(343, 165);
            this.lbl03.Name = "lbl03";
            this.lbl03.Size = new System.Drawing.Size(65, 12);
            this.lbl03.TabIndex = 47;
            this.lbl03.Text = "평균심박수";
            // 
            // lbl02
            // 
            this.lbl02.AutoSize = true;
            this.lbl02.Location = new System.Drawing.Point(343, 139);
            this.lbl02.Name = "lbl02";
            this.lbl02.Size = new System.Drawing.Size(65, 12);
            this.lbl02.TabIndex = 46;
            this.lbl02.Text = "최고심박수";
            // 
            // lbl01
            // 
            this.lbl01.AutoSize = true;
            this.lbl01.Location = new System.Drawing.Point(355, 111);
            this.lbl01.Name = "lbl01";
            this.lbl01.Size = new System.Drawing.Size(53, 12);
            this.lbl01.TabIndex = 45;
            this.lbl01.Text = "평균온도";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(355, 85);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 44;
            this.label20.Text = "최고온도";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(337, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 12);
            this.label21.TabIndex = 43;
            this.label21.Text = "케이던스(A)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(337, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 12);
            this.label22.TabIndex = 42;
            this.label22.Text = "케이던스(H)";
            // 
            // txtAvgHeart
            // 
            this.txtAvgHeart.BackColor = System.Drawing.SystemColors.Window;
            this.txtAvgHeart.Location = new System.Drawing.Point(410, 161);
            this.txtAvgHeart.Name = "txtAvgHeart";
            this.txtAvgHeart.Size = new System.Drawing.Size(82, 21);
            this.txtAvgHeart.TabIndex = 41;
            // 
            // txtHighHeart
            // 
            this.txtHighHeart.BackColor = System.Drawing.SystemColors.Window;
            this.txtHighHeart.Location = new System.Drawing.Point(410, 134);
            this.txtHighHeart.Name = "txtHighHeart";
            this.txtHighHeart.Size = new System.Drawing.Size(82, 21);
            this.txtHighHeart.TabIndex = 40;
            // 
            // txtAvgTemp
            // 
            this.txtAvgTemp.BackColor = System.Drawing.SystemColors.Window;
            this.txtAvgTemp.Location = new System.Drawing.Point(410, 107);
            this.txtAvgTemp.Name = "txtAvgTemp";
            this.txtAvgTemp.Size = new System.Drawing.Size(82, 21);
            this.txtAvgTemp.TabIndex = 39;
            // 
            // txtHighTemp
            // 
            this.txtHighTemp.BackColor = System.Drawing.SystemColors.Window;
            this.txtHighTemp.Location = new System.Drawing.Point(410, 80);
            this.txtHighTemp.Name = "txtHighTemp";
            this.txtHighTemp.Size = new System.Drawing.Size(82, 21);
            this.txtHighTemp.TabIndex = 38;
            // 
            // txtAvgCad
            // 
            this.txtAvgCad.BackColor = System.Drawing.SystemColors.Window;
            this.txtAvgCad.Location = new System.Drawing.Point(410, 53);
            this.txtAvgCad.Name = "txtAvgCad";
            this.txtAvgCad.Size = new System.Drawing.Size(82, 21);
            this.txtAvgCad.TabIndex = 37;
            // 
            // txtHighCad
            // 
            this.txtHighCad.BackColor = System.Drawing.SystemColors.Window;
            this.txtHighCad.Location = new System.Drawing.Point(410, 26);
            this.txtHighCad.Name = "txtHighCad";
            this.txtHighCad.Size = new System.Drawing.Size(82, 21);
            this.txtHighCad.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 35;
            this.label11.Text = "경사도";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(181, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 34;
            this.label12.Text = "평균해발";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(181, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "최저해발";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(181, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 32;
            this.label14.Text = "최고해발";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(169, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 31;
            this.label15.Text = "누적내리막";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(169, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 30;
            this.label16.Text = "누적오르막";
            // 
            // txtGrade
            // 
            this.txtGrade.BackColor = System.Drawing.SystemColors.Window;
            this.txtGrade.Location = new System.Drawing.Point(240, 162);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(82, 21);
            this.txtGrade.TabIndex = 29;
            // 
            // txtAvgEle
            // 
            this.txtAvgEle.BackColor = System.Drawing.SystemColors.Window;
            this.txtAvgEle.Location = new System.Drawing.Point(240, 135);
            this.txtAvgEle.Name = "txtAvgEle";
            this.txtAvgEle.Size = new System.Drawing.Size(82, 21);
            this.txtAvgEle.TabIndex = 28;
            // 
            // txtLowEle
            // 
            this.txtLowEle.BackColor = System.Drawing.SystemColors.Window;
            this.txtLowEle.Location = new System.Drawing.Point(240, 108);
            this.txtLowEle.Name = "txtLowEle";
            this.txtLowEle.Size = new System.Drawing.Size(82, 21);
            this.txtLowEle.TabIndex = 27;
            // 
            // txtHighEle
            // 
            this.txtHighEle.BackColor = System.Drawing.SystemColors.Window;
            this.txtHighEle.Location = new System.Drawing.Point(240, 81);
            this.txtHighEle.Name = "txtHighEle";
            this.txtHighEle.Size = new System.Drawing.Size(82, 21);
            this.txtHighEle.TabIndex = 26;
            // 
            // txtDescent
            // 
            this.txtDescent.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescent.Location = new System.Drawing.Point(240, 54);
            this.txtDescent.Name = "txtDescent";
            this.txtDescent.Size = new System.Drawing.Size(82, 21);
            this.txtDescent.TabIndex = 25;
            // 
            // txtAscent
            // 
            this.txtAscent.BackColor = System.Drawing.SystemColors.Window;
            this.txtAscent.Location = new System.Drawing.Point(240, 27);
            this.txtAscent.Name = "txtAscent";
            this.txtAscent.Size = new System.Drawing.Size(82, 21);
            this.txtAscent.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "칼로리";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "경과시간";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "시간";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "최고속도";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "평균속도";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "거리";
            // 
            // txtKcal
            // 
            this.txtKcal.BackColor = System.Drawing.SystemColors.Window;
            this.txtKcal.Location = new System.Drawing.Point(72, 161);
            this.txtKcal.Name = "txtKcal";
            this.txtKcal.Size = new System.Drawing.Size(82, 21);
            this.txtKcal.TabIndex = 5;
            // 
            // txtElapseTime
            // 
            this.txtElapseTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtElapseTime.Location = new System.Drawing.Point(72, 134);
            this.txtElapseTime.Name = "txtElapseTime";
            this.txtElapseTime.Size = new System.Drawing.Size(82, 21);
            this.txtElapseTime.TabIndex = 4;
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtTime.Location = new System.Drawing.Point(72, 107);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(82, 21);
            this.txtTime.TabIndex = 3;
            // 
            // txtHighSpeed
            // 
            this.txtHighSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.txtHighSpeed.Location = new System.Drawing.Point(72, 80);
            this.txtHighSpeed.Name = "txtHighSpeed";
            this.txtHighSpeed.Size = new System.Drawing.Size(82, 21);
            this.txtHighSpeed.TabIndex = 2;
            // 
            // txtSpeed
            // 
            this.txtSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.txtSpeed.Location = new System.Drawing.Point(72, 53);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(82, 21);
            this.txtSpeed.TabIndex = 1;
            // 
            // splBottom
            // 
            this.splBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splBottom.Location = new System.Drawing.Point(0, 0);
            this.splBottom.Name = "splBottom";
            this.splBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splBottom.Panel1
            // 
            this.splBottom.Panel1.Controls.Add(this.lblZoom);
            this.splBottom.Panel1.Controls.Add(this.lblEle);
            this.splBottom.Panel1.Controls.Add(this.lblLatLng);
            this.splBottom.Panel1.Controls.Add(this.gMap);
            this.splBottom.Panel1.Controls.Add(this.gvGpsLog);
            // 
            // splBottom.Panel2
            // 
            this.splBottom.Panel2.Controls.Add(this.chtGpslog);
            this.splBottom.Panel2.Controls.Add(this.button1);
            this.splBottom.Size = new System.Drawing.Size(1080, 587);
            this.splBottom.SplitterDistance = 400;
            this.splBottom.TabIndex = 0;
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(975, 9);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(11, 12);
            this.lblZoom.TabIndex = 7;
            this.lblZoom.Text = "1";
            // 
            // lblEle
            // 
            this.lblEle.AutoSize = true;
            this.lblEle.Location = new System.Drawing.Point(3, 26);
            this.lblEle.Name = "lblEle";
            this.lblEle.Size = new System.Drawing.Size(33, 12);
            this.lblEle.TabIndex = 6;
            this.lblEle.Text = "고도:";
            // 
            // lblLatLng
            // 
            this.lblLatLng.AutoSize = true;
            this.lblLatLng.Location = new System.Drawing.Point(2, 5);
            this.lblLatLng.Name = "lblLatLng";
            this.lblLatLng.Size = new System.Drawing.Size(49, 12);
            this.lblLatLng.TabIndex = 5;
            this.lblLatLng.Text = "Lat/Lng";
            this.lblLatLng.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblLatLng_MouseUp);
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.ForeColor = System.Drawing.Color.Black;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(0, 0);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(1080, 400);
            this.gMap.TabIndex = 4;
            this.gMap.Zoom = 0D;
            this.gMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMap_OnMarkerClick);
            this.gMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMap_OnMapZoomChanged);
            this.gMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseClick);
            this.gMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseMove);
            // 
            // gvGpsLog
            // 
            this.gvGpsLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGpsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvGpsLog.Location = new System.Drawing.Point(0, 0);
            this.gvGpsLog.Name = "gvGpsLog";
            this.gvGpsLog.RowTemplate.Height = 23;
            this.gvGpsLog.Size = new System.Drawing.Size(1080, 400);
            this.gvGpsLog.TabIndex = 3;
            this.gvGpsLog.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvGpsLog_CellMouseUp);
            // 
            // chtGpslog
            // 
            chartArea1.Name = "ChartArea1";
            this.chtGpslog.ChartAreas.Add(chartArea1);
            this.chtGpslog.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chtGpslog.Legends.Add(legend1);
            this.chtGpslog.Location = new System.Drawing.Point(0, 0);
            this.chtGpslog.Name = "chtGpslog";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chtGpslog.Series.Add(series1);
            this.chtGpslog.Size = new System.Drawing.Size(1080, 183);
            this.chtGpslog.TabIndex = 45;
            this.chtGpslog.Text = "chart1";
            this.chtGpslog.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chtGpslog_GetToolTipText);
            this.chtGpslog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseClick);
            this.chtGpslog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chtGpslog_MouseDown);
            this.chtGpslog.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chtGpslog_MouseMove);
            this.chtGpslog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chtGpslog_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(977, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMakerBtnVisible
            // 
            this.btnMakerBtnVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakerBtnVisible.Location = new System.Drawing.Point(84, 102);
            this.btnMakerBtnVisible.Name = "btnMakerBtnVisible";
            this.btnMakerBtnVisible.Size = new System.Drawing.Size(64, 23);
            this.btnMakerBtnVisible.TabIndex = 41;
            this.btnMakerBtnVisible.Text = "마커숨김";
            this.btnMakerBtnVisible.UseVisualStyleBackColor = true;
            this.btnMakerBtnVisible.Click += new System.EventHandler(this.btnMakerBtnVisible_Click);
            // 
            // btnReplay
            // 
            this.btnReplay.Location = new System.Drawing.Point(16, 160);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(64, 23);
            this.btnReplay.TabIndex = 45;
            this.btnReplay.Text = "재생";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // chkHeart
            // 
            this.chkHeart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHeart.AutoSize = true;
            this.chkHeart.BackColor = System.Drawing.SystemColors.Control;
            this.chkHeart.Location = new System.Drawing.Point(19, 131);
            this.chkHeart.Name = "chkHeart";
            this.chkHeart.Size = new System.Drawing.Size(60, 16);
            this.chkHeart.TabIndex = 47;
            this.chkHeart.Tag = "";
            this.chkHeart.Text = "심박수";
            this.chkHeart.UseVisualStyleBackColor = false;
            this.chkHeart.CheckedChanged += new System.EventHandler(this.chkHeart_CheckedChanged);
            // 
            // chkTemp
            // 
            this.chkTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTemp.AutoSize = true;
            this.chkTemp.BackColor = System.Drawing.SystemColors.Control;
            this.chkTemp.Location = new System.Drawing.Point(19, 113);
            this.chkTemp.Name = "chkTemp";
            this.chkTemp.Size = new System.Drawing.Size(48, 16);
            this.chkTemp.TabIndex = 46;
            this.chkTemp.Tag = "";
            this.chkTemp.Text = "온도";
            this.chkTemp.UseVisualStyleBackColor = false;
            this.chkTemp.CheckedChanged += new System.EventHandler(this.chkTemp_CheckedChanged);
            // 
            // chkCad
            // 
            this.chkCad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCad.AutoSize = true;
            this.chkCad.BackColor = System.Drawing.SystemColors.Control;
            this.chkCad.Location = new System.Drawing.Point(19, 93);
            this.chkCad.Name = "chkCad";
            this.chkCad.Size = new System.Drawing.Size(72, 16);
            this.chkCad.TabIndex = 45;
            this.chkCad.Tag = "";
            this.chkCad.Text = "케이던스";
            this.chkCad.UseVisualStyleBackColor = false;
            this.chkCad.CheckedChanged += new System.EventHandler(this.chkCad_CheckedChanged);
            // 
            // chkSpeed
            // 
            this.chkSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSpeed.AutoSize = true;
            this.chkSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.chkSpeed.Location = new System.Drawing.Point(19, 73);
            this.chkSpeed.Name = "chkSpeed";
            this.chkSpeed.Size = new System.Drawing.Size(48, 16);
            this.chkSpeed.TabIndex = 44;
            this.chkSpeed.Tag = "";
            this.chkSpeed.Text = "평속";
            this.chkSpeed.UseVisualStyleBackColor = false;
            this.chkSpeed.CheckedChanged += new System.EventHandler(this.chkSpeed_CheckedChanged);
            // 
            // chkEle
            // 
            this.chkEle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEle.AutoSize = true;
            this.chkEle.BackColor = System.Drawing.SystemColors.Control;
            this.chkEle.Checked = true;
            this.chkEle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEle.Font = new System.Drawing.Font("굴림", 9F);
            this.chkEle.Location = new System.Drawing.Point(19, 53);
            this.chkEle.Name = "chkEle";
            this.chkEle.Size = new System.Drawing.Size(48, 16);
            this.chkEle.TabIndex = 43;
            this.chkEle.Tag = "";
            this.chkEle.Text = "고도";
            this.chkEle.UseVisualStyleBackColor = false;
            this.chkEle.CheckedChanged += new System.EventHandler(this.chkEle_CheckedChanged);
            // 
            // cboGraphY
            // 
            this.cboGraphY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGraphY.FormattingEnabled = true;
            this.cboGraphY.Location = new System.Drawing.Point(16, 20);
            this.cboGraphY.Name = "cboGraphY";
            this.cboGraphY.Size = new System.Drawing.Size(63, 20);
            this.cboGraphY.TabIndex = 35;
            this.cboGraphY.SelectedIndexChanged += new System.EventHandler(this.cboGraphY_SelectedIndexChanged);
            // 
            // cboGraphX
            // 
            this.cboGraphX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGraphX.FormattingEnabled = true;
            this.cboGraphX.Location = new System.Drawing.Point(1141, 345);
            this.cboGraphX.Name = "cboGraphX";
            this.cboGraphX.Size = new System.Drawing.Size(15, 20);
            this.cboGraphX.TabIndex = 34;
            this.cboGraphX.Visible = false;
            this.cboGraphX.SelectedIndexChanged += new System.EventHandler(this.cboGraphX_SelectedIndexChanged);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Location = new System.Drawing.Point(17, 154);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(65, 23);
            this.btnPrevious.TabIndex = 51;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(83, 154);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(65, 23);
            this.btnNext.TabIndex = 50;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // cboMapProvider
            // 
            this.cboMapProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMapProvider.FormattingEnabled = true;
            this.cboMapProvider.Location = new System.Drawing.Point(16, 20);
            this.cboMapProvider.Name = "cboMapProvider";
            this.cboMapProvider.Size = new System.Drawing.Size(132, 20);
            this.cboMapProvider.TabIndex = 33;
            this.cboMapProvider.SelectedIndexChanged += new System.EventHandler(this.cboMapProvider_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnPrevious);
            this.groupBox1.Controls.Add(this.btnSum);
            this.groupBox1.Controls.Add(this.cboLogCount);
            this.groupBox1.Controls.Add(this.lebel1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboSearchType);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.cboDate);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(1107, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 187);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "조회/통계";
            // 
            // btnSum
            // 
            this.btnSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSum.Location = new System.Drawing.Point(83, 125);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(65, 23);
            this.btnSum.TabIndex = 35;
            this.btnSum.Text = "통계";
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // cboLogCount
            // 
            this.cboLogCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLogCount.FormattingEnabled = true;
            this.cboLogCount.Location = new System.Drawing.Point(73, 99);
            this.cboLogCount.Name = "cboLogCount";
            this.cboLogCount.Size = new System.Drawing.Size(75, 20);
            this.cboLogCount.TabIndex = 34;
            this.cboLogCount.SelectedIndexChanged += new System.EventHandler(this.cboLogCount_SelectedIndexChanged);
            // 
            // lebel1
            // 
            this.lebel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lebel1.AutoSize = true;
            this.lebel1.Location = new System.Drawing.Point(14, 102);
            this.lebel1.Name = "lebel1";
            this.lebel1.Size = new System.Drawing.Size(53, 12);
            this.lebel1.TabIndex = 33;
            this.lebel1.Text = "조회건수";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "검색조건";
            // 
            // cboSearchType
            // 
            this.cboSearchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Location = new System.Drawing.Point(73, 73);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(75, 20);
            this.cboSearchType.TabIndex = 31;
            this.cboSearchType.SelectedIndexChanged += new System.EventHandler(this.cboSearchType_SelectedIndexChanged);
            // 
            // cboYear
            // 
            this.cboYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(34, 20);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(50, 20);
            this.cboYear.TabIndex = 24;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // cboDate
            // 
            this.cboDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDate.FormattingEnabled = true;
            this.cboDate.Location = new System.Drawing.Point(34, 47);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(114, 20);
            this.cboDate.TabIndex = 19;
            this.cboDate.SelectedIndexChanged += new System.EventHandler(this.cboDate_SelectedIndexChanged);
            // 
            // cboMonth
            // 
            this.cboMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(108, 19);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(40, 20);
            this.cboMonth.TabIndex = 27;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "일";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(16, 125);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 23);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "월";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "년";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnModify);
            this.groupBox2.Controls.Add(this.cboUtcLocal);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnGpsImport);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Location = new System.Drawing.Point(1107, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 139);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "관리";
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModify.Location = new System.Drawing.Point(83, 76);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(65, 23);
            this.btnModify.TabIndex = 33;
            this.btnModify.Text = "수정";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // cboUtcLocal
            // 
            this.cboUtcLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUtcLocal.FormattingEnabled = true;
            this.cboUtcLocal.Location = new System.Drawing.Point(17, 21);
            this.cboUtcLocal.Name = "cboUtcLocal";
            this.cboUtcLocal.Size = new System.Drawing.Size(131, 20);
            this.cboUtcLocal.TabIndex = 32;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(16, 77);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGpsImport
            // 
            this.btnGpsImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGpsImport.Location = new System.Drawing.Point(17, 48);
            this.btnGpsImport.Name = "btnGpsImport";
            this.btnGpsImport.Size = new System.Drawing.Size(65, 23);
            this.btnGpsImport.TabIndex = 0;
            this.btnGpsImport.Text = "입력";
            this.btnGpsImport.UseVisualStyleBackColor = true;
            this.btnGpsImport.Click += new System.EventHandler(this.btnGpsImport_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(83, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "등록";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(17, 108);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(132, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "지우기(화면)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnMultiGpsLog
            // 
            this.btnMultiGpsLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultiGpsLog.Location = new System.Drawing.Point(16, 102);
            this.btnMultiGpsLog.Name = "btnMultiGpsLog";
            this.btnMultiGpsLog.Size = new System.Drawing.Size(64, 23);
            this.btnMultiGpsLog.TabIndex = 10;
            this.btnMultiGpsLog.Text = "트랙보기";
            this.btnMultiGpsLog.UseVisualStyleBackColor = true;
            this.btnMultiGpsLog.Click += new System.EventHandler(this.btnMultiGpsLog_Click);
            // 
            // btnMap
            // 
            this.btnMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMap.Location = new System.Drawing.Point(15, 218);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(65, 23);
            this.btnMap.TabIndex = 9;
            this.btnMap.Text = "지도열기";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // cboManager
            // 
            this.cboManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboManager.FormattingEnabled = true;
            this.cboManager.Location = new System.Drawing.Point(97, 79);
            this.cboManager.Name = "cboManager";
            this.cboManager.Size = new System.Drawing.Size(51, 20);
            this.cboManager.TabIndex = 34;
            this.cboManager.UseWaitCursor = true;
            this.cboManager.Visible = false;
            this.cboManager.SelectedIndexChanged += new System.EventHandler(this.cboManager_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnMakerBtnVisible);
            this.groupBox3.Controls.Add(this.btnReplayEnd);
            this.groupBox3.Controls.Add(this.btnReplay);
            this.groupBox3.Controls.Add(this.btnMapFull);
            this.groupBox3.Controls.Add(this.btnMarker);
            this.groupBox3.Controls.Add(this.cboMapProvider);
            this.groupBox3.Controls.Add(this.btnMapCancel);
            this.groupBox3.Controls.Add(this.btnMap);
            this.groupBox3.Controls.Add(this.txtGoto);
            this.groupBox3.Controls.Add(this.btnEnd);
            this.groupBox3.Controls.Add(this.btnGoto);
            this.groupBox3.Controls.Add(this.btnPngSave);
            this.groupBox3.Controls.Add(this.btnMultiGpsLog);
            this.groupBox3.Location = new System.Drawing.Point(1107, 360);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(165, 254);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "지도";
            // 
            // btnReplayEnd
            // 
            this.btnReplayEnd.Location = new System.Drawing.Point(84, 160);
            this.btnReplayEnd.Name = "btnReplayEnd";
            this.btnReplayEnd.Size = new System.Drawing.Size(64, 23);
            this.btnReplayEnd.TabIndex = 46;
            this.btnReplayEnd.Text = "종료";
            this.btnReplayEnd.UseVisualStyleBackColor = true;
            this.btnReplayEnd.Click += new System.EventHandler(this.btnReplayEnd_Click);
            // 
            // btnMapFull
            // 
            this.btnMapFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapFull.Location = new System.Drawing.Point(83, 218);
            this.btnMapFull.Name = "btnMapFull";
            this.btnMapFull.Size = new System.Drawing.Size(65, 23);
            this.btnMapFull.TabIndex = 41;
            this.btnMapFull.Text = "전체화면";
            this.btnMapFull.UseVisualStyleBackColor = true;
            this.btnMapFull.Click += new System.EventHandler(this.btnMapFull_Click);
            // 
            // btnMarker
            // 
            this.btnMarker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarker.Location = new System.Drawing.Point(16, 131);
            this.btnMarker.Name = "btnMarker";
            this.btnMarker.Size = new System.Drawing.Size(133, 23);
            this.btnMarker.TabIndex = 40;
            this.btnMarker.Text = "트랙시작";
            this.btnMarker.UseVisualStyleBackColor = true;
            this.btnMarker.Click += new System.EventHandler(this.btnMarker_Click);
            // 
            // btnMapCancel
            // 
            this.btnMapCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapCancel.Location = new System.Drawing.Point(15, 189);
            this.btnMapCancel.Name = "btnMapCancel";
            this.btnMapCancel.Size = new System.Drawing.Size(134, 23);
            this.btnMapCancel.TabIndex = 4;
            this.btnMapCancel.Text = "지우기(지도)";
            this.btnMapCancel.UseVisualStyleBackColor = true;
            this.btnMapCancel.Click += new System.EventHandler(this.btnMapCancel_Click);
            // 
            // txtGoto
            // 
            this.txtGoto.Location = new System.Drawing.Point(16, 46);
            this.txtGoto.Name = "txtGoto";
            this.txtGoto.Size = new System.Drawing.Size(132, 21);
            this.txtGoto.TabIndex = 37;
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Location = new System.Drawing.Point(83, -15);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(26, 23);
            this.btnEnd.TabIndex = 39;
            this.btnEnd.Text = "종료";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Visible = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnGoto
            // 
            this.btnGoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoto.Location = new System.Drawing.Point(16, 73);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(65, 23);
            this.btnGoto.TabIndex = 36;
            this.btnGoto.Text = "검색";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btn_Goto_Click);
            // 
            // btnPngSave
            // 
            this.btnPngSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPngSave.Location = new System.Drawing.Point(84, 73);
            this.btnPngSave.Name = "btnPngSave";
            this.btnPngSave.Size = new System.Drawing.Size(65, 23);
            this.btnPngSave.TabIndex = 35;
            this.btnPngSave.Text = "지도저장";
            this.btnPngSave.UseVisualStyleBackColor = true;
            this.btnPngSave.Click += new System.EventHandler(this.btnPngSave_Click);
            // 
            // chkToolTip
            // 
            this.chkToolTip.AutoSize = true;
            this.chkToolTip.Checked = true;
            this.chkToolTip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkToolTip.Location = new System.Drawing.Point(87, 22);
            this.chkToolTip.Name = "chkToolTip";
            this.chkToolTip.Size = new System.Drawing.Size(72, 16);
            this.chkToolTip.TabIndex = 35;
            this.chkToolTip.Tag = "";
            this.chkToolTip.Text = "트랙마커";
            this.chkToolTip.UseVisualStyleBackColor = true;
            this.chkToolTip.Visible = false;
            // 
            // cboMaker
            // 
            this.cboMaker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaker.FormattingEnabled = true;
            this.cboMaker.Location = new System.Drawing.Point(91, 53);
            this.cboMaker.Name = "cboMaker";
            this.cboMaker.Size = new System.Drawing.Size(58, 20);
            this.cboMaker.TabIndex = 38;
            this.cboMaker.UseWaitCursor = true;
            this.cboMaker.Visible = false;
            this.cboMaker.SelectedIndexChanged += new System.EventHandler(this.cboMaker_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(1171, 345);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(20, 23);
            this.btnStart.TabIndex = 34;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnSetting);
            this.groupBox4.Controls.Add(this.chkToolTip);
            this.groupBox4.Location = new System.Drawing.Point(1107, 788);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(165, 49);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "설정";
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Location = new System.Drawing.Point(15, 17);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(134, 23);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Text = "설정";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.btnChart);
            this.groupBox5.Controls.Add(this.chkHeart);
            this.groupBox5.Controls.Add(this.cboGraphY);
            this.groupBox5.Controls.Add(this.chkTemp);
            this.groupBox5.Controls.Add(this.chkCad);
            this.groupBox5.Controls.Add(this.chkEle);
            this.groupBox5.Controls.Add(this.chkSpeed);
            this.groupBox5.Controls.Add(this.cboMaker);
            this.groupBox5.Controls.Add(this.cboManager);
            this.groupBox5.Location = new System.Drawing.Point(1107, 620);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(165, 158);
            this.groupBox5.TabIndex = 43;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "차트";
            // 
            // btnChart
            // 
            this.btnChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChart.Location = new System.Drawing.Point(83, 18);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(65, 23);
            this.btnChart.TabIndex = 48;
            this.btnChart.Text = "차트열기";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // GpsLogWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 849);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cboGraphX);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splAll);
            this.Name = "GpsLogWriter";
            this.Text = "Gpslog Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GpsLogWriter_FormClosing);
            this.Load += new System.EventHandler(this.GpsLogWriter_Load);
            this.splAll.Panel1.ResumeLayout(false);
            this.splAll.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splAll)).EndInit();
            this.splAll.ResumeLayout(false);
            this.splTop.Panel1.ResumeLayout(false);
            this.splTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splTop)).EndInit();
            this.splTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvGpsActivity)).EndInit();
            this.tblDetail.ResumeLayout(false);
            this.tp01.ResumeLayout(false);
            this.tp01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAscent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKcal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDistance)).EndInit();
            this.tb02.ResumeLayout(false);
            this.tb02.PerformLayout();
            this.splBottom.Panel1.ResumeLayout(false);
            this.splBottom.Panel1.PerformLayout();
            this.splBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splBottom)).EndInit();
            this.splBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvGpsLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtGpslog)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splAll;
        private System.Windows.Forms.DataGridView gvGpsLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboDate;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMultiGpsLog;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnGpsImport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.ComboBox cboManager;
        private System.Windows.Forms.ComboBox cboMapProvider;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPngSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtGoto;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.ComboBox cboMaker;
        private System.Windows.Forms.ComboBox cboLogCount;
        private System.Windows.Forms.Label lebel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnMapCancel;
        private System.Windows.Forms.Button btnMakerBtnVisible;
        private System.Windows.Forms.Button btnMarker;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.CheckBox chkToolTip;
        private System.Windows.Forms.SplitContainer splBottom;
        private System.Windows.Forms.ComboBox cboGraphY;
        private System.Windows.Forms.ComboBox cboGraphX;
        private System.Windows.Forms.ComboBox cboUtcLocal;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.Label lblLatLng;
        private System.Windows.Forms.Label lblEle;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox chkSpeed;
        private System.Windows.Forms.CheckBox chkEle;
        private System.Windows.Forms.CheckBox chkTemp;
        private System.Windows.Forms.CheckBox chkCad;
        private System.Windows.Forms.CheckBox chkHeart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMapFull;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtGpslog;
        private System.Windows.Forms.Button btnReplayEnd;
        private System.Windows.Forms.SplitContainer splTop;
        private System.Windows.Forms.DataGridView gvGpsActivity;
        private System.Windows.Forms.TabControl tblDetail;
        private System.Windows.Forms.TabPage tp01;
        private System.Windows.Forms.TabPage tb02;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblAvgSpeed;
        private System.Windows.Forms.Label lblKcal;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblAscent;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox picDistance;
        private System.Windows.Forms.PictureBox picTime;
        private System.Windows.Forms.PictureBox picSpeed;
        private System.Windows.Forms.PictureBox picKcal;
        private System.Windows.Forms.PictureBox picAscent;
        private System.Windows.Forms.PictureBox picTemp;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtHighSpeed;
        private System.Windows.Forms.TextBox txtKcal;
        private System.Windows.Forms.TextBox txtElapseTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.TextBox txtAvgEle;
        private System.Windows.Forms.TextBox txtLowEle;
        private System.Windows.Forms.TextBox txtHighEle;
        private System.Windows.Forms.TextBox txtDescent;
        private System.Windows.Forms.TextBox txtAscent;
        private System.Windows.Forms.Label lbl03;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtAvgHeart;
        private System.Windows.Forms.TextBox txtHighHeart;
        private System.Windows.Forms.TextBox txtAvgTemp;
        private System.Windows.Forms.TextBox txtHighTemp;
        private System.Windows.Forms.TextBox txtAvgCad;
        private System.Windows.Forms.TextBox txtHighCad;
        private System.Windows.Forms.TextBox txtDistance;
    }
}