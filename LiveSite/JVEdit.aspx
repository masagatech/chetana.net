<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="JVEdit.aspx.cs" Inherits="JVEdit" Title="JV Edit" %>

<%@ Register src="UserControls/uc_JVEdit.ascx" tagname="uc_JVEdit" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_JVEdit ID="uc_JVEdit1" runat="server" />
</asp:Content>

