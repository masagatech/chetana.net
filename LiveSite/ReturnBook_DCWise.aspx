<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ReturnBook_DCWise.aspx.cs" Inherits="ReturnBook_DCWise" %>

<%@ Register src="UserControls/ODC/uc_DC__Returnbook.ascx" tagname="uc_DC__Returnbook" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_DC__Returnbook ID="uc_DC__Returnbook1" runat="server" />
</asp:Content>

