<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SuperZoneMaster.aspx.cs" Inherits="SuperZoneMaster" Title="Chetana:SuperZone Master" %>

<%@ Register src="UserControls/uc_SuperZoneMaster.ascx" tagname="uc_SuperZoneMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_SuperZoneMaster ID="uc_SuperZoneMaster1" runat="server" />
</asp:Content>

