<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="RailwayRegisterZone.aspx.cs" Inherits="RailwayRegisterZone" %>
<%@ Register src="~/Godown/RailwayZone.ascx" tagname="RailwayZone" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:RailwayZone ID="RailwayZone1" runat="server" />
</asp:Content>

