<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Customer_Master.aspx.cs" Inherits="Customer_Master" %>

<%@ Register src="UserControls/uc_Customer.ascx" tagname="uc_Customer" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Customer ID="uc_Customer1" runat="server" />
</asp:Content>

