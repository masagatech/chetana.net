<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="AccountMain.aspx.cs"
    Inherits="UserControls_AccountMain" Title="Account Main" %>

<%@ Register Src="UserControls/ODC/receipt/Uc_AccountMain.ascx" TagName="Uc_AccountMain" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:Uc_AccountMain ID="Uc_AccountMain1" runat="server" />
</asp:Content>
