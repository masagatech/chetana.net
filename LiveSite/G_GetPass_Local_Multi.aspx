<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" 
AutoEventWireup="true" 
CodeFile="G_GetPass_Local_Multi.aspx.cs" Inherits="G_GetPass_Local_Multi" Title="Local Get Pass : Chetana : Godown" %>

 <%@ Register src="~/Godown/GetPass_Local_multi.ascx" TagName="GetPass_Local_multi" tagprefix="uc1" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:GetPass_Local_multi ID="getpass_Local_multi1" runat="server" />
    </asp:Content>


