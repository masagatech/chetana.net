<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChequeCashFilter.ascx.cs"
  Inherits="UserControls_ChequeCashFilter" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
  <div class="title">
    <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
    A/C Entries >Check/Cash> Payment Pending<a href="Campaigns.aspx" title="back to campaign list"></a>
  </div>
</div>
<style type="text/css">
  .submitbtn
  {
    height: 26px;
  }
  .inp-form
  {
    margin-left: 0px;
  }
</style>
<%--<div style="float: right; width: 70%">
    <asp:Button ID="view" CssClass="submitbtn" TabIndex="3" runat="server" Text="view"
        Width="80px" OnClick="view_Click" ValidationGroup="ct" />
</div>--%>
<div>
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="ct"
    runat="server" ID="ss" />
</div>
<asp:Panel ID="pnlchequedate" runat="server" Width="709px" Style="height: auto">
  <table cellpadding="0" cellspacing="0">
    <tr>
      <td>
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="709px" Height="30px">
          <table>
            <tr>
              <td>
                <asp:Label ID="lblcustid" runat="server" Style="display: none"></asp:Label>
                <asp:Label ID="lblchedate" runat="server" CssClass="lbl-form" Text="FromDate"></asp:Label>
                <span style="color: Red">*</span>
              </td>
              <td valign="middle">
                <asp:TextBox ID="txtdate" runat="server" Height="17px" TabIndex="1" autocomplete="off"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate"
                  Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtdate"
                  MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                  AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter FromDate"
                  ValidationGroup="ct" Text="." ControlToValidate="txtdate"></asp:RequiredFieldValidator>
                <asp:Label ID="lblmessage" runat="server" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"></asp:Label>
              
             
              </td>
              <td>
                <asp:Label ID="lblid" runat="server" Style="display: none"></asp:Label>
                <asp:Label ID="lblto" runat="server" CssClass="lbl-form" Text="ToDate"></asp:Label>
                <span style="color: Red">*</span>
              </td>
              <td valign="middle">
                <asp:TextBox ID="txttodate" runat="server" Height="17px" TabIndex="1" autocomplete="off"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                  Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                  MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                  AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter ToDate"
                  ValidationGroup="ct" Text="." ControlToValidate="txttodate"></asp:RequiredFieldValidator>
                <asp:Label ID="Label2" runat="server" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"></asp:Label>
              </td>
              <td align="left">
                <asp:Button ID="btnGet" CssClass="submitbtn" Width="40px" runat="server" Text="Get"
                  OnClick="btnGet_Click" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ct"
                  ShowMessageBox="true" ShowSummary="false" />
              </td>
            </tr>
          </table>
        </asp:Panel>
        <br />
        <asp:GridView ID="GrdViewChequedate" runat="server" AutoGenerateColumns="false" CssClass="product-table"
          ForeColor="#333333" PageSize="100" Width="550px">
          <Columns>
           <asp:TemplateField HeaderStyle-Width="60px" HeaderText="Document No">
              <ItemTemplate>
              <asp:Label ID="lblcqid" runat="server"  Text='<%#Eval("CQ_ID") %>'></asp:Label>
               </ItemTemplate>
             <HeaderStyle Width="60px" />
               </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="60px" HeaderText="Cheque Date">
              <ItemTemplate>
                
                 <asp:Label ID="lblCustCode1" runat="server" Style="display: none" Text='<%#Eval("CustCode")%>'></asp:Label>
                  <asp:Label ID="lblEmpCode1" runat="server" Style="display: none" Text='<%#Eval("EmpCode")%>'></asp:Label>
                
                <asp:Label ID="lblEmpId" runat="server" Style="display: none" Text='<%#Eval("EmpID")%>'></asp:Label>
                <asp:Label ID="lblcustid" runat="server" Style="display: none" Text='<%#Eval("CustId")%>'></asp:Label>
                <asp:Label ID="lbldepositType" runat="server" Style="display: none" Text='<%#Eval("Deposite_Type")%>'></asp:Label>
                <asp:Label ID="lblcreatedby" runat="server" Style="display: none" Text='<%#Eval("CreatedBy")%>'></asp:Label>
                <asp:Label ID="lblChequeDate" runat="server" Text='<%#Eval("ChequeDate")%>'></asp:Label>
                <%--  <asp:Label ID="lblBankCode" runat="server" Style="display: none" Text='<%#Eval("BankCode")%>'></asp:Label>
                                  <asp:Label ID="lblBankID" runat="server" Style="display: none" Text='<%#Eval("BankID")%>'></asp:Label>--%>
                <asp:Label ID="lblPayee_Bank" runat="server" Style="display: none" Text='<%#Eval("Payee_Bank")%>'></asp:Label>
              </ItemTemplate>
             <HeaderStyle Width="60px" />
           </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="60px" HeaderText="Receipt No">
              <ItemTemplate>
                <asp:Label ID="lblrec" runat="server" Text='<%#Eval("ReciptNo")%>'></asp:Label>
              </ItemTemplate>
              <HeaderStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="60px" HeaderText="Cheque No">
              <ItemTemplate>
                <asp:Label ID="lblChequeNo" runat="server" Text='<%#Eval("ChequeNo")%>'></asp:Label>
              </ItemTemplate>
              <HeaderStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="60px" HeaderText="Amount">
              <ItemTemplate>
                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
              </ItemTemplate>
              <HeaderStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Client Name">
              <ItemTemplate>
                <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
               
              </ItemTemplate>
              <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" HeaderText="Action">
              <ItemTemplate>
                <asp:ImageButton ID="lblAction" runat="server" CommandArgument='<%#Eval("CQ_ID") %>' 
                  CommandName='<%#Eval("ReciptNo")%>' ImageUrl="../../../Images/icon/View-icon.gif"
                  OnClick="lblAction_Click" text="Deposit" />
              </ItemTemplate>
              <HeaderStyle Width="100px" />
            </asp:TemplateField>
            
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
    
      <td>
        <asp:Label ID="lblReceiptNo123" CssClass="inp-form" runat="server"></asp:Label>
        <asp:Label ID="lblminusamt" style="display:none"  runat="server" ></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvLegder" runat="server" AutoGenerateColumns="false" CellPadding="4" ShowFooter="true"
          CssClass="product-table" ForeColor="#333333" PageSize="100" 
              onrowdatabound="gvLegder_RowDataBound">
          <Columns>
            <asp:TemplateField HeaderText="InvoiceNo">
              <ItemTemplate>
                <asp:Label ID="lblotherId" runat="server" Text='<%#Eval("otherId") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date">
              <ItemTemplate>
                <asp:Label ID="lbldate" runat="server" Text='<%#Eval("date")%>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DebitAmount" ItemStyle-HorizontalAlign="Right">
              <ItemTemplate>
                <asp:Label ID="lblDebitAmount" runat="server" Text='<%#Eval("DebitAmount","{0:0.00}")%>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CreditAmount" ItemStyle-HorizontalAlign="Right">
              <ItemTemplate>
                <asp:Label ID="lblCreditAmount" runat="server" Text='<%#Eval("CreditAmount","{0:0.00}") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CNAmt" ItemStyle-HorizontalAlign="Right">
              <ItemTemplate>
                <asp:Label ID="lblCNAmt" runat="server" Text='<%#Eval("CNAmt","{0:0.00}") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PaymentStatus" ItemStyle-HorizontalAlign="Left">
              <ItemTemplate>
                <asp:Label ID="lblPaymentStatus" runat="server" Text='<%#Eval("PaymentStatus") %>'></asp:Label>
                <asp:Label ID="lblFTotalamount" runat="server" ></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Receivable" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
              <ItemTemplate>
                <asp:TextBox ID="txtreceivable" runat="server" Text="0.00" style="text-align:right" AutoComplete="off" >
                </asp:TextBox>
              </ItemTemplate>
              <FooterTemplate>
               <asp:Label ID="lblFTotalamount1" CssClass="totalAmt1" runat="server" ></asp:Label>
              </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Close">
              <ItemTemplate>
                <asp:CheckBox ID="chkclose" runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
         <asp:Label ID="lblTotalamtId" Style="display: none;" runat="server" Text="0" CssClass="inp-form"></asp:Label>
      </td>
    </tr>
  </table>
