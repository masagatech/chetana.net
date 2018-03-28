<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ReceiptCancelBook.aspx.cs" Inherits="UserControls_ReceiptCancelBook" Title="ReceiptCancelBook" %>

<%@ Register src="~/UserControls/ODC/receipt/uc_Receiptcancel.ascx" tagname="uc_Receiptcancel" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Receiptcancel ID="uc_Receiptcancel1" runat="server" />
</asp:Content>

