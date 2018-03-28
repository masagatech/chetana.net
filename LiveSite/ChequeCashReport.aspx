<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ChequeCashReport.aspx.cs" Inherits="UserControls_ChequeCashReport" Title="Payment Pending" %>

<%@ Register src="~/UserControls/ODC/receipt/ChequeCashFilter.ascx" tagname="ChequeCashFilter" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ChequeCashFilter ID="ChequeCashFilter1" runat="server" />
 
</asp:Content>

