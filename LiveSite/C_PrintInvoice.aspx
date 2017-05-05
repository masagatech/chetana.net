<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="C_PrintInvoice.aspx.cs" Inherits="C_PrintInvoice" %>

<%@ Register src="CNF/UserControl/uc_CnFPrintInvoice.ascx" tagname="uc_CnFPrintInvoice" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_CnFPrintInvoice ID="uc_CnFPrintInvoice1" runat="server" />
</asp:Content>

