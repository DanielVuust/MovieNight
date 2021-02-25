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
        private int _rating;
        public int id { get { return _id; } set { _id = value; } }
        public string title { get { return _title; } set { _title = value; } }
        public int releaseYear { get { return _releaseYear; } set { _releaseYear = value; } }
        public int rating { get { return _rating; } set { _rating = value; } }

        public Movie(int id, string title, int releaseYear, int rating)
        {
            _id = id;
            _title = title;
            _releaseYear = releaseYear;
            _rating = rating; 
        }
    }
}
