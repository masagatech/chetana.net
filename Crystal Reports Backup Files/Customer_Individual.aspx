<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" 
AutoEventWireup="true" CodeFile="Customer_Individual.aspx.cs" 
Inherits="Customer_Individual" Title="Chetana- Customer Individual Update" %>

<%@ Register src="UserControls/uc_CustomerMaster_Individual.ascx" tagname="uc_CustomerMaster_Individual" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_CustomerMaster_Individual ID="uc_CustomerMaster_Individual1" 
        runat="server" />
</asp:Content>

