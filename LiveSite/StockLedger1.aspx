<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
    AutoEventWireup="true" CodeFile="StockLedger.aspx.cs" Inherits="StockLedger" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlzone" CssClass="panelDetails" Width="496px" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Book Code" CssClass="lbl-form"></asp:Label>
                </td>
                <td colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtbkcod" CssClass="inp-form" AutoPostBack="true" autocomplete="off"
                                TabIndex="3" runat="server" Enabled="true"></asp:TextBox>
                            <div id="divwidth" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbkcod"
                                UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
                            </ajaxCt:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="inp-form" 
                        onblur="ValidInYearDate(this);" TabIndex="1"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtTo" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                        AutoComplete="true" CultureName="en-GB" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                        TargetControlID="txtFromDate" />
                </td>
                <td class="style2">
                    <asp:Label ID="lblToDateCust" runat="server" CssClass="lbl-form" Text="To Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTo" runat="server" CssClass="inp-form" onblur="ValidInYearDate(this);"
                        TabIndex="2"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtTo" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="true"
                        AutoComplete="true" CultureName="en-GB" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                        TargetControlID="txtTo" />
                    <%-- <ajaxCt:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlToValidate="txtTo"
                                            ControlExtender="MaskedEditExtender2" CssClass="RedLabel" Display="Dynamic" EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="Invalid Date" IsValidEmpty="False" ValidationExpression="^\d{2}/\d{2}/\d{4}$">  
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                        </ajaxCt:MaskedEditValidator>--%>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnget" runat="server" CssClass="submitbtn" OnClick="btnget_Click"
                        TabIndex="8" Text="Get Data" ValidationGroup="AZone" Width="80px" />
                </td>
            </tr>
        </table>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
                ValidationGroup="AZone" ControlToValidate="txtTo"></asp:RequiredFieldValidator>
        </div>
    </asp:Panel>
    <CR:CrystalReportViewer ID="crtStLedger" runat="server" HasGotoPageButton="True"
        AutoDataBind="false" HasSearchButton="True" DisplayGroupTree="False" EnableDatabaseLogonPrompt="false"
        EnableDrillDown="false" HasCrystalLogo="False" EnableParameterPrompt="false"
        EnableTheming="false" EnableToolTips="false" HasDrillUpButton="False" HasPageNavigationButtons="True"
        HasRefreshButton="False" HasToggleGroupTreeButton="false" HasViewList="False"
        HasZoomFactorList="False" Width="773px" />
</asp:Content>
