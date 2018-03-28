<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_editSpcInvoice.ascx.cs"
    Inherits="UserControls_uc_editSpcInvoice" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Print Invoice<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<asp:Panel ID="Panel2" CssClass="panelDetails" runat="server">
    <table>
        <asp:RadioButtonList ID="RdlView" runat="server" RepeatDirection="Horizontal" CssClass="lbl-form"
            Width="300px" OnSelectedIndexChanged="RdlView_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="Date" Text="  Date Wise"></asp:ListItem>
            <asp:ListItem Value="Employee" Text="  Employee Wise"></asp:ListItem>
            <asp:ListItem Value="All" Text="  All "></asp:ListItem>
        </asp:RadioButtonList>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="Pnlcust" CssClass="panelDetails" runat="server" Visible="false">
    <%--    <asp:UpdatePanel ID="Upanelcust" UpdateMode="Conditional" runat="server">
        <ContentTemplate>--%>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="M.R. Code" CssClass="lbl-form"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="DDLEmployee" DataTextField="Name" DataValueField="EmpID"
                    runat="server" Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
                    InitialValue="0" ValidationGroup="DDlcust" ControlToValidate="DDLEmployee">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnemployee" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="DDlcust"
                    Width="50px" OnClick="btnemployee_Click" />
            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Panel>
<asp:Panel ID="pnlDate" CssClass="panelDetails" runat="server" Visible="false">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtFromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="Rqffdate" runat="server" ErrorMessage="Require From Date"
                            InitialValue="none" ValidationGroup="DDlDeldate" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                            color="red">*</font> &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttoDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require To Date"
                            InitialValue="0" ValidationGroup="DDlDelDate" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnfind" runat="server" TabIndex="3" Text="Get" CssClass="submitbtn"
                            ValidationGroup="DDlDelDate" Width="50px" OnClick="btnfind_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<br />
