<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ChequeCashDetails.aspx.cs" Inherits="UserControls_ChequeCashDetailsaspx" Title="ChequeCashDetails" %>







<%@ Register src="~/UserControls/ODC/receipt/uc_ChequeCashDeposit.ascx" tagname="uc_ChequeCashDeposit" tagprefix="uc1" %>







<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <uc1:uc_ChequeCashDeposit ID="uc_ChequeCashDeposit1" runat="server" />
    
    
</asp:Content>

