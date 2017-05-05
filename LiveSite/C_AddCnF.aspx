<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
    AutoEventWireup="true" CodeFile="C_AddCnF.aspx.cs" Inherits="C_AddCnF" %>

<%@ Register Src="CNF/UserControl/uc_AddCnF.ascx" TagName="uc_AddCnF" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:uc_AddCnF ID="uc_AddCnF1" runat="server" />
</asp:Content>
