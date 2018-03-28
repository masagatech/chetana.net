<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SalesPerFormance_Summary.aspx.cs" Inherits="SalesPerFormance_Summary" Title="Sales Summary" %>

<%@ Register src="UserControls/uc_SalesPerfomanceofZone_Summary.ascx" tagname="uc_SalesPerfomanceofZone_Summary" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_SalesPerfomanceofZone_Summary ID="uc_SalesPerfomanceofZone_Summary1" 
        runat="server" />
</asp:Content>

