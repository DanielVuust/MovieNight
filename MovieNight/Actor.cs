using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    public class Actor
    {
        private int _id;
        private string _firstname;
        private string _lastname;


        public int id { get { return _id; } set { _id = value; } }
        public string firstname { get { return _firstname; } set { _firstname = value; } }
        public string lastname{ get { return _lastname; } set { _lastname = value; } }
        

        public Actor(string firstname, string lastname)
        {
            this._firstname = firstname;
            this._lastname = lastname;
        }
        public Actor (int id, string firstname, string lastname)
            :this(firstname, lastname)
        {
            this.id = id;
        }
    }
}
