using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GpsLogManager.Data;
using GpsLogManager.Field;

namespace GpsLogManager.Utils
{
    public class SetData
    {
        private GpsLogDac dac = null;

        public SetData()
        {
            dac = new GpsLogDac();
        }

        #region Google

        /// <summary>
        /// 구글 지도에서 주소 구하기
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
        public static string GetAddress(double lat, double lng)
        {
            GeoCoderStatusCode status;
            var pos = GMapProviders.GoogleMap.GetPlacemark(new PointLatLng(lat, lng), out status);

            string address = string.Empty;
            if (status == GeoCoderStatusCode.G_GEO_SUCCESS && pos != null)
            {
                address = string.Format("{0}", pos.Value.Address);
            }

            return address;
        }

        /// <summary>
        /// 검색조건
        /// </summary>
        /// <returns></returns>
        public static List<string> SearchType()
        {
            List<string> listSearchType = new List<string>()
            {
                "전체", "연도별", "월별", "일별", "오버레이",
            };

            return listSearchType;
        }

        /// <summary>
        /// 지도 선택
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="gMap"></param>
        /// <returns></returns>
        public static GMapControl MapProvider(String maps, GMapControl gMap)
        {
            switch (maps)
            {
                case "구글 지도":
                    gMap.MapProvider = GoogleMapProvider.Instance;
                    break;
                case "구글 위성사진":
                    gMap.MapProvider = GoogleSatelliteMapProvider.Instance;
                    break;
                case "구글 지형도":
                    gMap.MapProvider = GoogleTerrainMapProvider.Instance;
                    break;
                case "구글 하이브리드":
                    gMap.MapProvider = GoogleHybridMapProvider.Instance;
                    break;
                case "오픈 스트리트 맵":
                    gMap.MapProvider = OpenStreetMapProvider.Instance;
                    break;
                case "빙 지도":
                    gMap.MapProvider = BingMapProvider.Instance;
                    break;
                case "빙 위성사진":
                    gMap.MapProvider = BingSatelliteMapProvider.Instance;
                    break;
                case "빙 하이브리드":
                    gMap.MapProvider = BingHybridMapProvider.Instance;
                    break;
                default:
                    break;

                    //case "Google Map":
                    //    gMap.MapProvider = GoogleMapProvider.Instance;
                    //    break;
                    //case "Google Satellite":
                    //    gMap.MapProvider = GoogleSatelliteMapProvider.Instance;
                    //    break;
                    //case "Google Terrain":
                    //    gMap.MapProvider = GoogleTerrainMapProvider.Instance;
                    //    break;
                    //case "Google Hibrid Map":
                    //    gMap.MapProvider = GoogleHybridMapProvider.Instance;
                    //    break;
                    //case "Google Korea Hybrid Map":
                    //    gMap.MapProvider = GoogleKoreaHybridMapProvider.Instance;
                    //    break;
                    //case "Google China Map":
                    //    gMap.MapProvider = GoogleChinaMapProvider.Instance;
                    //    break;
                    //case "Ovi Map":
                    //    gMap.MapProvider = OviMapProvider.Instance;
                    //    break;
                    //case "Ovi Satellite":
                    //    gMap.MapProvider =OviTerrainMapProvider.Instance;
                    //    break;
                    //case "Ovi Terrain":
                    //    gMap.MapProvider =OviTerrainMapProvider.Instance;
                    //    break;
                    //case "Ovi Hibrid Map":
                    //    gMap.MapProvider =OviHybridMapProvider.Instance;
                    //    break;
                    //case "Open Street Map":
                    //    gMap.MapProvider =OpenStreetMapProvider.Instance;
                    //    break;
                    //case "Bing Map":
                    //    gMap.MapProvider =BingMapProvider.Instance;
                    //    break;
                    //case "Bing Satellite":
                    //    gMap.MapProvider =BingSatelliteMapProvider.Instance;
                    //    break;
                    //case "Bing Hibrid Map":
                    //    gMap.MapProvider =BingHybridMapProvider.Instance;
                    //    break;
                    //case "Yahoo Map":
                    //    gMap.MapProvider =YahooMapProvider.Instance;
                    //    break;
                    //case "Yahoo Satellite":
                    //    gMap.MapProvider =YahooSatelliteMapProvider.Instance;
                    //    break;
                    //case "Yahoo Hibrid Ma":
                    //    gMap.MapProvider =YahooHybridMapProvider.Instance;
                    //    break;
                    //default:
                    //    break;
            }

            return gMap;
        }

