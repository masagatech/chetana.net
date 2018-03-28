<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="View_Month_Target.aspx.cs" Inherits="View_Month_Target" Title="View Edit Month Target" %>

<%@ Register src="UserControls/View_Month_Target.ascx" tagname="View_Month_Target" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:View_Month_Target ID="View_Month_Target1" runat="server" />
</asp:Content>

