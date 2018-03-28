<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="StockAgeingReport.aspx.cs" Inherits="StockAgeingReport" Title="Chetana-Stock Ageing" %>

<%@ Register src="UserControls/Loan-C-I/StockAgeing.ascx" tagname="StockAgeing" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:StockAgeing ID="StockAgeing1" runat="server" />
</asp:Content>

