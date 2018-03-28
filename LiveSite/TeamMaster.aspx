<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="TeamMaster.aspx.cs" Inherits="TeamMaster" %>

<%@ Register src="~/UserControls/uc_TeamMaster.ascx" tagname="uc_TeamMaster" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <uc1:uc_TeamMaster ID="uc_TeamMaster" runat="server" />
</asp:Content>
