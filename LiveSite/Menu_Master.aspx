<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Menu_Master.aspx.cs" Inherits="Menu_Master" Title="Chetana:Menu Master" %>

<%@ Register src="UserControls/uc_MenuMaster.ascx" tagname="uc_MenuMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_MenuMaster ID="uc_MenuMaster1" runat="server" />
</asp:Content>

