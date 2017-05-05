<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Edit_Invoice.aspx.cs" Inherits="Edit_Invoice" Title="Chetana : Edit Invoice " %>

<%@ Register src="UserControls/ODC/uc_EditInvoice.ascx" tagname="uc_EditInvoice" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_EditInvoice ID="uc_EditInvoice1" runat="server" />
</asp:Content>

