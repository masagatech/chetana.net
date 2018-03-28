<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Customer_Sub_Category_Master.aspx.cs" Inherits="Customer_Sub_Category_Master" %>

<%@ Register src="UserControls/uc_Customer_Sub_Category.ascx" tagname="uc_Customer_Sub_Category" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Customer_Sub_Category ID="uc_Customer_Sub_Category1" runat="server" />
</asp:Content>

