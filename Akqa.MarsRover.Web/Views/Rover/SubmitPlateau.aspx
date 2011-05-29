<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Akqa.MarsRover.Web.Models.RoverModel>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p> Please submit details about as many rovers as you wish.</p>

<form runat="server" action="/Rover/AddRover">
    <table>
        <tr>
            <td>Enter Start X Position</td>
            <td><%= Html.TextBox("x") %></td>
        </tr>
        <tr>
            <td>Enter Start Y Position</td>
            <td><%= Html.TextBox("y") %></td>
        </tr>
          <tr>
            <td>Enter Direction Facing (N,S,E,W)</td>
            <td><%= Html.TextBox("direction") %></td>
        </tr>
        <tr>
            <td>Enter Movements</td>
            <td><%= Html.TextBox("movements") %></td>
        </tr>
          <td><input type="submit" title="Submit" value="Add Rover"/></td>
    </table>

<p>Alternatively, if you have added enough rovers, please <a href="/rover/StartExploration"> start the exploration</a>.</p>
  
  <h2>Current Rovers</h2>
  <table>
  <tr>
    <th>X</th>
    <th>Y</th>
    <th>Direction</th>
    <th>Movements</th>
  </tr>

  <% foreach (var result in ViewData.Model) { %>
    <tr>  
      <td>  <%=result.Rover.GetCurrentPosition().X.ToString() %></td>
       <td> <%=result.Rover.GetCurrentPosition().Y.ToString() %></td>
        <td><%=result.Rover.GetCurrentPosition().Direction.ToString() %></td>
        <td><%=result.Movements %></td>
        </tr>  
 <%   } %>

</table>
  <p>If you would like to start again, visit the <a href="/">hompegae</a>.</p>  
</form>
</asp:Content>