﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_PurchaseMaster_Vat.ascx.cs"
    Inherits="UserControls_uc_PurchaseMaster_Vat" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Purchase Master<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<div style="float: right; width: 53%">
    <asp:Button ID="btn_Save" CssClass="submitbtn" ValidationGroup="ct1" TabIndex="10"
        runat="server" Text="Save" Width="87px" OnClick="btn_Save_Click" />
</div>
<br />
<br />
<asp:Panel ID="pnlpurch" CssClass="panelDetails" runat="server" Width="800px" Height="160px">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="Purchase Code"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="txtPurchase" autocomplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="1" runat="server" AutoPostBack="true" Height="15px" OnTextChanged="txtPurchase_TextChanged"></asp:TextBox>
                        <div id="Div2" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtPurchase"
                            UseContextKey="true" ContextKey="VatAccountPur" CompletionListElementID="Div2">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="rfvcust" runat="server" ErrorMessage="Require Purchase Name"
                            ValidationGroup="ct1" ControlToValidate="txtPurchase">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblpurchase" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="100px">
                        <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="lblID1" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="lblInvoce" runat="server" CssClass="lbl-form" Text="Invoice No."></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInvAlfa" ToolTip="text from invoice no." Width="50px" TabIndex="2"
                            autocomplete="off" MaxLength="8" runat="server" CssClass="inp-form"></asp:TextBox>
                        <asp:TextBox ID="txtInvoiceNo" autocomplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="2" runat="server" Height="15px" AutoPostBack="true" onkeypress="return CheckNumeric(event)"
                            OnTextChanged="txtInvoiceNo_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqfi" runat="server" ValidationGroup="ct1" ErrorMessage="Enter Invoice NO"
                            ControlToValidate="txtInvoiceNo">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSupplier" runat="server" CssClass="lbl-form" Text="Supplier Code"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <%--<asp:UpdatePanel ID="hh" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="txtSupplier" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="3" runat="server" Height="15px" AutoPostBack="true" OnTextChanged="txtSupplier_TextChanged1">
                        </asp:TextBox>
                        <div id="Div2" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtSupplier"
                            UseContextKey="true" ContextKey="VatAccountSup" CompletionListElementID="Div2">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:Label ID="lblshow" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Supplier"
                            ValidationGroup="ct1" ControlToValidate="txtSupplier">.</asp:RequiredFieldValidator>
                        <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDate" runat="server" CssClass="lbl-form" Text="Invoice Date"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" onblur="ValidInYearDate(this);" AutoComplete="off" Width="150px"
                            CssClass="inp-form" TabIndex="3" runat="server" Height="15px">
                        </asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtDate" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Date"
                            ValidationGroup="ct1" ControlToValidate="txtDate">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="Vat(%)"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlmsoms" Width="120px" TabIndex="3" runat="server" OnSelectedIndexChanged="ddlmsoms_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem Text="MS" Value="MS"></asp:ListItem>
                            <asp:ListItem Text="OMS" Value="OMS"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlVat" Width="120px" TabIndex="3" DataTextField="value" DataValueField="value"
                            runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVat_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lbl2ID" runat="server" Style="display: none"></asp:Label>
                        <asp:Label ID="lblCode" runat="server" CssClass="lbl-form" Text="Book Code"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lblQuantity" runat="server" CssClass="lbl-form" Text="Quantity"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lblRate" runat="server" CssClass="lbl-form" Text="Rate"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lblper" runat="server" CssClass="lbl-form" Text="per"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lblDisc" runat="server" CssClass="lbl-form" Text="Disc. %"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lblAmount" Style="display: none" runat="server" CssClass="lbl-form"
                            Text="Amount"></asp:Label>
                        <asp:Label ID="lblDisc0" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>--%>
                    <td valign="top">
                        <asp:TextBox ID="txtCode" Text="mis" runat="server" autocomplete="off" AutoPostBack="true"
                            CssClass="inp-form" Height="15px" TabIndex="3" Width="100px" OnTextChanged="txtCode_TextChanged"></asp:TextBox>
                        <div id="dvcust" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="dvcust" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="10" ContextKey="book"
                            DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                            ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtCode"
                            UseContextKey="true">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCode"
                            ErrorMessage="Require Book Code" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                        <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtQuantity" onkeypress="return CheckNumeric(event)" Width="100px"
                            CssClass="inp-form" TabIndex="4" Height="15px" runat="server">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuantity"
                            ErrorMessage="Require Quantity" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                    </td>
                    <td valign="top">
                        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="txtRate" runat="server" CssClass="inp-form" Height="15px" onkeypress="return CheckNumericWithDot(event)"
                            TabIndex="5" Width="100px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRate"
                            ErrorMessage="Require Rate" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                        <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtper" Text="No." runat="server" CssClass="inp-form" Height="15px"
                            TabIndex="6" Width="100px">
                        </asp:TextBox>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtDisc" Text="0.00" onkeypress="return CheckNumericWithDot(event)"
                            runat="server" CssClass="inp-form" Height="15px" TabIndex="7" Width="100px">
                        </asp:TextBox>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtAmount" Style="display: none" onkeypress="return CheckNumericWithDot(event)"
                            runat="server" CssClass="inp-form" Height="15px" TabIndex="333" Width="100px">
                        </asp:TextBox>
                        <asp:TextBox ID="txtremark" runat="server" CssClass="inp-form" Height="15px" TabIndex="8"
                            TextMode="MultiLine" Width="103px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" CssClass="submitbtn" ValidationGroup="ct" runat="server"
                            Text="Add" TabIndex="9" Width="80px" OnClick="btnAdd_Click" />
                    </td>
                    <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
                </tr>
                <tr>
                    <td colspan="6" valign="top">
                        <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                        <asp:Label ID="lblDescriptionofGoods" runat="server" CssClass="lbl-form" Font-Size="15px"
                            ForeColor="Blue"></asp:Label>
                        <asp:Label ID="lblStandard" Visible="false" runat="server" CssClass="lbl-form" Font-Size="15px"></asp:Label>
                        <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<asp:ValidationSummary ID="sum" runat="server" ValidationGroup="ct1" ShowMessageBox="true"
    ShowSummary="false" />
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ct"
    ShowMessageBox="true" ShowSummary="false" />
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:GridView ID="gvPurchasing" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
            ShowFooter="true" CellPadding="4" CssClass="product-table" ForeColor="#333333"
            Width="735px" PageSize="100" OnRowDataBound="gvPurchasing_RowDataBound" OnRowDeleting="gvPurchasing_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="left">
                    <ItemTemplate>
                        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description of Goods" ItemStyle-HorizontalAlign="left">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Standard" ItemStyle-HorizontalAlign="left">
                    <ItemTemplate>
                        <asp:Label ID="lblstandard" runat="server" Text='<%#Eval("Standard") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lbltotalQuantity" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate","{0:0.00}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="per" ItemStyle-HorizontalAlign="left" HeaderStyle-Width="40px">
                    <ItemTemplate>
                        <asp:Label ID="lblRemarksave" runat="server" Text='<%#Eval("Per") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discount" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblDisc" runat="server" Text='<%#Eval("Discount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount","{0:0.00}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="lblDeleteExp" runat="server" CausesValidation="false" CommandName="Delete"
                            CssClass="close" ToolTip="Remove" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do You want to Delete?')" />
                        <%--<asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CssClass="close" 
                        ImageUrl="../../Images/icon/save_as.png" CommandName="Edit" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Panel ID="pndDetails" runat="server" Width="674px">
            <table style="width: 100%; text-align: right;" runat="server" id="summery">
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Sub Total"></asp:Label>
                    </td>
                    <td style="width: 100px;">
                        <asp:Label ID="lblSubTotal" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblVatper" runat="server" Text="VAT (%)"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblVatAmt" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Font-Bold="true" Text="Grand Total"></asp:Label>
                    </td>
                    <td style="border-top: 2px double #ccc;">
                        <asp:Label ID="lblGrandTot" Font-Bold="true" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddlVat" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlmsoms" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
