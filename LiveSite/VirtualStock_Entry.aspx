<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="VirtualStock_Entry.aspx.cs" Inherits="VirtualStock_Entry" Title="Chetana : Virtual Stock Entry" %>

<%@ Register src="UserControls/uc_VirtualStock.ascx" tagname="uc_VirtualStock" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_VirtualStock ID="uc_VirtualStock1" runat="server" />
</asp:Content>

