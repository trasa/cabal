<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Creating New Game</legend>
            <p>
                <label for="Description">Description:</label>
                <%= Html.TextBox("Description") %>
                <%= Html.ValidationMessage("Description", "*") %>
            </p>
            <div>
                Players:
                <table>
                    <tr>
                        <td>Soviet Union</td>
                        <td>
                            <% Html.RenderPartial("PlayerRadioButtons", new PlayerRadioButtonModel(Nationality.SovietUnion)); %>
                        </td>
                    </tr>
                    <tr>
                        <td>Germany</td>
                        <td>
                            <% Html.RenderPartial("PlayerRadioButtons", new PlayerRadioButtonModel(Nationality.Germany)); %>
                        </td></tr>
                    <tr><td>United Kingdom</td>
                        <td>
                            <% Html.RenderPartial("PlayerRadioButtons", new PlayerRadioButtonModel(Nationality.UnitedKingdom)); %>
                        </td></tr>
                    <tr>
                        <td>Empire of Japan</td>
                        <td><% Html.RenderPartial("PlayerRadioButtons", new PlayerRadioButtonModel(Nationality.Japan)); %></td>
                    </tr>
                    <tr>
                        <td>United States</td>
                        <td><% Html.RenderPartial("PlayerRadioButtons", new PlayerRadioButtonModel(Nationality.UnitedStates)); %></td>
                    </tr>
                </table>
            </div>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
    <% } %>
</asp:Content>

