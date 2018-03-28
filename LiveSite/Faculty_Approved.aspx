<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Faculty_Approved.aspx.cs" Inherits="Faculty_Approved" Title="Approved Faculties" %>

<%@ Register src="UserControls/uc_Faculty_Approved.ascx" tagname="uc_Faculty_Approved" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Faculty_Approved ID="uc_Faculty_Approved1" runat="server" />
</asp:Content>

