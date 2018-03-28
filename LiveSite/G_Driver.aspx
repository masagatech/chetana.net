<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" 
AutoEventWireup="true" CodeFile="G_Driver.aspx.cs" Inherits="G_Driver" Title="Driver Master : Chetana : Godown" %>

<%@ Register src="Godown/Driver.ascx" tagname="Driver" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Driver ID="Driver1" runat="server" />
</asp:Content>

