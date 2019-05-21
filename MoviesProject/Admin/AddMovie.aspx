<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="AddMovie.aspx.cs" Inherits="Admin_AddMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <b>Add Movie</b>
    <br />
    <table>
        <tr>
            <td align="left">
                Global ID :
            </td>
            <td>
                <asp:TextBox ID="GlobalIDTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                * To get the Global ID go to IMDB
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
        <%--<tr>
            <td align="left">
                Award(s) :
            </td>
            <td>
                <asp:ListBox ID="AwardsListBox" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </td>
            <td>
                <asp:TextBox ID="NewAwardTextBox" runat="server" Visible="false"></asp:TextBox>
                &nbsp
                <asp:Button ID="AddAwardButton" runat="server" Text="Add Award" 
                    onclick="AddAwardButton_Click" />
            </td>
        </tr>--%>
        <tr>
            <td align="left">
                Movie Photo :
            </td>
            <td>
                <asp:FileUpload ID="PhotoFileUpload" runat="server" />
            </td>
            <td>
                
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
    <asp:Button ID="AddMovieButton" runat="server" Text="Add Movie" 
        onclick="AddMovieButton_Click" />
        
</asp:Content>

