<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Menu Role_Mapping.aspx.cs" Inherits="Menu_Role_Mapping" Title="Chetana:Menu Role Mapping" %>

<%@ Register src="UserControls/uc_MenuRoleMapping.ascx" tagname="uc_MenuRoleMapping" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_MenuRoleMapping ID="uc_MenuRoleMapping1" runat="server" />
</asp:Content>

