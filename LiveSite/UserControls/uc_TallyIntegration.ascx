<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_TallyIntegration.ascx.cs" Inherits="UserControls_uc_TallyIntegration" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server" Width="100%">
    <table cellspacing="5" cellpadding="5" width="100%">
        <tr>
            <td width="15%">
                <asp:Label ID="lblfrmdt" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
            </td>
            <td width="35%">
                <asp:TextBox ID="txtFromDate" runat="server" CssClass="inp-form-text" TabIndex="1"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="ceFromDate" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="meFromDate" runat="server" TargetControlID="txtFromDate" MaskType="Date"
                    Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false" AutoComplete="true" CultureName="en-US" />
            </td>
            <td width="15%">
                <asp:Label ID="lbltodt" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label>
            </td>
            <td width="35%">
                <asp:TextBox ID="txtToDate" runat="server" CssClass="inp-form-text" TabIndex="2"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="ceToDate" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="meToDate" runat="server" TargetControlID="txtToDate" MaskType="Date"
                    Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false" AutoComplete="true" CultureName="en-US" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblcoa" runat="server" Text="Chart of A/C" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan="2"></td>
            <td>
                <asp:Button ID="btnDLoad_COA" runat="server" Text="Download Chart of A/C " CssClass="submitbtn" OnClick="btnDLoad_COA_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblbp" runat="server" Text="Bank Payment" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="upbp" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAutoBP" runat="server" TabIndex="3" CssClass="inp-form-text" autocomplete="off"
                            AutoPostBack="True" OnTextChanged="txtAutoBP_TextChanged"></asp:TextBox>
                        <div id="divAutoBP" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="aweBP" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtAutoBP"
                            UseContextKey="true" ContextKey="Bank" CompletionListElementID="div3">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:Label ID="lblAutoBP" runat="server" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtAutoBP" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Button ID="btnDLoad_BP" runat="server" Text="Download Bank Payment" CssClass="submitbtn" OnClick="btnDLoad_BP_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblbr" runat="server" Text="Bank Receivable" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="upbr" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAutoBR" runat="server" TabIndex="4" CssClass="inp-form-text" autocomplete="off"
                            AutoPostBack="True" OnTextChanged="txtAutoBR_TextChanged"></asp:TextBox>
                        <div id="divAutoBR" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="aweBR" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtAutoBR"
                            UseContextKey="true" ContextKey="Bank" CompletionListElementID="div3">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:Label ID="lblAutoBR" runat="server" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtAutoBP" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Button ID="btnDLoad_BR" runat="server" Text="Download Bank Receivable" CssClass="submitbtn" OnClick="btnDLoad_BR_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblinv" runat="server" Text="Invoices" TabIndex="5" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan="2"></td>
            <td>
                <asp:Button ID="btnDLoad_Inv" runat="server" Text="Download Excel" CssClass="submitbtn" OnClick="btnDLoad_Inv_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblcn" runat="server" Text="Credit Note" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan="2"></td>
            <td>
                <asp:Button ID="btnDLoad_CN" runat="server" Text="Download Invoices" CssClass="submitbtn" OnClick="btnDLoad_CN_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbljv" runat="server" Text="Journal Voucher" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan="2"></td>
            <td>
                <asp:Button ID="btnDLoad_JV" runat="server" Text="Download Journal Voucher" CssClass="submitbtn hide" OnClick="btnDLoad_JV_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:GridView ID="gvExportDetails" runat="server" ShowFooter="true" CssClass="product-table"
    AutoGenerateColumns="true" FooterStyle-HorizontalAlign="Right">
</asp:GridView>
