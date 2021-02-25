using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    static class MovieManager
    {
        public static List<Movie> GetMovies(string title = null)
        {
            return DalManager.GetMovies(title);
        }
        public static List<Actor> GetActors()
        {
            return DalManager.GetActors();
        }
    }
}
