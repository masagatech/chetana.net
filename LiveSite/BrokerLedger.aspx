<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="BrokerLedger.aspx.cs"
 Inherits="BrokerLedger" Title="Broker Ledger" %>

<%@ Register src="UserControls/Loan-C-I/LedgerBroker.ascx" tagname="LedgerBroker" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:LedgerBroker ID="LedgerBroker1" runat="server" />
</asp:Content>

