using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp25
{
    class Downloader
    {
        public void Download(string name, string url)
        {
            WebClient client = new WebClient();
            client.DownloadFile(url, name);
        }
    }
}
