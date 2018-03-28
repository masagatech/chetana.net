<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ViewPettyCashDetails.aspx.cs" Inherits="UserControls_ViewPettyCashDetails" Title="View PettyCash Details" %>



<%@ Register src="UserControls/ODC/receipt/Get_All_PettyCashDetails.ascx" tagname="Get_All_PettyCashDetails" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:Get_All_PettyCashDetails ID="Get_All_PettyCashDetails1" runat="server" />
    
</asp:Content>

