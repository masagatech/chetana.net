<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="G_Railway_Report.aspx.cs" Inherits="G_Railway_Report" Title="Railway Register Report" %>

<%@ Register src="Godown/Get_Railway.ascx" tagname="Get_Railway" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Get_Railway ID="Get_Railway1" runat="server" />
</asp:Content>