        /// <summary>
        /// 지도 가져오는 방법
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="gMap"></param>
        /// <returns></returns>
        public static GMapControl ServerManager(String maps, GMapControl gMap)
        {
            switch (maps)
            {
                case "ServerOnly":
                    gMap.Manager.Mode = AccessMode.ServerOnly;
                    break;
                case "CacheOnly":
                    gMap.Manager.Mode = AccessMode.CacheOnly;
                    break;
                case "ServerAndCache":
                    gMap.Manager.Mode = AccessMode.ServerAndCache;
                    break;
                default:
                    break;
            }

            return gMap;
        }

        /// <summary>
        /// 지도 목록
        /// </summary>
        /// <returns></returns>
        public static List<string> MapProviderList()
        {
            List<string> listProvider = new List<string>()
            {
                //    "Google Map"
                //,   "Google Satellite"
                //,   "Google Terrain"
                //,   "Google Hibrid Map"
                //,   "Google Korea Hybrid Map"
                //,   "Google China Map"
                //,   "Ovi Map"
                //,   "Ovi Satellite"
                //,   "Ovi Terrain"
                //,   "Ovi Hibrid Map"
                //,   "Open Street Map"
                //,   "Bing Map"
                //,   "Bing Satellite"
                //,   "Bing Hibrid Map"
                //,   "Yahoo Map"
                //,   "Yahoo Satellite"
                //,   "Yahoo Hibrid Ma"

                    "구글 지도"
                ,   "구글 위성사진"
                ,   "구글 지형도"
                ,   "구글 하이브리드"
                ,   "오픈 스트리트 맵"
                ,   "빙 지도"
                ,   "빙 위성사진"
                ,   "빙 하이브리드"
            };

            return listProvider;
        }

        /// <summary>
        ///  서버 
        /// </summary>
        /// <returns></returns>
        public static List<string> ServerManagerList()
        {
            List<string> listManager = new List<string>()
            {
                "ServerOnly", "CacheOnly", "ServerAndCache"
            };

            return listManager;
        }

        /// <summary>
        /// 마커 선택
        /// </summary>
        /// <param name="maker"></param>
        /// <returns></returns>
        public static GMarkerGoogleType ToMarkerType(string maker)
        {
            GMarkerGoogleType currentMarkerType = GMarkerGoogleType.blue;

            switch (maker)
            {
                case "arrow":
                    currentMarkerType = GMarkerGoogleType.arrow;
                    break;
                case "black_small":
                    currentMarkerType = GMarkerGoogleType.black_small;
                    break;
                case "blue":
                    currentMarkerType = GMarkerGoogleType.blue;
                    break;
                case "blue_dot":
                    currentMarkerType = GMarkerGoogleType.blue_dot;
                    break;
                case "blue_pushpin":
                    currentMarkerType = GMarkerGoogleType.blue_pushpin;
                    break;
                case "blue_small":
                    currentMarkerType = GMarkerGoogleType.blue_small;
                    break;
                case "brown_small":
                    currentMarkerType = GMarkerGoogleType.brown_small;
                    break;
                case "gray_small":
                    currentMarkerType = GMarkerGoogleType.gray_small;
                    break;
                case "green":
                    currentMarkerType = GMarkerGoogleType.green;
                    break;
                case "green_big_go":
                    currentMarkerType = GMarkerGoogleType.green_big_go;
                    break;
                case "green_dot":
                    currentMarkerType = GMarkerGoogleType.green_dot;
                    break;
                case "green_pushpin":
                    currentMarkerType = GMarkerGoogleType.green_pushpin;
                    break;
                case "green_small":
                    currentMarkerType = GMarkerGoogleType.green_small;
                    break;
                case "lightblue":
                    currentMarkerType = GMarkerGoogleType.lightblue;
                    break;
                case "lightblue_dot":
                    currentMarkerType = GMarkerGoogleType.lightblue_dot;
                    break;
                case "lightblue_pushpin":
                    currentMarkerType = GMarkerGoogleType.lightblue_pushpin;
                    break;
                case "orange":
                    currentMarkerType = GMarkerGoogleType.orange;
                    break;
                case "orange_dot":
                    currentMarkerType = GMarkerGoogleType.orange_dot;
                    break;
                case "orange_small":
                    currentMarkerType = GMarkerGoogleType.orange_small;
                    break;
                case "pink":
                    currentMarkerType = GMarkerGoogleType.pink;
                    break;
                case "pink_dot":
                    currentMarkerType = GMarkerGoogleType.pink_dot;
                    break;
                case "pink_pushpin":
                    currentMarkerType = GMarkerGoogleType.pink_pushpin;
                    break;
                case "purple":
                    currentMarkerType = GMarkerGoogleType.purple;
                    break;
                case "purple_dot":
                    currentMarkerType = GMarkerGoogleType.purple_dot;
                    break;
                case "purple_pushpin":
                    currentMarkerType = GMarkerGoogleType.purple_pushpin;
                    break;
                case "purple_small":
                    currentMarkerType = GMarkerGoogleType.purple_small;
                    break;
                case "red":
                    currentMarkerType = GMarkerGoogleType.red;
                    break;
                case "red_dot":
                    currentMarkerType = GMarkerGoogleType.red_dot;
                    break;
                case "red_pushpin":
                    currentMarkerType = GMarkerGoogleType.red_pushpin;
                    break;
                case "red_small":
                    currentMarkerType = GMarkerGoogleType.red_small;
                    break;
                case "white_small":
                    currentMarkerType = GMarkerGoogleType.white_small;
                    break;
                case "yellow":
                    currentMarkerType = GMarkerGoogleType.yellow;
                    break;
                case "yellow_big_pause":
                    currentMarkerType = GMarkerGoogleType.yellow_big_pause;
                    break;
                case "yellow_dot":
                    currentMarkerType = GMarkerGoogleType.yellow_dot;
                    break;
                case "yellow_pushpin":
                    currentMarkerType = GMarkerGoogleType.yellow_pushpin;
                    break;
                case "yellow_small":
                    currentMarkerType = GMarkerGoogleType.yellow_small;
                    break;
                default:
                    currentMarkerType = GMarkerGoogleType.pink;
                    break;
            }

            return currentMarkerType;
        }

