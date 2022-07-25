using System;
using System.ComponentModel;

namespace GpsLogManager.Field
{
    /// <summary>
    /// 자전거 라이딩 정보 
    /// </summary>
    public class GpsLogActivity
    {
        public GpsLogActivity()
        { }

        public GpsLogActivity(string title, string ridedateOrigen)
        {
            this.TITLE = title;
            this.RIDE_DATE_ORIGEN = ridedateOrigen;
        }

        public string RIDE_DATE { get; set; }
        public string TITLE { get; set; }
        public double DISTANCE { get; set; }
        public string TIME { get; set; }
        public string ELAPSE_TIME { get; set; }
        public double HIGH_SPEED { get; set; }
        public double AVG_SPEED { get; set; }
        public double HIGH_ELE { get; set; }
        public double LOW_ELE { get; set; }
        public double AVG_ELE { get; set; }
        public double TOTAL_ASCENT { get; set; }  // 상승고도
        public double TOTAL_DESCENT { get; set; } // 하강고도
        public double HIGH_CAD { get; set; }
        public double LOW_CAD { get; set; }
        public double AVG_CAD { get; set; }
        public double HIGH_TEMP { get; set; }
        public double LOW_TEMP { get; set; }
        public double AVG_TEMP { get; set; }
        public double HIGH_HEART { get; set; }
        public double LOW_HEART { get; set; }
        public double AVG_HEART { get; set; }
        public double KCAL { get; set; }
        public string RIDE_DATE_ORIGEN { get; set; }
        public double START_LAT {get;set;}
        public double START_LNG { get;set;}
        public double END_LAT {get;set;}
        public double END_LNG { get;set;}
        public string YEAR { get; set; }
        public string MONTH { get; set; }
        public double ALTITUDE_GAP { get; set; }
        public double GRADE { get; set; }

        public string OVERLAP { get; set; } // DB 중복체크
    }
}
