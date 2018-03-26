<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Copy of Speciman.aspx.cs" 
Inherits="Speciman" Title="Chetana : Specimen Create D.C." %>

<%@ Register src="UserControls/uc_SpecimanMaster.ascx" tagname="uc_SpecimanMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:uc_SpecimanMaster ID="uc_SpecimanMaster1" runat="server" />
</asp:Content>

