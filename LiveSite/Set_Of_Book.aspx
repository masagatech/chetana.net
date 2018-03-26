<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Set_Of_Book.aspx.cs" Inherits="Set_Of_Book" Title="Chetana:Set Of Book" %>

<%@ Register src="UserControls/uc_SetOfBook.ascx" tagname="uc_SetOfBook" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_SetOfBook ID="uc_SetOfBook12" runat="server" />
</asp:Content>

