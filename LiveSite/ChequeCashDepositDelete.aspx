<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ChequeCashDepositDelete.aspx.cs" Inherits="ChequeCashDepositDelete" Title="Payment Receipt Delete" %>

<%@ Register src="UserControls/ODC/receipt/ChequeCashDepositDelete.ascx" tagname="ChequeCashDepositDelete" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ChequeCashDepositDelete ID="ChequeCashDepositDelete1" runat="server" />
</asp:Content>

