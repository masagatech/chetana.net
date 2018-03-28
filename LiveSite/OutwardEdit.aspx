<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="OutwardEdit.aspx.cs" Inherits="OutwardEdit" Title="OutwardEdit" %>

<%@ Register src="UserControls/uc_OutwardEdit.ascx" tagname="uc_OutwardEdit" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_OutwardEdit ID="uc_OutwardEdit1" runat="server" />
</asp:Content>

