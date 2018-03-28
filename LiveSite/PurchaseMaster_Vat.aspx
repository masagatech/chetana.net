<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="PurchaseMaster_Vat.aspx.cs" Inherits="UserControls_PurchaseMaster_Vat" Title="Purchase Master" %>



<%@ Register src="UserControls/uc_PurchaseMaster_Vat.ascx" tagname="uc_PurchaseMaster_Vat" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:uc_PurchaseMaster_Vat ID="uc_PurchaseMaster_Vat1" runat="server" />
    
</asp:Content>

