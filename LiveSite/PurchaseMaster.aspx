<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="PurchaseMaster.aspx.cs" Inherits="UserControls_PurchaseMaster" Title="Purchase Master" %>

<%@ Register src="UserControls/uc_PurchaseMaster.ascx" tagname="uc_PurchaseMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_PurchaseMaster ID="uc_PurchaseMaster1" runat="server" />
</asp:Content>

