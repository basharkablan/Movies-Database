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

public partial class Pages_Movies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["allow"] == "1")
        {
            Button1.Visible = true;
            DataGrid1.Columns[4].Visible = true;
        }

        if (Request["oid"] != null)
        {
            DataGrid1.DataSource = Movies.GetAllMoviesOrdered(Request["oid"]);
        }
        else
        {
            DataGrid1.DataSource = Movies.GetAllMovies();
        }
        DataGrid1.DataBind();
    }

    protected void DataGrid1_OnPageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        DataGrid1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/AddMovie.aspx");
    }
}
