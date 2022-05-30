using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongStill
{
    class SongsFromHtml
    {
        public List<Song> Songs { get; private set; }//Лист песен, можно сказать, что это массив
        public string HTML { get; set; }//хтмлька сайта
        public SongsFromHtml(string HTML)//конструктор класса
        {
            this.HTML = HTML;//этот хтмл = хтмл жтого коструктора
            Songs = new List<Song>();
        }
        public void GenerateList()//генерируем лист песен
        {
            string HTML = this.HTML;//делаем копию сайта
            string name;//локальное имя песни
            string URL;//локальное урл

            Songs = new List<Song>();//создаем еще раз, т.к. прошлый уже стерся

            int index = HTML.IndexOf("track__title");//поиск в хтмл данной строке
            while (index >= 0)//поиск всех "track__title" с помощью цикла 
            {
                HTML = HTML.Remove(0, index + 14);//отрезаме код от нуля до 14 символа
                name = HTML.Remove(HTML.IndexOf("<"));
                name = name.Remove(0, 53);
                name = name.Remove(name.IndexOf("\n"));

                index = HTML.IndexOf("data-nopjax");
                HTML = HTML.Remove(0, index + 18);
                URL = HTML.Remove(HTML.IndexOf("\""));

                index = HTML.IndexOf("track__title");
                Songs.Add(new Song() { Name = name, URL = URL } );
            }
        }
    }
}
