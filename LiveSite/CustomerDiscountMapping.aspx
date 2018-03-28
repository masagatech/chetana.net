<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="CustomerDiscountMapping.aspx.cs" Inherits="CustomerDiscountMapping" Title="Chetana:Customer Discount" %>

 
<%@ Register src="~/UserControls/uc_Customer_Discount_Mapping.ascx" tagname="uc_Customer_Discount_Mapping" tagprefix="uc1" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:uc_Customer_Discount_Mapping ID="uc_Customer_Discount_Mapping1" runat="server" />
    
</asp:Content>

