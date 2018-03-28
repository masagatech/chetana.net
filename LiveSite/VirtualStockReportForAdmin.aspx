<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="VirtualStockReportForAdmin.aspx.cs" Inherits="VirtualStockReportForAdmin" Title="Virtual Stock Report" %>

<%@ Register src="UserControls/uc_virtualStockreport_ForAdmin.ascx" tagname="uc_virtualStockreport_ForAdmin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_virtualStockreport_ForAdmin ID="uc_virtualStockreport_ForAdmin1" 
        runat="server" />
</asp:Content>

