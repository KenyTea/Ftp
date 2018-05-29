using Ftp.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ftp
{
    public class ServiceFtp
    {
        private NetworkCredential credential;
        private string path;

        public ServiceFtp(NetworkCredential credential, string path)
        {
            this.credential = credential;
            this.path = path;
        }
        public void DownloadFile()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path); // запрос
            request.Method = WebRequestMethods.Ftp.ListDirectory;


            request.Credentials = credential;
            request.Proxy = null;

            var responce = (FtpWebResponse)request.GetResponse();
            Stream stream = responce.GetResponseStream();

            List<string> ListFiles = new List<string>();
            if (stream != null)
            {
                using (var reader = new StreamReader(stream))
                {
                    var line = reader.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        ListFiles.Add(line);
                        line = reader.ReadLine();
                        Console.WriteLine("File  "+ line + "  is ready");
                    }
                }
                using (var ftpClients = new WebClient() { Credentials = credential })
                {
                    foreach (var item in ListFiles)
                    {
                        ftpClients.DownloadFile(path + "/" + item, "new_" + item);
                        GoodsReceipt g = DF("new_" + item);
                    }
                }
            }

        }

        public GoodsReceipt DF(string pathToFile)
        {
            GoodsReceipt gr = null;
            XmlSerializer formatter = new XmlSerializer(typeof(GoodsReceipt));
            using (FileStream fs = new FileStream(pathToFile, FileMode.Open))
            {
                gr = (GoodsReceipt)formatter.Deserialize(fs);
            }
            return gr;
        }
    }
}
