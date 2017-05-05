<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DCMaster.aspx.cs" Inherits="DCMaster" Title="Chetana : DC Master" %>

<%@ Register src="UserControls/ODC/uc_DC_Master.ascx" tagname="uc_DC_Master" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_DC_Master ID="uc_DC_Master1" runat="server" />
</asp:Content>

