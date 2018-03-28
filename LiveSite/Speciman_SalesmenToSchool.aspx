<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Speciman_SalesmenToSchool.aspx.cs" Inherits="Speciman_SalesmenToSchool" Title="Chetana : Specimen Salesman To School" %>

<%@ Register src="UserControls/uc_SalesmantoSchool.ascx" tagname="uc_SalesmantoSchool" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:uc_SalesmantoSchool ID="uc_SalesmantoSchool12" runat="server" />
</asp:Content>

