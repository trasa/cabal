<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PlayerRadioButtonModel>" %>
Open: <%=Html.RadioButton(Model.Nationality.ToString(), "open", Model.IsOpen)%>
Self: <%=Html.RadioButton(Model.Nationality.ToString(), "self", Model.IsSelf)%>
Cpu: <%=Html.RadioButton(Model.Nationality.ToString(), "cpu", Model.IsCpu)%>