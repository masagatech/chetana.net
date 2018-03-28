<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="AccountMain.aspx.cs" Inherits="UserControls_AccountMain" Title="Account Main" %>



<%@ Register src="UserControls/ODC/receipt/Uc_AccountMain.ascx" tagname="Uc_AccountMain" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:Uc_AccountMain ID="Uc_AccountMain1" runat="server" />
    
</asp:Content>

