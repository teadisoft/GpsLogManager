#region NameSpace

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Collections;
using System.Text.RegularExpressions;

using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GpsLogManager.Common;
using GpsLogManager.Data;
using GpsLogManager.Field;
using GpsLogManager.Utils;
using GMap.NET.MapProviders;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

#endregion

namespace GpsLogManager
{
    public partial class GpsLogWriter : Form
    {
        delegate void Position(double lat, double lng);
        delegate void ZoomLevel(double level, bool isReplay);
        delegate void MapLatLng(double lat, double lng);
        delegate void BtnReplayEnabled(bool isEnable);
        delegate void deleReplayClear();
        delegate string GpsLogItem(List<GpsLogData> item);

        public string _fileName = string.Empty;
        public string _timeType = string.Empty;

        Thread thread = null;

        #region

        /// <summary>
        /// 파싱한 Gpslog
        /// </summary>
        private List<GpsLogData> listGpxLog = null;

        private List<GpsLogData> listMapGraph = null;

        /// <summary>
        /// 파싱한 Gpslog의 자전거 라이딩 정보 계산 결과
        /// </summary>
        private List<GpsLogActivity> listGpsActivity = null;

        /// <summary>
        /// 파싱한 Gpslog의 자전거 라이딩 정보 계산 결과
        /// </summary>
        private List<GpsLogSumData> listSum = null;

        /// <summary>
        /// 라이딩 날짜 정보
        /// </summary>
        private List<RideInfo> listRideDate = null;

        /// <summary>
        /// Gpslog용 좌표 트랙 저장
        /// </summary>
        private List<PointLatLng> listPoints = null;

        /// <summary>
        /// 거리 계산용 좌표 트랙 저장
        /// </summary>
        private List<PointLatLng> listRouteTrack = null;

        /// <summary>
        /// 트랙 그리기
        /// </summary>
        private List<PointLatLng> listpolyOverlay = null;

        /// <summary>
        /// Gpslog 파싱 버튼 클릭 여부
        /// </summary>
        private bool IsGpsImportClick { get; set; }

        /// <summary>
        /// 지도 오픈 여부 체크
        /// </summary>
        private bool IsMapOpen { get; set; }

        /// <summary>
        ///  거리 계산할 시작 좌표 트랙
        /// </summary>
        private bool IsStartTrack { get; set; }

        /// <summary>
        ///  거리 계산할 종료 좌표 트랙
        /// </summary>
        private bool IsEndTrack { get; set; }

        /// <summary>
        /// 루트 트랙
        /// </summary>
        public bool IsRouteTrack { get; set; }

        /// <summary>
        /// 마커
        /// </summary>
        public bool IsPolygons { get; set; }

        /// <summary>
        /// 거리계산
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// 마커숨김버튼
        /// </summary>
        public bool IsMakerVisble { get; set; }

        /// <summary>
        /// Gps Log 조회 카운트
        /// </summary>
        public string RowCount { get; set; }

        /// <summary>
        /// 도시 이름
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 합계모드
        /// </summary>
        public bool IsSummary { get; set; }

        /// <summary>
        /// 조회 조건 Index
        /// </summary>
        private int SIndex { get; set; }

        /// <summary>
        /// [이전][다음] Index
        /// </summary>
        private int RIndex { get; set; }

        /// <summary>
        /// 차트 보기 여부
        /// </summary>
        private bool IsLogChart { get; set; }

        /// <summary>
        /// 팝업메뉴 타입(그리드/지도)
        /// </summary>
        private string MnuType { get; set; }

        /// <summary>
        /// 그래프 블럭 지정 시작지점
        /// </summary>
        private int SlectionStart { get; set; }

        /// <summary>
        /// 그래프 블럭 지정 종료지점
        /// </summary>
        private int SlectionEnd { get; set; }

        /// <summary>
        /// 전체화면 모드
        /// </summary>
        private bool IsFullMap { get; set; }

        /// <summary>
        /// 재생속도
        /// </summary>
        private int RePlaySpeed { get; set; }

        /// <summary>
        /// 재생속도
        /// </summary>
        private bool IsRePlay { get; set; }

        /// <summary>
        /// 수정모드
        /// </summary>
        private string EditMode { get; set; }

        /// <summary>
        /// 기본 지도 
        /// </summary>
        private GMapOverlay routes;

        /// <summary>
        /// Marker(마커) 레이어
        /// </summary>
        private GMapOverlay polyOverlay = new GMapOverlay("polygons");

        /// <summary>
        /// 트랙 레이어
        /// </summary>
        private GMapOverlay routeTrackOverlay = new GMapOverlay("routeTrack");

        /// <summary>
        /// 주소 레이어
        /// </summary>
        private GMapOverlay addressOverlay = new GMapOverlay("address");

        /// <summary>
        /// 경로 따라가기
        /// </summary>
        GMapOverlay replayOverlay = new GMapOverlay("replay");

        /// <summary>
        /// 계산 클레스
        /// </summary>
        GpsLogCalculate calc = null;

        /// <summary>
        /// 현재 Marker(마커) 선택
        /// </summary>
        GMarkerGoogleType currentMarkerType = GMarkerGoogleType.green_pushpin;

        /// <summary>
        /// 텍스트 박스 그룹화
        /// </summary>
        TextBox[] textBoxs;

        /// <summary>
        /// 생성자(시작점)
        /// </summary>
        public GpsLogWriter()
        {
            InitializeComponent();

            // 컨트롤 설정
            SetContorl();

            // 라이딩 날짜 ComboBox에 표시
            GetRideDate();

            // DataGridView 설정
            SetDataGridView();

            // 조회
            GetGpsLog();
        }

        #endregion

        #region Control Setting

        /// <summary>
        /// 컨트롤 초기화 및 설정
        /// </summary>
        public void SetContorl()
        {
            // 상세 정보 텍스트 박스 그룹화
            textBoxs = new TextBox[]{   txtDistance, txtSpeed, txtHighSpeed, txtTime, txtElapseTime, txtKcal,
                                        txtAscent, txtDescent, txtLowEle, txtAvgEle, txtHighEle, txtGrade,
                                        txtHighCad, txtAvgCad, txtHighTemp, txtAvgTemp, txtHighHeart, txtAvgHeart};

            foreach (TextBox txtbox in textBoxs)
            {
                txtbox.Enabled = false;
                txtbox.BackColor = Color.White;
            }

            SIndex = 0;
            RIndex = 0;
            SlectionStart = 0;
            SlectionEnd = 0;
            RePlaySpeed = 35;

            #region Instance

            calc = new GpsLogCalculate();

            listpolyOverlay = new List<PointLatLng>();
            listPoints = new List<PointLatLng>();
            listRouteTrack = new List<PointLatLng>();
            listpolyOverlay = new List<PointLatLng>();

            listGpxLog = new List<GpsLogData>();
            listGpsActivity = new List<GpsLogActivity>();
            listSum = new List<GpsLogSumData>();

            #endregion

            #region Flag (True/False)

            IsGpsImportClick = false;
            IsMapOpen = false;
            IsStartTrack = false;
            IsEndTrack = false;
            IsRouteTrack = false;
            IsPolygons = false;
            btnMapFull.Enabled = false;
            IsFullMap = false;
            IsRePlay = false;
            IsMakerVisble = true;

            MnuType = "GMap";

            #endregion

            #region Map

            gMap.Visible = false;
            gMap.ShowCenter = false;

            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMap.Manager.Mode = AccessMode.ServerAndCache;
            gMap.DragButton = MouseButtons.Left;

            gMap.MinZoom = 0;
            gMap.MaxZoom = 19;
            gMap.Zoom = 5;

            gMap.Controls.Add(lblLatLng);
            gMap.Controls.Add(lblEle);
            gMap.Controls.Add(lblZoom);

            lblZoom.Text = "Zoom Level : " + gMap.Zoom.ToString();
            CityName = "Seoul Korea";

            GMapProvider.Language = LanguageType.Korean;
            BingMapProvider.Language = LanguageType.Korean;

            #endregion

            #region ComboBox

            cboSearchType.DataSource = SetData.SearchType();
            cboMapProvider.DataSource = SetData.MapProviderList();
            cboManager.DataSource = SetData.ServerManagerList();
            cboMaker.DataSource = SetData.ToMarkerTypeList();

            SetData.SetComBoBox(cboLogCount, SetData.GpsLogRowCount());
            SetData.SetComBoBox(cboGraphX, SetData.GpsGraphX());
            SetData.SetComBoBox(cboGraphY, SetData.GpsGraphY());
            SetData.SetComBoBox(cboUtcLocal, SetData.UtcLocal());

            cboMapProvider.SelectedIndex = 0;
            cboManager.SelectedIndex = 2;
            cboMaker.SelectedIndex = 11;
            cboSearchType.SelectedIndex = 2;
            cboGraphX.SelectedIndex = 0;
            cboGraphY.SelectedIndex = 0;
            cboUtcLocal.SelectedIndex = 2;

            #endregion

            #region DataGridView

            ContextMenuStrip mnu = new ContextMenuStrip();

            ToolStripMenuItem mnuSelectAll = new ToolStripMenuItem("전체선택");
            mnuSelectAll.Click += MnuSelectAll_Click;
            mnu.Items.Add(mnuSelectAll);

            ToolStripMenuItem mnuGraph = new ToolStripMenuItem("그래프");
            mnuGraph.Click += mnuGraph_Click;
            mnu.Items.Add(mnuGraph);

            ToolStripMenuItem mnuTrackView = new ToolStripMenuItem("트랙보기");
            mnuTrackView.Click += MnuTrackView_Click;
            mnu.Items.Add(mnuTrackView);

            ToolStripMenuItem mnuReplay = new ToolStripMenuItem("재생");
            mnuReplay.Click += MnuReplay_Click;
            mnu.Items.Add(mnuReplay);

            gvGpsActivity.ContextMenuStrip = mnu;

            ContextMenuStrip mnu1 = new ContextMenuStrip();

            // Daum 지도
            ToolStripMenuItem mnu1Naver = new ToolStripMenuItem("Daum");
            mnu1Naver.Click += Mnu1Naver_Click;
            mnu1.Items.Add(mnu1Naver);

            // Naver 지도
            ToolStripMenuItem mnu1Daum = new ToolStripMenuItem("Naver");
            mnu1Daum.Click += Mnu1Daum_Click;
            mnu1.Items.Add(mnu1Daum);

            // Goolgle 지도
            ToolStripMenuItem mnu1Google = new ToolStripMenuItem("Google");
            mnu1Google.Click += Mnu1Google_Click;
            mnu1.Items.Add(mnu1Google);

            // Bing Map
            ToolStripMenuItem mnu1Bing = new ToolStripMenuItem("MS(Bing)");
            mnu1Bing.Click += Mnu1Bing_Click;
            mnu1.Items.Add(mnu1Bing);

            // GMap
            ToolStripMenuItem mnuGMap = new ToolStripMenuItem("GMap");
            mnuGMap.Click += MnuGMap_Click;
            mnu1.Items.Add(mnuGMap);

            lblLatLng.ContextMenuStrip = mnu1;
            gvGpsLog.ContextMenuStrip = mnu1;

            // 읽기속성
            gvGpsLog.ReadOnly = true;
            gvGpsActivity.ReadOnly = true;

            // ROW 전체 선택
            gvGpsLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvGpsActivity.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 헤더 정렬
            gvGpsLog.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvGpsActivity.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 마지막 Row 생성금지
            gvGpsLog.AllowUserToAddRows = false;
            gvGpsActivity.AllowUserToAddRows = false;

            // 다중 Row 선택
            gvGpsLog.MultiSelect = false;
            gvGpsActivity.MultiSelect = true;

            #endregion

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(chkToolTip, "마커 및 툴팁 표시");

            toolTip.SetToolTip(picDistance, "거리");
            toolTip.SetToolTip(picSpeed, "평균 속도");
            toolTip.SetToolTip(picKcal, "칼로리");

            toolTip.SetToolTip(picTime, "시간");
            toolTip.SetToolTip(picAscent, "누적 오르막");
            toolTip.SetToolTip(picTemp, "평균 온도");

            toolTip.SetToolTip(lblDistance, "거리");
            toolTip.SetToolTip(lblAvgSpeed, "평균 속도");
            toolTip.SetToolTip(lblKcal, "칼로리");

            toolTip.SetToolTip(lblTime, "시간");
            toolTip.SetToolTip(lblAscent, "누적 오르막");
            toolTip.SetToolTip(lblTemp, "평균 온도");

            splBottom.Panel2Collapsed = true;

            splTop.IsSplitterFixed = true;
            splAll.IsSplitterFixed = true;

            #region

            //using (CountryIP countryIp = new CountryIP())
            //           {
            //               string city = countryIp.GetlIPAddress();

            //               if (city != string.Empty)
            //                   CityName = city;
            //               else
            //                   CityName = "Seoul Korea";
            //           };

            #endregion
        }

