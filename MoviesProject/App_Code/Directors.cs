using System;
using System.Data;

/// <summary>
/// Summary description for Actors
/// </summary>
public abstract class Directors : UpperClass
{
    public static DataSet GetAllDirectors()
    {
        return DBConn.RunDataSetSQL("select * from Directors");
    }

    public static DataSet GetAllDirectorsOrdered(string orderId)
    {
        switch (orderId)
        {
            case "1":
                return DBConn.RunDataSetSQL("select * from Directors order by DirectorFirstName");
            case "2":
                return DBConn.RunDataSetSQL("select * from Directors order by DirectorLastName");
            case "3":
                return DBConn.RunDataSetSQL("select * from Directors order by BornYear");
            default:
                return DBConn.RunDataSetSQL("select * from Directors");
        }
    }

    public static Director GetDirectorByID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from Directors where DirectorID=" + id);

        string firstName = ds.Tables[0].Rows[0]["DirectorFirstName"].ToString();
        string lastName = ds.Tables[0].Rows[0]["DirectorLastName"].ToString();
        int bornYear = int.Parse(ds.Tables[0].Rows[0]["BornYear"].ToString());
        int bornCountry = int.Parse(ds.Tables[0].Rows[0]["BornCountry"].ToString());
        string directorPhoto = ds.Tables[0].Rows[0]["DirectorPhoto"].ToString();

        Director d1 = new Director(int.Parse(id), firstName, lastName, bornYear, bornCountry, directorPhoto);

        return d1;
    }

    public static Director[] GetDirectorsByMovieID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndDirectors Where MovieID=" + id);

        Director[] d1 = new Director[ds.Tables[0].Rows.Count];

        for (int i = 0; i < d1.Length; i++)
            d1[i] = Directors.GetDirectorByID(ds.Tables[0].Rows[i]["DirectorID"].ToString());
        return d1;
    }

    public static string GetDirectorsLinkByMovieID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndDirectors Where MovieID=" + id);

        string st = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            st = st + "<a href=OneDirector.aspx?did=" + GetDirectorByID(ds.Tables[0].Rows[i]["DirectorID"].ToString()).GetID() + " >";
            st = st + GetDirectorByID(ds.Tables[0].Rows[i]["DirectorID"].ToString()).GetName();
            st = st + "</a>";
            st = st + "<br/>";
        }
        return st;
    }

    public static void DeleteMovieDirectors(string movieID)
    {
        string strSql = "delete from MoviesAndDirectors where MovieID=" + movieID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void DeleteMovieDirector(string movieID, string directorID)
    {
        string strSql = "delete from MoviesAndDirectors where MovieID=" + movieID + "And DirectorID=" + directorID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void DeleteDirector(string directorID)
    {
        Movies.DeleteDirectorMovies(directorID);
        string strSql = "delete from Directors where DirectorID=" + directorID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void AddDirector(Director d1)
    {
        string sqlCom = "insert into Directors (DirectorFirstName, DirectorLastName, BornYear, BornCountry, DirectorPhoto) Values(";

        sqlCom += "'" + d1.GetFirstName() + "',";
        sqlCom += "'" + d1.GetLastName() + "',";
        sqlCom += d1.GetBornYear() + ",";
        sqlCom += d1.GetBornCountry() + ",";
        sqlCom += "'" + d1.GetDirectorPhoto() + "'";
        sqlCom += ")";

        DBConn.RunNonQuerySQL(sqlCom);
    }

    public static int GetLastDirectorID()
    {
        return int.Parse(DBConn.RunDataSetSQL("select max(DirectorID) from Directors").Tables[0].Rows[0][0].ToString());
    }

    public static void UpdateDirector(Director d1)
    {
        string strSql = "update Directors set ";
        strSql += "DirectorFirstName='" + d1.GetFirstName() + "',";
        strSql += "DirectorLastName='" + d1.GetLastName() + "',";
        strSql += "BornCountry=" + d1.GetBornCountry().ToString() + ",";
        strSql += "BornYear=" + d1.GetBornYear();
        strSql += " where DirectorID=" + d1.GetID();

        DBConn.RunNonQuerySQL(strSql);
    }

    public static DataSet Search(string text)
    {
        return DBConn.RunDataSetSQL("select * from Directors where DirectorFirstName like '%" + text + "%' or DirectorLastName like '%" + text + "%' ");
    }

    public static DataSet Get5Directors()
    {
        return DBConn.RunDataSetSQL("select top 5 * from Directors order by DirectorID");
    }
}