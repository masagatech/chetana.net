<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ViewEmployee_Master.aspx.cs" Inherits="ViewEmployee_Master" Title="View Employee" %>

<%@ Register src="UserControls/uc_View_EmployeeMaster.ascx" tagname="uc_View_EmployeeMaster" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_View_EmployeeMaster ID="uc_View_EmployeeMaster1" runat="server" />
</asp:Content>

