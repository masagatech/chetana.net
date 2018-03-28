<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="TrileBalence.aspx.cs" Inherits="UserControls_TrileBalence" Title="TrileBalence" %>







<%@ Register src="UserControls/ODC/uc_TrileBalence.ascx" tagname="uc_TrileBalence" tagprefix="uc1" %>







<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
   
    <uc1:uc_TrileBalence ID="uc_TrileBalence1" runat="server" />
   
   
   
</asp:Content>

