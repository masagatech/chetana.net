<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="VoucherPayment.aspx.cs" Inherits="UserControls_VoucherPayment" Title="PettyVoucher Payment" %>

<%@ Register src="UserControls/ODC/receipt/PettyVoucherPayment.ascx" tagname="PettyVoucherPayment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:PettyVoucherPayment ID="PettyVoucherPayment1" runat="server" />
</asp:Content>

