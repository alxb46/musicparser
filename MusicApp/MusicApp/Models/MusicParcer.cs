using System;
using System.Collections.Generic;
using Avalonia.Controls;
using HtmlAgilityPack;

namespace MusicApp.Models
{
    public class MusicParcer 
    {
        public List<Music> Musics = new();

        //private readonly string filePath = "https://music.apple.com/ua/playlist/a-list-pop/pl.5ee8333dbe944d9f9151e97d92d1ead9";

        public void Parce(string filePath)
        {
            HtmlWeb web = new();
            HtmlDocument? doc = web.Load(filePath);

            HtmlNodeCollection song_nodes = doc.DocumentNode.SelectNodes("//div[@class='songs-list-row songs-list-row--web-preview web-preview songs-list-row--two-lines songs-list-row--song']");


            int count = 0;

            foreach (var item in song_nodes)
            {
                Music music = new();

                //parse name song
                string str = item.InnerHtml.TrimStart();
                string name_class = "class=\"songs-list-row__song-name\">";
                int index = str.IndexOf(name_class);
                str = str[(index + name_class.Length)..]; //

                index = str.IndexOf("</div>");
                music.Song = str[..index];

                //parse artists
                do
                {
                    str = str.Substring(index);
                    name_class = "class=\"songs-list-row__link\" tabindex=\"-1\" dir=\"auto\">";
                    index = str.IndexOf(name_class);
                    if (index != -1)
                    {
                        str = str.Substring(index + name_class.Length);
                        index = str.IndexOf("</a>");
                        music.Artist += str[..index] + "   ";
                    }
                    //str = str.Substring(index);
                } while (str.IndexOf(name_class) != -1);

                //parse album
                str = str.Substring(index);
                name_class = "class=\"songs-list-row__link\" tabindex=\"-1\">";
                index = str.IndexOf(name_class);
                str = str.Substring(index + name_class.Length);
                index = str.IndexOf("</a>");
                str = str.Substring(index);
                name_class = "class=\"songs-list-row__link\" tabindex=\"-1\">";
                index = str.IndexOf(name_class);
                str = str.Substring(index + name_class.Length);
                index = str.IndexOf("</a>");
                music.Album = str[..index];

                //parse time 
                str = str.Substring(index);
                name_class = "class=\"songs-list-row__length\">\n";
                index = str.IndexOf(name_class);
                str = str.Substring(index + name_class.Length);
                index = str.IndexOf("</time>");
                music.Time = str[..index].Trim();

                ++count;
                music.Id = count;

                Musics.Add(music);
            }
        }
    }
}

