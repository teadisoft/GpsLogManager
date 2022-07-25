using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GpsLogManager.Field;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Globalization;

namespace GpsLogManager.Utils
{
    public class Routing
    {
        /// <summary>
        /// 지도에 Route 표시
        /// </summary>
        /// <param name="listPoints"></param>
        /// <param name="stroke"></param>
        /// <param name="color"></param>
        /// <param name="dashStyle"></param>
        /// <returns></returns>
        public static GMapRoute RouteDrawing(List<PointLatLng> listPoints, int stroke, Color color, System.Drawing.Drawing2D.DashStyle dashStyle)
        {
            GMapRoute rt = new GMapRoute(listPoints, string.Empty);
            {
                rt.Stroke = new Pen(Color.FromArgb(144, color));
                rt.Stroke.Width = stroke;
                rt.Stroke.DashStyle = dashStyle;

                return rt;
            }
        }

        /// <summary>
        /// 지도에 표시할 Gpx Log(위경도 자표)
        /// </summary>
        /// <param name="dt"></param>
        //public void GetPointLatLng(DataTable dt)
        public static List<PointLatLng> GetPointLatLng(DataTable dt)
        {
            List<PointLatLng> tempPoints = new List<PointLatLng>();

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    var query =
                            from p in dt.AsEnumerable().Distinct()
                            orderby p.Field<String>("LOG_TIME")
                            select new
                            {
                                lat = p.Field<double>("LAT"),
                                lng = p.Field<double>("LNG")
                            };

                    foreach (var p in query)
                    {
                        tempPoints.Add(new PointLatLng(p.lat, p.lng));
                    }
                }
            }

