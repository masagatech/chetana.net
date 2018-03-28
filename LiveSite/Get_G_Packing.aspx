<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Get_G_Packing.aspx.cs" Inherits="Get_G_Packing" Title="Packing Report" %>

<%@ Register src="Godown/Get_Packing.ascx" tagname="Get_Packing" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Get_Packing ID="Get_Packing1" runat="server" />
</asp:Content>

