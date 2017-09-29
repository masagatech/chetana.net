<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CNSpecimanMaster.ascx.cs"
    Inherits="UserControls_CNSpecimanMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>
        <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<div style="float: right; width: 59%">
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:Button ID="btn_Save" Enabled="false" CssClass="submitbtn" ValidationGroup="S"
                runat="server" Text="Save" Width="80px" OnClick="btn_Save_Click" />
            <asp:Button ID="btnEdit1" OnClientClick="Openpopup(2)" CssClass="submitbtn" Width="80px"
                runat="server" Text="Edit"></asp:Button>
             <asp:Button ID="btn_PrintSave" Visible="true"
            CssClass="submitbtn" ValidationGroup="S" TabIndex="100" ToolTip="Save below data and Print"
            runat="server" Text="Save & Print" OnClick="btn_PrintSave_Click" Width="80px" />&nbsp;
            <asp:Label Style="display: none;" ID="lblmsg" runat="server" Text=" "></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btngetset" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- <asp:Button ID="btncancel" CssClass="form-submit" runat="server" Text="Cancel" Width="80px"
        OnClick="btncancel_Click" />--%>
</div>
<br />
<br />
<asp:Panel ID="PnlSpecimenDetails" CssClass="panelDetails" runat="server" Style="width: 740px;">
    <table width="100%" cellpadding="0">
        <tr>
            <td width="100px">
                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="GCN"></asp:Label>
            </td>
            <td width="110px">
                <%--<asp:TextBox ID="txtdoc" CssClass="inp-form" TabIndex="1" Width="80px" runat="server"
                    Enabled="false" MaxLength="10"></asp:TextBox>--%>
                <asp:TextBox ID="txtGCN" CssClass="inp-form" Width="90px" runat="server" TabIndex="1"></asp:TextBox>
                <%-- <ajaxCt:FilteredTextBoxExtender ID="filter4" runat="server" FilterType="Custom, Numbers"
                    TargetControlID="Txtgcn" ValidChars="." />--%>
            </td>
            <td width="10px"></td>
            <td width="120px">
                <%--<asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
                <font color="red">*</font>--%>
                <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="CN Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <%--<asp:TextBox ID="txtdocDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                   ></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdocDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtdocDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />--%>
                <asp:UpdatePanel ID="UpPnldate1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCNDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCNDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtCNDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>(dd/mm/yyyy)
                <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require Date"
                    ValidationGroup="S" ControlToValidate="txtCNDate">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <%--<asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Challan No."></asp:Label>--%>
                <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="SCN"></asp:Label>
            </td>
            <td>
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtchalan" CssClass="inp-form" Width="80px" TabIndex="3" runat="server"
                            AutoPostBack="true" OnTextChanged="txtchalan_TextChanged" MaxLength="10"></asp:TextBox></ContentTemplate>
                </asp:UpdatePanel>--%>
                <asp:TextBox ID="txtSCN" CssClass="inp-form" Width="90px" runat="server" TabIndex="3"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqChallan" runat="server" ErrorMessage="Require Challan No."
                    ValidationGroup="Ssss" ControlToValidate="txtSCN">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <%-- <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Challan Date"></asp:Label>--%>
                <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text=" L.R. No.  "></asp:Label>
            </td>
            <td>
                <%--  <asp:TextBox ID="txtChalDate" onblur="lthantoday(this)" CssClass="inp-form" TabIndex="4"
                    Width="80px" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtChalDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtChalDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />--%>
                <asp:TextBox ID="txtlrno" CssClass="inp-form" Width="100px" runat="server" Text="" TabIndex="4"></asp:TextBox>
            </td>
            <%-- <td>
                (dd/mm/yyyy)
                <asp:RequiredFieldValidator ID="reqDt" runat="server" ErrorMessage="Require Date"
                    ValidationGroup="Sssss" ControlToValidate="txtChalDate">*</asp:RequiredFieldValidator>
            </td>--%>
        </tr>
        <tr>
            <td>
                <%--<asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Order No."></asp:Label>--%>
                <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="MR Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtsalemanCode" onfocus="setfocus('customer');" autocomplete="off" Width="123px" CssClass="inp-form"
                    TabIndex="5" runat="server" OnTextChanged="txtsalemanCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                <div id="dvsalesman" class="divauto">
                </div>
                <ajaxCt:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtsalemanCode"
                    UseContextKey="true" ContextKey="salesman" CompletionListElementID="dvsalesman">
                </ajaxCt:AutoCompleteExtender>

                <td>
                    <asp:Label ID="lblSalesManName" runat="server" CssClass="lbl-form" Font-Size="12px" ForeColor="Blue"
                        Width="100px"></asp:Label>
                </td>
            <%--<td>
                <asp:RequiredFieldValidator ID="reqOrdeR" runat="server" ErrorMessage="Require Order No."
                    ValidationGroup="Saaa" ControlToValidate="txtorder">*</asp:RequiredFieldValidator>
            </td>--%>
            <td>
                <%--<asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Order Date"></asp:Label>--%>
                <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="  Transporter   "></asp:Label>
            </td>
            <td>
                <%--<asp:TextBox ID="txtOrdDate" CssClass="inp-form" Width="80px" TabIndex="6" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtOrdDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtOrdDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />--%>
                <%--<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>--%>
                <asp:TextBox ID="txtTrasnport" CssClass="inp-form" Width="100px" runat="server"
                    Enabled="true" Text="" TabIndex="6"></asp:TextBox>
                <div id="divtrasport" class="divauto">
                </div>
                <ajaxCt:AutoCompleteExtender ID="ACExttransporter" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtTrasnport"
                    UseContextKey="true" ContextKey="transporter" CompletionListElementID="divtrasport">
                </ajaxCt:AutoCompleteExtender>
                <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
            </td>
            <%-- <td>
                (dd/mm/yyyy)
                <asp:RequiredFieldValidator ID="reqDat" runat="server" ErrorMessage="Require Date"
                    ValidationGroup="Saaa" ControlToValidate="txtOrdDate">*</asp:RequiredFieldValidator>
            </td>--%>
        </tr>
        <tr>
            <%-- <td>
                <asp:Label ID="Label7" CssClass="lbl-form" runat="server" Text="M R Code"></asp:Label>
                <font color="red">*</font>
            </td>--%>
            <%-- <td colspan="4">
                
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtsalemanCode"  onfocus="setfocus('customer');" autocomplete="off" Width="80px" CssClass="inp-form"
                            TabIndex="7" runat="server" OnTextChanged="txtsalemanCode_TextChanged" AutoPostBack="true"></asp:TextBox>
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
                            ValidationGroup="S" ControlToValidate="txtsalemanCode">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblSalesManName" CssClass="lbl-form" ForeColor="Blue" Font-Size="12px"
                            runat="server"></asp:Label>
                            </ContentTemplate>
                </asp:UpdatePanel>
            </td>--%>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" CssClass="lbl-form" runat="server" Text="Sp. Instruction"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtspInstruct" Width="130px" CssClass="inp-form" TabIndex="7"
                            runat="server"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="padding-bottom: 10px; padding-top: 8px;">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel runat="server" ID="Panel1" DefaultButton="btngetset">
                    <asp:DropDownList CssClass="ddl-form" Width="160px" ID="DDLSelectSet" TabIndex="8" runat="server"
                        DataTextField="Value" DataValueField="AutoId">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtsetqty" TabIndex="9" Width="30px" CssClass="inp-form" Style="text-align: right;"
                        onkeypress="return CheckNumeric(event)" runat="server"></asp:TextBox>
                    <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtsetqty"
                        WatermarkText="Qty">
                    </ajaxCt:TextBoxWatermarkExtender>
                </asp:Panel>
            </td>
            <td>
                <asp:Button ID="btngetset" CssClass="form-submit" TabIndex="80" runat="server" Style="display: none;"
                    Text="Get" Width="70px" OnClick="btngetset_Click" />
            </td>
            <td colspan="3">
                <asp:Panel runat="server" ID="aa" DefaultButton="btnaddBooks">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" ID="DDlstandard" TabIndex="10" runat="server"
                                DataTextField="Value" DataValueField="AutoId" AutoPostBack="true"
                                OnSelectedIndexChanged="DDlstandard_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtbkcod" autocomplete="off" TabIndex="11" CssClass="inp-form" runat="server"
                                OnTextChanged="txtbkcod_TextChanged" Width="240px"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtbkcod" WatermarkText="Enter BookCode to add  ">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <asp:TextBox ID="txtbookqty" TabIndex="12" Width="30px" CssClass="inp-form" Style="text-align: right;"
                                onkeypress="return CheckNumeric(event)" runat="server"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtbookqty"
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
                            <asp:AsyncPostBackTrigger ControlID="DDlstandard" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
                <%--<a href="Javascript:Openpopup(1);">Add Books</a>--%>
            </td>
            <td style="padding-left: 5px;">&nbsp;&nbsp;&nbsp;&nbsp;
                  <%--<asp:Button ID="btnaddbk" CssClass="form-submit" TabIndex="10" runat="server" Text="Add NewBook"
              OnClick="btnaddbk_Click" />--%>
                <asp:Button ID="btnaddBooks" CssClass="form-submit" runat="server"
                    Text="Add" Width="70px" Style="display: none;" OnClick="btnaddBooks_Click" /><a href="Javascript:Openpopup(2);"
                        style="display: none;">Get Specimens</a>
            </td>
            <td>
                <asp:Button ID="btnclear" CssClass="form-submit" Style="display: none;" runat="server"
                    Text="Clear" Width="70px" OnClick="btnclear_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:UpdatePanel ID="upGridData" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:GridView ID="grdBookDetails" CssClass="product-table" AutoGenerateColumns="False"
            Width="800px" runat="server" OnRowDeleting="grdBookDetails_RowDeleting" AlternatingRowStyle-CssClass="alt"
            OnRowDataBound="grdBookDetails_RowDataBound" OnRowCreated="grdBookDetails_RowCreated"
            ShowFooter="true">
            <Columns>
                <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblspecDetailID" Style="display: none;" runat="server" Text='<%#Eval("SpecimenDetailID")%>'></asp:Label>
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


                <asp:TemplateField HeaderStyle-Width="20px" HeaderText="Quantity" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:TextBox ID="txtquty" runat="server"  onkeypress="return CheckNumeric(event)" onblur="ValidateQty(this);" AutoComplete="off"
                            Style="text-align: right;" TabIndex="14" Text='<%#Eval("RemainQty")%>' Width="40px"></asp:TextBox>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalqty" CssClass="totalQty" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <HeaderStyle Width="20px" />
                    <ItemStyle HorizontalAlign="Right" />
                    <FooterStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRate" Style="text-align: right;" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblAmt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                        <asp:TextBox ID="txtDiscount" Style="text-align: right; display: none;" Text='<%#Eval("Discount","{0:0.00}")%>'
                            runat="server" Width="40px"></asp:TextBox>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalamt" CssClass="totalAmt" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                    <ItemStyle HorizontalAlign="Right" />
                    <FooterStyle HorizontalAlign="Right" />
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
                  <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Invoice Qty" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblinvqty" CssClass="invqty" Style="text-align: right;" runat="server" Text='<%#Eval("InvQty")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Return Qty" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblrqty" CssClass="rqty" Style="text-align: right;" runat="server" Text='<%#Eval("RQty")%>'></asp:Label>
                        <asp:Label ID="lbltotal" CssClass="total" Style="text-align: right;" Visible="false" runat="server" Text='<%#Eval("Total")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:TemplateField HeaderText="Discount" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                       
                        <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" TargetControlID="txtDiscount"
                            FilterType="Custom, Numbers" ValidChars="+-=/*()." />
                    </ItemTemplate>
                    <HeaderStyle Width="20px" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>--%>
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
    <asp:UpdatePanel ID="upBooksAdd" runat="server">
        <ContentTemplate>
            <div class="facebox">
                <div class="content">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
                                    ForeColor="White"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton2" CssClass="close" runat="server" ImageUrl="../Images/button-cross.png"
                                    OnClientClick="Closepopup(1);" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" CssClass="lbl-form" runat="server" Text="Book Code"></asp:Label>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" CssClass="lbl-form" runat="server" Text="Book Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtname" CssClass="inp-form" runat="server"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<ajaxCt:ModalPopupExtender ID="modalPopupForBooks" runat="server" TargetControlID="LinkButton1"
    PopupControlID="pnlBooks" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />
