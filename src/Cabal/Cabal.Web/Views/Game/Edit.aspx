<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EditGameViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function() {
        $(".edit").hide();
        
        $("button").click(function(e) {
            $(this).hide(); // hide the button
            $(this).parent().children("div.edit").show(); // show the edit div
            e.preventDefault();
        });
    });    
</script>
    <h2>
        Edit</h2>
    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm())
       { %>
    <fieldset>
        <legend>Edit</legend>
        <p>
            <label for="Description">Description:</label>
            <%= Html.TextBox("Description", Model.Description) %>
            <%= Html.ValidationMessage("Description", "*") %>
            
            <label for="owner">Owner:</label>
            <%= Html.Encode(Model.OwnerDisplayName) %>
        </p>
        <div>
            Players:
            <table>
                <tr>
                    <td>
                        Soviet Union
                    </td>
                    <td>
                        <%= Html.Encode(Model.SovietPlayerState.DisplayName) %>
                    </td>
                    <td>
                        <% Html.RenderPartial("EditPlayer", Model.SovietPlayerState); %>
                    </td>
                </tr>
                <tr>
                    <td>
                        Germany
                    </td>
                    <td>
                       <%= Html.Encode(Model.GermanPlayerState.DisplayName) %>
                    </td>
                    <td>
                        <% Html.RenderPartial("EditPlayer", Model.GermanPlayerState); %>
                    </td>
                </tr>
                <tr>
                    <td>
                        United Kingdom
                    </td>
                    <td>
                        <%= Html.Encode(Model.BritishPlayerState.DisplayName)%>
                    </td>
                    <td><% Html.RenderPartial("EditPlayer", Model.BritishPlayerState); %></td>
                </tr>
                <tr>
                    <td>
                        Empire of Japan
                    </td>
                    <td>
                        <%= Html.Encode(Model.JapanesePlayerState.DisplayName)%>
                    </td>
                    <td><% Html.RenderPartial("EditPlayer", Model.JapanesePlayerState); %></td>
                </tr>
                <tr>
                    <td>
                        United States
                    </td>
                    <td>
                       <%= Html.Encode(Model.AmericanPlayerState.DisplayName)%>
                    </td>
                    <td><% Html.RenderPartial("EditPlayer", Model.AmericanPlayerState); %></td>
                </tr>
            </table>
        </div>
        <p><input type="submit" value="Save" /></p>
        <% if (Model.CanStartGame) {%>
            <p><%= Html.ActionLink<GameController>("Start Game", c=>c.Start(0), new { Model.Id }) %></p>
        <% }%>
        
    </fieldset>
    <% } %>
</asp:Content>
