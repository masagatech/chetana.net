<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="MultiPrint.aspx.cs" Inherits="MultiPrint" Title="MultiPrint" %>

<%@ Register src="UserControls/uc_BankPaymment_MultiPrint.ascx" tagname="uc_BankPaymment_MultiPrint" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_BankPaymment_MultiPrint ID="uc_BankPaymment_MultiPrint1" 
    runat="server" />
</asp:Content>

