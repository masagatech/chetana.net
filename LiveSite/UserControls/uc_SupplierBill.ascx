<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SupplierBill.ascx.cs" Inherits="UserControls_uc_SupplierBill" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Supplier Bill<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<br />
<br />
<asp:Panel ID="pnlpurch" DefaultButton="btnAdd" CssClass="panelDetails" runat="server" Style="width: auto; height: auto;">
    <div style="float: right;">
        <asp:Button ID="btn_Save" CssClass="submitbtn" ValidationGroup="ct1" TabIndex="10"
            runat="server" Text="Save" Width="100px" Height="25px" OnClick="btn_Save_Click" />
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="5" cellspacing="5" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblSupplier" runat="server" CssClass="lbl-form" Text="Supplier Name"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:Label ID="lblSBillID" runat="server" CssClass="hide"></asp:Label>
                        <asp:TextBox ID="txtSupplierName" AutoComplete="off" Width="250px" CssClass="inp-form"
                            TabIndex="1" runat="server" Height="15px" AutoPostBack="true" OnTextChanged="txtSupplierName_TextChanged">
                        </asp:TextBox>
                        <div id="Div1" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="aceSupplierName" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtSupplierName"
                            UseContextKey="true" ContextKey="VatAccountSup" CompletionListElementID="Div2">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="rfvSupplierName" runat="server" ErrorMessage="Enter Supplier Name"
                            ValidationGroup="ct1" ControlToValidate="txtSupplierName">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblSupplierCode" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPurchase" runat="server" CssClass="lbl-form" Text="Purchase Name"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPurchaseName" autocomplete="off" Width="250px" CssClass="inp-form"
                            TabIndex="2" runat="server" Height="15px" AutoPostBack="true" OnTextChanged="txtPurchaseName_TextChanged"></asp:TextBox>
                        <div id="Div2" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="acePurchaseName" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtPurchaseName"
                            UseContextKey="true" ContextKey="VatAccountPur" CompletionListElementID="Div2">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="rfvPurchaseName" runat="server" ErrorMessage="Require Purchase Name"
                            ValidationGroup="ct1" ControlToValidate="txtPurchaseName">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblPurchaseCode" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="100px">
                        <asp:Label ID="lblInvoiceNo" runat="server" CssClass="lbl-form" Text="Invoice No."></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInvoiceNo" autocomplete="off" Width="250px" CssClass="inp-form"
                            TabIndex="3" runat="server" Height="15px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvInvoiceNo" runat="server" ValidationGroup="ct1" ErrorMessage="Enter Invoice No"
                            ControlToValidate="txtInvoiceNo">.</asp:RequiredFieldValidator>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblInvoiceDate" runat="server" CssClass="lbl-form" Text="Invoice Date"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInvoiceDate" AutoComplete="off" Width="250px" CssClass="inp-form" TabIndex="4" runat="server" Height="15px">
                        </asp:TextBox>
                        <ajaxCt:CalendarExtender ID="ceInvoiceDate" runat="server" Format="dd/MM/yyyy" TargetControlID="txtInvoiceDate" />
                        <ajaxCt:MaskedEditExtender ID="meeInvoiceDate" runat="server" TargetControlID="txtInvoiceDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="rfvInvoiceDate" runat="server" ErrorMessage="Enter Invoice Date"
                            ValidationGroup="ct1" ControlToValidate="txtInvoiceDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGSTPer" runat="server" CssClass="lbl-form" Text="GST Percentage"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGSTPer" runat="server" DataValueField="Key" DataTextField="Value" CssClass="inp-form"
                            Width="250px" Height="25px" TabIndex="5">
                        </asp:DropDownList>
                        %
                        <asp:RequiredFieldValidator ID="rfvGSTPer" runat="server" InitialValue="0" ValidationGroup="ct1" ErrorMessage="Select GST Percentage"
                            ControlToValidate="ddlGSTPer">.</asp:RequiredFieldValidator>
                    </td>
                    <td></td>
                </tr>
            </table>
            <br />
            <table cellpadding="5" cellspacing="5" width="100%">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblAccount" runat="server" CssClass="lbl-form" Text="Account Name"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lblQuantity" runat="server" CssClass="lbl-form" Text="Quantity"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lblAmount" runat="server" CssClass="lbl-form" Text="Amount"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lblRemark" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
                    </td>
                    <td valign="top"></td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblSBillDID" runat="server" CssClass="hide"></asp:Label>
                        <asp:TextBox ID="txtAccountName" runat="server" autocomplete="off" CssClass="inp-form" Height="15px" TabIndex="6" Width="150px"></asp:TextBox>
                        <div id="divACName" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="aceAccountName" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtAccountName"
                            UseContextKey="true" ContextKey="Account" CompletionListElementID="divACName">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="rfvAccountName" runat="server" ControlToValidate="txtAccountName"
                            ErrorMessage="Require Account Name" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtQuantity" Width="50px" CssClass="inp-form text-right" TabIndex="7" Height="15px" runat="server" Enabled="false">
                        </asp:TextBox>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="inp-form text-right" Height="15px" TabIndex="5" Width="100px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ControlToValidate="txtAmount"
                            ErrorMessage="Require Amount" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" CssClass="inp-form" Height="100px"
                            TabIndex="8" Width="300px">
                        </asp:TextBox>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAdd" CssClass="submitbtn" ValidationGroup="ct" runat="server"
                            Text="Add" TabIndex="9" Width="80px" OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </table>

            <asp:ValidationSummary ID="sum" runat="server" ValidationGroup="ct1" ShowMessageBox="true"
                ShowSummary="false" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ct"
                ShowMessageBox="true" ShowSummary="false" />

            <div id="divSuppDetails" runat="server" class="hide">
                <div class="float-right">
                    <asp:Button ID="btnDeleteAll" CssClass="submitbtn" runat="server" Text="Delete All" TabIndex="9" Width="80px" OnClick="btnDeleteAll_Click" />
                </div>

                <div class="m-30">
                    <asp:GridView ID="gvSupplierBill" runat="server" AutoGenerateColumns="false" CssClass="product-table"
                        OnRowDataBound="gvSupplierBill_RowDataBound" OnRowDeleting="gvSupplierBill_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Account Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSBillDID" runat="server" Text='<%#Eval("SBillDID") %>' CssClass="hide"></asp:Label>
                                    <asp:Label ID="lblAccountCode" runat="server" Text='<%#Eval("AccountCode") %>' CssClass="hide"></asp:Label>
                                    <asp:Label ID="lblAccountName" runat="server" Text='<%#Eval("AccountName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remark">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remark">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="submitbtn" Width="80px" CausesValidation="false" CommandName="Delete"
                                        TabIndex="10" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

                <table cellspacing="5" cellpadding="5" class="product-table">
                    <tr>
                        <td>Total Amount :</td>
                        <td>
                            <asp:Label ID="lblTotalAmount" runat="server" CssClass="lbl-form"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>GST Amount :</td>
                        <td>
                            <asp:Label ID="lblGSTAmount" runat="server" CssClass="lbl-form"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>GrandTotal :</td>
                        <td>
                            <asp:Label ID="lblGrandTotal" runat="server" CssClass="lbl-form"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
