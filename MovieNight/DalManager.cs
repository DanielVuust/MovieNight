using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MovieNight
{
    static class DalManager
    {
        //This is the string used to connect to the local database which will later be display in the console.
        private static string strConnection= @"Data Source = (local); Initial Catalog = MovieNight; Integrated Security = SSPI";

        //This function return a List<Movie>.
        public static List<Movie> GetMoviesFromTitle(string titleSearch)
        {
            //Makes a new List 
            List<Movie> movieList = new List<Movie>();
            //The using tag makes a connection to the local database within the using tags.
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                
                //Makes a SqlCommand that is connected to the local database.
                SqlCommand sqlCommand = new SqlCommand() { Connection = connection };
                
                //If the titleSearch is null then all movies in the movie database will be returned 
                //I do this so i can either search for a return movies wuth a specific title or all movies.
                if (titleSearch == null)
                {
                    //Adds the query/CommandText to the SqlCommand.
                    sqlCommand.CommandText = "SELECT * FROM Movies";
                    
                }
                else
                {
                    //Adds the query/CommandText with a where clause to the SqlCommand.
                    sqlCommand.CommandText = "SELECT * FROM Movies WHERE Title like @search";

                    SqlParameter sp = new SqlParameter();
                    sp.ParameterName = "@search";
                    sp.Value = titleSearch;

                    sqlCommand.Parameters.Add(sp);
                }
                //Opens a connection to the local database so the data can be read.
                connection.Open();
                
                //Executes the query to the database
                SqlDataReader rdr = sqlCommand.ExecuteReader();
                //For each of the rows in the database that matches the query.
                while (rdr.Read())
                {
                    int id = (int)rdr["MID"];
                    string title = (string)rdr["Title"];
                    int releaseYear = (int)rdr["Year"];
                    string genre = (string)rdr["Genre"];
                    //Makes a new Movie object with the id title releaseYear and genre.
                    Movie movie = new Movie(id, title, releaseYear, genre);
                    //Ads the new Movie object to the list.
                    movieList.Add(movie);
                }
            }
            //Returns the List 
            return movieList;
        }
        //This function return a List<Movie>.
        public static List<Movie> GetMoviesFromGenre(string genreSearch)
        
        {
            //Makes a new List 
            List<Movie> movieList = new List<Movie>();
            //The using tag makes a connection to the local database within the using tags.
            using (SqlConnection connection = new SqlConnection(strConnection))
            {

                //Makes a SqlCommand that is connected to the local database.
                SqlCommand sqlCommand = new SqlCommand() { Connection = connection };


                //If the titleSearch is null then all movies in the movie database will be returned 
                //I do this so i can either search for a return movies wuth a specific genre or all movies.
                if (genreSearch == null)
                {
                    //Adds the query/CommandText to the SqlCommand.
                    sqlCommand.CommandText = "SELECT * FROM Movies";

                }
                else
                {
                    //Adds the query/CommandText with a where clause to the SqlCommand.
                    sqlCommand.CommandText = "SELECT * FROM Movies WHERE Genre like @search";
                    SqlParameter sp = new SqlParameter();
                    sp.ParameterName = "@search";
                    sp.Value = genreSearch;

                    sqlCommand.Parameters.Add(sp);
                }
                //Opens a connection to the local database so the data can be read.
                connection.Open();
                //Executes the query to the database
                SqlDataReader rdr = sqlCommand.ExecuteReader();
                //For each of the rows in the database that matches the query.
                while (rdr.Read())
                {
                    int id = (int)rdr["MID"];
                    string title = (string)rdr["Title"];
                    int releaseYear = (int)rdr["Year"];
                    string genre = (string)rdr["Genre"];
                    //Makes a new Movie object with the id title releaseYear and genre.
                    Movie movie = new Movie(id, title, releaseYear, genre);
                    //Ads the new Movie object to the list.
                    movieList.Add(movie);
                }
            }
            //Returns the List 
            return movieList;
        }
        public static List<Actor> GetActorsFromLastname(string nameSearch)
        {
            List<Actor> actorList = new List<Actor>();
            //The using tag makes a connection to the local database within the using tags.
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                //Makes a SqlCommand that is connected to the local database.
                SqlCommand sqlCommand = new SqlCommand() { Connection = connection };
                //If the titleSearch is null then all movies in the movie database will be returned 
                //I do this so i can either search for a return actors wuth a specific name or all actors.
                if (nameSearch == null)
                {
                    //Adds the query/CommandText to the SqlCommand.
                    sqlCommand.CommandText = "SELECT * FROM Actors";
                }
                else
                {
                    sqlCommand.CommandText = "SELECT * FROM Actors WHERE LastName like @search";
                    SqlParameter sp = new SqlParameter();
                    sp.ParameterName = "@search";
                    sp.Value = nameSearch;

                    sqlCommand.Parameters.Add(sp);
                }
                //Opens a connection to the local database so the data can be read.
                connection.Open();
                //Executes the query to the database
                SqlDataReader rdr = sqlCommand.ExecuteReader();
                //For each of the rows in the database that matches the query.
                while (rdr.Read())
                {
                    int id = (int)rdr["AID"];
                    string firstname = (string)rdr["firstName"];
                    string lastname = (string)rdr["lastName"];
                    //Makes a new Actor object with their name
                    Actor actor = new Actor(id, firstname, lastname);
                    //Ads the new Movie object to the list
                    actorList.Add(actor);
                }
            }
            return actorList;
        }
        public static Actor InsertActor(Actor a)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                int newId;
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand() { Connection = connection, CommandText = 
                    "INSERT INTO Actors (FirstName, LastName) OUTPUT INSERTED.AID VALUES (@firstname, @lastname)" };
                sqlCommand.Parameters.Add(new SqlParameter("@firstname", a.firstname));
                sqlCommand.Parameters.Add(new SqlParameter("@lastname", a.lastname));

                newId = (Int32)sqlCommand.ExecuteScalar();
                a.id = newId;
            }
            return a;

        }
        public static Movie InsertMovie(Movie m)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                int newId;
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandText =
                    "INSERT INTO Movies (Title, Year, Genre) OUTPUT INSERTED.MID VALUES (@title, @releaseYear, @genre)"
                };
                sqlCommand.Parameters.Add(new SqlParameter("@title", m.title));
                sqlCommand.Parameters.Add(new SqlParameter("@releaseYear", m.releaseYear));
                sqlCommand.Parameters.Add(new SqlParameter("@genre", m.genre));

                newId = (Int32)sqlCommand.ExecuteScalar();
                m.id = newId;
            }
            return m;
        }
    }
}
