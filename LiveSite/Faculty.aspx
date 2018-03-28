<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="Faculty.aspx.cs" Inherits="Faculty" Title="Teacher Entry" %>

<%@ Register src="UserControls/us_FacultyDetails.ascx" tagname="us_FacultyDetails" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:us_FacultyDetails ID="us_FacultyDetails1" runat="server" />
</asp:Content>

