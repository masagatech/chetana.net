<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DN.aspx.cs" Inherits="DN" Title="Debit Note" %>

<%@ Register src="UserControls/uc_DN.ascx" tagname="uc_DN" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_DN ID="uc_DN1" runat="server" />
</asp:Content>

