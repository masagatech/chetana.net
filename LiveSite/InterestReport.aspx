<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="InterestReport.aspx.cs" Inherits="InterestReport" Title="Interest Report" %>

<%@ Register src="UserControls/Loan-C-I/interestReport.ascx" tagname="interestReport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:interestReport ID="interestReport1" runat="server" />
</asp:Content>

