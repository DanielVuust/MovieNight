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
            Console.WriteLine(MovieManager.OutputMoviesFromTitle());
            Console.WriteLine("yo");

            Console.WriteLine(MovieManager.OutputActorsFromLastname());

            Program program = new Program();
            //I use a while loop because the user should be able to make multiple searches.
            while (true)
            {
                Console.WriteLine("Vil du søge efter en skuespiller eller en film? \n 1. Film \n 2. Skuespiller \n 3. Genre");
                //A switch statemant so i can call the function that is related the what the user wants.
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine(" 1. Vis alle film \n 2. Søg efter titel \n 3. Søg efter genre \n 4. Tilføj film 5. Updater film data \n 6. Slet film");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                program.ShowAllMovies();
                                break;
                            case "2":
                                Console.Clear();
                                program.MovieSearch();
                                break;
                            case "3":
                                Console.Clear();
                                program.GenreSearch();
                                break;
                            case "4":
                                Console.Clear();
                                program.AddMovie();
                                break;
                            case "5":
                                Console.Clear();
                                program.EditMovie();
                                break;
                            case "6":
                                Console.Clear();
                                program.RemoveMovie();
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine(" 1. Vis alle skuespillere \n 2. Søg efter efternavn \n 3. Tilføj skuespiller 4. Updater skespiller data \n 5. Slet skuespiller");
                        
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                program.ShowAllActors();
                                break;
                            case "2":
                                Console.Clear();
                                program.ActorSearch();
                                break;
                            case "3":
                                Console.Clear();
                                program.AddActor();
                                break;
                            case "4":
                                Console.Clear();
                                program.EditActor();
                                break;
                            case "5":
                                Console.Clear();
                                program.RemoveActor();
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine(" 1. Vis all genre \n 2. Tilføj En genre \n 3. Updater genre data \n 4. Slet genre");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                program.ShowAlllGenres();
                                break;
                            case "2":
                                Console.Clear();
                                program.AddGenre();
                                break;
                            case "3":
                                Console.Clear();
                                program.EditGenre();
                                break;
                            case "4":
                                Console.Clear();
                                program.RemoveGenre();
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
        private void ShowAllMovies()
        {
            Console.WriteLine(MovieManager.OutputMoviesFromTitle()); 
        }
        private void ShowAllActors()
        {
            Console.WriteLine(MovieManager.OutputActorsFromLastname());
        }
        private void ShowAlllGenres()
        {
            Console.WriteLine(MovieManager.OutputGenreFromGenre());
        }
        private void MovieSearch()
        {
            Console.WriteLine("Skriv hvad du vil søge efter");
            //Here the user decides what to search for.
            string search = Console.ReadLine();
            //Calls a function and saves it as a movieSearchList List
            Console.WriteLine(MovieManager.OutputMoviesFromTitle(search));
        }
        private void ActorSearch()
        {
            Console.WriteLine("Skriv hvad du vil søge efter");
            //Here the user decides what to search for.
            string search = Console.ReadLine();
            //Calls a function and saves it as a actorSearchList List
            Console.WriteLine(MovieManager.OutputActorsFromLastname(search));
        }
        private void GenreSearch()
        {
            Console.WriteLine("Lige nu findes der de her genrer");
            Console.WriteLine(MovieManager.OutputGenreFromGenre());
            Console.WriteLine("Skriv hvilken genre vil du søge efter?");
            
            string search = Console.ReadLine();
            //Gets the movie List<Movie> from the search and makes them to a string builder in the OutputMoviesFromList.
            Console.WriteLine(MovieManager.OutputMoviesFromGenre(search));
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
            Console.WriteLine(MovieManager.OutputActorsFromLastname());
        }
        private void AddMovie()
        {
            string title;
            int releaseYear;
            List<string> genreList = new List<string>();
            Console.WriteLine("Skriv navnet på den film du vil tilføje");
            title = Console.ReadLine();
            Console.WriteLine("Skriv året filmen blev udgivet");
            releaseYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(MovieManager.OutputGenreFromGenre());
            while (true)
            {
                Console.WriteLine("Skriv hvilken en af de her genrer filmen er. Skriv 0 når du er færdig med at tilføje genrer");
                string genre = Console.ReadLine();
                if (genre == "0")
                {
                    break;
                }
                else
                {
                    genreList.Add(genre);
                }
            }
            Movie movie = new Movie(genreList, title, releaseYear);
            MovieManager.AddMovie(movie);
        }
        private void AddGenre()
        {
            Console.WriteLine("Skriv den genre du vil tilføje");
            MovieManager.AddGenre(Console.ReadLine());
        }
        private void EditMovie()
        {
            Console.WriteLine(MovieManager.OutputMoviesFromTitle());
            Console.WriteLine("Skriv id'et på den film du vil ændre på");
        }
        private void EditActor()
        {

        }
        private void EditGenre()
        {

        }
        private void RemoveMovie()
        {
            Console.WriteLine(MovieManager.OutputMoviesFromTitle());
            Console.WriteLine("Skriv id'et på den film du vil fjerne");
            if (MovieManager.RemoveMovie(Console.ReadLine()))
                Console.WriteLine("Filmen er nu blevet fjernet");
            else
                Console.WriteLine("Filmen med den indtastede id kunne ikke fjernes");
            
        }
        private void RemoveActor()
        {
            Console.WriteLine(MovieManager.OutputActorsFromLastname());
            Console.WriteLine("Skriv id'et på den skuespillder du vil slette");
            if (MovieManager.RemoveActor(Console.ReadLine()))
                Console.WriteLine("Skuespilleren er nu blevet fjernet");
            else
                Console.WriteLine("Skuespilleren med den indtastede id kunne ikke fjernes");
        }
        private void RemoveGenre()
        {
            Console.WriteLine(MovieManager.OutputGenreFromGenre());
            Console.WriteLine("yo");
            if (MovieManager.RemoveGenre(Console.ReadLine()))
                Console.WriteLine("success");
            else
                Console.WriteLine("fail");
        }
    }
}
