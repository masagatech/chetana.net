<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_BankReceipt.ascx.cs"
    Inherits="UserControls_uc_BankReceipt" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <tr>
        <td>
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
                <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
            <div class="options">
            </div>
        </td>
        <td>
            <div style="float: right; width: 50%">
                <div id="filter" runat="server">
                    <span>Filter Data:</span>
                    <input name="filt" onkeyup="filter(this, 'sf', '<%=GrdBankRDetails.ClientID%>')"
                        type="text">
                </div>
            </div>
        </td>
    </tr>
</div>
<%--<asp:UpdatePanel ID="UpdatePanel7" runat="server">
    <ContentTemplate>--%>
        <div style="float: right; width: 1130px">
            <asp:Button ID="btnDelete" OnClientClick="Javascript:return confirm('Are you sure you want to delete this entry?');"
                CssClass="submitbtn" TabIndex="15" runat="server" Text="Delete" Width="80px" OnClick="btn_Delete_Click" />
            <asp:Button ID="btn_Save" CssClass="submitbtn" TabIndex="16" runat="server" Text="Save"
                Width="80px" OnClick="btn_Save_Click" ValidationGroup="bnkrct" />
            <asp:Button ID="btnCashEntry" Visible="false" CssClass="submitbtn" TabIndex="16" runat="server" Text="Cash Entry"
                Width="100px" OnClick="btn_CashEntry" />
		 <asp:DropDownList ID="ddlMonth" Visible="false" runat="server" CssClass="ddl-form" >
                <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
		<asp:ListItem Text="Jan" Value="1"></asp:ListItem>
		<asp:ListItem Text="Feb" Value="2"></asp:ListItem>
		<asp:ListItem Text="Mar" Value="3"></asp:ListItem>
            </asp:DropDownList>

            <%--<%#ConfigurationManager.AppSettings["editlockMsg"].ToString()     %>--%>
        </div>
        <br />
        <asp:Panel ID="Pnldate" Visible="false" CssClass="panelDetails" runat="server" Width="862px">
            <table>
                <tr>
                    <td colspan="2">
                        <asp:RadioButtonList runat="server" ID="rdbselect" TabIndex="7" RepeatDirection="Horizontal"
                            CssClass="lbl-form" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rdbselect_SelectedIndexChanged">
                            <asp:ListItem Value="DateWise" Text="DateWise" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="DocumentWise" Text="DocumentWise"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td width="67px">
                        <asp:Label ID="Label8" runat="server" Text="Bank" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtbankcoder" Width="80px" CssClass="inp-form" TabIndex="1" autocomplete="off"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtbankcoder_TextChanged"></asp:TextBox>
                                <div id="div3" class="divauto350">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True" ServiceMethod="GetCodes"
                                    CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                    EnableCaching="false" TargetControlID="txtbankcoder" UseContextKey="true" ContextKey="Bank"
                                    CompletionListElementID="div3">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="Rqfbnkr" runat="server" ErrorMessage="Enter Bank Code"
                                    ValidationGroup="rdateft" ControlToValidate="txtbankcoder">.</asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td width="25px"></td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblbanknamer" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                    runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Pnld" runat="server">
                <table>
                    <tr>
                        <td width="60px">
                            <asp:Label ID="Label11" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td width="5px"></td>
                        <td>
                            <%--   <asp:UpdatePanel ID="UpPnldate1" UpdateMode="Conditional" runat="server">
              <ContentTemplate>--%>
                            <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                Enabled="true" AutoPostBack="True" OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From Date"
                                ValidationGroup="rdateft" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                            <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
                        </td>
                        <td width="25px"></td>
                        <td width="60px">
                            <asp:Label ID="Label7" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                                color="red">*</font> &nbsp;
                        </td>
                        <td width="5px"></td>
                        <td>
                            <%-- <asp:UpdatePanel ID="UpPnldate2" runat="server">
              <ContentTemplate>--%>
                            <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                                Enabled="true" AutoPostBack="True" OnTextChanged="txttoDate_TextChanged"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttoDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttoDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To Date"
                                ValidationGroup="rdateft" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
                        </td>
                        <td width="25px"></td>
                        <td>
                            <asp:Button ID="btnget" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="rdateft"
                                TabIndex="3" Width="50px" OnClick="btnget_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnldoc123" runat="server">
                <table>
                    <tr>
                        <td width="60px">
                            <asp:Label ID="Label9" runat="server" Text="Document No." CssClass="lbl-form"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td width="5px"></td>
                        <td>
                            <asp:TextBox ID="txtdoc123" CssClass="inp-form" TabIndex="22" Width="80px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btndoc" runat="server" Text="Get" CssClass="submitbtn" TabIndex="24"
                                ValidationGroup="pdadoc" Width="50px" OnClick="btndoc_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="rdateft"
            runat="server" ID="ss" />
        <br />
        <asp:Panel ID="PnlAddBankR" CssClass="panelDetails" runat="server" Style="float: left; width: 510px">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="110px">
                        <asp:Label ID="lblPhone" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="LblBankRID" runat="server" Style="display: none;"></asp:Label>
			 
                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Bank Code"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtbankcode" Width="85px" CssClass="inp-form" TabIndex="1" autocomplete="off"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtbankcode_TextChanged"></asp:TextBox>
                                <div id="divbank" class="divauto350">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True" ServiceMethod="GetCodes"
                                    CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                    EnableCaching="false" TargetControlID="txtbankcode" UseContextKey="true" ContextKey="Bank"
                                    CompletionListElementID="divbank">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="Reqbnkcode" runat="server" ErrorMessage="Enter Bank Code"
                                    ValidationGroup="bnkrct" ControlToValidate="txtbankcode">.</asp:RequiredFieldValidator>
                                <asp:Label ID="lblbankname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                    runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Document No"></asp:Label>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtdocno" CssClass="inp-form" TabIndex="2" Width="85px" runat="server"
                                    Enabled="false"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td width="90px">
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdocDate" onblur="ValidInYearDate(this);" CssClass="inp-form"
                            TabIndex="3" Width="85px" runat="server" Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdocDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtdocDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        (dd/mm/yyyy)
            <asp:RequiredFieldValidator ID="reqDate" runat="server" ErrorMessage="Require Document Date"
                ValidationGroup="bnkrct" ControlToValidate="txtdocDate">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%-- <tr>
            <td>
                <asp:Label ID="Label12" CssClass="lbl-form" runat="server" Text="Serial No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtsrno" CssClass="inp-form" autocomplete="off" TabIndex="4" runat="server"
                    Text="1"></asp:TextBox>
            </td>
        </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="Label16" CssClass="lbl-form" runat="server" Text="Account Code"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                                <asp:TextBox ID="txtAccode" Width="85px" CssClass="inp-form" TabIndex="5" autocomplete="off"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtAccode_TextChanged"></asp:TextBox>
                                <div id="div1" class="divauto350">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True" ServiceMethod="GetCodes"
                                    CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                    EnableCaching="false" TargetControlID="txtAccode" UseContextKey="true" ContextKey="Account"
                                    CompletionListElementID="div1">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="ReqAccode" runat="server" ErrorMessage="Enter Account Code"
                                    ValidationGroup="bnkrct" ControlToValidate="txtAccode">.</asp:RequiredFieldValidator>
                                <asp:Label ID="lblaccname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                    runat="server"></asp:Label>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblCustOS" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"
                            Visible="False" Width="120px"></asp:Label>
                    </td>
		    </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Person Incharge"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtperson" CssClass="inp-form" autocomplete="off" TabIndex="6" Width="85px"
                            runat="server"></asp:TextBox>
                    </td>
                    <td></td>
		    <td>
	                <asp:Label ID="lbldislimit" runat="server" Text="Cash limit" CssClass="lbl-form" Visible="False"></asp:Label>

	            </td>
	            <td>
                <asp:Label ID="lbllimit" runat="server" CssClass="lbl-form" Font-Size="10px" ForeColor="Blue"
                    Visible="False" Width="120px"></asp:Label>
                 <asp:Label ID="lblsplitdc" runat="server" Text="" CssClass="lbl-form" Visible="false"></asp:Label>
            </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Report Code"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtreportcode" Width="85px" CssClass="inp-form" TabIndex="7" autocomplete="off"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtreportcode_TextChanged"></asp:TextBox>
                                <div id="div2" class="divauto350">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True" ServiceMethod="GetCodes"
                                    CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                    EnableCaching="false" TargetControlID="txtreportcode" UseContextKey="true" ContextKey="Account"
                                    CompletionListElementID="div2">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="Reqrepcode" runat="server" ErrorMessage="Enter Report Code"
                                    ValidationGroup="bnkrct" ControlToValidate="txtreportcode">.</asp:RequiredFieldValidator>
                                <asp:Label ID="lblacname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Salesman ReceiptNo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSrcptno" CssClass="inp-form" autocomplete="off" TabIndex="8"
                            Width="85px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="padding-bottom: 10px; padding-top: 8px;">
                        <hr />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="LblCCDD" runat="server" CssClass="lbl-form" Text="Cash/Cheque/DD"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLCCDD" runat="server" Enabled="true" Width="100px" TabIndex="9"
                            OnSelectedIndexChanged="DDLCCDD_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                            <asp:ListItem Value="DD">DD</asp:ListItem>
                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="Reqselect" runat="server" ErrorMessage="Select Cash/Cheque/DD"
                            ValidationGroup="bnkrct" ControlToValidate="DDLCCDD">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%--<asp:UpdatePanel ID="UpdatePanel8" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>--%>
                        <tr>
                            <td>
                                <asp:Label ID="LblCCDDNo" runat="server" CssClass="lbl-form" Text="Cheque/DD No."></asp:Label>
                            </td>
                            <td>
                                <%-- <asp:UpdatePanel ID="updatepnel" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>--%>
                                <asp:TextBox ID="txtCCDDNo" runat="server" CssClass="inp-form" Width="85px" Enabled="true"
                                    TabIndex="10"></asp:TextBox>
                                <%--</ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="DDLCCDD" EventName="DDLCCDD_SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>--%>

                            </td>
                            <%-- <td>
                <asp:Label ID="LblType" runat="server" CssClass="lbl-form" Text="Type"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtType" runat="server" CssClass="inp-form" Width="46px" TabIndex="11"></asp:TextBox>
            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblAmt" runat="server" CssClass="lbl-form" Text="Amount"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>

                                <asp:TextBox ID="txtAmt" runat="server" CssClass="inp-form" TabIndex="12" Width="85px"
                                    MaxLength="20" OnTextChanged="txtAmt_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                <ajaxCt:FilteredTextBoxExtender ID="filter1" runat="server" FilterType="Custom, Numbers"
                                    TargetControlID="txtAmt" ValidChars="." />
                                <asp:RequiredFieldValidator ID="Reqamt" runat="server" ErrorMessage="Enter Amount"
                                    ValidationGroup="bnkrct" ControlToValidate="txtAmt">.</asp:RequiredFieldValidator>

                            </td>
                            <%--<td>
                <asp:Label ID="LblDrawnon" runat="server" CssClass="lbl-form" Text="Drawn On"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDrawnon" runat="server" CssClass="inp-form" Width="85px" TabIndex="13"></asp:TextBox>
            </td>--%>
                        </tr>
                   <%-- </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLCCDD" EventName="DDLCCDD_SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                <tr>
                    <td width="110px">
                        <asp:Label ID="LblDrawnon" CssClass="lbl-form" runat="server" Text="Customer Bank"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>--%>
                        <asp:TextBox ID="txtDrawnon" Width="85px" CssClass="inp-form" TabIndex="13" autocomplete="off"
                            runat="server" OnTextChanged="txtDrawnon_TextChanged"></asp:TextBox>
                        <asp:Label ID="lblDrawnonname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server" Style="display: none"></asp:Label>
                        <%--</ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="DDLCCDD" EventName="DDLCCDD_SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>


                <tr>
                    <td>
                        <asp:Label ID="LblRem" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="inp-form" Height="40px" TextMode="MultiLine"
                            Width="150px" TabIndex="14"></asp:TextBox>
                        <%-- <asp:RequiredFieldValidator ID="ReqRmrk" runat="server" ErrorMessage="Enter Remark"
                    ValidationGroup="bnkrct" ControlToValidate="txtRemark">.</asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblChk" runat="server" CssClass="lbl-form" Text="Active"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckActive" runat="server" Checked="true" TabIndex="15" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <p>
        </p>

        <asp:Panel ID="PnlBankRDetails" runat="server">
            <asp:GridView ID="GrdBankRDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                CssClass="product-table" ForeColor="#333333" PageSize="10" Width="900px" OnRowDeleting="GrdBankRDetails_RowDeleting"
                OnRowEditing="GrdBankRDetails_RowEditing">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Document Date"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblBankPID" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("BankReceiptID") %>'></asp:Label>
                            <asp:Label ID="lblBankCode" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("BankCode") %>'></asp:Label>
                            <asp:Label ID="lblBankName" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("BankName") %>'></asp:Label>
                            <asp:Label ID="lblDocDt" runat="server" CssClass="lbl-form" Text='<%#Eval("Documentdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Bank Name" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblBankName" runat="server" CssClass="lbl-form" Text='<%#Eval("BankName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
                    <%--  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="AccBook Name" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblAccBookName" runat="server" CssClass="lbl-form" 
                 Text='<%#Eval("AccBookName") %>'></asp:Label> 
        </ItemTemplate>
    </asp:TemplateField>  --%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Document No."
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDocNo" runat="server" CssClass="lbl-form" Text='<%#Eval("DocumentNo") %>'></asp:Label>
                            <%--<asp:Label ID="lblAccDocDt" runat="server" CssClass="lbl-form" Style="display: none;"
                 Text='<%#Eval("AccDocumentdate") %>'></asp:Label> --%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Serial No" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>                                         
            <asp:Label ID="lblSNo" runat="server" CssClass="lbl-form" 
                Text='<%#Eval("SerialNo") %>'></asp:Label>
       </ItemTemplate>
    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Account Name"
                        ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblAccName" runat="server" CssClass="lbl-form" Text='<%#Eval("AC_NAME") %>'></asp:Label>
                            <%--<asp:Label ID="lblSNo" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("SerialNo") %>'></asp:Label>--%>
                            <asp:Label ID="lblAccCode" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("AccountCode") %>'></asp:Label>
                            <asp:Label ID="lblPnI" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("PersonInCharge") %>'></asp:Label>
                            <asp:Label ID="lblRCode" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("ReportCode") %>'></asp:Label>
                            <asp:Label ID="lblSMReceipt" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("SalesmanReceiptNo")%>'></asp:Label>
                            <%--<asp:Label ID="lblType" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("Type") %>'></asp:Label>--%>
                            <asp:Label ID="lblDrawnon" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("DrawnOn")%>'></asp:Label>
                            <asp:Label ID="lblDrwnonName" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("DrawnonName")%>'></asp:Label>
                            <asp:Label ID="lblRemark" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("Remarks") %>'></asp:Label>
                            <asp:CheckBox ID="chkisActive" runat="server" CssClass="lbl-form" Style="display: none;"
                                Checked='<%#Eval("Isactive") %>' />
                            <%--  <asp:Label ID="lblIsEditable" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("is_Editable") %>'></asp:Label>  --%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Report Name"
                        ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblRepName" runat="server" CssClass="lbl-form" Text='<%#Eval("ReportName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Amount" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblAmt" runat="server" CssClass="lbl-form" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Cheque/DD NO"
                        ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblCCDDNo" runat="server" CssClass="lbl-form" Text='<%#Eval("Cheque_DD_NO")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Cash/Cheque/DD"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCCDD" runat="server" CssClass="lbl-form" Text='<%#Eval("Cash_Cheque_DD") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Phone" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblPhone1" runat="server" Text='<%#Eval("phone1")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                            <%--<asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you want to Delete?')" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </asp:Panel>