</asp:Panel>
<asp:Panel ID="pnlothertext" runat="server" CssClass="panelDetails" Width="690px"
  Height="100px">
  <table>
    <tr>
      <td width="50px">
        <asp:Label ID="lblCid" runat="server" CssClass="lbl-form" Text="0" Style="display: none"></asp:Label>
        <asp:Label ID="lblBank" runat="server" CssClass="lbl-form" Text="BankName"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtBankName" autocomplete="off" CssClass="inp-form" TabIndex="2"
          runat="server" AutoPostBack="false" Width="200px" Style="margin-left: 0px" Height="17px"
          OnTextChanged="txtBankName_TextChanged"></asp:TextBox>
        <%-- <div id="Div1" class="divauto2">
                        </div>--%>
        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" DelimiterCharacters=""
          CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
          CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True" ServiceMethod="GetCodes"
          CompletionSetCount="20" ServicePath="~/AutoComplete.asmx" CompletionInterval="100"
          MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtBankName" UseContextKey="true"
          ContextKey="Bank" CompletionListElementID="divbank">
        </ajaxCt:AutoCompleteExtender>
      </td>
    </tr>
    <tr>
      <td width="50px">
        <asp:Label ID="lblDepositDate" runat="server" CssClass="lbl-form" Text="DepositDate"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtDepositDate" runat="server" TabIndex="3" Style="margin-left: 0px"
          CssClass="inp-form" Width="200px"></asp:TextBox>
        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDepositDate"
          Format="dd/MM/yyyy" />
        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDepositDate"
          MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
          AutoComplete="true" CultureName="en-US" />
      </td>
    </tr>
    <tr>
      <td width="50px">
        <asp:Label ID="lblRemark" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtRemark" TextMode="MultiLine" Width="200px" runat="server" TabIndex="4"
          CssClass="inp-form"></asp:TextBox>
      </td>
      <td>
      </td>
      <%-- </tr>
    <tr>--%>
      <td>
      <asp:Button ID="lblEdit" runat="server" Text ="Save" CssClass="submitbtn"
           OnClick="lblupdate_Click" ValidationGroup="Discount" />
       <%-- <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CssClass="close"
          ImageUrl="../../../Images/icon/saveimg.png" OnClick="lblupdate_Click" ValidationGroup="Discount" />--%>
      </td>
    </tr>
  </table>
