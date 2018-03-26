<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Scheme_CustomerMapping.aspx.cs" Inherits="Scheme_CustomerMapping" Title="Scheme Customer Mapping" %>

<%@ Register src="UserControls/uc_Scheme_CustomerMapping.ascx" tagname="uc_Scheme_CustomerMapping" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Scheme_CustomerMapping ID="uc_Scheme_CustomerMapping1" runat="server" />
</asp:Content>

