using System;
using System.Text;
using System.Xml;
using System.Collections;
using System.Windows.Forms;
using System.IO;

/// <summary>
/// 환경설정
/// http://www.dreamy.pe.kr/zbxe/CodeClip/164954
/// </summary>
namespace GpsLogManager.Utils
{
    public class Setting
    {
        /// <summary>
        /// Xml 쓰기
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int WriteXml(Hashtable ht)
        {
            IDictionaryEnumerator htEnum = ht.GetEnumerator();

            XmlTextWriter tw = new XmlTextWriter(Application.StartupPath + @"\Setting.xml", Encoding.UTF8);

            tw.Formatting = Formatting.Indented;
            tw.WriteStartDocument();
            tw.WriteStartElement("Configutation");

            while (htEnum.MoveNext())
            {
                tw.WriteElementString(htEnum.Key.ToString(), htEnum.Value.ToString());
            }

            tw.WriteEndElement();
            tw.WriteEndDocument();

            tw.Flush();
            tw.Close();
            return 0;
        }

        /// <summary>
        /// Xml 읽기
        /// </summary>
        /// <returns></returns>
        public Hashtable ReadXml()
        {
            try
            {
                string skey = string.Empty;
                string sValue = string.Empty;
                Hashtable ht = new Hashtable();
                XmlTextReader xtr = new XmlTextReader(Application.StartupPath + @"\Setting.xml");

                while (xtr.Read())
                {
                    if (xtr.NodeType == XmlNodeType.Element)
                    {
                        skey = xtr.LocalName;
                        xtr.Read();

                        if (xtr.NodeType == XmlNodeType.Text)
                        {
                            sValue = xtr.Value;
                            ht.Add(skey, sValue);
                        }
                        else
                            continue;
                    }
                }

                return ht;
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }
        }
    }
}
