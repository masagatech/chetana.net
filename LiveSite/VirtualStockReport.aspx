<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="VirtualStockReport.aspx.cs" Inherits="VirtualStockReport" Title="Chatana : Virtual Stock" %>

<%@ Register src="UserControls/uc_virtualStockreport.ascx" tagname="uc_virtualStockreport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <uc1:uc_virtualStockreport ID="uc_virtualStockreport1" runat="server" />
   
</asp:Content>

