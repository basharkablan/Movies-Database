using System;
using System.Data;

/// <summary>
/// Summary description for Countries
/// </summary>
public abstract class Countries : UpperClass
{
    public static DataSet GetAllCountries()
    {
        return DBConn.RunDataSetSQL("select * from Countries");
    }

    public static Country GetCountryByID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from Countries where CountryID=" + id);

        string countryName = ds.Tables[0].Rows[0]["Country"].ToString();
        string flag = ds.Tables[0].Rows[0]["FlagImage"].ToString();

        Country c1 = new Country(int.Parse(id), countryName, flag);

        return c1;
    }

    public static void AddCountry(Country c1)
    {
        string strSql = "insert into Countries (Country, FlagImage) values('" + c1.GetCountryName() + "', " + c1.GetFlag() + ")";
        DBConn.RunNonQuerySQL(strSql);
    }
}