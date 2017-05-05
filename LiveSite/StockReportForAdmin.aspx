<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="StockReportForAdmin.aspx.cs" Inherits="StockReportForAdmin" Title="Physical Stock Report" %>

<%@ Register src="UserControls/uc_StockReportForAdmin.ascx" tagname="uc_StockReportForAdmin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_StockReportForAdmin ID="uc_StockReportForAdmin1" runat="server" />
</asp:Content>

