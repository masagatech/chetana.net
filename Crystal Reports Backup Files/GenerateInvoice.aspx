<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="GenerateInvoice.aspx.cs" Inherits="GenerateInvoice" Title="Chetana : Generate Invoice" %>

<%@ Register src="UserControls/ODC/uc_GenerateInvoice.ascx" tagname="uc_GenerateInvoice" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_GenerateInvoice ID="uc_GenerateInvoice1" runat="server" />
</asp:Content>

