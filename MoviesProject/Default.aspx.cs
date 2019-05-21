using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MoviesDataList.DataSource = Movies.GetTop5Movies();
        MoviesDataList.DataBind();

        ActorsDataList.DataSource = Actors.Get5Actors();
        ActorsDataList.DataBind();

        DirectorsDataList.DataSource = Directors.Get5Directors();
        DirectorsDataList.DataBind();

        WritersDataList.DataSource = Writers.Get5Writers();
        WritersDataList.DataBind();
    }
}
