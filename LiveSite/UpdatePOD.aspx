<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="UpdatePOD.aspx.cs" Inherits="UpdatePOD" %>



<%@ Register src="UserControls/uc_UpdatePodCourier.ascx" tagname="uc_UpdatePodCourier" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:uc_UpdatePodCourier ID="uc_UpdatePodCourier1" runat="server" />

</asp:Content>

