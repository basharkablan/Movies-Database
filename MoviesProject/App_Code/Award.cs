using System;

/// <summary>
/// Summary description for Award
/// </summary>
public class Award
{
    private int id;
    private string award;
    private int year;

    public Award(int id, string award)
    {
        this.id = id;
        this.award = award;
    }

	public Award(int id, string award,int year)
	{
        this.id = id;
        this.award = award;
        this.year = year;
	}
    public int GetID()
    {
        return this.id;
    }

    public string GetAward()
    {
        return this.award;
    }

    public int GetYear()
    {
        return this.year;
    }
}
