<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
 AutoEventWireup="true" CodeFile="Cutomer_BlackList_View.aspx.cs" 
 Inherits="Cutomer_BlackList_View" Title="Black List View" %>

<%@ Register src="UserControls/uc_Customer_BlackList_View.ascx" tagname="uc_Customer_BlackList_View" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Customer_BlackList_View ID="uc_Customer_BlackList_View1" 
        runat="server" />
</asp:Content>

