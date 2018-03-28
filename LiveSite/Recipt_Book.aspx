<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Recipt_Book.aspx.cs" Inherits="UserControls_Recipt_Book" Title="ReceiptBook" %>



<%@ Register src="~/UserControls/ODC/receipt/uc_ReceiptBookEntry.ascx" tagname="uc_ReceiptBookEntry" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  
  
    <uc2:uc_ReceiptBookEntry ID="uc_ReceiptBookEntry1" runat="server" />
  
  
  
</asp:Content>

