using System;
using System.Data;

/// <summary>
/// Summary description for Actors
/// </summary>
public abstract class Actors : UpperClass
{
    public static DataSet GetAllActors()
    {
        return DBConn.RunDataSetSQL("select * from Actors");
    }

    public static DataSet GetAllActorsOrdered(string orderId)
    {
        switch (orderId)
        {
            case "1":
                return DBConn.RunDataSetSQL("select * from Actors order by ActorFirstName");
            case "2":
                return DBConn.RunDataSetSQL("select * from Actors order by ActorLastName");
            case "3":
                return DBConn.RunDataSetSQL("select * from Actors order by BornYear");
            default:
                return DBConn.RunDataSetSQL("select * from Actors");
        }
    }

    public static Actor GetActorByID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from Actors where ActorID=" + id);

        string firstName = ds.Tables[0].Rows[0]["ActorFirstName"].ToString();
        string lastName = ds.Tables[0].Rows[0]["ActorLastName"].ToString();
        int bornYear = int.Parse(ds.Tables[0].Rows[0]["BornYear"].ToString());
        int bornCountry = int.Parse(ds.Tables[0].Rows[0]["BornCountry"].ToString());
        string actorPhoto = ds.Tables[0].Rows[0]["ActorPhoto"].ToString();

        Actor a1 = new Actor(int.Parse(id), firstName, lastName, bornYear, bornCountry, actorPhoto);

         return a1;
    }

    public static Actor[] GetActorsByMovieID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndActors Where MovieID=" + id);

        Actor[] a1 = new Actor[ds.Tables[0].Rows.Count];

        for (int i = 0; i < a1.Length; i++)
            a1[i] = Actors.GetActorByID(ds.Tables[0].Rows[i]["ActorID"].ToString());
        return a1;
    }

    public static string GetActorsLinkByMovieID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndActors Where MovieID=" + id);

        string st = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            st = st + "<a href=OneActor.aspx?aid=" + GetActorByID(ds.Tables[0].Rows[i]["ActorID"].ToString()).GetID() + " >";
            st = st + GetActorByID(ds.Tables[0].Rows[i]["ActorID"].ToString()).GetName();
            st = st + "</a>";
            st = st + "<br/>";
        }
        return st;
    }

    public static void DeleteMovieActors(string movieID)
    {
        string strSql = "delete from MoviesAndActors where MovieID=" + movieID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void DeleteMovieActor(string movieID, string actorID)
    {
        string strSql = "delete from MoviesAndActors where MovieID=" + movieID + "And ActorID=" + actorID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void DeleteActor(string actorID)
    {
        Movies.DeleteActorMovies(actorID);
        string strSql = "delete from Actors where ActorID=" + actorID;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void AddActor(Actor a1)
    {
        string sqlCom = "insert into Actors (ActorFirstName, ActorLastName, BornYear, BornCountry, ActorPhoto) Values(";

        sqlCom += "'" + a1.GetFirstName() + "',";
        sqlCom += "'" + a1.GetLastName() + "',";
        sqlCom += a1.GetBornYear() + ",";
        sqlCom += a1.GetBornCountry() + ",";
        sqlCom += "'" + a1.GetActorPhoto() + "'";
        sqlCom += ")";

        DBConn.RunNonQuerySQL(sqlCom);
    }

    public static int GetLastActorID()
    {
        return int.Parse(DBConn.RunDataSetSQL("select max(ActorID) from Actors").Tables[0].Rows[0][0].ToString());
    }

    public static void UpdateActor(Actor a1)
    {
        string strSql = "update Actors set ";
        strSql += "ActorFirstName='" + a1.GetFirstName() + "',";
        strSql += "ActorLastName='" + a1.GetLastName() + "',";
        strSql += "BornCountry=" + a1.GetBornCountry().ToString() + ",";
        strSql += "BornYear=" + a1.GetBornYear();
        strSql += " where ActorID=" + a1.GetID();

        DBConn.RunNonQuerySQL(strSql);
    }

    public static DataSet Search(string text)
    {
        return DBConn.RunDataSetSQL("select * from Actors where ActorFirstName like '%" + text + "%' or ActorLastName like '%" + text + "%' ");
    }

    public static DataSet Get5Actors()
    {
        return DBConn.RunDataSetSQL("select top 5 * from Actors order by ActorID");
    }
}
