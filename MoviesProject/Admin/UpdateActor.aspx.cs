﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_UpdateActor : System.Web.UI.Page
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
                if (Request["aid"] != null)
                {
                    CountriesDropDownList.DataSource = Countries.GetAllCountries();
                    CountriesDropDownList.DataValueField = "CountryID";
                    CountriesDropDownList.DataTextField = "Country";
                    CountriesDropDownList.DataBind();

                    Actor a1 = Actors.GetActorByID(Request["aid"]);

                    FirstNameTextBox.Text = a1.GetFirstName();
                    LastNameTextBox.Text = a1.GetLastName();
                    BornYearTextBox.Text = a1.GetBornYear().ToString();
                    CountriesDropDownList.SelectedValue = a1.GetBornCountry().ToString();

                    ActorPhoto.ImageUrl = "/Pictures/Actors/" + a1.GetActorPhoto();
                }
            }
        }
    }

    protected void UpdateActorButton_Click(object sender, EventArgs e)
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

            int actorID = int.Parse(Request["aid"]);

            Actor a1 = new Actor(actorID, firstName, lastName, bYear, country, pic);

            Actors.UpdateActor(a1);

            Response.Redirect("/Pages/OneActor.aspx?aid=" + actorID);
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
            CountryLabel.Visible = false;
            FlagLabel.Visible = false;
            BreakLabel.Visible = false;
            NewCountryTextBox.Visible = false;
            FlagFileUpload.Visible = false;

            CountriesDropDownList.DataSource = Countries.GetAllCountries();
            CountriesDropDownList.DataTextField = "Country";
            CountriesDropDownList.DataValueField = "CountryID";
            CountriesDropDownList.DataBind();
        }
    }
}
