<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Market_Review.aspx.cs" Inherits="Market_Review" Title="Market Review" %>

<%@ Register src="UserControls/uc_Market_Review.ascx" tagname="uc_Market_Review" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Market_Review ID="uc_Market_Review1" runat="server" />
</asp:Content>

