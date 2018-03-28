<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="StockUpdate.aspx.cs" Inherits="StockUpdate" Title="Stock Update" %>

<%@ Register src="UserControls/uc_StockUpdate.ascx" tagname="uc_StockUpdate" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_StockUpdate ID="uc_StockUpdate1" runat="server" />
</asp:Content>

