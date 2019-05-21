<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Pages_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label ID="ResultLabel" runat="server"></asp:Label>
    <br/>
    
    <asp:Label ID="MoviesLabel" runat="server" Text="<br/>Movies<br/>" Visible="false" ForeColor="#FF9933" Font-Size="Large"></asp:Label>
    <asp:DataList ID="MoviesDataList" runat="server" Visible="false" CellPadding="4" ForeColor="#333333">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#E3EAEB" />
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <asp:HyperLink ID="MoviesHyperLink" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MovieName", "{0}")%>'
            NavigateUrl='<%# "/Pages/OneMovie.aspx?mid=" + DataBinder.Eval(Container.DataItem, "MovieID", "{0}")%>' />
            &nbsp(<%# DataBinder.Eval(Container.DataItem, "ReleaseYear", "{0}") %>)
        </ItemTemplate>
    </asp:DataList>
    
    <asp:Label ID="ActorsLabel" runat="server" Text="<br/>Actors<br/>" Visible="false" ForeColor="#FF9933" Font-Size="Large"></asp:Label>
    <asp:DataList ID="ActorsDataList" runat="server" Visible="false" CellPadding="4" ForeColor="#333333">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#E3EAEB" />
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <asp:HyperLink ID="ActorsHyperLink" runat="server" Text='<%# Actors.GetActorByID(DataBinder.Eval(Container.DataItem, "ActorID", "{0}")).GetName() %>'
            NavigateUrl='<%# "/Pages/OneActor.aspx?aid=" + DataBinder.Eval(Container.DataItem, "ActorID", "{0}") %>' />
            &nbsp(<%# DataBinder.Eval(Container.DataItem, "BornYear", "{0}") %>)
        </ItemTemplate>
    </asp:DataList>
    
    <asp:Label ID="DirectorsLabel" runat="server" Text="<br/>Directors<br/>" Visible="false" ForeColor="#FF9933" Font-Size="Large"></asp:Label>
    <asp:DataList ID="DirectorsDataList" runat="server" Visible="false" CellPadding="4" ForeColor="#333333">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#E3EAEB" />
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <asp:HyperLink ID="DirectorsHyperLink" runat="server" Text='<%# Directors.GetDirectorByID(DataBinder.Eval(Container.DataItem, "DirectorID", "{0}")).GetName() %>'
            NavigateUrl='<%# "/Pages/OneDirector.aspx?did=" + DataBinder.Eval(Container.DataItem, "DirectorID", "{0}") %>' />
            &nbsp(<%# DataBinder.Eval(Container.DataItem, "BornYear", "{0}") %>)
        </ItemTemplate>
    </asp:DataList>
    
    <asp:Label ID="WritersLabel" runat="server" Text="<br/>Writers<br/>" Visible="false" ForeColor="#FF9933" Font-Size="Large"></asp:Label>
    <asp:DataList ID="WritersDataList" runat="server" Visible="false" CellPadding="4" ForeColor="#333333">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#E3EAEB" />
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <asp:HyperLink ID="WritersHyperLink" runat="server" Text='<%# Writers.GetWriterByID(DataBinder.Eval(Container.DataItem, "WriterID", "{0}")).GetName() %>'
            NavigateUrl='<%# "/Pages/OneWriter.aspx?wid=" + DataBinder.Eval(Container.DataItem, "WriterID", "{0}") %>' />
            &nbsp(<%# DataBinder.Eval(Container.DataItem, "BornYear", "{0}") %>)
        </ItemTemplate>
    </asp:DataList>
    
</asp:Content>

