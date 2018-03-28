<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="TeamMember.aspx.cs" Inherits="TeamMember" EnableEventValidation="true" %>
<%@ Register src="~/UserControls/uc_TeamMembers.ascx" tagname="uc_TeamMembers" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <uc1:uc_TeamMembers ID="uc_TeamMembers" runat="server"/>
</asp:Content>
