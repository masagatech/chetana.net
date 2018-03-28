<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ChetanaSendCourier.aspx.cs" Inherits="ChetanaSendCourier" %>

<%@ Register src="UserControls/uc_ChetanaSendCourier.ascx" tagname="uc_ChetanaSendCourier" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_ChetanaSendCourier ID="uc_ChetanaSendCourier1" runat="server" />
</asp:Content>

