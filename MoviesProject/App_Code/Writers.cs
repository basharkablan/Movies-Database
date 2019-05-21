using System;
using System.Data;

/// <summary>
/// Summary description for Actors
/// </summary>
public abstract class Writers : UpperClass
{
    public static DataSet GetAllWriters()
    {
        return DBConn.RunDataSetSQL("select * from Writers");
    }

    public static DataSet GetAllWritersOrdered(string orderId)
    {
        switch (orderId)
        {
            case "1":
                return DBConn.RunDataSetSQL("select * from Writers order by WriterFirstName");
            case "2":
                return DBConn.RunDataSetSQL("select * from Writers order by WriterLastName");
            case "3":
                return DBConn.RunDataSetSQL("select * from Writers order by BornYear");
            default:
                return DBConn.RunDataSetSQL("select * from Writers");
        }
    }

    public static Writer GetWriterByID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from Writers where WriterID=" + id);

        string firstName = ds.Tables[0].Rows[0]["WriterFirstName"].ToString();
        string lastName = ds.Tables[0].Rows[0]["WriterLastName"].ToString();
        int bornYear = int.Parse(ds.Tables[0].Rows[0]["BornYear"].ToString());
        int bornCountry = int.Parse(ds.Tables[0].Rows[0]["BornCountry"].ToString());
        string writerPhoto = ds.Tables[0].Rows[0]["WriterPhoto"].ToString();

        Writer w1 = new Writer(int.Parse(id), firstName, lastName, bornYear, bornCountry, writerPhoto);

         return w1;
    }

    public static Writer[] GetWritersByMovieID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndWriters Where MovieID=" + id);

        Writer[] w1 = new Writer[ds.Tables[0].Rows.Count];

        for (int i = 0; i < w1.Length; i++)
            w1[i] = Writers.GetWriterByID(ds.Tables[0].Rows[i]["WriterID"].ToString());
        return w1;
    }

    public static string GetWritersLinkByMovieID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndWriters Where MovieID=" + id);

        string st = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            st = st + "<a href=OneWriter.aspx?wid=" + GetWriterByID(ds.Tables[0].Rows[i]["WriterID"].ToString()).GetID() + " >";
            st = st + GetWriterByID(ds.Tables[0].Rows[i]["WriterID"].ToString()).GetName();
            st = st + "</a>";
            st = st + "<br/>";
        }
        return st;
    }

    public static void DeleteMovieWriters(string movieID)
    {
        string strSql = "delete from MoviesAndWriters where MovieID=" + movieID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void DeleteMovieWriter(string movieID, string writerID)
    {
        string strSql = "delete from MoviesAndWriters where MovieID=" + movieID + "And WriterID=" + writerID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void DeleteWriter(string writerID)
    {
        Movies.DeleteWriterMovies(writerID);
        string strSql = "delete from Writers where WriterID=" + writerID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static DataSet Search(string text)
    {
        return DBConn.RunDataSetSQL("select * from Writers where WriterFirstName like '%" + text + "%' or WriterLastName like '%" + text + "%' ");
    }

    public static void AddWriter(Writer w1)
    {
        string sqlCom = "insert into Writers (WriterFirstName, WriterLastName, BornYear, BornCountry, WriterPhoto) Values(";

        sqlCom += "'" + w1.GetFirstName() + "',";
        sqlCom += "'" + w1.GetLastName() + "',";
        sqlCom += w1.GetBornYear() + ",";
        sqlCom += w1.GetBornCountry() + ",";
        sqlCom += "'" + w1.GetWriterPhoto() + "'";
        sqlCom += ")";

        DBConn.RunNonQuerySQL(sqlCom);
    }

    public static int GetLastWriterID()
    {
        return int.Parse(DBConn.RunDataSetSQL("select max(WriterID) from Writers").Tables[0].Rows[0][0].ToString());
    }

    public static void UpdateWriter(Writer w1)
    {
        string strSql = "update Writers set ";
        strSql += "WriterFirstName='" + w1.GetFirstName() + "',";
        strSql += "WriterLastName='" + w1.GetLastName() + "',";
        strSql += "BornCountry=" + w1.GetBornCountry().ToString() + ",";
        strSql += "BornYear=" + w1.GetBornYear();
        strSql += " where WriterID=" + w1.GetID();

        DBConn.RunNonQuerySQL(strSql);
    }

    public static DataSet Get5Writers()
    {
        return DBConn.RunDataSetSQL("select top 5 * from Writers order by WriterID");
    }
}
