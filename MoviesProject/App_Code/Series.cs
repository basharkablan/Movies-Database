using System;
using System.Data;

/// <summary>
/// Summary description for Serieses
/// </summary>
public abstract class Series : UpperClass
{
    public static DataSet GetAllSeries()
    {
        return DBConn.RunDataSetSQL("select * from Series");
    }

    public static Serie GetSerieByID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select Series from Series where SeriesID="+id);

        string serie = ds.Tables[0].Rows[0]["Series"].ToString();

        Serie s1 = new Serie(int.Parse(id), serie);

        return s1;
    }

    public static void AddSerie(Serie s1)
    {
        string strSql = "insert into Series (Series) values('" + s1.GetSerie() + "')";
        DBConn.RunNonQuerySQL(strSql);
    }
}
