<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_EditDC.ascx.cs" Inherits="UserControls_ODC_uc_EditDC" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Src="../help/helpctrl.ascx" TagName="helpctrl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Transaction > ORDER > Edit D.C. <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<div style="float: left; width: 71%">
    <asp:UpdatePanel ID="updatebtn" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="btn_Save" CssClass="submitbtn" Style="float: right; margin-left: 5px"
                ValidationGroup="S" Visible="false" TabIndex="21" runat="server" Text="Save"
                Width="80px" OnClick="btn_Save_Click" />
            <asp:Button ID="btnEdit" CssClass="submitbtn" Style="float: right; display: none"
                Width="80px" runat="server" Text="Edit" OnClick="btnEdit_Click"></asp:Button>
            <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnGetDCDetails" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</div>
<br />
<br />
<asp:Panel ID="PnlSpecimenDetails" CssClass="panelDetails" Width="68%" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td width="100px">
                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Document No."></asp:Label>
                <asp:Label ID="lblchksplitdc" runat="server" Text="splitdc" Style="display: none"></asp:Label>
            </td>
            <td width="110px">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtdocnew" CssClass="inp-form" TabIndex="1" Width="80px" runat="server"
                            Enabled="false" MaxLength="10"></asp:TextBox>
                        <asp:TextBox ID="txtdoc" CssClass="inp-form" TabIndex="1" Width="80px" runat="server"
                            Enabled="false" Style="display: none" MaxLength="10"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="10px"></td>
            <td width="120px">
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtdocDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdocDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtdocDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        (dd/mm/yyyy)
                        <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require Date"
                            ValidationGroup="S" ControlToValidate="txtdocDate">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="display: none">
            <td>
                <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Challan No."></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtchalan" CssClass="inp-form" Width="80px" TabIndex="3" runat="server"
                            AutoPostBack="true" OnTextChanged="txtchalan_TextChanged" MaxLength="10"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Order No."></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtorder" CssClass="inp-form" Width="80px" TabIndex="5" runat="server"
                            OnTextChanged="txtorder_TextChanged" AutoPostBack="true" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqOrdeR" runat="server" ErrorMessage="Require Order No."
                            ValidationGroup="S" ControlToValidate="txtorder">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td></td>
            <td>
                <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Order Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOrdDate" CssClass="inp-form"
                            Width="80px" TabIndex="6" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtOrdDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" TargetControlID="txtOrdDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        (dd/mm/yyyy)
                        <asp:RequiredFieldValidator ID="reqDat" runat="server" ErrorMessage="Require Date"
                            ValidationGroup="S" ControlToValidate="txtOrdDate">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Customer Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                            Width="80px" CssClass="inp-form" TabIndex="7" runat="server" AutoPostBack="true"
                            OnTextChanged="txtcustomer_TextChanged"></asp:TextBox>
                        <div id="dvcust" class="divauto">
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" CssClass="lbl-form" runat="server" Text="M R Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDlemployee" TabIndex="8" DataTextField="Name" DataValueField="EmpCode"
                            CssClass="ddl-form" Width="160px" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsalesman" runat="server" InitialValue="0" ErrorMessage="Require M R Code"
                            ValidationGroup="S" ControlToValidate="DDlemployee">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtsalemanCode" onfocus="setfocus('salesman');" autocomplete="off"
                            Width="80px" CssClass="inp-form" TabIndex="8" runat="server" OnTextChanged="txtsalemanCode_TextChanged"
                            AutoPostBack="true"></asp:TextBox>
                        <div id="dvsalesman" class="divauto">
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
            <td></td>
            <td>
                <asp:UpdatePanel ID="UpdatePanellblExtra" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblZoneCode" runat="server">Extra Zone Code </asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanelDropExtra" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="9" DataTextField="ZoneName" DataValueField="ZoneCode"
                            CssClass="ddl-form" Width="160px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="padding-bottom: 10px; padding-top: 8px;">
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" CssClass="lbl-form" runat="server" Text="Person Incharge"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtpIncharge" onfocus="setfocus('');" Width="130px" CssClass="inp-form"
                            TabIndex="10" runat="server"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label11" CssClass="lbl-form" runat="server" Text="Sp. Instruction"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtspInstruct" Width="130px" CssClass="inp-form" TabIndex="11"
                            runat="server"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label15" CssClass="lbl-form" runat="server" Text="Transporter"></asp:Label>
            </td>

            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
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
                        <asp:Label ID="lbltransporter" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtcustomer" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>

            <td>
                <asp:RequiredFieldValidator ID="reqtransport" runat="server" ErrorMessage="Require Transporter"
                    InitialValue="none" ValidationGroup="S" ControlToValidate="txttransporter">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label13" runat="server">Limit</asp:Label>
            </td>
            <td>
                <asp:Label ID="lblsplitval" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label16" CssClass="lbl-form" runat="server" Text="Bank Through"></asp:Label>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
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
                        <asp:Label ID="lblbankname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="padding-bottom: 10px; padding-top: 8px;">
                <hr />
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td align="right">
                <asp:Label ID="lbldate" Text="Delivery Date " CssClass="lbl-form" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDeliverydte" CssClass="inp-form" Width="80px" TabIndex="14" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDeliverydte"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDeliverydte"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkDDlset" runat="server" TargetControlID="txtsetqty"
                    WatermarkText="Qty">
                </ajaxCt:TextBoxWatermarkExtender>

                <asp:Panel runat="server" ID="Panel1" DefaultButton="btngetset" Style="display: none">
                    <asp:DropDownList CssClass="ddl-form" Width="160px" ID="DDLSelectSet" TabIndex="15"
                        runat="server" DataTextField="Value" DataValueField="AutoId">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtsetqty" TabIndex="16" Width="35px" CssClass="inp-form" Style="text-align: right;"
                        onkeypress="return CheckNumeric(event)" MaxLength="5" runat="server"></asp:TextBox>
                    <asp:Button ID="btngetset" CssClass="form-submit" TabIndex="17" runat="server" Style="display: none;"
                        ValidationGroup="Date" Text="Get" Width="70px" OnClick="btngetset_Click" />
                </asp:Panel>
            </td>
            <td>
                <asp:Panel runat="server" ID="aa" DefaultButton="btnaddBooks">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList AutoPostBack="true" CssClass="ddl-form" ID="DDLstandard" TabIndex="18"
                                runat="server" DataTextField="Value" DataValueField="AutoId" OnSelectedIndexChanged="DDLstandard_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtbkcod" onfocus="setfocus('book');" onblur="setfocus('');" autocomplete="off"
                                TabIndex="19" CssClass="inp-form" runat="server" OnTextChanged="txtbkcod_TextChanged"
                                Width="240px"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarktxtbook" runat="server" TargetControlID="txtbkcod"
                                WatermarkText="Enter BookCode to add  ">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <asp:TextBox ID="txtbookqty" TabIndex="20" Width="35px" CssClass="inp-form" Style="text-align: right;"
                                onkeypress="return CheckNumeric(event)" MaxLength="5" runat="server"></asp:TextBox>
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
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLstandard" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
                <%--<a href="Javascript:Openpopup(1);">Add Books</a>--%>
                <asp:Button ID="btnaddBooks" CssClass="form-submit" runat="server" ValidationGroup="Date"
                    Text="Add" Width="70px" Style="display: none;" OnClick="btnaddBooks_Click" /><a href="Javascript:Openpopup(2);"
                        style="display: none;">Get DC</a>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:UpdatePanel ID="upGridData" runat="server">
    <ContentTemplate>
        <asp:GridView ID="grdBookDetails" CssClass="product-table" AutoGenerateColumns="False"
            ShowFooter="true" Width="800px" runat="server" OnRowDeleting="grdBookDetails_RowDeleting"
            AlternatingRowStyle-CssClass="alt" OnRowDataBound="grdBookDetails_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblDCDetailID" Style="display: none" runat="server" Text='<%#Eval("DCDetailID")%>'></asp:Label>
                        <asp:Label ID="lblBookid" Style="display: none;" runat="server" Text='<%#Eval("Bookid")%>'></asp:Label>
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
                <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Invoice Qty" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblgivedqty" Style="text-align: right;" runat="server" Text='<%#Eval("GivedQty")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="20px" HeaderText="Qty" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:TextBox ID="txtquty" MaxLength="8" runat="server" onkeypress="return CheckNumeric(event)"
                            Style="text-align: right;" Text='<%#Eval("RemainQty")%>' Width="40px"></asp:TextBox>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalqty" CssClass="totalQty" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <HeaderStyle Width="20px" />
                    <ItemStyle HorizontalAlign="Right" />
                    <FooterStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" Visible="false">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDeldate" Width="80px" Style="text-align: right;" runat="server"
                            Text='<%#Eval("DeliveryDate","{0:dd/MM/yyyy}")%>'></asp:TextBox>
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
                        <asp:TextBox ID="txtrate" onkeydown="setQtyclass(this)" MaxLength="6" runat="server"
                            onkeypress="return CheckNumericWithDot(event)" Style="text-align: right;" Text='<%#Eval("Rate","{0:0.00}")%>'
                            Width="40px"></asp:TextBox>
                        <asp:Label ID="lblRate" Style="text-align: right; display: none;" runat="server"
                            Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Disc.(%)" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDiscount" ReadOnly Style="text-align: right;" Text='<%#Eval("Discount")%>'
                            runat="server" Width="40px"></asp:TextBox>
                        <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" TargetControlID="txtDiscount"
                            FilterType="Custom, Numbers" ValidChars="+-=/*()." />
                    </ItemTemplate>
                    <HeaderStyle Width="20px" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblAmt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                        <asp:Label ID="txtAddDiscount" Style="text-align: right; display: none;" Text='<%#Eval("AdditionalDiscount")%>'
                            runat="server" Width="20px"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalamt" CssClass="totalAmt" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                    <ItemStyle HorizontalAlign="Right" />
                    <FooterStyle HorizontalAlign="Right" />
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
<asp:Panel ID="PnlInsertDocNum" runat="server" DefaultButton="BtnGetDCDetails" Style="display: none; text-align: left; width: 300px; height: 140px;">
    <div class="facebox" width="300px">
        <asp:Label ID="Label9" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
            ForeColor="White"></asp:Label>
        <a id="A1" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup(2);">
            <img src="Images/button-cross.png" /></a>
        <br />
        <div class="content" width="275px">
            <table width="100%">
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="LablcustCode" runat="server" Font-Bold="true" Text="Customer Code: "></asp:Label>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="Upanelcust" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="TxtcustCode" runat="server" Style="display: none" OnTextChanged="TxtcustCode_TextChanged"></asp:TextBox>
                                            <asp:DropDownList CssClass="ddl-form" ID="DDLCustomer" DataTextField="CustName" Width="200px"
                                                DataValueField="CustID" OnSelectedIndexChanged="DDLCustomer_SelectedIndexChanged"
                                                runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDocNo" runat="server" Font-Bold="true" Font-Size="12px" Text="Document No : "
                                        CssClass="lbl-form"></asp:Label>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="TxtDocNo" Style="display: none;" onkeypress="return CheckNumeric(event)"
                                                runat="server" AutoComplete="off" MaxLength="10"></asp:TextBox>
                                            <asp:DropDownList CssClass="ddl-form" ID="ddldocno" DataTextField="DocumentNo_New"
                                                Width="150px" DataValueField="DocumentNo" runat="server" AutoPostBack="false">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DDLCustomer" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1" align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="get"
                                        InitialValue="0" ControlToValidate="ddldocno">Select Document No.</asp:RequiredFieldValidator>
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
    PopupControlID="PnlInsertDocNum" OkControlID="A1" BackgroundCssClass="modalBackground"
    DropShadow="false" EnableViewState="false" />
