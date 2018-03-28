<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="G_Report_CN.aspx.cs" Inherits="G_Report_CN" Title="Credit Note Report" %>

<%@ Register src="Godown/Report_CN.ascx" tagname="Report_CN" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Report_CN ID="Report_CN1" runat="server" />
</asp:Content>

