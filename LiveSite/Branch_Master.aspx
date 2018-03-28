<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Branch_Master.aspx.cs" Inherits="Branch_Master" Title="Chetana:Branch Master" %>

<%@ Register src="~/UserControls/uc_BranchMaster.ascx" tagname="uc_BranchMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:uc_BranchMaster ID="uc_BranchMaster1" runat="server" />
</asp:Content>

