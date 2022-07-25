using System;
using System.Collections.Generic;
using System.Data;
using GpsLogManager.Common;
using GpsLogManager.Field;

namespace GpsLogManager.Data
{
    public class GpsLogDac : IDisposable
    {
        private DBHelper dbhelper = null;

        public GpsLogDac()
        {
            dbhelper = new DBHelper(DBHelper.DbProviders.SQLite);
        }

        /// <summary>
        /// GpsActivity 검색
        /// </summary>
        /// <returns></returns>
        public List<T> GetGpsLogList<T>()
        {
            #region Query

            string query = @"

            SELECT RIDE_DATE, RIDE_DATE_ORIGEN FROM 
            GPS_ACTIVITY 
            WHERE RIDE_DATE != 'TOTAL'            
            ORDER BY RIDE_DATE_ORIGEN ASC";

            #endregion

            return dbhelper.ExecuteReader<T>(query, CommandType.Text);
        }

        public bool OverRapCheck(string tablename, string date)
        {
            bool isCheck = false;

            string query = string.Format("SELECT RIDE_DATE_ORIGEN FROM GPS_ACTIVITY WHERE RIDE_DATE_ORIGEN = '{1}' ", tablename, date);

            List<string> rtnList = dbhelper.ExecuteReader<string>(query, CommandType.Text);

            isCheck = rtnList.Count > 0 ? true : false;

            return isCheck;
        }

        /// <summary>
        /// Gpslog 검색
        /// </summary>
        /// <param name="rideDate"></param>
        /// <returns></returns>
        public List<T> GetGpsLogList<T>(string rideDate)
        {
            int langeth = rideDate.Length;

            List<T> rtnList = new List<T>();

            string query = string.Empty;
            string where = string.Empty;
            string resultQuery = string.Empty;

            #region Query

            query = @"
                SELECT 
                    DAY_SEQ
                ,	RIDE_DATE
                ,	TITLE
                ,	LAT
                ,	LNG
                ,	ELE
                ,	SPEED_KMH
                ,	KM
                ,	DIFF_TIME
                ,	LOG_TIME
                ,	LOG_TIME_ORIGEN
                ,	ATEMP
                ,	CAD
                ,	HEART
                ,	RIDE_DATE_ORIGEN
                ,	WAYPOINT
                FROM GPS_LOG
                {0}
                ORDER BY DAY_SEQ ASC";

            if (langeth == 0)
                where = @"";
            else if (langeth == 4)
                where = string.Format(@" WHERE SUBSTR(RIDE_DATE_ORIGEN, 1, 4) = {0}", rideDate);
            else if (langeth == 7)
                where = string.Format(@" WHERE SUBSTR(RIDE_DATE_ORIGEN, 1, 7) = {0}", rideDate);
            else
                where = string.Format(@" WHERE RIDE_DATE_ORIGEN = '{0}' ", rideDate);

            resultQuery = string.Format(query, where);
            return dbhelper.ExecuteReader<T>(resultQuery, CommandType.Text);

            #endregion
        }

        /// <summary>
        /// 라이딩 정보 조회
        /// </summary>
        /// <param name="rideDate"></param>
        /// <returns></returns>
        public List<T> GetGpsActivityList<T>(string rideDate)
        {
            int langeth = rideDate.Length;

            string query = string.Empty;
            string where = string.Empty;
            string resultQuery = string.Empty;

            List<T> rtnList = new List<T>();

            #region Query

            query = @"
                SELECT 
	                RIDE_DATE
                ,	TITLE
                ,   DISTANCE
                ,	TIME
                ,	ELAPSE_TIME
                ,   HIGH_SPEED
                ,   AVG_SPEED
                ,	HIGH_ELE
                ,	LOW_ELE
                ,	AVG_ELE
                ,	TOTAL_ASCENT
                ,	TOTAL_DESCENT
                ,	HIGH_CAD
                ,	LOW_CAD
                ,	AVG_CAD
                ,	HIGH_TEMP
                ,	LOW_TEMP
                ,	AVG_TEMP
                ,	HIGH_HEART
                ,	LOW_HEART
                ,	AVG_HEART
                ,	KCAL
                ,	RIDE_DATE_ORIGEN
                ,	START_LAT
                ,	START_LNG
                ,	END_LAT
                ,	END_LNG
                ,	YEAR
                ,	MONTH
                ,   ALTITUDE_GAP
                ,   GRADE
                FROM GPS_ACTIVITY
                {0}
                ORDER BY RIDE_DATE_ORIGEN ASC";

            if (langeth == 0)
                where = @"";
            else if (langeth == 4)
                where = string.Format(@" WHERE SUBSTR(RIDE_DATE_ORIGEN, 1, 4) = '{0}' ", rideDate);
            else if (langeth == 7)
                where = string.Format(@" WHERE SUBSTR(RIDE_DATE_ORIGEN, 1, 7) = '{0}' ", rideDate);
            else
                where = string.Format(@" WHERE RIDE_DATE_ORIGEN = '{0}' ", rideDate);

            resultQuery = string.Format(query, where);

            #endregion

            return dbhelper.ExecuteReader<T>(resultQuery, CommandType.Text);
        }

        /// <summary>
        /// GpsLog 등록
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void InsertGpsLog<T>(List<T> list)
        {
            string tableName = "GPS_LOG";
            string query = dbhelper.InsertAutoQuery<T>(tableName);

            dbhelper.AutoMakeParamseter<T>(query, list);
        }

