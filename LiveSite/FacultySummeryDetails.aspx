<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="FacultySummeryDetails.aspx.cs" Inherits="FacultySummeryDetails" Title="Faculty View" %>

<%@ Register src="UserControls/uc_FacultySummeryDetails.ascx" tagname="uc_FacultySummeryDetails" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_FacultySummeryDetails ID="uc_FacultySummeryDetails1" runat="server" />
</asp:Content>

