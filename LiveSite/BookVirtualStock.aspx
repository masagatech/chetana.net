<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="BookVirtualStock.aspx.cs" Inherits="BookVirtualStock" Title="Book VirtualStock" %>

<%@ Register src="UserControls/uc_BookVirtualStock.ascx" tagname="uc_BookVirtualStock" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_BookVirtualStock ID="uc_BookVirtualStock1" runat="server" />
</asp:Content>

