<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="InquiryStatusMaster.aspx.cs" Inherits="InquiryStatusMaster" %>

<%@ Register src="UserControls/uc_InquiryStatusMaster.ascx" tagname="uc_InquiryStatusMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_InquiryStatusMaster ID="uc_InquiryStatusMaster1" runat="server" />
</asp:Content>

