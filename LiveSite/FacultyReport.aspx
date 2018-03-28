<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="FacultyReport.aspx.cs" Inherits="FacultyReport" Title="Faculty Report" %>

<%@ Register src="UserControls/uc_FacultyReport.ascx" tagname="uc_FacultyReport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_FacultyReport ID="uc_FacultyReport1" runat="server" />
</asp:Content>

