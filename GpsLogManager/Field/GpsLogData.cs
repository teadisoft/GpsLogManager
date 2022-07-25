using System;

namespace GpsLogManager.Field
{
    /// <summary>
    /// gpslog 클래스
    /// </summary>
    public class GpsLogData
    {
        public GpsLogData() { }

        public GpsLogData(string title, double lat, double lng, double ele) 
        {
            this.TITLE = title;
            this.LAT = lat;
            this.LNG = lng;
            this.ELE = ele;
        }

        public string DAY_SEQ { get; set; }
        public string RIDE_DATE { get; set; }
        public string TITLE { get; set; }
        public double LAT { get; set; }
        public double LNG { get; set; }
        public double ELE { get; set; }
        public double SPEED_KMH { get; set; }
        public double KM { get; set; }
        public double DIFF_TIME { get; set; }
        public string LOG_TIME { get; set; }
        public string LOG_TIME_ORIGEN { get; set; }
        public double ATEMP { get; set; }
        public double CAD { get; set; }
        public double HEART { get; set; }
        public string RIDE_DATE_ORIGEN { get; set; }
        public string WAYPOINT { get; set; }

        public string OVERLAP { get; set; }  // DB 중복체크
    }
}
