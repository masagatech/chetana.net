<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DispatchEmail.aspx.cs" Inherits="DispatchEmail" %>









<%@ Register src="UserControls/ODC/uc_DispatchEmail.ascx" tagname="uc_DispatchEmail" tagprefix="uc1" %>









<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   

   
   

   
    <uc1:uc_DispatchEmail ID="uc_DispatchEmail1" runat="server" />
   

   
   

   
</asp:Content>

