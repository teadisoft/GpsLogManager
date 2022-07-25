using System;

namespace GpsLogManager.Field
{
    public class GpsLogSetting
    {
        /// <summary>
        /// 설정 정보 
        /// </summary>
        public GpsLogSetting() { }

        public string NAME { get; set; }
        public int WEIGHT { get; set; }
        public int HEIGHT { get; set; }
        public string DB_PATH { get; set; }
    }
}
