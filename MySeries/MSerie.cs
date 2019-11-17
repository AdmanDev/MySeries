using System;
using System.Drawing;

namespace MySeries
{
    [Serializable]
    public class MSerie
    {
        //Variables
        private string title;
        private string author;
        private string genre;
        private string language;
        private string state;
        private string synopsis;
        private int episodeNb;
        private int releaseDate;
        private int rating;
        private Bitmap poster;
        private bool favorite;

        //Properties
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Language { get => language; set => language = value; }
        public string State { get => state; set => state = value; }
        public string Synopsis { get => synopsis; set => synopsis = value; }
        public int EpisodeNb { get => episodeNb; set => episodeNb = value; }
        public int ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public int Rating { get => rating; set => rating = value; }
        public Bitmap Poster { get => poster; set => poster = value; }
        public bool Favorite { get => favorite; set => favorite = value; }


        //Constructors
        public MSerie()
        {
            Title = Author = Genre = Language = State = Synopsis = "Undefined";
            EpisodeNb = 0;
            ReleaseDate = 0;
            Rating = 0;
            Favorite = false;
        }

        public MSerie(string _title, string _author, string _genre, string _language, string _state, string _synopsis, int _episodeNb, int _releaseDate, int _rating, Bitmap _poster, bool _favorite)
        {
            Title = _title;
            Author = _author;
            Genre = _genre;
            Language = _language;
            State = _state;
            Synopsis = _synopsis;
            EpisodeNb = _episodeNb;
            ReleaseDate = _releaseDate;
            Rating = _rating;
            Poster = _poster;
            Favorite = _favorite;
        }

    }
}
