<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="AccountMainGroup.aspx.cs" Inherits="UserControls_AccountMainGroup"
    Title="Account Main Group" %>

<%@ Register src="UserControls/ODC/receipt/AccountMainGroup.ascx" tagname="AccountMainGroup" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:AccountMainGroup ID="AccountMainGroup1" runat="server" />
</asp:Content>
