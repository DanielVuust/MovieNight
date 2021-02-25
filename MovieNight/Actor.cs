using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    public class Actor
    {
        private int _id;
        private string _name;


        public int id { get { return _id; } set { _id = value; } }
        public string name{ get { return _name; } set { _name = value; } }

        public Actor(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
