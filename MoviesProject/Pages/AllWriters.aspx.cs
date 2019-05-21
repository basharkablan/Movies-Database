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

public partial class Pages_AllWriters : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["allow"] == "1")
        {
            addWriterButton.Visible = true;
        }

        if (Request["oid"] != null)
        {
            DataList1.DataSource = Writers.GetAllWritersOrdered(Request["oid"]);
        }
        else
        {
            DataList1.DataSource = Writers.GetAllWriters();
        }
        DataList1.DataBind();
    }

    protected string GenerateMovieWriterButton_Click(string id)
    {
        if (Session["update_movie"] != null)
        {
            return string.Format("<br /><input type=button onClick=\"location.href='/Admin/UpdateMovie.aspx?mid={0}&addWriter={1}'\" value=\"Add\">", ((Movie)Session["update_movie"]).GetID(), id);
        }
        return "";
    }

    protected void addWriterButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/AddWriter.aspx");
    }
}
