<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PettyVoucherPayment.ascx.cs"
  Inherits="UserControls_ODC_receipt_PettyVoucherPayment" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
  <div class="title">
    <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
    Bill/Voucher Payment<a href="Campaigns.aspx" title="back to campaign list"></a>
  </div>
  <asp:Panel ID="pnlra" runat="server">
  </asp:Panel>
</div>


<asp:Panel ID="pnlpaymet" runat="server" CssClass="panelDetails" style="height:auto; width:auto">
<asp:TextBox ID="txtFromorec" runat="server" CssClass="inp-form" TabIndex="1" autocomplete="off"></asp:TextBox>
                 <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkDDlset" runat="server" 
                 TargetControlID="txtFromorec" WatermarkText="From Voc.No">
              </ajaxCt:TextBoxWatermarkExtender>
<asp:TextBox ID="txttorec" runat="server" CssClass="inp-form" TabIndex="2" autocomplete="off"></asp:TextBox> 
                 <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" 
                 TargetControlID="txttorec" WatermarkText="To Vou.No">
              </ajaxCt:TextBoxWatermarkExtender>
              <asp:Button ID="btnGetVoc" runat="server" TabIndex="3" Text="Get Data" 
    CssClass="submitbtn" Width="80px" onclick="btnGetVoc_Click"/>
                           
  </asp:Panel>
  <br />
    
  <div style="float: right; width: 30.5%">

  <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="submitbtn" Width="80px"
    OnClick="btnsave_Click" ValidationGroup="date" />
</div><br /><br />
  <asp:UpdatePanel ID="updatepetty" runat="server">
    <ContentTemplate>
      <asp:GridView ID="gvPayment" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="100" Width="100px"
        OnRowDataBound="gvPayment_RowDataBound">
        <Columns>
          <asp:TemplateField HeaderText="Vou. No" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
              <asp:Label ID="lblEmpId" runat="server" Style="display: none" Text='<%#Eval("EmpId") %>'></asp:Label>
              <asp:Label ID="lblVoucherNo" runat="server" Text='<%#Eval("VoucherNo") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Voucher Date" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
              <asp:TextBox ID="lblVoucherdate" runat="server" BackColor="White" BorderStyle="None"
                Enabled="false" Width="65px" Text='<%#Eval("VoucherBillSubmitDate") %>' ValidationGroup="date"></asp:TextBox>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Party/Employee Name" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
              <asp:Label ID="lblEmpname" runat="server" Text='<%#Eval("FirstName")+" "+Eval("MiddleName")+" "+Eval("LastName") %>'></asp:Label>
              <asp:Label ID="lblemp" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
              <asp:Label ID="lbltype" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Right">
            <ItemTemplate>
              <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount","{0:0.00}") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Paid Amount" ItemStyle-HorizontalAlign="Right">
            <ItemTemplate>
              <asp:TextBox ID="txtPaidAmount" runat="server" AutoPostBack="true" CssClass="inp-form"
                Height="15px" MaxLength="8" onblur='<%#"javascript:MsgMaxAmount(this,"+Eval("TotalAmount")+")"%>'
                onkeypress="return CheckNumeric(event)" OnTextChanged="txtPaidAmount_TextChanged"
                TabIndex="1" Text='<%#Eval("TotalAmount","{0:0.00}") %>' Width="100px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPaidAmount"
                ErrorMessage="Enter PaidAmount" ValidationGroup="Discount1">.</asp:RequiredFieldValidator>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Payment Mode">
            <ItemTemplate>
              <asp:DropDownList ID="ddlGivenFrom" runat="server" AutoPostBack="true" CssClass="ddl-form"
                TabIndex="3" Width="113px" DataValueField="AutoId" DataTextField="Value" OnSelectedIndexChanged="ddlGivenFrom_SelectedIndexChanged">
              </asp:DropDownList>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderText="Payment Date"
            ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
              <asp:TextBox ID="txtPaymentDate" Width="65px" runat="server" AutoComplete="off" AutoPostBack="true"
                CssClass="inp-form" Height="15px" OnTextChanged="txtPaymentDate_TextChanged" TabIndex="2"></asp:TextBox>
              <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                TargetControlID="txtPaymentDate" />
              <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="true"
                AutoComplete="true" CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                TargetControlID="txtPaymentDate" />
              <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter PaymentDate"
                        ValidationGroup="date" ControlToValidate="txtPaymentDate">.</asp:RequiredFieldValidator>--%>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderText="Cheque No" ItemStyle-HorizontalAlign="Right">
            <ItemTemplate>
              <asp:TextBox ID="txtCheque" runat="server" CssClass="inp-form" TabIndex="2" Enabled="false"
                onkeypress="return CheckNumeric(event)" autocomplete="off"></asp:TextBox>
              <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkCheque" runat="server" TargetControlID="txtCheque"
                WatermarkText="Cheque No">
              </ajaxCt:TextBoxWatermarkExtender>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField FooterStyle-HorizontalAlign="Center" HeaderText="Bank" ItemStyle-HorizontalAlign="Right">
            <ItemTemplate>
              <asp:TextBox ID="txtBankName" runat="server" autocomplete="off" AutoPostBack="false"
                CssClass="inp-form" Height="17px" Style="margin-left: 0px" TabIndex="3" Enabled="false"
                Width="150px"></asp:TextBox>
              <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkDDlset" runat="server" TargetControlID="txtBankName"
                WatermarkText="Bank Name">
              </ajaxCt:TextBoxWatermarkExtender>
              <%-- <div id="Div1" class="divauto2">
                        </div>--%>
              <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="100"
                CompletionListCssClass="AutoExtender" CompletionListElementID="divbank" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="Bank"
                DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtBankName"
                UseContextKey="true">
              </ajaxCt:AutoCompleteExtender>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Remark" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
              <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Payment Remark" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
              <asp:TextBox ID="txtRemark" runat="server" autocomplete="off" AutoPostBack="false"
                CssClass="inp-form" Height="17px" Style="margin-left: 0px" TabIndex="3"
                Width="90px"></asp:TextBox>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </ContentTemplate>
  </asp:UpdatePanel>
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Discount"
    runat="server" ID="ss" />
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="date"
    runat="server" ID="ValidationSummary2" />

