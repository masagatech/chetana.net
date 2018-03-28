<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Month_Target.aspx.cs" Inherits="Month_Target" Title="Month Target" %>

<%@ Register src="UserControls/Month_Target.ascx" tagname="Month_Target" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Month_Target ID="Month_Target1" runat="server" />
</asp:Content>

