<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Confirm_DC.aspx.cs" Inherits="Confirm_DC" Title="Chetana :  Specimen Confirm D. C." %>

<%@ Register Src="UserControls/uc_ConfirmDC.ascx" TagName="uc_ConfirmDC" TagPrefix="uc1" %>
<%@ Register Src="UserControls/uc_Get_NotConfirmDcBooks.ascx" TagName="uc_Get_NotConfirmDcBooks"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:uc_ConfirmDC ID="uc_ConfirmDC1" runat="server"/>
    <uc2:uc_Get_NotConfirmDcBooks ID="uc_Get_NotConfirmDcBooks1"  Visible="false"  runat="server" />
</asp:Content>
