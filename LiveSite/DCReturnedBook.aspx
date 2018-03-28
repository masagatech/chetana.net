<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DCReturnedBook.aspx.cs" Inherits="DCReturnedBook" Title="DC Returned Book" %>

<%@ Register src="UserControls/ODC/uc_DC__Returnedbook.ascx" tagname="uc_DC__Returnedbook" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_DC__Returnedbook ID="uc_DC__Returnedbook1" runat="server" />
</asp:Content>

