<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PurchaseRegisterNew.ascx.cs"
    Inherits="UserControls_PurchaseRegisterNew" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        JV Details Report<a href="Campaigns.aspx" title="back to campaign list"></a>
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
                        ValidationGroup="retun" Text="." ControlToValidate="txtFromDate"></asp:RequiredFieldValidator>
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
                        ValidationGroup="retun" Text="." ControlToValidate="txtToDate"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RadioButtonList ID="rdOptions" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Other</asp:ListItem>
                        <asp:ListItem>Bookwise</asp:ListItem>
                        <asp:ListItem>All</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlSD" runat="server">
                        <asp:ListItem>Summary</asp:ListItem>
                        <asp:ListItem>Details</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtEMcode" AutoPostBack="true" autocomplete="off" Width="150px"
                                CssClass="inp-form" TabIndex="1" runat="server" Height="15px" OnTextChanged="txtEMcode_TextChanged"></asp:TextBox>
                            <div id="dvcust" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtEMcode"
                                UseContextKey="true" ContextKey="Account" CompletionListElementID="dvcust">
                            </ajaxCt:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Button ID="btnget" runat="server" CssClass="submitbtn" OnClick="btnget_Click"
                        TabIndex="3" Text="Get" ValidationGroup="Discount" Width="80px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
    <asp:GridView ID="grdDetails" ShowFooter="true" CssClass="product-table" runat="server"
        AutoGenerateColumns="true" OnRowDataBound="grdDetails_RowDataBound" FooterStyle-HorizontalAlign="Right">
    </asp:GridView>
</div>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Discount"
    runat="server" ID="ss" />
