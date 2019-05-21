using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Movie : System.Web.UI.Page
{
    Movie m1;
    localhost.Service srv;

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["mid"];

        if (Request["dmid"] != null)
        {
            if (Request["dmid"] == "1")
            {
                Movies.DeleteMovie(id);
                Response.Redirect("/Pages/AllMovies.aspx");
            }
        }

        m1 = Movies.GetMovieByID(id);

        Page.Title = m1.GetName();
        GlobalIDLabel.Text = m1.GetGlobalID().ToString();
        NameLabel.Text = m1.GetName();
        SeriesLabel.Text = Series.GetSerieByID(m1.GetSeries().ToString()).GetSerie();
        ReleaseYearLabel.Text = m1.GetReleaseYear().ToString();
        if (m1.Get3DAvailable())
        {
            D3AvailableLabel.Text = "Yes";
        }
        else
        {
            D3AvailableLabel.Text = "No";
        }

        RatingIMDBLabel.Text = generate_rating_text(m1.GetRating());

        srv = new localhost.Service();

        if (Request["RatingSelected"] != null)
        {
            srv.AddRate(m1.GetGlobalID().ToString(), int.Parse(Request["RatingSelected"]));
        }

        RatingWSLabel.Text = generate_rating_text(srv.GetMovieRatingByMovieID(m1.GetGlobalID().ToString()));

        for (int i = 1; i <= 10; i++)
		{
            RateMeLabel.Text += "<img id=\"star_" + i + "\" src=\"/Pictures/Other/star_0.jpg\" onmouseover=\"stars_changed(" + i + ")\" onclick=\"submit_rating(" + i + "," + m1.GetID() + ")\" alt=\"Rate Me !\"/>";
		}

        if (srv.GetCommentsByMovie(m1.GetGlobalID().ToString()).Tables[0].Rows.Count != 0)
        {
            CommentsDataList.DataSource = srv.GetCommentsByMovie(m1.GetGlobalID().ToString());
            CommentsDataList.DataBind();
        }
        else
        {
            CommentsLabel.Text = "No Comments - " + srv.GetCommentsByMovie(m1.GetGlobalID().ToString()).Tables[0].Rows.Count;
        }

        TotalTimeLabel.Text = m1.GetTotalTime().ToString();
        GenresLabel.Text = Genres.GetGenresLinkByMovieID(id);
        ActorsLabel.Text = Actors.GetActorsLinkByMovieID(id);
        DirectorsLabel.Text = Directors.GetDirectorsLinkByMovieID(id);
        WritersLabel.Text = Writers.GetWritersLinkByMovieID(id);
        AwardsLabel.Text = Awards.GetAwardsLinkByMovieID(id);
        Image1.ImageUrl = "../Pictures/Movies/" + m1.GetMoviePhoto();

        if (m1.GetTrailer().Trim() != "")
        {
            TrailerLabel.Text = "<iframe width=\"560\" height=\"315\" src=\"http://www.youtube.com/embed/" + m1.GetTrailer() + "?rel=0&iv_load_policy=3\" frameborder=\"0\" allowfullscreen></iframe>";
        }
        MovieTrailerLabel.Text = "The Trailer of " + m1.GetName();

        if ((string)Session["allow"] == "1")
        {
            UpdateHyperLink.Visible = true;
            SlashLabel.Visible = true;
            DeleteHyperLink.Visible = true;
            UpdateHyperLink.NavigateUrl = "/Admin/UpdateMovie.aspx?mid=" + m1.GetID();
            DeleteHyperLink.NavigateUrl = "/Pages/OneMovie.aspx?mid=" + m1.GetID() + "&dmid=1";
        }
    }

    protected void AddCommentButton_Click(object sender, EventArgs e)
    {
        srv = new localhost.Service();
        string mid = Movies.GetMovieByID(Request["mid"].ToString()).GetGlobalID().ToString();
        srv.AddComment(mid, CommenterNameTextBox.Text, NewCommentTextBox.Text);

        Response.Redirect("/Pages/OneMovie.aspx?mid=" + m1.GetID());
    }

    protected string generate_rating_text(double rating)
    {
        string rating_link = "<img src=\"/Pictures/Other/";
        string str = "";
        double temp = rating;
        while (temp > 1)
        {
            temp--;
            str += rating_link + "star_1.jpg\" />";
        }
        if (temp == 1) str += rating_link + "star_1.jpg\" />";
        else
        {
            if (temp > 0.6)
                str += rating_link + "star_1.jpg\" />";
            else
            {
                if (temp > 0.3)
                    str += rating_link + "star_1.jpg\" />";
                else
                {
                    if (temp > 0)
                        str += rating_link + "star_1.jpg\" />";
                }
            }

        }
        for (int i = 10 - ((int)Math.Ceiling(rating)); i > 0; i--)
        {
            str += rating_link + "star_0.jpg\" />";
        }
        return str + " " + Math.Floor(rating*10)/10.0 + "/10";
    }

}