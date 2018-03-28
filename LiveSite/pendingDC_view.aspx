<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="pendingDC_view.aspx.cs" Inherits="pendingDC_View" Title="Chetana : Pending DC" %>

<%@ Register src="UserControls/ODC/uc_PendingDCView.ascx" tagname="uc_PendingDC12" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_PendingDC12 ID="uc_PendingDC1" runat="server" />
</asp:Content>

