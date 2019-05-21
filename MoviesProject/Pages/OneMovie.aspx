<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="OneMovie.aspx.cs" Inherits="Pages_Movie" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script type="text/javascript">
	    var i;
	    var element;
	    function stars_changed(selected)
	    {
		    for (i=1;i<=selected;i+=1)
		    {
			    element=document.getElementById("star_"+i);
			    element.src = "/Pictures/Other/star_1.jpg";
		    }
		    for (;i<=10;i+=1)
		    {
			    element=document.getElementById("star_"+i);
			    element.src = "/Pictures/Other/star_0.jpg";
		    }
	    }
	    function submit_rating(selected, movieID)
	    {
	        window.location.href = "/Pages/OneMovie.aspx?mid=" + movieID + "&RatingSelected=" + selected;
	    }
	</script>

    <table border="2" style="border-color: #D3A2A4">
        <tr>
            <td colspan="3" align="center">
                <big><asp:Label ID="NameLabel" runat="server" Text="" Font-Bold="True" Font-Underline="True"></asp:Label></big>
            </td>
        </tr>
        
        <tr>
            <td rowspan="12" style="width: 14px">
                <asp:Image ID="Image1" runat="server" ImageUrl="" Width="214" />
            </td>
            <td style="width: 150px">Global ID</td>
            <td>
                <asp:Label ID="GlobalIDLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">Series</td>
            <td>
                <asp:Label ID="SeriesLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">Release Year</td>
            <td>
                <asp:Label ID="ReleaseYearLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">3D Available</td>
            <td>
                <asp:Label ID="D3AvailableLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">IMDB Rating</td>
            <td>
                <asp:Label ID="RatingIMDBLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">Web Service Rating</td>
            <td>
                <asp:Label ID="RatingWSLabel" runat="server" Text=""></asp:Label>
                <br />
                Rate it : 
                <asp:Label ID="RateMeLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">Total Time</td>
            <td>
                <asp:Label ID="TotalTimeLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">Genre</td>
            <td>
                <asp:Label ID="GenresLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">Actors</td>
            <td>
                <asp:Label ID="ActorsLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">Directors</td>
            <td>
                <asp:Label ID="DirectorsLabel" runat="server" Text=""></asp:Label>
            
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">Writers</td>
            <td>
                <asp:Label ID="WritersLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width: 150px">Awards</td>
            <td>
                <asp:Label ID="AwardsLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    
    </table>
    
    <br />
    <asp:HyperLink ID="UpdateHyperLink" runat="server" Visible="False">Update</asp:HyperLink>
    <asp:Label ID="SlashLabel" runat="server" Visible="false">&nbsp/&nbsp</asp:Label>
    <asp:HyperLink ID="DeleteHyperLink" runat="server" Visible="False">Delete</asp:HyperLink>
    <br />
    <br />
     
    <table border="2" style="border-color: #D3A2A4">
        <tr>
            <td>
                <asp:Label ID="MovieTrailerLabel" runat="server" Text="" style="direction: ltr"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="TrailerLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    
         
    <table style="border-color: #D3A2A4">
        <tr>
            <td colspan="2">
                <big><b>Comments :</b></big>
                <br />&nbsp
            </td>
        </tr>
        <tr>
            <td>
                Name :
            </td>
            <td>
                <asp:TextBox ID="CommenterNameTextBox" runat="server" Width="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Comment :
            </td>
            <td>
                <asp:TextBox ID="NewCommentTextBox" runat="server" TextMode="MultiLine" Height="100" Width="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="AddCommentButton" runat="server" Text="Add Comment" OnClick="AddCommentButton_Click" />
            </td>
        </tr>
    </table>
    
    <br />
    
    <asp:Label ID="CommentsLabel" runat="server" Text=""></asp:Label>
    
    <asp:DataList ID="CommentsDataList" runat="server">
        <ItemTemplate>
             <%# DataBinder.Eval(Container.DataItem, "Comment", "{0}")%>
            <label style="color: #A5A5A5" >
                &nbsp&nbsp&nbsp&nbsp&nbsp<%# DataBinder.Eval(Container.DataItem,"Name", "{0}") %>
                <hr />
            </label>
            
        </ItemTemplate>
    </asp:DataList>
    
    
</asp:Content>