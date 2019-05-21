using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataSet GetAllMovies()
    {
        DataSet ds = Movies.GetAllMovies();

        return ds;
    }

    [WebMethod]
    public double GetMovieRatingByMovieID(string id)
    {
        return Movies.GetMovieByID(id).Rating;
    }

    [WebMethod]
    public DataSet GetCommentsByMovie(string id)
    {
        return Comments.GetCommentsByMovie(id);
    }

    [WebMethod]
    public Comment GetCommentByID(string id)
    {
        return Comments.GetCommentByID(id);
    }

    [WebMethod]
    public void AddRate(string movieId, int rating)
    {
        Movies.AddRate(movieId, rating);
    }

    [WebMethod]
    public void AddComment(string movieId, string name, string comment)
    {
        Comment c1 = new Comment(0, name, comment, int.Parse(movieId));

        Comments.AddComment(c1);
    }
}