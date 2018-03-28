<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="LedgerDetails.aspx.cs" Inherits="UserControls_LedgerDetails" Title="Chetana : Ledger" %>



<%@ Register src="UserControls/ODC/receipt/LedgerDetails.ascx" tagname="LedgerDetails" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <uc1:LedgerDetails ID="LedgerDetails1" runat="server" />
  
</asp:Content>

