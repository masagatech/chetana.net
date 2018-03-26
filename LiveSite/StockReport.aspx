<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="StockReport.aspx.cs" Inherits="StockReport" Title="Chetana : Stock Report" %>

<%@ Register src="UserControls/uc_StockReport.ascx" tagname="uc_StockReport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_StockReport ID="uc_StockReport1" runat="server" />
</asp:Content>