<asp:LinkButton ID="LnkBtn" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
<!--End -->

<script type="text/javascript">


    shortcut.add("Ctrl+S", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_EditDC1_btn_Save').click();
    });

    shortcut.add("Ctrl+A", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_EditDC1_txtbkcod').focus();
    });
    shortcut.add("Ctrl+G", function () {
        Openpopup(2)
    });

    shortcut.add("esc", function () {

        Closepopup(2)
    });





    function Openpopup(id) {
        if (id == 1) {
            $find('ctl00_ContentPlaceHolder1_uc_EditDC1_modalPopupForBooks').show();
            document.getElementById('ctl00_ContentPlaceHolder1_uc_EditDC1_txtbkcod').value = "";
            document.getElementById('ctl00_ContentPlaceHolder1_uc_EditDC1_txtbkcod').focus();
        }
        if (id == 2) {
            $find('ctl00_ContentPlaceHolder1_uc_EditDC1_ModalPopUpDocNum').show();
            document.getElementById('ctl00_ContentPlaceHolder1_uc_EditDC1_TxtDocNo').focus();
        }
    }
    function Closepopup(id) {
        if (id == 1) {
            $find('ctl00_ContentPlaceHolder1_uc_EditDC1_modalPopupForBooks').hide();
        }
        if (id == 2) {
            $find('ctl00_ContentPlaceHolder1_uc_EditDC1_ModalPopUpDocNum').hide();
        }
    }

    function clearAddbook() {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_EditDC1_txtbkcod').value = "";
        document.getElementById('ctl00_ContentPlaceHolder1_uc_EditDC1_txtbkcod').focus();
        document.getElementById('ctl00_ContentPlaceHolder1_uc_EditDC1_txtbookqty').value = "";
    }



    setTimeout("setSatus()", 2000);
    function setSatus() {
        var status = "[ Ctrl+A : Add book ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]&nbsp;&nbsp;&nbsp;[ Ctrl+G : Edit Order ]";
        document.getElementById('status').innerHTML = status;

    }
    function multiplyQty(id, id1, id2, disc, orgqty) {
        $('.totalQty').html("0");
        $('.totalAmt').html("0");
        var orgQty = document.getElementById(orgqty).innerHTML;
        var Qty = document.getElementById(id).value;
        var Rate = document.getElementById(id1).value;
        var Amt = 0;
        var disc = parseFloat(document.getElementById(disc).value);
        var totalQtyId = "";
        var totalAmtID = "";
        Qty = parseInt(Qty) + parseInt(orgQty);

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

 function TOTAL() {

     var gridview = document.getElementById('<%=grdBookDetails.ClientID %>')

    var Qty = 0;
    var ToatalQty = 0;
    var amount = 0;
    var totalAmt = 0;
    var Rate = 0;
    var TotalRate = 0;
    var Disc = 0;
    var TotalDisc = 0;
    var originalqty = 0;

    for (var r = 1; r < gridview.rows.length - 1; r++) {
        // originalqty =  parseInt(gridview.rows[r].cells[4].innerHTML.replace(/<[^>]+>/g,""));

        Qty = $(gridview.rows[r].cells[6]).find('input:text').attr("value");
        if (Qty != "") {
            Rate = $(gridview.rows[r].cells[8]).find('input:text').attr("value");
        }
        //  Disc  = $(gridview.rows[r].cells[10].innerHTML);
        // alert(Disc);
        if (gridview.rows[r].cells[10].innerHTML.replace(/<[^>]+>/g, "") != "") {
            totalAmt = totalAmt + parseFloat(gridview.rows[r].cells[10].innerHTML.replace(/<[^>]+>/g, ""));
        }
        // TotalDisc = TotalDisc + parseFloat(Disc);
        ToatalQty = ToatalQty + (parseInt(Qty));//+ parseInt(originalqty));
        TotalRate = TotalRate + parseFloat(Rate)


    }
    $('.totalQty').html(ToatalQty.toString());
    $('.totalAmt').html(totalAmt.toString());



}


</script>

<%--<script type="text/javascript">


 function TOTAL()
   {
 
     var gridview = document.getElementById('<%=grdBookDetails.ClientID %>')
      
     var Qty = 0;
     var ToatalQty = 0 ;
     var amount = 0 ;
     var totalAmt = 0
     var Rate= 0;
     var TotalRate= 0;
     var Disc=0;
     var TotalDisc=0;
     
		                for (var r = 1; r < gridview.rows.length-1; r++)
		                {
		                
		                    Qty  = $(gridview.rows[r].cells[6]).find('input:text').attr("value");
			                Rate  = $(gridview.rows[r].cells[8]).find('input:text').attr("value");
			               // Disc  = $(gridview.rows[r].cells[7]).find('input:text').attr("value");
			               
			                totalAmt = totalAmt + parseFloat(gridview.rows[r].cells[10].innerHTML.replace(/<[^>]+>/g,""));
			                alert(totalAmt);
			               // TotalDisc = TotalDisc + parseFloat(Disc);
			                ToatalQty = ToatalQty + parseInt(Qty);
			                TotalRate = TotalRate + parseFloat(Rate)
			               
			                
		                }
		                
		                   // amount = ((ToatalQty * TotalRate * TotalDisc)/100)
		                    //totalAmt =(ToatalQty * TotalRate) - amount
		                    
		               
		                      $('.totalQty').html(ToatalQty.toString());
		                      $('.totalAmt').html(totalAmt.toString());
		           
		             
     
   }

</script>--%>