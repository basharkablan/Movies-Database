<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <center>
        
        <asp:Image ID="Image1" runat="server" ImageUrl="/Pictures/Other/welcome-to-my-site.gif" />
        
        <br />
        <b>Movies Section</b>
        <br />
        
        <asp:DataList ID="MoviesDataList" runat="server" RepeatColumns="5" 
            RepeatDirection="Horizontal" CellSpacing="10" CellPadding="10">
            <ItemTemplate>
                <center>
                    <a href ='Pages/OneMovie.aspx?mid=<%# DataBinder.Eval(Container.DataItem, "MovieID", "{0}").ToString() %>'>
                        <asp:Image ID="Image2" runat="server" width="75" Height="110" ImageUrl='<%# "/Pictures/Movies/" + Movies.GetMovieByID(DataBinder.Eval(Container.DataItem, "MovieID", "{0}")).GetMoviePhoto() %>'/>
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
        
        <a href="/Pages/AllMovies.aspx">See All Movies..</a>
        
        <hr width="75%" />
        
        <b>Actors Section</b>
        <br />
        
        <asp:DataList ID="ActorsDataList" runat="server" RepeatColumns="5" 
            RepeatDirection="Horizontal" CellSpacing="10" CellPadding="10">
            <ItemTemplate>
                <center>
                    <a href ='Pages/OneActor.aspx?aid=<%# DataBinder.Eval(Container.DataItem, "ActorID", "{0}").ToString() %>'>
                        <asp:Image ID="Image2" runat="server" width="75" Height="110" ImageUrl='<%# "/Pictures/Actors/" + Actors.GetActorByID(DataBinder.Eval(Container.DataItem, "ActorID", "{0}")).GetActorPhoto() %>'/>
                    </a>
                    <br />
                    <a href ='Pages/OneActor.aspx?aid=<%# DataBinder.Eval(Container.DataItem, "ActorID").ToString() %>'>
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Actors.GetActorByID(DataBinder.Eval(Container.DataItem, "ActorID").ToString()).GetName() %>'></asp:Label>
                    </a>
                    <br />
                    <%# "Born Year : " + DataBinder.Eval(Container.DataItem,"BornYear","{0}") %>
                </center>
            </ItemTemplate>
        </asp:DataList>
        
        <a href="/Pages/AllActors.aspx">See All Actors..</a>
        
        <hr width="75%" />
        
        <b>Directors Section</b>
        <br />
        
        <asp:DataList ID="DirectorsDataList" runat="server" RepeatColumns="5" 
            RepeatDirection="Horizontal" CellSpacing="10" CellPadding="10">
            <ItemTemplate>
                <center>
                    <a href ='Pages/OneDirector.aspx?did=<%# DataBinder.Eval(Container.DataItem, "DirectorID", "{0}").ToString() %>'>
                        <asp:Image ID="Image2" runat="server" width="75" Height="110" ImageUrl='<%# "/Pictures/Directors/" + Directors.GetDirectorByID(DataBinder.Eval(Container.DataItem, "DirectorID", "{0}")).GetDirectorPhoto() %>'/>
                    </a>
                    <br />
                    <a href ='Pages/OneDirector.aspx?did=<%# DataBinder.Eval(Container.DataItem, "DirectorID").ToString() %>'>
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Directors.GetDirectorByID(DataBinder.Eval(Container.DataItem, "DirectorID").ToString()).GetName() %>'></asp:Label>
                    </a>
                    <br />
                    <%# "Born Year : " + DataBinder.Eval(Container.DataItem,"BornYear","{0}") %>
                </center>
            </ItemTemplate>
        </asp:DataList>
        
        <a href="/Pages/AllDirectors.aspx">See All Directors..</a>
        
        <hr width="75%" />
        
        <b>Writers Section</b>
        <br />
        
        <asp:DataList ID="WritersDataList" runat="server" RepeatColumns="5" 
            RepeatDirection="Horizontal" CellSpacing="10" CellPadding="10">
            <ItemTemplate>
                <center>
                    <a href ='Pages/OneWriter.aspx?wid=<%# DataBinder.Eval(Container.DataItem, "WriterID", "{0}").ToString() %>'>
                        <asp:Image ID="Image2" runat="server" width="75" Height="110" ImageUrl='<%# "/Pictures/Writers/" + Writers.GetWriterByID(DataBinder.Eval(Container.DataItem, "WriterID", "{0}")).GetWriterPhoto() %>'/>
                    </a>
                    <br />
                    <a href ='Pages/OneWriter.aspx?wid=<%# DataBinder.Eval(Container.DataItem, "WriterID").ToString() %>'>
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Writers.GetWriterByID(DataBinder.Eval(Container.DataItem, "WriterID").ToString()).GetName() %>'></asp:Label>
                    </a>
                    <br />
                    <%# "Born Year : " + DataBinder.Eval(Container.DataItem,"BornYear","{0}") %>
                </center>
            </ItemTemplate>
        </asp:DataList>
        
        <a href="/Pages/AllWriters.aspx">See All Writers..</a>
        
    </center>
    
</asp:Content>