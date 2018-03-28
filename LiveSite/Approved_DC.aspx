<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Approved_DC.aspx.cs" Inherits="Approved_DC" Title="Chetana : Specimen Approved D.C." %>

<%@ Register src="UserControls/uc_Approval.ascx" tagname="uc_Approval" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Approval ID="uc_Approval1" runat="server" />
</asp:Content>

