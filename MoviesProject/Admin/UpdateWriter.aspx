﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="UpdateWriter.aspx.cs" Inherits="Admin_UpdateWriter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <b>Update Writer</b>
    <br />
    <table>
        <tr>
            <td align="left">
                Writer First Name :
            </td>
            <td>
                <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td align="left">
                Writer Last Name :
            </td>
            <td>
                <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td align="left">
                Born Year :
            </td>
            <td>
                <asp:TextBox ID="BornYearTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td align="left">
                Born Country :
            </td>
            <td>
                <asp:DropDownList ID="CountriesDropDownList" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="CountryLabel" runat="server" Visible="false">Country : </asp:Label>
                <asp:TextBox ID="NewCountryTextBox" runat="server" Visible="false"></asp:TextBox>
                <asp:Label ID="FlagLabel" runat="server" Visible="false"><br />Flag : </asp:Label>
                <asp:FileUpload ID="FlagFileUpload" runat="server" Visible="false" />
                <asp:Label ID="BreakLabel" runat="server" Visible="false"><br /></asp:Label>
                <asp:Button ID="AddCountryButton" runat="server" Text="Add Country" 
                    onclick="AddCountryButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="left">
                Writer Photo :
            </td>
            <td>
                <asp:FileUpload ID="PhotoFileUpload" runat="server" />
            </td>
            <td>
                <asp:Image ID="WriterPhoto" runat="server" Height="70" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="UpdateWriterButton" runat="server" Text="Update Writer" 
        onclick="UpdateWriterButton_Click" />
    
</asp:Content>

