using System.Collections.Generic;

namespace MovieNight
{
    static class MovieManager
    {
        //If titleSearch is not definded then it is set to null 
        public static List<Movie> GetMoviesFromTitle(string titleSearch = null)
        {
            return DalManager.GetMoviesFromTitle(titleSearch);
        }
        //If nameSearch is not definded then it is set to null 
        public static List<Actor> GetActorsFromLastname(string nameSearch = null)
        {
            return DalManager.GetActorsFromLastname(nameSearch);
        }
        //If genreSearch is not definded then it is set to null 
        public static List<Movie> GetMoviesFromGenre(string genreSearch = null)
        {
            return DalManager.GetMoviesFromGenre(genreSearch);
        }
    }
}
