<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="C_AddLogin.aspx.cs" Inherits="C_AddLogin" %>

<%@ Register src="CNF/UserControl/uc_CnFCreateLogin.ascx" tagname="uc_CnFCreateLogin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_CnFCreateLogin ID="uc_CnFCreateLogin1" runat="server" />
</asp:Content>

