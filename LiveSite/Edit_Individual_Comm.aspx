<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/NewChetana.master"  CodeFile="Edit_Individual_Comm.aspx.cs" Inherits="Edit_Individual_Comm" %>

<%@ Register src="UserControls/uc_Edit_Individual_Comm.ascx" tagname="uc_Comm" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Comm ID="uc_Comm1" runat="server" />
</asp:Content>
