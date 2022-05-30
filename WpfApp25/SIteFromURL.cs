using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace SongStill
{
    class SiteFromURL
    {
        public string URL { get; set; }//переменная, что получает и отдает ЮРЛ
        public SiteFromURL(string URL)//конструктор
        {
            this.URL = URL;
        }
        public string GetHtml()
        {
            WebRequest request = WebRequest.Create(URL);//запрос на пролучение юрл сайта
            WebResponse response = request.GetResponse();//ответ с сервера
            Stream stream = response.GetResponseStream();//поток данный
            StreamReader reader = new StreamReader(stream);//чтение потока данных
            return reader.ReadToEnd();
        }
    }
}
