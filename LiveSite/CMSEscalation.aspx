<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="CMSEscalation.aspx.cs" Inherits="HelpdeskDashboard_Godown"
    Title="CMS Escalation" %>

<%@ Register src="UserControls/uc_CMSEscalation.ascx" tagname="uc_CMSEscalation" tagprefix="uc1" %>
<%--<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:uc_CMSEscalation ID="uc_CMSEscalation1" runat="server" />
</asp:Content>