<asp:LinkButton ID="LinkButton1" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
<!--End -->
<!--Modal popup for get details by Document No -->
<asp:Panel ID="PnlInsertDocNum" runat="server" DefaultButton="BtnGetSpecimanDetails"
    Style="display: none; text-align: left; width: 270px; height: 140px;">
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
                                    <asp:TextBox ID="TxtEmpCode" runat="server" OnTextChanged="TxtEmpCode_TextChanged"></asp:TextBox>
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
                                    <asp:Button ID="BtnGetSpecimanDetails" CssClass="submitbtn" runat="server" ValidationGroup="get"
                                        Text="Get Details" OnClick="BtnGetSpecimanDetails_Click" />
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
<ajaxCt:ModalPopupExtender ID="ModalPopUpDocNum" runat="server" TargetControlID="LnkBtn"
    PopupControlID="PnlInsertDocNum" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />
<asp:LinkButton ID="LnkBtn" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
<!--End -->

<script type="text/javascript">

    window.onload = function () {
        UpperBound = parseInt('<%= this.grdBookDetails.Rows.Count %>') - 1;
        LowerBound = 0;
        SelectedRowIndex = -1;
    }



    shortcut.add("Ctrl+S", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_btn_Save').click();
    });

    shortcut.add("Ctrl+A", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_txtbkcod').focus();
    });
    shortcut.add("Ctrl+G", function () {
        Openpopup(2)
    });

    shortcut.add("esc", function () {

        Closepopup(2)
    });

    shortcut.add("Ctrl+C", function () {
        location.reload(true);
    });



    function Openpopup(id) {
        if (id == 1) {
            $find('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_modalPopupForBooks').show();
            document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_txtbkcod').value = "";
            document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_txtbkcod').focus();
        }
        if (id == 2) {
            $find('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_ModalPopUpDocNum').show();
            document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_TxtDocNo').focus();
        }
    }
    function Closepopup(id) {
        if (id == 1) {
            $find('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_modalPopupForBooks').hide();
        }
        if (id == 2) {
            $find('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_ModalPopUpDocNum').hide();
        }
    }

    function clearAddbook() {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_txtbkcod').value = "";
        document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_txtbkcod').focus();
        document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_txtbookqty').value = "";
    }



    setTimeout("setSatus()", 2000);
    function setSatus() {
        var status = "[ Ctrl+A : Add book ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]&nbsp;&nbsp;&nbsp;[ Ctrl+G : Edit Specimen ]&nbsp;&nbsp;&nbsp;[ Ctrl+C : New Specimen ]";
        document.getElementById('status').innerHTML = status;

    }
    function multiplyQty(id, id1, id2) {
        var Qty = document.getElementById(id).value;
        var Rate = document.getElementById(id1).innerHTML;
        //   alert(Rate);
        var Amt = 0;
        //var disc = parseFloat(document.getElementById(disc).value);
        var totalQtyId = "";
        var totalAmtID = "";


        var totalQty = 0;
        var totalAmt = 0;



        //  var adddisc1 = parseFloat(adddisc.innerHTML);
        // var newdisc = disc;
        //var discountprice= (Qty * Rate) * (disc /100);
        //id1.innerHTML * id.value;        
        document.getElementById(id2).innerHTML = (Qty * Rate);
        document.getElementById(id2).innerHTML = document.getElementById(id2).innerHTML;

        totalQtyId = document.getElementById("<%=lblTotalqtyId.ClientID %>").innerHTML;
    totalAmtID = document.getElementById("<%=lblTotalamtId.ClientID %>").innerHTML;

    totalQty = document.getElementById(totalQtyId).innerHTML;
    totalAmt = document.getElementById(totalAmtID).innerHTML;
    // alert(totalQty);
    //  alert(totalAmt);
    if (totalQty >= 0) {

        totalQty = parseInt(totalQty) + parseInt(Qty);

        //  document.getElementById(totalQtyId).innerHTML = totalQty;
    }
    if (totalAmt >= 0) {

        totalAmt = parseFloat(totalAmt) + ((Qty * Rate));

        //document.getElementById(totalAmtID).innerHTML = totalAmt;
        TOTAL();
    }
}

