<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="Cutomer_BlackList.aspx.cs" Inherits="Cutomer_BlackList" Title="Chetana-Cutomer BlackList" %>

<%@ Register src="UserControls/uc_Customer_BlackList.ascx" tagname="uc_Customer_BlackList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Customer_BlackList ID="uc_Customer_BlackList1" runat="server" />
</asp:Content>

