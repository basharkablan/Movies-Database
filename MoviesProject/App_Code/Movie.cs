using System;

/// <summary>
/// Movie
/// </summary>
public class Movie
{
    private int id;
    private string name;
    private int series;
    private int year;
    private bool D3;
    private double rating;
    private int totalTime;
    private string moviePhoto;
    private string trailer;
    private int globalId;

    public Movie(int id, string name, int series, int year,
        bool D3, double rating, int totalTime, string moviePhoto, string trailer, int globalId)
    {
        this.id = id;
        this.name = name;
        this.series = series;
        this.year = year;
        this.D3 = D3;
        this.rating = rating;
        this.totalTime = totalTime;

        if (moviePhoto == "")
        {
            moviePhoto = "No Photo.jpg";
        }

        this.moviePhoto = moviePhoto;
        this.trailer = trailer;
        this.globalId = globalId;
    }

    public int GetID()
    {
        return this.id;
    }
    
    public string GetName()
    {
        return this.name;
    }
    
    public int GetSeries()
    {
        return this.series;
    }

    public int GetReleaseYear()
    {
        return this.year;
    }

    public bool Get3DAvailable()
    {
        return this.D3;
    }

    public double GetRating()
    {
        return this.rating;
    }

    public int GetTotalTime()
    {
        return this.totalTime;
    }

    public string GetMoviePhoto()
    {
        return this.moviePhoto;
    }

    public string GetTrailer()
    {
        return this.trailer;
    }

    public int GetGlobalID()
    {
        return this.globalId;
    }
}
