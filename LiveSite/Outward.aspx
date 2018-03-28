<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Outward.aspx.cs" Inherits="Outward" Title="Outward" %>

<%@ Register src="UserControls/uc_Outward.ascx" tagname="uc_Outward" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Outward ID="uc_Outward1" runat="server" />
</asp:Content>

