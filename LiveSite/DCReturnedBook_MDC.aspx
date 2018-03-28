<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DCReturnedBook_MDC.aspx.cs" Inherits="DCReturnedBook_MDC" Title="Returned Book" %>

<%@ Register src="UserControls/ODC/uc_DC__Returnedbook_MDC.ascx" tagname="uc_DC__Returnedbook_MDC" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_DC__Returnedbook_MDC ID="uc_DC__Returnedbook_MDC1" runat="server" />
</asp:Content>

