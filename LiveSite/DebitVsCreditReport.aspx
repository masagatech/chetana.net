<%@ Page Title="Additional Commission Ledger" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DebitVsCreditReport.aspx.cs" Inherits="DebitVsCreditReport" %>

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
                Additional Commission Ledger<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlfalse" runat="server" CssClass="panelDetails" Width="755px" Height="30px">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblcust" CssClass="lbl-form" runat="server" Text="Client"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcustomerid" onfocus="setfocus('customer');" autocomplete="off"
                        Width="200px" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                    <div id="dvcust" class="divauto">
                    </div>
                    <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                        ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                        CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomerid"
                        UseContextKey="true" ContextKey="Account" CompletionListElementID="dvcust">
                    </ajaxCt:AutoCompleteExtender>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                        Enabled="true"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From Date"
                        ValidationGroup="pdateft" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="To Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                        Enabled="true"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttoDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttoDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To Date"
                        ValidationGroup="pdateft" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btnGetData" runat="server" Text="Get" TabIndex="4" Width="230%"
                        OnClick="btnGetData_Click" CssClass="submitbtn" />
                </td>
            </tr>
            <tr>
                <td width="50px">&nbsp;
                </td>
                <td colspan="4">
                    <asp:Label ID="lblCustName" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="panelReport" runat="server">
        <CR:CrystalReportViewer ID="DebitCredit" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
            HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
            HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
            Width="773px" ClientTarget="Auto" HasCrystalLogo="False" />
    </asp:Panel>
</asp:Content>

