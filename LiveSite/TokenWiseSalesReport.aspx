<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="TokenWiseSalesReport.aspx.cs" Inherits="UserControls_TokenWiseSalesReport"
    Title="TokenWise Sales Report" %>

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
                TokenWise Sales Report<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
      
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="720px" Height="40px">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblFromdateCust" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="4" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                            Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Fromdate"
                            ValidationGroup="AZone" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    </td>
                    <td>
                        <asp:Label ID="lblToDateCust" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTo" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                            Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
                            ValidationGroup="AZone" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                        <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtTo" MaskType="Date"
                            Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false" AutoComplete="true"
                            CultureName="en-US" />
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rdbselect" TabIndex="7" RepeatDirection="Horizontal"
                            CssClass="lbl-form" Width="300px">
                            <asp:ListItem Value="All" Text="All" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="Pending" Text="Pending"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="GetData"
                            Width="80px" ValidationGroup="AZone" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <CR:CrystalReportPartsViewer ID="CrystalReportPartsViewer1" runat="server" AutoDataBind="true"
            HasPageNavigationLinks="true" Height="1039px" Width="773px" />
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <CR:CrystalReportViewer ID="TokenWiseSale" runat="server" AutoDataBind="true" DisplayGroupTree="false"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="true" EnableParameterPrompt="false"
            EnableTheming="false" EnableToolTips="true" HasDrillUpButton="True" HasGotoPageButton="True"
            HasPageNavigationButtons="True" HasRefreshButton="true" HasSearchButton="True"
            HasToggleGroupTreeButton="True" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" />
    </div>
</asp:Content>
