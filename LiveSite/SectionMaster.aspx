<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SectionMaster.aspx.cs" Inherits="SectionMaster" Title="Chetana:Section Master" %>

<%@ Register src="UserControls/uc_SectionMaster.ascx" tagname="uc_SectionMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_SectionMaster ID="uc_SectionMaster1" runat="server" />
<div></div>
</asp:Content>