<div style="padding-bottom: 50px">
    <table width="90%">
        <tr>
            <td width="70%">
                <%--   <asp:UpdatePanel ID="updateapprove" UpdateMode="Conditional" runat="server">
                <ContentTemplate>--%>
                <asp:Panel ID="Panel1" CssClass="panelDetails" Height="80px" ScrollBars="Vertical"
                    runat="server">
                    <table width="100%" height="auto" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                <asp:Repeater ID="Rptrpending" runat="server">
                                    <ItemTemplate>
                                        <a class="nav_bar_link" title="click to get record" href='<%#"javascript:setVal("+Eval("DocumentNo")+")" %>'>
                                            <%#Eval("DocumentNo")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                    <div width="100px" style="display: none">
                        <asp:Label ID="Label1" runat="server" Text="Document No."></asp:Label>
                        <font color="red">*</font>
                        <asp:TextBox ID="txtDocno" CssClass="inp-form" Width="80px" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqdocno" runat="server" ErrorMessage="Require Document No."
                            ValidationGroup="App" ControlToValidate="txtDocno">*</asp:RequiredFieldValidator>
                        <asp:Button ID="btnget" OnClick="btnget_Click" CssClass="form-submit" runat="server"
                            Width="70px" Text="Get" />
                    </div>
                </asp:Panel>
                <br />
                <asp:Panel ID="pnlDetails" Visible="false" runat="server">
                    <%--  <asp:UpdatePanel ID="upDocNo" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>--%>
                    <table>
                        <tr>
                            <td width="110px">
                                <span>Document No :
                                    <label id="docno" style="font-size: 12px; font-weight: bold" runat="server">
                                    </label>
                                </span>
                            </td>
                            <td>
                                <span>MR Name :
                                    <label id="lblempname1" style="font-size: 12px; font-weight: bold" runat="server">
                                    </label>
                                </span>
                            </td>
                        </tr>
                    </table>
                    <asp:Repeater ID="RepDetailsConfirm" runat="server" OnItemDataBound="RepDetailsConfirm_ItemDataBound"
                        OnItemCommand="RepDetailsConfirm_ItemCommand">
                        <ItemTemplate>
                            <div class="actiontab">
                                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                    <tr>
                                        <td valign="bottom">
                                            <span>Invoice No :
                                                <asp:Label ID="SubConfirmID" Style="font-weight: bold; font-size: 13px;" runat="server"
                                                    Text='<%#Eval("SubConfirmID")%>'></asp:Label></span>
                                        </td>
                                        <%--<td align="right">
                                            <asp:Button ID="btnConfirmed" CommandArgument='<%#Eval("SubConfirmID")%>' OnClick="btnapproval_Click"
                                                runat="server" Text="Create Invoice" CssClass="submitbtn" Width="110px" Style="float: right;" />
                                        </td>--%>
                                    </tr>
                                </table>
                            </div>
                            <asp:UpdatePanel ID="upUpdate" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdapproval" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                                        ShowFooter="true" AutoGenerateColumns="false" runat="server" OnRowDataBound="grdapproval_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label Style="display: none;" ID="lblCQt" runat="server" Text='<%#Eval("ConfirmDcQtyId")%>'></asp:Label>
                                                    <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                                    <asp:Label ID="lblspecidatils" Style="display: none;" runat="server" Text='<%#Eval("SpecimenDetailID")%>'></asp:Label>
                                                    <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Book Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbookN" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Qty" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqunty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblT" runat="server" Text="Total"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblqunty" Style="text-align: right; display: none;" runat="server"
                                                        Text='<%#Eval("Quantity")%>'></asp:Label>
                                                    <asp:Label ID="lblAvailblQtyOrg" Style="text-align: right; display: none;" Width="50px"
                                                        runat="server" Text='<%#Eval("AvailableQty")%>'></asp:Label>
                                                    <asp:TextBox ID="lblAqty" Style="text-align: right;" Width="50px" runat="server"
                                                        Text='<%#Eval("AvailableQty")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalqty" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblrateOrg" runat="server" Width="50px" Style="text-align: right;
                                                        display: none;" Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                                    <asp:TextBox ID="lblrate" runat="server" Width="50px" Style="text-align: right;"
                                                        Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:TextBox>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamt" runat="server" Text='<%#Eval("RevisedAmt","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalAmt" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnRemove" ImageUrl="~/Images/icon/DeleteIcon.gif" CommandArgument='<%#Eval("ConfirmDcQtyId")%>'
                                                        OnClientClick="return confirm('Are you sure want to remove this book');" OnClick="btnRemove_Click"
                                                        runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle Width="50px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <table width="100%">
                                <tr>
                                    <td valign="bottom">
                                        <asp:Label ID="Label2" Style="font-size: 12px; font-weight: bold" runat="server"
                                            Text="  Transporter  "></asp:Label>
                                    </td>
                                    <td valign="bottom">
                                        <asp:Label ID="Label3" Style="font-size: 12px; font-weight: bold" runat="server"
                                            Text="  LR No.  "></asp:Label>
                                    </td>
                                    <td valign="bottom">
                                        <asp:Label ID="Label4" Style="font-size: 12px; font-weight: bold" runat="server"
                                            Text="  Bundles  "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" Style="font-size: 12px; font-weight: bold" runat="server"
                                            Text=" Date  "></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtTransporter" CssClass="inp-form" Width="200px" runat="server"
                                                    Enabled="true" Text="" AutoPostBack="true" OnTextChanged="lbltransporter_TextChanged"></asp:TextBox>
                                                <ajaxCt:AutoCompleteExtender ID="ACExttransporter" runat="server" DelimiterCharacters=""
                                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtTransporter"
                                                    UseContextKey="true" ContextKey="transporter" CompletionListElementID="divtrasport">
                                                </ajaxCt:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div id="divtrasport" class="divauto">
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtlrno" CssClass="inp-form" Width="80px" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbundles" CssClass="inp-form" Width="80px" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdateabc" CssClass="inp-form" Width="100px" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender Animated="true" PopupPosition="Right" ID="CalendarExtender3"
                                            runat="server" TargetControlID="txtdateabc" Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" TargetControlID="txtdateabc"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-US" />
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="updateapprove1" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnConfirmed" CommandArgument='<%#Eval("SubConfirmID")%>' runat="server"
                                                    Text="Update Invoice" CssClass="submitbtn" Width="110px" Style="float: right;" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--  </ContentTemplate>
                        </asp:UpdatePanel>--%>
                </asp:Panel>
                <%--   </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td>
            <td width="20%" valign="top">
            </td>
        </tr>
    </table>
</div>

<script>
         function setVal(id)
         {
         document.getElementById('<%= txtDocno.ClientID%>').value = id;
         document.getElementById('<%= btnget.ClientID%>').click();
         }
</script>

