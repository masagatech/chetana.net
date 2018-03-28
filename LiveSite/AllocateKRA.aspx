<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="AllocateKRA.aspx.cs" Inherits="AllocateKRA" Title="CHETANA : AllocateKRA" %>

<%@ Register src="UserControls/uc_AllocateTarget.ascx" tagname="uc_AllocateTarget" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_AllocateTarget ID="uc_AllocateTarget1" runat="server" />
</asp:Content>

