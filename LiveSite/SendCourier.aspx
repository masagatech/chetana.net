<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SendCourier.aspx.cs" Inherits="SendCourier" %>

<%@ Register src="UserControls/uc_SendCourier.ascx" tagname="uc_SendCourier" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_SendCourier ID="uc_SendCourier1" runat="server" />
</asp:Content>

