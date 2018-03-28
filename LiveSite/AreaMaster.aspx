<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="AreaMaster.aspx.cs" Inherits="AreaMaster" Title="Chetana:Area Master" %>

<%@ Register src="UserControls/uc_AreaMaster.ascx" tagname="uc_AreaMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_AreaMaster ID="uc_AreaMaster1" runat="server" />
</asp:Content>

