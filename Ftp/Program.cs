using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Ftp
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceFtp sftp = new ServiceFtp(
                new NetworkCredential("AvisSite", "dm#o4%v#Wn43arWv2"), "ftp://new.avislogistics.kz:2021/GOODS_RECEIPT/");

            sftp.DownloadFile();
        }
    }
}
