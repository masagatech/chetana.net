<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="BankLedger.aspx.cs" Inherits="BankLedger" Title="Chetana : Bank Book" %>

<%@ Register src="UserControls/uc_BankLedger.ascx" tagname="uc_BankLedger" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_BankLedger ID="uc_BankLedger1" runat="server" />
</asp:Content>

