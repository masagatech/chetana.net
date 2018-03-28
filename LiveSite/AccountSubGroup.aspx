<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="AccountSubGroup.aspx.cs" Inherits="UserControls_AccountSubGroup" Title="Account SubGroup" %>



<%@ Register src="UserControls/ODC/receipt/AccountSubGroup.ascx" tagname="AccountSubGroup" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <uc1:AccountSubGroup ID="AccountSubGroup1" runat="server" />
   
</asp:Content>

