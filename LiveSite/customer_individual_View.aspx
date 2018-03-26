<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" 
AutoEventWireup="true" CodeFile="customer_individual_View.aspx.cs" 
Inherits="customer_individual_View" Title="Chetana- Customer Individual View" %>

<%@ Register src="UserControls/uc_CustomerMaster_Individual_View.ascx" tagname="uc_CustomerMaster_Individual_View" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_CustomerMaster_Individual_View ID="uc_CustomerMaster_Individual_View1" 
        runat="server" />
</asp:Content>