</asp:Panel>
<asp:Panel ID="pnldeposit" runat="server" CssClass="panelDetails" Width="690px" Height="27px">
  <div class="section-header">
    <div class="title">
      <%--<img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />--%>
      A/C Entries >Check/Cash> Deposited<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
  </div>
  <tr>
    <td width="128px">
      <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Customer"></asp:Label>
      <font color="red">*</font>
    </td>
    <td>
      <asp:TextBox ID="txtcustomerid" AutoPostBack="true" CssClass="inp-form" TabIndex="3"
        Width="130px" runat="server" Height="15px" 
            ontextchanged="txtcustomerid_TextChanged" ></asp:TextBox>
      <%--<div id="Div1" class="divauto">
                        </div>--%>
      <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True" ServiceMethod="GetCodes"
        CompletionSetCount="20" ServicePath="~/AutoComplete.asmx" CompletionInterval="100"
        MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomerid" UseContextKey="true"
        ContextKey="customer">
      </ajaxCt:AutoCompleteExtender>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Client"
        ValidationGroup="Discount32" ControlToValidate="txtcustomerid">.</asp:RequiredFieldValidator>
     
    </td>
    <td>
   <asp:TextBox ID="txtFromDate1" runat="server" TabIndex="2" Style="margin-left: 0px"
          CssClass="inp-form" Width="100px"></asp:TextBox>
        <ajaxCt:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtFromDate1"
          Format="dd/MM/yyyy" />
        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtFromDate1"
          MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
          AutoComplete="true" CultureName="en-US" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter FromDate"
        ValidationGroup="Discount32" ControlToValidate="txtFromDate1">.</asp:RequiredFieldValidator>
    <ajaxCt:TextBoxWatermarkExtender ID="waterfrom" runat="server" TargetControlID="txtFromDate1" WatermarkText="From Date"></ajaxCt:TextBoxWatermarkExtender>
    </td>
    <td>
     <asp:TextBox ID="txtToDate2" runat="server" TabIndex="3" Style="margin-left: 0px"
          CssClass="inp-form" Width="100px"></asp:TextBox>
        <ajaxCt:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtToDate2"
          Format="dd/MM/yyyy" />
        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtToDate2"
          MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
          AutoComplete="true" CultureName="en-US" />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter ToDate"
        ValidationGroup="Discount32" ControlToValidate="txtToDate2">.</asp:RequiredFieldValidator>
        <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtToDate2" WatermarkText="To Date"></ajaxCt:TextBoxWatermarkExtender>
    </td>
    <td>
    <asp:Button ID="btngetdata" runat="server" Text ="GetData" CssClass="submitbtn"
            ValidationGroup="Discount32" onclick="btngetdata_Click" />
            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="Discount32"
                  ShowMessageBox="true" ShowSummary="false" />
    </td>
  </tr>
  <br />
  <tr>
