<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="InquirySeverityMaster.aspx.cs" Inherits="InquirySeverityMaster" %>

<%@ Register src="UserControls/uc_InquirySeverityMaster.ascx" tagname="uc_InquirySeverityMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_InquirySeverityMaster ID="uc_InquirySeverityMaster1" runat="server" />
</asp:Content>

