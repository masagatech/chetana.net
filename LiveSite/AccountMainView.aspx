<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="AccountMainView.aspx.cs" Inherits="UserControls_AccountMainView" Title="Account Main View" %>



<%@ Register src="UserControls/ODC/receipt/Uc_AccountMain_View.ascx" tagname="Uc_AccountMain_View" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <uc1:Uc_AccountMain_View ID="Uc_AccountMain_View1" runat="server" />
   
</asp:Content>

