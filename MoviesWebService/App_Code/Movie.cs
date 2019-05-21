using System;

/// <summary>
/// Movie
/// </summary>
public class Movie
{
    private int movieId;
    private string movieName;
    private double rating;
    private int numberOfRaters;
    private int globalId;

    public int MovieId
    {
        get
        {
            return this.movieId;
        }
        set
        {
            this.movieId = value;
        }
    }

    public string MovieName
    {
        get
        {
            return this.movieName;
        }
        set
        {
            this.movieName = value;
        }
    }

    public double Rating
    {
        get
        {
            return this.rating;
        }
        set
        {
            this.rating = value;
        }
    }

    public int NumberOfRaters
    {
        get
        {
            return this.numberOfRaters;
        }
        set
        {
            this.numberOfRaters = value;
        }
    }

    public int GlobalId
    {
        get
        {
            return this.globalId;
        }
        set
        {
            this.globalId = value;
        }
    }

    public Movie()
    {

    }
    
    public Movie(int movieId, string movieName, double rating, int numberOfRaters, int globalId)
    {
        this.movieId = movieId;
        this.movieName = movieName;
        this.rating = rating;
        this.numberOfRaters = numberOfRaters;
        this.globalId = globalId;
    }
}
