<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Book_Master.aspx.cs" Inherits="Book_Master" EnableEventValidation="false" Title="Chetana:Book Master" %>

<%@ Register src="UserControls/AddBookMaster.ascx" tagname="AddBookMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:AddBookMaster ID="AddBookMaster1" runat="server" />
</asp:Content>

