using System;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace GpsLogManager.Utils
{
    public class CountryIP : IDisposable
    {
        /// <summary>
        /// IP 정보를 기초로 국가, 도시, 기타 ISP정보 조회
        /// </summary>
        /// <returns></returns>
        public string GetlIPAddress()
        {
            string myIp = "http://checkip.dyndns.org/";
            WebClient wc = new WebClient();
            UTF8Encoding utf8 = new UTF8Encoding();

            string requestHtml = utf8.GetString(wc.DownloadData(myIp));
            string ip = Regex.Match(requestHtml, @"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}").Value.ToString();
            string strReturnVal;
            string ipResponse = IPRequestHelper("http://ip-api.com/xml/" + ip);

            XmlDocument ipInfoXML = new XmlDocument();
            ipInfoXML.LoadXml(ipResponse);
            XmlNodeList responseXML = ipInfoXML.GetElementsByTagName("query");

            NameValueCollection dataXML = new NameValueCollection();

            strReturnVal = responseXML.Item(0).ChildNodes[5].InnerText.ToString(); // Contry
            return strReturnVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string IPRequestHelper(string url)
        {
            string checkURL = url;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            StreamReader responseStream = new StreamReader(objResponse.GetResponseStream());
            string responseRead = responseStream.ReadToEnd();
            responseRead = responseRead.Replace("\n", String.Empty);
            responseStream.Close();
            responseStream.Dispose();
            return responseRead;
        }

        void IDisposable.Dispose()
        {
            
        }
    }
}
