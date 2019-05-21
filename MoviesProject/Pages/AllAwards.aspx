<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="AllAwards.aspx.cs" Inherits="Pages_AllAwards" Title="All Awards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <b>All Awards</b>
    
    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" 
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" CellSpacing="2">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" Mode="NumericPages" />
        <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            <asp:HyperLinkColumn HeaderText="Choose Award"
            DataNavigateUrlFormatString="OneAward.aspx?aid={0}"
            DataTextField="Award" DataNavigateUrlField="AwardID">
            </asp:HyperLinkColumn>
        </Columns>
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
    
</asp:Content>