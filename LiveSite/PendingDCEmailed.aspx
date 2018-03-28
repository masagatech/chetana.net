<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="PendingDCEmailed.aspx.cs" Inherits="PendingDCEmailed" %>



<%@ Register src="UserControls/ODC/uc_PendingDCEmailed.ascx" tagname="uc_PendingDCEmailed" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <uc1:uc_PendingDCEmailed ID="uc_PendingDCEmailed1" runat="server" />
 
</asp:Content>

