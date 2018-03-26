<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChequeCashDepositDelete.ascx.cs"
    Inherits="UserControls_ODC_receipt_ChequeCashDepositDelete" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<style type="text/css">
    .style1
    {
        height: 57px;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Payment Receipt Delete<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<div style="float: right; width: 53%">
    <asp:Button ID="btn_Save" CssClass="submitbtn" ValidationGroup="Discount" TabIndex="9"
        runat="server" Text="Save" Width="87px" OnClick="btn_Save_Click" />
</div>
<br />
<br />
<asp:Label ID="lblIsEditable" runat="server" Text="This Record is locked for any further editing."
    CssClass="lbl-form" Visible="false" />
<asp:Label ID="lblId3" runat="server" BackColor="Yellow"></asp:Label>
<asp:Panel ID="pnlCust" CssClass="panelDetails" runat="server" Width="570px" Height="300px">
    <table cellpadding="0" cellspacing="0">
        <%--<asp:Panel ID="PnlCustDiscDetails" runat="server">--%>
        <tr>
            <td>
                <asp:Label ID="lblReciptno" runat="server" CssClass="lbl-form" Text="ReceiptNo"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtReciptNo" AutoComplete="off" onkeypress="return CheckNumeric(event)"
                    Width="150px" AutoPostBack="true" CssClass="inp-form" TabIndex="2" runat="server"
                    OnTextChanged="txtReciptNo_TextChanged" Height="15px">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter ReceiptNo"
                    ValidationGroup="Discount" ControlToValidate="txtReciptNo">.</asp:RequiredFieldValidator>
                <asp:Label ID="lblempname" runat="server" CssClass="lbl-form" Font-Size="15px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="Employee"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEMcode" autocomplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="1" runat="server" AutoPostBack="true" OnTextChanged="txtEMcode_TextChanged"
                            Height="15px"></asp:TextBox>
                        <div id="dvcust" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtEMcode"
                            UseContextKey="true" ContextKey="salesman" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="rfvcust" runat="server" ErrorMessage="Require Employee"
                            ValidationGroup="Discount" ControlToValidate="txtEMcode">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblshow" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:RadioButtonList ID="Cheque" runat="server" Visible="true" RepeatDirection="Horizontal"
                    AutoPostBack="True" OnSelectedIndexChanged="Cheque_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="Cheque" Text="Cheque"></asp:ListItem>
                    <asp:ListItem Value="Cash" Text="Cash"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <%--</table>
</asp:Panel>--%>
        <caption>
            <br />
            <br />
            <%--<asp:Panel ID="PnlCustDiscDetails" runat="server" CssClass="panelDetails" Width="700px">--%>
            <%-- <table cellpadding="0" cellspacing="0">--%>
            <tr>
                <td width="128px">
                    <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Customer"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtcustomerid" runat="server" AutoPostBack="true" CssClass="inp-form"
                                Height="15px" OnTextChanged="txtcustomer_TextChanged" TabIndex="3" Width="150px"></asp:TextBox>
                            <div id="divclient" class="divauto" style="display: none">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="100"
                                CompletionListCssClass="AutoExtender" CompletionListElementID="divclient" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="customer"
                                DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                                ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtcustomerid"
                                UseContextKey="true">
                            </ajaxCt:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcustomerid"
                                ErrorMessage="Enter Client" ValidationGroup="Discount">.</asp:RequiredFieldValidator>
                            <asp:Label ID="lblCustName" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <asp:Panel ID="pnlCheque" runat="server">
                <tr>
                    <td width="128px">
                        <asp:Label ID="Label5" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="lblbankcode" runat="server" CssClass="lbl-form" Text="Bank"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBankName" runat="server" autocomplete="off" AutoPostBack="false"
                            CssClass="inp-form" Height="15px" TabIndex="4" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="128px">
                        <asp:Label ID="lblCheck" runat="server" CssClass="lbl-form" Text="ChequeNo"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCheck" runat="server" CssClass="inp-form" Height="15px" MaxLength="15"
                            onkeypress="return CheckNumeric(event)" TabIndex="5" Width="150px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCheck"
                            ErrorMessage="ChequeNo" ValidationGroup="Discount">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </asp:Panel>
            <tr>
                <td width="128px">
                    <asp:Label ID="lbldate" runat="server" CssClass="lbl-form" Text="Cheque Date"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:TextBox ID="txtChequeDate" runat="server" CssClass="inp-form" Height="15px"
                        TabIndex="6" Width="150px">
                    </asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtChequeDate" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="true"
                        AutoComplete="true" CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                        TargetControlID="txtChequeDate" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtChequeDate"
                        ErrorMessage="Enter ChequeDate" ValidationGroup="Discount">.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="128px">
                    <asp:Label ID="lblamount" runat="server" CssClass="lbl-form" Text="Amount"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="inp-form" Height="15px" MaxLength="15"
                        onkeypress="return CheckNumericWithDot(event)" TabIndex="7" Width="150px">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAmount"
                        ErrorMessage="Enter Amount" ValidationGroup="Discount">.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="128px">
                    <asp:Label ID="lblRemark" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="inp-form" Height="30px" TabIndex="8"
                        TextMode="MultiLine" Width="150px">
                    </asp:TextBox>
                </td>
            </tr>
        </caption>
    </table>
</asp:Panel>
<asp:Panel ID="getcheque" runat="server">
    <asp:Panel ID="UpanelGrd" runat="server" CssClass="panelDetails" Width="700px" Height="18px">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td width="100px">
                    <asp:Label ID="lblmrcode" runat="server" Text="Customer Code"></asp:Label>
                    <span style="color: red">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtcheque" Width="100px" CssClass="inp-form" runat="server" TabIndex="1"
                        AutoPostBack="True" OnTextChanged="txtcheque_TextChanged" Height="15px"></asp:TextBox>
                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                        ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                        CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcheque"
                        UseContextKey="true" ContextKey="customer">
                    </ajaxCt:AutoCompleteExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter MR Code"
                        ValidationGroup="Discount4" Text="." ControlToValidate="txtcheque">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" Width="100px" CssClass="inp-form" TabIndex="2" Height="15px"
                        runat="server">
                    </asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter FromDate"
                        ValidationGroup="Discount4" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                    <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtFromDate"
                        WatermarkText="From Date">
                    </ajaxCt:TextBoxWatermarkExtender>
                </td>
                <td>
                    <asp:TextBox ID="txttoDate" Width="100px" CssClass="inp-form" TabIndex="3" Height="15px"
                        runat="server">
                    </asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttoDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtChequeDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter ToDate"
                        ValidationGroup="Discount4" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                    <ajaxCt:TextBoxWatermarkExtender ID="txtFromDate1" runat="server" TargetControlID="txttoDate"
                        WatermarkText="To Date">
                    </ajaxCt:TextBoxWatermarkExtender>
                </td>
                <td>
                    <asp:Button ID="btnGetData" CssClass="submitbtn" ValidationGroup="Discount4" TabIndex="4"
                        runat="server" Text="GetData" Width="87px" OnClick="btnGetData_Click" />
                </td>
            </tr>
            <%-- <caption>
                <br />--%>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblcheque" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <%-- </caption>--%>
        </table>
        </asp:Panel>
        <p>
        </p>
        <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
            CellPadding="4" CssClass="product-table" ForeColor="#333333" OnRowEditing="gvdetails_RowEditing"
            PageSize="100" OnRowDeleting="gvdetails_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="ChequeDate">
                    <ItemTemplate>
                        <asp:Label ID="lblcheque" runat="server" Text='<%#Eval("ChequeDate") %>' />
                        <asp:Label ID="lblremark" runat="server" Text='<%#Eval("Description") %>' Style="display: none" />
                        <asp:Label ID="isEditable" runat="server" Text='<%#Eval("isEditable") %>' Style="display: none" />
                        <asp:Label ID="lblCreated" runat="server" Text='<%#Eval("CreatedBy") %>' Style="display: none" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ChequeNo">
                    <ItemTemplate>
                        <asp:Label ID="lblid2" runat="server" Style="display: none" Text='<%#Eval("CQ_ID")%>'></asp:Label>
                        <asp:Label ID="lblempid" runat="server" Style="display: none" Text='<%#Eval("EmpID") %>'></asp:Label>
                        <asp:Label ID="lblempcode" runat="server" Style="display: none" Text='<%#Eval("EmpCode") %>'>
                        </asp:Label>
                        <asp:Label ID="lblchequeno" runat="server" Text='<%#Eval("ChequeNo") %>'></asp:Label>
                        <asp:Label ID="lblempname" Style="display: none" runat="server" Text='<%#Eval("FirstName")+" "+Eval("LastName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ReciptNo">
                    <ItemTemplate>
                        <asp:Label ID="lblreceipt" runat="server" Text='<%#Eval("ReciptNo")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer">
                    <ItemTemplate>
                        <asp:Label ID="lblcustomer" runat="server" Text='<%#Eval("CustCode")%>' Style="display: none"></asp:Label>
                        <asp:Label ID="lblcustname" runat="server" Text='<%#Eval("CustName")+" "+Eval("LastName")%>'>
                        </asp:Label>
                        <asp:Label ID="lblDepositeType" runat="server" Text='<%#Eval("Deposite_Type") %>'
                            Style="display: none;"></asp:Label>
                        <asp:Label ID="lbldeposit" runat="server" Text='<%#Eval("CustId") %>' Style="display: none;"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:TemplateField HeaderText="DepositeType">
              <ItemTemplate>
             
              </ItemTemplate>
            </asp:TemplateField>--%>
                <%--<asp:TemplateField HeaderText="DepositedBy">
              <ItemTemplate>
                <asp:Label ID="lbldepositby" runat="server" Text='<%#Eval("Deposited_By") %>'>
                </asp:Label>
              </ItemTemplate>
            </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("Amount","{0:0.00}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BankName">
                    <ItemTemplate>
                        <asp:Label ID="lblbank" runat="server" Text='<%#Eval("Payee_Bank") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="lblEdit" runat="server" Visible="false" CausesValidation="false"
                            CommandName="Edit" CssClass="close" ImageUrl="../../../Images/icon/edit_icon.png" />
                        <asp:ImageButton ID="lblView" runat="server" CausesValidation="false" CommandName="Delete"
                            CssClass="close" ImageUrl="../../../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you really want to delete this record?')" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--   <asp:GridView ID="gvshow" runat="server" AutoGenerateColumns="false" CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="100"  
                    CaptionAlign="Bottom">
                    <Columns>
                    
                        <asp:TemplateField HeaderText="Recipt Nos">
                            <ItemTemplate>
                            <asp:Label ID="lblid" runat="server" Text='<%#Eval("EmpID") %>' style="display:none"></asp:Label>
                            <asp:Label ID="lblempid" runat="server" Text='<%#Eval("EmpCode") %>' style="display:none"></asp:Label>
                                <asp:Label ID="lblFromNo" runat="server" Text='<%#Eval("FromNo")+"-"+Eval("ToNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                    CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                                <asp:ImageButton ID="lblView" runat="server" CausesValidation="false" CommandName="View"
                                    CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>--%>
        <%-- <asp:Panel ID="pnlshowdetail" runat="server">
        </asp:Panel>--%>
        <%--</table>--%></asp:Panel>
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Discount"
    runat="server" ID="ss" />
<asp:ValidationSummary ID="valde" runat="server" ShowMessageBox="true" ShowSummary="false"
    ValidationGroup="Discount4" Width="143px" />

<script type="text/javascript">
      
shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_ChequeCashDeposit1_btn_Save').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>

<script type="text/javascript">
     setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+S : Save ]";
   document.getElementById('status').innerHTML=status;
   }
</script>

<script type="text/javascript">  
 function LabelHide() 
 {   
  document.getElementById('<%= lblId3.ClientID %>').style.display = "none";   
 }   
        setTimeout("LabelHide();", 500000);   
</script>