<td>

      <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
        runat="server"></asp:Label>
</td>
  </tr>
  <br />
  <br />
  <asp:GridView ID="gvDeposit" runat="server" CssClass="product-table" AutoGenerateColumns="false"
    ForeColor="#333333" PageSize="100" Width="650px"   >
    <Columns>
      <asp:TemplateField HeaderText="ChequeDate" HeaderStyle-Width="60px">
        <ItemTemplate>
          <asp:Label ID="lblcq_id" runat="server" Text='<%#Eval("CQ_ID") %>' Style="display: none"></asp:Label>
          <asp:Label ID="lbl_emp" runat="server" Style="display: none" Text='<%#Eval("EmpID")%>'></asp:Label>
          <asp:Label ID="lblcust_id" runat="server" Style="display: none" Text='<%#Eval("CustId")%>'></asp:Label>
          <asp:Label ID="lbldeposit_Type" runat="server" Style="display: none" Text='<%#Eval("Deposite_Type")%>'>
          </asp:Label>
    
         
      <asp:Label ID="lblcustomername" runat="server" Text='<%#Eval("CustName") %>' Style="display: none"></asp:Label>
        <asp:Label ID="lblCheque_Date" runat="server" Text='<%#Eval("ChequeDate")%>'></asp:Label>
        </ItemTemplate>
        <HeaderStyle Width="60px" />
      </asp:TemplateField>
      <asp:TemplateField HeaderText="ChequeNo" HeaderStyle-Width="60px">
        <ItemTemplate>
          <asp:Label ID="lblche_no" runat="server" Text='<%#Eval("ChequeNo")%>'></asp:Label>
        </ItemTemplate>
        <HeaderStyle Width="60px" />
      </asp:TemplateField>
      <asp:TemplateField HeaderText="ReciptNo" HeaderStyle-Width="60px">
        <ItemTemplate>
          <asp:Label ID="lblrec_no" runat="server" Text='<%#Eval("ReciptNo")%>'></asp:Label>
        </ItemTemplate>
        <HeaderStyle Width="60px" />
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="60px">
        <ItemTemplate>
          <asp:Label ID="lbl_Amount" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
        </ItemTemplate>
        <HeaderStyle Width="60px" />
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Deposited Bank" HeaderStyle-Width="60px">
        <ItemTemplate>
          <asp:Label ID="lbl_deposit" runat="server" Text='<%#Eval("BankName")%>'></asp:Label>
        </ItemTemplate>
        <HeaderStyle Width="60px" />
      </asp:TemplateField>
      <asp:TemplateField HeaderText="DepositDate" HeaderStyle-Width="60px">
        <ItemTemplate>
          <asp:Label ID="lbl_depositDate" runat="server" Text='<%#Eval("DepositDate")%>'></asp:Label>
        </ItemTemplate>
        <HeaderStyle Width="60px" />
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="60px">
        <ItemTemplate>
          <asp:Label ID="lbl_Remark"  TabIndex="1" Width="100px" runat="server" Text='<%#Eval("Description")%>'>
          </asp:Label>
         </ItemTemplate>
           </asp:TemplateField>
     <asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px">
        <ItemTemplate>
          <asp:LinkButton ID="lnkBounce" runat="server" Text="Cheque Bounce" CommandArgument='<%#Eval("ReciptNo")%>' CommandName='<%#Eval("ChequeNo")%>'
            OnClick="lnkBounce_Click"></asp:LinkButton> 
        </ItemTemplate>
        <HeaderStyle Width="60px" />
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
  <%--   </table>--%>
