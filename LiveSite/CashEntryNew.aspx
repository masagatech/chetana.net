<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="CashEntryNew.aspx.cs" Inherits="UserControls_ODC_CashEntry" Title="CashEntry" %>

<%@ Register src="UserControls/ODC/receipt/CashEntry.ascx" tagname="CashEntry" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:CashEntry ID="CashEntry" runat="server" />
</asp:Content>

