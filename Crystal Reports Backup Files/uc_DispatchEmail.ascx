<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DispatchEmail.ascx.cs" Inherits="UserControls_uc_DispatchEmail" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <td>
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            <span runat="server" id="pageName">Get Pass Out</span><a href="Campaigns.aspx" title="back to campaign list">
            </a>
        </div>
        <div class="options">
        </div>
    </td>
</div>
<div style="float: left; width: 518px">
  <asp:Button ID="btnEmail" Style="float: right; margin: 0px 2px 0px 2px"
        CssClass="submitbtn" 
        runat="server" Text="Send" Width="80px" onclick="btnEmail_Click"  />
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
    <asp:Label ID="lblDocNo" Style="display: none;" runat="server"></asp:Label>

</div>
<br />
<br />
<asp:Panel ID="pnlAddForm" CssClass="panelDetails" runat="server" Width="480px">
    <table cellpadding="1" cellspacing="2">
        <tr>
            <td>
                <asp:Label ID="lblSelect" runat="server" Text="Select" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoOL" runat="server" RepeatDirection="Horizontal"
                    TabIndex="11">
                    <asp:ListItem Value="O">Outstation</asp:ListItem>
                    <asp:ListItem Value="L">Local</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
                                <td style="margin-left: 80px">
                                    <asp:Label ID="Label1" runat="server" Text="DC No" 
                                        CssClass="lbl-form"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDC" ValidationGroup="get" onkeypress="return CheckNumeric(event)"
                                        runat="server" MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
        <tr>
        <td align="right">
         <asp:Button ID="BtnGetDCDetails" CssClass="submitbtn" runat="server" ValidationGroup="get"
          Text="Get Details" onclick="BtnGetDCDetails_Click"  />
  </td> </tr>
    </table>

    

    <script type="text/javascript">


    </script>