<asp:Panel ID="PanelPopup" runat="server" Style="overflow-y: auto; max-height: 465px;">
    <asp:GridView ID="grdPopup" runat="server" CssClass="product-table" AutoGenerateColumns="False"
        CellPadding="4" AlternatingRowStyle-CssClass="alt" Style="height: 250%">
        <Columns>
            <asp:TemplateField HeaderText="Select" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <input type="checkbox" id="chk" runat="server" data-val='<%#Eval("DebitAmount")%>' />
                    <asp:HiddenField ID="hiddenId" runat="server" Value='<%#Eval("autoid") %>' />
                </ItemTemplate>
                <HeaderStyle Width="30px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="53px" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblDepositDate" runat="server" Text='<%#Eval("DepositeDate") %>'>TEST 1</asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="33px" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cust Name" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("Party") %>'>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="10px" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="txtAmount" runat="server" Text='<%#Eval("DebitAmount")%>'>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="30px" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>

        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="bnkrct"
            runat="server" ID="bk" />
  <%--  </ContentTemplate>
</asp:UpdatePanel>--%>



<script type="text/javascript">
    var totaamt = 0;
    $(function () {
        $('tr input[type=checkbox]').change(function () {
            if ($(this).attr('checked')) {
                totaamt += parseFloat($(this).attr('data-val'));
            } else {
                totaamt -= parseFloat($(this).attr('data-val'));
            }
            $('#<%=txtAmt.ClientID%>').val(totaamt);
        });
    });
    shortcut.add("Ctrl+S", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_BankReceipt1_btn_Save').click();
    });

</script>

<asp:HiddenField ID="HidFY" runat="server" />
