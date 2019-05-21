<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="UpdateMovie.aspx.cs" Inherits="Admin_UpdateMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <b>Update Movie</b>
    <br />
    <table border="1">
        <tr>
            <td align="left">
                Global ID :
            </td>
            <td>
                <asp:TextBox ID="GlobalIDTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                * To get the Global ID go to IMDB
                <br />
                * http://www.imdb.com/title/tt0133093/?ref_=sr_1 --> 133093
            </td>
        </tr>
        <tr>
            <td align="left">
                Movie Name :
            </td>
            <td>
                <asp:TextBox ID="MovieNameTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td align="left">
                Series :
            </td>
            <td>
                <asp:DropDownList ID="SeriesDropDownList" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="NewSeriesTextBox" runat="server" Visible="false"></asp:TextBox>
                    &nbsp
                <asp:Button ID="AddSeriesButton" runat="server" Text="Add Series" 
                    onclick="AddSeriesButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="left">
                Release Year :
            </td>
            <td>
                <asp:TextBox ID="ReleaseYearTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td align="left">
                3D Available :
            </td>
            <td>
                <asp:CheckBox ID="D3AvailableCheckBox" runat="server" />
            </td>
            <td>
                
            </td>
         </tr>
         <tr>
            <td align="left">
                Rating :
            </td>
            <td>
                <asp:TextBox ID="RatingTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td align="left">
                Total Time :
            </td>
            <td>
                <asp:TextBox ID="TotalTimeTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td align="left">
                Genre(s) :
            </td>
            <td>
                <asp:ListBox ID="GenresListBox" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </td>
            <td>
                <asp:TextBox ID="NewGenreTextBox" runat="server" Visible="false"></asp:TextBox>
                    &nbsp
                <asp:Button ID="AddGenreButton" runat="server" Text="Add Genre" 
                    onclick="AddGenreButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="left">
                Award(s) :
            </td>
                <td>
                    <asp:Label ID="AwardsLabel" runat="server" Text=""></asp:Label>
                    
                    <asp:DropDownList ID="AwardsDropDownList" runat="server"></asp:DropDownList>
                    &nbsp
                    Year :<asp:TextBox ID="AwardYearTextBox" runat="server" Width="35"></asp:TextBox>
                </td>
            <td>
                <asp:TextBox ID="NewAwardTextBox" runat="server" Visible="false"></asp:TextBox>
                &nbsp
                <asp:Button ID="AddAwardButton" runat="server" Text="Add Award" 
                    onclick="AddAwardButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="left">
                Actor(s) :
            </td>
            <td>
                <asp:Label ID="ActorsLabel" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Button ID="AddActorButton" runat="server" Text="Add Actor" 
                    onclick="AddActorButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="left">
                Director(s) :
            </td>
            <td>
                <asp:Label ID="DirectorsLabel" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Button ID="AddDirectorButton" runat="server" Text="Add Director"
                    onclick="AddDirectorButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="left">
                Writer(s) :
            </td>
            <td>
                <asp:Label ID="WritersLabel" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Button ID="AddWriterButton" runat="server" Text="Add Writer"
                    onclick="AddWriterButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="left">
                Movie Photo :
            </td>
            <td>
                <asp:FileUpload ID="PhotoFileUpload" runat="server" />
            </td>
            <td>
                <asp:Image ID="MoviePhoto" runat="server" Height="70" />
            </td>
        </tr>
        <tr>
            <td align="left">
                *Trailer in Youtube :
            </td>
            <td>
                <asp:TextBox ID="TrailerTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                
            </td>
        </tr>
    </table>
    <br />
    * such as "http://www.youtube.com/watch?v=A6XUVjK9W4o" put "A6XUVjK9W4o"
    <br />
    <asp:Button ID="UpdateMovieButton" runat="server" Text="Update Movie" 
        onclick="UpdateMovieButton_Click" />
    
</asp:Content>

