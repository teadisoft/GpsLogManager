using System;
using System.Collections.Generic;
using System.Globalization;

namespace GpsLogManager.Utils
{
    public class DateTimeHelper
    {
        public enum TimeFormat
        {
            HH,
            HH_MM,
            HH_MM_SS,
            HH_MM_SS_MS,
            HHHH_MM_SS_MS
        }

        /// <summary>
        /// Time Format Enum
        /// </summary>
        public enum DateFormat
        {
            /// <summary>
            /// Local to UTC yyyy-MM-dd hh:mm:ss
            /// </summary>
            CONVERT_LOCAL_TO_UTC,

            /// <summary>
            /// UTC to LOCAL yyyyy-MM-dd hh:mm:ss
            /// </summary>
            CONVERT_UTC_TO_LOCAL,

            /// <summary>
            /// NOMAL(변경없음) yyyy-MM-dd hh:mm:ss
            /// </summary>
            CONVERT_NOMAL
        }

        /// <summary>
        /// Enum 값에 따라 시간 포맷을 리턴
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="timeFormat"></param>
        /// <returns></returns>
        public static string GetTimeFormat(TimeSpan ts, TimeFormat timeFormat)
        {
            string result = string.Empty;

            switch (timeFormat)
            {
                case TimeFormat.HH:
                    result = string.Format("{0:00}", ts.Hours);
                    break;
                case TimeFormat.HH_MM:
                    result = string.Format("{0:00}:{1:00}", ts.Hours, ts.Minutes);
                    break;
                case TimeFormat.HH_MM_SS:
                    result = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
                    break;
                case TimeFormat.HH_MM_SS_MS:
                    result = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    break;
                case TimeFormat.HHHH_MM_SS_MS:
                    result = string.Format("{0:0000}:{1:00}:{2:00}", ts.TotalHours, ts.Minutes, ts.Seconds);
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 시간 계산
        /// </summary>
        /// <param name="startDate">시작시간</param>
        /// <param name="endDate">종료시간</param>
        /// <returns></returns>
        public static string GetDateTimeCalc(string startDate, string endDate)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(startDate) && !string.IsNullOrWhiteSpace(endDate))
                result = GetTimeFormat(GetTimeSpan(startDate, endDate), TimeFormat.HH_MM_SS);
            else
                result = "00:00:00";
            return result;
        }

        /// <summary>
        /// 시간 간격
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static TimeSpan GetTimeSpan(string startDate, string endDate)
        {
            DateTime StartDate = Convert.ToDateTime(startDate.Substring(0, 19));
            DateTime EndDate = Convert.ToDateTime(endDate.Substring(0, 19));

            TimeSpan ts = EndDate - StartDate;

            return ts;
        }

        /// <summary>
        /// 현재시간 리턴
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeNow()
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff");
            return now;
        }

        /// <summary>
        /// Utc <-> Local 변경
        /// </summary>
        /// <param name="df"></param>
        /// <param name="time"></param>
        /// <param name="timeType"></param>
        /// <param name="daySeq"></param>
        /// <returns></returns>
        public static string ConvertTimeTotime(DateFormat df, string time, string timeType, int daySeq)
        {
            string rtnTime = string.Empty;

            if (!string.IsNullOrWhiteSpace(time))
            {
                int year    = Convert.ToInt32(time.Substring(0, 4));   
                int month   = Convert.ToInt32(time.Substring(5, 2));   
                int day     = Convert.ToInt32(time.Substring(8, 2));   
                int hour    = Convert.ToInt32(time.Substring(11, 2));  
                int min     = Convert.ToInt32(time.Substring(14, 2));  
                int second  = Convert.ToInt32(time.Substring(17, 2));  

                DateTime date = new DateTime(year, month, day, hour, min, second);

                switch (df)
                {
                    case DateFormat.CONVERT_LOCAL_TO_UTC: // Local to UTC yyyy-MM-dd hh:mm:ss
                        rtnTime = TimeZoneInfo.ConvertTimeToUtc(date).ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                    case DateFormat.CONVERT_UTC_TO_LOCAL: // UTC to Local yyyy-MM-dd hh:mm:ss
                        rtnTime = TimeZone.CurrentTimeZone.ToLocalTime(date).ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                    case DateFormat.CONVERT_NOMAL: // NOMAL yyyyMMdd hhmmss
                        rtnTime = date.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                }
                if (timeType == "R")
                    rtnTime = rtnTime.Replace(" ", "T") + time.Substring(19);
                else if (timeType == "L")
                    rtnTime = rtnTime.Replace("T", " ").Substring(0, 19);
            }
            else
            {
                if (timeType == "R")
                    rtnTime = GetDateTimeNow();
                else if (timeType == "L")
                    rtnTime = Routing.GetNewLogDate(daySeq.ToString());
            }

            return rtnTime;
        }

