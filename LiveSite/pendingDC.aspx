<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="pendingDC.aspx.cs" Inherits="pendingDC" Title="Chetana : Pending DC" %>

<%@ Register src="UserControls/ODC/uc_PendingDC.ascx" tagname="uc_PendingDC" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_PendingDC ID="uc_PendingDC1" runat="server" />
</asp:Content>

