<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Start a Game
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Start</h2>
    Are you ready to start this game?
    <% using(Html.BeginForm()) { %>
        <input type="submit" value="Yeah, lets go." />
    <% } %>
</asp:Content>