        /// <summary>
        /// 이번주 시작일과 마지막날
        /// </summary>
        /// <returns></returns>
        //public static string GetCrrrentWeekDay(string day)
        //{
        //    string rtnWeekDay = string.Empty;
        //    System.Globalization.CultureInfo current = System.Threading.Thread.CurrentThread.CurrentCulture;

        //    //DateTime toDay = DateTime.Now.AddDays(dayCount);
        //    DateTime toDay = Convert.ToDateTime(day);

        //    DayOfWeek dwFirst = current.DateTimeFormat.FirstDayOfWeek;
        //    DayOfWeek dwToday = current.Calendar.GetDayOfWeek(toDay);

        //    int iDiff = dwToday - dwFirst;
        //    DateTime dtFirstDayofThisWeek = toDay.AddDays(-iDiff +1);
        //    DateTime dtLastDayofThisWeek = dtFirstDayofThisWeek.AddDays(6);

        //    rtnWeekDay = string.Format("{0}~{1}", dtFirstDayofThisWeek.ToString("yyyy-MM-dd"), dtLastDayofThisWeek.ToString("yyyy-MM-dd"));

        //    return rtnWeekDay;
        //}

        /// <summary>
        /// 이번주 시작일과 마지막날
        /// </summary>
        /// <returns></returns>
        public static string GetWeekDay(string day)
        {
            string rtnWeekDay = string.Empty;
            string firstDay = string.Empty;
            string lastDay = string.Empty;

            DateTime dt = Convert.ToDateTime(day);

            switch (WeekDayNum(day))
            {
                case 1:
                    firstDay = day;
                    lastDay = dt.AddDays(6).ToString("yyyy-MM-dd");
                    break;
                case 2:
                    firstDay = dt.AddDays(-1).ToString("yyyy-MM-dd");
                    lastDay = dt.AddDays(5).ToString("yyyy-MM-dd");
                    break;
                case 3:
                    firstDay = dt.AddDays(-2).ToString("yyyy-MM-dd");
                    lastDay = dt.AddDays(4).ToString("yyyy-MM-dd");
                    break;
                case 4:
                    firstDay = dt.AddDays(-3).ToString("yyyy-MM-dd");
                    lastDay = dt.AddDays(3).ToString("yyyy-MM-dd");
                    break;
                case 5:
                    firstDay = dt.AddDays(-4).ToString("yyyy-MM-dd");
                    lastDay = dt.AddDays(2).ToString("yyyy-MM-dd");
                    break;
                case 6:
                    firstDay = dt.AddDays(-5).ToString("yyyy-MM-dd");
                    lastDay = dt.AddDays(1).ToString("yyyy-MM-dd");
                    break;
                case 7:
                    firstDay = dt.AddDays(-6).ToString("yyyy-MM-dd");
                    lastDay = dt.AddDays(0).ToString("yyyy-MM-dd");
                    break;
            }

            rtnWeekDay = string.Format("{0}~{1}", firstDay, lastDay);
            return rtnWeekDay;
        }

        public static List<string> BetweenDay(string startDay, string EndDay)
        {
            List<string> listDay = new List<string>();

            DateTime fromDt = DateTime.Parse(startDay);
            DateTime toDt = DateTime.Parse(EndDay);

            int duration = DayCount(fromDt, toDt);

            for (int i = 0; i <= duration; i++)
            {
                listDay.Add(fromDt.AddDays(i).ToString("yyyy-MM-dd"));
            }

            return listDay;
        }

