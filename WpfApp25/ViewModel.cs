using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WpfApp25;

namespace SongStill
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        List<Song> _songs;
        Song _selectedSong;
        string path = "";
        string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                Notify("Search");
            }
        }
        public Song SelectedSongs
        {
            get { return _selectedSong; }
            set
            {
                _selectedSong = value;
                Notify("SelectedSongs");
            }
        }
        public List<Song> Songs
        {
            get { return _songs; }
            set
            {
                _songs = value;
                Notify("Songs");
            }
        }
        public ICommand SearchClick
        {
            get
            {
                return new ButtonCommand(new Action(
                    () =>
                    {
                        SiteFromURL siteFrom = new SiteFromURL("https://ru.hitmotop.com/search?q=" + _search);
                        SongsFromHtml songs = new SongsFromHtml(siteFrom.GetHtml());
                        songs.GenerateList();
                        Songs = new List<Song>(songs.Songs);
                    }));
            }
        }
        public ICommand DownloadClick
        {
            get
            {
                return new ButtonCommand(
                    new Action(
                        () =>
                        {
                            if (path == "")
                            {
                                FolderBrowserDialog dialog = new FolderBrowserDialog();
                                if (dialog.ShowDialog() == DialogResult.OK)
                                    path = dialog.SelectedPath;
                                else
                                    return;
                            }
                            if (path != "")
                            {
                                Downloader downloader = new Downloader();
                                downloader.Download(path + "\\" + _selectedSong.Name + ".mp3", _selectedSong.URL);
                                MessageBox.Show("Gotovo");
                            }
                        })
                        );
            }
        }
    }
}
