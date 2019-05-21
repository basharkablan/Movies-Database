using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Pages_OneDirector : System.Web.UI.Page
{
    Director d1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["did"];

        if (Request["ddid"] != null)
        {
            if (Request["ddid"] == "1")
            {
                Directors.DeleteDirector(id);
                Response.Redirect("/Pages/AllDirectors.aspx");
            }
        }

        d1 = Directors.GetDirectorByID(id);

        Page.Title = d1.GetName();
        NameLabel1.Text = d1.GetName();
        NameLabel2.Text = d1.GetName();
        bornYear.Text = d1.GetBornYear().ToString();
        bornCountry.Text = Countries.GetCountryByID(d1.GetBornCountry().ToString()).GetCountryName();
        DirectorPhoto.ImageUrl = "../Pictures/Directors/" + d1.GetDirectorPhoto();
        ContryFlag.ImageUrl = "../Pictures/CountryFlag/" + Countries.GetCountryByID(d1.GetBornCountry().ToString()).GetFlag();
        moviesLinks.Text = Movies.GetMoviesLinkByDirectorID(id);

        if ((string)Session["allow"] == "1")
        {
            UpdateHyperLink.Visible = true;
            SlashLabel.Visible = true;
            DeleteHyperLink.Visible = true;
            UpdateHyperLink.NavigateUrl = "/Admin/UpdateDirector.aspx?did=" + d1.GetID();
            DeleteHyperLink.NavigateUrl = "/Pages/OneDirector.aspx?did=" + d1.GetID() + "&ddid=1";
        }
    }
}
