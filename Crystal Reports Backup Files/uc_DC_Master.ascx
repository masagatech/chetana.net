<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DC_Master.ascx.cs"
    Inherits="UserControls_uc_DC_Master" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Src="../help/helpctrl.ascx" TagName="helpctrl" TagPrefix="uc1" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<style>
    .panelDetails
    {
        width: 535px;
        padding: 5px 9px;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Transaction > ORDER > Create D.C. <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
</div>
<div style="width: 555px">
    <div style="float: right;">
        <asp:UpdatePanel ID="updatebtn" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btn_Save" Enabled="false" Style="float: right;" CssClass="submitbtn"
                    ValidationGroup="S" TabIndex="22" runat="server" Text="Save" Width="80px" OnClick="btn_Save_Click" />
                <asp:Button ID="btnEdit" OnClientClick="Openpopup(2)" CssClass="submitbtn" Width="80px"
                    Style="display: none" runat="server" Text="Edit"></asp:Button>
                <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
<br />
<br />
<asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <asp:HiddenField ID="srate" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:Panel ID="PnlSpecimenDetails" CssClass="panelDetails" runat="server">
    <asp:UpdatePanel ID="upall" runat="server">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100px">
                        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td width="110px">
                        <asp:TextBox ID="txtdocDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdocDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtdocDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require Date"
                            ValidationGroup="S" ControlToValidate="txtdocDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td width="10px">
                    </td>
                    <td width="120px">
                        <asp:Label ID="Label1" Style="display: none" runat="server" CssClass="lbl-form" Text="Document No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdoc" Style="display: none" CssClass="inp-form" TabIndex="1" Width="80px"
                            runat="server" Enabled="false" MaxLength="10"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td>
                        <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Challan No."></asp:Label>
                    </td>
                    <td>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="txtchalan" CssClass="inp-form" Width="80px" TabIndex="3" runat="server"
                            AutoPostBack="true" OnTextChanged="txtchalan_TextChanged" MaxLength="10"></asp:TextBox>
                        <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqChallan" runat="server" ErrorMessage="Require Challan No."
                            ValidationGroup="Ssss" ControlToValidate="txtchalan">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Challan Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtChalDate" onblur="lthantoday(this)" CssClass="inp-form" TabIndex="4"
                            Width="80px" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtChalDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="Maskedchaldt" runat="server" TargetControlID="txtChalDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        (dd/mm/yyyy)
                        <asp:RequiredFieldValidator ID="reqDt" runat="server" ErrorMessage="Require Date"
                            ValidationGroup="Sssss" ControlToValidate="txtChalDate">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Token No."></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <%-- <asp:UpdatePanel ID="UpdatePane32" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="txtorder" CssClass="inp-form" Width="80px" TabIndex="2" runat="server"
                            AutoComplete="off" OnTextChanged="txtorder_TextChanged" AutoPostBack="true" MaxLength="10"
                            onkeypress="return CheckNumeric(event)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqOrdeR" runat="server" ErrorMessage="Require Order No."
                            ValidationGroup="S" ControlToValidate="txtorder">.</asp:RequiredFieldValidator>
                        <%-- </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btn_Save" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Token Date"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <%--<asp:TextBox ID="txtOrdDate" Width="80px" onblur="ValidInYearDate(this);" CssClass="inp-form"
                TabIndex="6" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtOrdDate"
                    Format="dd/mm/yyyy" />
                <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" TargetControlID="txtOrdDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                (dd/mm/yyyy)
                <asp:RequiredFieldValidator ID="reqDat" runat="server" ErrorMessage="Require Date"
                    ValidationGroup="S" ControlToValidate="txtOrdDate">.</asp:RequiredFieldValidator> --%>
                        <%--   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="txtOrdDate" CssClass="inp-form" TabIndex="500" Width="80px" onblur="ValidInYearDate(this);"
                            runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtOrdDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtOrdDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Require Date"
                            ValidationGroup="S" ControlToValidate="txtOrdDate">.</asp:RequiredFieldValidator>
                        <%-- </ContentTemplate>
           <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TxtDocNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Customer Code"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td colspan="4">
                        <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>--%>
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
                        <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label>
                        <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" CssClass="lbl-form" runat="server" Text="M R Code"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <%--  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>--%>
                        <asp:DropDownList ID="DDlemployee" TabIndex="8" DataTextField="Name" DataValueField="EmpCode"
                            CssClass="ddl-form" Width="160px" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsalesman" Style="display: none;" runat="server"
                            InitialValue="0" ErrorMessage="Require M R Code" ValidationGroup="S" ControlToValidate="DDlemployee">.</asp:RequiredFieldValidator>
                        <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtsalemanCode" onfocus="setfocus('salesman');" autocomplete="off"
                            Width="80px" CssClass="inp-form" TabIndex="7" runat="server" OnTextChanged="txtsalemanCode_TextChanged"
                            AutoPostBack="true"></asp:TextBox>
                        <div id="dvsalesman" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtsalemanCode"
                            UseContextKey="true" ContextKey="salesman" CompletionListElementID="dvsalesman">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="reqsalesman" runat="server" ErrorMessage="Require M R Code"
                            ValidationGroup="S" ControlToValidate="txtsalemanCode">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblSalesManName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label></ContentTemplate>
                </asp:UpdatePanel>--%>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblZoneCode" runat="server">Extra Zone Code </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="9" DataTextField="ZoneName" DataValueField="ZoneCode"
                            CssClass="ddl-form" Width="160px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <%--<tr>
            <td colspan="5" style="padding-bottom: 10px; padding-top: 8px;">
                <hr />
            </td>
        </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="Label10" CssClass="lbl-form" runat="server" Text="Person Incharge"></asp:Label>
                    </td>
                    <td>
                        <%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="txtpIncharge" onfocus="setfocus('');" Width="130px" CssClass="inp-form"
                            AutoComplete="off" TabIndex="10" runat="server"></asp:TextBox>
                        <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
                    </td>
                    <td width="10px">
                    </td>
                    <td>
                        <asp:Label ID="Label11" CssClass="lbl-form" runat="server" Text="Sp. Instruction"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="txtspInstruct" Width="130px" CssClass="inp-form" TabIndex="11" AutoComplete="off"
                            runat="server"></asp:TextBox>
                        <%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require Special Instruction"
                            ValidationGroup="S" ControlToValidate="txtspInstruct">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" CssClass="lbl-form" runat="server" Text="Transporter"></asp:Label>
                    </td>
                    <td colspan="4">
                        <%-- <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>--%>
                        <%-- <table width="100%">
              <tr>
                <td style="width: 120px">--%>
                        <asp:TextBox ID="txttransporter" Width="80px" CssClass="inp-form" TabIndex="12" autocomplete="off"
                            runat="server" AutoPostBack="True" OnTextChanged="txttransporter_TextChanged"></asp:TextBox>
                        <div id="divtrasport" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="ACExttransporter" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txttransporter"
                            UseContextKey="true" ContextKey="transporter" CompletionListElementID="divtrasport">
                        </ajaxCt:AutoCompleteExtender>
                        <%--</td>
                <td>--%>
                        <asp:Label ID="lbltransporter" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label>
                        <%--</td>
              </tr>
            </table>--%>
                        <%-- </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txttransporter" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqtransport" runat="server" ErrorMessage="Require Transporter"
                            InitialValue="none" ValidationGroup="S" ControlToValidate="txttransporter">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label16" CssClass="lbl-form" runat="server" Text="Bank Through"></asp:Label>
                    </td>
                    <td colspan="4">
                        <%--   <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                        <table width="100%"">
                            <tr>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtbankdet" Width="80px" CssClass="inp-form" TabIndex="12" autocomplete="off"
                                        runat="server" AutoPostBack="True" OnTextChanged="txtbankdet_TextChanged"></asp:TextBox>
                                    <div id="divbank" class="divauto">
                                    </div>
                                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                        ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                        ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbankdet"
                                        UseContextKey="true" ContextKey="Bank" CompletionListElementID="divbank">
                                    </ajaxCt:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Label ID="lblbankname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                        runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <%--    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtbankdet" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <%-- <tr>
            <td colspan="5" style="padding-bottom: 10px; padding-top: 8px;">
                <hr />
            </td>
        </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="lbldate" Text="Delivery Date " CssClass="lbl-form" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliverydte" CssClass="inp-form" Width="80px" TabIndex="14" AutoComplete="off"
                            runat="server"></asp:TextBox>
                        <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkDDlset" runat="server" TargetControlID="txtsetqty"
                            WatermarkText="Qty">
                        </ajaxCt:TextBoxWatermarkExtender>
                        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDeliverydte"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDeliverydte"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    </td>
                    <%--<td>
                    </td>--%>
                    <td align="right">
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server">Outstanding</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblOutstanding" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="5">
                        <asp:Panel runat="server" ID="Panel1" DefaultButton="btngetset" Style="display: none">
                            <asp:DropDownList CssClass="ddl-form" Width="160px" ID="DDLSelectSet" TabIndex="15"
                                runat="server" DataTextField="Value" DataValueField="AutoId">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtsetqty" TabIndex="16" Width="35px" CssClass="inp-form" Style="text-align: right;"
                                MaxLength="5" onkeypress="return CheckNumeric(event)" runat="server"></asp:TextBox>
                            <asp:Button ID="btngetset" CssClass="form-submit" TabIndex="17" runat="server" Style="display: none;"
                                ValidationGroup="Date" Text="Get" Width="70px" OnClick="btngetset_Click" />
                        </asp:Panel>
                        <asp:Panel runat="server" ID="aa" DefaultButton="btnaddBooks">
                            <%-- <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>--%>
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList AutoPostBack="true" CssClass="ddl-form" ID="DDLstandard" TabIndex="18"
                                            runat="server" DataTextField="Value" DataValueField="AutoId" OnSelectedIndexChanged="DDLstandard_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbkcod" onfocus="setfocus('book');" onblur="setfocus('');" autocomplete="off"
                                            TabIndex="19" CssClass="inp-form" runat="server" OnTextChanged="txtbkcod_TextChanged"
                                            Width="240px"></asp:TextBox>
                                        <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarktxtbook" runat="server" TargetControlID="txtbkcod"
                                            WatermarkText="Enter BookCode to add  ">
                                        </ajaxCt:TextBoxWatermarkExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbookqty" TabIndex="20" Width="35px" AutoComplete="off" CssClass="inp-form"
                                            Style="text-align: right;" MaxLength="5" onkeypress="return CheckNumeric(event)"
                                            runat="server"></asp:TextBox>
                                        <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtbookqty"
                                            WatermarkText="Qty">
                                        </ajaxCt:TextBoxWatermarkExtender>
                                        <div id="divwidth" class="divauto">
                                        </div>
                                        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbkcod"
                                            UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
                                        </ajaxCt:AutoCompleteExtender>
                                    </td>
                                </tr>
                            </table>
                            <%--  </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLstandard" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                        </asp:Panel>
                        <%--<a href="Javascript:Openpopup(1);">Add Books</a>--%>
                        <asp:Button ID="btnaddBooks" CssClass="form-submit" runat="server" ValidationGroup="Date"
                            Text="Add" Width="70px" Style="display: none;" OnClick="btnaddBooks_Click" /><a href="Javascript:Openpopup(2);"
                                style="display: none;">Get DC</a>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<div>
    <asp:Button ID="btnclear" runat="server" Style="display: none;" Width="80px" OnClick="btnclear_Click"
        Text="Clear" />
</div>
<br />
<asp:UpdatePanel ID="upGridData" runat="server">
    <ContentTemplate>
        <asp:GridView ID="grdBookDetails" CssClass="product-table" AutoGenerateColumns="False"
            TabIndex="21" Width="800px" runat="server" OnRowDeleting="grdBookDetails_RowDeleting"
            AlternatingRowStyle-CssClass="alt" OnRowDataBound="grdBookDetails_RowDataBound"
            ShowFooter="true">
            <Columns>
                <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblDCDetailID" Style="display: none;" runat="server" Text='<%#Eval("DCDetailID")%>'></asp:Label>
                        <asp:Label ID="lblBookCode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Book Name" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Standard" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medium" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Original Qty" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblavailable" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Confirmed Qty" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblgivedqty" Style="text-align: right;" runat="server" Text='<%#Eval("GivedQty")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="20px" HeaderText="Qty" ItemStyle-HorizontalAlign="right"
                    FooterStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:TextBox ID="txtquty" MaxLength="5" runat="server" onkeypress="return CheckNumeric(event)"
                            AutoComplete="off" Style="text-align: right;" Text='<%#Eval("RemainQty")%>' Width="40px"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle Width="20px" />
                    <ItemStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Label ID="lblTotalqty" CssClass="totalQty" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDeldate" Width="80px" Style="text-align: right;" runat="server"
                            AutoComplete="off" Text='<%#Eval("DeliveryDate","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDeldate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="DeliveryDate" runat="server" TargetControlID="txtDeldate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    </ItemTemplate>
                    <HeaderStyle Width="40px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:TextBox ID="txtrate" MaxLength="6" runat="server" onkeypress="return CheckNumericWithDot(event)"
                            AutoComplete="off" Style="text-align: right;" Text='<%#Eval("Rate","{0:0.00}")%>'
                            Width="40px"></asp:TextBox>
                        <asp:Label ID="lblRate" Style="text-align: right; display: none" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dis.(%)" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDiscount" onkeydown="setAmtclass(this)" MaxLength="6" Style="text-align: right;"
                            AutoComplete="off" Text='<%#Eval("Discount")%>' onkeypress="return CheckNumericWithDot(event)"
                            runat="server" Width="40px"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle Width="20px" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                    FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblAmt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                        <asp:Label ID="txtAddDiscount" Style="text-align: right; display: none;" Text='<%#Eval("AdditionalDiscount")%>'
                            runat="server" Width="20px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                    <ItemStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Label ID="lblTotalamt" CssClass="totalAmt" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remove" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnRemove" ImageUrl="~/Images/icon/DeleteIcon.gif" CommandName="delete"
                            OnClientClick="return confirm('Are you sure want to remove this book');" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblTotalqtyId" Style="display: none;" runat="server" CssClass="inp-form"></asp:Label>
        <asp:Label ID="lblTotalamtId" Style="display: none;" runat="server" CssClass="inp-form"></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btngetset" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnaddBooks" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<!--Modal popup for get bookName by BookId -->
<asp:Panel ID="pnlBooks" DefaultButton="btnaddBooks" Style="display: none;" runat="server">
    <div class="facebox">
        <div class="content">
            <uc1:helpctrl ID="helpctrl1" runat="server" />
        </div>
    </div>
</asp:Panel>
<ajaxCt:ModalPopupExtender ID="modalPopupForBooks" runat="server" TargetControlID="LinkButton1"
    PopupControlID="pnlBooks" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />
<asp:LinkButton ID="LinkButton1" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
<!--End -->
<!--Modal popup for get details by Document No -->
<asp:Panel ID="PnlInsertDocNum" runat="server" DefaultButton="BtnGetDCDetails" Style="display: none;
    text-align: left; width: 270px; height: 140px;">
    <div class="facebox">
        <asp:Label ID="Label9" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
            ForeColor="White"></asp:Label>
        <a id="A1" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup(2);">
            <img src="Images/button-cross.png" /></a>
        <br />
        <div class="content">
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td style="display: none;">
                                    <asp:Label ID="LablEmpCode" runat="server" Text="Salesman Code : "></asp:Label>
                                </td>
                                <td style="display: none;">
                                    <asp:TextBox ID="TxtEmpCode" runat="server" MaxLength="10" OnTextChanged="TxtEmpCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblDocNo" runat="server" Font-Bold="true" Font-Size="12px" Text="Document No : "
                                        CssClass="lbl-form"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtDocNo" onkeypress="return CheckNumeric(event)" runat="server"
                                        MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1" align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="get"
                                        ControlToValidate="TxtDocNo">Enter Order No.</asp:RequiredFieldValidator>
                                </td>
                                <td colspan="1" align="right">
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
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="S"
    runat="server" ID="ss" />
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Date"
    runat="server" ID="date1" />
<ajaxCt:ModalPopupExtender ID="ModalPopUpDocNum" runat="server" TargetControlID="LnkBtn"
    PopupControlID="PnlInsertDocNum" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />
<asp:LinkButton ID="LnkBtn" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
<!--End -->

<script type="text/javascript">


    shortcut.add("Ctrl+S", function() {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_Master1_btn_Save').click();
    });

    shortcut.add("Ctrl+A", function() {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_Master1_txtbkcod').focus();
    });
    shortcut.add("Ctrl+G", function() {
        Openpopup(2)
    });

    shortcut.add("esc", function() {

        Closepopup(2)
    });

    shortcut.add("Ctrl+C", function() {
        location.reload(true);
    });



    function Openpopup(id) {
        if (id == 1) {
            $find('ctl00_ContentPlaceHolder1_uc_DC_Master1_modalPopupForBooks').show();
            document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_Master1_txtbkcod').value = "";
            document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_Master1_txtbkcod').focus();
        }
        if (id == 2) {
            $find('ctl00_ContentPlaceHolder1_uc_DC_Master1_ModalPopUpDocNum').show();
            document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_Master1_TxtDocNo').focus();
        }
    }
    function Closepopup(id) {
        if (id == 1) {
            $find('ctl00_ContentPlaceHolder1_uc_DC_Master1_modalPopupForBooks').hide();
        }
        if (id == 2) {
            $find('ctl00_ContentPlaceHolder1_uc_DC_Master1_ModalPopUpDocNum').hide();
        }
    }

    function clearAddbook() {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_Master1_txtbkcod').value = "";
        document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_Master1_txtbkcod').focus();
        document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_Master1_txtbookqty').value = "";
    }



    setTimeout("setSatus()", 2000);
    function setSatus() {
        var status = "[ Ctrl+A : Add book ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]&nbsp;&nbsp;&nbsp;[ Ctrl+G : Edit Order ]&nbsp;&nbsp;&nbsp;[ Ctrl+C : New Order ]&nbsp;&nbsp;&nbsp;[ Ctrl+M : Side Menu(tab) ]";
        document.getElementById('status').innerHTML = status;

    }
    function multiplyQty(id, id1, id2, disc) {
        var Qty = document.getElementById(id).value;
        var Rate = document.getElementById(id1).value;
        var Amt = 0;
        var disc = parseFloat(document.getElementById(disc).value);
        var totalQtyId = "";
        var totalAmtID = "";


        var totalQty = 0;
        var totalAmt = 0;



        //  var adddisc1 = parseFloat(adddisc.innerHTML);
        var newdisc = disc;
        var discountprice = (Qty * Rate) * (disc / 100);
        //id1.innerHTML * id.value;        
        document.getElementById(id2).innerHTML = (Qty * Rate) - discountprice;
        document.getElementById(id2).innerHTML = document.getElementById(id2).innerHTML;

        totalQtyId = document.getElementById("<%=lblTotalqtyId.ClientID %>").innerHTML;
        totalAmtID = document.getElementById("<%=lblTotalamtId.ClientID %>").innerHTML;

        totalQty = document.getElementById(totalQtyId).innerHTML;
        totalAmt = document.getElementById(totalAmtID).innerHTML;

        if (totalQty >= 0) {
            totalQty = parseInt(totalQty) + parseInt(Qty);
            //  document.getElementById(totalQtyId).innerHTML = totalQty;
        }
        if (totalAmt >= 0) {
            totalAmt = parseFloat(totalAmt) + ((Qty * Rate) - discountprice);

            //document.getElementById(totalAmtID).innerHTML = totalAmt;
            TOTAL();
        }
    }
    function setAmtclass() {
    }


</script>

<script type="text/javascript">
    function TOTAL() {

        var gridview = document.getElementById('<%=grdBookDetails.ClientID %>')

        var Qty = 0;
        var ToatalQty = 0;
        var amount = 0;
        var totalAmt = 0
        var Rate = 0;
        var TotalRate = 0;
        var Disc = 0;
        var TotalDisc = 0;

        for (var r = 1; r < gridview.rows.length - 1; r++) {

            Qty = $(gridview.rows[r].cells[4]).find('input:text').attr("value");
            //alert(Qty);
            Rate = $(gridview.rows[r].cells[6]).find('input:text').attr("value");
            // Disc  = $(gridview.rows[r].cells[7]).find('input:text').attr("value");

            totalAmt = totalAmt + parseFloat(gridview.rows[r].cells[8].innerHTML.replace(/<[^>]+>/g, ""));
            // TotalDisc = TotalDisc + parseFloat(Disc);
            ToatalQty = ToatalQty + parseInt(Qty);
            TotalRate = TotalRate + parseFloat(Rate)
            // totalAmt = totalAmt + parseFloat((ToatalQty * TotalRate) - ((ToatalQty * TotalRate) * (TotalDisc/100)));

            // ele  = $(gridview.rows[r].cells[4]).find('input:text').attr("value");
            //   alert(ele);

        }

        // amount = ((ToatalQty * TotalRate * TotalDisc)/100)
        //totalAmt =(ToatalQty * TotalRate) - amount


        $('.totalQty').html(ToatalQty.toString());
        $('.totalAmt').html(totalAmt.toString());



    }

</script>

