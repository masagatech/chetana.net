<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="TargetMaster.aspx.cs" Inherits="TargetMaster" Title="Chetana : SET KRA" %>

<%@ Register src="UserControls/uc_TargetMaster.ascx" tagname="uc_TargetMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_TargetMaster ID="uc_TargetMaster1" runat="server" />
</asp:Content>

