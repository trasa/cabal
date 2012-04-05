<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Game>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>
    <% if (Model.Count() == 0)
       {%> 
        <p>No games found.</p>
    <% }
       else
       { %>
            <table>
                <tr>
                    <th></th>
                    <th>Description</th>
                    <th>State</th>
                    <th>Status Message</th>
                </tr>
            <% foreach (var item in Model)
               { %>
                <tr>
                    <td>
                        <%= Html.ActionLink<GameController>("Edit", c => c.Edit(0), new { item.Id })%>
                    </td>
                    <td><%= Html.Encode(item.Description)%></td>
                    <td><%= Html.Encode(item.GameState)%></td>
                    <td><%= Html.Encode(new GameStatusGenerator(item).ToString())%></td>
                </tr>
                
            <% } %>
            </table>
    <% } %>
    <%= Html.ActionLink<GameController>("Create A New Game", c => c.Create()) %>
</asp:Content>
