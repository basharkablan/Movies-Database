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

public partial class Pages_OneGenre : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["gid"];
        DataGrid1.DataSource = Movies.GetMoviesByGenre(id);
        DataGrid1.DataBind();
        Page.Title = Genres.GetGenreByID(id).GetGenre();
        TitleLabel.Text = Genres.GetGenreByID(id).GetGenre() + " Movies";
    }

    protected void DataGrid1_OnPageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        DataGrid1.DataBind();
    }
}
