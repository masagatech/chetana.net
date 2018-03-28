<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" 
AutoEventWireup="true" CodeFile="BankReceipt_View.aspx.cs" 
Inherits="BankReceipt_View" Title="Bank Receipt" %>

<%@ Register src="~/UserControls/uc_BankReceiptView.ascx" tagname="uc_BankReceipt" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_BankReceipt ID="uc_BankReceipt1" runat="server" />
</asp:Content>

