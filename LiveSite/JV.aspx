<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="JV.aspx.cs" Inherits="JV" Title="JV" %>

<%@ Register src="UserControls/uc_JV.ascx" tagname="uc_JV" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_JV ID="uc_JV1" runat="server" />
</asp:Content>

