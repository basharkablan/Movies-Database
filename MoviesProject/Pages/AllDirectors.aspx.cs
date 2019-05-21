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

public partial class Pages_AllDirectors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["allow"] == "1")
        {
            addDirectorButton.Visible = true;
        }

        if (Request["oid"] != null)
        {
            DataList1.DataSource = Directors.GetAllDirectorsOrdered(Request["oid"]);
        }
        else
        {
            DataList1.DataSource = Directors.GetAllDirectors();
        }
        DataList1.DataBind();
    }

    protected string GenerateMovieDirectorButton_Click(string id)
    {
        if (Session["update_movie"] != null)
        {
            return string.Format("<br /><input type=button onClick=\"location.href='/Admin/UpdateMovie.aspx?mid={0}&addDirector={1}'\" value=\"Add\">", ((Movie)Session["update_movie"]).GetID(), id);
        }
        return "";
    }

    protected void addDirectorButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/AddDirector.aspx");
    }
}
