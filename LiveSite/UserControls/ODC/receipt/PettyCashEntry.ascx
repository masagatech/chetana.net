<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PettyCashEntry.ascx.cs"
    Inherits="UserControls_ODC_receipt_PettyCash_PettyCashEntry" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Petty Cash Entry<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<div style="float: right; width: 53%">
    <asp:Button ID="btn_Save" CssClass="submitbtn" ValidationGroup="Discount" TabIndex="9"
        runat="server" Text="Save" Width="87px" OnClick="btn_Save_Click" />
</div>
<br />
<br />
<asp:Label ID="lblId3" runat="server" BackColor="Yellow"></asp:Label>
<asp:Panel ID="pnlCust" CssClass="panelDetails" runat="server" Width="638px" Height="258px">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100px">
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="lblID1" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="lblPartyName" runat="server" CssClass="lbl-form" Text="Party Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEMcode" autocomplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="1" runat="server" AutoPostBack="true" Height="15px" OnTextChanged="txtEMcode_TextChanged"></asp:TextBox>
                        <div id="dvcust" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtEMcode"
                            UseContextKey="true" ContextKey="Account" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="rfvcust" runat="server" ErrorMessage="Require Party Name"
                            ValidationGroup="Discount" ControlToValidate="txtEMcode">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblshow" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblRemark" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRemark" AutoComplete="off" TextMode="MultiLine" Width="150px"
                    CssClass="inp-form" TabIndex="2" runat="server" Height="100px">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDate11" runat="server" CssClass="lbl-form" Text="Voucher Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtVocDate" AutoComplete="off" Width="150px" CssClass="inp-form"
                    TabIndex="3" runat="server" Height="15px">
                </asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                    TargetControlID="txtVocDate" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Require vouc.Date"
                    ValidationGroup="Discount" ControlToValidate="txtVocDate">.</asp:RequiredFieldValidator>
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtVocDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblExpanceName" runat="server" CssClass="lbl-form" Text="Expence Name"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lbldate" runat="server" CssClass="lbl-form" Text="Date"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblAmount" runat="server" CssClass="lbl-form" Text="Amount"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblRemarks" Style="display: none" runat="server" CssClass="lbl-form"
                                Text="Expence Remark"></asp:Label>
                        </td>
                    </tr>
                    <asp:Panel ID="pnlenter" runat="server" DefaultButton="btnAdd" Height="16px" Width="263px">
                        <tr>
                            <td valign="top">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtExpance" runat="server" autocomplete="off" AutoPostBack="true"
                                            CssClass="inp-form" Height="15px" OnTextChanged="txtExpance_TextChanged" TabIndex="4"
                                            Width="150px"></asp:TextBox>
                                        <div id="dvcust" class="divauto">
                                        </div>
                                        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                                            CompletionListCssClass="AutoExtender" CompletionListElementID="dvcust" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="10" ContextKey="OTHERSEXPENSES"
                                            DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                                            ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtExpance"
                                            UseContextKey="true">
                                        </ajaxCt:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtExpance"
                                            ErrorMessage="Require Expance Name" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                                        <br />
                                        <asp:Label ID="lblShowExp" runat="server" Width="155px" CssClass="lbl-form" Font-Size="15px"
                                            ForeColor="Blue"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtDate" Width="150px" CssClass="inp-form" TabIndex="5" Height="15px"
                                    runat="server">
                                </asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtDate" />
                                <%-- <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                    AcceptAMPM="true" AutoComplete="true" CultureName="en-US" Mask="99/99/9999" 
                    MaskType="Date" MessageValidatorTip="false" TargetControlID="txtChequeDate" />--%>
                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDate"
                                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                    AutoComplete="true" CultureName="en-US" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate"
                                    ErrorMessage="Enter Date" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtAmount" runat="server" CssClass="inp-form" Height="15px" onkeypress="return CheckNumericWithDot(event)"
                                    TabIndex="6" Width="150px">
                                </asp:TextBox>
                            </td>
                            <td>
                                &nbsp; &nbsp;
                            </td>
                            <td valign="top" width="100px">
                                <asp:Button ID="btnAdd" CssClass="submitbtn" ValidationGroup="ct" runat="server"
                                    Text="Add" TabIndex="8" Width="80px" OnClick="btnAdd_Click" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAmount"
                                    ErrorMessage="Require Amount" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtRemarks" Style="display: none" runat="server" CssClass="inp-form"
                                    Height="15px" TabIndex="7" Width="150px">
                                </asp:TextBox>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>

