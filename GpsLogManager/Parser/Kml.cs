using System;

namespace GpsLogManager.Parser
{
    public class KmlPaser
    {
        public string FileName { get; set; }

        public KmlPaser(string fileName)
        {
            this.FileName = fileName;
        }
    }
}
