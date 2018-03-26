<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" 
AutoEventWireup="true" CodeFile="G_GetPass_Out_Multi.aspx.cs" Inherits="G_GetPass_Out" 
Title="Local Get Pass : Chetana : Godown" %>

 <%@ Register src="Godown/GetPass_Out_multi.ascx" tagname="GetPass_Out_multi" tagprefix="uc1" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <uc1:GetPass_Out_multi ID="GetPass_Out_multi1" runat="server" />
  
</asp:Content>

