<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Uc_AccountMain_View.ascx.cs"
    Inherits="UserControls_ODC_receipt_Uc_AccountMain_View" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Account Main::View<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<div style="float: right; width: 42%">
    <asp:Button ID="btn_Save" CssClass="submitbtn" TabIndex="40" runat="server" Text="Edit"
        ValidationGroup="Discount12" Width="87px" OnClick="btn_Save_Click" />
    <asp:ValidationSummary ID="val" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Discount12" />
</div>
<br />
<br />
<asp:Panel ID="pnlCust" CssClass="panelDetails" runat="server" Width="638px" Height="550px">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="120px">
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <%--<asp:Label ID="lblID1" runat="server" Style="display: none;"></asp:Label>--%>
                <asp:Label ID="lblPartyName" runat="server" CssClass="lbl-form" Text="Ac Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
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
                        <asp:RequiredFieldValidator ID="rfvcust" runat="server" ErrorMessage="Require AC Name"
                            ValidationGroup="Discount12" ControlToValidate="txtEMcode">.</asp:RequiredFieldValidator>
                        <%--<asp:Label ID="lblshow" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblAcCode" runat="server" CssClass="lbl-form" Text="AC Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAcCode" autocomplete="off" AutoPostBack="true" Width="150px"
                            CssClass="inp-form" TabIndex="1" runat="server" Height="15px" OnTextChanged="txtAcCode_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require AC Code"
                            ValidationGroup="Discount12" ControlToValidate="txtAcCode">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAC_Group" runat="server" CssClass="lbl-form" Text="AC Group"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtGroup" autocomplete="off" Width="150px" CssClass="inp-form" TabIndex="2"
                            runat="server" AutoPostBack="true" Height="15px" OnTextChanged="txtGroup_TextChanged"></asp:TextBox>
                        <div id="dvcust" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtGroup"
                            UseContextKey="true" ContextKey="GR_HEAD" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Require Group Name"
                            ValidationGroup="Discount12" ControlToValidate="txtGroup">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblGroup" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="120px">
                        <asp:Label ID="lblAddress1" runat="server" CssClass="lbl-form" Text="First Address"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdd1" AutoComplete="off" Width="150px" CssClass="inp-form" TabIndex="3"
                            runat="server" Height="15px">
                        </asp:TextBox>
                        <%--<ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtVocDate" />  --%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Require Address"
                            ValidationGroup="Discount12" ControlToValidate="txtAdd1">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblBrokPerc" runat="server" CssClass="lbl-form" Text="Broker Perc"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBrokper" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="4" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAdd2" runat="server" CssClass="lbl-form" Text="Second Address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdd2" AutoComplete="off" Width="150px" CssClass="inp-form" TabIndex="5"
                            runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblPrint" runat="server" CssClass="lbl-form" Text="Print Int"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrintint" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="6" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAdd3" runat="server" CssClass="lbl-form" Text="Third Address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdd3" AutoComplete="off" Width="150px" CssClass="inp-form" TabIndex="7"
                            runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblBlackList" runat="server" CssClass="lbl-form" Text="Black List"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBlackList" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="8" MaxLength="1" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblphon1" runat="server" CssClass="lbl-form" Text="Phone NO"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtpnon1" AutoComplete="off" Width="150px" CssClass="inp-form" TabIndex="9"
                            onkeypress="return CheckNumeric(event)" MaxLength="10" runat="server" Height="15px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Phone No"
                            ValidationGroup="Discount12" ControlToValidate="txtpnon1">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblAcPen" runat="server" CssClass="lbl-form" Text="AcPin NO"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPincode" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="10" MaxLength="10" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblphon2" runat="server" CssClass="lbl-form" Text="Alternate Phone No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtpnon2" onkeypress="return CheckNumeric(event)" AutoComplete="off"
                            Width="150px" CssClass="inp-form" TabIndex="11" MaxLength="10" runat="server"
                            Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblAcIntRate" runat="server" CssClass="lbl-form" Text="Ac Int Rate"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAcIntRate" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="12" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCityCode" runat="server" CssClass="lbl-form" Text="City Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCityCode" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="13" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblZoneCode" runat="server" CssClass="lbl-form" Text="Zone Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZoneCode" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="14" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblpin" runat="server" CssClass="lbl-form" Text="Pin Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPin" AutoComplete="off" Width="150px" CssClass="inp-form" TabIndex="15"
                            runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCOUNTRY" runat="server" CssClass="lbl-form" Text="Country"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCOUNTRY" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="16" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBroker" runat="server" CssClass="lbl-form" Text="Broker"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbroker" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="17" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblMEDIUM" runat="server" CssClass="lbl-form" Text="Medium"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMedium" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="18" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblactype" runat="server" CssClass="lbl-form" Text="Ac Type"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAcType" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="19" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblAc_St_no" runat="server" CssClass="lbl-form" Text="Ac St NO"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAcStNo" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="20" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <hr />
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <%--<tr>
        <td width="120px">
                 <asp:Label ID="lblAC_CST_NO" runat="server" CssClass="lbl-form" Text="Ac Cst No"></asp:Label>
                 
            </td>
         <td>
               <asp:TextBox ID="txtAC_CST_NO" AutoComplete="off" Width="150px"
                    CssClass="inp-form" TabIndex="21" runat="server" Height="15px">
                </asp:TextBox>
            </td>
         
        </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="lblAC_TDS_LIM" runat="server" CssClass="lbl-form" Text="Ac Tds Lim"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAC_TDS_LIM" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="21" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblAC_TDS_RAT" runat="server" CssClass="lbl-form" Text="Ac Tds Rat"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAC_TDS_RAT" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="22" runat="server" Height="15px" onkeypress="return CheckNumeric(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <%-- <td>
                 <asp:Label ID="lblAC_H15" runat="server" CssClass="lbl-form" Text="Ac H15"></asp:Label>
                
            </td>
         <td>
               <asp:TextBox ID="txtAC_H15" AutoComplete="off" Width="150px"
                    CssClass="inp-form" TabIndex="24" runat="server" Height="15px">
                </asp:TextBox>
            </td>--%>
                    <td width="120px">
                        <asp:Label ID="lblAC_CST_NO" runat="server" CssClass="lbl-form" Text="Ac Cst No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAC_CST_NO" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="23" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblAC_DEPR_C" runat="server" CssClass="lbl-form" Text="Ac Depr C"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAC_DEPR_C" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="24" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAC_DEPR_N" runat="server" CssClass="lbl-form" Text="Ac Derp N"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAC_DEPR_N" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="25" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblDISC_PREC" runat="server" CssClass="lbl-form" Text="Disc Prec"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDISC_PREC" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="26" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAREA" runat="server" CssClass="lbl-form" Text="Area"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAREA" AutoComplete="off" Width="150px" CssClass="inp-form" TabIndex="27"
                            runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblsr_Order" runat="server" CssClass="lbl-form" Text="Sr Order"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSR_ORDER" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="28" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOPEN_BAL" runat="server" CssClass="lbl-form" Text="Open Bal"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOPEN_BAL" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="29" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblPROFIT" runat="server" CssClass="lbl-form" Text="Profit"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPROFIT" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="30" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblREMUNA" runat="server" CssClass="lbl-form" Text="Remuna"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtREMUNA" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="31" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCR_LIMIT" runat="server" CssClass="lbl-form" Text="Cr Limit"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCR_LIMIT" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="32" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSP_DISC" runat="server" CssClass="lbl-form" Text="Sp Disc"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSP_DISC" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="33" runat="server" Height="15px" onkeypress="return CheckNumericWithDot(event)">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblEMAIL_NO" runat="server" CssClass="lbl-form" Text="Email No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEMAIL_NO" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="34" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblIN_CHARGE" runat="server" CssClass="lbl-form" Text="In Change"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIN_CHARGE" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="35" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCTYPE_CODE" runat="server" CssClass="lbl-form" Text="Ctype Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCTYPE_CODE" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="36" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblL_O" runat="server" CssClass="lbl-form" Text="L O"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtL_O" AutoComplete="off" Width="150px" CssClass="inp-form" TabIndex="37"
                            runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCF_CODE" runat="server" CssClass="lbl-form" Text="Cf Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCF_CODE" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="38" runat="server" Height="15px">
                        </asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
