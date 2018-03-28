<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Bank_ReceiptPayment.aspx.cs" Inherits="Bank_ReceiptPayment" Title="Bank Receipt/Payment" %>

<%@ Register src="UserControls/uc_BankReceiptPayment.ascx" tagname="uc_BankReceiptPayment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_BankReceiptPayment ID="uc_BankReceiptPayment1" runat="server" />
</asp:Content>

