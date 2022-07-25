using System;
using System.IO;
using System.Text;

namespace GpsLogManager.Utils
{
    internal class StringWriterExt : StringWriter
    {
        public StringWriterExt(IFormatProvider info): base(info)
        {}

        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}