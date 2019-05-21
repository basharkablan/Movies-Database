using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if ((string)Session["allow"] == "1")
        {
            Label1.Visible = false;
            HyperLink1.Visible = false;
            Label2.Visible = true;


            //MOVIE UPDATE START
            string current_page = Request.RawUrl; //THE TRUE current page
            current_page = current_page.Substring(current_page.LastIndexOf('/') + 1);
            if (current_page.IndexOf('?') != -1)
                current_page = current_page.Substring(0, current_page.IndexOf('?'));

            if (Session["update_movie"] != null)
            {
                if (current_page != (Session["update_currentpage"].ToString()))
                {
                    //Kill the session
                    Session["update_movie"] = null; //if we're at the wrong page, cancel the updating.
                    Session["update_currentpage"] = null; //if we're at the wrong page, cancel the updating.
                    Response.Redirect(Request.RawUrl); //force another page load
                }
                else //we're at the right page
                {
                    //if (current_page != "admin_game.aspx") //We add a "cancel" button if this isn't the update page. 
                        //cancel_add.Visible = true;
                }
            }

            //MOVIE UPDATE END
        }

        if (SearchTextBox.Text != "")
        {
            Response.Redirect("/Pages/Search.aspx?text=" + SearchTextBox.Text);
        }
    }
}
