<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SalesPerformance.aspx.cs" Inherits="SalesPerformance" Title="Chetana : SalesPerformance" %>

<%@ Register src="UserControls/uc_SalesPerfomanceofZone.ascx" tagname="uc_SalesPerfomanceofZone" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_SalesPerfomanceofZone ID="uc_SalesPerfomanceofZone1" runat="server" />
</asp:Content>

