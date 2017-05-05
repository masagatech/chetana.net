<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="PettyCashEntryNew_edit.aspx.cs" Inherits="UserControls_ODC_PettyCashEntryNew_edit" Title="PettyCashEntry" %>

<%@ Register src="UserControls/ODC/receipt/PettyCashEntry.ascx" tagname="PettyCashEntry" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:PettyCashEntry ID="PettyCashEntry1" runat="server" />
</asp:Content>

