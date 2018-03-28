<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="EditInvoiceDeliveryStatus.aspx.cs" Inherits="EditInvoiceDeliveryStatus" Title="Edit Invoice Delivery Status" %>

<%@ Register src="UserControls/ODC/receipt/EditInvoiceDeliverStatus.ascx" tagname="EditInvoiceDeliverStatus" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:EditInvoiceDeliverStatus ID="EditInvoiceDeliverStatus1" runat="server" />
</asp:Content>

