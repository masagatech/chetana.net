<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="UpdateRate.aspx.cs" Inherits="UpdateRate" Title="Update Rate" %>

<%@ Register src="UserControls/uc_UpdateRate.ascx" tagname="uc_UpdateRate" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_UpdateRate ID="uc_UpdateRate1" runat="server" />
</asp:Content>

