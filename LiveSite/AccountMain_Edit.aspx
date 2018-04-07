<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="AccountMain_Edit.aspx.cs"
    Inherits="UserControls_AccountMain_Edit" Title="Account Main" %>

<%@ Register Src="UserControls/ODC/receipt/Uc_AccountMain_Edit.ascx" TagName="Uc_AccountMain_edit" TagPrefix="uc_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc_Edit:Uc_AccountMain_edit ID="Uc_AccountMain_Edit" runat="server" />
</asp:Content>