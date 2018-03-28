<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
    AutoEventWireup="true" CodeFile="C_CreateInvoice.aspx.cs" Inherits="C_CreateInvoice" %>

<%@ Register Src="CNF/UserControl/CnFInvoice.ascx" TagName="CnFInvoice" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="js/popup/jquery-ui.js" type="text/javascript"></script>

    
    <script src="js/popup/jquery-1.10.2.js" type="text/javascript"></script>
   <%-- <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">

    <script src="//code.jquery.com/jquery-1.10.2.js"></script>

    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>

    <link rel="stylesheet" href="/resources/demos/style.css">--%>
    <uc1:CnFInvoice ID="CnFInvoice1" runat="server" />
</asp:Content>
