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

public partial class Pages_OneWriter : System.Web.UI.Page
{
    Writer w1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["wid"];

        if (Request["dwid"] != null)
        {
            if (Request["dwid"] == "1")
            {
                Writers.DeleteWriter(id);
                Response.Redirect("/Pages/AllWriters.aspx");
            }
        }

        w1 = Writers.GetWriterByID(id);

        Page.Title = w1.GetName();
        NameLabel1.Text = w1.GetName();
        NameLabel2.Text = w1.GetName();
        bornYear.Text = w1.GetBornYear().ToString();
        bornCountry.Text = Countries.GetCountryByID(w1.GetBornCountry().ToString()).GetCountryName();
        WriterPhoto.ImageUrl = "../Pictures/Writers/" + w1.GetWriterPhoto();
        ContryFlag.ImageUrl = "../Pictures/CountryFlag/" + Countries.GetCountryByID(w1.GetBornCountry().ToString()).GetFlag();
        moviesLinks.Text = Movies.GetMoviesLinkByWriterID(id);

        if ((string)Session["allow"] == "1")
        {
            UpdateHyperLink.Visible = true;
            SlashLabel.Visible = true;
            DeleteHyperLink.Visible = true;
            UpdateHyperLink.NavigateUrl = "/Admin/UpdateWriter.aspx?wid=" + w1.GetID();
            DeleteHyperLink.NavigateUrl = "/Pages/OneWriter.aspx?wid=" + w1.GetID() + "&dwid=1";
        }
    }
}
