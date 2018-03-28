<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="BookWiseReport.aspx.cs" Inherits="BookWiseReport" Title="Chetana : Book-Wise Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Panel ID="pnlbooks" CssClass="panelDetails" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="1" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require From Date"
                            ValidationGroup="book" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="TO Date" CssClass="lbl-form"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="toDate" runat="server" TargetControlID="txttoDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To Date"
                            ValidationGroup="book" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblBookName" runat="server" Text="Book Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBook" runat="server" CssClass="inp-form" TabIndex="3" Width="80px"></asp:TextBox>
                                                <div id="divwidth" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtBook"
                                UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
                            </ajaxCt:AutoCompleteExtender>
                    </td>
                    <td>
                        <asp:Button ID="btnget" TabIndex="4"  runat="server" Width="80px" Text="Get" CssClass="submitbtn"
                            ValidationGroup="book" OnClick="btnget_Click" Style="height: 26px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <CR:CrystalReportViewer ID="cryBookwise" runat="server" AutoDataBind="true" DisplayGroupTree="false"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
            EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
            HasRefreshButton="true" HasSearchButton="false" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" ShowAllPageIds="True" />
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="book"
            runat="server" ID="ss" />
    </div>
</asp:Content>
