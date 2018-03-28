<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Miscellaneous.aspx.cs" Inherits="Miscellaneous" %>

<%@ Register src="UserControls/uc_Miscellaneous.ascx" tagname="uc_Miscellaneous" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Miscellaneous ID="uc_Miscellaneous1" runat="server" />
</asp:Content>

