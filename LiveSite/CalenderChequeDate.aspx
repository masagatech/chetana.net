<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="CalenderChequeDate.aspx.cs" Inherits="UserControls_CalenderChequeDate" Title="DashboardCalender" %>

<%@ Register src="UserControls/ODC/receipt/Calender.ascx" tagname="Calender" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Calender ID="Calender1" runat="server" />
</asp:Content>

