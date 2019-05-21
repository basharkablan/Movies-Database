using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_AddMovie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((string)Session["allow"] != "1")
            {
                Response.Redirect("/Pages/Forbidden.aspx");
            }
            else
            {
                GenresListBox.DataSource = Genres.GetAllGenres();
                GenresListBox.DataTextField = "Genre";
                GenresListBox.DataValueField = "GenreID";
                GenresListBox.DataBind();

                SeriesDropDownList.DataSource = Series.GetAllSeries();
                SeriesDropDownList.DataTextField = "Series";
                SeriesDropDownList.DataValueField = "SeriesID";
                SeriesDropDownList.DataBind();

                /*
                AwardsListBox.DataSource = Awards.GetAllAwards();
                AwardsListBox.DataTextField = "Award";
                AwardsListBox.DataValueField = "AwardID";
                AwardsListBox.DataBind();
                */
            }
        }
    }

    protected void AddMovieButton_Click(object sender, EventArgs e)
    {

        string movieName = MovieNameTextBox.Text.Trim();
        string globalId = GlobalIDTextBox.Text.Trim();

        if (movieName != "" && globalId != "")
        {
            int series = int.Parse(SeriesDropDownList.SelectedValue);
            int rYear = int.Parse(ReleaseYearTextBox.Text.Trim());
            bool d3Available = D3AvailableCheckBox.Checked;
            double rating = double.Parse(RatingTextBox.Text.Trim());
            int totalTime = int.Parse(TotalTimeTextBox.Text.Trim());

            string pic = "";
            if (PhotoFileUpload.PostedFile != null)
            {
                if (PhotoFileUpload.PostedFile.FileName.Trim().Length > 0 && PhotoFileUpload.PostedFile.ContentLength > 0)
                {
                    pic = Path.GetFileName(PhotoFileUpload.PostedFile.FileName.Trim());

                    string dir = Server.MapPath("~/Pictures/Movies/");
                    string file = Path.GetFileName(PhotoFileUpload.PostedFile.FileName.Trim());

                    PhotoFileUpload.PostedFile.SaveAs(dir + file);
                }
            }

            string trailer = TrailerTextBox.Text.Trim();

            Movie m1 = new Movie(0, movieName, series, rYear, d3Available, rating, totalTime, pic, trailer, int.Parse(globalId));

            Movies.AddMovie(m1);

            int movieID = Movies.GetLastMovieID();

            for (int i = 0; i < GenresListBox.Items.Count; i++)
            {
                if (GenresListBox.Items[i].Selected)
                {
                    Genres.AddGenreAndMovie(int.Parse(GenresListBox.Items[i].Value), movieID);
                }
            }
            Response.Redirect("/Pages/OneMovie.aspx?mid="+movieID);
        }
    }

    protected void AddSeriesButton_Click(object sender, EventArgs e)
    {
        NewSeriesTextBox.Visible = true;

        if (NewSeriesTextBox.Text.Trim() != "")
        {
            Serie s1 = new Serie(0, NewSeriesTextBox.Text.Trim());

            Series.AddSerie(s1);

            NewSeriesTextBox.Text = "";
            NewSeriesTextBox.Visible = false;

            SeriesDropDownList.DataSource = Series.GetAllSeries();
            SeriesDropDownList.DataTextField = "Series";
            SeriesDropDownList.DataValueField = "SeriesID";
            SeriesDropDownList.DataBind();
        }
    }

    protected void AddGenreButton_Click(object sender, EventArgs e)
    {
        NewGenreTextBox.Visible = true;

        if (NewGenreTextBox.Text.Trim() != "")
        {
            Genre g1 = new Genre(0, NewGenreTextBox.Text.Trim());

            Genres.AddGenre(g1);

            NewGenreTextBox.Text = "";
            NewGenreTextBox.Visible = false;

            GenresListBox.DataSource = Genres.GetAllGenres();
            GenresListBox.DataTextField = "Genre";
            GenresListBox.DataValueField = "GenreID";
            GenresListBox.DataBind();
        }
    }

    /*protected void AddAwardButton_Click(object sender, EventArgs e)
    {
        NewAwardTextBox.Visible = true;

        if (NewAwardTextBox.Text.Trim() != "")
        {
            Award a1 = new Award(0, NewAwardTextBox.Text.Trim());

            Awards.AddAward(a1);

            NewAwardTextBox.Visible = false;
            NewAwardTextBox.Text = "";

            AwardsListBox.DataSource = Awards.GetAllAwards();
            AwardsListBox.DataTextField = "Award";
            AwardsListBox.DataValueField = "AwardID";
            AwardsListBox.DataBind();
    }*/
}