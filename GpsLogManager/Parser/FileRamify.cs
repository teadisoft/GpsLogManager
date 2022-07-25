using System;
using System.Collections.Generic;
using GpsLogManager.Field;

namespace GpsLogManager.Parser
{
    public class FileRamify
    {
        /// <summary>
        /// 파일명
        /// </summary>
        public string FileName { get; set; }
        public string TimeType { get; set; }
        
        public FileRamify(string fileName, string timeType)
        {
            this.FileName = fileName;
            this.TimeType = timeType;
        }

        /// <summary>
        /// 파일 분기
        /// </summary>
        /// <returns></returns>
        public List<GpsLogData> Ramiify(List<RideInfo> listRideDate)
        {
            List<GpsLogData> TempGpxLog = new List<GpsLogData>();

            switch (GetFileExtension())
            {
                case "gpx":
                    GpxPaser gpxPaser = new GpxPaser(FileName, TimeType);
                    TempGpxLog = gpxPaser.Paser(listRideDate);
                    break;
                case "tcx":
                    TcxPaser tcxPaser = new TcxPaser(FileName);
                    TempGpxLog = tcxPaser.Paser(listRideDate);
                    break;
                case "kml":
                    KmlPaser kmlPaser = new KmlPaser(FileName);
                    break;
                case "kmz":
                    KmzPaser kmzPaser = new KmzPaser(FileName);
                    break;
            }

            return TempGpxLog;
        }

        /// <summary>
        /// 파일 확장자 추출(gpx, tcx, kml, kmz)
        /// </summary>
        /// <returns></returns>
        public string GetFileExtension()
        {
            return System.IO.Path.GetExtension(FileName).Replace(".", "");
        }
    }
}
