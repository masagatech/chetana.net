﻿<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="BookType.aspx.cs" Inherits="BookType" Title="Chetana:Book Type" %>

<%@ Register src="UserControls/uc_Masterofmaster.ascx" tagname="uc_Masterofmaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Masterofmaster ID="uc_Masterofmaster1" runat="server" />
</asp:Content>

