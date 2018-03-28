<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="InquiryTypeMaster.aspx.cs" Inherits="InquiryTypeMaster" %>

<%@ Register src="UserControls/uc_InquiryTypeMaster.ascx" tagname="uc_InquiryTypeMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_InquiryTypeMaster ID="uc_InquiryTypeMaster1" runat="server" />
</asp:Content>

