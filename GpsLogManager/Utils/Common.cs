using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsLogManager.Utils
{
    public static class Common
    {
        public static double NaNValue(double value)
        {
            double rtnValue = !double.IsNaN(value) ? value : 0;
            return rtnValue;
        }

        /// <summary>
        /// 숫자 3자리마다 콤마
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string NumberFormat(string num)
        {
            string result = string.Empty;

            if (num != string.Empty)
            {
                int number = Convert.ToInt32(num);
                result = string.Format("{0:#,#}", number);
            }
            else
                result = "0";

            return result;
        }
    }
}


