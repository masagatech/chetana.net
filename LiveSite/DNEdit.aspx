<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DNEdit.aspx.cs" Inherits="DNEdit" Title="DN Edit" %>

<%@ Register src="UserControls/uc_DNEdit.ascx" tagname="uc_DNEdit" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uc_DNEdit ID="uc_DNEdit1" runat="server" />
</asp:Content>

