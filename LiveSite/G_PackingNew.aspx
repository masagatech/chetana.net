<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="G_PackingNew.aspx.cs" Inherits="G_PackingNew" %>

<%@ Register src="Godown/Get_PackingDetails.ascx" tagname="Get_PackingDetails" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Get_PackingDetails ID="Get_PackingDetails1" runat="server" />
</asp:Content>

