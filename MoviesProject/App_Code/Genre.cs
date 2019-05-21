using System;

/// <summary>
/// Summary description for Genre
/// </summary>
public class Genre
{
    private int id;
    private string genre;

	public Genre(int id, string genre)
	{
        this.id = id;
        this.genre = genre;
	}
    public int GetID()
    {
        return this.id;
    }

    public string GetGenre()
    {
        return this.genre;
    }
}
