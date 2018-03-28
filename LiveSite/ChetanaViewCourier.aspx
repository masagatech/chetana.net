<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ChetanaViewCourier.aspx.cs" Inherits="ChetanaViewCourier" %>

<%@ Register src="UserControls/uc_ChetanaViewCourier.ascx" tagname="uc_ChetanaViewCourier" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_ChetanaViewCourier ID="uc_ChetanaViewCourier1" runat="server" />
</asp:Content>

