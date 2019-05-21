using System;
using System.Data;

    /// <summary>
/// The Comments Class
    /// </summary>
public abstract class Comments : UpperClass
{
    public static DataSet GetAllComments()
    {
        return DBConn.RunDataSetSQL("select * from Comments");
    }

    public static Comment GetCommentByID(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from Comments where CommentID=" + id);

        int commentId = int.Parse(ds.Tables[0].Rows[0]["CommentID"].ToString());
        string name = ds.Tables[0].Rows[0]["Name"].ToString();
        string comment = ds.Tables[0].Rows[0]["Comment"].ToString();
        int movieId = int.Parse(ds.Tables[0].Rows[0]["MovieID"].ToString());

        Comment c1 = new Comment(commentId, name,comment,movieId);

        return c1;
    }

    public static DataSet GetCommentsByMovie(string id)
    {
        return DBConn.RunDataSetSQL("select * from Comments where MovieID=" + id);
    }

    public static void AddComment(Comment c1)
    {
        string strSql = "insert into Comments (Name, Comment, MovieID) values("
            + "'" + c1.Name + "', "
            + "'"+ c1.CommentString + "', "
            + c1.MovieId + ")";
        DBConn.RunNonQuerySQL(strSql);
    }
}