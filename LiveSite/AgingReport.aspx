<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="AgingReport.aspx.cs" Inherits="AgingReport" Title="Aging Report" %>

<%@ Register src="UserControls/Loan-C-I/AgingReport.ascx" tagname="AgingReport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AgingReport ID="AgingReport1" runat="server" />
</asp:Content>

