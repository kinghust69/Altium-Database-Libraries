using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Altium_Database_Libraries.Lib
{
    public class HTMLData
    {
        public string GetHtml(string url)
        {
            string result = String.Empty;
            url = url.Trim();
            if(url.IndexOf("http") == -1 || url == string.Empty)
            {
                return result;
            }
            ServicePointManager.MaxServicePointIdleTime = 1000;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            using (Stream stream = res.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            result = result.Replace("\n", String.Empty); // remove CR
            result = result.Replace("\r", String.Empty); // remove LF
            result = result.Replace("  ", String.Empty); // remove double space 
            return result;
        }

        public void Download(string url, string path)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, path);
            }
        }

        public List<string> GetData(string data, string startData, string endData)
        {
            
            List<string> result = new List<string>();
            if (data != string.Empty)
            {
                MatchCollection match = Regex.Matches(data, startData + "(?<Data>.*?)" + endData);
                foreach (Match item in match)
                {
                    result.Add(item.Groups["Data"].Value.ToString());
                }
            }
            if (result.Count == 0)
            {
                result.Add("<Not Found>");
            }
            return result;
        }
        
    }
}
