using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["what"] == "logout")
        {
            Session["allow"] = "0";
            Response.Redirect("/Default.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "admin" && TextBox2.Text == "admin")
        {
            Session["allow"] = "1";
            Response.Redirect("/Default.aspx");
        }
        else
        {
            Label1.Visible = true;
        }
    }
}
