<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
 AutoEventWireup="true" CodeFile="SDZoneMaster.aspx.cs" 
 Inherits="SDZoneMaster" Title="Chetana:Super Duper Zone Master" %>

<%@ Register src="UserControls/uc_SDZoneMaster.ascx" 
    tagname="uc_SDZoneMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_SDZoneMaster ID="uc_SDZoneMaster1" runat="server" />
</asp:Content>