        /// <summary>
        /// DataGradView 설정
        /// </summary>
        public void SetDataGridView()
        {
            #region MainGridView

            // 컬럼제목 설정
            List<string> listActivityHeader = new List<string>()
            {
                "날짜", "제목", "거리(Km)", "시간", "경과시간",
                "최고속도", "평균속도", "최고해발", "최저해발", "평균해발",
                "누적오르막", "누적내리막", "최고케이던스", "최저케이던스","평균케이던스",
                "최고온도", "최저온도", "평균온도", "최고심박수", "최저심박수",
                "평균심박수", "kcal", "최초생성일", "시작 위도", "시작 경도",
                "종료 위도", "종료 경도", "연도", "월", "표고차(m)",
                "경사도(%)", "중복"
            };

            // 컬럼길이 지정
            List<int> listActivityColSize = new List<int>()
            {
                80, 340, 70, 70, 70,
                70, 70, 70, 70, 70,
                80, 80, 90, 90, 90,
                90, 60, 60, 90, 90,
                90, 60, 150, 160, 130,
                130, 130, 130, 60, 80,
                80, 100
            };

            List<int> listVisibleAct = new List<int>();

            for (int i = 2; i <= 31; i++)
            {
                listVisibleAct.Add(i);
            }

            SetDataGridView<GpsLogActivity>(gvGpsActivity, listActivityHeader, listActivityColSize, 1, listVisibleAct);

            gvGpsActivity.Columns[2].Visible = true;

            #endregion

            #region SubGridView

            // 컬럼제목 설정
            List<string> listLogHeader = new List<string>()
            {
                "Seq", "날짜", "제목", "위도", "경도",
                "고도(m)", "속도(Km)", "시간(S)", "거리(km)", "좌표기록시간",
                "좌표시간(원본)", "온도", "케이던스", "심박수", "최초생성일",
                "WayPoint"
            };

            // 컬럼길이 지정
            List<int> listLogColSize = new List<int>()
            {
                60, 80, 250, 120, 120,
                70, 70, 60, 160, 160,
                160, 60, 60, 60, 160,
                70,
            };

            List<int> listVisiblelog = new List<int>() { 1, 2, 7, 8, 10, 14 };
            SetDataGridView<GpsLogData>(gvGpsLog, listLogHeader, listLogColSize, 2, listVisiblelog);

            #endregion
        }

        /// <summary>
        /// 합계
        /// </summary>
        public void SetDataGridViewSum()
        {
            // 컬럼제목 설정
            List<string> listActivityHeader = new List<string>()
            {
                "날짜", "거리(Km)", "초", "시간", "누적오르막", "누적내리막", "kcal"
            };

            // 컬럼길이 지정
            List<int> listActivityColSize = listActivityColSize = new List<int>() { 100, 80, 80, 80, 80, 80, 80 };

            SetDataGridView<GpsLogSumData>(gvGpsActivity, listActivityHeader, listActivityColSize, 0, null);

            // 헤더 가로정렬
            for (int i = 0; i < 7; i++)
            {
                if (i == 0 || i == 3)
                    gvGpsActivity.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                else
                    gvGpsActivity.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // 세자리 콤마 : 1,000
            for (int i = 1; i <= 6; i++)
            {
                if (i != 2 || i != 3)
                    gvGpsActivity.Columns[i].DefaultCellStyle.Format = " #,##0.#";
            }

            for (int i = 0; i <= 6; i++)
            {
                if (i == 2)
                    gvGpsActivity.Columns[i].Visible = false;
                else
                    gvGpsActivity.Columns[i].Visible = true;
            }
        }

        /// <summary>
        /// 데이터 그리드 뷰 셋팅
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="listHeader"></param>
        /// <param name="listSize"></param>
        /// <param name="left"></param>
        /// <param name="iVisible"></param>
        public void SetDataGridView<T>(DataGridView gv, List<string> listHeader, List<int> listColSize, int left, List<int> listVisible)
        {
            if (gv.ColumnCount != listHeader.Count)
            {
                gv.DataSource = null;
                gv.ColumnCount = listHeader.Count;
            }

            var properties = typeof(T).GetProperties();

            for (int i = 0; i < listHeader.Count; i++)
            {
                // 헤더 이름
                gv.Columns[i].HeaderText = listHeader[i];

                // 데이터 매핑 컬럼
                gv.Columns[i].DataPropertyName = properties[i].Name;

                // 컬럼 가로 크기 지정
                gv.Columns[i].Width = listColSize[i];

                // 헤더 Sort 설정
                gv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // 헤더 가로정렬
                if (i == left)
                    gv.Columns[left].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                else
                    gv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 컬럼 숨김
            if (listVisible != null)
            {
                foreach (int index in listVisible)
                {
                    gv.Columns[index].Visible = false;
                }
            }

            //gv.ColumnHeadersVisible = false;
        }

        #endregion

        #region #조회/통계

        /// <summary>
        /// ComBox 월별 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string year = cboYear.SelectedItem.ToString();

            if (!year.Contains("TOT"))
            {
                var query =
                from item in listRideDate
                where item.RIDE_DATE.Substring(0, 4) == year
                orderby item.RIDE_DATE.Substring(5, 2) descending
                select item.RIDE_DATE.Substring(5, 2);

                cboMonth.DataSource = query.Distinct().ToList();
            }
        }

        /// <summary>
        /// 라이딩 일자 조회하여 ComboBox에 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yearMonth = string.Format("{0}-{1}", cboYear.SelectedItem.ToString(), cboMonth.SelectedItem.ToString());
            var query = listRideDate.Where(n => n.RIDE_DATE.Substring(0, 7) == yearMonth)
                                            .OrderByDescending(n => n.RIDE_DATE).ToList();

            cboDate.DataSource = new BindingSource(query, null);
            cboDate.DisplayMember = "RIDE_DATE";
            cboDate.ValueMember = "RIDE_DATE";
        }