        /// <summary>
        ///  마커 스타일
        /// </summary>
        /// <returns></returns>
        public static List<string> ToMarkerTypeList()
        {
            List<string> listMarker = new List<string>()
            {
                "arrow",
                "black_small",
                "blue",
                "blue_dot",
                "blue_pushpin",
                "blue_small",
                "brown_small",
                "gray_small",
                "green",
                "green_big_go",
                "green_dot",
                "green_pushpin",
                "green_small",
                "lightblue",
                "lightblue_dot",
                "lightblue_pushpin",
                "orange",
                "orange_dot",
                "orange_small",
                "pink",
                "pink_dot",
                "pink_pushpin",
                "purple",
                "purple_dot",
                "purple_pushpin",
                "purple_small",
                "red",
                "red_dot",
                "red_pushpin",
                "red_small",
                "white_small",
                "yellow",
                "yellow_big_pause",
                "yellow_dot",
                "yellow_pushpin",
                "yellow_small"
        };

            return listMarker;
        }

        /// <summary>
        /// Gpslog 조회 건수 설정
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GpsLogRowCount()
        {
            Dictionary<string, string> dicRowCount = new Dictionary<string, string>()
            {
                 { "100", "101" },{ "500", "501" }, { "1000", "1001" },{ "2000", "2001" },{ "3000",  "3001" },{ "전체", "100000000" }
            };

            return dicRowCount;
        }

        /// <summary>
        ///  GPS X축 정보
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GpsGraphX()
        {
            Dictionary<string, string> dicGraphX = new Dictionary<string, string>()
            {
                 { "고도", "ELE" },{ "속도", "SPEED_KMH" }, { "CAD", "CAD" },{ "심박", "HEART" },{ "온도", "ATEMP" }, { "오버레이", "OVERLAY" }
            };

            return dicGraphX;
        }

        /// <summary>
        ///  GPS Y축 정보
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GpsGraphY()
        {
            Dictionary<string, string> dicGraphY = new Dictionary<string, string>()
            {
                 { "거리", "KM" },{ "시간", "DIFF_TIME" }
            };

            return dicGraphY;
        }

        /// <summary>
        /// Gpslog 좌표 생성 시간 Utc, Local 시간 변경
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> UtcLocal()
        {
            Dictionary<string, string> dicUtcToLocal = new Dictionary<string, string>()
            {
                  { "좌표 생성 시간", "NORMAL" },{ "UTC 시간", "UTC" },{ "LOCAL 시간", "LOCAL" }
            };

            return dicUtcToLocal;
        }

        public static ComboBox SetComBoBox(ComboBox cbo, Dictionary<string, string> list)
        {
            cbo.DataSource = new BindingSource(list, null);
            cbo.DisplayMember = "key";
            cbo.ValueMember = "value";

            ComboBox rtnCbo = cbo;

            return rtnCbo;
        }

        /// <summary>
        /// 설정정보
        /// </summary>
        /// <returns></returns>
        public static List<T> GetSetting<T>()
        {
            List<T> listSetting = new List<T>();

            using (Data.GpsLogDac dac = new Data.GpsLogDac())
            {
                listSetting = dac.GetSetting<T>();

                return listSetting;
            }

            #endregion
        }
    }
}
