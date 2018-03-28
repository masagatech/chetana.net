<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Order_ValuationDashboard.aspx.cs" Inherits="Order_ValuationDashboard" Title="Order Valuation Dashboard" %>

<%@ Register src="UserControls/uc_OrderValuation_DashBoard.ascx" tagname="uc_OrderValuation_DashBoard" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_OrderValuation_DashBoard ID="uc_OrderValuation_DashBoard1" 
        runat="server" />
</asp:Content>

