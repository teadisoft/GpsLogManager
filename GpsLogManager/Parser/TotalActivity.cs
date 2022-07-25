using System;
using System.Linq;
using GpsLogManager.Field;
using GpsLogManager.Utils;
using System.Collections.Generic;
using GpsLogManager.Data;

namespace GpsLogManager.Parser
{
    public class TotalActivity
    {
        public List<GpsLogData> ListGpxLog { get; set; }

        public TotalActivity(List<GpsLogData> listGpxLog)
        {
            this.ListGpxLog = listGpxLog;
        }

        public TotalActivity() { }

        /// <summary>
        /// 자전거 라이딩 정보 
        /// </summary>
        /// <returns></returns>
        public GpsLogActivity GetActivity(string type)
        {
            GpsLogActivity actitity = new GpsLogActivity();
            List<double> listEle = GpsLogCalculate.GetMaxMinAverage(ListGpxLog.Select(n => n.ELE).ToList(), false, true);

            actitity.TITLE = ListGpxLog[0].TITLE;
            actitity.RIDE_DATE = ListGpxLog[0].RIDE_DATE;
            actitity.HIGH_ELE = listEle[0];
            actitity.LOW_ELE = listEle[1];
            actitity.AVG_ELE = listEle[2];
            actitity.RIDE_DATE_ORIGEN = ListGpxLog[0].RIDE_DATE_ORIGEN;

            // 순수 라이딩 시간(시속 3km이상 합계)
            var totalTime = (from r in ListGpxLog where r.SPEED_KMH > 3 select r.DIFF_TIME).Sum();

            actitity.TIME = DateTimeHelper.GetTimeFormat(TimeSpan.FromSeconds(totalTime), DateTimeHelper.TimeFormat.HH_MM_SS);
            actitity.ELAPSE_TIME = DateTimeHelper.GetDateTimeCalc(ListGpxLog[0].LOG_TIME, ListGpxLog[ListGpxLog.Count - 1].LOG_TIME);

            if (totalTime > 0)
                actitity.DISTANCE = Math.Round(ListGpxLog.Where(n => n.SPEED_KMH > 3).Select(n => n.KM).Sum(), 1);
            else // 에디터에서 임의로 생성한 로그
                actitity.DISTANCE = Math.Round(ListGpxLog.Select(n => n.KM).Sum(), 1);

            // 라이딩 시간이 없으면 Gps log 파일을 에디터에서 임의 생성한 
            // 것으로 간주하여 속도, 케이던스, 온도 등의 계산을 패스한다.
            if (totalTime > 0)
            {
                List<double> listKph = GpsLogCalculate.CompletedSpeed(ListGpxLog, type);
                List<double> listCadence = GpsLogCalculate.GetMaxMinAverage(ListGpxLog.Where(n=>n.CAD > 0).Select(n => n.CAD).ToList(), false, true);
                List<double> listTemp = GpsLogCalculate.GetMaxMinAverage(ListGpxLog.Select(n => n.ATEMP).ToList(), true, true);
                List<double> listHeart = GpsLogCalculate.GetMaxMinAverage(ListGpxLog.Select(n => n.HEART).ToList(), false, true);


                // 속도
                actitity.HIGH_SPEED = listKph[0];
                actitity.AVG_SPEED = listKph[2];

                // 케이던스
                actitity.HIGH_CAD = listCadence[0];
                actitity.LOW_CAD = listCadence[1];
                actitity.AVG_CAD = listCadence[2];

                // 온도
                actitity.HIGH_TEMP = listTemp[0];
                actitity.LOW_TEMP = listTemp[1];
                actitity.AVG_TEMP = listTemp[2];

                // 심박수
                actitity.HIGH_HEART = listHeart[0];
                actitity.LOW_HEART = listHeart[1];
                actitity.AVG_HEART = listHeart[2];

                // 칼로리
                actitity.KCAL = GpsLogCalculate.GetKcal(totalTime, Math.Round(listKph[2]));
            }

            // 트랙의 처음과 마지막 위경도 좌표
            actitity.START_LAT = ListGpxLog[0].LAT;
            actitity.START_LNG = ListGpxLog[0].LNG;
            actitity.END_LAT = ListGpxLog[ListGpxLog.Count - 1].LAT;
            actitity.END_LNG = ListGpxLog[ListGpxLog.Count - 1].LNG;

            List<double> listTotalEle = GpsLogCalculate.GetAscentDescent(ListGpxLog);

            // 누적오르막/누적내리막 (소수점 버림)
            actitity.TOTAL_ASCENT = Math.Truncate(listTotalEle[0]); 
            actitity.TOTAL_DESCENT = Math.Truncate(listTotalEle[1]);

            actitity.YEAR = ListGpxLog[0].RIDE_DATE_ORIGEN.Substring(0, 4);
            actitity.MONTH = ListGpxLog[0].RIDE_DATE_ORIGEN.Substring(0, 7);

            // Total : 전체거리 / "" : 구간거리
            if (type == "Total")
                actitity.ALTITUDE_GAP = Math.Round(listEle[0] - ListGpxLog[0].ELE, 1);
            else
                actitity.ALTITUDE_GAP = Math.Truncate(ListGpxLog[ListGpxLog.Count - 1].ELE - ListGpxLog[0].ELE);

            actitity.GRADE = GpsLogCalculate.Grade(actitity.ALTITUDE_GAP, actitity.DISTANCE);
            actitity.OVERLAP = ListGpxLog[0].OVERLAP;

            return actitity;
        }
    }
}
