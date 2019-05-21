<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="OneGenre.aspx.cs" Inherits="Pages_OneGenre" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label ID="TitleLabel" runat="server" Text=""></asp:Label>
    
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
                    <%# DataBinder.Eval(Container.DataItem, "ReleaseYear", "{0}") %>
                </ItemTemplate>
            </asp:TemplateColumn>
            
            <asp:TemplateColumn>
                <HeaderTemplate>Rating</HeaderTemplate>
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "Rating", "{0}") %>
                </ItemTemplate>
            </asp:TemplateColumn>
            
            <asp:HyperLinkColumn Text="See More.." DataNavigateUrlField="MovieID"
            DataNavigateUrlFormatString="OneMovie.aspx?mid={0}" HeaderText="See More.." />
            
        </Columns>
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
    
</asp:Content>

