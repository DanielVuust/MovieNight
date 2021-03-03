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
            Console.WriteLine(MovieManager.OutputMoviesFromDB());

            Console.WriteLine(MovieManager.OutputActorsFromDB());

            Program program = new Program();
            //I use a while loop because the user should be able to make multiple searches.
            while (true)
            {
                Console.WriteLine("Vil du søge efter en skuespiller eller en film? \n 1. Film \n 2. Skuespiller");
                //A switch statemant so i can call the function that is related the what the user wants.
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine(" 1. Vis alle film \n 2. Søg efter titel \n 3. Søg efter genre \n 4. Tilføj film 5. Updater film data \n 6. Slet film");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                MovieManager.OutputActorsFromDB();
                                break;
                            case "2":
                                program.MovieSearch();
                                break;
                            case "3":
                                program.GenreSearch();
                                break;
                            case "4":
                                program.AddMovie();
                                break;
                            case "5":

                                break;
                            case "6":

                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine(" 1. Vis alle skuespillere \n 2. Søg efter efternavn \n 3. Tilføj skuespiller 4. Updater skespiller data \n 5. Slet skuespiller");
                        
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine(MovieManager.OutputActorsFromDB());
                                break;
                            case "2":
                                program.ActorSearch();
                                break;
                            case "3":

                                break;
                            case "4":

                                break;
                            case "5":

                                break;
                        }
                        break;
                    //If nothing runs the this runs.
                    default:
                        Console.WriteLine("Du har indtastet et ugyldigt tal.");
                        continue;
                }
            }
            
        }
        private void MovieSearch()
        {
            Console.WriteLine("Skriv hvad du vil søge efter");
            //Here the user decides what to search for.
            string search = Console.ReadLine();
            //Calls a function and saves it as a movieSearchList List
            Console.WriteLine(MovieManager.OutputMoviesFromDB(search));
        }
        private void ActorSearch()
        {
            Console.WriteLine("Skriv hvad du vil søge efter");
            //Here the user decides what to search for.
            string search = Console.ReadLine();
            //Calls a function and saves it as a actorSearchList List
            Console.WriteLine(MovieManager.OutputActorsFromDB(search));
        }
        private void GenreSearch()
        {
            Console.WriteLine("Skriv hvilken genre vil du søge efter?");
            //Here the user decides what to search for.
            string search = Console.ReadLine();
            //Gets the movie List<Movie> from the search and makes them to a string builder in the OutputMoviesFromList.
            Console.WriteLine(MovieManager.OutputMoviesFromList(MovieManager.GetMoviesFromGenre(search)));
        }
        private void AddActor()
        {
            string firstname;
            string lastname;
            Console.WriteLine("Skriv fornavnet på den skuespiller du vil tilføje");
            firstname = Console.ReadLine();
            Console.WriteLine("Skriv efternavnet på den skespiller du vil tilføje");
            lastname = Console.ReadLine();
            Actor actor = new Actor(firstname, lastname);
            MovieManager.AddActor(actor);
            Console.WriteLine(MovieManager.OutputActorsFromDB());
        }
        private void AddMovie()
        {
            string title;
            int releaseYear;
            string genre;
            Console.WriteLine("Skriv navnet på den film du vil tilføje");
            title = Console.ReadLine();
            Console.WriteLine("Skriv året filmen blev udgivet");
            releaseYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Skriv hvilken genre filmen er");
            genre = Console.ReadLine();
            Movie movie = new Movie(title, releaseYear, genre);
            MovieManager.AddMovie(movie);
        }
    }
}
