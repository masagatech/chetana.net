<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="EditODC.aspx.cs" Inherits="EditODC" Title="Chetana : Edit DC" %>

<%@ Register src="UserControls/ODC/uc_EditDC.ascx" tagname="uc_EditDC" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_EditDC ID="uc_EditDC" runat="server" />
</asp:Content>

