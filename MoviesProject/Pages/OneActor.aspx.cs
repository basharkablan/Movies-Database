using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_OneActor : System.Web.UI.Page
{
    Actor a1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["aid"];

        if (Request["daid"] != null)
        {
            if (Request["daid"] == "1")
            {
                Actors.DeleteActor(id);
                Response.Redirect("/Pages/AllActors.aspx");
            }
        }

        a1 = Actors.GetActorByID(id);

        Page.Title = a1.GetName();
        NameLabel1.Text = a1.GetName();
        NameLabel2.Text = a1.GetName();
        bornYear.Text = a1.GetBornYear().ToString();
        bornCountry.Text = Countries.GetCountryByID(a1.GetBornCountry().ToString()).GetCountryName();
        ActorPhoto.ImageUrl = "../Pictures/Actors/" + a1.GetActorPhoto();
        ContryFlag.ImageUrl = "../Pictures/CountryFlag/" + Countries.GetCountryByID(a1.GetBornCountry().ToString()).GetFlag();
        moviesLinks.Text = Movies.GetMoviesLinkByActorID(id);

        if ((string)Session["allow"] == "1")
        {
            UpdateHyperLink.Visible = true;
            SlashLabel.Visible = true;
            DeleteHyperLink.Visible = true;
            UpdateHyperLink.NavigateUrl = "/Admin/UpdateActor.aspx?aid=" + a1.GetID();
            DeleteHyperLink.NavigateUrl = "/Pages/OneActor.aspx?aid=" + a1.GetID() + "&daid=1";
        }
    }
}
