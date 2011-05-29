<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Akqa.MarsRover.Business.Domain.Position>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	StartExploration
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   
    <h2>Output</h2>
<% foreach (var result in ViewData.Model) { %>
    <p>  
        <%=result.X.ToString() %>
        <%=result.Y.ToString() %>
        <%=result.Direction.ToString() %>
        </p>  
 <%   } %>


   <p>If you would like to start again, visit the <a href="/">hompegae</a>.</p>  
</asp:Content>
