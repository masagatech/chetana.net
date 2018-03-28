<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="OrderCancelDc.aspx.cs" Inherits="UserControls_ODC_OrderCancelDc" Title="Order CancelDC" %>



<%@ Register src="UserControls/ODC/uc_OCancelDC.ascx" tagname="uc_OCancelDC" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <uc1:uc_OCancelDC ID="uc_OCancelDC1" runat="server" />
 
</asp:Content>

