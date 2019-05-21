<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="AllMovies.aspx.cs" Inherits="Pages_Movies" Title="All Movies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <b>All Movies</b>
            
    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" OnPageIndexChanged="DataGrid1_OnPageIndexChanged" 
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" CellSpacing="2">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" Mode="NumericPages" />
        <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            
            <asp:BoundColumn DataField="MovieName" HeaderText="Movie Name"></asp:BoundColumn>
            
            <asp:TemplateColumn>
            <HeaderTemplate>Release Year</HeaderTemplate>
            <ItemTemplate>
            <%# DataBinder.Eval(Container.DataItem, "ReleaseYear", "{0}")%>
            </ItemTemplate>
            </asp:TemplateColumn>
            
            <asp:TemplateColumn>
                <HeaderTemplate>Rating</HeaderTemplate>
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "Rating", "{0}")%>
                </ItemTemplate>
            </asp:TemplateColumn>
            
            <asp:HyperLinkColumn Text="See More.." DataNavigateUrlField="MovieID"
            DataNavigateUrlFormatString="OneMovie.aspx?mid={0}" HeaderText="See More.." />
            
            <asp:TemplateColumn Visible="False">
                <HeaderTemplate>Update / Delete</HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="UpdateHyperLink" runat="server"
                     NavigateUrl='<%# "/Admin/UpdateMovie.aspx?mid=" + DataBinder.Eval(Container.DataItem, "MovieID", "{0}") %>'>Update</asp:HyperLink>
                    &nbsp/&nbsp
                    <asp:HyperLink ID="DeleteHyperLink" runat="server"
                     NavigateUrl='<%# "/Pages/OneMovie.aspx?mid=" + DataBinder.Eval(Container.DataItem, "MovieID", "{0}")+"&dmid=1" %>'>Delete</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateColumn>
            
        </Columns>
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Button ID="Button1" runat="server" Text="Add Movie" Visible="false"
        onclick="Button1_Click" />
</asp:Content>