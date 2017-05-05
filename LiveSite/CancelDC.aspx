<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="CancelDC.aspx.cs" Inherits="CancelDC" Title="Cancel DC" %>

<%@ Register src="UserControls/uc_CancelDC.ascx" tagname="uc_CancelDC" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_CancelDC ID="uc_CancelDC1" runat="server" />
</asp:Content>

