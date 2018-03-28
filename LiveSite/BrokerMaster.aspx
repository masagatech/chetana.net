<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="BrokerMaster.aspx.cs" Inherits="BrokerMaster" Title="Broker Master" %>

<%@ Register src="UserControls/uc_BrokerMaster.ascx" tagname="uc_BrokerMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_BrokerMaster ID="uc_BrokerMaster1" runat="server" />
</asp:Content>

