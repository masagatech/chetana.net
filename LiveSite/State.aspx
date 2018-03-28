<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="State.aspx.cs" Inherits="State" Title="State" %>

<%@ Register src="UserControls/uc_DestinationMaster.ascx" tagname="uc_DestinationMaster" tagprefix="uc1" %>
<%@ Register src="UserControls/uc_State.ascx" tagname="uc_State" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:uc_State ID="uc_State1" runat="server" />
</asp:Content>

