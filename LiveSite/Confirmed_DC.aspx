<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Confirmed_DC.aspx.cs" Inherits="Confirmed_DC" Title="Chetana :  Specimen Confirmed D.C." %>

<%@ Register src="UserControls/uc_ConfirmedDC.ascx" tagname="uc_ConfirmedDC" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_ConfirmedDC ID="uc_ConfirmedDC1" runat="server" />
</asp:Content>

