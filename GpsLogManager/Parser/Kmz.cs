using System;

namespace GpsLogManager.Parser
{
    public class KmzPaser
    {
        public string FileName { get; set; }

        public KmzPaser(string fileName)
        {
            this.FileName = fileName;
        }
    }
}
