<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StockAgeing.ascx.cs" Inherits="UserControls_Loan_C_I_StockAgeing" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<style type="text/css">
    .style1
    {
        width: 71px;
    }
    .style2
    {
        width: 59px;
    }
    .inp-form
    {
        margin-left: 0px;
    }
</style>
<asp:Panel ID="pnlzone" CssClass="panelDetails" Width="496px" runat="server">
    <table>
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" Enabled="false" onblur="ValidInYearDate(this);" CssClass="inp-form"
                    TabIndex="1" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-GB" />
            </td>
            <td class="style2">
                <asp:Label ID="lblToDateCust" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTo" onblur="ValidInYearDate(this);" CssClass="inp-form" TabIndex="2"
                    runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-GB" />
                <%-- <ajaxCt:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlToValidate="txtTo"
                                            ControlExtender="MaskedEditExtender2" CssClass="RedLabel" Display="Dynamic" EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="Invalid Date" IsValidEmpty="False" ValidationExpression="^\d{2}/\d{2}/\d{4}$">  
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                        </ajaxCt:MaskedEditValidator>--%>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnget" CssClass="submitbtn" TabIndex="8" runat="server" Text="Get Data"
                    Width="80px" ValidationGroup="AZone" OnClick="btnget_Click" />
            </td>
        </tr>
    </table>
    <div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
            ValidationGroup="AZone" ControlToValidate="txtTo"></asp:RequiredFieldValidator>
 
    </div>
</asp:Panel>
<CR:CrystalReportViewer ID="crtAgging" runat="server" HasGotoPageButton="True" AutoDataBind="false"
    HasSearchButton="True" DisplayGroupTree="False" EnableDatabaseLogonPrompt="false"
    EnableDrillDown="false" HasCrystalLogo="False" EnableParameterPrompt="false"
    EnableTheming="false" EnableToolTips="false" HasDrillUpButton="False" HasPageNavigationButtons="True"
    HasRefreshButton="False" HasToggleGroupTreeButton="false" HasViewList="False"
    HasZoomFactorList="False" Width="773px" />
