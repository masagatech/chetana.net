<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="InvoiceDeliveryStatus.aspx.cs" Inherits="InvoiceDeliveryStatus" Title="Invoice Delivery Status" %>

<%@ Register src="UserControls/ODC/receipt/InvoiceDeliverStatus.ascx" tagname="InvoiceDeliverStatus" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:InvoiceDeliverStatus ID="InvoiceDeliverStatus1" runat="server" />
</asp:Content>

