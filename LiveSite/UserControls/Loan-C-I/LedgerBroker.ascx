<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LedgerBroker.ascx.cs"
    Inherits="UserControls_Loan_C_I_LedgerBroker" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Panel ID="pnlzone" CssClass="panelDetails" Width="520px" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Broker"></asp:Label>
            </td>
            <td colspan="3">
                <asp:UpdatePanel UpdateMode="Conditional" ID="upCodeUpdate" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEMcode" TabIndex="1" autocomplete="off" Width="250px" CssClass="inp-form"
                            runat="server" Height="15px"></asp:TextBox>
                        <div id="dvcust" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtEMcode"
                            UseContextKey="true" ContextKey="Account" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="rfvcust" runat="server" ErrorMessage="Require AC Name"
                            ValidationGroup="Discount12" ControlToValidate="txtEMcode">.</asp:RequiredFieldValidator>
                        <%--<asp:Label ID="lblshow" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
         <td width="60px">
                <asp:Label ID="Label1" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtfromdate" onblur="ValidInYearDate(this);" CssClass="inp-form" TabIndex="6"
                    runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtfromdate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-GB" />
                <%-- <ajaxCt:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlToValidate="txtTo"
                                            ControlExtender="MaskedEditExtender2" CssClass="RedLabel" Display="Dynamic" EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="Invalid Date" IsValidEmpty="False" ValidationExpression="^\d{2}/\d{2}/\d{4}$">  
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                        </ajaxCt:MaskedEditValidator>--%>
            </td>
            <td width="60px">
                <asp:Label ID="lblToDateCust" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTo" onblur="ValidInYearDate(this);" CssClass="inp-form" TabIndex="6"
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
