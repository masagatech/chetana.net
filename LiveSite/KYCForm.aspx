<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="KYCForm.aspx.cs" Inherits="KYCForm" Title="Kyc Form" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .OrderRecdDate
        {
            width: 66%;
        }

        .ddlTransport
        {
            width: 93%;
        }

        .displaynone
        {
            display: none;
        }

        .AddressLangth
        {
            margin-top: 0px;
            margin-bottom: 0px;
            height: 49px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Kyc Form<a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
        <asp:Panel ID="pnlra" runat="server">
            <div style="float: right; width: 58%">
                <div id="filter" runat="server">
                </div>
            </div>
        </asp:Panel>
        <div class="options">
        </div>
    </div>
    <div style="float: left; width: 652px">
        <asp:Button ID="btnClear" Style="float: right; margin: 0px 0px 0px 2px" CssClass="submitbtn"
            OnClientClick="javascript:return confirm('Wish to clear this data');" TabIndex="120"
            ToolTip="Clear all fields" Visible="true" runat="server" Text="Cancel" Width="80px"
            OnClick="btnClear_Click" />
        <asp:Button ID="btnPrint" Visible="true" Style="float: right; margin: 0px 2px 0px 2px"
            CssClass="submitbtn" ValidationGroup="V" TabIndex="100" ToolTip="Print" runat="server"
            Text="Print" OnClick="btn_Print_Click" Width="80px" />&nbsp;
        <asp:Button ID="btnDelete" Style="float: right; color: Red; margin: 0px 2px 0px 2px"
            CssClass="submitbtn" OnClientClick="javascript:return confirm('Wish to delete this data');"
            TabIndex="115" ToolTip="Delete the below data" runat="server" Visible="false"
            Text="Delete" Width="80px" OnClick="btnDelete_Click" />
        <asp:Button ID="btn_Edit" Visible="true" Style="float: right; margin: 0px 2px 0px 2px"
            CssClass="submitbtn" OnClientClick="javascript:return openEditPopup();" TabIndex="110"
            ToolTip="Edit the data" runat="server" Text="Edit" Width="80px" OnClick="btn_Edit_Click" />&nbsp;
        <asp:Button ID="btn_Save" Visible="true" Style="float: right; margin: 0px 2px 0px 2px"
            CssClass="submitbtn" ValidationGroup="V" TabIndex="25" ToolTip="Save below data"
            runat="server" Text="Save" Width="80px" OnClick="btn_Save_Click" />&nbsp;
        <asp:Button ID="btn_PrintSave" Visible="true" Style="float: right; margin: 0px 2px 0px 2px"
            CssClass="submitbtn" ValidationGroup="V" TabIndex="100" ToolTip="Save below data and Print"
            runat="server" Text="Save & Print" OnClick="btn_PrintSave_Click" Width="80px" />&nbsp;
        <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
        <asp:Label ID="lblDocNo" Style="display: none;" runat="server"></asp:Label>
    </div>
    <br />
    <br />
    <asp:Panel ID="KycPanel" runat="server" CssClass="panelDetails" Style="width: 615px">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSrNo" runat="server">Kyc No.</asp:Label>
                    <asp:Label ID="lblKycId" runat="server" Visible="false" Text="0"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAutoExtend" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label17" runat="server">Party Code</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustCode" runat="server" TabIndex="3" CssClass="inp-form" autocomplete="off"
                        AutoPostBack="True" OnTextChanged="txtCustCode_TextChanged">
                    </asp:TextBox>
                    <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                        ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                        CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtCustCode"
                        UseContextKey="true" ContextKey="custz" CompletionListElementID="dvcust">
                    </ajaxCt:AutoCompleteExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="V"
                        ErrorMessage="Required Customer Code" ControlToValidate="txtCustCode">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label19" runat="server">Party Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustName" runat="server" TabIndex="4" Style="width: 156%" CssClass="inp-form"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ValidationGroup="V" ControlToValidate="txtCustName">*</asp:RequiredFieldValidator>--%>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label21" runat="server">Party Add.</asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtCustAdd" runat="server" TabIndex="5" TextMode="MultiLine" Style="width: 100%; margin-top: 0px; margin-bottom: 0px; height: 49px;"
                        CssClass="inp-form"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator4" runat="server"
                        ValidationGroup="V" ControlToValidate="txtCustAdd">.</asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server">City</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" TabIndex="6" CssClass="inp-form"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator8" runat="server"
                        ValidationGroup="V" ControlToValidate="txtCity">.</asp:RequiredFieldValidator>--%>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server">Area</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtArea" runat="server" TabIndex="7" CssClass="inp-form"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator7" runat="server"
                        ValidationGroup="V" ControlToValidate="txtArea">.</asp:RequiredFieldValidator>--%>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server">Zone Code</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtZoneCode" runat="server" TabIndex="8" CssClass="inp-form"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator10"
                        runat="server" ValidationGroup="V" ControlToValidate="txtZoneCode">.</asp:RequiredFieldValidator>--%>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server">Zip Code</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtZipCode" runat="server" TabIndex="9" CssClass="inp-form"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator9" runat="server"
                        ValidationGroup="V" ControlToValidate="txtZipCode">.</asp:RequiredFieldValidator>--%>
                </td>
                <td></td>
            </tr>
            <%-- <tr>
                <td>
                    <asp:Label ID="Label15" runat="server">Person In chrg :</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPersonInchrg" runat="server" TabIndex="10" CssClass="inp-form"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td></td>
                <td colspan="4">
                    <asp:Label ID="lblZoneCode" Style="color: Blue" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server">Mobile No.</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" TabIndex="11" CssClass="inp-form"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator12"
                        runat="server" ValidationGroup="V" ControlToValidate="txtMobile">.</asp:RequiredFieldValidator>--%>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server">Telepone No.</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTelephone" runat="server" TabIndex="12" CssClass="inp-form"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator11"
                        runat="server" ValidationGroup="V" ControlToValidate="txtTelephone">.</asp:RequiredFieldValidator>--%>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server">If Bookseller</asp:Label>
                </td>
                <td>
                    <asp:RadioButton ID="rbtnChr" runat="server" TabIndex="13" Text="CH RECD" GroupName="rbtnChr" />
                </td>
                <td>
                    <asp:RadioButton ID="rbtnSch" runat="server" TabIndex="14" Text="SCH" GroupName="rbtnChr" />
                </td>
                <td>
                    <asp:RadioButton ID="rbtnWcp" runat="server" TabIndex="15" Text="WCP" GroupName="rbtnChr" />
                </td>
                <td>
                    <asp:RadioButton ID="rbtnCod" runat="server" TabIndex="16" Text="COD" GroupName="rbtnChr" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server">Del.Add</asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtDelAdd" runat="server" TabIndex="17" TextMode="MultiLine" Style="width: 100% margin-top: 0px; margin-bottom: 0px; height: 49px;"
                        CssClass="inp-form"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator13"
                        runat="server" ValidationGroup="V" ControlToValidate="txtDelAdd">.</asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server">Transporter Details</asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList TabIndex="18" Width="100%" CssClass="ddl-form ddlTransport" ID="txtTransport"
                        DataTextField="Value" DataValueField="AutoId" runat="server">
                    </asp:DropDownList>
                    <%-- <asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator14"
                        runat="server" ValidationGroup="V" ControlToValidate="txtTransport">.</asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server">Outstanding</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOS" Font-Bold="true" runat="server">0</asp:Label>&nbsp;(Current)
                </td>
                <td>
                    <asp:Label ID="Label18" runat="server">Book Return%</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAvg" Font-Bold="true" runat="server">0</asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <b>Prev. Year</b>
                </td>
                <td></td>
                <td>
                    <b>Current Year</b>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server">Discount :</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblprvyeardisc" runat="server"></asp:Label>
                </td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtDisYear" runat="server" TabIndex="19" CssClass="inp-form" onkeypress="return CheckNumericWithDot(event)"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator15"
                        runat="server" ValidationGroup="V" ControlToValidate="txtDisYear">.</asp:RequiredFieldValidator>--%>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label16" runat="server">Titles :</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblpreyeartitles" runat="server"></asp:Label>
                </td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtTitlesYear" runat="server" TabIndex="20" CssClass="inp-form"
                        onkeypress="return CheckNumeric(event)"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator CssClass="displaynone" ID="RequiredFieldValidator16"
                        runat="server" ValidationGroup="V" ControlToValidate="txtTitlesYear">.</asp:RequiredFieldValidator>--%>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server">Attached :</asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ChkScheme" runat="server" TabIndex="21" Text="Scheme Letter" />
                </td>
                <td>
                    <asp:ValidationSummary ID="validation" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="V" />
                </td>
                <td>
                    <asp:CheckBox ID="ChkAddComminsion" runat="server" TabIndex="22" Text="Add Commision" />
                </td>
                <td style="width: 107px;">
                    <asp:CheckBox ID="ChkDisForm" runat="server" TabIndex="23" Text="Add Discount Form" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server">Remark</asp:Label>
                    <asp:Label ID="lblEdit" runat="server" Style="display: none"></asp:Label>
                    <asp:Label ID="lblSaveFlag" runat="server" Style="display: none"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRemrk" runat="server" TabIndex="24" TextMode="MultiLine" Style="width: 242%; margin-top: 0px; margin-bottom: 0px; height: 49px;"
                        CssClass="inp-form"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="V"
                        ErrorMessage="Required Remark" ControlToValidate="txtRemrk">*</asp:RequiredFieldValidator>
                </td>
                <td></td>
            </tr>
        </table>
    </asp:Panel>

    <script type="text/javascript">
        function openShowpopMethod() {
            document.getElementById('<%=btn_Edit.ClientID %>').click();
            document.getElementById('<%=txtDocIdEdit.ClientID %>').value = "";
            document.getElementById('<%=txtDocIdEdit.ClientID %>').focus();
            $find('<%=ModalPopUpDocNum.ClientID %>').show();
        }
        function CloseOpenNewPopup() {
            $find('<%=ModalPopupExtenderNew.ClientID %>').hide();
        }

        shortcut.add("Ctrl+E", function () {
            openShowpopMethod();
        });

        shortcut.add("esc", function () {
            closeEditPopup();
            CloseOpenNewPopup();
        });

        function openEditPopup() {
            openShowpopMethod();
            return false;
        }
        function closeEditPopup() {
            $find('<%=ModalPopUpDocNum.ClientID %>').hide();
        }
    </script>

    <div id="dvcust" class="divauto350">
    </div>
    <asp:Panel ID="PnlInsertDocNum" runat="server" DefaultButton="BtnGetDCDetails" Style="display: none; text-align: left; height: 140px;">
        <div class="facebox">
            <asp:Label ID="Label22" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
                ForeColor="White"></asp:Label>
            <a id="A1" class="close" style="right: 0;" runat="server" href="javascript:void(0);"
                onclick="closeEditPopup();">
                <img src="Images/button-cross.png" /></a>
            <br />
            <div class="content">
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDocNo12" runat="server" Font-Bold="true" Font-Size="12px" Text="Kyc No : "
                                            CssClass="lbl-form"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDocIdEdit" ValidationGroup="get" onkeypress="return CheckNumeric(event)"
                                            runat="server" MaxLength="10" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="get"
                                            ControlToValidate="txtDocIdEdit">Enter Order No.</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="BtnGetDCDetails" CssClass="submitbtn" runat="server" ValidationGroup="get"
                                            Text="Get Details" OnClick="BtnGetDCDetails_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="PnelAlreadyExsist" runat="server" DefaultButton="BtnGetDCDetails"
        Style="display: none; text-align: left; height: 140px;">
        <div class="facebox" style="width: 98%; height: 61%">
            <asp:Label ID="Label13" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
                ForeColor="White"></asp:Label>
            <a id="A2" class="close" style="right: 0;" runat="server" href="javascript:void(0);"
                onclick="closeEditPopup();">
                <img src="Images/button-cross.png" /></a>
            <br />
            <div class="content">
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>KYC for this customer is already present for this financial year. Do you want to
                                        create this entry ?
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnExsist" runat="server" Style="margin-left: 40%" OnClick="btnbtnExsist_Click"
                                            CssClass="submitbtn" Text="Yes" />
                                        <asp:Button ID="btnExCancel" runat="server" Style="margin-left: 2%" OnClick="btnExCancel_Click"
                                            CssClass="submitbtn" Text="No" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <ajaxCt:ModalPopupExtender ID="ModalPopUpDocNum" runat="server" TargetControlID="LnkBtn"
        PopupControlID="PnlInsertDocNum" BackgroundCssClass="modalBackground" DropShadow="false"
        EnableViewState="false" />
    <asp:LinkButton ID="LnkBtn" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
    <ajaxCt:ModalPopupExtender ID="ModalPopupExtenderNew" runat="server" TargetControlID="NewLinkButton"
        PopupControlID="PnelAlreadyExsist" BackgroundCssClass="modalBackground" DropShadow="false"
        EnableViewState="false" />
    <asp:LinkButton ID="NewLinkButton" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
</asp:Content>
