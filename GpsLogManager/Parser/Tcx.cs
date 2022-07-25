using System;
using System.Collections.Generic;
using GpsLogManager.Field;
using System.Xml;

namespace GpsLogManager.Parser
{
    public class TcxPaser
    {
        List<GpsLogData> listTcxLog = null;

        public string FileName { get; set; }

        public TcxPaser(string fileName)
        {
            this.FileName = fileName;
        }

        public List<GpsLogData> Paser(List<RideInfo> listRideDate)
        {
            listTcxLog = new List<GpsLogData>();

            XmlDocument xml = new XmlDocument();
            xml.Load(FileName);

            string rideDateOrigen = string.Empty;
            XmlNodeList actNodelist = xml.GetElementsByTagName("Activity");
            foreach (XmlNode node in actNodelist)
            {
                rideDateOrigen = node.ChildNodes[0].InnerText;
            }

             XmlNodeList nodes = xml.GetElementsByTagName("Trackpoint");

            foreach (XmlNode node in nodes)
            {
                GpsLogData tcxlog = new GpsLogData();

                tcxlog.RIDE_DATE_ORIGEN = rideDateOrigen;
                tcxlog.RIDE_DATE = rideDateOrigen.Substring(0, 10);
                tcxlog.LOG_TIME = node["Time"].InnerText.Substring(0, 19).Replace("T", " ");
                tcxlog.LOG_TIME_ORIGEN = node["Time"].InnerText;

                if (node["Position"] != null)
                {
                    tcxlog.LAT = Convert.ToDouble(node["Position"].ChildNodes[0].InnerText);
                    tcxlog.LNG = Convert.ToDouble(node["Position"].ChildNodes[1].InnerText);
                }
                else
                {
                    tcxlog.LAT = 0;
                    tcxlog.LNG = 0;
                }
             
                tcxlog.ELE = Convert.ToDouble(node["AltitudeMeters"].InnerText);
                //tcxlog.KM = Convert.ToDouble(node["DistanceMeters"].InnerText);
                tcxlog.SPEED_KMH = Convert.ToDouble(node["Extensions"].ChildNodes[0].InnerText);

                listTcxLog.Add(tcxlog);
            }

            return listTcxLog;
        }
    }
}
