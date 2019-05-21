using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool mb = false, ab = false, db = false, wb = false;
        string st = Request["text"];

        st.Replace("'", "");

        DataSet mds = Movies.Search(st);
        if (mds.Tables[0].Rows.Count > 0)
        {
            MoviesLabel.Visible = true;
            MoviesDataList.Visible = true;
            MoviesDataList.DataSource = mds;
            MoviesDataList.DataBind();
            mb =true;
        }

        DataSet ads = Actors.Search(st);
        if (ads.Tables[0].Rows.Count > 0)
        {
            ActorsLabel.Visible = true;
            ActorsDataList.Visible = true;
            ActorsDataList.DataSource = ads;
            ActorsDataList.DataBind();
            ab = true;
        }

        DataSet dds = Directors.Search(st);
        if (dds.Tables[0].Rows.Count > 0)
        {
            DirectorsLabel.Visible = true;
            DirectorsDataList.Visible = true;
            DirectorsDataList.DataSource = dds;
            DirectorsDataList.DataBind();
            db = true;
        }

        DataSet wds = Writers.Search(st);
        if (wds.Tables[0].Rows.Count > 0)
        {
            WritersLabel.Visible = true;
            WritersDataList.Visible = true;
            WritersDataList.DataSource = wds;
            WritersDataList.DataBind();
            wb = true;
        }

        if (mb || ab || db || wb)
            ResultLabel.Text = "Results for \"" + st + "\".";
        else
            ResultLabel.Text = "There is no results for \"" + st + "\".";

        //Fill ResultLabel
    }
}
