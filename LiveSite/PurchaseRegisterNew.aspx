<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="PurchaseRegisterNew.aspx.cs" Inherits="PurchaseRegisterNew" Title="Purchase Register" %>

<%@ Register Src="UserControls/PurchaseRegisterNew.ascx" TagName="PurchaseRegisterNew"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:PurchaseRegisterNew ID="PurchaseRegisterNew1" runat="server" />
</asp:Content>
