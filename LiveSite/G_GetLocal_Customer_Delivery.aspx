<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" Title="Local Customer Report"
    CodeFile="G_GetLocal_Customer_Delivery.aspx.cs" Inherits="GetLocal_Customer_Delivery"
  %>

<%@ Register Src="Godown/GetLocal_Customer_Delivery.ascx" TagName="GetLocal_Customer_Delivery"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:GetLocal_Customer_Delivery ID="GetLocal_Customer_Delivery1" runat="server" />
</asp:Content>
