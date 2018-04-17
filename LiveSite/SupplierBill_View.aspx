<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SupplierBill_View.aspx.cs" Inherits="SupplierBill_View" %>

<%@ Register src="UserControls/uc_SupplierBill_View.ascx" tagname="uc_SupplierBill_View" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:uc_SupplierBill_View ID="uc_SupplierBill_View1" runat="server" />
</asp:Content>