<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" 
AutoEventWireup="true" CodeFile="PrintInvoice_Z.aspx.cs" Inherits="PrintInvoice_Z" Title="Chetana : Print Invoice" %>

<%@ Register src="~/UserControls/ODC/uc_Print_Invoice_Z.ascx" tagname="uc_Print_Invoice" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Print_Invoice ID="uc_Print_Invoice1" runat="server" />
</asp:Content>