        /// <summary>
        /// GpsLogActivity 등록
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void InsertGpsActivity<T>(List<T> list)
        {
            string tableName = "GPS_ACTIVITY";
            string query = dbhelper.InsertAutoQuery<T>(tableName);

            dbhelper.AutoMakeParamseter<T>(query, list);
        }

        public void UpdateGpsActivity<T>(List<T> list)
        {
            #region Query

            string query = @"

            UPDATE GPS_ACTIVITY SET
                TITLE = @TITLE
            WHERE RIDE_DATE_ORIGEN = @RIDE_DATE_ORIGEN ";

            #endregion

            dbhelper.AutoMakeParamseter<T>(query, list);
        }

        /// <summary>
        /// 라이딩 정보 삭제
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listDelete"></param>
        public void DeleteGpsLog<T>(List<T> listDelete)
        {
            List<string> listQuerys = new List<string>()
            {
                #region Query

                "DELETE FROM GPS_ACTIVITY WHERE RIDE_DATE_ORIGEN = @RIDE_DATE_ORIGEN",
                "DELETE FROM GPS_LOG WHERE RIDE_DATE_ORIGEN = @RIDE_DATE_ORIGEN"

                #endregion
            };

            foreach (string query in listQuerys)
            {
                dbhelper.AutoMakeParamseter<T>(query, listDelete);
            }
        }

        /// <summary>
        /// 환경설정 정보 등록
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void InsertSetting<T>(List<T> list)
        {
            string tableName = "GPS_SETTING";
            string query = dbhelper.InsertAutoQuery<T>(tableName);

            dbhelper.AutoMakeParamseter<T>(query, list);
        }

        /// <summary>
        /// 환경설정 정보 조회
        /// </summary>
        /// <returns></returns>
        public List<T> GetSetting<T>()
        {
            #region Query

            string query = @"

            SELECT NAME, WEIGHT, HEIGHT, DB_PATH FROM GPS_SETTING";

            #endregion

            return dbhelper.ExecuteReader<T>(query, CommandType.Text);
        }

        public void UpdateSetting<T>(List<T> list)
        {
            #region Query

            string query = @"

            UPDATE GPS_SETTING SET 
                WEIGHT = @WEIGHT, 
                HEIGHT = @HEIGHT,
                DB_PATH = @DB_PATH
            WHERE NAME = @NAME";

            #endregion

            dbhelper.AutoMakeParamseter(query, list);
        }

        /// <summary>
        /// 환경설정 정보 삭제
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void DeleteSetting<T>(List<T> list)
        {
            #region Query

            string query = @"

           DELETE FROM GPS_SETTING WHERE NAME = @NAME";

            #endregion

            dbhelper.AutoMakeParamseter(query, list);
        }

        /// <summary>
        /// 합계
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<T> GpsLogSum<T>(int index, string sumDate)
        {
            string where = string.Empty;
            string resultQuery = string.Empty;
            string date = string.Empty;

            #region Query

            string query = @"

            SELECT
                {0} AS DATE
            ,	SUM(DISTANCE) AS DISTANCE
            ,   STRFTIME('%S',TIME) AS RIDE_SECOND
            ,	SUM(TOTAL_ASCENT) AS TOTAL_ASCENT
            ,	SUM(TOTAL_DESCENT) AS TOTAL_DESCENT
            ,	SUM(KCAL) AS KCAL
            FROM GPS_ACTIVITY
            {1}            
            GROUP BY {2} ";

            if (index == 0)
            {
                date = " YEAR";
                where = string.Empty;
            }
            else if (index == 1)
            {
                date = "MONTH ";
                where = string.Format(@" WHERE YEAR = '{0}' ", sumDate);
            }
            else if (index == 2 || index == 3)
            {
                string[] days = null;

                if (sumDate.IndexOf('/') != -1)
                {
                    days = sumDate.Split('/');
                    date = " SUBSTR(RIDE_DATE, 1, 7)  ";
                }
                else
                {
                    days = sumDate.Split('~');
                    date = " RIDE_DATE ";
                }

                where = string.Format(@" WHERE RIDE_DATE BETWEEN '{0}' AND '{1}' ", days[0], days[1]);
            }

            resultQuery = string.Format(query, date, where, date);

            #endregion

            return dbhelper.ExecuteReader<T>(resultQuery, CommandType.Text);
        }

        /// <summary>
        /// 위경도 정보 리턴
        /// </summary>
        /// <param name="listrideDateOrigen"></param>
        /// <returns></returns>
        public List<T> GetLatlng<T>(List<string> listrideDateOrigen)
        {
            string where = string.Empty;
            string resultQuery = string.Empty;
            string query = string.Empty;

            List<T> rtnList = new List<T>();

            query = @"
                    
            SELECT 
                    DAY_SEQ
                ,   LAT
                ,   LNG
                ,   ELE
                ,   SPEED_KMH
                ,   CAD
                ,   ATEMP
                ,   HEART
                ,   KM
                ,   DIFF_TIME
                ,   LOG_TIME
                ,   WAYPOINT
                ,   RIDE_DATE_ORIGEN 
            FROM GPS_LOG 
            WHERE RIDE_DATE_ORIGEN IN ({0}) ";

            where = dbhelper.AddIn(listrideDateOrigen);
            resultQuery = string.Format(query, where);

            rtnList =  dbhelper.ExecuteReader<T>(resultQuery, CommandType.Text);

            return rtnList;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 중복 호출을 검색하려면

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
                }

                // TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.

                disposedValue = true;
            }
        }

        // TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
        // ~GpsLogDac() {
        //   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
        //   Dispose(false);
        // }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
            Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}