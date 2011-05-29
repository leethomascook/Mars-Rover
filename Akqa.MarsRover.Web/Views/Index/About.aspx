<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master"%>


<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>About</h2>
    <p>
       <br /><br />A squad of robotic rovers are to be landed by NASA on a plateau on Mars.<br /><br />This plateau, which is curiously rectangular, must be navigated by the rovers so that their on board cameras can get a complete view of the surrounding terrain to send back to Earth.<br />A rover&#39;s position is represented by a combination of an x and y co-ordinates and a letter representing one of the four cardinal compass points. The plateau is divided up into a grid to simplify navigation. An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North.<br /><br />In order to control a rover, NASA sends a simple string of letters. The possible letters are &#39;L&#39;, &#39;R&#39; and &#39;M&#39;. &#39;L&#39; and &#39;R&#39; makes the rover spin 90 degrees left or right respectively, without moving from its current spot.<br />&#39;M&#39; means move forward one grid point, and maintain the same heading.<br />Assume that the square directly North from (x, y) is (x, y+1).<br /><br />Input (whether hard coded or input from keyboard):<br />The first line of input is the upper-right coordinates of the plateau, the lower-left coordinates are assumed to be 0,0.<br />The rest of the input is information pertaining to the rovers that have been deployed. Each rover has two lines of input. The first line gives the rover&#39;s position, and the second line is a series of instructions telling the rover how to explore the plateau.<br /><br />The position is made up of two integers and a letter separated by spaces, corresponding to the x and y co-ordinates and the rover&#39;s orientation.<br />Each rover will be finished sequentially, which means that the second rover won&#39;t start to move until the first one has finished moving.<br />Output:<br />The output for each rover should be its final co-ordinates and heading.<br /><br />Plateau max X and Y, Starting coordinates, direction and path for two rovers:<br />5 5<br />1 2 N<br />LMLMLMLMM<br />3 3 E<br />MMRMMRMRRM<br /><br />Output and new coordinates:<br />1 3 N<br />5 1 E<br />






    </p>
</asp:Content>