</asp:Panel>
<asp:Panel ID="pnlReturnCheck" runat="server" CssClass="panelDetails" Width="652px" Height="217px">
<asp:panel ID="pnlbounse" runat="server">
 <asp:GridView ID="gvBouncedetails" runat="server" CssClass="product-table" AutoGenerateColumns="false"
    ForeColor="#333333" PageSize="100" Width="650px">
    <Columns>
    <asp:TemplateField HeaderText="Customer Name" HeaderStyle-Width="60px">
        <ItemTemplate>
          <asp:Label ID="lblcq_id2" runat="server" Text='<%#Eval("CQ_ID") %>' Style="display: none"></asp:Label>
          <asp:Label ID="lbl_emp2" runat="server" Style="display: none" Text='<%#Eval("EmpID")%>'></asp:Label>
          <asp:Label ID="lblcust_id2" runat="server" Style="display: none" Text='<%#Eval("CustId")%>'></asp:Label>
          <asp:Label ID="lbldeposit_Type2" runat="server" Style="display: none" Text='<%#Eval("Deposite_Type")%>'>
          </asp:Label>
      <asp:Label ID="lblcustomername2" runat="server" Text='<%#Eval("CustName") %>'></asp:Label>
       <asp:Label ID="lblFinYearFrom" runat="server" Text='<%#Eval("FinancialYearFrom") %>' Style="display: none"></asp:Label>
          <asp:Label ID="lblFinYearTo" runat="server" Text='<%#Eval("FinancialYearTo") %>' Style="display: none"></asp:Label>
      </ItemTemplate>
       </asp:TemplateField>
      <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="60px">
      <ItemTemplate>
       <asp:Label ID="lbl_BounceAmount2" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'>
       </asp:Label>
      </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="ChequeDate" HeaderStyle-Width="60px">
      <ItemTemplate>
       <asp:Label ID="lblCheque_Date2" runat="server" Text='<%#Eval("ChequeDate")%>'></asp:Label>
       <asp:Label ID="lblrec_no2" runat="server" style="display:none" Text='<%#Eval("ReciptNo")%>'></asp:Label>
        <asp:Label ID="lbl_deposit2" runat="server" style="display:none" Text='<%#Eval("BankName")%>'></asp:Label>
          <asp:Label ID="lblche_no2" runat="server" style="display:none" Text='<%#Eval("ChequeNo")%>'></asp:Label>
           <asp:Label ID="lbl_depositDate2" runat="server" style="display:none" Text='<%#Eval("DepositDate")%>'>
           </asp:Label>
         <asp:Label ID="lbl_Remark2" Width="100px" style="display:none" runat="server" Text='<%#Eval("Description")%>'>       </asp:Label>
      </ItemTemplate>
      </asp:TemplateField>
   </Columns>
    </asp:GridView>
 <div class="section-header">
    <div class="title">
      <%--<img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />--%>
      A/C Entries >Check/Cash>ReturnCheque<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
  </div>
