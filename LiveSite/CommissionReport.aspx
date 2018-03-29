<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
 CodeFile="CommissionReport.aspx.cs" Inherits="CommissionReport" Title="Commission Report" %>

<%@ Register src="~/UserControls/Loan-C-I/CommissionReport.ascx" tagname="CommissionReport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:CommissionReport ID="CommissionReport1" runat="server" />
</asp:Content>