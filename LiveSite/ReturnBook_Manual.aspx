<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ReturnBook_Manual.aspx.cs" Inherits="ReturnBook_Manual" %>

<%@ Register src="UserControls/ODC/uc_DC_GenerateCN.ascx" tagname="uc_DC_GenerateCN" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_DC_GenerateCN ID="uc_DC_GenerateCN1" runat="server" />
</asp:Content>

