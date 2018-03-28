<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Market_View.aspx.cs" Inherits="Market_View" Title="Market View" %>

<%@ Register src="UserControls/uc_Market_View.ascx" tagname="uc_Market_View" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Market_View ID="uc_Market_View1" runat="server" />
</asp:Content>

