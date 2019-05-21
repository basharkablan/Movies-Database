using System;

/// <summary>
/// Summary description for Country
/// </summary>
public class Country
{
    private int id;
    private string countryName;
    private string flag;

    public Country(int id, string countryName, string flag)
    {
        this.id = id;
        this.countryName = countryName;

        if (flag == "")
        {
            flag = "No Flag.png";
        }
        this.flag = flag;
    }

    public int GetID()
    {
        return this.id;
    }

    public string GetCountryName()
    {
        return this.countryName;
    }

    public string GetFlag()
    {
        return this.flag;
    }
}
