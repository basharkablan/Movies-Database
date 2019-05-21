using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AllActors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["allow"] == "1")
        {
            addActorButton.Visible = true;
        }

        if (Request["oid"] != null)
        {
            DataList1.DataSource = Actors.GetAllActorsOrdered(Request["oid"]);
        }
        else
        {
            DataList1.DataSource = Actors.GetAllActors();
        }
        DataList1.DataBind();
    }

    protected string GenerateMovieActorButton_Click(string id)
    {
        if (Session["update_movie"] != null)
        {
            return string.Format("<br /><input type=button onClick=\"location.href='/Admin/UpdateMovie.aspx?mid={0}&addActor={1}'\" value=\"Add\">", ((Movie)Session["update_movie"]).GetID(), id);
        }
        return "";
    }

    protected void addActorButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/AddActor.aspx");
    }
}