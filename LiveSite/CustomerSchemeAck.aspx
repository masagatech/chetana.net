<%@ Page  Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" Title ="Scheme Report"
    AutoEventWireup="true" CodeFile="CustomerSchemeAck.aspx.cs" Inherits="CustomerSchemeAck" %>

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
                Schemewise Customer<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="820px">
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                                    Width="80px" CssClass="inp-form" TabIndex="7" runat="server" AutoPostBack="true"
                                    OnTextChanged="txtcustomer_TextChanged"></asp:TextBox>
                                <div id="dvcust" class="divauto350">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                    ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                                    UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                                    ValidationGroup="S" ControlToValidate="txtcustomer">.</asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:Button ID="btnget" CssClass="submitbtn" TabIndex="8" runat="server" Text="Get Data"
                            Width="80px" ValidationGroup="AZone" onclick="btnget_Click" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                    Width="400px" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <CR:CrystalReportViewer ID="schemeCustomer" runat="server" AutoDataBind="true" DisplayGroupTree="false"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
            EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
            HasRefreshButton="true" HasSearchButton="True" HasToggleGroupTreeButton="False"
            HasViewList="false" HasZoomFactorList="false" Height="1039px" Width="773px" ShowAllPageIds="True" />
    </div>
</asp:Content>