</script>
<script type="text/javascript">

    function ValidateQty(d)
    {
        var Qty = $(d).val();
        var Rqty = $(d).parent().parent().find('.rqty').html();
        var InvQty =$(d).parent().parent().find('.invqty').html();
        var total = $(d).parent().parent().find('.total').html();
        if (Qty == "")
        {
            $(d).val('0');
        }
        if (parseInt(Rqty) != 0)
        {
            if(parseInt(total) < parseInt(Qty))
            {
                alert('Invalid Quntity');
                $(d).val();
               // $(d).focus();
              //  return false;
            }
        }
        else {
            if (parseInt(InvQty) < parseInt(Qty))
            {
                alert('Invalid Quntity');
                $(d).val();
                $(d).focus();
                return false;
            }
        }
        //var Qty = 0;
        //var TotalQty = 0;
       // var Rqty = 0;
        //var InvQty = 0;
        //var gridview = document.getElementById('<%=grdBookDetails.ClientID %>')
        //for (var r = 1; r < gridview.rows.length - 1; r++) {
        //    Qty = $(gridview.rows[r].cells[4]).find('input:text').attr("value");
        //    InvQty = $(gridview.rows[r].cells[9]).find('input:text').attr("value");
        //    Rqty = $(gridview.rows[r].cells[10]).find('input:text').attr("value");
           // TotalQty = $(gridview.rows[r].cells[12]).find('input:text').attr("value");
        //    if (Rqty == 0)
        //    {
        //        alert('Qty 0');
        //        break;
        //    }
        //}
    }

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
            // alert(Qty);
            Rate = $(gridview.rows[r].cells[5]).find('input:text').attr("value");
            // Disc  = $(gridview.rows[r].cells[7]).find('input:text').attr("value");
            // alert(Rate);
            totalAmt = totalAmt + parseFloat(gridview.rows[r].cells[6].innerHTML.replace(/<[^>]+>/g, ""));
            // alert(totalAmt);
            // TotalDisc = TotalDisc + parseFloat(Disc);
            ToatalQty = ToatalQty + parseInt(Qty);
            TotalRate = TotalRate + parseFloat(Rate)
            // totalAmt = totalAmt + parseFloat((ToatalQty * TotalRate) - ((ToatalQty * TotalRate) * (TotalDisc/100)));

            // ele  = $(gridview.rows[r].cells[4]).find('input:text').attr("value");
            //            alert(ele);

        }

        // amount = ((ToatalQty * TotalRate * TotalDisc)/100)
        //totalAmt =(ToatalQty * TotalRate) - amount


        $('.totalQty').html(ToatalQty.toString());
        $('.totalAmt').html(totalAmt.toString());



    }

