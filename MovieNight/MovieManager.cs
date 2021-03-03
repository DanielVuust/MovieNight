using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    static class MovieManager
    {
        //If titleSearch is not definded then it is set to null
        public static StringBuilder OutputMoviesFromDB(string titleSearch = null)
        {
            return OutputMoviesFromList(DalManager.GetMoviesFromTitle(titleSearch));
        }
        public static StringBuilder OutputActorsFromDB(string nameSearch = null)
        {
            return OutputActorsFromList(DalManager.GetActorsFromLastname(nameSearch));
        }
        public static StringBuilder OutputMoviesFromList(List<Movie> movieList)
        {
            //Makes a stringBuilder and defines what it starts with.
            StringBuilder stringBuilder = new StringBuilder("Id \t Title \t\t Realse Year \t Genre \n");

            //Runs through all the item in the list and puts it in the stringBuilder.
            foreach (Movie movie in movieList)
            {
                stringBuilder.Append($"{movie.id} \t {movie.title} \t {movie.releaseYear} \t\t {movie.genre} \n");
            }
            //Returns one long stringBuilder so it only need to be outputted to the console.
            return stringBuilder;
        }
        public static StringBuilder OutputActorsFromList(List<Actor> actorList)
        {
            //Makes a stringBuilder and defines what it starts with.
            StringBuilder stringBuilder = new StringBuilder("Id \t Firstname \t Lastname \n");

            //Runs through all the item in the list and puts it in the stringBuilder.
            foreach (Actor actor in actorList)
            {
                stringBuilder.Append($"{actor.id} \t {actor.firstname} \t {actor.lastname}\n");
            }
            //Returns one long stringBuilder so it only need to be outputted to the console.
            return stringBuilder;
        }
        

         
        
        //If genreSearch is not definded then it is set to null 
        public static List<Movie> GetMoviesFromGenre(string genreSearch = null)
        {
            return DalManager.GetMoviesFromGenre(genreSearch);
        }
        public static Actor AddActor(Actor a)
        {
            return DalManager.InsertActor(a);
        }
        public static Movie AddMovie(Movie m)
        {
            return DalManager.InsertMovie(m);
        }
    }
}
