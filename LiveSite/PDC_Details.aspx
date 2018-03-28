<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="PDC_Details.aspx.cs" Inherits="PDC_Details" Title="PDC Details" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            PDC Details Report<a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
    <div>
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Height="40px" Width="735px">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblFromDate" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" Width="100px" runat="server" TabIndex="1" CssClass="inp-form"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtFromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter FromDate"
                            ValidationGroup="PDC" Text="." ControlToValidate="txtFromDate"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblToDate" runat="server" CssClass="lbl-form" Text="To Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" Width="100px" runat="server" TabIndex="2" CssClass="inp-form"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtToDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter ToDate"
                            ValidationGroup="PDC" Text="." ControlToValidate="txtToDate"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" ValidationGroup="PDC"
                            CssClass="submitbtn" TabIndex="3" OnClick="btnget_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <CR:CrystalReportViewer ID="PDCReport" runat="server" AutoDataBind="true" DisplayGroupTree="false"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
            EnableTheming="false" EnableToolTips="false" HasDrillUpButton="false" HasGotoPageButton="True"
            HasPageNavigationButtons="True" HasRefreshButton="true" HasSearchButton="True"
            HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" />
    </div>
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="PDC"
        runat="server" ID="ss" />
</asp:Content>
