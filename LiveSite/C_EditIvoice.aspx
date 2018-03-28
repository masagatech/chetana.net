<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="C_EditIvoice.aspx.cs" Inherits="C_EditIvoice" Title="Edit Invoice" %>

<%@ Register Src="CNF/UserControl/uc_CnFEditInvoice.ascx" TagName="uc_CnFEditInvoice"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:uc_CnFEditInvoice ID="uc_CnFEditInvoice1" runat="server" />
</asp:Content>
