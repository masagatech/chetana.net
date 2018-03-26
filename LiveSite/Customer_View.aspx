<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" 
AutoEventWireup="true" EnableEventValidation="false" CodeFile="Customer_View.aspx.cs" 
Inherits="Customer_View" Title="Chetana:Customer Master:View" %>


<%@ Register src="UserControls/uc_CustomerMaster_View.ascx" tagname="uc_CustomerMaster_View" tagprefix="uc1_View" %>

 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   

   
    <uc1_View:uc_CustomerMaster_View ID="uc_CustomerMaster1" runat="server" />
   

   
</asp:Content>

