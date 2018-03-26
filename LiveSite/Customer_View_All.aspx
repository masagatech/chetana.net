<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
 AutoEventWireup="true" CodeFile="Customer_View_All.aspx.cs" Inherits="Customer_View_All" Title="Customer View" %>

<%@ Register src="UserControls/uc_CustomerMaster_Individual_View.ascx" 
tagname="uc_CustomerMaster_Individual_View" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_CustomerMaster_Individual_View ID="uc_CustomerMaster_Individual_View1" 
        runat="server" />
</asp:Content>

