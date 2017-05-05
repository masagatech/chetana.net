<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="AccountLedger.aspx.cs" Inherits="AccountLedger" Title="Chetana-Acount Ledger" %>

<%@ Register src="UserControls/ODC/ledger/uc_AC_Ledger.ascx" tagname="uc_AC_Ledger" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_AC_Ledger ID="uc_AC_Ledger1" runat="server" />
</asp:Content>

