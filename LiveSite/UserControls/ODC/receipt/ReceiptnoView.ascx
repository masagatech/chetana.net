<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReceiptnoView.ascx.cs"
  Inherits="UserControls_ODC_receipt_ReceiptnoView" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header" style="float: right; width: 70%">
  <div class="title">
   <span runat="server" id="pageName"></span>
    <a href="Campaigns.aspx" title="back to campaign list"></a>
  </div>
</div>
<asp:Panel ID="pnlreceiptno" runat="server" CssClass="panelDetails" Width="652px" Height="13px">
  <div style="float: right; width: 36%">
    <asp:Button ID="buttonsave" CssClass="submitbtn" TabIndex="2" runat="server" Text="Get"
      Width="80px" ValidationGroup="ct" onclick="buttonsave_Click" />
  </div>
  <table>
    <tr>
      <td>
       <font color="red">*</font>
        <asp:Label ID="lblReceiptno" runat="server" Width="100px" CssClass="lbl-form" Text="Receipt No"></asp:Label>
       
      </td>
      <td>
        <asp:TextBox ID="txtReceiptno" onkeypress="return CheckNumeric(event)" MaxLength="8"
          Width="100px" runat="server" TabIndex="1" CssClass="inp-form"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="EnterReceiptNo"
          ValidationGroup="ct" Text="." ControlToValidate="txtReceiptno"></asp:RequiredFieldValidator>
      </td>
    </tr>
  </table>
  <br />
  <asp:GridView ID="gvBouncedetails" runat="server" CssClass="product-table" AutoGenerateColumns="false"
    ForeColor="#333333" PageSize="100" Width="650px">
    <Columns>
      <asp:TemplateField HeaderText="Receipt BookID" HeaderStyle-Width="60px" FooterStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
          <asp:Label ID="lblcq_id2" runat="server" Text='<%#Eval("EmpID") %>' Style="display: none"></asp:Label>
          <asp:Label ID="lbl_emp2" runat="server" Style="display: none" Text='<%#Eval("EmpCode")%>'></asp:Label>
          <asp:Label ID="lblcust_id2" runat="server" Text='<%#Eval("ReceiptBookID")%>'></asp:Label>
      </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="60px" FooterStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
          <asp:Label ID="lbl_BounceAmount2" runat="server" Text='<%#Eval("Name")%>'>
          </asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Receipt From-To" HeaderStyle-Width="60px" FooterStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
          <asp:Label ID="lblCheque_Date2" runat="server" Text='<%#Eval("FromNo")+"-"+Eval("ToNo")%>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
     </Columns>
  </asp:GridView>
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="ct"
    runat="server" ID="ss" />
</asp:Panel>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter ChequeDate"
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter ChequeDate"
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
<asp:Panel ID="PnlCancelReceipt" runat="server">
 <asp:GridView ID="GrdViewChequedate" runat="server" AutoGenerateColumns="false" CssClass="product-table"
          ForeColor="#333333" PageSize="100" Width="550px" 
    onrowdeleting="GrdViewChequedate_RowDeleting">
          <Columns>
            <asp:TemplateField HeaderStyle-Width="60px" HeaderText="Cheque Date">
              <ItemTemplate>
                <asp:Label ID="lblcqid" runat="server" Style="display: none" Text='<%#Eval("CQ_ID") %>'></asp:Label>
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
                <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../../../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />
              </ItemTemplate>
              <HeaderStyle Width="100px" />
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
</asp:Panel>
