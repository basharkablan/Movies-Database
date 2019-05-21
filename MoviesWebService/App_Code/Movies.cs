using System;
using System.Data;

    /// <summary>
    /// The Movies Class
    /// </summary>
public abstract class Movies : UpperClass
{
    public static DataSet GetAllMovies()
    {
        return DBConn.RunDataSetSQL("select * from Movies");
    }

    public static Movie GetMovieByID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from Movies where GlobalID=" + id);

        string name = ds.Tables[0].Rows[0]["MovieName"].ToString();
        double rating = double.Parse(ds.Tables[0].Rows[0]["Rating"].ToString());
        int numberOfRaters = int.Parse(ds.Tables[0].Rows[0]["NumberOfRaters"].ToString());
        int globalId = int.Parse(ds.Tables[0].Rows[0]["GlobalID"].ToString());

        Movie m1 = new Movie(int.Parse(id), name, rating,numberOfRaters, globalId);

        return m1;
    }

    public static void UpdateMovie(Movie m1)
    {
        string strSql = "update Movies set ";
        strSql += "MovieName='" + m1.MovieName + "',";
        strSql += "Rating=" + m1.Rating + ",";
        strSql += "NumberOfRaters=" + m1.NumberOfRaters;
        strSql += " where GLobalID=" + m1.MovieId;

        DBConn.RunNonQuerySQL(strSql);
    }

    public static void AddRate(string movieId, int rating)
    {
        Movie m1 = GetMovieByID(movieId);

        double rf = (m1.Rating * m1.NumberOfRaters + rating) / (double)(m1.NumberOfRaters + 1);

        Movie m2 = new Movie(m1.MovieId, m1.MovieName, rf, m1.NumberOfRaters + 1, m1.GlobalId);

        UpdateMovie(m2);
    }
}