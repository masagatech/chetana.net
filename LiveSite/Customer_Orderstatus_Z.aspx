<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Customer_Orderstatus_Z.aspx.cs" Inherits="Customer_Orderstatus_Z" Title="Customer Order Status" %>


<%@ Register src="UserControls/uc_Customer_OrderStatus_Z.ascx" tagname="uc_Customer_OrderStatus_Z" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:uc_Customer_OrderStatus_Z ID="uc_Customer_OrderStatus_Z1" runat="server" />
    </asp:Content>
