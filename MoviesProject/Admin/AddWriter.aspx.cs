using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_AddWriter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((string)Session["allow"] != "1")
            {
                Response.Redirect("/Pages/Forbidden.aspx");
            }
            else
            {
                CountriesDropDownList.DataSource = Countries.GetAllCountries();
                CountriesDropDownList.DataTextField = "Country";
                CountriesDropDownList.DataValueField = "CountryID";
                CountriesDropDownList.DataBind();
            }
        }
    }

    protected void AddWriterButton_Click(object sender, EventArgs e)
    {
        string firstName = FirstNameTextBox.Text.Trim();
        string lastName = LastNameTextBox.Text.Trim();

        if (firstName != "" && lastName != "")
        {
            int country = int.Parse(CountriesDropDownList.SelectedValue);
            int bYear = int.Parse(BornYearTextBox.Text.Trim());

            string pic = "";
            if (PhotoFileUpload.PostedFile != null)
            {
                if (PhotoFileUpload.PostedFile.FileName.Trim().Length > 0 && PhotoFileUpload.PostedFile.ContentLength > 0)
                {
                    pic = Path.GetFileName(PhotoFileUpload.PostedFile.FileName.Trim());

                    string dir = Server.MapPath("~/Pictures/Actors/");
                    string file = Path.GetFileName(PhotoFileUpload.PostedFile.FileName.Trim());

                    PhotoFileUpload.PostedFile.SaveAs(dir + file);
                }
            }

            Writer a1 = new Writer(0, firstName, lastName, bYear, country, pic);

            Writers.AddWriter(a1);

            int writerID = Writers.GetLastWriterID();

            Response.Redirect("/Pages/OneWriter.aspx?wid=" + writerID);
        }
    }

    protected void AddCountryButton_Click(object sender, EventArgs e)
    {
        CountryLabel.Visible = true;
        FlagLabel.Visible = true;
        BreakLabel.Visible = true;
        NewCountryTextBox.Visible = true;
        FlagFileUpload.Visible = true;

        if (NewCountryTextBox.Text.Trim() != "")
        {
            string pic = "";
            if (FlagFileUpload.PostedFile != null)
            {
                if (FlagFileUpload.PostedFile.FileName.Trim().Length > 0 && FlagFileUpload.PostedFile.ContentLength > 0)
                {
                    pic = Path.GetFileName(FlagFileUpload.PostedFile.FileName.Trim());

                    string dir = Server.MapPath("~/Pictures/CountryFlag/");
                    string file = Path.GetFileName(FlagFileUpload.PostedFile.FileName.Trim());

                    FlagFileUpload.PostedFile.SaveAs(dir + file);
                }
            }

            Country c1 = new Country(0, NewCountryTextBox.Text, pic);

            Countries.AddCountry(c1);

            NewCountryTextBox.Text = "";
            NewCountryTextBox.Visible = false;

            CountriesDropDownList.DataSource = Countries.GetAllCountries();
            CountriesDropDownList.DataTextField = "Country";
            CountriesDropDownList.DataValueField = "CountryID";
            CountriesDropDownList.DataBind();
        }
    }
}