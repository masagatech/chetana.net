<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ChetanaUpdatePOD.aspx.cs" Inherits="ChetanaUpdatePOD" %>

<%@ Register src="UserControls/uc_ChetanaUpdatePOD.ascx" tagname="uc_ChetanaUpdatePOD" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_ChetanaUpdatePOD ID="uc_ChetanaUpdatePOD1" runat="server" />
</asp:Content>