<script type="text/javascript">  
 function LabelHide() 
 {   
  document.getElementById('<%= lblId3.ClientID %>').style.display = "none";   
 }   
        setTimeout("LabelHide();", 3000);   
</script>

<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Discount"
    runat="server" ID="ValidationSummary2" />
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="ct"
    runat="server" ID="ValidationSummary1" />
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="ct1"
    runat="server" ID="ValidationSummary3" />
<br />
<asp:Panel ID="pnlExpencse" runat="server">
    <asp:GridView ID="gvExpense" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
        ShowFooter="true" CellPadding="4" CssClass="product-table" ForeColor="#333333"
        Width="100px" PageSize="100" OnRowDataBound="gvExpense_RowDataBound" OnRowDeleting="gvExpense_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Expense Head" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="left">
                <ItemTemplate>
                    <asp:Label ID="lblExpenseHead" runat="server" Style="display: none" Text='<%#Eval("ExpenseCode") %>'></asp:Label>
                    <asp:Label ID="lblExpenseValuesave" Width="300px" runat="server" Text='<%#Eval("ExpenceName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lbldatesave" Width="125px" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Right"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblAmountsave" Width="130px" runat="server" Text='<%#Eval("Amount","{0:0.00}") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbltotalAmount" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Expence Remark" ItemStyle-HorizontalAlign="left">
                <ItemTemplate>
                    <asp:Label ID="lblRemarksave" Width="160px" runat="server" Text='<%#Eval("Remark") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblDeleteExp" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ToolTip="Remove" ImageUrl="../../../Images/icon/DeleteIcon.gif"
                        OnClientClick="return confirm('Do You really want to Delete?')" />
                    <%--<asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CssClass="close" 
                        ImageUrl="../../Images/icon/save_as.png" CommandName="Edit" />--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Panel ID="pnlViewexp" CssClass="panelDetails" Width="540px" runat="server">
        <table>
            <tr>
                <td>
                    <font color="red">*</font>
                    <asp:TextBox ID="txtFromDate" Width="150px" CssClass="inp-form" TabIndex="4" Height="15px"
                        runat="server">
                    </asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtFromDate" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtFromDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtFromDate"
                        WatermarkText="From Date">
                    </ajaxCt:TextBoxWatermarkExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFromDate"
                        ErrorMessage="Enter From Date" ValidationGroup="ct1">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <font color="red">*</font>
                    <asp:TextBox ID="txtToDate" Width="150px" CssClass="inp-form" TabIndex="5" Height="15px"
                        runat="server">
                    </asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtToDate" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtToDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtToDate"
                        WatermarkText="To Date">
                    </ajaxCt:TextBoxWatermarkExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtToDate"
                        ErrorMessage="Enter ToDate" ValidationGroup="ct1">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="lblget" runat="server" Text="Get Data" Width="87px" TabIndex="6"
                        ValidationGroup="ct1" CssClass="submitbtn" OnClick="lblget_Click" />
                </td>
                <td>
                    <asp:Button ID="btnPrint" Visible="true" runat="server" TabIndex="7" Text="Print"
                        Style="float: right;" Width="50px" CssClass="submitbtn" ToolTip="click to print"
                        OnClick="btnPrint_Click" ValidationGroup="ct1" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="gvVoucher" CssClass="product-table" runat="server" AutoGenerateColumns="false"
        CaptionAlign="Bottom" CellPadding="4" ForeColor="#333333" Width="250px" PageSize="100">
        <Columns>
            <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="left">
                <ItemTemplate>
                    <asp:Label ID="lblCreated_By" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEDate" runat="server" Text='<%#Eval("Date") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Voucher No" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblVoucherNo" runat="server" Text='<%#Eval("VoucherNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Expence Name" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblPartyName" Width="300px" runat="server" Text='<%#Eval("ExpenceName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEexp" runat="server" Text='<%#Eval("ExpenceName") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Expence Amount" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("Amount","{0:0.00}") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEamount" runat="server" Text='<%#Eval("Amount","{0:0.00}") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Created By" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Left"
            FooterStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="lbldate" Width="100px"  runat="server" Text='<%#Eval("CreatedBy") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvExp" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" ShowFooter="true"
        PageSize="100" Width="200px" OnRowEditing="gvExp_RowEditing" OnRowDataBound="gvExp_RowDataBound">
        <Columns>
            <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderText="Created Date"
                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="500px">
                <ItemTemplate>
                    <asp:Label ID="lblpartycode" Style="display: none" runat="server" Text='<%#Eval("PartyCode") %>'></asp:Label>
                    <asp:Label ID="lblRemarkedit" runat="server" Style="display: none" Text='<%#Eval("MainRemark") %>'></asp:Label>
                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("VoucherDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Voucher No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="500px">
                <ItemTemplate>
                    <asp:Label ID="lblVoucherNo" Style="display: none" runat="server" Text='<%#Eval("VoucherNo_Autoid") %>'></asp:Label> 
                    <asp:Label ID="lblVoucherNoNew" runat="server" Text='<%#Eval("VoucherNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Party Name" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="500px">
                <ItemTemplate>
                    <asp:Label ID="lblPartyName" runat="server" Text='<%#Eval("PartyName") %>' Width="300px"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="500px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount","{0:0.00}") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbltotalAmount2" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <%--  <asp:TemplateField HeaderText="Created By" ItemStyle-HorizontalAlign="left">
                <ItemTemplate>
                    <asp:Label ID="lblCreated_By" runat="server" Text='<%#Eval("Created_By") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                HeaderText="View" ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <asp:LinkButton ID="viewexp" runat="server" CommandArgument='<%#Eval("VoucherNo_Autoid") %>'
                        Text="View" OnClick="viewexp_Click"></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                HeaderText="Edit" ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" CssClass="close" runat="server" CausesValidation="false"
                        CommandName="Edit" ToolTip="Edit" ImageUrl="../../../Images/icon/edit_icon.png" />&nbsp;&nbsp;
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                HeaderText="Delete" ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <asp:ImageButton ID="btnDelete" CssClass="close" runat="server" CausesValidation="false"
                         OnClick="btnDelete_Click" ImageUrl="../../../Images/icon/DeleteIcon.gif"
                        OnClientClick="return confirm('Do You really want to Delete?')" ToolTip="Delete" />&nbsp;&nbsp;
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvExpDelete" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" OnRowDataBound="gvExpDelete_RowDataBound"
        OnRowDeleting="gvExpDelete_RowDeleting" PageSize="100" ShowFooter="true" Width="100px">
        <Columns>
            <asp:TemplateField HeaderText="Expence Name" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="500px">
                <ItemTemplate>
                    <asp:Label ID="lblvoucher_detail" runat="server" Style="display: none" Text='<%#Eval("Voucher_Detail") %>'></asp:Label>
                    <asp:Label ID="lblVoucherNo" runat="server" Style="display: none" Text='<%#Eval("VoucherNo") %>'
                        Width="300px"></asp:Label>
                    <asp:Label ID="lblExpName" runat="server" Text='<%#Eval("ExpenceName") %>' Width="125px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="500px">
                <ItemTemplate>
                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>' Width="125px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderText="Amount" ItemStyle-HorizontalAlign="Right"
                ItemStyle-Width="500px">
                <ItemTemplate>
                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount","{0:0.00}") %>' Width="130px"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbltotalAmount" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Expence Remark" ItemStyle-HorizontalAlign="left">
                <ItemTemplate>
                    <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark") %>' Width="160px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                HeaderText="Action" ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblDeleteExp" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../../../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do You really want to Delete?')"
                        ToolTip="Remove" />
                    <%--<asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CssClass="close" 
                        ImageUrl="../../Images/icon/save_as.png" CommandName="Edit" />--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<br />

<script type="text/javascript">
     //setTimeout("setSatus()",2000);
   function setSatus()
   {
   //var status="[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
   //document.getElementById('status').innerHTML=status;
   }
</script>

<script type="text/javascript">
      
shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_PettyCashEntry1_btn_Save').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>

