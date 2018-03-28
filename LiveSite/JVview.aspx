<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="JVview.aspx.cs" Inherits="JVview" Title="Journal Voucher View/Delete" %>

<%@ Register src="UserControls/uc_JVView.ascx" tagname="uc_JVView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_JVView ID="uc_JVView1" runat="server" />
</asp:Content>

