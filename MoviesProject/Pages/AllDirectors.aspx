<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="AllDirectors.aspx.cs" Inherits="Pages_AllDirectors" Title="All Directors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <big><b>All Directors</b></big>
    <br />
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" 
        RepeatDirection="Horizontal" CellSpacing="10" CellPadding="10">
        <ItemTemplate>
            <center>
                <a href ='OneDirector.aspx?did=<%# DataBinder.Eval(Container.DataItem, "DirectorID").ToString() %>'>
                    <asp:Image ID="Image1" width="100" Height="146" runat="server" ImageUrl='<%# "../Pictures/Directors/" + Directors.GetDirectorByID(DataBinder.Eval(Container.DataItem, "DirectorID").ToString()).GetDirectorPhoto() %>' />
                </a>
                <br />
                <a href ='OneDirector.aspx?did=<%# DataBinder.Eval(Container.DataItem, "DirectorID").ToString() %>'>
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Directors.GetDirectorByID(DataBinder.Eval(Container.DataItem, "DirectorID").ToString()).GetName() %>'></asp:Label>
                </a>
                <%# GenerateMovieDirectorButton_Click(DataBinder.Eval(Container.DataItem, "DirectorID").ToString()) %>
            </center>
        </ItemTemplate>
    </asp:DataList>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Button ID="addDirectorButton" runat="server" Text="Add Director" Visible="false"
        onclick="addDirectorButton_Click"/>
</asp:Content>