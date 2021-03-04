using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    public class Genre
    {
        private int _id;
        private string _genreName;
        public int id { get { return _id; }}
        public string genreName { get { return _genreName; }set { _genreName = value; } }
        public Genre (string genreName)
        {
            _genreName = genreName;
        }
    }
}
