<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="FacultyApproval.aspx.cs" Inherits="FacultyApprovalaspx" Title="Faculty Approve" %>

<%@ Register src="UserControls/uc_FacultyApprovs.ascx" tagname="uc_FacultyApprovs" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_FacultyApprovs ID="uc_FacultyApprovs1" runat="server" />
</asp:Content>

