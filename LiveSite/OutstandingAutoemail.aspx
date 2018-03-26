<%@ Page Title="Outstanding Auto email" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
    AutoEventWireup="true" CodeFile="OutstandingAutoemail.aspx.cs" Inherits="OutstandingAutoemail" %>

<%@ Register Src="UserControls/uc_OutstandingAutoEmail.ascx" TagName="uc_OutstandingAutoEmail" TagPrefix="uc1_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1_View:uc_OutstandingAutoEmail ID="uc_CustomerMaster1" runat="server" />
</asp:Content>


