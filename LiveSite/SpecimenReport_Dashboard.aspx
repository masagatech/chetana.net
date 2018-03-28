<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SpecimenReport_Dashboard.aspx.cs" Inherits="Report_SpecimenReport_Dashboard" Title="Specimen Report Dashboard" %>

<%@ Register src="UserControls/uc_SpecimenrReport_Dashboard.ascx" tagname="uc_SpecimenrReport_Dashboard" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:uc_SpecimenrReport_Dashboard ID="uc_SpecimenrReport_Dashboard1" 
        runat="server" />
    
</asp:Content>

