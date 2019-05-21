using System;

/// <summary>
/// Summary description for Actor
/// </summary>
public class Director
{
    private int id;
    private string firstName;
    private string lastName;
    private int bornYear;
    private int bornCountry;
    private string directorPhoto;

    public Director(int id, string firstName, string lastName, int bornYear, int bornCountry, string directorPhoto)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.bornYear = bornYear;
        this.bornCountry = bornCountry;

        if (directorPhoto == "")
        {
            directorPhoto = "No Photo.jpg";
        }
        this.directorPhoto = directorPhoto;
    }

    public int GetID()
    {
        return this.id;
    }

    public string GetFirstName()
    {
        return this.firstName;
    }

    public string GetLastName()
    {
        return this.lastName;
    }

    public string GetName()
    {
        return this.firstName + " " + this.lastName;
    }

    public int GetBornYear()
    {
        return this.bornYear;
    }

    public int GetBornCountry()
    {
        return this.bornCountry;
    }

    public string GetDirectorPhoto()
    {
        return this.directorPhoto;
    }
}