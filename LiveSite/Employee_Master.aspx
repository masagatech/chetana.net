<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Employee_Master.aspx.cs"
 Inherits="Employee_Master" Title="Chetana:Employee Master" %>
<%@ Register src="UserControls/uc_EmployeeMaster.ascx" tagname="uc_EmployeeMaster" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_EmployeeMaster ID="uc_EmployeeMaster1" runat="server" />
</asp:Content>

