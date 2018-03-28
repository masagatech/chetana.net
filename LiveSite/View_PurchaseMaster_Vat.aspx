<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="View_PurchaseMaster_Vat.aspx.cs" Inherits="View_PurchaseMaster" Title="Purchase Master View" %>

<%@ Register src="~/UserControls/uc_PurchaseMaster_Ind_View_Vat.ascx" tagname="uc_PurchaseMaster_Ind_View" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:uc_PurchaseMaster_Ind_View ID="uc_PurchaseMaster_Ind_View_Vat1" 
  runat="server" />
</asp:Content>

