using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsLogManager.Field
{
    public class GpsLogSumData
    {
        public GpsLogSumData() {}

        public string DATE { get; set; }
        public double DISTANCE { get; set; }
        public double RIDE_SECOND { get; set; }
        public string RIDE_TIME { get; set; }
        public double TOTAL_ASCENT { get; set; }
        public double TOTAL_DESCENT { get; set; }
        public double KCAL { get; set; }
    }
}
