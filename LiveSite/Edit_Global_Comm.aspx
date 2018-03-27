<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Edit_Global_Comm.aspx.cs" Inherits="Edit_Global_Comm" %>

<%@ Register src="UserControls/uc_Edit_Global_Comm.ascx" tagname="uc_Comm" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_Comm ID="uc_Comm1" runat="server" />
</asp:Content>

