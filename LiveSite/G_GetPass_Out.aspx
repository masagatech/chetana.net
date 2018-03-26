<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" 
AutoEventWireup="true" CodeFile="G_GetPass_Out.aspx.cs" Inherits="G_GetPass_Out" 
Title="Local Get Pass : Chetana : Godown" %>

<%@ Register src="Godown/GetPass_OutSide.ascx" tagname="GetPass_OutSide" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:GetPass_OutSide ID="GetPass_OutSide1" runat="server" />
</asp:Content>

