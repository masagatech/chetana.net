<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="G_GetPAss_Local_Speciman.aspx.cs" Inherits="G_GetPAss_Local" Title="Local Get Pass : Chetana : Godown" %>

<%@ Register src="Godown/GetPass_Local_Speciman.ascx" tagname="GetPass_Local_Speciman" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:GetPass_Local_Speciman ID="GetPass_Local1" runat="server" />
</asp:Content>

