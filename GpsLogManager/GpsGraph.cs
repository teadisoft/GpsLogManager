using GMap.NET;
using GMap.NET.WindowsForms;
using GpsLogManager.Data;
using GpsLogManager.Field;
using GpsLogManager.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GpsLogManager
{
    public partial class GpsGraph : Form
    {
        private int RIndex = 0;

        /// <summary>
        /// 라이딩 날짜 정보
        /// </summary>
        private List<RideInfo> listRideDate = null;

        /// <summary>
        /// 기본 지도 
        /// </summary>
        private GMapOverlay routes;

        Setting config = null;

        private List<PointLatLng> listPoints = null;
        private string RideDate { get; set; }
        private string KeyX { get; set; }
        private List<GpsLogData> listGpxLog = null;

        private List<GpsLogActivity> listGpsActivity = null;

        public GpsGraph() { }

        /// <summary>
        /// 그래프 뷰어
        /// </summary>
        /// <param name="rideDate"></param>
        public GpsGraph(string rideDate)
        {
            InitializeComponent();

            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMap.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMap.DragButton = MouseButtons.Left; 

            gMap.MinZoom = 0;
            gMap.MaxZoom = 19;
            gMap.Zoom = 5;

            this.RideDate = rideDate;

            cboGraphY.DataSource = new BindingSource(Utils.SetData.GpsGraphY(), null);
            cboGraphY.DisplayMember = "key";
            cboGraphY.ValueMember = "value";

            cboMapProvider.DataSource = SetData.MapProviderList();

            GetRideDate();

            var index = listRideDate.FindIndex(r => r.RIDE_DATE == RideDate);
            RIndex = index;

            GetGpsLog();
            ChartView();

            config = new Setting();
        }

        /// <summary>
        /// 차트 바인딩
        /// </summary>
        public void ChartView()
        {
            if (listGpsActivity != null && listGpsActivity.Count > 0)
            {
                chtEle.Series.Clear();
                chtSpeed.Series.Clear();
                chtCad.Series.Clear();
                chtHeart.Series.Clear();
                chtTemp.Series.Clear();

                gMap.Overlays.Clear();
                gMap.Refresh();

                routes = new GMapOverlay("routes");

                lblTitle.Text = listGpsActivity[0].RIDE_DATE + " / " + listGpsActivity[0].TITLE;

                lblDistance.Text = "이동거리 : " + listGpsActivity[0].DISTANCE + " km";
                lbltime.Text = "시      간 : " + listGpsActivity[0].TIME;
                lblAvgSpeed.Text = "평균속도 : " + listGpsActivity[0].AVG_SPEED + " kph";

                lblHighEle.Text = "누적오르막 : " + Utils.Common.NumberFormat(listGpsActivity[0].TOTAL_ASCENT.ToString()) + " m";
                lblLowEle.Text = "최고해발 : " + Utils.Common.NumberFormat(listGpsActivity[0].HIGH_ELE.ToString()) + " m";

                lblHighCad.Text = "최고 CAD : " + listGpsActivity[0].HIGH_CAD;
                lblAvgCad.Text = "평균 CAD : " + listGpsActivity[0].AVG_CAD;

                lblHighHR.Text = "최고심박수 : " + listGpsActivity[0].HIGH_HEART;
                lblAvgHR.Text = "평균심박수 : " + listGpsActivity[0].AVG_HEART;

                lblKcal.Text = "칼 로 리 : " + Utils.Common.NumberFormat(listGpsActivity[0].KCAL.ToString()) + " kcal";


                listPoints = new List<PointLatLng>();
                foreach (GpsLogData gpslog in listGpxLog)
                {
                    listPoints.Add(new PointLatLng(gpslog.LAT, gpslog.LNG));
                }

                GMapRoute route = Routing.RouteDrawing(listPoints, 3, Color.Red, DashStyle.Solid);

                routes.Routes.Add(route);
                gMap.ZoomAndCenterRoute(route);
                gMap.Overlays.Add(routes);

                double pLat = listPoints.Average(n => n.Lat);
                double pLng = listPoints.Average(n => n.Lng);
                gMap.Position = new PointLatLng(pLat, pLng);

                // 시간/거리
                string keyY = ((KeyValuePair<string, string>)cboGraphY.SelectedItem).Key;

                string[] item = { "ELE", "SPEED_KMH", "CAD", "ATEMP", "HEART" };

                Chart[] chart = { chtEle, chtSpeed, chtCad, chtTemp, chtHeart };

                for (int i = 0; i < chart.Length; i++)
                {
                    List<string> list = new List<string>() { item[i] };
                    ChartGraph.SplineOverlap(chart[i], listGpxLog, list, cboGraphY, 2, true, 0, 0, SeriesChartType.SplineArea);
                }
            }
        }

        /// <summary>
        /// 거리/시간 (그래프 X축)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboGraphY_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartView();
        }

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
        /// 다음 Gpslog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
               if (RIndex < listRideDate.Count - 1)
            {
                RIndex += 1;
                RideDate = listRideDate[RIndex].RIDE_DATE_ORIGEN;

                GetGpsLog();
                ChartView();
            }
        }

        /// <summary>
        /// 이전 Gpslog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (RIndex > 0)
            {
                RIndex -= 1;
                RideDate = listRideDate[RIndex].RIDE_DATE_ORIGEN;

                GetGpsLog();
                ChartView();
            }
        }

        /// <summary>
        /// Gps 정보 조회
        /// </summary>
        public void GetGpsLog()
        {
            // 선택된 Row에서 키값(자전거 라이딩 시작시간)
            List<string> listrideDateOrigen = new List<string>() { RideDate };
            listGpsActivity = new List<GpsLogActivity>();

            using (GpsLogDac dac = new GpsLogDac())
            {
                listGpsActivity = dac.GetGpsActivityList<GpsLogActivity>(RideDate);
            }

            using (GpsLogDac dac = new GpsLogDac())
            {
                listGpxLog = dac.GetLatlng<GpsLogData>(listrideDateOrigen);
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
                listRideDate = dac.GetGpsLogList<RideInfo>().OrderBy(n => n.RIDE_DATE).ToList();
            }
        }

        /// <summary>
        /// 온도/심박
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkVisible_CheckedChanged(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();

            if (chkVisible.Checked)
                IsChart(true);
            else
                IsChart(false);
        }

        public void IsChart(bool isChart)
        {
            if (isChart)
            {
                chkVisible.Checked = true;
                chtTemp.Visible = true;
                chtHeart.Visible = false;
            }
            else
            {
                chkVisible.Checked = false;
                chtTemp.Visible = false;
                chtHeart.Visible = true;
            }
        }

        private void btnGpxSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "GPX (*.gpx)|*.gpx";
                    sfd.FileName = "mobile gps log";

                    DateTime? date = null;
                    DateTime? dateEnd = null;



                    if (listGpxLog != null)
                    {
                        sfd.FileName = listGpxLog[0].TITLE;

                       

                        date = Convert.ToDateTime(listGpxLog[0].LOG_TIME_ORIGEN);
                      
                        dateEnd = Convert.ToDateTime(listGpxLog[listGpxLog.Count-1].LOG_TIME_ORIGEN);

                        //MainMap.Manager.ExportGPX(log, sfd.FileName
                    }

                    //if (MobileLogFrom.Checked)
                    //{
                    //    date = MobileLogFrom.Value.ToUniversalTime();

                    //    sfd.FileName += " from " + MobileLogFrom.Value.ToString("yyyy-MM-dd HH-mm");
                    //}



                    //if (MobileLogTo.Checked)
                    //{
                    //    dateEnd = MobileLogTo.Value.ToUniversalTime();

                    //    sfd.FileName += " to " + MobileLogTo.Value.ToString("yyyy-MM-dd HH-mm");
                    //}

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                    //    var log = Stuff.GetRoutesFromMobileLog(mobileGpsLog, date, dateEnd, 3.3);
                    //    if (log != null)
                    //    {
                    //        if (MainMap.Manager.ExportGPX(log, sfd.FileName))
                    //        {
                    //            MessageBox.Show("GPX saved: " + sfd.FileName, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        }
                    //    }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GPX failed to save: " + ex.Message, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
