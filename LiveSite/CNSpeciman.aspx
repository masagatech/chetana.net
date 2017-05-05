<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="CNSpeciman.aspx.cs" 
Inherits="CNSpeciman" Title="Chetana : Specimen Create D.C." %>

<%@ Register src="UserControls/uc_CNSpecimanMaster.ascx" tagname="uc_CNSpecimanMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:uc_CNSpecimanMaster ID="uc_CNSpecimanMaster1" runat="server" />
</asp:Content>

