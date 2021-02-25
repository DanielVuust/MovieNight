using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MovieNight
{
    static class DalManager
    {
        private static string strConnection= @"Data Source = (local); Initial Catalog = MovieNight; Integrated Security = SSPI";

        public static List<Movie> GetMovies(string query)
        {
            List<Movie> movieList = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                //Opens a connectin to the database unsing the strConnection string 
                connection.Open();
                SqlCommand sqlCommand; 
                if (query == null)
                {
                    sqlCommand = new SqlCommand("SELECT * FROM Movies", connection);
                }
                else
                {

                    sqlCommand = new SqlCommand("SELECT * FROM Movies", connection);
                }
                SqlDataReader rdr = sqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["MID"];
                    string title = (string)rdr["Title"];
                    int realeseYear = (int)rdr["Year"];
                    int rating = (int)rdr["Rating"];
                    Movie movie = new Movie(id, title, realeseYear, rating);

                    movieList.Add(movie);
                }
            }
            return movieList;
        }
        public static List<Actor> GetActors()
        {
            List<Actor> actorList = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                //Opens a connectin to the database unsing the strConnection string 
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Actors", connection);
                SqlDataReader rdr = sqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["AID"];
                    string name = (string)rdr["firstName"] + " " + (string)rdr["lastName"];
                    Actor actor = new Actor(id, name);

                    actorList.Add(actor);
                }
            }
            return actorList;
        }
    }
}
