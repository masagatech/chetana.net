<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DC_EditCN.ascx.cs"
    Inherits="UserControls_ODC_uc_DC_EditCN" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<%@ Register Src="../help/helpctrl.ascx" TagName="helpctrl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>Edit CN <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
</div>
<p>
</p>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server" Width="961px">
            <table>
                <tr>
                    <td colspan="4">
                        <asp:RadioButtonList ID="RdbtnSelect" runat="server" RepeatDirection="Horizontal"
                            TabIndex="1" Width="280px" AutoPostBack="True" OnSelectedIndexChanged="RdbtnSelect_SelectedIndexChanged">
                            <asp:ListItem Value="CN" Text="CN"></asp:ListItem>
                            <asp:ListItem Value="CustomerwiseCN" Selected="True" Text="CustomerwiseCN"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td width="60px">
                        <asp:Label ID="Label11" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td width="5px">
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpPnldate1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="1" Width="80px" runat="server"
                                    Enabled="true" AutoPostBack="True" OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                    Format="dd/MM/yyyy" />
                                <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtFromDate"
                                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                    AutoComplete="true" CultureName="en-US" />
                                <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From Date"
                                    ValidationGroup="dateft" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td width="25px">
                    </td>
                    <td width="60px">
                        <asp:Label ID="Label12" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                            color="red">*</font> &nbsp;
                    </td>
                    <td width="5px">
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpPnldate2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                    Enabled="true" AutoPostBack="True" OnTextChanged="txttoDate_TextChanged"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                                    Format="dd/MM/yyyy" />
                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttoDate"
                                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                    AutoComplete="true" CultureName="en-US" />
                                <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To Date"
                                    ValidationGroup="dateft" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td width="25px">
                    </td>
                    <td>
                        <asp:Button ID="btngetcust" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="dateft"
                            TabIndex="3" Width="50px" OnClick="btngetcust_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="dateft"
            runat="server" ID="ss" />
        <p>
        </p>
        <asp:Panel ID="Pnl1" CssClass="panelDetails" runat="server" Width="961px">
            <table>
                <tr>
                    <td width="65px">
                        <asp:Label ID="Label2" runat="server" Text="Customer" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLCustomer" DataTextField="CustName" DataValueField="CustCode"
                            runat="server" TabIndex="4" OnSelectedIndexChanged="DDLCustomer_SelectedIndexChanged"
                            AutoPostBack="True" Width="500px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <p>
        </p>
        <asp:Panel ID="Pnl2" CssClass="panelDetails" runat="server" Width="961px" ScrollBars="Vertical"
            Height="50px">
            <table width="100%" height="auto" cellpadding="0" cellspacing="0">
                <tr>
                    <asp:Panel ID="PnlCNNo" runat="server">
                        <td width="70px;" valign="top">
                            CN No.<font color="red">*</font>
                        </td>
                        <td valign="top">
                            <asp:Repeater ID="RptrCN2" runat="server">
                                <ItemTemplate>
                                    <a class='<%#Eval("classReturnMDC")%>' title="click to get record" href='<%#"javascript:setVal("+Eval("CNNo")+")" %>'>
                                        <%#Eval("CNNo")%>
                                    </a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </asp:Panel>
                </tr>
            </table>
            <table width="100%" height="auto" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100px" style="display: none">
                        <asp:Label ID="Label1" runat="server" Text="CNNo."></asp:Label>
                    </td>
                    <td width="100px" style="display: none">
                        <asp:TextBox ID="txtCnno" CssClass="inp-form" Width="80px" runat="server"></asp:TextBox>
                    </td>
                    <td width="100px" style="display: none">
                        <asp:RequiredFieldValidator ID="reqcn02" runat="server" ErrorMessage="Require CN No."
                            ValidationGroup="Editcn" ControlToValidate="txtCnno">*</asp:RequiredFieldValidator>
                    </td>
                    <td width="100px">
                        <asp:Button ID="btnget" OnClick="btnget_Click" CssClass="submitbtn" runat="server"
                            Style="display: none" Width="70px" Text="Get" ValidationGroup="Editcn" TabIndex="6" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <p>
        </p>
        <asp:Panel ID="PnlAddbk" runat="server" Width="1003px">
            <table border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;">
                <tr>
                    <td width="60px">
                        <asp:Label ID="label3" runat="server" CssClass="lbl-form" Text="CN No :" Width="60px"></asp:Label>
                    </td>
                    <td width="150">
                        <asp:Label ID="lblviewCNNo" runat="server" CssClass="lbl-form" Width="40px" Font-Bold="True"></asp:Label>
                    </td>
                    <td width="130px">
                        <asp:Label ID="Label9" runat="server" CssClass="lbl-form" Width="40px" Text="GCN"></asp:Label>
                        <asp:TextBox ID="txtGCN" runat="server" onkeypress="return CheckNumeric(event)" CssClass="inp-form"
                            Width="80px" ToolTip="GCN No"></asp:TextBox>
                    </td>
                    <td width="130px">
                        <asp:Label ID="Label10" runat="server" CssClass="lbl-form" Width="40px" Text="SCN"></asp:Label>
                        <asp:TextBox ID="txtSCN" runat="server" onkeypress="return CheckNumeric(event)" CssClass="inp-form"
                            Width="80px"></asp:TextBox>
                        <%--<ajaxCt:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers"
                    TargetControlID="txtSCN" ValidChars="." />--%>
                    </td>
                    <td width="130px">
                        <asp:Label ID="Label13" runat="server" CssClass="lbl-form" Width="50px" Text="LR No"></asp:Label>
                        <asp:TextBox ID="txtlRNO" runat="server" CssClass="inp-form" Width="80px"></asp:TextBox>
                    </td>
                    <td width="130px">
                        <asp:Label ID="Label14" runat="server" CssClass="lbl-form" Width="50px" Text="Transporter"></asp:Label>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="lbltransporter" CssClass="inp-form" Width="100px" runat="server"
                                    Enabled="true" Text="" TabIndex="1" AutoPostBack="true" OnTextChanged="lbltransporter_TextChanged"></asp:TextBox>
                                <div id="divtrasport" class="divauto">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="ACExttransporter" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="lbltransporter"
                                    UseContextKey="true" ContextKey="transporter" CompletionListElementID="divtrasport">
                                </ajaxCt:AutoCompleteExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" width="130px">
                        <asp:Label ID="Label19" runat="server" CssClass="lbl-form" Text="IsExcise"></asp:Label>
                        <asp:CheckBox runat="server" ID="ISExcise" />
                        <asp:Label ID="lbledit" runat="server" CssClass="lbl-form" Width="40px" Style="display: none"></asp:Label>
                        <asp:Label ID="lblflagdc" runat="server" Style="display: none"></asp:Label>
                    </td>
                    <td align="right" width="90px">
                        <asp:Button ID="btn_Save" runat="server" CssClass="submitbtn" OnClick="btn_Save_Click"
                            Style="float: right;" TabIndex="14" Text="Update CN" ValidationGroup="S" Width="80px"
                            BorderWidth="2px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="Customer :" Width="60px"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:Label ID="lblCustN" runat="server" CssClass="lbl-form" Width="700px" Font-Bold></asp:Label>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;">
                <tr>
                    <td width="60px">
                        <asp:Label ID="Label7" runat="server" CssClass="lbl-form" Text="CN Date" Width="60px"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCNDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                    Enabled="true" AutoPostBack="True"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtCNDate"
                                    Format="dd/MM/yyyy" />
                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtCNDate"
                                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                    AutoComplete="true" CultureName="en-US" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require CN Date"
                                    ValidationGroup="S" ControlToValidate="txtCNDate">.</asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td width="20px">
                    </td>
                    <td width="60px">
                        <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Customer :" Width="60px"></asp:Label>
                    </td>
                    <td width="80px">
                        <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                            Width="80px" CssClass="inp-form" TabIndex="3" runat="server" OnTextChanged="txtcustomer_TextChanged"
                            AutoPostBack="True" ></asp:TextBox>
                        <div id="dvcust" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                            UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                    </td>
                    <td width="600px">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblCustName" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"
                                    Width="600px"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="PnlAddBook" runat="server" DefaultButton="btnaddBooks">
                <table>
                    <tr>
                        <td valign="top">
                            &nbsp;
                            <asp:Label ID="Label15" runat="server" Text="Std."></asp:Label>
                        </td>
                        <td valign="top">
                            &nbsp;
                            <asp:Label ID="Label16" runat="server" Text="Book"></asp:Label>
                        </td>
                        <td valign="top">
                            &nbsp;
                            <asp:Label ID="Label17" runat="server" Text="Qty."></asp:Label>
                        </td>
                        <td valign="top">
                            &nbsp;
                            <asp:Label ID="Label18" runat="server" Text="Comment"></asp:Label>
                        </td>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:DropDownList ID="DDLstandard" runat="server" AutoPostBack="true" CssClass="ddl-form"
                                DataTextField="Value" DataValueField="AutoId" OnSelectedIndexChanged="DDLstandard_SelectedIndexChanged"
                                TabIndex="4">
                            </asp:DropDownList>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtbkcod" runat="server" autocomplete="off" CssClass="inp-form"
                                onblur="setfocus('');" onfocus="setfocus('book');" TabIndex="5" Width="240px"></asp:TextBox>
                            <%--OnTextChanged="txtbkcod_TextChanged"--%>
                            <div id="divwidth" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender123" runat="server" CompletionInterval="100"
                                CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="book"
                                DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                                ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtbkcod"
                                UseContextKey="true">
                            </ajaxCt:AutoCompleteExtender>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txRetqty" runat="server" AutoComplete="off" CssClass="inp-form"
                                MaxLength="7" onkeypress="return CheckNumeric(event)" Style="text-align: right;"
                                TabIndex="6" ToolTip="Return Qty" Width="35px"></asp:TextBox>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtComment" runat="server" CssClass="inp-form" Height="15px" TabIndex="7"
                                TextMode="MultiLine" ToolTip="Return Qty" Width="200px"></asp:TextBox>
                        </td>
                        <td valign="top">
                            <asp:Button ID="btnaddBooks" runat="server" CssClass="submitbtn" OnClick="btnaddBooks_Click"
                                TabIndex="8" Text="Add" ValidationGroup="Date" Width="70px" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <p>
            </p>
            <asp:GridView ID="grdBookDetails" runat="server" AlternatingRowStyle-CssClass="alt"
                AutoGenerateColumns="False" TabIndex="21" CssClass="product-table" Width="1000px"
                OnRowDataBound="grdBookDetails_RowDataBound" OnRowDeleting="grdBookDetails_RowDeleting"
                ShowFooter="false" OnRowEditing="grdBookDetails_RowEditing" OnRowCreated="grdBookDetails_RowCreated">
                <Columns>
                    <asp:TemplateField HeaderText="Check" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkBxSelect" runat="server" TabIndex="7"></asp:CheckBox>
                        </ItemTemplate>
                        <HeaderStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="70px" HeaderText="Book Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDAutoID" runat="server" Style="display: none;" Text='<%#Eval("AutoID")%>'></asp:Label>
                            <asp:Label ID="lblBookCode" runat="server" Width="70px" Text='<%#Eval("BookCode")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Book Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtBookName" runat="server" Width="300px" Autocomplete="off" Text='<%#Eval("BookName")%>'
                                AutoPostBack="True" OnTextChanged="txtBookName_TextChanged" TabIndex="8"></asp:TextBox>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtBookName"
                                UseContextKey="true" ContextKey="book">
                            </ajaxCt:AutoCompleteExtender>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="90px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-Width="20px" HeaderText="Return Qty"
                        ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:TextBox ID="txtretquty" runat="server" MaxLength="6" TabIndex="9" onkeypress="return CheckNumeric(event)"
                                Style="text-align: right;" Text='<%#Eval("TotReturnQty")%>' Width="40px" AutoPostBack="True"
                                OnTextChanged="txtretquty_TextChanged"></asp:TextBox>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotalretqty" runat="server" CssClass="totalrtQty" Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-Width="20px" HeaderText="Defect Qty"
                        ItemStyle-HorizontalAlign="right" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox ID="txtdefquty" runat="server" MaxLength="6" onkeypress="return CheckNumeric(event)"
                                Style="text-align: right;" Text='<%#Eval("DefectQty")%>' Width="40px" Enabled="false"></asp:TextBox>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotaldefqty" runat="server" CssClass="totaldfQty" Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-Width="20px" HeaderText="CN Qty"
                        ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:TextBox ID="txtquty" runat="server" MaxLength="6" TabIndex="10" onkeypress="return CheckNumeric(event)"
                                Style="text-align: right;" Text='<%#Eval("ReturnQty")%>' Width="40px" AutoPostBack="True"
                                OnTextChanged="txtquty_TextChanged"></asp:TextBox>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotalqty" runat="server" CssClass="totalQty" Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"
                        HeaderText="Rate" ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:TextBox ID="txtrate" runat="server" MaxLength="6" TabIndex="11" onkeypress="return CheckNumericWithDot(event)"
                                Style="text-align: right;" Text='<%#Eval("Rate","{0:0.00}")%>' Width="50px"></asp:TextBox>
                            <asp:Label ID="lblRate" runat="server" Style="text-align: right; display: none" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="20px" HeaderText="Dis.(%)" ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDiscount" runat="server" onkeydown="setAmtclass(this)" onkeypress="return CheckNumericWithDot(event)"
                                Style="text-align: right;" TabIndex="12" Text='<%#Eval("Discount","{0:0.00}")%>'
                                Width="40px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"
                        Visible="false" HeaderStyle-Width="80px" HeaderText="Amount" ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lblAmt" runat="server" Style="text-align: right;" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                            <%--<asp:Label ID="txtAddDiscount" runat="server" Style="text-align: right; display: none;"
                                Text='<%#Eval("AdditionalDiscount")%>' Width="20px"></asp:Label>--%>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotalamt" runat="server" CssClass="totalAmt" Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment" HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtcmmt" CssClass="inp-form" TabIndex="13" Width="100px" Height="20px"
                                runat="server" TextMode="MultiLine" Text='<%#Eval("Comment")%>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="80px"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Return Type" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Left"
                        Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblflag" runat="server" Text='<%#Eval("Flag")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IsDeleted" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center"
                        Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblIsDeleted" runat="server" Text='<%#Eval("IsDeleted")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Save" ItemStyle-HorizontalAlign="Center"
                        Visible="false">
                        <ItemTemplate>
                            <asp:Button ID="btnSave" CssClass="submitbtn" runat="server" Text="Save" Width="80px"
                                CommandName="edit" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Remove" ItemStyle-HorizontalAlign="Center"
                        Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnRemove" runat="server" CommandName="delete" ImageUrl="~/Images/icon/DeleteIcon.gif"
                                OnClientClick="return confirm('Are you sure want to remove this book');" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="alt" />
            </asp:GridView>
            <asp:Label ID="lblTotalqtyId" Style="display: none;" runat="server" CssClass="inp-form"></asp:Label>
            <asp:Label ID="lblTotalamtId" Style="display: none;" runat="server" CssClass="inp-form"></asp:Label>
        </asp:Panel>
        <p>
        </p>
        <p>
        </p>
        <asp:Panel ID="PnlPrint" runat="server" Width="900px">
            <%--<div class="actiontab">--%>
            <table width="900px" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        <asp:Label ID="labelCNNo" runat="server" CssClass="lbl-form" Text="CN No :" Width="110px"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCNNo" runat="server" CssClass="lbl-form" Width="30px" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="Customer Name :"
                            Width="110px"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCustName1" runat="server" CssClass="lbl-form" Width="500px" Font-Bold></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="Customer Address :"
                            Width="110px"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCustAddress" runat="server" CssClass="lbl-form" Width="800px" Font-Bold></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnPrint" CssClass="submitbtn" TabIndex="15" runat="server" Text="Print"
                            Width="80px" OnClick="btnPrint_Click" ValidationGroup="DCRB" />
                    </td>
                </tr>
            </table>
            <%--</div>--%>
            <p>
            </p>
            <asp:GridView ID="grdcn" CssClass="product-table" AutoGenerateColumns="false" ShowFooter="true"
                runat="server" Width="1000px" CellPadding="2" OnRowDataBound="grdcn_RowDataBound">
                <Columns>
                    <%--<asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" >
        <ItemTemplate>
            <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
        </ItemTemplate>
       </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="PARTICULARS" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="450px">
                        <ItemTemplate>
                            <asp:Label ID="lblbkname" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotal" Style="text-align: right; font-weight: bold;" runat="server"
                                Text="Total: "></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QTY" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblqty" runat="server" Text='<%#Eval("ReturnQty")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltqty" Style="text-align: right; font-weight: bold;" runat="server"
                                Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="MEDIUM" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
            </ItemTemplate>
           </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="PRICE" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                        HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DISCOUNT(%)" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'
                                HeaderStyle-HorizontalAlign="Left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AMOUNT" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblamt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltamt" Style="text-align: right; font-weight: bold;" runat="server"
                                Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NET AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"
                        HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblnamt" Style="text-align: right;" runat="server" Text='<%#Eval("NetAmount","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltnamt" Style="text-align: right; font-weight: bold;" runat="server"
                                Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<script>
    function setVal(id) {
        document.getElementById("ctl00_ContentPlaceHolder1_uc_DC_EditCN1_txtCnno").value = id;
        document.getElementById("ctl00_ContentPlaceHolder1_uc_DC_EditCN1_btnget").click();
    }
