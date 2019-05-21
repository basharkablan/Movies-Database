using System;
using System.Data;

/// <summary>
/// Summary description for Genres
/// </summary>
public abstract class Awards : UpperClass
{
    public static DataSet GetAllAwards()
    {
        return DBConn.RunDataSetSQL("select * from MoviesAwards");
    }

    public static Award[] GetAwardsByMovieID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndAwards where MovieID=" + id);

        Award[] a1 = new Award[ds.Tables[0].Rows.Count];

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Award tempAward = Awards.GetAwardByID(ds.Tables[0].Rows[i]["AwardID"].ToString());
            a1[i] = new Award(tempAward.GetID(), tempAward.GetAward(), int.Parse(ds.Tables[0].Rows[i]["Year"].ToString()));
        }
        return a1;
    }

    public static Award GetAwardByID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select Award from MoviesAwards where AwardID=" + id);

        string award = ds.Tables[0].Rows[0]["Award"].ToString();

        Award a1 = new Award(int.Parse(id), award);

        return a1;
    }

    public static string GetAwardsLinkByMovieID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from MoviesAndAwards Where MovieID=" + id);

        string st = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            st = st + "<a href=OneAward.aspx?aid=" + GetAwardByID(ds.Tables[0].Rows[i]["AwardID"].ToString()).GetID() + " >";
            st = st + GetAwardByID(ds.Tables[0].Rows[i]["AwardID"].ToString()).GetAward();
            st = st + " (" + ds.Tables[0].Rows[i]["Year"].ToString() + ")";
            st = st + "</a>";
            st = st + "<br/>";
        }
        return st;
    }

    public static void AddAward(Award a1)
    {
        string strSql = "insert into MoviesAwards (Award) values('" + a1.GetAward() + "')";
        DBConn.RunNonQuerySQL(strSql);
    }

    public static void DeleteMovieAwards(string movieID)
    {
        string strSql = "delete from MoviesAndAwards where MovieID=" + movieID;
        DBConn.RunNonQuerySQL(strSql);
    }
    
    public static void DeleteMovieAward(string movieID, string awardID, int year)
    {
        string strSql = "delete from MoviesAndAwards where MovieID=" + movieID + " And AwardID=" + awardID + " And Year=" + year;
        DBConn.RunNonQuerySQL(strSql);
    }
}
