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

    public static DataSet GetAllMoviesOrdered(string orderId)
    {
        switch (orderId)
        {
            case "1":
                return DBConn.RunDataSetSQL("select * from Movies order by MovieName");
            case "2":
                return DBConn.RunDataSetSQL("select * from Movies order by ReleaseYear desc");
            case "3":
                return DBConn.RunDataSetSQL("select * from Movies order by Rating desc");
            case "4":
                return DBConn.RunDataSetSQL("select * from Movies order by TotalTime desc");
            default:
                return DBConn.RunDataSetSQL("select * from Movies");
        }
    }

    public static Movie GetMovieByID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from Movies where MovieID=" + id);

        string name = ds.Tables[0].Rows[0]["MovieName"].ToString();
        int series = int.Parse(ds.Tables[0].Rows[0]["Series"].ToString());
        int year = int.Parse(ds.Tables[0].Rows[0]["ReleaseYear"].ToString());
        bool D3 = bool.Parse(ds.Tables[0].Rows[0]["3DAvailable"].ToString());
        double rating = double.Parse(ds.Tables[0].Rows[0]["Rating"].ToString());
        int totalTime = int.Parse(ds.Tables[0].Rows[0]["TotalTime"].ToString());
        string moviePhoto = ds.Tables[0].Rows[0]["MoviePhoto"].ToString();
        string trailer = ds.Tables[0].Rows[0]["Trailer"].ToString();
        int globalId = int.Parse(ds.Tables[0].Rows[0]["GlobalID"].ToString());

        Movie m1 = new Movie(int.Parse(id), name, series, year, D3, rating, totalTime, moviePhoto, trailer, globalId);

        return m1;
    }

    public static string GetMoviesLinkByActorID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndActors Where ActorID=" + id);

        string st = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            st = st + "<a href=OneMovie.aspx?mid=" + GetMovieByID(ds.Tables[0].Rows[i]["MovieID"].ToString()).GetID() + " >";
            st = st + GetMovieByID(ds.Tables[0].Rows[i]["MovieID"].ToString()).GetName();
            st = st + "</a>";
            st = st + "<br/>";
        }
        return st;
    }

    public static string GetMoviesLinkByDirectorID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndDirectors Where DirectorID=" + id);

        string st = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            st = st + "<a href=OneMovie.aspx?mid=" + GetMovieByID(ds.Tables[0].Rows[i]["MovieID"].ToString()).GetID() + " >";
            st = st + GetMovieByID(ds.Tables[0].Rows[i]["MovieID"].ToString()).GetName();
            st = st + "</a>";
            st = st + "<br/>";
        }
        return st;
    }
    
    public static string GetMoviesLinkByWriterID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndWriters Where WriterID=" + id);

        string st = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            st = st + "<a href=OneMovie.aspx?mid=" + GetMovieByID(ds.Tables[0].Rows[i]["MovieID"].ToString()).GetID() + " >";
            st = st + GetMovieByID(ds.Tables[0].Rows[i]["MovieID"].ToString()).GetName();
            st = st + "</a>";
            st = st + "<br/>";
        }
        return st;
    }
    
    public static string GetMoviesLinkByGenreID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndGenres Where GenreID=" + id);

        string st = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            st = st + "<a href=OneMovie.aspx?mid=" + GetMovieByID(ds.Tables[0].Rows[i]["MovieID"].ToString()).GetID() + " >";
            st = st + GetMovieByID(ds.Tables[0].Rows[i]["MovieID"].ToString()).GetName();
            st = st + "</a>";
            st = st + "<br/>";
        }
        return st;
    }

    public static DataSet GetMoviesByGenre(string id)
    {
        return DBConn.RunDataSetSQL("select * from GetMoviesByGenre where GenreID=" + id);
    }
    
    public static DataSet GetMoviesByAward(string id)
    {
        return DBConn.RunDataSetSQL("select * from GetMoviesByAward where AwardID=" + id);
    }
    
    public static DataSet GetTop10Movies()
    {
        return DBConn.RunDataSetSQL("select * from Top10Movies");
    }

    public static DataSet GetTop5Movies()
    {
        return DBConn.RunDataSetSQL("select top 5 * from Movies order by Rating desc");
    }
    
    public static void AddMovie(Movie m1)
    {
        string sqlCom = "insert into Movies (MovieName,Series,ReleaseYear,3DAvailable,Rating,TotalTime,MoviePhoto,Trailer,GlobalID) Values(";

        sqlCom += "'" + m1.GetName() + "',";
        sqlCom += m1.GetSeries() + ",";
        sqlCom += m1.GetReleaseYear() + ",";
        sqlCom += m1.Get3DAvailable() + ",";
        sqlCom += m1.GetRating() + ",";
        sqlCom += m1.GetTotalTime() + ",";
        sqlCom += "'" + m1.GetMoviePhoto() + "',";
        sqlCom += "'" + m1.GetTrailer() + "',";
        sqlCom += m1.GetGlobalID();
        sqlCom += ")";

        DBConn.RunNonQuerySQL(sqlCom);
    }
    
    public static int GetLastMovieID()
    {
        return int.Parse(DBConn.RunDataSetSQL("select max(MovieID) from Movies").Tables[0].Rows[0][0].ToString());
    }

    public static void UpdateMovie(Movie m1)
    {
        string strSql = "update Movies set ";
        strSql += "MovieName='" + m1.GetName() + "',";
        strSql += "Series=" + m1.GetSeries().ToString() + ",";
        strSql += "ReleaseYear=" + m1.GetReleaseYear() + ",";
        strSql += "3DAvailable=" + m1.Get3DAvailable() + ",";
        strSql += "Rating=" + m1.GetRating() + ",";
        strSql += "TotalTime=" + m1.GetTotalTime() + ",";
        strSql += "MoviePhoto='" + m1.GetMoviePhoto() + "',";
        strSql += "Trailer='" + m1.GetTrailer() + "',";
        strSql += "GlobalID=" + m1.GetGlobalID();
        strSql += " where MovieID="+m1.GetID();

        DBConn.RunNonQuerySQL(strSql);
    }
    
    public static void DeleteMovie(string id)
    {
        Genres.DeleteMovieGenres(id);
        Actors.DeleteMovieActors(id);
        Directors.DeleteMovieDirectors(id);
        Writers.DeleteMovieWriters(id);
        Awards.DeleteMovieAwards(id);
        DBConn.RunNonQuerySQL("delete from Movies where MovieID=" + id);
    }
    
    public static void DeleteActorMovies(string actorID)
    {
        string strSql = "delete from MoviesAndActors where ActorID=" + actorID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void DeleteDirectorMovies(string directorID)
    {
        string strSql = "delete from MoviesAndDirectors where DirectorID=" + directorID;
        DBConn.RunNonQuerySQL(strSql);
    }
    
    public static void DeleteWriterMovies(string writerID)
    {
        string strSql = "delete from MoviesAndWriters where WriterID=" + writerID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static DataSet Search(string text)
    {
        return DBConn.RunDataSetSQL("select * from Movies where MovieName like '%" + text + "%'");
    }

    public static void AddMovieAward(Movie m1, Award a1)
    {
        string sqlCom = String.Format("INSERT INTO MoviesAndAwards(MovieID,AwardID,[Year]) VALUES({0},{1},{2})", m1.GetID(), a1.GetID(), a1.GetYear());
        DBConn.RunNonQuerySQL(sqlCom);
    }
    
    public static void AddMovieActor(Movie m1, Actor a1)
    {
        string sqlCom = String.Format("INSERT INTO MoviesAndActors(MovieID,ActorID) VALUES({0},{1})", m1.GetID(), a1.GetID());
        DBConn.RunNonQuerySQL(sqlCom);
    }
    
    public static void AddMovieDirector(Movie m1, Director d1)
    {
        string sqlCom = String.Format("INSERT INTO MoviesAndDirectors(MovieID,DirectorID) VALUES({0},{1})", m1.GetID(), d1.GetID());
        DBConn.RunNonQuerySQL(sqlCom);
    }
    
    public static void AddMovieWriter(Movie m1, Writer w1)
    {
        string sqlCom = String.Format("INSERT INTO MoviesAndWriters(MovieID,WriterID) VALUES({0},{1})", m1.GetID(), w1.GetID());
        DBConn.RunNonQuerySQL(sqlCom);
    }
}