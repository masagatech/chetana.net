<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="FinancialYear.aspx.cs" Inherits="FinancialYear" Title="Chetana : Year" %>

<%@ Register src="UserControls/uc_FinancialYearMaster.ascx" tagname="uc_Financial" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Financial ID="uc_Financial1" runat="server" />
</asp:Content>

