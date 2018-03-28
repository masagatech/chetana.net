<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Role_Master.aspx.cs" Inherits="Role_Master" Title="Role Master" %>

<%@ Register src="UserControls/uc_RoleMaster.ascx" tagname="uc_RoleMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_RoleMaster ID="uc_RoleMaster1" runat="server" />
</asp:Content>

