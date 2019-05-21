<%@ Page Title="All Genres" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="AllGenres.aspx.cs" Inherits="Pages_AllGenres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" 
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" CellSpacing="2">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" Mode="NumericPages" />
        <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            <asp:HyperLinkColumn HeaderText="Choose Genre"
            DataNavigateUrlFormatString="OneGenre.aspx?gid={0}"
            DataTextField="Genre" DataNavigateUrlField="GenreID">
            </asp:HyperLinkColumn>
        </Columns>
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
    
</asp:Content>