</script>
<script type="text/javascript">
    setTimeout("setSatus()", 2000);
    function setSatus() {
        var status = "[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
        document.getElementById('status').innerHTML = status;
    }
</script>
<script type="text/javascript">

    shortcut.add("Ctrl+S", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_btn_Save').click();
    });

    shortcut.add("Ctrl+F", function () {
        document.getElementById('filterdata').focus();
    });

</script>
<script type="text/javascript">

    shortcut.add("Ctrl+S", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_btnEdit1').click();
    });

    shortcut.add("Ctrl+F", function () {
        document.getElementById('filterdata').focus();
    });

</script>
<%--<script type="text/javascript">
  function Openpopup(id)
   {
    if(id==1)
     {
        $find('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_modalPopupForBooks').show();
         document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_txtbkcod').value="";
        document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_txtbkcod').focus();
     }
     if(id==2)
     {
        $find('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_ModalPopUpDocNum').show();
        document.getElementById('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_TxtDocNo').focus();
     }
   }
   function Closepopup(id)
   {
    if(id==1)
     {
        $find('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_modalPopupForBooks').hide();
     }
     if(id==2)
     {
        $find('ctl00_ContentPlaceHolder1_uc_SpecimanMaster1_ModalPopUpDocNum').hide();
     }
   }
</script>--%>