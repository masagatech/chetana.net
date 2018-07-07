<%@ Page Title="Tally Integration" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="TallyIntegration.aspx.cs" Inherits="TallyIntegration" %>

<%@ Register Src="UserControls/uc_TallyIntegration.ascx" TagName="TallyIntegration" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:TallyIntegration ID="TallyIntegration1" runat="server" />
</asp:Content>
