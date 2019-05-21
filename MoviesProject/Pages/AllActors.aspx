<%@ Page Title="All Actors" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="AllActors.aspx.cs" Inherits="Pages_AllActors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <big><b>All Actors</b></big>
    <br />
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" 
        RepeatDirection="Horizontal" CellSpacing="10" CellPadding="10">
        <ItemTemplate>
            <center>
                <a href ='OneActor.aspx?aid=<%# DataBinder.Eval(Container.DataItem, "ActorID").ToString() %>'>
                    <asp:Image runat="server" width="100" Height="146" ImageUrl='<%# "../Pictures/Actors/" + Actors.GetActorByID(DataBinder.Eval(Container.DataItem, "ActorID").ToString()).GetActorPhoto() %>'/>
                </a>
                <br />
                <a href ='OneActor.aspx?aid=<%# DataBinder.Eval(Container.DataItem, "ActorID").ToString() %>'>
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Actors.GetActorByID(DataBinder.Eval(Container.DataItem, "ActorID").ToString()).GetName() %>'></asp:Label>
                </a>
                <%# GenerateMovieActorButton_Click(DataBinder.Eval(Container.DataItem, "ActorID").ToString()) %>
            </center>
        </ItemTemplate>
    </asp:DataList>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Button ID="addActorButton" runat="server" Text="Add Actor" Visible="false"
        onclick="addActorButton_Click"/>
</asp:Content>