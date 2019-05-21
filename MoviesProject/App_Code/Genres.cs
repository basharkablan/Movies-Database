using System;
using System.Data;

/// <summary>
/// Summary description for Genres
/// </summary>
public abstract class Genres : UpperClass
{
    public static DataSet GetAllGenres()
    {
        return DBConn.RunDataSetSQL("select * from Genres");
    }

    public static Genre[] GetGenresByMovieID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select GenreID from MoviesAndGenres where MovieID=" + id);

        Genre[] g1 = new Genre[ds.Tables[0].Rows.Count];

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            g1[i] = Genres.GetGenreByID(ds.Tables[0].Rows[i]["GenreID"].ToString());
        return g1;
    }

    public static Genre GetGenreByID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select Genre from Genres where GenreID=" + id);

        string genre = ds.Tables[0].Rows[0]["Genre"].ToString();

        Genre g1 = new Genre(int.Parse(id), genre);

        return g1;
    }

    public static string GetGenresLinkByMovieID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndGenres Where MovieID=" + id);

        string st = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            st = st + "<a href=OneGenre.aspx?gid=" + GetGenreByID(ds.Tables[0].Rows[i]["GenreID"].ToString()).GetID() + " >";
            st = st + GetGenreByID(ds.Tables[0].Rows[i]["GenreID"].ToString()).GetGenre();
            st = st + "</a>";
            st = st + "<br/>";
        }
        return st;
    }

    public static void AddGenre(Genre g1)
    {
        string strSql = "insert into Genres (Genre) values('" + g1.GetGenre() + "')";
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void AddGenreAndMovie(int genreID, int movieID)
    {
        string strSql = "insert into MoviesAndGenres (MovieID,GenreID) Values(" + movieID + "," + genreID + ")";
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void DeleteMovieGenres(string movieID)
    {
        string strSql = "delete from MoviesAndGenres where MovieID=" + movieID;
        DBConn.RunNonQuerySQL(strSql);
    }
}
