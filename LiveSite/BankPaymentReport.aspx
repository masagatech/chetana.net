﻿<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="BankPaymentReport.aspx.cs" Inherits="UserControls_BankPaymentReport" Title="Bank Payment Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Height="40px" Width="735px">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblBank" runat="server" CssClass="lbl-form" Text="Bank"></asp:Label>
                    </td>
                    <td>
                        <div id="dvBank" class="divauto">
                        </div>
                        <asp:TextBox ID="txtBank" onfocus="setfocus('Bank');" autocomplete="off" Width="130px"
                            CssClass="inp-form" TabIndex="1" runat="server" AutoPostBack="true" OnTextChanged="txtBank_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require Bank"
                            ValidationGroup="Discount" ControlToValidate="txtBank">.</asp:RequiredFieldValidator>
                        <ajaxCt:AutoCompleteExtender ID="Bank_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtBank"
                            UseContextKey="true" ContextKey="Bank" CompletionListElementID="dvBank">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RFVBank" runat="server" ErrorMessage="Require Bank Code"
                            ValidationGroup="Discount" ControlToValidate="txtBank">.</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lblBankName" CssClass="lbl-form" ForeColor="Blue" Font-Size="12px"
                            runat="server"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="lblDocNo" runat="server" CssClass="lbl-form" Text="DocumentNo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocNo" autocomplete="off" Width="130px" onkeypress="return  CheckNumeric(event)"
                            CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require DocumentNo"
                            ValidationGroup="S" ControlToValidate="txtDocNo">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" ValidationGroup="Discount"
                            CssClass="submitbtn" TabIndex="3" OnClick="btnget_Click" />
                    </td>
                </tr>

            </table>
        </asp:Panel>
        <br />
        <br />
        <CR:CrystalReportViewer ID="BankPaymentReport" runat="server"
            AutoDataBind="true" DisplayGroupTree="false" EnableDatabaseLogonPrompt="false"
            EnableDrillDown="false" EnableParameterPrompt="false" EnableTheming="false"
            EnableToolTips="false" HasDrillUpButton="false" HasGotoPageButton="false"
            HasPageNavigationButtons="false" HasRefreshButton="true"
            HasSearchButton="false" HasToggleGroupTreeButton="false" HasViewList="false"
            HasZoomFactorList="false" Height="1039px" Width="773px" />
    </div>
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Discount"
        runat="server" ID="ss" />
</asp:Content>


