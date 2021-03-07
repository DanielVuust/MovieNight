using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    static class MovieManager
    {

        //If titleSearch is not definded then it is set to null
        public static StringBuilder OutputMoviesFromTitle(string titleSearch = null)
        {
            return MoviesListToStrinBuilder(DalManager.GetMoviesFromTitle(titleSearch));
        }
        public static StringBuilder OutputActorsFromLastname(string nameSearch = null)
        {
            return ActorListToStringBuilder(DalManager.GetActorsFromLastname(nameSearch));
        }
        public static StringBuilder OutputMoviesFromGenre(string genreSearch = null)
        {
            return MoviesListToStrinBuilder(DalManager.GetMoviesFromGenre(genreSearch));
        }
        public static StringBuilder OutputGenreFromGenre()
        {
            return GenreListToStringBuilder(DalManager.GetAllGenre());
        }

        //Makes a list to a StringBuilder.
        private static StringBuilder MoviesListToStrinBuilder(List<Movie> movieList)
        {
            //Makes a stringBuilder and defines what it starts with.
            StringBuilder stringBuilder = new StringBuilder("Id \t Title \t\t Realse Year \t Genre\n");

            //Runs through all the item in the list and puts it in the stringBuilder.
            foreach (Movie movie in movieList)
            {
                stringBuilder.Append($"{movie.id} \t {movie.title} \t {movie.releaseYear}\t\t");
                foreach (string genre1 in movie.genre)
                {
                    stringBuilder.Append($" {genre1}");
                }
                stringBuilder.Append("\n");
            }
            //Returns one long stringBuilder so it only need to be outputted to the console.
            return stringBuilder;
        }
        private static StringBuilder ActorListToStringBuilder(List<Actor> actorList)
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
        private static StringBuilder GenreListToStringBuilder(List<string> genreList)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string genre in genreList)
            {
                stringBuilder.Append(genre + " ");
            }
            return stringBuilder;
        }

        //Add to the db.
        public static Actor AddActor(Actor a)
        {
            return DalManager.InsertActor(a);
        }
        public static Movie AddMovie(Movie m)
        {
            return DalManager.InsertMovie(m);
        }
        public static void AddGenre(string genreName)
        {
            DalManager.InsertGenre(genreName);
        }
        //Edit.
        public static void UpdateMovie(Movie m)
        {
            DalManager.UpdateMovie(m);
        }
        public static void UpdateActor(Actor a)
        {
            DalManager.UpdateActor(a);
        }
        public static void UpdateGenre(string oldGenreName, string newGenreName)
        {
            DalManager.UpdateGenre(oldGenreName, newGenreName);
        }
        public static bool RemoveMovie(string id)
        {
            if (Int32.TryParse(id, out int intId))
            {
                DalManager.RemoveMovie(intId);
                return true;
            }
            else
                return false;
        }
        public static bool RemoveActor(string id)
        {
            if (Int32.TryParse(id, out int intId))
            {
                DalManager.RemoveActor(intId);
                return true;
            }
            else
                return false;
        }
        public static bool RemoveGenre(string genreName)
        {
            DalManager.RemoveGenre(genreName);
            return true;
        }

    }   
}



