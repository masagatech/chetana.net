<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="City.aspx.cs" Inherits="City" Title="City" %>

<%@ Register src="UserControls/uc_City.ascx" tagname="uc_City" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_City ID="uc_City1" runat="server" />
</asp:Content>

