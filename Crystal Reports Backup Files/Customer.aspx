<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Customer.aspx.cs" Inherits="Customer" Title="Chetana:Customer Master" %>

 


 

<%@ Register src="UserControls/uc_CustomerMaster.ascx" tagname="uc_CustomerMaster" tagprefix="uc1" %>

 


 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   

   
    <uc1:uc_CustomerMaster ID="uc_CustomerMaster1" runat="server" />
   

   
</asp:Content>

