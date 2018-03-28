<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DCDeleteCN.aspx.cs" Inherits="DCDeleteCN" Title="Delete CN" %>

<%@ Register src="UserControls/ODC/uc_DC_DeleteCN.ascx" tagname="uc_DC_DeleteCN" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_DC_DeleteCN ID="uc_DC_DeleteCN1" runat="server" />
</asp:Content>

