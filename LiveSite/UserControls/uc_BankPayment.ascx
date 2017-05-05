<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_BankPayment.ascx.cs"
    Inherits="UserControls_uc_BankPayment" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <tr>
        <td>
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
                <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
                </a>
            </div>
            <div class="options">
            </div>
        </td>
        <td>
            <div style="float: right; width: 50%">
                <div id="filter" runat="server">
                    <span>Filter Data:</span>
                    <input name="filt" onkeyup="filter(this, 'sf', '<%=GrdBankPDetails.ClientID%>')"
                        type="text">
                </div>
            </div>
        </td>
    </tr>
</div>
<asp:UpdatePanel ID="UpdatePanel7" runat="server">
    <ContentTemplate>
        <div style="float: right; width: 40%">
            <asp:Button ID="btnDelete" OnClientClick="Javascript:return confirm('Are you sure you want to delete this entry?');"
                CssClass="submitbtn" TabIndex="15" runat="server" Text="Delete" Width="80px"
                OnClick="btn_Delete_Click" />
            <asp:Button ID="btn_Save" CssClass="submitbtn" TabIndex="15" runat="server" Text="Save"
                Width="80px" OnClick="btn_Save_Click" ValidationGroup="bnkpmt" />
        </div>
        <asp:Label ID="lblAuditMsg" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
        <br />
        <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server" Width="860px">
            <table>
                <tr>
                    <td colspan="2">
                        <asp:RadioButtonList runat="server" ID="rdbselect" TabIndex="7" RepeatDirection="Horizontal"
                            CssClass="lbl-form" Width="300px" AutoPostBack="true" 
                            onselectedindexchanged="rdbselect_SelectedIndexChanged">
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
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="txtbankcodep" Width="80px" CssClass="inp-form" TabIndex="21" autocomplete="off"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtbankcodep_TextChanged"></asp:TextBox>
                                <div id="div3" class="divauto350">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbankcodep"
                                    UseContextKey="true" ContextKey="Bank" CompletionListElementID="div3">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="Rqfbnkp" runat="server" ErrorMessage="Enter Bank Code"
                                    ValidationGroup="pdateft" ControlToValidate="txtbankcodep">.</asp:RequiredFieldValidator>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtbankcodep" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td width="25px">
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Label ID="lblbanknamep" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                    runat="server"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtbankcodep" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Pnld"  runat="server">
                <table>
                    <tr>
                        <td width="60px">
                            <asp:Label ID="Label11" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <%-- <asp:UpdatePanel ID="UpPnldate1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                            <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="22" Width="80px" runat="server"
                                Enabled="true" AutoPostBack="True" OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From Date"
                                ValidationGroup="pdateft" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                            <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                        </td>
                        <td width="25px">
                        </td>
                        <td width="60px">
                            <asp:Label ID="Label3" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                                color="red">*</font> &nbsp;
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                            <%-- <asp:UpdatePanel ID="UpPnldate2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                            <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="23" Width="80px" runat="server"
                                Enabled="true" AutoPostBack="True" OnTextChanged="txttoDate_TextChanged"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttoDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttoDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To Date"
                                ValidationGroup="pdateft" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                            <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                        </td>
                        <td width="25px">
                        </td>
                        <td>
                            <asp:Button ID="btnget" runat="server" Text="Get" CssClass="submitbtn" TabIndex="24"
                                ValidationGroup="pdateft" Width="50px" OnClick="btnget_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel> 
            <asp:Panel ID="pnldoc123"  runat="server">
                <table>
                    <tr>
                        <td width="60px">
                            <asp:Label ID="Label7" runat="server" Text="Document No." CssClass="lbl-form"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td width="5px">
                        </td>
                        <td>
                           
                            <asp:TextBox ID="txtdoc123" CssClass="inp-form" TabIndex="22" Width="80px" runat="server"
                                 ></asp:TextBox>
                             </td>
                        
                        
                        <td>
                            <asp:Button ID="btndoc" runat="server" Text="Get" CssClass="submitbtn" TabIndex="24"
                                ValidationGroup="pdadoc" Width="50px" onclick="btndoc_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="pdateft"
            runat="server" ID="ss" />
        <br />
        <asp:Panel ID="PnlAddBankP" CssClass="panelDetails" runat="server" Width="715px">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="110px">
                        <asp:Label ID="LblBankPID" runat="server" Style="display: none;"></asp:Label>
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
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbankcode"
                                    UseContextKey="true" ContextKey="Bank" CompletionListElementID="divbank">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="Reqbnkcode" runat="server" ErrorMessage="Enter Bank Code"
                                    ValidationGroup="bnkpmt" ControlToValidate="txtbankcode">.</asp:RequiredFieldValidator>
                                <asp:Label ID="lblbankname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                    runat="server"></asp:Label></ContentTemplate>
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
                                <asp:TextBox ID="txtdocno" Width="85px" CssClass="inp-form" TabIndex="2" runat="server"
                                    Enabled="false"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td width="90px">
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdocDate" onblur="ValidInYearDate(this);" CssClass="inp-form"
                            TabIndex="3" Width="85px" runat="server" Enabled="true"></asp:TextBox>
                        <font color="red">*</font>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdocDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtdocDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        (dd/mm/yyyy)
                        <asp:RequiredFieldValidator ID="reqDate" runat="server" ErrorMessage="Require Document Date"
                            ValidationGroup="bnkpmt" ControlToValidate="txtdocDate">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%--    <tr>
            <td>
                <asp:Label ID="Label12" CssClass="lbl-form" runat="server" Text="Serial No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtsrno" CssClass="inp-form" autocomplete="off" TabIndex="4" runat="server"
                   Width="85px" Text="1"></asp:TextBox>
            </td>
        </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="Label16" CssClass="lbl-form" runat="server" Text="Account Code"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtAccode" Width="85px" CssClass="inp-form" TabIndex="5" autocomplete="off"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtAccode_TextChanged"></asp:TextBox>
                                <div id="div1" class="divauto350">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtAccode"
                                    UseContextKey="true" ContextKey="Account" CompletionListElementID="div1">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="ReqAccode" runat="server" ErrorMessage="Enter Account Code"
                                    ValidationGroup="bnkpmt" ControlToValidate="txtAccode">.</asp:RequiredFieldValidator>
                                <asp:Label ID="lblaccname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                    runat="server"></asp:Label></ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
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
                        <asp:TextBox ID="txtperson" Width="85px" CssClass="inp-form" autocomplete="off" TabIndex="6"
                            runat="server"></asp:TextBox>
                    </td>
                    <td>
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
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtreportcode"
                                    UseContextKey="true" ContextKey="Account" CompletionListElementID="div2">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="Reqrepcode" runat="server" ErrorMessage="Enter Report Code"
                                    ValidationGroup="bnkpmt" ControlToValidate="txtreportcode">.</asp:RequiredFieldValidator>
                                <asp:Label ID="lblacname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label></ContentTemplate>
                        </asp:UpdatePanel>
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
                        <asp:DropDownList ID="DDLCCDD" runat="server" Enabled="true" Width="100px" TabIndex="8"
                            OnSelectedIndexChanged="DDLCCDD_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                            <asp:ListItem Value="DD">DD</asp:ListItem>
                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                            <asp:ListItem Value="ECS">ECS</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="Reqselect" runat="server" InitialValue="0" ErrorMessage="Select Cash/Cheque/DD"
                            ValidationGroup="bnkpmt" ControlToValidate="DDLCCDD">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblCCDDNo" runat="server" CssClass="lbl-form" Text="Cheque/DD No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCCDDNo" runat="server" CssClass="inp-form" Width="85px" Enabled="true"
                            TabIndex="9"></asp:TextBox>
                    </td>
                    <%--<td>
                <asp:Label ID="LblType" runat="server" CssClass="lbl-form" Text="Type"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtType" runat="server" CssClass="inp-form" Width="46px" TabIndex="10"></asp:TextBox>
            </td>--%>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblAmt" runat="server" CssClass="lbl-form" Text="Amount"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAmt" runat="server" CssClass="inp-form" TabIndex="11" Width="85px"
                            MaxLength="20"></asp:TextBox>
                        <ajaxCt:FilteredTextBoxExtender ID="filter1" runat="server" FilterType="Custom, Numbers"
                            TargetControlID="txtAmt" ValidChars="." />
                        <asp:RequiredFieldValidator ID="Reqamt" runat="server" ErrorMessage="Enter Amount"
                            ValidationGroup="bnkpmt" ControlToValidate="txtAmt">.</asp:RequiredFieldValidator>
                    </td>
                    <%--       <td>
                <asp:Label ID="LblDrawnon" runat="server" CssClass="lbl-form" Text="Drawn On"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDrawnon" runat="server" CssClass="inp-form" Width="85px" TabIndex="12"></asp:TextBox>
            </td>--%>
                </tr>
                <tr style="display: none;">
                    <td width="110px">
                        <asp:Label ID="LblDrawnon" runat="server" Text="Drawn On" CssClass="lbl-form"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtDrawnon" Width="85px" CssClass="inp-form" TabIndex="12" autocomplete="off"
                                    runat="server" AutoPostBack="True" OnTextChanged="txtDrawnon_TextChanged"></asp:TextBox>
                                <div id="div4" class="divauto350">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtDrawnon"
                                    UseContextKey="true" ContextKey="Bank" CompletionListElementID="div4">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="Rqfdrwon" runat="server" ErrorMessage="Enter Drawn on "
                                    ValidationGroup="//bnkpmt" ControlToValidate="txtDrawnon">.</asp:RequiredFieldValidator>
                                <asp:Label ID="lblDrawnonname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                    runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblRem" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="inp-form" Height="40px" TextMode="MultiLine"
                            Width="150px" TabIndex="13"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="ReqRmrk" runat="server" ErrorMessage="Enter Remark"
             ValidationGroup="bnkpmt" ControlToValidate="txtRemark">.</asp:RequiredFieldValidator> --%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblChk" runat="server" CssClass="lbl-form" Text="IsChequeBounce"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckActive" runat="server"  TabIndex="14" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <p>
        </p>
        <asp:Panel ID="PnlBankPDetails" runat="server">
            <asp:GridView ID="GrdBankPDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                CssClass="product-table" ForeColor="#333333" PageSize="10" Width="900px" OnRowDeleting="GrdBankPDetails_RowDeleting"
                OnRowEditing="GrdBankPDetails_RowEditing" 
                onselectedindexchanged="GrdBankPDetails_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Document Date"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblBankPID" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("BankPaymentID") %>'></asp:Label>
                            <asp:Label ID="lblBankCode" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("BankCode") %>'></asp:Label>
                            <asp:Label ID="lblBankName" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("BankName") %>'></asp:Label>
                            <asp:Label ID="lblDocDt" runat="server" CssClass="lbl-form" Text='<%#Eval("Documentdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Bank Name" ItemStyle-HorizontalAlign="Center">
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
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="bnkpmt"
            runat="server" ID="bk" />
    </ContentTemplate>
</asp:UpdatePanel>

<script type="text/javascript">

shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_BankPayment1_btn_Save').click();
});

</script>

<asp:HiddenField ID="HidFY" runat="server" />