</script>

<script type="text/javascript">
    var TotalChkBx;
    var Counter;

    window.onload = function() {
        //Get total no. of CheckBoxes in side the GridView.
        TotalChkBx = parseInt('<%= this.grdBookDetails.Rows.Count %>');

        //Get total no. of checked CheckBoxes in side the GridView.
        Counter = 0;
    }

    function HeaderClick(CheckBox) {
        //Get target base & child control.
        var TargetBaseControl =
       document.getElementById('<%= this.grdBookDetails.ClientID %>');
        var TargetChildControl = "chkBxSelect";

        //Get all the control of the type INPUT in the base control.
        var Inputs = TargetBaseControl.getElementsByTagName("input");

        //Checked/Unchecked all the checkBoxes in side the GridView.
        for (var n = 0; n < Inputs.length; ++n)
            if (Inputs[n].type == 'checkbox' &&
                Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
            Inputs[n].checked = CheckBox.checked;

        //Reset Counter
        Counter = CheckBox.checked ? TotalChkBx : 0;
    }

    function ChildClick(CheckBox, HCheckBox) {
        //get target control.
        var HeaderCheckBox = document.getElementById(HCheckBox);

        //Modifiy Counter; 
        if (CheckBox.checked && Counter < TotalChkBx)
            Counter++;
        else if (Counter > 0)
            Counter--;

        //Change state of the header CheckBox.
        if (Counter < TotalChkBx)
            HeaderCheckBox.checked = false;
        else if (Counter == TotalChkBx)
            HeaderCheckBox.checked = true;
    }
</script>

