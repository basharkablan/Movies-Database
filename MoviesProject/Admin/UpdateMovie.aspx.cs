using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_UpdateMovie : System.Web.UI.Page
{
    Movie m1;
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
                if (Request["mid"] != null || Session["update_movie"] != null)
                {
                    if (Session["update_movie"] != null)
                    {
                        m1 = (Movie)Session["update_movie"];
                    }
                    else //FIRST VISIT
                    {
                        m1 = Movies.GetMovieByID(Request["mid"]);
                        Session["update_movie"] = m1;
                    }
                    Session["update_currentpage"] = "UpdateMovie.aspx";

                    // delete section
                    if (Request["deleteAward"] != null)
                    {
                        string[] str = Request["deleteAward"].Split(',');
                        Awards.DeleteMovieAward(m1.GetID().ToString(),str[0],int.Parse(str[1]));
                    }

                    if (Request["deleteActor"] != null)
                    {
                        Actors.DeleteMovieActor(m1.GetID().ToString(), Request["deleteActor"].ToString());
                    }

                    if (Request["deleteDirector"] != null)
                    {
                        Directors.DeleteMovieDirector(m1.GetID().ToString(), Request["deleteDirector"].ToString());
                    }

                    if (Request["deleteWriter"] != null)
                    {
                        Writers.DeleteMovieWriter(m1.GetID().ToString(), Request["deleteWriter"].ToString());
                    }

                    // add section
                    if (Request["addActor"] != null)
                    {
                        Movies.AddMovieActor(m1, Actors.GetActorByID(Request["addActor"]));
                    }

                    if (Request["addDirector"] != null)
                    {
                        Movies.AddMovieDirector(m1, Directors.GetDirectorByID(Request["addDirector"]));
                    }

                    if (Request["addWriter"] != null)
                    {
                        Movies.AddMovieWriter(m1, Writers.GetWriterByID(Request["addWriter"]));
                    }

                    GenresListBox.DataSource = Genres.GetAllGenres();
                    GenresListBox.DataTextField = "Genre";
                    GenresListBox.DataValueField = "GenreID";
                    GenresListBox.DataBind();

                    SeriesDropDownList.DataSource = Series.GetAllSeries();
                    SeriesDropDownList.DataTextField = "Series";
                    SeriesDropDownList.DataValueField = "SeriesID";
                    SeriesDropDownList.DataBind();

                    AwardsDropDownList.DataSource = Awards.GetAllAwards();
                    AwardsDropDownList.DataTextField = "Award";
                    AwardsDropDownList.DataValueField = "AwardID";
                    AwardsDropDownList.DataBind();

                    GlobalIDTextBox.Text = m1.GetGlobalID().ToString();

                    MovieNameTextBox.Text = m1.GetName();
                    int sr = m1.GetSeries();

                    for (int i = 0; i < SeriesDropDownList.Items.Count; i++)
                    {
                        if (int.Parse(SeriesDropDownList.Items[i].Value) == sr)
                        {
                            SeriesDropDownList.Items[i].Selected = true;
                        }
                    }

                    ReleaseYearTextBox.Text = m1.GetReleaseYear().ToString();

                    D3AvailableCheckBox.Checked = m1.Get3DAvailable();

                    RatingTextBox.Text = m1.GetRating().ToString();

                    TotalTimeTextBox.Text = m1.GetTotalTime().ToString();

                    Genre[] g1 = Genres.GetGenresByMovieID(m1.GetID().ToString());

                    for (int i = 0; i < GenresListBox.Items.Count; i++)
                    {
                        for (int j = 0; j < g1.Length; j++)
                        {
                            if (int.Parse(GenresListBox.Items[i].Value) == g1[j].GetID())
                            {
                                GenresListBox.Items[i].Selected = true;
                            }
                        }
                    }

                    Award[] a1 = Awards.GetAwardsByMovieID(m1.GetID().ToString());

                    for (int i = 0; i < a1.Length; i++)
                    {
                        AwardsLabel.Text += "<a href=\"UpdateMovie.aspx?mid="+m1.GetID()+"&deleteAward="+ ""+ a1[i].GetID()+"," + a1[i].GetYear() +"\" style=\"color: #FF0000; font-weight: bold\">X</a>" + "&nbsp&nbsp";
                        AwardsLabel.Text += a1[i].GetAward() + " - " + a1[i].GetYear();
                        AwardsLabel.Text += "<br />";
                    }

                    Actor[] ac1 = Actors.GetActorsByMovieID(m1.GetID().ToString());

                    for (int i = 0; i < ac1.Length; i++)
                    {
                        ActorsLabel.Text += "<a href=\"UpdateMovie.aspx?mid=" + m1.GetID() + "&deleteActor=" + "" + ac1[i].GetID() + "\" style=\"color: #FF0000; font-weight: bold\">X</a>" + "&nbsp&nbsp";
                        ActorsLabel.Text += ac1[i].GetName();
                        ActorsLabel.Text += "<br />";
                    }

                    Director[] d1 = Directors.GetDirectorsByMovieID(m1.GetID().ToString());

                    for (int i = 0; i < d1.Length; i++)
                    {
                        DirectorsLabel.Text += "<a href=\"UpdateMovie.aspx?mid=" + m1.GetID() + "&deleteDirector=" + "" + d1[i].GetID() + "\" style=\"color: #FF0000; font-weight: bold\">X</a>" + "&nbsp&nbsp";
                        DirectorsLabel.Text += d1[i].GetName();
                        DirectorsLabel.Text += "<br />";
                    }

                    Writer[] w1 = Writers.GetWritersByMovieID(m1.GetID().ToString());

                    for (int i = 0; i < w1.Length; i++)
                    {
                        WritersLabel.Text += "<a href=\"UpdateMovie.aspx?mid=" + m1.GetID() + "&deleteWriter=" + "" + w1[i].GetID() + "\" style=\"color: #FF0000; font-weight: bold\">X</a>" + "&nbsp&nbsp";
                        WritersLabel.Text += w1[i].GetName();
                        WritersLabel.Text += "<br />";
                    }

                    MoviePhoto.ImageUrl = "../Pictures/Movies/" + m1.GetMoviePhoto();

                    TrailerTextBox.Text = m1.GetTrailer();
                }
            }
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

    protected void AddAwardButton_Click(object sender, EventArgs e)
    {
        if (AwardYearTextBox.Text != "")
        {
            Award a1 = new Award(int.Parse(AwardsDropDownList.SelectedItem.Value), AwardsDropDownList.SelectedItem.Text,int.Parse(AwardYearTextBox.Text));
            m1 = Movies.GetMovieByID(Request["mid"]);
            Movies.AddMovieAward(m1, a1);
        }
        else
        {
            NewAwardTextBox.Visible = true;

            if (NewAwardTextBox.Text.Trim() != "")
            {
                Award a1 = new Award(0, NewAwardTextBox.Text.Trim());

                Awards.AddAward(a1);

                NewAwardTextBox.Text = "";
                NewAwardTextBox.Visible = false;

                AwardsDropDownList.DataSource = Awards.GetAllAwards();
                AwardsDropDownList.DataTextField = "Award";
                AwardsDropDownList.DataValueField = "AwardID";
                AwardsDropDownList.DataBind();
            }
        }
    }

    protected void AddActorButton_Click(object sender, EventArgs e)
    {
        Session["update_currentpage"] = "AllActors.aspx";
        Session["update_movie"] = Movies.GetMovieByID(Request["mid"]);
        Response.Redirect("..\\Pages\\AllActors.aspx");
    }

    protected void AddDirectorButton_Click(object sender, EventArgs e)
    {
        Session["update_currentpage"] = "AllDirectors.aspx";
        Session["update_movie"] = Movies.GetMovieByID(Request["mid"]);
        Response.Redirect("..\\Pages\\AllDirectors.aspx");
    }

    protected void AddWriterButton_Click(object sender, EventArgs e)
    {
        Session["update_currentpage"] = "AllWriters.aspx";
        Session["update_movie"] = Movies.GetMovieByID(Request["mid"]);
        Response.Redirect("..\\Pages\\AllWriters.aspx");
    }

    protected void UpdateMovieButton_Click(object sender, EventArgs e)
    {
        int id = int.Parse(Request["mid"]);
        string name = MovieNameTextBox.Text;
        int serie = int.Parse(SeriesDropDownList.SelectedValue);
        int ry = int.Parse(ReleaseYearTextBox.Text);
        bool d3 = D3AvailableCheckBox.Checked;
        double rating = double.Parse(RatingTextBox.Text);
        int tt = int.Parse(TotalTimeTextBox.Text);
        int globalId = int.Parse(GlobalIDTextBox.Text);

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
            else
            {
                pic = Movies.GetMovieByID(id.ToString()).GetMoviePhoto();
            }
        }


        string trailer = TrailerTextBox.Text;

        Movie m1 = new Movie(id, name, serie, ry, d3, rating, tt, pic, trailer, globalId);

        Movies.UpdateMovie(m1);

        Genres.DeleteMovieGenres(m1.GetID().ToString());

        for (int i = 0; i < GenresListBox.Items.Count; i++)
        {
            if (GenresListBox.Items[i].Selected)
            {
                Genres.AddGenreAndMovie(int.Parse(GenresListBox.Items[i].Value), m1.GetID());
            }
        }

        Response.Redirect("/Pages/OneMovie.aspx?mid=" + m1.GetID());
    }
}