        static int DayCount(DateTime fromDt, DateTime ToDt)
        {
            TimeSpan ts = ToDt - fromDt;
            return ts.Days;
        }

        public static string WeekDay(string day)
        {
            string rtnWeekday = string.Empty;

            if (day.Equals("Total"))
                return "";

            DayOfWeek dt = Convert.ToDateTime(day).DayOfWeek;

            switch (dt)
            {
                case DayOfWeek.Monday: //월
                    rtnWeekday = "월";
                    break;

                case DayOfWeek.Tuesday: //화
                    rtnWeekday = "화";
                    break;

                case DayOfWeek.Wednesday: //수
                    rtnWeekday = "수";
                    break;

                case DayOfWeek.Thursday: //목
                    rtnWeekday = "목";
                    break;

                case DayOfWeek.Friday: //금
                    rtnWeekday = "금";
                    break;

                case DayOfWeek.Saturday: //토
                    rtnWeekday = "토";
                    break;

                case DayOfWeek.Sunday: //일
                    rtnWeekday = "일";
                    break;
            }

            return rtnWeekday;
        }

        public static int WeekDayNum(string day)
        {
            int rtnNum = 0;

            DayOfWeek dt = Convert.ToDateTime(day).DayOfWeek;

            switch (dt)
            {
                case DayOfWeek.Monday: //월
                    rtnNum = 1;
                    break;

                case DayOfWeek.Tuesday: //화
                    rtnNum = 2;
                    break;

                case DayOfWeek.Wednesday: //수
                    rtnNum = 3;
                    break;

                case DayOfWeek.Thursday: //목
                    rtnNum = 4;
                    break;

                case DayOfWeek.Friday: //금
                    rtnNum = 5;
                    break;

                case DayOfWeek.Saturday: //토
                    rtnNum = 6;
                    break;

                case DayOfWeek.Sunday: //일
                    rtnNum = 7;
                    break;
            }

            return rtnNum;
        }

        //현재일이 포함된 년중 주와 현재달의 첫째날의 년중 주를 구하여 차로서 해당일의 월간 주간을 알아낼수 있다.
        public static int GetCurrentWeekOfMonth(string date)
        {
            CultureInfo culture = new CultureInfo("ko-KR");

            // now = DateTime.Now;
            DateTime firstDayOfMonth = Convert.ToDateTime(date);
            int firstWeekOfMonth = GetWeekOfYear(firstDayOfMonth, culture);
            int nowWeekOfMonth = GetWeekOfYear(Convert.ToDateTime(date), culture);

            return (nowWeekOfMonth - firstWeekOfMonth) + 1;
        }

        public static int GetWeekOfYear(DateTime targetDate)
        {
            return GetWeekOfYear(targetDate, null);
        }

        // 주어진 날짜가 1년 중 몇 번째 주(week)인가를 반환한다.
        // 달력 규칙은 매개변수로 주어진 CultureInfo를 사용한다.
        public static int GetWeekOfYear(DateTime targetDate, CultureInfo culture)
        {
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }
            CalendarWeekRule weekRule = culture.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
            return culture.Calendar.GetWeekOfYear(targetDate, weekRule, firstDayOfWeek);
        }

        /// <summary>
        /// 달의 일요일만 추출
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<string> getWeekdatesandDates(string date)
        {
            List<string> weekdays = new List<string>();

            string[] dates = date.Split('-');

            int year = Convert.ToInt32(dates[0]);
            int month = Convert.ToInt32(dates[1]);

            DateTime firstOfMonth = new DateTime(year, month, 1);

            DateTime currentDay = firstOfMonth;
            while (firstOfMonth.Month == currentDay.Month)
            {
                DayOfWeek dayOfWeek = currentDay.DayOfWeek;
                if (dayOfWeek == DayOfWeek.Sunday)
                    weekdays.Add(currentDay.Date.ToString("yyyy-MM-dd"));

                currentDay = currentDay.AddDays(1);
            }

            return weekdays;
        }
    }
}
