﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="OneActor.aspx.cs" Inherits="Pages_OneActor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label ID="NameLabel1" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
    <br />
    <table border="2" style="border-color: #D3A2A4">
        <tr>
            <td>
                <asp:Image ID="ActorPhoto" runat="server" ImageUrl="" Height="314" Width="214" />
            </td>
            <td style="padding: 5px">
                <asp:Label ID="NameLabel2" runat="server"></asp:Label>
                <br />
                Born Year : 
                <asp:Label ID="bornYear" runat="server" Text=""></asp:Label>
                <br />
                Born Country : 
                <asp:Label ID="bornCountry" runat="server" Text=""></asp:Label>
                &nbsp
                <asp:Image runat="server" Height="20" ID="ContryFlag" />
                <br />Acted in :<br />
                <asp:Label ID="moviesLinks" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:HyperLink ID="UpdateHyperLink" runat="server" Visible="False">Update</asp:HyperLink>
    <asp:Label ID="SlashLabel" runat="server" Visible="false">&nbsp/&nbsp</asp:Label>
    <asp:HyperLink ID="DeleteHyperLink" runat="server" Visible="False">Delete</asp:HyperLink>
    
</asp:Content>

