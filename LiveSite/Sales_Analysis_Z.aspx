<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Sales_Analysis_Z.aspx.cs" Inherits="Sales_Analysis_Z" Title="Sales Analysis" %>

<%@ Register src="UserControls/uc_Sales_View_Z.ascx" tagname="uc_Sales_View_Z" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Sales_View_Z ID="uc_Sales_View_Z1" runat="server" />
</asp:Content>

