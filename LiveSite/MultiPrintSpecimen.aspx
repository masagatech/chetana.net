<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="MultiPrintSpecimen.aspx.cs" 
Inherits="MultiPrintSpecimen" Title="Chetana : Print Specimen" %>

<%@ Register src="~/UserControls/uc_Multi_Print_Specimen.ascx" tagname="uc_Print_Speciman" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Print_Speciman ID="uc_Print_Speciman" runat="server" />
</asp:Content>