</asp:Panel>
<asp:Panel ID="pnlDetailsForm" CssClass="panelDetails" runat="server" Width="480px">
<table cellpadding="1" cellspacing="2">
        <tr>
            <td style="margin-left: 80px">
                <asp:Label ID="Label2" runat="server" Text="Doc No" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDocNo" runat="server" CssClass="inp-form" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="Doc Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDocDate" runat="server" CssClass="inp-form" TabIndex="1"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDocDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" TargetControlID="txtDocDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                (dd/mm/yyyy)
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDocDate"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="getpassout">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="D/C No."></asp:Label>
            </td>
            <td style="margin-left: 40px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDcNo" runat="server" CssClass="inp-form" onkeypress="return CheckNumeric(event)"
                            TabIndex="2" AutoPostBack="True"></asp:TextBox>
                        <div id="divDocNo" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="AutoExtDocno" runat="server" CompletionInterval="100"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="divDocNo" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="g_docNo"
                            DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                            ServiceMethod="GetGodownCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDcNo"
                            UseContextKey="true">
                        </ajaxCt:AutoCompleteExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtBillNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;<asp:Label ID="lblBill" runat="server" CssClass="lbl-form" Text="Bill No."></asp:Label>
                &nbsp;
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtBillNo" runat="server" onkeypress="return CheckNumericWithDot(event)"
                            CssClass="inp-form" TabIndex="2" AutoPostBack="false" ></asp:TextBox>
                        <asp:Label ID="lblclone" runat="server" Style="display: none;" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDcNo"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="getpassout">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Customer" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtcustomer" runat="server" Width="310px" CssClass="inp-form" TabIndex="3"
                            AutoPostBack="true"></asp:TextBox>
                        <div id="dvcust" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" CompletionInterval="100"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="dvcust" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="customer"
                            DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                            ServiceMethod="GetGodownCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtCustomer"
                            UseContextKey="true">
                        </ajaxCt:AutoCompleteExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtDcNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtBillNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomer"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="getpassout">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:UpdatePanel ID="upCustomerName" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblCustomer" ForeColor="Blue" Font-Bold="true" Font-Size="10px" runat="server"
                            Style="font-size: 11px"></asp:Label>
                        <asp:Label ID="lblCustID" Style="display: none;" runat="server" Text="0"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtCustomer" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtBillNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Transporter"></asp:Label>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txttransporter" runat="server" Width="310px" CssClass="inp-form"
                            TabIndex="4" AutoPostBack="True" ></asp:TextBox>
                        <ajaxCt:AutoCompleteExtender ID="ACExttransporter" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetGodownCodes" CompletionInterval="100" MinimumPrefixLength="1"
                            CompletionSetCount="20" ServicePath="~/AutoComplete.asmx" EnableCaching="false"
                            TargetControlID="txttransporter" UseContextKey="true" ContextKey="transporterg"
                            CompletionListElementID="divtrasport">
                        </ajaxCt:AutoCompleteExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtTransporter" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTransporter"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="getpassout">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:UpdatePanel ID="upTransporter" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbltransporter" runat="server" Style="font-size: 11px; color: #0000FF;
                            font-weight: 700" Visible="False"></asp:Label>
                        <asp:Label ID="lblTransID" Style="display: none;" runat="server" Text="0"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtTransporter" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="No of Parcels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNoOfBund" Style="text-align: right;" onkeypress="return CheckNumeric(event)"
                    runat="server" CssClass="inp-form" TabIndex="5"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:Label ID="Label16" runat="server" Text="Remark"></asp:Label>
            </td>
            <td rowspan="2">
                &nbsp; &nbsp;
                <asp:TextBox ID="txtRemark" runat="server" CssClass="inp-form" Height="64px" MaxLength="500"
                    TextMode="MultiLine" Width="192px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Value of Goods" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtValOfGoods" Style="text-align: right;" runat="server" onkeypress="return CheckNumeric(event)"
                    CssClass="inp-form" TabIndex="7"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Sent By" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtSentBy" runat="server" CssClass="inp-form" TabIndex="9" Width="310px"></asp:TextBox>
                &nbsp; &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="LR No" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLRNo" runat="server" onkeypress="return CheckNumeric(event)"
                    CssClass="inp-form" TabIndex="10"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" CssClass="lbl-form" Text="LR Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLrDate" runat="server" CssClass="inp-form" TabIndex="10"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtLrDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtLrDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                (dd/mm/yyyy)
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Text="Payment Status" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoPaidStaus" runat="server" RepeatDirection="Horizontal"
                    TabIndex="11">
                    <asp:ListItem Value="topay">To Pay</asp:ListItem>
                    <asp:ListItem Value="paid">Paid</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Amount" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmt" Style="text-align: right;" onkeypress="return CheckNumeric(event)"
                    runat="server" CssClass="inp-form" TabIndex="12"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Delivery" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chIsDelivery" runat="server" TabIndex="13" />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlDetailsGrid" runat="server">
                     
                        <asp:GridView ID="grdOL" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                            AutoGenerateColumns="false" runat="server">
                            <Columns>
                            <asp:TemplateField HeaderText="Doc No" HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDoc_No" runat="server" Text='<%#Eval("Doc_No")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Doc Date" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDoc_Date" runat="server" Text='<%#Eval("Doc_Date")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="D/C No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDC_No" runat="server" Text='<%#Eval("DC_No")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bill No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Bill_Nos")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Customer" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustomerName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Transporter" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTransporter" Style="text-align: right;" runat="server" Text='<%#Eval("Trasporter")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="No of Parcels" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNo_Bundles" runat="server" Text='<%#Eval("No_Bundles")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value of Goods" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblValue_Goods" runat="server" Text='<%#Eval("Value_Goods")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sent By" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSent_By" Style="text-align: right;" runat="server" Text='<%#Eval("Sent_By")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="LR No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLR_No" Style="text-align: right;" runat="server" Text='<%#Eval("LR_No")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="LR Date" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLR_Date" Style="text-align: right;" runat="server" Text='<%#Eval("LR_Date")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Payment Status" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSent_By" Style="text-align: right;" runat="server" Text='<%#Eval("Pay_Paid")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLR_No" Style="text-align: right;" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delivery" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLR_Date" Style="text-align: right;" runat="server" Text='<%#Eval("Delivery")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
