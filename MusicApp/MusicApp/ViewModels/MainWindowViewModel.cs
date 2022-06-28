using System.Collections.Generic;
using System.Collections.ObjectModel;
using HtmlAgilityPack;
using MusicApp.Models;

namespace MusicApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        //public string Greeting => "Welcome to Avalonia!";
        public List<Music> Musics { get; set; }

        // private readonly string filePath = "https://music.apple.com/ua/playlist/a-list-pop/pl.5ee8333dbe944d9f9151e97d92d1ead9";
        private readonly string filePath = "https://music.apple.com/ua/playlist/the-new-rock/pl.28926c578a80475c904026ea97646ad5";
        //ObservableCollection<Music> Musics { get; set; }

        public MainWindowViewModel(MusicParcer musicParcer)
        {
            musicParcer.Parce(filePath);
            Musics = musicParcer.Musics;
        }
    }
}

