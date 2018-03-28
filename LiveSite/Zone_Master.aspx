<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="~/Zone_Master.aspx.cs" Inherits="Zone_Master" Title="Chetana:Zone Master" %>


<%@ Register src="UserControls/uc_ZoneMaster.ascx" tagname="uc_ZoneMaster" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:uc_ZoneMaster ID="uc_ZoneMaster1" runat="server" />
    
</asp:Content>

