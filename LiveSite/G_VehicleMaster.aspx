<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" 
CodeFile="G_VehicleMaster.aspx.cs" Inherits="G_VehicleMaster" Title="Vehicle Master : Chetana : Godown " %>

<%@ Register src="Godown/Vehicle.ascx" tagname="Vehicle" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Vehicle ID="Vehicle1" runat="server" />
</asp:Content>

