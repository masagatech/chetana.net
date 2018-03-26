<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Get_LocalOut_Pass_Report.aspx.cs" Inherits="Get_LocalOut_Pass_Report" Title="Local Out Pass Report" %>

<%@ Register src="Godown/Get_LocalOut_Pass.ascx" tagname="Get_LocalOut_Pass" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Get_LocalOut_Pass ID="Get_LocalOut_Pass1" runat="server" />
</asp:Content>

