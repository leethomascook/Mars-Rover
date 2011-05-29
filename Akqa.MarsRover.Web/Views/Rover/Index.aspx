<%@ Page Title="Title" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form action="SubmitPlateau" runat="server">
    <table>
        <tr>
            <td>Enter Plateau Height</td>
            <td><%= Html.TextBox("height") %></td>
        </tr>
        <tr>
            <td>Enter Plateau Width</td>
            <td><%= Html.TextBox("width") %></td>
        </tr>
        <tr>
            <td><input type="submit" title="Submit" value="Submit"/></td>
        </tr>
    </table>
</form>
</asp:Content>