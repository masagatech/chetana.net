<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="EditSpecimenInv.aspx.cs" Inherits="EditSpecimenInv" Title="Edit Invoice" %>

<%@ Register src="UserControls/uc_editSpcInvoice.ascx" tagname="uc_editSpcInvoice" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_editSpcInvoice ID="uc_editSpcInvoice1" runat="server" />
</asp:Content>

