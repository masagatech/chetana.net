<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="AccountMainSubGroup.aspx.cs" Inherits="UserControls_AccountMainSubGroup" Title="Account MainSub Group" %>

<%@ Register src="UserControls/ODC/receipt/AccountSubGroupSub.ascx" tagname="AccountSubGroupSub" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AccountSubGroupSub ID="AccountSubGroupSub1" runat="server" />
</asp:Content>

