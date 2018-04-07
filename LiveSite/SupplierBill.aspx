<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SupplierBill.aspx.cs" Inherits="SupplierBill" %>

<%@ Register src="UserControls/uc_SupplierBill.ascx" tagname="uc_SupplierBill" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:uc_SupplierBill ID="uc_SupplierBill1" runat="server" />
</asp:Content>