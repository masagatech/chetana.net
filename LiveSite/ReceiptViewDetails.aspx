<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ReceiptViewDetails.aspx.cs" Inherits="UserControls_ODC_receipt_ReceiptViewDetails" Title="Receipt" %>


<%@ Register src="UserControls/ODC/receipt/ReceiptnoView.ascx" tagname="ReceiptnoView" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
  <uc1:ReceiptnoView ID="ReceiptnoView1" runat="server" />

  
</asp:Content>

