<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DCCreditNotePrint.aspx.cs" Inherits="DCCreditNotePrint" Title="View CreditNote" %>

<%@ Register src="UserControls/ODC/uc_DC_CNPrint.ascx" tagname="uc_DC_CNPrint" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_DC_CNPrint ID="uc_DC_CNPrint1" runat="server" />
</asp:Content>

