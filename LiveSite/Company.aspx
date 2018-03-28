<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="Company" Title="Company" %>

<%@ Register src="UserControls/uc_CompanyMaster.ascx" tagname="uc_CompanyMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_CompanyMaster ID="uc_CompanyMaster1" runat="server" />
</asp:Content>

