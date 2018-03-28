<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="TransferOpeningBalance.aspx.cs" Inherits="UserControls_TransferOpeningBalance"
    Title="Transfer OpeningBalance" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: right; width: 101%">
        <div class="section-header">
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Transfer OpeningBalance<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="800px" Height="50px">
            <table border="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblfromDate" CssClass="lbl-form" runat="server" Text="From Date"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtFromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select FromDate"
                            ValidationGroup="AZone" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblTodate" CssClass="lbl-form" runat="server" Text="To Date"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtToDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please select ToDate"
                            ValidationGroup="AZone" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                    </td>
                 
                    <td>
                        <asp:Button ID="btnGet" CssClass="submitbtn" TabIndex="4" runat="server" Text="Get Data"
                            Width="80px" ValidationGroup="AZone" OnClick="btnGet_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btntransfer" CssClass="submitbtn" TabIndex="5" runat="server" Text="Transfer To O.B."
                            Width="100px" Visible="false" 
                            onclick="btntransfer_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <br />
        <br />
        <CR:CrystalReportViewer ID="cristTrialBalance" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="false" HasDrillUpButton="false"
            HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
            HasSearchButton="True" HasToggleGroupTreeButton="True" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" />
    </div>
</asp:Content>
