<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="Top10.aspx.cs" Inherits="Pages_Top10" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <center>
        <b><big>Top 10 Movies</big></b>
        
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" 
            RepeatDirection="Horizontal" CellSpacing="10" CellPadding="10">
            <ItemTemplate>
                <center>
                    <a href ='Pages/OneMovie.aspx?mid=<%# DataBinder.Eval(Container.DataItem, "MovieID", "{0}").ToString() %>'>
                        <asp:Image ID="Image2" runat="server" width="100" Height="146" ImageUrl='<%# "/Pictures/Movies/" + Movies.GetMovieByID(DataBinder.Eval(Container.DataItem, "MovieID", "{0}")).GetMoviePhoto() %>'/>
                    </a>
                    <br />
                    <a href ='Pages/OneMovie.aspx?mid=<%# DataBinder.Eval(Container.DataItem, "MovieID").ToString() %>'>
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Movies.GetMovieByID(DataBinder.Eval(Container.DataItem, "MovieID").ToString()).GetName() %>'></asp:Label>
                    </a>
                    <br />
                    <%# "Rating : " + DataBinder.Eval(Container.DataItem,"Rating","{0}") + "/10" %>
                </center>
            </ItemTemplate>
        </asp:DataList>
        
    </center>
    
</asp:Content>