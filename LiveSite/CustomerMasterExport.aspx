<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="CustomerMasterExport.aspx.cs" 
Inherits="CustomerMasterExport" Title="Chetana:Cusomer Master" %>

<%@ Register src="UserControls/uc_CustomerMasterExport.ascx" tagname="uc_CustomerMasterExport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_CustomerMasterExport ID="uc_CustomerMasterExport" runat="server" />
</asp:Content>

