<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ExpenseDetails.aspx.cs" Inherits="ExpenseDetails" Title="Chetana : Expense Details" %>

<%@ Register src="UserControls/uc_ExpenseHead.ascx" tagname="uc_ExpenseHead" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_ExpenseHead ID="uc_ExpenseHead1" runat="server" />
</asp:Content>

