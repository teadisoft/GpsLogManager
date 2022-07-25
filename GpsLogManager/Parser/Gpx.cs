using System;
using System.Collections.Generic;
using System.Xml;
using GpsLogManager.Field;
using GpsLogManager.Utils;

namespace GpsLogManager.Parser
{
    /// <summary>
    ///  *.gpx 파일 파싱
    /// </summary>
    public class GpxPaser
    {
        List<GpsLogData> listGpxLog = null;

        public string FileName { get; set; }
        public string TimeType { get; set; }

        public GpxPaser(string fileName, string timeType)
        {
            this.FileName = fileName;
            this.TimeType = timeType;

            listGpxLog = new List<GpsLogData>();
        }

        /// <summary>
        /// Gpx 데이터 파싱
        /// </summary>
        /// <param name="listRideDate"></param>
        /// <returns></returns>
        public List<GpsLogData> Paser(List<RideInfo> listRideDate)
        {
            DateTimeHelper.DateFormat dateformat = DateTimeHelper.DateFormat.CONVERT_NOMAL;

            switch (TimeType)
            {
                case "UTC":
                    dateformat = DateTimeHelper.DateFormat.CONVERT_LOCAL_TO_UTC;
                    break;
                case "LOCAL":
                    dateformat = DateTimeHelper.DateFormat.CONVERT_UTC_TO_LOCAL;
                    break;
                case "NOMAL":
                    dateformat = DateTimeHelper.DateFormat.CONVERT_NOMAL;
                    break;
            }

            XmlDocument xml = new XmlDocument();
            xml.Load(FileName);

            string utcTime = string.Empty;
            string localTime = string.Empty;

            string rideDateOrigen = string.Empty;
            string overlap = string.Empty; 
            XmlNodeList metaNodes = xml.GetElementsByTagName("metadata");

            if (metaNodes.Count > 0)
            {
                foreach (XmlNode node in metaNodes)
                {
                    utcTime = node["time"] != null ? node["time"].InnerText.ToString() : string.Empty;
                    rideDateOrigen = DateTimeHelper.ConvertTimeTotime(dateformat, utcTime, "R", 0);
                }
            }
            else
            {
                XmlNodeList time = xml.GetElementsByTagName("time");
                utcTime = time[0].InnerText;
                rideDateOrigen = DateTimeHelper.ConvertTimeTotime(dateformat, utcTime, "R", 0);
            }

            // 중복체크
            foreach (RideInfo day in listRideDate)
            {
                if (day.RIDE_DATE_ORIGEN == rideDateOrigen)
                {
                    overlap = "Y";
                    break;
                }
            }

            string name = string.Empty;
            XmlNodeList trkNode = xml.GetElementsByTagName("trk");
            foreach (XmlNode node in trkNode)
            {
                name = node["name"] != null ? node["name"].InnerText : string.Empty;
            }

            var nsmgr = new XmlNamespaceManager(xml.NameTable);

            // Path 검색을 위한 NameSpace 설정
            nsmgr.AddNamespace("i", "http://www.topografix.com/GPX/1/1");
            nsmgr.AddNamespace("gpxtpx", "http://www.garmin.com/xmlschemas/TrackPointExtension/v1");

            XmlNodeList nodes = xml.SelectNodes("//i:trkpt", nsmgr);

            if (nodes.Count == 0)
                nodes = xml.GetElementsByTagName("trkpt");

            // log No
            int daySeq = 0;
            foreach (XmlNode node in nodes)
            {
                daySeq++;

                GpsLogCalculate gpsCalc = new GpsLogCalculate();
                GpsLogData log = new GpsLogData();

                log.TITLE = name;
                log.RIDE_DATE = rideDateOrigen.Substring(0, 10);
                log.LAT = Convert.ToDouble(node.Attributes["lat"].Value);
                log.LNG = Convert.ToDouble(node.Attributes["lon"].Value);
                log.ELE = node["ele"] != null ? Math.Round(Convert.ToDouble(node["ele"].InnerText), 1) : 0;
                log.RIDE_DATE_ORIGEN = rideDateOrigen;

                utcTime = node["time"] != null ? node["time"].InnerText : string.Empty;
                localTime = DateTimeHelper.ConvertTimeTotime(dateformat, utcTime, "L", daySeq);
                log.LOG_TIME_ORIGEN = localTime;
                log.LOG_TIME = utcTime != string.Empty ? localTime.Substring(0, 19) : localTime;

                string gpxtx = "i:extensions/gpxtpx:TrackPointExtension/gpxtpx:{0}";

                // 기온 : Xml Path 
                var atemp = node.SelectSingleNode(string.Format(gpxtx, "atemp"), nsmgr);
                log.ATEMP = atemp != null ? Convert.ToDouble(atemp.InnerText) : 0;

                // 케이던스 : Xml Path 
                var cad = node.SelectSingleNode(string.Format(gpxtx, "cad"), nsmgr);
                log.CAD = cad != null ? Convert.ToDouble(cad.InnerText) : 0;

                // 심박수 : Xml Path 
                var heart = node.SelectSingleNode(string.Format(gpxtx, "hr"), nsmgr);
                log.HEART = heart != null ? Convert.ToDouble(heart.InnerText) : 0;

                // 좌표간 거리, 속도 계산
                if (listGpxLog.Count >= 1)
                {
                    // row Count
                    int iCount = listGpxLog.Count - 1;

                    // 좌표 위경도
                    double lat = listGpxLog[iCount].LAT;
                    double lng = listGpxLog[iCount].LNG;

                    // 좌표간 로그 시작시간과 끝시간
                    string startDate = listGpxLog[iCount].LOG_TIME;
                    string endDate = log.LOG_TIME;

                    // 좌표간 거리계산
                    double km = gpsCalc.Distance(lat, lng, log.LAT, log.LNG);

                    // 거리
                    log.KM = Utils.Common.NaNValue(km);

                    if (startDate != string.Empty && endDate != string.Empty)
                    {
                        // 좌표 A=>B까지 속도(km/h)
                        log.SPEED_KMH = Math.Round((km > 0 ? GpsLogCalculate.GetKph(km, startDate, endDate) : 0), 1);

                        // 좌표 A=>B까지 시간                    
                        log.DIFF_TIME = DateTimeHelper.GetTimeSpan(startDate, endDate).Seconds;
                    }
                    else
                    {
                        log.SPEED_KMH = 0;
                        log.DIFF_TIME = 0;
                    }
                }

                log.DAY_SEQ = daySeq.ToString();
                log.OVERLAP = overlap;   // DB 중복체크

                if(log.SPEED_KMH <= 300)
                    listGpxLog.Add(log);

                log = null;
            }

            // Way Point
            XmlNodeList wptNodes = xml.GetElementsByTagName("wpt");

            if (wptNodes.Count > 0)
            {
                int wptSeq = 0;

                foreach (XmlNode wpt in wptNodes)
                {
                    GpsLogData wp = new GpsLogData();

                    wptSeq++;

                    wp.LAT = Convert.ToDouble(wpt.Attributes["lat"].Value);
                    wp.LNG = Convert.ToDouble(wpt.Attributes["lon"].Value);
                    wp.ELE = wpt["ele"] != null ? Convert.ToDouble(wpt["ele"].InnerText) : 0;
                    wp.TITLE = wpt["name"].InnerText;
                    wp.RIDE_DATE_ORIGEN = rideDateOrigen;
                    wp.WAYPOINT = "Y";
                    wp.DAY_SEQ = wptSeq.ToString();

                    listGpxLog.Add(wp);
                }
            }

            return listGpxLog;
        }
    }
}
