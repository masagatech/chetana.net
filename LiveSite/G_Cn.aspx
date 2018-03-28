<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="G_Cn.aspx.cs" Inherits="G_Cn" Title="Godown CN" %>

<%@ Register src="Godown/CN.ascx" tagname="CN" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:CN ID="CN1" runat="server" />
</asp:Content>

