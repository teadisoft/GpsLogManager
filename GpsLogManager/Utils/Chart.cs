using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GpsLogManager.Field;

namespace GpsLogManager.Utils
{
    public class ChartGraph
    {
        public ChartGraph() { }

        /// <summary>
        /// 선 그래프
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="dt"></param>
        /// <param name="listGraph"></param>
        /// <returns></returns>
        public static Chart Spline(Chart chart, DataTable dt, List<string> listGraph)
        {
            chart.Series.Clear();

            double maxValueY = Convert.ToDouble(dt.Compute(string.Format("max({0})", listGraph[1].ToString()), string.Empty));
            double minValueY = Convert.ToDouble(dt.Compute(string.Format("min({0})", listGraph[1].ToString()), string.Empty));

            chart.ChartAreas[0].AxisY.Maximum = GetMaxValue(maxValueY, "");
            chart.ChartAreas[0].AxisY.Minimum = minValueY < 0 ? -30 : 0;
            chart.ChartAreas[0].AxisX.Interval = 0;

            // 고도 / 속도 / 케이던스 / 온도
            string keyX = listGraph[0].ToString();

            // 시간 / 거리
            string keyY = listGraph[2].ToString();

            string chartTitle = string.Format("{0} / {1}", keyX, keyY);
            Series series = chart.Series.Add(chartTitle);
            series.ChartType = SeriesChartType.SplineArea;
            chart.Series[chartTitle].IsVisibleInLegend = false;

            double totalValue = 0;
            foreach (DataRow dr in dt.Rows)
            {
                double speed = Convert.ToDouble(dr["SPEED_KMH"].ToString());

                // ELE / SPEED_KMH / CAD / ATEMP
                double valueX = Convert.ToDouble(dr[listGraph[1].ToString()].ToString());

                // DIFF_TIME / KM
                double valueY = Convert.ToDouble(dr[listGraph[3].ToString()].ToString());

                // 평속 3k 이상만 계산
                if (speed >= 3 && speed <= 75)
                    totalValue += Utils.Common.NaNValue(valueY);

                // 임의로 생성한 Gps 로그 파일
                else if (speed == 0 && dr["LOG_TIME_ORIGEN"].ToString().Length > 19)
                    totalValue += Utils.Common.NaNValue(valueY);

                SetAddXY(chart, totalValue, valueX, keyY, chartTitle);
            }

            return chart;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="dt"></param>
        /// <param name="items"></param>
        /// <param name="cboGraphY"></param>
        /// <returns></returns>
        public static Chart SplineOverlap(Chart chart, List<GpsLogData> listGpxLog, List<string> items, ComboBox cboGraphY, int area, bool isVisibleInLegend, double maxValue, double minValue, SeriesChartType seriesChartType)
        {
            chart.ChartAreas.Clear();
            chart.Series.Clear();

            string keyY = ((KeyValuePair<string, string>)cboGraphY.SelectedItem).Key;
            string valueY = ((KeyValuePair<string, string>)cboGraphY.SelectedItem).Value;

            if (area == 2)
                chart.ChartAreas.Add("AREA1");

            if (items.Contains("DAY_SEQ"))
            {
                chart.ChartAreas["AREA1"].AxisY.Maximum = GetMaxValue(maxValue, "");
                chart.ChartAreas["AREA1"].AxisY.Minimum = minValue < 0 ? -30 : 0;
                chart.ChartAreas["AREA1"].AxisX.Interval = 0;
            }

            for (int i = 0; i < items.Count; i++)
            {
                if (area == 1)
                    chart.ChartAreas.Add("AREA" + i.ToString());

                double totalValue = 0.0d;
                string item = items[i];
                string title = GetLegendTitle(item);

                chart.Series.Add(title);

                if (area == 2)
                    chart.Series[title].ChartArea = "AREA1";
                else
                    chart.Series[title].ChartArea = "AREA" + i.ToString();

                chart.Series[title].ChartType = seriesChartType;

                if (maxValue > 0)
                {
                    if (title == "DAY_SEQ")
                        chart.Series[title].Color = Color.Transparent;
                    else
                        chart.Series[title].Color = SeriesColor(item);
                }
                else
                {
                    if (title == "DAY_SEQ")
                        chart.Series[title].Color = Color.Transparent;
                }

                chart.Series[title].IsVisibleInLegend = isVisibleInLegend;

                foreach(GpsLogData gpslog in listGpxLog)
                {
                    double x = 0.0d;
                    double valueX = 0.0d;
                    
                    int daySeq = Convert.ToInt32(gpslog.DAY_SEQ);
                    double speed = gpslog.SPEED_KMH;

                    switch (item)
                    {
                        case "DAY_SEQ":
                            valueX = Convert.ToDouble(gpslog.DAY_SEQ);
                            break;
                        case "ELE":
                            valueX = gpslog.ELE;
                            break;
                        case "SPEED_KMH":
                            valueX = gpslog.SPEED_KMH;
                            break;
                        case "CAD":
                            valueX = gpslog.CAD;
                            break;
                        case "ATEMP":
                            valueX = gpslog.ATEMP;
                            break;
                        case "HEART":
                            valueX = gpslog.HEART;
                            break;
                    }

                    switch (valueY)
                    {
                        case "KM" : x = gpslog.KM; break;
                        case "DIFF_TIME": x = gpslog.DIFF_TIME; break;
                    }

                    // 평속 3k 이상만 계산
                    if (speed >= 3 && speed <= 75)
                        totalValue += Utils.Common.NaNValue(x);
                    else if (speed == 0 && gpslog.RIDE_DATE_ORIGEN.Length > 19) // 임의로 생성한 Gps 로그 파일
                        totalValue += Utils.Common.NaNValue(x);

                    if (daySeq % 3 == 0)
                        SetAddXY(chart, totalValue, valueX, keyY, title);
                }
            }

            return chart;
        }

        /// <summary>
        /// 막대그래프
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Chart Column(Chart chart, List<GpsLogSumData> listSum, string year)
        {
            if (listSum.Count > 0)
                listSum.RemoveAt(listSum.Count - 1);

            chart.ChartAreas.Clear();
            chart.Series.Clear();

            List<string> listMonth = new List<string>()
            {
                "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"
            };

            chart.ChartAreas.Add("AREA1");
            Series series = new Series();

            if (year == string.Empty)
                series = chart.Series.Add("전체");
            else if (year.Length == 4 || year.Length == 7)
                series = chart.Series.Add(year);
            else if (year.Length > 10)
            {
                string[] date = year.Split('~');
                series = chart.Series.Add(string.Format("({0}) {1}~{2}",year.Substring(0, 4), date[0].Substring(5), date[1].Substring(5)));
            }

            series.ChartType = SeriesChartType.Column;
            series["PixelPointWidth"] = "35";

            double maxValueY = 0.0d;

            if(listSum.Count > 0)
                maxValueY = Convert.ToDouble(listSum.Max(t=>t.DISTANCE));

            chart.ChartAreas[0].AxisY.Maximum = GetMaxValue(maxValueY, "Column");
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Title = "거리(km)";
            chart.ChartAreas[0].AxisY.TitleFont = new Font("굴림", 9F, FontStyle.Bold);

            // 지도에 그래프 눈금 표시
            chart.ChartAreas[0].AxisX.Interval = 1;

            bool isOverLap = false;

            // 연도별
            if (year.Length == 4)
            {
                foreach (string month in listMonth)
                {
                    isOverLap = false;

                    foreach (GpsLogSumData item in listSum)
                    {
                        if (month == item.DATE.Substring(5))
                        {
                            series.Points.AddXY(month, Convert.ToDouble(item.DISTANCE));
                            isOverLap = true;
                            break;
                        }
                    }

                    if (!isOverLap)
                        series.Points.AddXY(month, 0);
                }
            }
            else // 전체/월별/일별
            {
                foreach (GpsLogSumData item in listSum)
                {
                    string date = string.Empty;

                    if (year.Length > 10)
                        date = string.Format("{0} ({1})", item.DATE, DateTimeHelper.WeekDay(item.DATE));
                    else
                        date = item.DATE;

                    series.Points.AddXY(date, Convert.ToDouble(item.DISTANCE));
                }
            }
         
            return chart;
        }

        /// <summary>
        /// 차트 값 설정
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="totalValue"></param>
        /// <param name="valueX"></param>
        /// <param name="keyY"></param>
        /// <param name="item"></param>
        public static void SetAddXY(Chart chart, double totalValue, double valueX, string keyY, string item)
        {
            if (keyY == "거리")
                chart.Series[item].Points.AddXY(Math.Round(totalValue, 2).ToString(), valueX);
            else if (keyY == "시간")
            {
                string time = DateTimeHelper.GetTimeFormat(TimeSpan.FromSeconds(totalValue), DateTimeHelper.TimeFormat.HH_MM_SS);
                chart.Series[item].Points.AddXY(time, valueX);
            }
        }

        public static double GetMaxValue(double value, string column)
        {
            double maxValue = 0.0;

            if (value < 10 && column == string.Empty) maxValue = 10;
            else if (value < 20 && column == string.Empty) maxValue = 20;
            else if (value < 30 && column == string.Empty) maxValue = 30;
            else if (value < 40 && column == string.Empty) maxValue = 40;
            else if (value < 50 && column == string.Empty) maxValue = 50;
            //else if (value < 60) maxValue = 60;
            //else if (value < 70) maxValue = 70;
            //else if (value < 80) maxValue = 80;
            //else if (value < 90) maxValue = 90;
            else if (value < 100) maxValue = 100;
            else if (value < 150) maxValue = 150;
            else if (value < 200) maxValue = 200;
            else if (value < 300) maxValue = 300;
            else if (value < 400) maxValue = 400;
            else if (value < 500) maxValue = 500;
            else if (value < 500) maxValue = 500;
            else if (value < 1000) maxValue = 1000;
            else if (value < 1500) maxValue = 1500;
            else if (value < 2000) maxValue = 2000;
            else if (value < 2500) maxValue = 2500;
            else if (value < 3000) maxValue = 3000;
            else if (value < 3500) maxValue = 3500;
            else if (value < 4000) maxValue = 4000;
            else if (value < 5000) maxValue = 5000;
            else if (value < 7000) maxValue = 7000;
            else if (value < 10000) maxValue = 10000;
            else maxValue = 15000;

            return maxValue;
        }

        private static Color SeriesColor(string item)
        {
            Color color = new Color();

            switch (item)
            {
                case "ELE":
                    color = Color.Red;
                    break;
                case "SPEED_KMH":
                    color = Color.Blue;
                    break;
                case "CAD":
                    color = Color.Orchid;
                    break;
                case "ATEMP":
                    color = Color.Green;
                    break;
                case "HEART":
                    color = Color.Gray;
                    break;
            }

            return color;
        }

        private static string GetLegendTitle(string item)
        {
            string title = string.Empty;

            switch (item)
            {
                case "ELE":
                    title = "고도";
                    break;
                case "SPEED_KMH":
                    title = "속도";
                    break;
                case "CAD":
                    title = "CAD";
                    break;
                case "ATEMP":
                    title = "온도";
                    break;
                case "HEART":
                    title = "심박";
                    break;
                case "DAY_SEQ":
                    title = "DAY_SEQ";
                    break;
            }

            return title;
        }
    }
}