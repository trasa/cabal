<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EditGameViewModel.PlayerState>" %>
<% if (Model.CanEdit) {%>
<div>
    <button>
        Edit</button>
    <div class="edit">
        <% Html.RenderPartial("PlayerRadioButtons", Model.PlayerRadioButtons);%>
    </div>
</div>
<% }%>