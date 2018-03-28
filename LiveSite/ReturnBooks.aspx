<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ReturnBooks.aspx.cs" Inherits="ReturnBooks" Title="Return Book" %>

<%@ Register src="UserControls/uc_ReturnBooks.ascx" tagname="uc_ReturnBooks" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_ReturnBooks ID="uc_ReturnBooks1" runat="server" />
</asp:Content>

