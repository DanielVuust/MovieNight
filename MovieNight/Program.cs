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
            List<Movie> movies = MovieManager.GetMovies();

            StringBuilder movieStringBuilder = new StringBuilder();

            Console.WriteLine("Id \t Title \t\t Realse Year \t Rating");
            foreach (Movie movie in movies)
            {
                movieStringBuilder.Append($"{movie.id} \t {movie.title} \t {movie.releaseYear} \t\t {movie.rating} \n");
            }
            Console.WriteLine(movieStringBuilder);
            
            List<Actor> actors = MovieManager.GetActors();

            StringBuilder actorStringBuilder = new StringBuilder();
            Console.WriteLine("Id \t Name");
            foreach (Actor actor in actors)
            {
                actorStringBuilder.Append($"{actor.id} \t {actor.name} \n");
            }
            Console.WriteLine(actorStringBuilder);

            Console.WriteLine("Skriv hvad du vil søge efter");

            Console.ReadLine();
        }
    }
}
