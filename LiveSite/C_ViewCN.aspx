<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="C_ViewCN.aspx.cs" Inherits="C_ViewCN" Title="View CnF CN" %>

<%@ Register Src="CNF/UserControl/uc_DC_CNPrint.ascx" TagName="uc_DC_CNPrint" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:uc_DC_CNPrint ID="uc_DC_CNPrint1" runat="server" />
</asp:Content>
