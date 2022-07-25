using System;
using System.Linq;
using System.Collections.Generic;
using GpsLogManager.Field;
using GpsLogManager.Data;

namespace GpsLogManager.Utils
{
    public class GpsLogCalculate
    {
        public GpsLogCalculate()
        {
        }

        #region Distance

        /// <summary>
        /// 거리 계산
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lng1"></param>
        /// <param name="lat2"></param>
        /// <param name="lng2"></param>
        /// <returns></returns>
        public double Distance(double lat1, double lng1, double lat2, double lng2)
        {
            double theta = 0.0d;
            double dist = 0.0d;
            theta = lng1 - lng2;

            dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1))
                         * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515; // statute miles. 단위는 기본 마일.
            dist = dist * 1.609344;

            return dist;
        }

        /// <summary>
        /// 주어진 도(degree) 값을 라디언으로 변환
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        private double deg2rad(double deg)
        {
            if (!double.IsInfinity((double)(deg * (double)180d / Math.PI)))
                return (double)(deg * Math.PI / (double)180d);
            else
                return 0;
        }

        /// <summary>
        /// 주어진 라디언(radian) 값을 도(degree) 값으로 변환
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        private double rad2deg(double rad)
        {
            if (!double.IsInfinity((double)(rad * (double)180d / Math.PI)))
                return (double)(rad * (double)180d / Math.PI);
            else
                return 0;
        }

        /// <summary>
        /// 좌표 생성 시간을 기준으로 속도(km/h) 계산
        /// </summary>
        /// <param name="km"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static double GetKph(double km, string startDate, string endDate)
        {
            double velocity = 0.0d;
            double totalTime = Utils.DateTimeHelper.GetTimeSpan(startDate, endDate).TotalSeconds;

            if (!double.IsInfinity(((km / totalTime) * 3600)))
                velocity = ((km / totalTime) * 3600);

            return velocity;
        }

        #endregion 

        /// <summary>
        /// 자전거 칼로리 공식
        /// </summary>
        /// <param name="weight">몸무게</param>
        /// <param name="minute">운동시간(분)</param>
        /// <param name="kph">평균속도</param>
        /// <returns></returns>
        public static double GetKcal(double totalTime, double kph)
        {
            double minute = totalTime / 60;
            double weight = 0;

            List<GpsLogSetting> listSet = Utils.SetData.GetSetting<GpsLogSetting>();

            if (listSet.Count > 0)
                weight = Convert.ToDouble(listSet[0].WEIGHT);
            else
                weight = 0;

            double kcal = 0.0d;

            if (kph >= 0 && kph <= 13)
                kcal = 0.0650;
            else if (kph >= 14 && kph <= 16)
                kcal = 0.0783;
            else if (kph >= 17 && kph <= 19)
                kcal = 0.0939;
            else if (kph >= 20 && kph <= 22)
                kcal = 0.113;
            else if (kph >= 23 && kph <= 24)
                kcal = 0.124;
            else if (kph >= 25 && kph <= 26)
                kcal = 0.136;
            else if (kph == 27)
                kcal = 0.149;
            else if (kph >= 28 && kph <= 29)
                kcal = 0.163;
            else if (kph >= 30 && kph <= 31)
                kcal = 0.179;
            else if (kph >= 32)
                kcal = 0.196;
            else if (kph >= 33 && kph <= 34)
                kcal = 0.215;
            else if (kph >= 35 && kph <= 37)
                kcal = 0.259;
            else if (kph >= 40)
                kcal = 0.311;

            // 몸무게 x 평균 속도별 칼로리계수 * 분(운동시간)
            double result = Math.Round(weight * kcal * minute);
            result = Utils.Common.NaNValue(result);
            return result;
        }

        /// <summary>
        /// Max, Min, Average
        /// </summary>
        /// <param name="list"></param>
        /// <param name="r"></param>
        /// <param name="isDistinct"></param>
        /// <returns></returns>
        public static List<double> GetMaxMinAverage(List<double> list, bool isRound, bool isDistinct)
        {
            IEnumerable<double> iTemporarily = isDistinct ? list.Distinct() : list;
            List<double> listResult = null;

            if (iTemporarily.ToList().Count > 0)
            {
                double high = isRound ? Math.Round(iTemporarily.Max(), 1) : Math.Round(iTemporarily.Max());
                double low = isRound ? Math.Round(iTemporarily.Min(), 1) : Math.Round(iTemporarily.Min());
                double avg = isRound ? Math.Round(list.Sum() / list.Count, 1) : Math.Ceiling(list.Sum() / list.Count);

                listResult = new List<double> { high, low, avg };
            }
            else
                listResult = new List<double> { 0, 0, 0 };

            return listResult;
        }

        /// <summary>
        /// 누적 오르막/내리막
        /// </summary>
        /// <param name="listGpslog"></param>
        /// <returns></returns>
        public static List<double> GetAscentDescent(List<GpsLogData> listGpslog)
        {
            double threashold = 2.5d;
            double eLast = listGpslog[0].ELE;
            double totalAscent = 0;
            double totalDescent = 0;

            for (int i = 1; i < listGpslog.Count; i++)
            {
                double elevation = listGpslog[i].ELE;
                if (eLast > elevation + threashold)
                {
                    totalDescent += (eLast - elevation);
                    eLast = elevation;
                }
                else if (eLast < elevation - threashold)
                {
                    totalAscent += (elevation - eLast);
                    eLast = elevation;
                }
            }

            List<double> listElevations = new List<double>() { totalAscent, totalDescent };
            return listElevations;
        }

        /// <summary>
        /// 경사도
        /// </summary>
        /// <param name="gap">표고차</param>
        /// <param name="distance">거리</param>
        /// <returns></returns>
        public static double Grade(double gap, double distance)
        {
            double rtnGrade = 0.0;

            rtnGrade = Math.Round(gap / Math.Sqrt((distance * 1000) * (distance * 1000) - (gap * gap)) * 100, 2);

            return Common.NaNValue(rtnGrade);
        }

        /// <summary>
        /// 최고/최저/평균 속도
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Double> CompletedSpeed(List<GpsLogData> list, string type)
        {
            List<double> rtnKph = new List<double>();

            if (list.Count > 0)
            {
                rtnKph = GetMaxMinAverage(list
                        .Where(n => n.SPEED_KMH >= (type == "total" ? 7 : 3) && n.SPEED_KMH <= 50)
                        .Select(n => n.SPEED_KMH).ToList(), true, false);
            }
            else
                rtnKph = new List<double> { 0, 0, 0 };

            return rtnKph;
        }
    }
}