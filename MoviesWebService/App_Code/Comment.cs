using System;

/// <summary>
/// Comment
/// </summary>
public class Comment
{
    private int commentId;
    private string name;
    private string commentString;
    private int movieId; // GlobalID

    public Comment()
    {

    }

    public Comment(int commentId, string name, string commentString, int movieId)
    {
        this.commentId = commentId;
        this.name = name;
        this.commentString = commentString;
        this.movieId = movieId;
    }

    public int CommentId
    {
        get
        {
            return this.commentId;
        }
        set
        {
            this.commentId = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public string CommentString
    {
        get
        {
            return this.commentString;
        }
        set
        {
            this.commentString = value;
        }
    }

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
}
