<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PlayerIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Player Page</h2>
    <p>
        Welcome to your player page, here there should be details about the games you're involved with, starting a new game,
        and that sort of thing.
    </p>
    <fieldset>
        <legend>Player Details</legend>
        Id: <%= Html.Encode(Model.Player.Id) %><br />
        Name: <%= Html.Encode(Model.Player.UserName) %><br />
        Is Cpu? <%= Html.Encode(Model.Player.IsCpu) %><br />
    </fieldset>
    
    <table>
        <tr><td colspan="4">Games</td></tr>
        <tr>
            <td>ID</td>
            <td>Description</td>
            <td>Playing As</td>
            <td>Current State</td>
        </tr>
        <% foreach (var game in Model.Games) { %>
            <tr>
                <td><%= Html.ActionLink<GameController>(game.Id.ToString(), c=>c.Edit(0), new { game.Id}) %></td>
                <td><%= Html.ActionLink<GameController>(game.Description, c => c.Edit(0), new { game.Id })%></td>
                <td>
                    <% foreach(var nationality in game.GetNationalityOf(Model.Player)) { %>
                        <%= Html.Encode(nationality) %>, 
                    <% } %>
                </td>
                <td><%= Html.Encode(game.GameState) %></td>
            </tr>   
        <% } %>
    </table>
    <%= Html.ActionLink<GameController>("Start A New Game", c => c.Create()) %>
</asp:Content>