<div style="float: right; width: 70%">
    <asp:Button ID="buttonsave" CssClass="submitbtn" TabIndex="4" runat="server" Text="Save"
        Width="80px" ValidationGroup="retun" onclick="buttonsave_Click"/>
</div>
  <table>
    <tr>
   
    <td>
     <asp:Label ID="lblrece" runat="server" CssClass="lbl-form" Text="Receipt No"></asp:Label>
    </td>
    <td>
   <asp:Label ID="lblreceiptnoret" CssClass="inp-form" runat="server"></asp:Label>
   
    </td>
    <td>
     <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="Cheque No"></asp:Label>
    </td>
      <td>
     
        <asp:Label ID="lblCheckNoRetun" runat="server"  CssClass="inp-form"></asp:Label>
       </td>
       </tr>
       <tr>
       <td>
        <asp:Label ID="lblrutenDate" runat="server" CssClass="lbl-form" Text="Date"></asp:Label>
        <font color="red">*</font>
      </td>
      <td>
        <asp:TextBox ID="txtReturnDate" Width="200px" runat="server" TabIndex="1" CssClass="inp-form"></asp:TextBox>
        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtReturnDate"
          Format="dd/MM/yyyy" />
        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtReturnDate"
          MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
          AutoComplete="true" CultureName="en-US" />
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Date"
                  ValidationGroup="retun" Text="." ControlToValidate="txtReturnAmount"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblRetAmount" runat="server" CssClass="lbl-form" Text="Penalty Amount"></asp:Label>
        <font color="red">*</font>
      </td>
      <td>
        <asp:TextBox ID="txtReturnAmount" onkeypress="return CheckNumeric(event)" MaxLength="8" Width="200px" runat="server" TabIndex="2" CssClass="inp-form"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter ReturnAmount"
                  ValidationGroup="retun" Text="." ControlToValidate="txtReturnAmount"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblReturnRemark" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txttRetRemark" TextMode="MultiLine" Width="200px" runat="server"
          TabIndex="3" CssClass="inp-form"></asp:TextBox>
          
     </td>
    </tr>
  </table>
  </asp:Panel>
   <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="retun"
                  ShowMessageBox="true" ShowSummary="false"/>
</asp:Panel>
  
  <script type="text/javascript">
function addamount(id)
{
var Amount = document.getElementById(id).value;
var totalAmtID = "";
var totalAmt = 0;
totalAmtID = document.getElementById("<%=lblTotalamtId.ClientID %>").innerHTML;
totalAmt = document.getElementById(totalAmtID).innerHTML;

    if(totalAmt >=0)
   {
   totalAmt = parseFloat(totalAmt) + parseFloat(totalAmt);
  //document.getElementById(totalAmtID).innerHTML = totalAmt;
  
   TOTAL();
     
  }
		           
 
}
 function TOTAL()
   {
 
     var gridview = document.getElementById('<%=gvLegder.ClientID %>')
      
    
     var amount = 0 ;
     var totalAmt = 0
    
     
		                for (var r = 1; r < gridview.rows.length-1; r++)
		                {
		                 Amount  = $(gridview.rows[r].cells[6]).find('input:text').attr("value");
		                   totalAmt = totalAmt +  parseFloat(Amount);
			            }
		             //  alert(totalAmt);
		               
		                   // amount = ((ToatalQty * TotalRate * TotalDisc)/100)
		                    //totalAmt =(ToatalQty * TotalRate) - amount
		                    
		                
		                   //   $('.totalQty').html(ToatalQty.toString());
		                      $('.totalAmt1').html(totalAmt.toString());
		}

</script>
    <script type="text/javascript">
     setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
   document.getElementById('status').innerHTML=status;
   }
        </script>
<script type="text/javascript">
      
shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_ChequeCashFilter1_lblEdit').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>