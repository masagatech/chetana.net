<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ViewCourier.aspx.cs" Inherits="ViewCourier" %>

<%@ Register src="UserControls/uc_ViewCourier.ascx" tagname="uc_ViewCourier" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_ViewCourier ID="uc_ViewCourier1" runat="server" />
</asp:Content>