<br />
<br />
<br />
<asp:Panel ID="pnlArea" CssClass="panelDetails" runat="server" Width="710px">
    <table cellpadding="2" cellspacing="2" style="width: 60%">
        <tr>
            <td>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="From Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtfromdate" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtfromdate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="reqFdate" runat="server" ErrorMessage="Require From Date"
                    ValidationGroup="date" ControlToValidate="txtfromdate">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="To Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txttodate" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txttodate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Reqtdate" runat="server" ErrorMessage="Require To date"
                    ValidationGroup="date" ControlToValidate="txttodate">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Invoice No"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtinvoice" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnget" runat="server" TabIndex="4" CssClass="submitbtn" Text="Get"
                    Width="80px" ValidationGroup="date" OnClick="btnget_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdpurchaseDetails" runat="server" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="100" Width="735px"
        OnRowDataBound="grdpurchaseDetails_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"
                HeaderText="Invoice No." ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <%-- <asp:Label ID="lblAreaID" runat="server" Style="display: none" Text='<%#Eval("AreaID")%>'></asp:Label>--%>
                    <asp:Label ID="lblInvoiceNo" Style="display: none" runat="server" Text='<%#Eval("InvoiceNo") %>'></asp:Label>
                    <asp:Label ID="lblinv2" runat="server" Text='<%#Eval("InvConc") %>'></asp:Label>
                    <asp:Label ID="lblinv3" Style="display: none" runat="server" Text='<%#Eval("Inv_No") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Purchace Code" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblPurchCode" runat="server" Text='<%#Eval("PurchaseCode")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Purchace Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblPurchName" runat="server" Text='<%#Eval("PurchaseName")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Supplier's Ref." ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblSuppliersRef" runat="server" Text='<%#Eval("SuppliersRef")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblInvoiceDate" runat="server" Text='<%#Eval("InvoiceDate")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblDescription5" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Per" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblper" runat="server" Text='<%#Eval("Per")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Disc.(%)" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblamount" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle CssClass="alt" />
    </asp:GridView>
</asp:Panel>

<script type="text/javascript">
     setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
   document.getElementById('status').innerHTML=status;
   }
</script>

<script type="text/javascript">
      
shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_PurchaseMaster1_btn_Save').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>

<asp:ValidationSummary ID="val" runat="server" ValidationGroup="date" ShowMessageBox="true"
    ShowSummary="false" />