            return tempPoints;
        }

        /// <summary>
        /// 지도에 표시할 Gpx Log(위경도 자표)
        /// </summary>
        /// <param name="iGpsLog"></param>
        /// <returns></returns>
        public static List<PointLatLng> GetPointLatLng(IEnumerable<GpsLogData> iGpsLog)
        {
            List<PointLatLng> tempPoints = new List<PointLatLng>();

            if (iGpsLog != null)
            {
                if (iGpsLog.ToList().Count > 0)
                {
                    var query =
                            (from p in iGpsLog.AsEnumerable().Distinct()
                            orderby p.LOG_TIME, p.DAY_SEQ
                            select new PointLatLng
                            {
                                Lat = p.LAT,
                                Lng = p.LNG
                            }).ToList();

                    tempPoints = query;
                }
            }

            return tempPoints;
        }

        /// <summary>
        /// GpsLog 지도에 표시후 지도 위치
        /// </summary>
        /// <param name="arrayPoints"></param>
        /// <returns></returns>
        public static PointLatLng GetAverageLatLng(ArrayList arrayPoints)
        {
            List<PointLatLng> tempPoint = new List<PointLatLng>();

            List<double> listLat = new List<double>();
            List<double> listLng = new List<double>();

            for (int iPoint = 0; iPoint < arrayPoints.Count; iPoint++)
            {
                List<PointLatLng> listPoints = arrayPoints[iPoint] as List<PointLatLng>;

                foreach (PointLatLng point in listPoints)
                {
                    listLat.Add(point.Lat);
                    listLng.Add(point.Lng);
                }
            }

            PointLatLng resultPoint = new PointLatLng(listLat.Average(), listLng.Average());
            return resultPoint;
        }

        /// <summary>
        /// 마커 툴팁
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="tooltip"></param>
        /// <param name="currentMarkerType"></param>
        /// <returns></returns>
        public static GMarkerGoogle MarkerToolTip(double lat, double lng, string tooltip, GMarkerGoogleType currentMarkerType, MarkerTooltipMode tooltipMode)
        {
            GMarkerGoogle maker = new GMarkerGoogle(new PointLatLng(lat, lng), currentMarkerType)
            {
                ToolTipText = tooltip,
                ToolTipMode = tooltipMode
            };
            return maker;
        }

        /// <summary>
        /// 마커 툴팁
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="tooltip"></param>
        /// <returns></returns>
        public static GMarkerGoogle MarkerToolTip(double lat, double lng, string tooltip)
        {
            GMarkerGoogle maker = new GMarkerGoogle(new PointLatLng(lat, lng), null)
            {
                ToolTipText = tooltip,
                ToolTipMode = MarkerTooltipMode.OnMouseOver,
            };
            return maker;
        }

        /// <summary>
        /// 에디터에서 만든 파일에 LOG_TIME 부여
        /// </summary>
        /// <param name="logSeq"></param>
        /// <returns></returns>
        public static string GetNewLogDate(string logSeq)
        {
            int len = logSeq.Length;

            string now = DateTimeHelper.GetDateTimeNow().Substring(0, 19);
            string format = string.Empty;

            switch (len)
            {
                case 1: format = "{0} 000{1}"; break;
                case 2: format = "{0} 00{1}"; break;
                case 3: format = "{0} 0{1}"; break;
                case 4: format = "{0} {1}"; break;
            }

            return string.Format(format, now, logSeq);
        }

        /// <summary>
        // 고도 검색
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
        public static double GetElevation(double lat, double lng)
        {
            double value = 0.0d;

            try
            {
                //https://developers.google.com/maps/documentation/elevation/intro
                var request = (HttpWebRequest)WebRequest.Create(string.Format("https://maps.googleapis.com/maps/api/elevation/json?locations={0},{1}", lat, lng));

                var response = (HttpWebResponse)request.GetResponse();
                var sr = new StreamReader(response.GetResponseStream() ?? new MemoryStream()).ReadToEnd();

                var json = JObject.Parse(sr);

                if (json.SelectToken("results[0].elevation") != null)
                    value = (double)json.SelectToken("results[0].elevation");
                else
                    value = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return value;
        }

        /// <summary>
        /// exports gps data to gpx file
        /// </summary>
        /// <param name="log">gps data</param>
        /// <param name="gpxFile">file to export</param>
        /// <returns>true if success</returns>
        public bool ExportGPX(IEnumerable<List<GpsLog>> log, string gpxFile)
        {
            try
            {
                gpxType gpx = new gpxType();
                {
                    gpx.creator = "GMap.NET - http://greatmaps.codeplex.com";
                    gpx.trk = new trkType[1];
                    gpx.trk[0] = new trkType();
                }

                var sessions = new List<List<GpsLog>>(log);
                gpx.trk[0].trkseg = new trksegType[sessions.Count];

                int sesid = 0;

                foreach (var session in sessions)
                {
                    trksegType seg = new trksegType();
                    {
                        seg.trkpt = new wptType[session.Count];
                    }
                    gpx.trk[0].trkseg[sesid++] = seg;

                    for (int i = 0; i < session.Count; i++)
                    {
                        var point = session[i];

                        wptType t = new wptType();
                        {
                            #region -- set values --
                            t.lat = new decimal(point.Position.Lat);
                            t.lon = new decimal(point.Position.Lng);

                            t.time = point.TimeUTC;
                            t.timeSpecified = true;

                            if (point.FixType != FixType.Unknown)
                            {
                                t.fix = (point.FixType == FixType.XyD ? fixType.Item2d : fixType.Item3d);
                                t.fixSpecified = true;
                            }

                            if (point.SeaLevelAltitude.HasValue)
                            {
                                t.ele = new decimal(point.SeaLevelAltitude.Value);
                                t.eleSpecified = true;
                            }

                            if (point.EllipsoidAltitude.HasValue)
                            {
                                t.geoidheight = new decimal(point.EllipsoidAltitude.Value);
                                t.geoidheightSpecified = true;
                            }

                            if (point.VerticalDilutionOfPrecision.HasValue)
                            {
                                t.vdopSpecified = true;
                                t.vdop = new decimal(point.VerticalDilutionOfPrecision.Value);
                            }

                            if (point.HorizontalDilutionOfPrecision.HasValue)
                            {
                                t.hdopSpecified = true;
                                t.hdop = new decimal(point.HorizontalDilutionOfPrecision.Value);
                            }

                            if (point.PositionDilutionOfPrecision.HasValue)
                            {
                                t.pdopSpecified = true;
                                t.pdop = new decimal(point.PositionDilutionOfPrecision.Value);
                            }

                            if (point.SatelliteCount.HasValue)
                            {
                                t.sat = point.SatelliteCount.Value.ToString();
                            }
                            #endregion
                        }
                        seg.trkpt[i] = t;
                    }
                }
                sessions.Clear();

#if !PocketPC
                File.WriteAllText(gpxFile, SerializeGPX(gpx), Encoding.UTF8);
#else
            using(StreamWriter w = File.CreateText(gpxFile))
            {
               w.Write(SerializeGPX(gpx));
               w.Close();
            }
#endif
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExportGPX: " + ex.ToString());
                return false;
            }
            return true;
        }

        public string SerializeGPX(gpxType targetInstance)
        {
            string retVal = string.Empty;
            using (StringWriterExt writer = new StringWriterExt(CultureInfo.InvariantCulture))
            {
                XmlSerializer serializer = new XmlSerializer(targetInstance.GetType());
                serializer.Serialize(writer, targetInstance);
                retVal = writer.ToString();
            }
            return retVal;
        }

    }
}
