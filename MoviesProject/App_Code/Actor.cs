using System;

/// <summary>
/// Summary description for Actor
/// </summary>
public class Actor
{
    private int id;
    private string firstName;
    private string lastName;
    private int bornYear;
    private int bornCountry;
    private string actorPhoto;

    public Actor(int id, string firstName, string lastName, int bornYear, int bornCountry, string actorPhoto)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.bornYear = bornYear;
        this.bornCountry = bornCountry;

        if (actorPhoto == "")
        {
            actorPhoto = "No Photo.jpg";
        }
        this.actorPhoto = actorPhoto;
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

    public string GetActorPhoto()
    {
        return this.actorPhoto;
    }
}