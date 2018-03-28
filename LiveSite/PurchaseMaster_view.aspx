<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
 CodeFile="PurchaseMaster_view.aspx.cs" Inherits="PurchaseMaster_view" Title="Purchase Details" %>

<%@ Register src="UserControls/UC_PurchaseMaster_View.ascx" tagname="UC_PurchaseMaster_View" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:UC_PurchaseMaster_View ID="UC_PurchaseMaster_View1" runat="server" />

</asp:Content>

