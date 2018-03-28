<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="LoanPartyMaster.aspx.cs" Inherits="LoanPartyMaster" Title="LoanParty Master" %>

<%@ Register src="UserControls/uc_LoanPartyMaster.ascx" tagname="uc_LoanPartyMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_LoanPartyMaster ID="uc_LoanPartyMaster1" runat="server" />
</asp:Content>

