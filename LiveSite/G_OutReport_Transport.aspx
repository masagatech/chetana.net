<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="G_OutReport_Transport.aspx.cs" Inherits="G_OutReport_Transport" Title="Transporter Parcel Delivery Report" %>

<%@ Register src="Godown/GetOut_Customer_Delivery.ascx" tagname="GetOut_Customer_Delivery" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:GetOut_Customer_Delivery ID="GetOut_Customer_Delivery1" runat="server" />
</asp:Content>

