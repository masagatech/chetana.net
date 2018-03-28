<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DCReturnedBook_MD.aspx.cs" Inherits="Returnedbook_MD" Title="Returnedbook" %>

<%@ Register src="UserControls/ODC/uc_DC_Returnedbook_MD.ascx" tagname="uc_DC_Returnedbook_MD" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_DC_Returnedbook_MD ID="uc_DC_Returnedbook_MD1" runat="server" />
</asp:Content>

