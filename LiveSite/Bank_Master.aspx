<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Bank_Master.aspx.cs" Inherits="Bank_Master" Title="Chetana:Bank Master" %>

<%@ Register src="~/UserControls/uc_BankMaster.ascx" tagname="uc_BankMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:uc_BankMaster ID="uc_BankMaster1" runat="server" />
</asp:Content>

