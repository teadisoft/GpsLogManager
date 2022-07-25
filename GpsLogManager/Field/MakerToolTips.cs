using System;

namespace GpsLogManager.Field
{
    /// <summary>
    ///  마커 툴 팁
    /// </summary>
    public class MakerToolTips
    {
        public double StartLat { get; set; }
        public double StartLng{ get; set; }
        public double EndLat { get; set; }
        public double EndLng { get; set; }
        public string Distance { get; set; }
        public string Title { get; set; }
        public string RideDate { get; set; }
        public string StartDate { get; set; }
        public string Time { get; set; }
        public string AvgSpeed { get; set; }
    }
}
