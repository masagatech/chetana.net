<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="LoginUserDetails.aspx.cs" Inherits="LoginUserDetails" Title="LoginUserDetails" %>

<%@ Register src="UserControls/uc_LoginUserDetails.ascx" tagname="uc_LoginUserDetails" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <uc1:uc_LoginUserDetails ID="uc_LoginUserDetails1" runat="server" />
</asp:Content>

