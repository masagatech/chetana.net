<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SalesHierarchy.aspx.cs" Inherits="SalesHierarchy" Title="SaleHierarchy" %>

<%@ Register src="UserControls/ODC/uc_SaleHierarchy.ascx" tagname="uc_SaleHierarchy" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_SaleHierarchy ID="uc_SaleHierarchy1" runat="server" />
</asp:Content>

