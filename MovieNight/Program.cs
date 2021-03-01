using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MovieNight 
{
    class Program
    {
        static void Main(string[] args) 
        {
            //Here i call the function that will return the List of movies in the database.
            List<Movie> movies = MovieManager.GetMoviesFromTitle();

            //I use StringBuilder so i only need to call Console.WriteLine once and its more manageable.
            StringBuilder movieStringBuilder = new StringBuilder();

            Console.WriteLine("Id \t Title \t\t Realse Year \t Genre");
            //For each movie in the query it makes a new line in the StringBuilder.
            foreach (Movie movie in movies)
            {
                movieStringBuilder.Append($"{movie.id} \t {movie.title} \t {movie.releaseYear} \t\t {movie.genre} \n");
            }
            Console.WriteLine(movieStringBuilder);
            
            //Here i call the function that will retunr the List of actors in the database.
            List<Actor> actors = MovieManager.GetActorsFromLastname();

            //Another StringBulder to make it more manageable.
            StringBuilder actorStringBuilder = new StringBuilder();
            Console.WriteLine("Id \t Name");
            //For each actor in the list it makes a new line.
            foreach (Actor actor in actors)
            {
                actorStringBuilder.Append($"{actor.id} \t {actor.name} \n");
            }
            Console.WriteLine(actorStringBuilder);

            Program program = new Program();
            //I use a while loop because the user should be able to make multiple searches.
            while (true)
            {
                Console.WriteLine("Vil du søge efter en skuespiller eller en film? \n 1. Film \n 2. Skuespiller \n 3. Genre");
                //A switch statemant so i can call the function that is related the what the user wants.
                switch (Console.ReadLine())
                {
                    case "1":
                        //If Console.RadLine = "1" the this runs and so on.
                        program.movieSearch();
                        break;
                    case "2":
                        program.actorSearch();
                        break;
                    case "3":
                        program.genreSearch();
                        break;
                    //If nothing runs the this runs.
                    default:
                        Console.WriteLine("Du har indtastet et ugyldigt tal.");
                        continue;
                }
            }
            
        }
        private void movieSearch()
        {
            Console.WriteLine("Skriv hvad du vil søge efter");
            //Here the user decides what to search for.
            string search = Console.ReadLine();
            //Calls a function and saves it as a movieSearchList List
            List<Movie> movieSearchList = MovieManager.GetMoviesFromTitle(search);

            StringBuilder movieSearchStringBuilder = new StringBuilder();

            Console.WriteLine("Id \t Title \t\t Realse Year \t Genre");
            foreach (Movie movie in movieSearchList)
            {
                movieSearchStringBuilder.Append($"{movie.id} \t {movie.title} \t {movie.releaseYear} \t\t {movie.genre} \n");
            }
            Console.WriteLine(movieSearchStringBuilder);
        }
        private void actorSearch()
        {
            Console.WriteLine("Skriv hvad du vil søge efter");
            //Here the user decides what to search for.
            string search = Console.ReadLine();
            //Calls a function and saves it as a actorSearchList List
            List<Actor> actorSearchList = MovieManager.GetActorsFromLastname(search);

            StringBuilder actorSearchStringBuilder = new StringBuilder();

            Console.WriteLine("Id \t Name");
            foreach (Actor actor in actorSearchList)
            {
                actorSearchStringBuilder.Append($"{actor.id} \t {actor.name} \n");
            }
            Console.WriteLine(actorSearchStringBuilder);
        }
        private void genreSearch()
        {
            Console.WriteLine("Skriv hvilken genre vil du søge efter?");
            //Here the user decides what to search for.
            string search = Console.ReadLine();
            //Calls a function and saves it as a movieSearchList List
            List<Movie> movieSearchList = MovieManager.GetMoviesFromGenre(search);
            StringBuilder movieSearchStringBuilder = new StringBuilder();

            Console.WriteLine("Id \t Title \t\t Realse Year \t Genre");
            foreach (Movie movie in movieSearchList)
            {
                movieSearchStringBuilder.Append($"{movie.id} \t {movie.title} \t {movie.releaseYear} \t\t {movie.genre} \n");
            }
            Console.WriteLine(movieSearchStringBuilder);
        }
    }
}
