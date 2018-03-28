<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="AreaZoneMaster.aspx.cs" Inherits="AreaZoneMaster" Title="Chetana-AreaZone Master" %>

<%@ Register src="UserControls/uc_AreaZoneMaster.ascx" tagname="uc_AreaZoneMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_AreaZoneMaster ID="uc_AreaZoneMaster1" runat="server" />
</asp:Content>

