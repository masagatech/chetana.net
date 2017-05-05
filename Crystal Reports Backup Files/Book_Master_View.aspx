<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="Book_Master_View.aspx.cs" Inherits="Book_Master_View" 
EnableEventValidation="false" Title="Chetana:Book Master:View" %>

<%@ Register src="UserControls/AddBookMaster_View.ascx" tagname="AddBookMaster_View" tagprefix="uc1_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1_View:AddBookMaster_View ID="AddBookMaster1" runat="server" />
</asp:Content>

