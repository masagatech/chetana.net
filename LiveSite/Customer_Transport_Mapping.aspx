<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Customer_Transport_Mapping.aspx.cs" Inherits="Customer_Transport_Mapping" Title="Customer Transport Mapping" %>

<%@ Register src="UserControls/uc_CustomerTransport_Mapping.ascx" tagname="uc_CustomerTransport_Mapping" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_CustomerTransport_Mapping ID="uc_CustomerTransport_Mapping1" 
        runat="server" />
</asp:Content>

