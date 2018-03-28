<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ChetanaViewCourierEdit.aspx.cs" Inherits="ChetanaViewCourierEdit" %>

<%@ Register src="UserControls/uc_ChetanaViewCourierCR.ascx" tagname="uc_ChetanaViewCourierCR" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_ChetanaViewCourierCR ID="uc_ChetanaViewCourierCR1" runat="server" />
</asp:Content>

