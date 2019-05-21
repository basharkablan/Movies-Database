using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AllGenres : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataGrid1.DataSource = Genres.GetAllGenres();
        DataGrid1.DataBind();
    }
}
