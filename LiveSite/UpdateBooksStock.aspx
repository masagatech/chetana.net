<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="UpdateBooksStock.aspx.cs" Inherits="UpdateBooksStock" Title="Update Books Stock" %>



<%@ Register src="UserControls/uc_UpdateBooksStock.ascx" tagname="uc_UpdateBooksStock" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <uc1:uc_UpdateBooksStock ID="uc_UpdateBooksStock1" runat="server" />

    
</asp:Content>

