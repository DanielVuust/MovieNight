using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    public class Movie
    {
        private int _id;
        private string _title;
        private int _releaseYear;
        private List<string> _genre;
        public int id { get { return _id; } set { _id = value; } }
        public string title { get { return _title; } set { _title = value; } }
        public int releaseYear { get { return _releaseYear; } set { _releaseYear = value; } }
        public List<string> genre { get { return _genre; } set { _genre = value; } }

        public Movie (List<string> genre, string title, int releaseYear)
        {
            _title = title;
            _releaseYear = releaseYear;
            _genre = genre;
        }
        public Movie(int id, List<string> genre, string title, int releaseYear)
            :this(genre, title, releaseYear)
        {
            _id = id;
        }
    }
}
