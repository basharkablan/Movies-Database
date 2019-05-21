using System;

    /// <summary>
    /// Summary description for UpperClass
    /// </summary>
public abstract class UpperClass
{
    protected static DBConnection DBConn;

    public static void LoadDataBase(string str)
    {
        DBConn = new DBConnection(str);
    }
}