<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="AllWriters.aspx.cs" Inherits="Pages_AllWriters" Title="All Writers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <big><b>All Writers</b></big>
    <br />
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" 
        RepeatDirection="Horizontal" CellSpacing="10" CellPadding="10">
        <ItemTemplate>
            <center>
                <a href ='OneWriter.aspx?wid=<%# DataBinder.Eval(Container.DataItem, "WriterID").ToString() %>'>
                    <asp:Image ID="Image1" width="100" Height="146" runat="server" ImageUrl='<%# "../Pictures/Writers/" + Writers.GetWriterByID(DataBinder.Eval(Container.DataItem, "WriterID").ToString()).GetWriterPhoto() %>' />
                </a>
                <br />
                <a href ='OneWriter.aspx?wid=<%# DataBinder.Eval(Container.DataItem, "WriterID").ToString() %>'>
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Writers.GetWriterByID(DataBinder.Eval(Container.DataItem, "WriterID").ToString()).GetName() %>'></asp:Label>
                </a>
                <%# GenerateMovieWriterButton_Click(DataBinder.Eval(Container.DataItem, "WriterID").ToString()) %>
            </center>
        </ItemTemplate>
    </asp:DataList>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Button ID="addWriterButton" runat="server" Text="Add Writer" Visible="false"
        onclick="addWriterButton_Click"/>
</asp:Content>