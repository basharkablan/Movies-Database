<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="Pages_LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <b><big>Login Page</big></b>
    <br />
    <br />
    <table>
        <tr>
            <td>
                Username : 
            </td>
            <td align="left">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="SingleLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Password : 
            </td>
            <td align="left">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
    
    <asp:Label ID="Label1" runat="server" Text="Wrong username or password !!" Visible="false"></asp:Label>
    
</asp:Content>