        /// <summary>
        /// 전체화면일 때 [일별] 콤보박스에서 선택하여 검색
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsFullMap)
            {
                MultiGpxLogview();
                GetGraphOverlay();
            }
        }

        /// <summary>
        /// ComboBox에 라이딩 날짜 Bind
        /// </summary>
        public void GetRideDate()
        {
            List<string> listYear = new List<string>();

            using (GpsLogDac dac = new GpsLogDac())
            {
                listRideDate = dac.GetGpsLogList<RideInfo>();
            }


            // 연도 중복제거 및 역순정렬
            IEnumerable<string> iYear = (
                from mci in listRideDate.OrderByDescending(n => n.RIDE_DATE)
                select mci.RIDE_DATE.Substring(0, 4)).Distinct().ToList();

            cboYear.DataSource = iYear;
        }

        /// <summary>
        /// 검색 조건에 따라 ComboBox를 Enabled = true/false 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SIndex = cboSearchType.SelectedIndex;

            switch (SIndex)
            {
                case 0:
                    IsSearchType(false, false, false);
                    break;
                case 1:
                    IsSearchType(true, false, false);
                    break;
                case 2:
                    IsSearchType(true, true, false);
                    break;
                case 3:
                    IsSearchType(true, true, true);
                    break;
                case 4:
                    IsSearchType(false, false, false);
                    break;
            }
        }

        /// <summary>
        /// 연도별 / 월별 / 일별 콤보 박스 선택 설정
        /// </summary>
        /// <param name="isYear"></param>
        /// <param name="isMonth"></param>
        /// <param name="isDate"></param>
        public void IsSearchType(bool isYear, bool isMonth, bool isDate)
        {
            cboYear.Enabled = isYear;
            cboMonth.Enabled = isMonth;
            cboDate.Enabled = isDate;

            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
        }

        /// <summary>
        /// GpsLog Count 선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboLogCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            RowCount = ((KeyValuePair<string, string>)cboLogCount.SelectedItem).Value;
        }

        /// <summary>
        /// Gps Log 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool isSearch = false;
            toolTipCount = 0;
            EditMode = string.Empty;

            if (SIndex == 4)
                return;

            if (IsMapOpen)
                MapClear();

            ThreadState();

            IsSummary = false;
            IsGpsImportClick = false;
            btnMap.Enabled = true;
            btnChart.Enabled = true;
            cboGraphY.Enabled = true;
            chkEle.Enabled = true;
            chkSpeed.Enabled = true;
            chkCad.Enabled = true;
            chkTemp.Enabled = true;
            chkHeart.Enabled = true;

            splBottom.Panel2Collapsed = IsLogChart ? false : true;

            splTop.Panel2Collapsed = false;

            gvGpsLog.Visible = true;
            splBottom.IsSplitterFixed = false;
            splAll.IsSplitterFixed = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            isSearch = true;
            //if (listGpsActivity.Count > 0 && listGpxLog.Count > 0)
            //{
            //    DialogResult result = MessageBox.Show("저장하지 않은 Gpx 데이터가 있습니다. 취소하겠습니까?", 
            //        "Gpslog Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (result == DialogResult.Yes)
            //        isSearch = true;
            //}
            //else
            //    isSearch = true;

            if (isSearch)
                GetGpsLog();
        }

        /// <summary>
        /// 연간/월간 합계
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSum_Click(object sender, EventArgs e)
        {
            // 초기화
            RIndex = 0;
            toolTipCount = 0;
            EditMode = string.Empty;

            if (SIndex == 4)
                return;

            IsLogChart = false;
            btnMap.Enabled = false;
            btnChart.Enabled = false;
            IsMapOpen = false;

            btnChart.Enabled = false;
            cboGraphY.Enabled = false;
            chkEle.Enabled = false;
            chkSpeed.Enabled = false;
            chkCad.Enabled = false;
            chkTemp.Enabled = false;
            chkHeart.Enabled = false;

            SIndex = cboSearchType.SelectedIndex;

            if (SIndex != 0 && listRideDate.Count > 0)
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
            }
            else
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
            }

            string date = string.Empty;
            if (listRideDate.Count > 0)
            {
                switch (SIndex)
                {
                    case 1:
                        date = cboYear.SelectedItem.ToString();
                        break;
                    case 2:
                        date = string.Format("{0}-{1}", cboYear.SelectedItem.ToString(), cboMonth.SelectedItem.ToString());
                        break;
                    case 3:
                        date = DateTimeHelper.GetWeekDay(cboDate.SelectedValue.ToString().Substring(0, 10));
                        break;
                }
            }
            else
                return;

            Summary(date);
        }

        /// <summary>
        ///  Gpx 데이터 조회
        /// </summary>
        public void GetGpsLog()
        {
            FormClear();
            SetDataGridView();

            SIndex = cboSearchType.SelectedIndex;

            listGpxLog = new List<GpsLogData>();

            if (listRideDate.Count <= 0)
                return;

            string searchString = string.Empty;

            if (listRideDate.Count > 0)
            {
                switch (SIndex)
                {
                    case 0: // 전체
                        searchString = string.Empty;
                        break;
                    case 1: // 연도별
                        searchString = cboYear.SelectedValue.ToString();
                        break;
                    case 2: // 월별
                        searchString = cboYear.SelectedValue.ToString() + "-" + cboMonth.SelectedValue.ToString();
                        break;
                    case 3: // 일별
                        searchString = cboDate.SelectedValue.ToString();
                        break;
                }
                using (GpsLogDac dac = new GpsLogDac())
                {
                    listGpsActivity = dac.GetGpsActivityList<GpsLogActivity>(searchString);
                    DataBindMain();

                    // 지도 전체화면일 경우
                    if (IsFullMap)
                    {
                        listGpxLog = dac.GetGpsLogList<GpsLogData>(searchString);
                        DataBindSub(string.Empty);
                    }
                    else
                        listGpxLog.Clear();
                }
            }
        }

        /// <summary>
        /// 메인 그리드 바인드
        /// </summary>
        private void DataBindMain()
        {
            // 상단 그리드 간이 합계
            if (listGpsActivity.Count > 1 && !IsSummary)
                GpsActivitySum();

            gvGpsActivity.DataSource = null;
            int seq = 0;

            if (IsSummary)
                gvGpsActivity.DataSource = listSum;
            else
            {
                gvGpsActivity.DataSource = listGpsActivity;

                foreach (DataGridViewRow dr in gvGpsActivity.Rows)
                {
                    if (IsGpsImportClick)
                    {
                        string value = CurrentCellValue(gvGpsActivity, seq, 31);

                        if (value == "Y")
                            gvGpsActivity.Rows[seq].DefaultCellStyle.BackColor = Color.Yellow;

                        seq++;
                    }
                }
            }
        }

        /// <summary>
        /// 서브 그리드 바인드
        /// </summary>
        private void DataBindSub(string rideDate)
        {
            if (!IsMapOpen && listGpxLog != null)
            {
                gvGpsLog.DataSource = null;
                SetDataGridView();

                if (IsGpsImportClick)
                {
                    var result = listGpxLog.Where(r => r.RIDE_DATE.Equals(rideDate) && Convert.ToInt32(r.DAY_SEQ) <= Convert.ToInt32(RowCount) - 1);
                    gvGpsLog.DataSource = result.ToList();
                }
                else
                {
                    var result = listGpxLog.Where(r => Convert.ToInt32(r.DAY_SEQ) <= Convert.ToInt32(RowCount) - 1);
                    gvGpsLog.DataSource = result.ToList();
                }
            }
        }

        /// <summary>
        /// 라이딩 정보 합계
        /// </summary>
        public void GpsActivitySum()
        {
            int rowCount = listGpsActivity.Count - 1;

            if (listGpsActivity[rowCount].RIDE_DATE.Equals("TOTAL"))
                listGpsActivity.RemoveAt(rowCount);

            List<GpsLogActivity> listTotal = new List<GpsLogActivity>();
            List<GpsLogActivity> listSum = new List<GpsLogActivity>();
            listSum = listGpsActivity;

            var query = (from r in listSum
                         group r by "" into g
                         select new
                         {
                             RAID_DATE = g.Key,
                             DISTANCE = g.Sum(r => r.DISTANCE),
                             TOTAL_ASCENT = g.Sum(r => r.TOTAL_ASCENT),
                             TOTAL_DESCENT = g.Sum(r => r.TOTAL_DESCENT),
                             KCAL = g.Sum(r => r.KCAL)
                         });

            GpsLogActivity totalRow = new GpsLogActivity
            {
                RIDE_DATE = "TOTAL",
                DISTANCE = Convert.ToDouble(query.ToList()[0].DISTANCE.ToString()),
                TOTAL_ASCENT = Convert.ToDouble(query.ToList()[0].TOTAL_ASCENT.ToString()),
                TOTAL_DESCENT = Convert.ToDouble(query.ToList()[0].TOTAL_DESCENT.ToString()),
                KCAL = Convert.ToDouble(query.ToList()[0].KCAL.ToString())
            };

            listGpsActivity.Add(totalRow);
        }

        /// <summary>
        /// 현재 선택된 RowValue
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string CurrentCellValue(DataGridView gv, int rowIndex, int cellIndex)
        {
            if (gv.Rows.Count == 0)
                return "";

            string value = string.Empty;
            DataGridViewCell cell = gv.Rows[rowIndex].Cells[cellIndex];

            if (cell != null && cell.Value != null)
                value = cell.Value.ToString();
            else
                value = string.Empty;

            return value;
        }

        /// <summary>
        /// 지난주(--)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (SIndex == 1 || SIndex == 2)
                RIndex -= 1;
            else if (SIndex == 3)
                RIndex -= 7;

            GetPreviousNext();
        }

        /// <summary>
        /// 다음주(++)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (SIndex == 1 || SIndex == 2)
                RIndex += 1;
            else if (SIndex == 3)
                RIndex += 7;

            GetPreviousNext();
        }

        /// <summary>
        /// 년/월/일=이전/다음
        /// </summary>
        public void GetPreviousNext()
        {
            string selectedDay = cboDate.SelectedValue.ToString().Substring(0, 10);
            string date = string.Empty;

            if (SIndex == 1)
                date = Convert.ToDateTime(selectedDay).AddYears(RIndex).ToString().Substring(0, 4);
            if (SIndex == 2)
                date = Convert.ToDateTime(selectedDay).AddMonths(RIndex).ToString().Substring(0, 7);
            else if (SIndex == 3)
                date = DateTimeHelper.GetWeekDay(Convert.ToDateTime(selectedDay).AddDays(RIndex).ToString());

            Summary(date);
        }

        /// <summary>
        /// 통계
        /// 1. 전체
        /// 2. 연도(1~12)
        /// 3. 월(주차)
        /// 4. 일(일주일)
        /// </summary>
        /// <param name="date"></param>
        public void Summary(string date)
        {
            List<GpsLogSumData> tempTotal = new List<GpsLogSumData>();

            FormClear();
            SetDataGridViewSum();

            IsSummary = true;

            int startLength = 0;
            int endLength = 0;

            if (SIndex == 1)
                endLength = 4;
            else if (SIndex == 3)
                endLength = 7;

            List<GpsLogSumData> tempSum = new List<GpsLogSumData>();

            // 월별 통계(그래프는 주간단위로 표시)
            if (SIndex == 2)
            {
                // 달의 일요일만 추출
                List<string> monthDays = DateTimeHelper.getWeekdatesandDates(date);

                monthDays.Add("");
                for (int i = 0; i < monthDays.Count; i++)
                {
                    string day = string.Empty;

                    if (monthDays[i] != string.Empty)
                        day = monthDays[i];
                    else
                        day = monthDays[i - 1];

                    string weekDay = string.Empty;

                    // 첫째 주
                    if (i == 0)
                        weekDay = string.Format("{0}-01~{1}", day.Substring(0, 7), day);
                    else if (i == (monthDays.Count - 1)) // 마지막주
                    {
                        int start = Convert.ToInt32(monthDays[monthDays.Count - 2].Substring(8, 2));
                        int last = DateTime.DaysInMonth(Convert.ToInt32(monthDays[0].Substring(0, 4)), Convert.ToInt32(monthDays[0].Substring(5, 2)));

                        if (start == last)
                            break;
                        else
                        {
                            string monday = Convert.ToDateTime(day.ToString()).AddDays(1).ToString("yyyy-MM-dd");
                            weekDay = string.Format("{0}~{1}-{2}", monday, day.Substring(0, 7), last);
                        }
                    }
                    else
                        weekDay = DateTimeHelper.GetWeekDay(day);

                    using (GpsLogDac dac = new GpsLogDac())
                    {
                        tempSum = dac.GpsLogSum<GpsLogSumData>(SIndex, weekDay.Replace("~", "/"));
                    }

                    if (tempSum.Count > 0)
                    {
                        tempSum[0].DATE = weekDay;
                        listSum.Add(tempSum[0] as GpsLogSumData);
                    }
                    else
                        listSum.Add(MakeSumItem(weekDay));
                }
            }
            else if (SIndex == 3) // 일별
            {
                if (listSum.Count > 0)
                    listSum.Clear();

                using (GpsLogDac dac = new GpsLogDac())
                {
                    tempSum = dac.GpsLogSum<GpsLogSumData>(SIndex, date);
                }
                List<string> listDate = null;

                string[] days = date.Split('~');
                listDate = DateTimeHelper.BetweenDay(days[0], days[1]);

                foreach (string day in listDate)
                {
                    listSum.Add(MakeSumItem(day));
                }

                foreach (GpsLogSumData item in listSum)
                {
                    foreach (GpsLogSumData tempItem in tempSum)
                    {
                        if (item.DATE.Equals(tempItem.DATE))
                        {
                            item.DISTANCE = tempItem.DISTANCE;
                            item.RIDE_SECOND = tempItem.RIDE_SECOND;
                            item.TOTAL_ASCENT = tempItem.TOTAL_ASCENT;
                            item.TOTAL_DESCENT = tempItem.TOTAL_DESCENT;
                            item.KCAL = tempItem.KCAL;

                            break;
                        }
                    }
                }
            }
            else // 전체/연도별
            {
                using (GpsLogDac dac = new GpsLogDac())
                {
                    listSum = dac.GpsLogSum<GpsLogSumData>(SIndex, date);
                }
            }


            tempTotal.AddRange(listSum.Where(t => !string.IsNullOrEmpty(t.DATE)));

            listSum.Clear();
            if (tempTotal.Count > 0)
            {
                var query =
                    (from dr in tempTotal
                     group dr by SIndex != 2 ? dr.DATE.Substring(startLength, endLength) : "DATE" into g
                     select new
                     {
                         DATE = g.Key,
                         DISTANCE = g.Sum(r => r.DISTANCE),
                         RIDESECOND = g.Sum(r => r.RIDE_SECOND),
                         TOTAL_ASCENT = g.Sum(r => r.TOTAL_ASCENT),
                         TOTAL_DESCENT = g.Sum(r => r.TOTAL_DESCENT),
                         KCAL = g.Sum(r => r.KCAL)
                     }).ToList();

                GpsLogSumData total = new GpsLogSumData
                {
                    DATE = "Total",
                    DISTANCE = query[0].DISTANCE,
                    RIDE_SECOND = query[0].RIDESECOND,
                    TOTAL_ASCENT = query[0].TOTAL_ASCENT,
                    TOTAL_DESCENT = query[0].TOTAL_DESCENT,
                    KCAL = query[0].KCAL
                };

                tempTotal.Add(total);

                foreach (GpsLogSumData item in tempTotal)
                {
                    GpsLogSumData newItem = new GpsLogSumData();

                    double second = Convert.ToDouble(item.RIDE_SECOND);
                    string week = item.DATE;

                    if (SIndex == 2 && week != "Total")
                    {
                        string[] days = week.Split('~');
                        newItem.DATE = string.Format("{0}~{1}", days[0].Substring(5), days[1].Substring(5));
                    }
                    else
                        newItem.DATE = item.DATE;

                    // 거리
                    newItem.DISTANCE = Math.Round(Convert.ToDouble(item.DISTANCE), 1);
                    newItem.RIDE_SECOND = item.RIDE_SECOND; // 시간(초) 숨김컬럼

                    string time = TimeSpan.FromSeconds(second).ToString();

                    if (86400 >= second)
                        newItem.RIDE_TIME = "00" + time;
                    else
                    {
                        string[] times = time.Split('.');

                        int timeCount = (Convert.ToInt32(times[0]) * 24) + Convert.ToInt32(times[1].Substring(0, 2));

                        if (timeCount <= 99)
                            newItem.RIDE_TIME = "00" + timeCount.ToString() + times[1].Substring(2);
                        else if (timeCount >= 100)
                            newItem.RIDE_TIME = "0" + timeCount.ToString() + times[1].Substring(2);
                    }

                    newItem.TOTAL_ASCENT = item.TOTAL_ASCENT; // 누적오르막
                    newItem.TOTAL_DESCENT = item.TOTAL_DESCENT; // 누적내리막
                    newItem.KCAL = item.KCAL; // kcal

                    listSum.Add(newItem);
                }
            }


            // 합계 바인딩
            if (IsSummary)
                DataBindMain();

            // 그래프
            splBottom.Panel2Collapsed = false;
            gvGpsLog.Visible = false;
            splBottom.SplitterDistance = 0;
            splBottom.IsSplitterFixed = true;
            splAll.IsSplitterFixed = true;

            splTop.Panel2Collapsed = true;

            if (listSum != null)
                ChartGraph.Column(chtGpslog, tempTotal, date);
        }

        public GpsLogSumData MakeSumItem(string day)
        {
            GpsLogSumData item = new GpsLogSumData
            {
                DATE = day,
                DISTANCE = 0,
                RIDE_SECOND = 0,
                RIDE_TIME = "0",
                TOTAL_ASCENT = 0,
                TOTAL_DESCENT = 0,
                KCAL = 0
            };

            return item;
        }

        #endregion

        #region #관리

        Thread _thread1;
        Thread _thread2;
        Thread _thread3;

        /// <summary>
        /// *.gpx 파일 읽기및 파싱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGpsImport_Click(object sender, EventArgs e)
        {
            if (IsSummary || IsFullMap)
                return;

            try
            {
                OpenFileDialog dig = new OpenFileDialog()
                {
                    CheckPathExists = true,
                    CheckFileExists = false,
                    AddExtension = true,
                    DefaultExt = "gpx",
                    Title = "Gmap.Net: open gpx log",
                    Filter = "gpx files (*.gpx) |*.gpx",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    Multiselect = true
                };

                if (dig.ShowDialog() == DialogResult.OK)
                {
                    FormClear();
                    SetDataGridView();
                    IsGpsImportClick = true;

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();

                    string[] fileNames = dig.FileNames;

                    int count = fileNames.Length / 3;

                    _timeType = ((KeyValuePair<string, string>)cboUtcLocal.SelectedItem).Value;

                    _thread1 = new Thread(delegate ()
                    {
                        ThreadParssing(0, count, fileNames);
                    });
                    _thread1.Start(); _thread1.Join();

                    _thread2 = new Thread(delegate ()
                    {
                        ThreadParssing(count, count + count, fileNames);
                    });
                    _thread2.Start(); _thread2.Join();

                    _thread3 = new Thread(delegate ()
                    {
                        ThreadParssing(count + count, fileNames.Length, fileNames);
                    });
                    _thread3.Start(); _thread3.Join();

                    DataBindMain();
                    RideDetailInfo(0);

                    TimeSpan ts = stopWatch.Elapsed;
                    MessageBox.Show("파싱완료 : " + DateTimeHelper.GetTimeFormat(ts, DateTimeHelper.TimeFormat.HH_MM_SS_MS),
                        "Gpslog Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EditMode = "Insert";

                    _thread1.Abort();
                    _thread2.Abort();
                    _thread3.Abort();
                }
                else
                {
                    if (listGpsActivity.Count > 0 && listGpxLog.Count > 0)
                        IsGpsImportClick = true;
                    else
                        IsGpsImportClick = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public void ThreadParssing(int from, int to, string[] fileNames)
        {
            for (int i = from; i < to; i++)
            {
                _fileName = fileNames[i];
                gpsLogParser();
            }
        }

        /// <summary>
        /// GpsLog 파싱
        /// </summary>
        /// <param name="filePath"></param>
        public void gpsLogParser()
        {
            // 파일 확장자에 따라 분기
            Parser.FileRamify fileRamify = new Parser.FileRamify(_fileName, _timeType);

            // Gps Log 파싱
            List<GpsLogData> tempGpxLog = fileRamify.Ramiify(listRideDate);

            // 파싱한 Gps Log를 누적(DB 등록 및 지도에서 루트 보는 용도)
            foreach (GpsLogData goslog in tempGpxLog)
            {
                listGpxLog.Add(goslog);
            }

            // 파싱한 결과를 이용하여 라이딩 정보 추출
            Parser.TotalActivity gpxActivity = new Parser.TotalActivity(tempGpxLog);
            listGpsActivity.Add(gpxActivity.GetActivity("Total"));

            tempGpxLog.Clear();
        }

        /// <summary>
        /// Gps Log 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsSummary || IsFullMap || IsRePlay)
                return;

            if (EditMode == "Insert")
            {
                if (listGpsActivity.Count > 0 && listGpxLog.Count > 0)
                {
                    DialogResult result = MessageBox.Show("GPX LOG 데이터를 저장하겠습니까?", "Gpslog Manager",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        using (GpsLogDac dac = new GpsLogDac())
                        {
                            // 중복제거
                            dac.InsertGpsActivity(listGpsActivity.Where(n => n.OVERLAP != "Y" && n.RIDE_DATE != "TOTAL").ToList());
                            dac.InsertGpsLog(listGpxLog.Where(n => n.OVERLAP != "Y").ToList());
                        }

                        TimeSpan ts = stopWatch.Elapsed;

                        MessageBox.Show("등록완료 : " + DateTimeHelper.GetTimeFormat(ts,
                            DateTimeHelper.TimeFormat.HH_MM_SS_MS), "Gpslog Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (cboYear.Items.Count > 0)
                            cboYear.SelectedIndex = cboYear.Items.Count - 1;
                    }
                }
                else
                    MessageBox.Show("등록할 데이터가 없습니다.", "Gpslog Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (EditMode == "Modify")
            {
                var result = gvGpsActivity.Rows.OfType<DataGridViewRow>().Select(
                    r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();

                // 조회할 때만 수정할 수 있도록 허용
                for (int i = 0; i < result.Count; i++)
                {
                    listGpsActivity.Add(new GpsLogActivity(result[i][1].ToString(), result[i][22].ToString()));
                }
                using (GpsLogDac dac = new GpsLogDac())
                {
                    dac.UpdateGpsActivity(listGpsActivity);
                }

                gvGpsActivity.Columns[1].ReadOnly = true;
                gvGpsActivity.ReadOnly = true;
            }

            GetRideDate();
            GetGpsLog();
        }

        /// <summary>
        ///  Gps Log 수정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (IsSummary || IsFullMap || IsRePlay)
                return;

            EditMode = "Modify";
        }

        /// <summary>
        /// Gps Log 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsSummary || IsFullMap || IsRePlay)
                return;

            bool isDelete = false;

            // 파싱한 데이터가 남아 있는지 체크
            if (IsGpsImportClick)
            {
                MessageBox.Show("아직 저장하지 않은 데이터가 남아 있습니다.", "Gpslog Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gvGpsActivity.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in gvGpsActivity.SelectedRows)
                {
                    string value = CurrentCellValue(gvGpsActivity, row.Index, 22);

                    GpsLogActivity delete = new GpsLogActivity();
                    delete.RIDE_DATE_ORIGEN = value;

                    if (value.Length > 0)
                    {
                        listGpsActivity.Add(delete);
                        isDelete = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("삭제할 데이터가 없습니다.", "Gpslog Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (isDelete)
            {
                DialogResult result = MessageBox.Show("선택한 로그를 삭제하겠습니까?", "Gpslog Manager",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (GpsLogDac dac = new GpsLogDac())
                    {
                        dac.DeleteGpsLog(listGpsActivity);
                        btnSearch_Click(null, null);
                    }
                }
                else
                {
                    listGpsActivity.Clear();
                    isDelete = false;
                }
            }

            GetRideDate();

            if (listRideDate.Count == 0)
            {
                cboYear.Text = string.Empty;
                cboMonth.Text = string.Empty;
                cboDate.Text = string.Empty;
            }

            GetGpsLog();
        }

        /// <summary>
        /// 폼 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            EditMode = string.Empty;

            if (IsSummary || IsFullMap || IsRePlay)
                return;

            FormClear();
            SetDataGridView();

            if (listPoints.Count > 0 || listpolyOverlay.Count > 0)
            {
                DialogResult result = MessageBox.Show("지도 데이터가 남아 있습니다. 지우시겠습니까?",
                    "Gpslog Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MapClear();
                    gMap.Zoom = 12;
                    gMap.SetPositionByKeywords(CityName);
                }
            }
        }

        /// <summary>
        /// 폼 초기화
        /// </summary>
        public void FormClear()
        {
            IsGpsImportClick = false;
            gvGpsLog.DataSource = null;
            gvGpsActivity.DataSource = null;
            listGpxLog.Clear();
            listGpsActivity.Clear();
            listSum.Clear();

            chtGpslog.Series.Clear();

            // 상세정보
            lblDistance.Text = string.Empty;
            lblAvgSpeed.Text = string.Empty;
            lblKcal.Text = string.Empty;
            lblTime.Text = string.Empty;
            lblAscent.Text = string.Empty;
            lblTemp.Text = string.Empty;

            foreach (TextBox txtbox in textBoxs)
            {
                txtbox.Text = string.Empty;
            }
        }

        #endregion

        #region #지도

        /// <summary>
        /// 지도 선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMapProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maps = cboMapProvider.SelectedItem.ToString();
            SetData.MapProvider(maps, gMap);
        }

        /// <summary>
        /// 지명/좌표 찾기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Goto_Click(object sender, EventArgs e)
        {
            if (addressOverlay.Markers.Count > 0)
                addressOverlay.Markers.Clear();

            if (IsMapOpen && !IsRePlay)
            {
                string coordinate = txtGoto.Text;
                if (!string.IsNullOrEmpty(coordinate))
                {
                    // 숫자 체크
                    if (CheckNumber(coordinate))
                    {
                        string[] split = null;

                        if (coordinate.IndexOf(",") == -1)
                            split = coordinate.Split(' ');
                        else
                            split = coordinate.Split(',');

                        if (split.Length > 1)
                        {
                            double lat = Convert.ToDouble(split[0].ToString());
                            double lng = Convert.ToDouble(split[1].ToString());

                            gMap.Position = new PointLatLng(lat, lng);
                        }
                    }
                    else
                        gMap.SetPositionByKeywords(coordinate);
                }
                else
                    gMap.SetPositionByKeywords(CityName);

                string address = SetData.GetAddress(gMap.Position.Lat, gMap.Position.Lng);
                string toolTip = string.Format("주소 : {0}", address);
                addressOverlay.Markers.Add(Routing.MarkerToolTip(gMap.Position.Lat, gMap.Position.Lng, toolTip,
                    GMarkerGoogleType.yellow_pushpin, MarkerTooltipMode.Always));
                gMap.Overlays.Add(addressOverlay);
                gMap.Zoom = 14;
            }
        }

        /// <summary>
        ///  숫자 체크
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public static bool CheckNumber(string letter)
        {
            bool IsCheck = true;

            Regex numRegex = new Regex(@"[0-9]");
            Boolean ismatch = numRegex.IsMatch(letter);

            if (!ismatch) IsCheck = false;

            return IsCheck;
        }

        /// <summary>
        ///  지도 이미지 저장(*.png)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPngSave_Click(object sender, EventArgs e)
        {
            if (IsMapOpen)
            {
                try
                {
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "PNG (*.png)|*.png";
                        sfd.FileName = "GMap.NET image";

                        Image tmpImage = gMap.ToImage();
                        if (tmpImage != null)
                        {
                            using (tmpImage)
                            {
                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    tmpImage.Save(sfd.FileName);

                                    MessageBox.Show("이미지 저장이 완료 되었습니다." + sfd.FileName,
                                        "Gpslog Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("이미지를 저장 불가합니다. " + ex.Message,
                        "Gpslog Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                return;
        }

        /// <summary>
        /// 멀티 GPS 로그 정보 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMultiGpsLog_Click(object sender, EventArgs e)
        {
            if (IsMapOpen && !IsRePlay)
                MultiGpxLogview();

            GetGraphOverlay();
        }

        /// <summary>
        ///  다중 Gpx Log 루트 보기
        /// </summary>
        public void MultiGpxLogview()
        {
            Thread th1 = null;
            Thread th2 = null;

            toolTipCount = 0;

            bool isTrackDelete = false;

            if (IsSummary)
                return;

            if (listpolyOverlay.Count > 0)
            {
                DialogResult result = MessageBox.Show("생성한 트랙 데이터가 남아 있습니다. 취소하시겠습니까?",
                    "Gpslog Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    isTrackDelete = true;
            }
            else
                isTrackDelete = true;

            if (isTrackDelete)
            {
                listpolyOverlay.Clear();

                List<MakerToolTips> pointsExtension = new List<MakerToolTips>();
                ArrayList aryPoints = new ArrayList();
                ArrayList aryWp = new ArrayList();

                // 선택된 Row에서 키값(자전거 라이딩 시작시간)
                List<string> listrideDateOrigen = new List<string>();

                foreach (DataGridViewRow row in gvGpsActivity.SelectedRows)
                {
                    if (!IsGpsImportClick)
                    {
                        string day = CurrentCellValue(gvGpsActivity, row.Index, 22);

                        if (IsFullMap)
                            listrideDateOrigen.Add(cboDate.SelectedValue.ToString());
                        else
                            listrideDateOrigen.Add(day);
                    }
                }

                List<string> listDate01 = new List<string>();
                List<string> listDate02 = new List<string>();

                int mom = listrideDateOrigen.Count / 2;

                for (int idate = 0; idate < listrideDateOrigen.Count; idate++)
                {
                    if (idate < mom)
                    {
                        listDate01.Add(listrideDateOrigen[idate]);
                    }
                    else
                    {
                        listDate02.Add(listrideDateOrigen[idate]);
                    }
                }

                if (!IsGpsImportClick)
                {
                    listGpxLog.Clear();

                    using (GpsLogDac dac = new GpsLogDac())
                    {
                        th1 = new Thread(delegate ()
                        {
                            listGpxLog.AddRange(dac.GetLatlng<GpsLogData>(listDate01));
                        });
                        th1.Start(); th1.Join();
                    }

                    using (GpsLogDac dac = new GpsLogDac())
                    {
                        th2 = new Thread(delegate ()
                        {
                            listGpxLog.AddRange(dac.GetLatlng<GpsLogData>(listDate02));
                        });
                        th2.Start(); th2.Join();
                    }


                    th1.Abort();
                    th2.Abort();
                }


                foreach (DataGridViewRow row in gvGpsActivity.SelectedRows)
                {
                    string value = string.Empty;

                    if (IsFullMap)
                        value = cboDate.SelectedValue.ToString();
                    else
                        value = CurrentCellValue(gvGpsActivity, row.Index, 22);

                    if (value.Length > 0)
                        pointsExtension.Add(GetPointsInfo(row));

                    List<GpsLogData> listWp = new List<GpsLogData>();
                    List<PointLatLng> listPoints = new List<PointLatLng>();

                    foreach (GpsLogData log in listGpxLog)
                    {
                        if (log.RIDE_DATE_ORIGEN == value && log.WAYPOINT == "Y")
                            listWp.Add(new GpsLogData(log.TITLE, log.LAT, log.LNG, log.ELE));

                        if (log.RIDE_DATE_ORIGEN == value && log.WAYPOINT != "Y")
                            listPoints.Add(new PointLatLng(log.LAT, log.LNG));
                    }

                    // 위경도 및 WayPoint
                    if (listPoints.Count > 0) aryPoints.Add(listPoints);
                    if (listWp.Count > 0) aryWp.Add(listWp);
                }


                if (aryPoints.Count > 0)
                {
                    if (IsMapOpen)
                    {
                        gMap.Overlays.Clear();
                        gMap.Refresh();

                        routes = new GMapOverlay("routes");

                        // 지도 위에 Route 표시
                        for (int iPoint = 0; iPoint < aryPoints.Count; iPoint++)
                        {
                            List<PointLatLng> listPoints = aryPoints[iPoint] as List<PointLatLng>;
                            GMapRoute route = Routing.RouteDrawing(listPoints, 3, Color.Red, DashStyle.Solid);
                            routes.Routes.Add(route);
                            gMap.ZoomAndCenterRoute(route);
                        }

                        gMap.Overlays.Add(routes);

                        // 체크 되어 있는 경우만 마커 및 툴팁 표시
                        if (chkToolTip.Checked)
                        {
                            foreach (MakerToolTips point in pointsExtension)
                            {
                                GMapOverlay overlay = new GMapOverlay("overlay");

                                if (pointsExtension.Count == 1)
                                {
                                    overlay.Markers.Add(Routing.MarkerToolTip(point.StartLat, point.StartLng, "Start", GMarkerGoogleType.green, MarkerTooltipMode.OnMouseOver));
                                    overlay.Markers.Add(Routing.MarkerToolTip(point.EndLat, point.EndLng, "End", GMarkerGoogleType.red, MarkerTooltipMode.OnMouseOver));
                                }
                                else
                                    overlay.Markers.Add(Routing.MarkerToolTip(point.EndLat, point.EndLng, point.RideDate, GMarkerGoogleType.red, MarkerTooltipMode.OnMouseOver));

                                gMap.Overlays.Add(overlay);
                            }

                            // Way Point ToolTip
                            for (int arrWp = 0; arrWp < aryWp.Count; arrWp++)
                            {
                                List<GpsLogData> tempWp = aryWp[arrWp] as List<GpsLogData>;
                                GMapOverlay wayOverlay = new GMapOverlay("wayOverlay");

                                for (int w = 0; w < tempWp.Count; w++)
                                {
                                    string sTooltip = string.Format("{0}\n위도 : {1}\n경도 : {2}\n고도 : {3}",
                                        tempWp[w].TITLE, tempWp[w].LAT, tempWp[w].LNG, tempWp[w].ELE);

                                    wayOverlay.Markers.Add(Routing.MarkerToolTip(tempWp[w].LAT, tempWp[w].LNG, sTooltip,
                                        GMarkerGoogleType.yellow_pushpin, MarkerTooltipMode.OnMouseOver));
                                }

                                gMap.Overlays.Add(wayOverlay);
                            }
                        }

                        // 최종 지도 위치
                        List<PointLatLng> tempPoints = aryPoints[0] as List<PointLatLng>;
                        MapPosition(tempPoints, false);
                        tempPoints.Clear();
                    }

                    aryPoints.Clear();
                    listPoints.Clear();
                    pointsExtension.Clear();
                }
                else
                    MapClear();
            }
        }

        /// <summary>
        /// 지도위치
        /// </summary>
        /// <param name="list"></param>
        public void MapPosition(List<PointLatLng> list, bool isChart)
        {
            if (list.Count == 0)
                return;

            double pLat = list.Average(n => n.Lat);
            double pLng = list.Average(n => n.Lng);

            if (isChart)
                gMap.Zoom = gMap.Zoom - 1;

            gMap.Position = new PointLatLng(pLat, pLng);
        }

        /// <summary>
        /// 마커(Marker) 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMarker_Click(object sender, EventArgs e)
        {
            if (IsMapOpen && !IsPolygons && !IsRePlay)
            {
                IsPolygons = true;
                btnMarker.Text = "트랙종료";
                gMap.DragButton = MouseButtons.Right;
                cboMaker.SelectedIndex = 34;
            }
            else
            {
                IsPolygons = false;
                btnMarker.Text = "트랙시작";
                gMap.DragButton = MouseButtons.Left;
                cboMaker.SelectedIndex = 11;
            }
        }

        /// <summary>
        /// 경로 따라기기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplay_Click(object sender, EventArgs e)
        {
            if (gvGpsActivity.SelectedRows.Count == 1)
                Run();
        }

        /// <summary>
        /// 재생 중지(스레드 종료)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplayEnd_Click(object sender, EventArgs e)
        {
            if (IsMapOpen)
            {
                ThreadState();
                btnReplayEnd.Enabled = false;
            }
        }

        /// <summary>
        /// 경로 따라기기 스레드 작업
        /// </summary>
        private void Run()
        {
            if (listGpxLog != null && IsMapOpen && !IsRePlay)
            {
                if (gMap.Overlays.Count <= 0)
                {
                    MultiGpxLogview();
                    return;
                }

                thread = new Thread(new ThreadStart(Replay));
                thread.IsBackground = true;
                thread.Start();

                IsRePlay = true;
                btnReplay.Enabled = false;
                btnReplayEnd.Enabled = true;
            }
        }

        /// <summary>
        /// 경로 따라기기
        /// </summary>
        private void Replay()
        {
            // 거리
            Distance = 0;

            // 라이딩 시간
            double totalSecond = 0;

            // Row Count
            int count = listGpxLog.Count - 1;

            for (int i = 0; i < count; i++)
            {
                if (i != count)
                {
                    this.Invoke(new deleReplayClear(ReplayClear));

                    double lat = listGpxLog[i].LAT;
                    double lng = listGpxLog[i].LNG;

                    if (listGpxLog[i].SPEED_KMH > 3)
                    {
                        Distance += listGpxLog[i].KM;
                        totalSecond += listGpxLog[i].DIFF_TIME;
                    }

                    string diffTime = DateTimeHelper.GetTimeFormat(TimeSpan.FromSeconds(totalSecond), DateTimeHelper.TimeFormat.HH_MM_SS);

                    string ele = listGpxLog[i].ELE.ToString();
                    string speed = listGpxLog[i].SPEED_KMH.ToString();
                    string cad = listGpxLog[i].CAD.ToString();

                    string toolTip = string.Format("고도 : {0}\n거리 : {1}\n시간 : {2}\n속도 : {3}\nCAD : {4}", ele, Math.Round(Distance, 1).ToString(), diffTime, speed, cad);

                    replayOverlay.Markers.Add(Routing.MarkerToolTip(lat, lng, toolTip,
                    GMarkerGoogleType.yellow_pushpin, MarkerTooltipMode.Always));
                    gMap.Overlays.Add(replayOverlay);

                    this.Invoke(new ZoomLevel(ChangeZoomLevel), 16, true);
                    this.Invoke(new Position(GMapPosition), lat, lng);

                    Thread.Sleep(RePlaySpeed);
                }
                else
                    return; // 마지막 Row
            }

            if (thread != null)
                this.Invoke(new BtnReplayEnabled(BtnReplayEnabledTrue), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isEnabled"></param>
        private void BtnReplayEnabledTrue(bool isEnabled)
        {
            btnReplay.Enabled = isEnabled;
            thread.Abort();
            IsRePlay = false;
        }

        /// <summary>
        /// 경로 따라가면서 이전 오버레이와 마커 삭제
        /// </summary>
        private void ReplayClear()
        {
            if (replayOverlay.Markers.Count > 0)
                replayOverlay.Markers.Clear();

            if (gMap.Overlays.Count > 0)
            {
                for (int f = 2; f < gMap.Overlays.Count; f++)
                {
                    gMap.Overlays.RemoveAt(f);
                }
            }
        }

        /// <summary>
        /// 지도 줌 레벨
        /// </summary>
        /// <param name="level"></param>
        /// <param name="isReplay"></param>
        private void ChangeZoomLevel(double level, bool isReplay)
        {
            if (!isReplay)
                lblZoom.Text = "Zoom Level : " + level.ToString();
            else
                gMap.Zoom = level;
        }

        /// <summary>
        /// 지도 위치
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        private void GMapPosition(double lat, double lng)
        {
            gMap.Position = new PointLatLng(lat, lng);
        }

        /// <summary>
        /// 스레드 종료
        /// </summary>
        private void ThreadState()
        {
            if (thread != null)
            {
                thread.Abort();

                IsRePlay = false;
                btnReplay.Enabled = true;

                ReplayClear();
            }
        }

        /// <summary>
        /// 지도 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMapCancel_Click(object sender, EventArgs e)
        {
            MapClear();
        }

        /// <summary>
        /// 지도 초기화
        /// </summary>
        private void MapClear()
        {
            Distance = 0;

            gMap.Overlays.Clear();
            gMap.Refresh();
            txtGoto.Text = string.Empty;
            IsStartTrack = false;
            IsEndTrack = false;
            IsRouteTrack = false;
            IsPolygons = false;
            listPoints.Clear();
            listRouteTrack.Clear();
            listpolyOverlay.Clear();
            polyOverlay.Clear();
            routeTrackOverlay.Clear();

            gMap.DragButton = MouseButtons.Left;

            btnMarker.Text = "트랙시작";

            if (thread != null)
            {
                thread.Abort();

                IsRePlay = false;
                btnReplay.Enabled = true;
                btnReplayEnd.Enabled = true;
                ReplayClear();
            }
        }

        /// <summary>
        /// 지도 열기/닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMap_Click(object sender, EventArgs e)
        {
            if (!IsMapOpen)
            {
                // 조회된 정보가 없으면 지도를 초기화 한다.
                if (gvGpsActivity.Rows.Count <= 0)
                    gMap.Overlays.Clear();

                // 지도에 데이터가 남아 있지 않으면 위치를 초기화 한다.
                if (gMap.Overlays.Count == 0)
                {
                    gMap.Zoom = 12;
                    gMap.SetPositionByKeywords(CityName);
                }

                gvGpsLog.DataSource = null;
                gvGpsLog.Rows.Clear();

                gMap.Visible = true;
                lblLatLng.Visible = true;
                IsMapOpen = true;

                btnSum.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnMapFull.Enabled = true;

                btnMap.Text = "지도 닫기";
            }
            else
            {
                gMap.Visible = false;
                IsMapOpen = false;
                lblLatLng.Visible = false;

                btnSum.Enabled = true;
                gvGpsLog.Visible = true;
                btnMapFull.Enabled = false;

                btnMap.Text = "지도 열기";
            }
        }

        /// <summary>
        /// 지도 전체화면 모드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMapFull_Click(object sender, EventArgs e)
        {
            if (!splAll.Panel1Collapsed)
            {
                splAll.Panel1Collapsed = true;
                btnMap.Enabled = false;
                IsFullMap = true;
                btnSearch.Enabled = false;
                cboSearchType.SelectedIndex = 3;
                SIndex = 3;
            }
            else
            {
                splAll.Panel1Collapsed = false;
                btnMap.Enabled = true;
                IsFullMap = false;
                btnSearch.Enabled = true;
                cboSearchType.SelectedIndex = 2;
                SIndex = 2;
            }
        }

        /// <summary>
        /// 루트 및 폴리곤 그리기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                double lat = gMap.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gMap.FromLocalToLatLng(e.X, e.Y).Lng;

                string ele = string.Empty; // Math.Round(Routing.GetElevation(lat, lng)).ToString();
                //lblEle.Text = string.Format("고도: {0}", ele == "0" ? "Server Error" : ele);

                if (IsRouteTrack && IsStartTrack)
                {
                    PointLatLng points = new PointLatLng(lat, lng);
                    listRouteTrack.Add(points);

                    GMarkerGoogle marker = new GMarkerGoogle(points, GMarkerGoogleType.yellow_dot);
                    gMap.Overlays.Add(routeTrackOverlay);
                    routeTrackOverlay.Markers.Add(marker);

                    IsRouteTrack = false;
                    IsStartTrack = false;
                }

                if (IsRouteTrack && IsEndTrack)
                {
                    PointLatLng points = new PointLatLng(lat, lng);
                    listRouteTrack.Add(points);

                    GMarkerGoogle marker = new GMarkerGoogle(points, GMarkerGoogleType.yellow_dot);
                    gMap.Overlays.Add(routeTrackOverlay);
                    routeTrackOverlay.Markers.Add(marker);

                    IsRouteTrack = false;
                    IsEndTrack = false;

                    if (listRouteTrack.Count == 2)
                    {
                        GDirections gdirections;
                        var gmapProviders = GMap.NET.MapProviders.GMapProviders.GoogleMap.GetDirections(
                            out gdirections, listRouteTrack[0], listRouteTrack[1], false, false, false, false, false);

                        if (gmapProviders.ToString() == "OK")
                        {
                            GMapOverlay routeOverlay = new GMapOverlay("route");
                            gMap.Overlays.Add(routeOverlay);

                            GMapRoute r = new GMapRoute(gdirections.Route, "My route");
                            {
                                r.Stroke.Width = 2;
                                r.Stroke.Color = Color.OrangeRed;
                            }
                            routeOverlay.Routes.Add(r);

                            double distance = Math.Round(Convert.ToDouble(gdirections.Distance.Replace("mi", "")) * 1.60934, 2);
                            MessageBox.Show(distance.ToString());
                            listRouteTrack.Clear();
                            btnMarker.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("거리 계산 불가 지역(메시지코드:{ZERO_RESULTS}");
                            IsEndTrack = false;
                            IsStartTrack = false;
                            IsRouteTrack = false;
                            listRouteTrack.Clear();
                            gMap.Overlays.Clear();
                        }
                    }
                }

                if (IsPolygons)
                {
                    PointLatLng points = new PointLatLng(lat, lng);

                    listpolyOverlay.Add(points);

                    string sTooltip = string.Format("{0}\nLat : {1}, lng : {2}, Ele : {3}", SetData.GetAddress(lat, lng), lat, lng, ele);

                    GMarkerGoogle polyMarker = new GMarkerGoogle(points, GMarkerGoogleType.yellow_dot)
                    {
                        ToolTipText = sTooltip,
                        ToolTipMode = MarkerTooltipMode.OnMouseOver,
                    };

                    GMapPolygon polygon = new GMapPolygon(NextPoint(listpolyOverlay.Count), "mypolygon");
                    polygon.Fill = new SolidBrush(Color.FromArgb(0, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 3);

                    gMap.Overlays.Add(polyOverlay);
                    polyOverlay.Markers.Add(polyMarker);
                    polyOverlay.Polygons.Add(polygon);

                    btnStart.Enabled = true;
                    btnEnd.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 폴리곤 이어긋기
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<PointLatLng> NextPoint(int count)
        {
            List<PointLatLng> next = new List<PointLatLng>();

            if (listpolyOverlay.Count >= 2)
            {
                double sLat = (listpolyOverlay[count - 2]).Lat;
                double slng = (listpolyOverlay[count - 2]).Lng;
                double eLat = (listpolyOverlay[count - 1]).Lat;
                double elng = (listpolyOverlay[count - 1]).Lng;

                PointLatLng p1 = new PointLatLng(sLat, slng);
                PointLatLng p2 = new PointLatLng(eLat, elng);

                Distance += calc.Distance(sLat, slng, eLat, elng);
                txtGoto.Text = Math.Round(Distance, 2).ToString();

                next.Add(p1);
                next.Add(p2);
            }

            return next;
        }

        /// <summary>
        /// 지도에 위경도 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gMap_MouseMove(object sender, MouseEventArgs e)
        {
            double lat = Math.Round(gMap.FromLocalToLatLng(e.X, e.Y).Lat, 7);
            double lng = Math.Round(gMap.FromLocalToLatLng(e.X, e.Y).Lng, 7);

            if (!IsRePlay)
                lblLatLng.Text = string.Format("위도: {0} 경도: {1}", lat, lng);
            else
                lblLatLng.Text = string.Format("위도: {0} 경도: {1}", "", "");
        }

        /// <summary>
        /// 현재 줌 레벨
        /// </summary>
        private void gMap_OnMapZoomChanged()
        {
            if (IsMapOpen)
                this.Invoke(new ZoomLevel(ChangeZoomLevel), gMap.Zoom, false);
        }

        int toolTipCount = 0;

        /// <summary>
        ///  마커 삭제
        /// </summary>
        /// <param name="item"></param>
        /// <param name="e"></param>
        private void gMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            // 다중 루트 출력시 마커 선택 하면 해당 날짜의 루트를 돋 보이게 처리
            if (gvGpsActivity.SelectedRows.Count >= 2)
            {
                if (toolTipCount > 0)
                {
                    // 루트 만 남기고 삭제
                    gMap.Overlays.RemoveAt(gMap.Overlays.Count - 1);
                    routes.Routes.RemoveAt(gMap.Overlays.Count - 1);
                }

                List<GpsLogData> list = new List<GpsLogData>();

                var query = from r in listGpsActivity
                            where r.RIDE_DATE == item.ToolTipText
                            select new
                            {
                                RIDE_DATE_ORIGEN = r.RIDE_DATE_ORIGEN
                            };

                string value = query.ToList()[0].RIDE_DATE_ORIGEN;

                using (GpsLogDac dac = new GpsLogDac())
                {
                    list = dac.GetGpsLogList<GpsLogData>(value);
                }

                // 그래프에서 선택한 지점을 지도에 루트로 표시
                GMapRoute route = Routing.RouteDrawing(Utils.Routing.GetPointLatLng(list), 6, Color.Aqua, DashStyle.Solid);
                routes.Routes.Add(route);
                gMap.Overlays.Add(routes);
                list.Clear();

                toolTipCount++;

                foreach (DataGridViewRow row in gvGpsActivity.SelectedRows)
                {
                    if (value == CurrentCellValue(gvGpsActivity, row.Index, 22))
                    {
                        RideDetailInfo(row.Index);
                        break;
                    }
                }
            }

            if (IsPolygons)
            {
                GMapMarker currentMarker = item;

                if (currentMarker != null)
                {
                    if (polyOverlay.Polygons.Count > 0)
                    {
                        // 마지막 마커만 삭제 가능
                        if (currentMarker.Position.Lat == listpolyOverlay[listpolyOverlay.Count - 1].Lat &&
                            currentMarker.Position.Lng == listpolyOverlay[listpolyOverlay.Count - 1].Lng)
                        {
                            polyOverlay.Markers.Remove(currentMarker);
                            gMap.Overlays.Remove(currentMarker.Overlay);

                            polyOverlay.Polygons.RemoveAt(polyOverlay.Polygons.Count - 1);
                            listpolyOverlay.RemoveAt(listpolyOverlay.Count - 1);

                            if (listpolyOverlay.Count >= 1)
                            {
                                Distance = 0;

                                // 마커 삭제 후 거리 재계산
                                for (int i = 1; i < listpolyOverlay.Count; i++)
                                {
                                    Distance += calc.Distance(listpolyOverlay[i - 1].Lat, listpolyOverlay[i - 1].Lng, listpolyOverlay[i].Lat, listpolyOverlay[i].Lng);
                                }
                            }
                        }

                        txtGoto.Text = Math.Round(Distance, 1).ToString();
                    }
                    else
                    {
                        polyOverlay.Polygons.Clear();
                        listpolyOverlay.Clear();
                        Distance = 0;
                        txtGoto.Text = "0";
                    }

                    currentMarker = null;
                }
            }
        }

        private void MapOverlaysClear()
        {
            if (gMap.Overlays.Count > 0)
            {
                for (int i = 2; i < gMap.Overlays.Count; i++)
                {
                    gMap.Overlays.RemoveAt(i);
                }
            }

            if (routes != null)
            {
                if (routes.Routes.Count > 0)
                {
                    for (int i = 1; i < routes.Routes.Count; i++)
                    {
                        routes.Routes.RemoveAt(i);
                    }
                }

                if (routes.Markers.Count > 0)
                    routes.Markers.Clear();
            }

            gMap.Refresh();
        }

        /// <summary>
        /// 지도속 위경도 출력 Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblLatLng_MouseUp(object sender, MouseEventArgs e)
        {
            MnuType = "GMap";
        }

        /// <summary>
        /// 마커 툴 팁
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MakerToolTips GetPointsInfo(DataGridViewRow row)
        {
            MakerToolTips resultPointInfo = new MakerToolTips();

            if (!IsFullMap)
            {
                resultPointInfo.RideDate = row.Cells[0].Value.ToString();
                resultPointInfo.StartLat = Convert.ToDouble(row.Cells[23].Value);
                resultPointInfo.StartLng = Convert.ToDouble(row.Cells[24].Value);
                resultPointInfo.EndLat = Convert.ToDouble(row.Cells[25].Value);
                resultPointInfo.EndLng = Convert.ToDouble(row.Cells[26].Value);
            }
            else
            {
                string date = cboDate.SelectedValue.ToString();
            }
            return resultPointInfo;
        }

        #endregion

        #region #차트

        /// <summary>
        /// 라이딩 거리 / 라이딩 시간
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboGraphY_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboGraphX.SelectedIndex;

            if (!splBottom.Panel2Collapsed)
            {
                if (listGpxLog.Count > 0)
                    GetGraphOverlay();
            }
        }

        /// <summary>
        /// 그래프 열기/닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChart_Click(object sender, EventArgs e)
        {
            if (!splBottom.Panel2Collapsed)
            {
                btnChart.Text = "차트열기";
                splBottom.Panel2Collapsed = true;
                chtGpslog.Series.Clear();

                IsLogChart = false;
            }
            else
            {
                btnChart.Text = "차트닫기";
                splBottom.Panel2Collapsed = false;
                splBottom.SplitterDistance = 400;

                GetGraphOverlay();

                IsLogChart = true;

                MnuType = "FullMap";
            }
        }

        /// <summary>
        /// 오버레이(고도)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEle_CheckedChanged(object sender, EventArgs e)
        {
            GetGraphOverlay();
        }

        /// <summary>
        /// 오버레이(속도)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSpeed_CheckedChanged(object sender, EventArgs e)
        {
            GetGraphOverlay();
        }

        /// <summary>
        /// 오버레이(케이던스)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkCad_CheckedChanged(object sender, EventArgs e)
        {
            GetGraphOverlay();
        }

        /// <summary>
        /// 오버레이(온도)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTemp_CheckedChanged(object sender, EventArgs e)
        {
            GetGraphOverlay();
        }

        /// <summary>
        /// 오버레이(심박수)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkHeart_CheckedChanged(object sender, EventArgs e)
        {
            GetGraphOverlay();
        }

        /// <summary>
        /// 오버레이(고도/속도/케이던스/온도/심박수)
        /// </summary>
        public void GetGraphOverlay()
        {
            if (!IsSummary && !splBottom.Panel2Collapsed)
            {
                int index = cboGraphX.SelectedIndex;

                foreach (DataGridViewRow row in gvGpsActivity.SelectedRows)
                {
                    if (gvGpsActivity.SelectedRows.Count == 1 && CurrentCellValue(gvGpsActivity, row.Index, 1) != "Total")
                    {
                        List<double> listCurrentValue = CurrentMaxValue();

                        double maxValue = listCurrentValue[0];
                        double minValue = listCurrentValue[1];

                        if (maxValue > 0 || minValue > 0)
                        {
                            if (IsGpsImportClick)
                                ChartGraph.SplineOverlap(chtGpslog, listMapGraph, CheckListItem(), cboGraphY, 2, false, maxValue, minValue, SeriesChartType.Spline);
                            else
                                ChartGraph.SplineOverlap(chtGpslog, listGpxLog, CheckListItem(), cboGraphY, 2, false, maxValue, minValue, SeriesChartType.Spline);

                            break;
                        }
                        else
                        {
                            chtGpslog.Series.Clear();
                            chtGpslog.ChartAreas.Clear();
                        }
                    }
                    else
                    {
                        chtGpslog.Series.Clear();
                        chtGpslog.ChartAreas.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// 오버레이 채크박스 리스트
        /// </summary>
        /// <returns></returns>
        private List<string> CheckListItem()
        {
            CheckBox[] checks = { chkEle, chkSpeed, chkCad, chkTemp, chkHeart };
            string[] items = { "ELE", "SPEED_KMH", "CAD", "ATEMP", "HEART" };

            List<string> list = new List<string>();

            for (int i = 0; i < checks.Length; i++)
            {
                if (checks[i].Checked)
                    list.Add(items[i]);
            }

            list.Add("DAY_SEQ");

            return list;
        }

        /// <summary>
        /// 선택영역 시작점 지정 및 지도에 루트와 거리 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chtGpslog_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsSummary || IsRePlay)
                return;

            if (e.Button == MouseButtons.Left && chtGpslog.ChartAreas.Count > 0 &&
                IsMapOpen && gMap.Overlays.Count > 0)
            {
                // 불럭 종료점 지정
                SlectionEnd = (int)chtGpslog.ChartAreas[0].CursorX.SelectionEnd;

                List<GpsLogActivity> listactitivy = new List<GpsLogActivity>();
                List<PointLatLng> listLatLng = new List<PointLatLng>();
                List<GpsLogData> listlog = new List<GpsLogData>();

                List<int> listSeq = FromToDaySeq();

                int startDaySeq = listSeq[0];
                int endDaySeq = listSeq[1];

                if (startDaySeq > endDaySeq || startDaySeq <= 0 || endDaySeq <= 0)
                    return;

                string rideDateOrigen = string.Empty;

                if (IsFullMap)
                    rideDateOrigen = cboDate.SelectedValue.ToString();
                else
                {
                    foreach (DataGridViewRow row in gvGpsActivity.SelectedRows)
                    {
                        rideDateOrigen = CurrentCellValue(gvGpsActivity, row.Index, 22);
                    }
                }

                foreach (GpsLogData gld in listGpxLog)
                {
                    if (rideDateOrigen == gld.RIDE_DATE_ORIGEN)
                    {
                        int dayseq = Convert.ToInt32(gld.DAY_SEQ);

                        if (dayseq >= startDaySeq && dayseq <= endDaySeq)
                        {
                            listlog.Add(gld);
                            listLatLng.Add(new PointLatLng(gld.LAT, gld.LNG));
                        }
                    }
                }

                if (listlog.Count <= 1)
                    return;

                // 파싱한 결과를 이용하여 라이딩 정보 추출
                Parser.TotalActivity gpxActivity = new Parser.TotalActivity(listlog);
                listactitivy.Add(gpxActivity.GetActivity(string.Empty));
                listlog.Clear();

                // 그래프에서 선택한 지점을 지도에 루트로 표시
                GMapRoute route = Routing.RouteDrawing(listLatLng, 6, Color.Aqua, DashStyle.Solid);
                routes.Routes.Add(route);
                gMap.Overlays.Add(routes);

                // 거리를 툴팁에 표시
                string toolTip = string.Format("구간거리 : {0}km\n구간속도 : {1}km\n최고고도 : {2}m\n평균고도 : {3}m\n케이던스 : {4}rpm\n심박수 : {5}\n표고차 : {6}m\n경사도 : {7}%",
                    listactitivy[0].DISTANCE, listactitivy[0].AVG_SPEED, listactitivy[0].HIGH_ELE, listactitivy[0].AVG_ELE, listactitivy[0].AVG_CAD, listactitivy[0].AVG_HEART, listactitivy[0].ALTITUDE_GAP, listactitivy[0].GRADE);

                int pCount = listLatLng.Count / 2;
                routes.Markers.Add(Routing.MarkerToolTip(listLatLng[pCount].Lat, listLatLng[pCount].Lng, toolTip,
                    GMarkerGoogleType.green_pushpin, MarkerTooltipMode.Always));

                gMap.ZoomAndCenterRoute(route);
                gMap.Overlays.Add(routes);

                // 최종 지도 위치
                MapPosition(listLatLng, true);

                listactitivy.Clear();
            }

            if (e.Button == MouseButtons.Right)
            {
                if (e.Location.X > 0)
                    SlectionStart = e.Location.X;

                MnuType = "Chart";
            }
        }

        /// <summary>
        /// 로그 Seq 시작과 끝 번호 가져오기
        /// </summary>
        /// <returns></returns>
        public List<int> FromToDaySeq()
        {
            int start = 0;
            int end = 0;
            int sdaySeq = 0;
            int edaySeq = 0;

            if (SlectionStart < SlectionEnd)
            {
                start = SlectionStart;
                end = SlectionEnd;
            }
            else if (SlectionStart > SlectionEnd)
            {
                start = SlectionEnd;
                end = SlectionStart;
            }

            if (start < end && end - start > 3)
            {
                var slat = chtGpslog.Series["DAY_SEQ"].Points[start];
                var elat = chtGpslog.Series["DAY_SEQ"].Points[end - 3];

                sdaySeq = Convert.ToInt32(slat.YValues[0]);
                edaySeq = Convert.ToInt32(elat.YValues[0]);
            }

            List<int> listSeq = new List<int>() { sdaySeq, edaySeq };

            return listSeq;
        }

        /// <summary>
        /// 위경도 검색
        /// </summary>
        /// <returns></returns>
        public List<PointLatLng> SearchLatLng()
        {
            List<PointLatLng> rtnList = new List<PointLatLng>();

            if (listGpxLog != null)
            {
                var latlng = (from item in listGpxLog
                              where Convert.ToInt32(item.DAY_SEQ) == FromToDaySeq()[1] * 3
                              select new
                              {
                                  lat = item.LAT,
                                  lng = item.LNG
                              }).ToList();

                if (latlng.Count > 0)
                    rtnList.Add(new PointLatLng(latlng[0].lat, latlng[0].lng));
                else
                    rtnList.Add(new PointLatLng(37.5513483, 126.9885421)); // 서울 남산
            }
            else
                rtnList.Add(new PointLatLng(37.5513483, 126.9885421)); // 서울 남산

            return rtnList;
        }

        /// <summary>
        /// 그래프 블록 지정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chtGpslog_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsSummary || IsRePlay)
                return;

            if (chtGpslog.ChartAreas.Count > 0)
            {
                if (IsMapOpen)
                {
                    Point mousePoint = new Point(e.X, e.Y);
                    chtGpslog.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);

                    chtGpslog.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                    chtGpslog.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
                    chtGpslog.ChartAreas[0].CursorX.LineWidth = 1;
                    chtGpslog.ChartAreas[0].CursorX.LineColor = Color.HotPink;
                    chtGpslog.ChartAreas[0].CursorX.SelectionColor = Color.HotPink;
                }
                else
                {
                    chtGpslog.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                    chtGpslog.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
                }
            }
        }

        /// <summary>
        /// 차트 블록 지정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chtGpslog_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsSummary || IsRePlay)
                return;

            if (e.Button == MouseButtons.Left && chtGpslog.ChartAreas.Count > 0 && IsMapOpen)
            {
                // 블럭 시작점 지정
                MapOverlaysClear();
                SlectionStart = (int)chtGpslog.ChartAreas[0].CursorX.SelectionStart;
            }
        }

        /// <summary>
        /// 차트 ToolTip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chtGpslog_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    string seriesName = e.HitTestResult.Series.Name;
                    var dataPoint = chtGpslog.Series[seriesName].Points[e.HitTestResult.PointIndex];

                    if (!IsSummary)
                    {
                        string xKey = seriesName;
                        string yKey = ((KeyValuePair<string, string>)cboGraphY.SelectedItem).Key;
                        e.Text = string.Format("{0} : {1}\n{2} : {3}", yKey, dataPoint.AxisLabel, xKey, dataPoint.YValues[0] + (yKey == "속도" ? "km" : string.Empty));
                    }
                    else
                        e.Text = string.Format("{0} : {1}\n{2} : {3}", "기간", dataPoint.AxisLabel, "속도", dataPoint.YValues[0] + "km");

                    break;
            }
        }

        #endregion

        #region #설정

        /// <summary>
        /// 프로그램 설정 팝업(이름, 체중)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            GpsSetting settting = new GpsSetting();

            // 부모폼의 중앙에 위치
            settting.StartPosition = FormStartPosition.CenterParent;
            settting.ShowDialog();
        }

        #endregion

        #region #데이터 그리드 뷰

        string beforeValue = string.Empty;
        /// <summary>
        ///  Activity 정보 선택시 해당 Gpx Log를 조회후 DataGirdView에 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvGpsActivity_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ThreadState();

            if (IsSummary || IsRePlay)
                return;

            if (e.RowIndex > -1)
            {
                string value = CurrentCellValue(gvGpsActivity, e.RowIndex, 22);
                RideDetailInfo(e.RowIndex);

                if (value.Length > 0)
                {
                    // 저장한 Gpslog 데이터 조회
                    if (!IsGpsImportClick && !IsMapOpen)
                    {
                        // 동일 검색 조건 중복 실행 방지
                        if (beforeValue != value)
                        {
                            using (GpsLogDac dac = new GpsLogDac())
                            {
                                listGpxLog = dac.GetLatlng<GpsLogData>(new List<string>() { value });
                                beforeValue = value;
                            }
                        }
                    }
                    else
                    {
                        // 파싱한 Gpslog 데이터 조회
                        IEnumerable<GpsLogData> iGpxLog = listGpxLog.Where(n => n.RIDE_DATE_ORIGEN == value);
                        listMapGraph = iGpxLog.ToList();
                    }

                    DataBindSub(CurrentCellValue(gvGpsActivity, e.RowIndex, 0));
                }
            }
        }

        /// <summary>
        /// DataGirdView Cell 선택하면 Gpx Log 지도에 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvGpsActivity_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ThreadState();

            if (IsSummary || IsRePlay)
            {
                gvGpsActivity.ReadOnly = true;
                return;
            }
            else
            {
                if (EditMode == "Modify")
                {
                    gvGpsActivity.Columns[1].ReadOnly = false;
                    gvGpsActivity.ReadOnly = false;
                    gvGpsActivity.Columns[0].ReadOnly = true;
                    gvGpsActivity.Columns[2].ReadOnly = true;
                }
            }

            if (e.RowIndex > -1 && IsMapOpen)
                MultiGpxLogview();

            // 그래프
            GetGraphOverlay();
        }

        /// <summary>
        /// 라이딩 상세정보
        /// </summary>
        /// <param name="rowIndex"></param>
        private void RideDetailInfo(int rowIndex)
        {
            if (gvGpsActivity.Rows.Count < 0)
                return;

            TextBox[] detailTextBoxs = { txtHighEle, txtLowEle, txtAvgEle, txtDistance, txtSpeed, txtHighSpeed, txtTime, txtElapseTime, txtGrade, txtHighCad,
                                         txtAvgCad, txtHighTemp, txtAvgTemp, txtHighHeart, txtAvgHeart };

            int[] idx = { 7, 8, 9, 2, 6, 5, 3, 4, 30, 12, 14, 15, 17, 18, 20 };

            string[] format = { "m", "m", "m", "km", "km", "km", "", "", "%", "", "", "℃", "℃", "", "" };

            string rideDate = CurrentCellValue(gvGpsActivity, rowIndex, 0);

            if (rideDate == "Total")
            {
                string distance = Math.Round(Convert.ToDouble(CurrentCellValue(gvGpsActivity, rowIndex, 2))).ToString();
                lblDistance.Text = string.Format(" {0} km", Utils.Common.NumberFormat(distance));
                txtDistance.Text = string.Format(" {0} km", Utils.Common.NumberFormat(distance));

                // 합계(거리, 누적오르막, 누적내리막, 칼로리) 표시할 텍스트 박스 외에 초기화
                for (int i = 0; i < textBoxs.Length; i++)
                {
                    if (i != 0 && i != 5 && i != 6 && i != 7)
                    {
                        textBoxs[i].Text = string.Empty;
                    }
                }
            }
            else
            {
                for (int i = 0; i < detailTextBoxs.Length; i++)
                {
                    if (i < 2)
                        detailTextBoxs[i].Text = string.Format(" {0} {1}", Utils.Common.NumberFormat(CurrentCellValue(gvGpsActivity, rowIndex, idx[i])), format[i]);
                    else
                        detailTextBoxs[i].Text = string.Format(" {0} {1}", CurrentCellValue(gvGpsActivity, rowIndex, idx[i]), format[i]);
                }
            }

            lblDistance.Text = string.Format(" {0} km", CurrentCellValue(gvGpsActivity, rowIndex, 2));
            lblAvgSpeed.Text = string.Format(" {0} km", CurrentCellValue(gvGpsActivity, rowIndex, 6));
            lblKcal.Text = string.Format(" {0} kcal", Utils.Common.NumberFormat(CurrentCellValue(gvGpsActivity, rowIndex, 21)));
            lblTime.Text = string.Format(" {0} ", CurrentCellValue(gvGpsActivity, rowIndex, 3));
            lblAscent.Text = string.Format(" {0} m", Utils.Common.NumberFormat(CurrentCellValue(gvGpsActivity, rowIndex, 10)));
            lblTemp.Text = string.Format(" {0} ℃", CurrentCellValue(gvGpsActivity, rowIndex, 17));

            txtKcal.Text = string.Format(" {0} kcal", Utils.Common.NumberFormat(CurrentCellValue(gvGpsActivity, rowIndex, 21)));
            txtAscent.Text = string.Format(" {0} m", Utils.Common.NumberFormat(CurrentCellValue(gvGpsActivity, rowIndex, 10)));
            txtDescent.Text = string.Format(" {0} m", Utils.Common.NumberFormat(CurrentCellValue(gvGpsActivity, rowIndex, 11)));
        }

        /// <summary>
        /// 자전거 라이딩 정보 데이터 그리드 뷰 팝업메뉴(그래프)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvGpsActivity_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { }
        }

        private void gvGpsLog_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { MnuType = "Grid"; }
        }

        #endregion

        #region #팝업

        /// <summary>
        /// 팝업메뉴 : 트랙보기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuTrackView_Click(object sender, EventArgs e)
        {
            if (IsSummary)
                return;

            btnMultiGpsLog_Click(null, null);
        }

        /// <summary>
        /// 재생(경로 따라가기)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuReplay_Click(object sender, EventArgs e)
        {
            if (IsSummary)
                return;

            btnReplay_Click(null, null);
        }

        /// <summary>
        /// 팝업메뉴 : 그래프
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuGraph_Click(object sender, EventArgs e)
        {
            if (IsSummary)
                return;

            if (!IsGpsImportClick)
            {
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm.Name == "GpsGraph")
                    {
                        if (openForm.WindowState == FormWindowState.Minimized)
                        {
                            openForm.WindowState = FormWindowState.Normal;
                            openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                        }

                        openForm.Activate();
                        MessageBox.Show("그래프 창이 실행중입니다.");
                        return;
                    }
                }

                int overlap = 0;

                foreach (DataGridViewRow row in gvGpsActivity.SelectedRows)
                {
                    if (overlap == 0)
                    {
                        string rideDate = CurrentCellValue(gvGpsActivity, row.Index, 1);
                        if (gvGpsActivity.SelectedRows.Count == 1 && (rideDate != "Total" && rideDate != ""))
                        {
                            string value = CurrentCellValue(gvGpsActivity, row.Index, 22);
                            GpsGraph graph = new GpsGraph(value);
                            graph.Show();
                            break;
                        }
                    }

                    overlap++;
                }
            }
            else
            {
                MessageBox.Show("파싱한 데이터 보기는 지원하지 않습니다.", "Gpslog Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// 전체트랙
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuSelectAll_Click(object sender, EventArgs e)
        {
            if (IsSummary)
                return;

            gvGpsActivity.SelectAll();
            btnMultiGpsLog_Click(null, null);
        }

        /// <summary>
        /// 네이버 지도
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mnu1Naver_Click(object sender, EventArgs e)
        {
            PopMenu("N");
        }

        /// <summary>
        /// 다음지도
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mnu1Daum_Click(object sender, EventArgs e)
        {
            PopMenu("D");
        }

        /// <summary>
        /// 구글맵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mnu1Google_Click(object sender, EventArgs e)
        {
            PopMenu("G");
        }

        /// <summary>
        /// Bing Map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mnu1Bing_Click(object sender, EventArgs e)
        {
            // https://msdn.microsoft.com/en-us/library/dn217138.aspx
            PopMenu("B");
        }

        /// <summary>
        /// 자체지도
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuGMap_Click(object sender, EventArgs e)
        {
            MapOverlaysClear();
            if (IsMapOpen)
            {
                if (addressOverlay.Markers.Count > 0)
                    addressOverlay.Markers.Clear();

                if (SearchLatLng().Count < 0)
                    return;

                double lat = Convert.ToDouble(SearchLatLng()[0].Lat);
                double lng = Convert.ToDouble(SearchLatLng()[0].Lng);

                string address = SetData.GetAddress(lat, lng);
                string toolTip = string.Format("주소 : {0}", address);

                addressOverlay.Markers.Add(Routing.MarkerToolTip(lat, lng, toolTip,
                    GMarkerGoogleType.yellow_pushpin, MarkerTooltipMode.Always));

                gMap.Overlays.Add(addressOverlay);
                gMap.ZoomAndCenterMarkers("address");
                gMap.Zoom = 14;
            }
        }

        /// <summary>
        /// 위경도 팝업(다음/네이버 지도)
        /// </summary>
        /// <param name="mnu"></param>
        private void PopMenu(string mnu)
        {
            string lat = string.Empty;
            string lng = string.Empty;
            string url = string.Empty;

            if (MnuType == "Grid")
            {
                foreach (DataGridViewRow row in gvGpsLog.SelectedRows)
                {
                    lat = CurrentCellValue(gvGpsLog, row.Index, 3);
                    lng = CurrentCellValue(gvGpsLog, row.Index, 4);
                }
            }
            else if (MnuType == "GMap")
            {
                lat = gMap.Position.Lat.ToString();
                lng = gMap.Position.Lng.ToString();
            }
            else if (MnuType == "Chart")
            {
                lat = SearchLatLng()[0].Lat.ToString();
                lng = SearchLatLng()[0].Lng.ToString();
            }
            else
            {
                if (IsMapOpen)
                {
                    lat = gMap.Position.Lat.ToString();
                    lng = gMap.Position.Lng.ToString();
                }
            }

            if (mnu == "N")
            {
                if (Convert.ToDouble(lat) > 0 || Convert.ToDouble(lng) > 0)
                    url = string.Format("http://map.naver.com/?menu=route&mapMode=2&lat={0}&lng={1}", lat, lng);
                else
                    url = string.Empty;
            }
            else if (mnu == "D")
            {
                if (Convert.ToDouble(lat) > 0 || Convert.ToDouble(lng) > 0)
                    url = string.Format("http://map.daum.net/link/map/{0},{1}", lat, lng);
                else
                    url = string.Empty;
            }
            else if (mnu == "G")
                url = string.Format("https://www.google.com/maps/place/{0},{1}", lat, lng);
            else if (mnu == "B")
                url = string.Format("http://www.bing.com/maps/default.aspx?cp={0}~{1}", lat, lng);

            if (url != string.Empty)
                Process.Start("chrome.exe", url);
        }

        #endregion

        #region #화면

        /// <summary>
        /// 화면 로딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GpsLogWriter_Load(object sender, EventArgs e)
        {
            List<GpsLogSetting> listInfo = new List<GpsLogSetting>();
            using (GpsLogDac dac = new GpsLogDac())
            {
                listInfo = dac.GetSetting<GpsLogSetting>();
            }

            if (listInfo.Count <= 0)
            {
                MessageBox.Show("프로그램 설정 정보를 등록하세요", "Gpslog Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                GpsSetting settting = new GpsSetting();
                // 부모폼의 중앙에 위치
                settting.StartPosition = FormStartPosition.CenterParent;
                settting.ShowDialog();
            }
        }

        /// <summary>
        /// 종료중에 경로 따라기기(스레드 작업)를 할경우 종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GpsLogWriter_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadState();
        }

        #endregion

        #region #기타

        /// <summary>
        /// 트랙 시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (IsMapOpen)
            {
                if (listRouteTrack.Count == 1)
                {
                    MessageBox.Show("시작지점이 이미 존재합니다.", "Gpslog Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                IsRouteTrack = true;
                IsStartTrack = true;
            }
            else
            {
                MessageBox.Show("지도가 열려 있는지 확인하세요", "Gpslog Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        ///  트랙종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (IsMapOpen)
            {
                if (listRouteTrack.Count == 0)
                {
                    MessageBox.Show("시작지점이 없습니다.", "Gpslog Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                IsRouteTrack = true;
                IsEndTrack = true;
            }
            else
            {
                MessageBox.Show("지도가 열려 있는지 확인하세요", "Gpslog Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// 마커 숨김 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakerBtnVisible_Click(object sender, EventArgs e)
        {
            if (IsMapOpen)
            {
                if (IsMakerVisble)
                {
                    IsMakerVisble = false;
                    btnMakerBtnVisible.Text = "마카보기";
                }
                else
                {
                    IsMakerVisble = true;
                    btnMakerBtnVisible.Text = "마카숨김";
                }

                for (int i = 0; i < gMap.Overlays.Count; i++)
                {
                    if (gMap.Overlays[i].Markers.Count > 0)
                    {
                        for (int j = 0; j < gMap.Overlays[i].Markers.Count; j++)
                        {
                            gMap.Overlays[i].Markers[j].IsVisible = IsMakerVisble;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 서버 연결 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maps = cboManager.SelectedItem.ToString();
            SetData.ServerManager(maps, gMap);
        }

        /// <summary>
        /// 마커 선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maker = cboMaker.SelectedItem.ToString();
            currentMarkerType = SetData.ToMarkerType(maker);
        }

        /// <summary>
        /// 고도 / 속도 / 케이던스 / 심박수 / 온도
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboGraphX_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboGraphX.SelectedIndex;

            if (!splBottom.Panel2Collapsed)
            {
                List<double> listCurrentValue = CurrentMaxValue();

                double maxValue = listCurrentValue[0];
                double minValue = listCurrentValue[1];

                if (maxValue > 0 && minValue > 0)
                {
                    if (IsGpsImportClick)
                        ChartGraph.SplineOverlap(chtGpslog, listMapGraph, CheckListItem(), cboGraphY, 2, false, maxValue, minValue, SeriesChartType.Spline);
                    else
                        ChartGraph.SplineOverlap(chtGpslog, listGpxLog, CheckListItem(), cboGraphY, 2, false, maxValue, minValue, SeriesChartType.Spline);
                }
            }
        }

        /// <summary>
        /// 차트 Max
        /// </summary>
        /// <returns></returns>
        private List<double> CurrentMaxValue()
        {
            double maxEle = 0.0d;
            double minEle = 0.0d;
            double maxCad = 0.0d;
            double maxValue = 0.0d;

            List<double> listMax = new List<double>();
            List<double> listMax2 = new List<double>();

            foreach (DataGridViewRow row in gvGpsActivity.SelectedRows)
            {
                if (!IsFullMap)
                {
                    // 최고속도/최고해발/최고케이던스/최고온도/최고심박수
                    int[] colNum = { 5, 7, 12, 15, 18 };
                    List<string> colName = new List<string>();
                    for (int i = 0; i < colNum.Length; i++)
                    {
                        string value = CurrentCellValue(gvGpsActivity, row.Index, colNum[i]);
                        listMax.Add(value != "" ? Convert.ToDouble(value) : 0);
                    }

                    if (listMax.Count > 0)
                    {
                        foreach (string item in CheckListItem())
                        {
                            int listIndex = 0;

                            switch (item)
                            {
                                case "SPEED_KMH":
                                    listIndex = 0;
                                    break;
                                case "ELE":
                                    listIndex = 1;
                                    break;
                                case "CAD":
                                    listIndex = 2;
                                    break;
                                case "ATEMP":
                                    listIndex = 3;
                                    break;
                                case "HEART":
                                    listIndex = 4;
                                    break;
                                default:
                                    listMax2.Add(listIndex);
                                    break;
                            }

                            listMax2.Add(listMax[listIndex]);
                        }

                        maxValue = listMax2.Max();

                        string value = CurrentCellValue(gvGpsActivity, row.Index, 8);
                        minEle = value != "" ? Convert.ToDouble(value) : 0;
                    }
                    else
                    {
                        maxValue = 0;
                        minEle = 0;
                    }
                }
                else
                {
                    maxEle = Convert.ToDouble(listGpsActivity[0].HIGH_ELE);
                    minEle = Convert.ToDouble(listGpsActivity[0].LOW_ELE);
                    maxCad = Convert.ToDouble(listGpsActivity[0].HIGH_CAD);

                    if (maxEle > maxCad)
                        maxValue = maxEle;
                    else
                        maxValue = maxCad;
                }
            }

            List<double> listValue = new List<double>() { maxValue, minEle };

            return listValue;
        }

        /// <summary>
        /// 테스트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerator<GMapOverlay> o = gMap.Overlays.GetEnumerator();

            List<PointLatLng> listpoints = new List<PointLatLng>();

            while (o.MoveNext())
            {
                var s = o.Current;
                var points = s.Routes.Select(n => n.Points);
                var polygons = s.Polygons.Select(n => n.Points);

                foreach (var p in s.Markers)
                {
                    double lat = p.Position.Lat;
                    double lng = p.Position.Lng;

                    listpoints.Add(new PointLatLng(lat, lng));
                }
            }
        }

        #endregion
    }
}
// 최초업로드
//

//