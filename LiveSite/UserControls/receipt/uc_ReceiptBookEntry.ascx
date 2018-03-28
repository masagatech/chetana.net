<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ReceiptBookEntry.ascx.cs"
  Inherits="UserControls_ReceiptBookEntry" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
  <div class="title" style="">
    <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
    <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
    </a>
  </div>
</div>
<div style="float: right; width: 74%">
  <asp:UpdatePanel ID="upder" runat="server">
    <ContentTemplate>
      <asp:Button ID="btnview" CssClass="submitbtn" TabIndex="7" runat="server" Text="View"
        Style="display: none" Width="80px" ValidationGroup="ct1" OnClick="btnview_Click" />
      <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="Save"
        Width="80px" ValidationGroup="ct" OnClick="btnSave_Click" />
    </ContentTemplate>
    <Triggers>
      <asp:AsyncPostBackTrigger ControlID="txtmrcode" EventName="TextChanged" />
    </Triggers>
  </asp:UpdatePanel>
</div>
<div style="float: right; width: 68%">
  <div id="filter" runat="server" style="width: 200px; clear: both; float: left;" visible="false">
    <span>Filter Data:</span>
    <input name="filt" onkeyup="filter(this, 'sf', '1')" type="text">
  </div>
</div>
<br />
<br />
<asp:Label ID="lblIsEditable" runat="server" Text="This Record is locked for any further editing."
  CssClass="lbl-form" Visible="false" />
<asp:UpdatePanel ID="UpdatePanel4" runat="server">
  <ContentTemplate>
    <asp:Label ID="lblId3" runat="server" BackColor="Yellow"></asp:Label>
    <asp:Label ID="lblStatus" Height="20px" CssClass="lbl-form" Font-Bold="true" runat="server"></asp:Label>
    <asp:Label ID="lblEditRece1" Height="20px" CssClass="lbl-form" Font-Bold="true" runat="server"></asp:Label>
    <asp:Label ID="lblEditRece" Height="20px" CssClass="lbl-form" Font-Bold="true" runat="server"></asp:Label>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Width="330px">
  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
      <table cellpadding="0" cellspacing="0">
        <tr>
          <td valign="middle">
            <asp:Label ID="lblrmno" runat="server" Text="MR Code"></asp:Label>
            <asp:Label ID="lblrecid" runat="server" Style="display: none"></asp:Label>
            <asp:Label ID="lblFromNo_Old" runat="server" Style="display: none"></asp:Label>
            <asp:Label ID="lblToNo_Old" runat="server" Style="display: none"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtmrcode" runat="server" autocomplete="off" AutoPostBack="True"
              OnTextChanged="txtmrcode_TextChanged" TabIndex="1"></asp:TextBox>
            <div id="dvsalesman" class="divauto">
            </div>
            <ajaxCt:AutoCompleteExtender ID="TextBox1AutoCompleteExtender" runat="server" CompletionInterval="100"
              CompletionListCssClass="AutoExtender" CompletionListElementID="dvsalesman" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
              CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="salesman"
              DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
              ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtmrcode"
              UseContextKey="true">
            </ajaxCt:AutoCompleteExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmrcode"
              ErrorMessage="Kindly Select Employee" Text="." ValidationGroup="ct"></asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
          <td>
          </td>
          <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
                <asp:Label ID="lblmrName" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"></asp:Label>
              </ContentTemplate>
              <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtmrcode" EventName="TextChanged" />
              </Triggers>
            </asp:UpdatePanel>
            <br />
          </td>
        </tr>
        <tr>
          <td colspan="2">
            <asp:Panel ID="Receiptsave" runat="server" CssClass="pnldash">
              <table>
                <tr>
                  <td>
                    <asp:Label ID="lblActualReceiptNo" runat="server" CssClass="lbl-form" Text="Receipt Book No:"></asp:Label>
                    <span style="color: Red">*</span>
                  </td>
                  <td>
                    <asp:TextBox Enabled="false" ID="txtActualrec" runat="server" autocomplete="off"
                      MaxLength="10" onkeypress="return  CheckNumeric(event)" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtActualrec"
                      ErrorMessage="Enter Actual ReceiptNo:" Text="." ValidationGroup="ct"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <tr>
                  <td>
                    <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="FromNo:"></asp:Label>
                    <span style="color: Red">*</span>
                  </td>
                  <td>
                    <asp:TextBox ID="txtfrom" runat="server" autocomplete="off" MaxLength="10" onkeypress="return CheckNumeric(event)"
                      OnTextChanged="txtfrom_TextChanged" TabIndex="2" AutoPostBack="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfrom"
                      ErrorMessage="Enter From No" Text="." ValidationGroup="ct"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <tr>
                  <td>
                    <asp:Label ID="lblto" runat="server" CssClass="lbl-form" Text="To:"></asp:Label>
                    <span style="color: Red">*</span>
                  </td>
                  <td>
                    <asp:TextBox ID="txtto" runat="server" autocomplete="off" MaxLength="10" onkeypress="return  CheckNumeric(event)"
                      TabIndex="3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtto"
                      ErrorMessage="Enter To No" Text="." ValidationGroup="ct"></asp:RequiredFieldValidator>
                  </td>
                </tr>
              </table>
            </asp:Panel>
          </td>
        </tr>
      </table>
      <triggers>

            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Panel>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ct"
  ShowMessageBox="true" ShowSummary="false" />
<div id="div" runat="server">
  <asp:Button ID="btnprint" runat="server" CssClass="submitbtn" Text="Print" Style="display: none;"
    Width="80px" OnClick="btnprint_Click" />
  <br />
  <asp:Panel ID="PnlRedio" runat="server" CssClass="panelDetails" Width="352px">
    <table>
      <tr>
        <td>
          <asp:RadioButtonList ID="redio" AutoPostBack="true" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text="Employee Wise" Value="ReceiptBookId"></asp:ListItem>
            <asp:ListItem Text="Receipt BookId Wise" Selected="True" Value="Employee"></asp:ListItem>
          </asp:RadioButtonList>
        </td>
      </tr>
    </table>
  </asp:Panel>
  <asp:Panel ID="pnlshow" CssClass="panelDetails" runat="server" Width="353px" Height="45px">
    <%--<hr style="float: left; width: 37%" />--%>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td valign="middle">
          <asp:Label ID="Label1" runat="server" Text="M R Code"></asp:Label>
          <span style="color: Red">*</span>
          <asp:Label ID="lblID" runat="server" Style="display: none"></asp:Label>
        </td>
        <td valign="middle">
          <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="True" Height="22px" OnTextChanged="txtempcode_TextChanged"></asp:TextBox>
          <asp:TextBox ID="txtReceiptBookId" runat="server" Height="22px" onkeypress="return CheckNumeric(event)"
            OnTextChanged="txtReceiptBookId_TextChanged"></asp:TextBox>
          <div id="Div2" class="divauto">
          </div>
          <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True" ServiceMethod="GetCodes"
            CompletionSetCount="20" ServicePath="~/AutoComplete.asmx" CompletionInterval="100"
            MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtempcode" UseContextKey="true"
            ContextKey="salesman" CompletionListElementID="dvsalesman">
          </ajaxCt:AutoCompleteExtender>
        </td>
      </tr>
      <tr>
        <td>
        </td>
        <td>
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
              <asp:Label ID="lblempname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                runat="server"></asp:Label>
            </ContentTemplate>
            <Triggers>
              <asp:AsyncPostBackTrigger ControlID="txtempcode" EventName="TextChanged" />
            </Triggers>
          </asp:UpdatePanel>
        </td>
      </tr>
    </table>
  </asp:Panel>
  <table cellpadding="0" cellspacing="0">
    <tr>
      <td>
        <asp:UpdatePanel ID="upsave" runat="server">
          <ContentTemplate>
            <asp:Button ID="Button1" CssClass="submitbtn" Style="float: right; margin-right: 1px"
              runat="server" Text="Back" Width="80px" ValidationGroup="ct" OnClick="Button1_Click" />
            <br />
          </ContentTemplate>
        </asp:UpdatePanel>
        <br />
      </td>
    </tr>
    <tr>
      <td style="float: right; width: 21%">
      </td>
    </tr>
    <tr>
      <td valign="middle">
      </td>
    </tr>
    <tr>
      <td>
        <br />
        <asp:UpdatePanel ID="upCounts" UpdateMode="Conditional" runat="server">
          <ContentTemplate>
            <asp:GridView ID="gvshow" runat="server" AutoGenerateColumns="False" CaptionAlign="Bottom"
              CellPadding="4" CssClass="product-table" ForeColor="#333333" OnRowEditing="gvshow_RowEditing"
              PageSize="100" OnRowCommand="gvshow_RowCommand" OnRowDataBound="gvshow_RowDataBound">
              <Columns>
                <asp:TemplateField HeaderText="Document No">
                  <ItemTemplate>
                    <asp:Label ID="lblid1" runat="server" Text='<%#Eval("ReceiptBookID") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Salesman Code">
                  <ItemTemplate>
                    <asp:Label ID="lblEmpCode" runat="server" Text='<%#Eval("EmpCode") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Salesman Name">
                  <ItemTemplate>
                    <asp:Label ID="lblEmp" runat="server" Text='<%#Eval("EmpName") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receipt Book No">
                  <ItemTemplate>
                    <asp:Label ID="lblActualReceipt" runat="server" Text='<%#Eval("ActualReceiptNo") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receipt Nos">
                  <ItemTemplate>
                    <asp:Label ID="lblid" runat="server" Style="display: none" Text='<%#Eval("ReceiptBookID") %>'></asp:Label>
                    <asp:Label ID="lblempid" runat="server" Style="display: none" Text='<%#Eval("EmpId") %>'></asp:Label>
                    <asp:Label ID="lblFromNo" runat="server" Text='<%#Eval("FromNo")+"-"+Eval("ToNo") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Used">
                  <ItemTemplate>
                    <asp:LinkButton ID="lnkused" runat="server" Text='<%#Eval("Used") %>' CommandArgument='<%#Eval("FromNo")+"-"+Eval("ToNo") %>'
                      CommandName="Used">
                    </asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cancel">
                  <ItemTemplate>
                    <asp:LinkButton ID="lnkCancel" runat="server" Text='<%#Eval("Cancel") %>' CommandArgument='<%#Eval("FromNo")+"-"+Eval("ToNo") %>'
                      CommandName="CancelReceipt">
                    </asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pending">
                  <ItemTemplate>
                    <asp:Label ID="lnkPending" runat="server" Text='<%#Eval("Pending") %>' CommandName="Pending"></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            </asp:GridView>
          </ContentTemplate>
          <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtempcode" EventName="TextChanged" />
            <asp:PostBackTrigger ControlID="txtReceiptBookId" />
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
          </Triggers>
        </asp:UpdatePanel>
      </td>
    </tr>
  </table>
</div>
<asp:UpdatePanel ID="upDetails" runat="server" UpdateMode="Conditional">
  <ContentTemplate>
    <asp:Panel ID="pnlusedDetails" runat="server">
      <table>
        <tr>
          <td>
            <asp:GridView ID="GridViewUsed" runat="server" AutoGenerateColumns="False" CellPadding="4"
              CssClass="product-table" ForeColor="#333333" PageSize="100" CaptionAlign="Bottom">
              <Columns>
                <asp:TemplateField HeaderText="Receipt No">
                  <ItemTemplate>
                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("CQ_ID") %>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblempid" runat="server" Text='<%#Eval ("EmpID")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblCustid" runat="server" Text='<%#Eval("CustId") %>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblFromNo" runat="server" Text='<%#Eval("ReciptNo") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Deposite_Type">
                  <ItemTemplate>
                    <asp:Label ID="lblDepositety" runat="server" Text='<%#Eval("Deposite_Type") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ChequeNo">
                  <ItemTemplate>
                    <asp:Label ID="lblcheckn" runat="server" Text='<%#Eval("ChequeNo") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ChequeDate">
                  <ItemTemplate>
                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("ChequeDate") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                  <ItemTemplate>
                    <asp:Label ID="lblamounts" runat="server" Text='<%#Eval("Amount") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Deposited_By">
                  <ItemTemplate>
                    <asp:Label ID="lbldepositedb" runat="server" Text='<%#Eval("Deposited_By") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                  <ItemTemplate>
                    <asp:Label ID="lbldesc" runat="server" Text='<%#Eval("Description") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BankName">
                  <ItemTemplate>
                    <asp:Label ID="lblbank" runat="server" Text='<%#Eval("BankName") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            </asp:GridView>
          </td>
        </tr>
      </table>
    </asp:Panel>
    <asp:Panel ID="PanelCancelDetalis" runat="server">
      <table>
        <tr>
          <td>
            <asp:GridView ID="GridViewCancel" runat="server" AutoGenerateColumns="False" CellPadding="4"
              CssClass="product-table" ForeColor="#333333" PageSize="100" CaptionAlign="Bottom">
              <Columns>
                <asp:TemplateField HeaderText="Document No">
                  <ItemTemplate>
                    <asp:Label ID="lblempid" runat="server" Text='<%#Eval ("EmpID")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblCustid" runat="server" Text='<%#Eval("AutoCancelRecNo") %>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblFromNo" runat="server" Text='<%#Eval("ReciptNo") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reason">
                  <ItemTemplate>
                    <asp:Label ID="lblreason" runat="server" Text='<%#Eval("Resion") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IsDelete">
                  <ItemTemplate>
                    <asp:Label ID="lblisdelete" runat="server" Text='<%#Eval("IsDelete") %>' />
                    <asp:Label ID="lblcreated" runat="server" Text='<%#Eval("CreatedOn") %>' Style="display: none" />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CreatedBy">
                  <ItemTemplate>
                    <asp:Label ID="lblcreatedby" runat="server" Text='<%#Eval("CreatedBy") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            </asp:GridView>
          </td>
        </tr>
      </table>
    </asp:Panel>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Kindly select employee"
  ValidationGroup="ct" Text="." ControlToValidate="txtempcode"></asp:RequiredFieldValidator>

<script type="text/javascript">
      
shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_ReceiptBookEntry1_btnSave').click();
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

<asp:Panel ID="pnlreceiptno" runat="server" CssClass="panelDetails" Width="500px"
  Style="bottom: auto" Height="13px">
  <div style="float: right; width: 36%">
    <asp:Button ID="buttonsave" CssClass="submitbtn" TabIndex="2" runat="server" Text="Get"
      Width="80px" ValidationGroup="ctEdit" OnClick="buttonsave_Click" />
  </div>
  <table>
    <tr>
      <td>
        <font color="red">*</font>
        <asp:Label ID="lblReceiptno" runat="server" Width="100px" CssClass="lbl-form" Text="Receipt Book No"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtReceiptno" onkeypress="return CheckNumeric(event)" MaxLength="8"
          Width="100px" runat="server" TabIndex="1" CssClass="inp-form"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="EnterReceiptNo"
          ValidationGroup="ctEdit" Text="." ControlToValidate="txtReceiptno"></asp:RequiredFieldValidator>
      </td>
    </tr>
  </table>
  <br />
  <asp:GridView ID="gvReceiptEdit" runat="server" CssClass="product-table" AutoGenerateColumns="False"
    ForeColor="#333333" PageSize="100" Width="650px" OnRowEditing="gvBouncedetails_RowEditing">
    <Columns>
      <asp:TemplateField HeaderText="Document No" HeaderStyle-Width="60px" FooterStyle-VerticalAlign="Middle"
        ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
          <asp:Label ID="lblEditable" runat="server" Style="display: none" Text='<%#Eval("IsEditable") %>'></asp:Label>
          <asp:Label ID="lblcq_id2" runat="server" Text='<%#Eval("EmpID") %>' Style="display: none"></asp:Label>
          <asp:Label ID="lbl_emp2" runat="server" Style="display: none" Text='<%#Eval("EmpCode")%>'></asp:Label>
          <asp:Label ID="lblcust_id2" runat="server" Text='<%#Eval("ReceiptBookID")%>'></asp:Label>
        </ItemTemplate>
        <FooterStyle VerticalAlign="Middle" />
        <HeaderStyle Width="60px" />
        <ItemStyle HorizontalAlign="Center" />
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Receipt Book No" HeaderStyle-Width="60px" FooterStyle-VerticalAlign="Middle"
        ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
          <asp:Label ID="lblActualReceiptEdit" runat="server" Text='<%#Eval("ActualReceiptNo")%>'>
          </asp:Label>
        </ItemTemplate>
        <FooterStyle VerticalAlign="Middle" />
        <HeaderStyle Width="60px" />
        <ItemStyle HorizontalAlign="Center" />
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="60px" FooterStyle-VerticalAlign="Middle"
        ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
          <asp:Label ID="lbl_BounceAmount2" runat="server" Text='<%#Eval("Name")%>'>
          </asp:Label>
        </ItemTemplate>
        <FooterStyle VerticalAlign="Middle" />
        <HeaderStyle Width="60px" />
        <ItemStyle HorizontalAlign="Center" />
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Receipt From-To" HeaderStyle-Width="60px" FooterStyle-VerticalAlign="Middle"
        ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
          <asp:Label ID="lblCheque_Date2" runat="server" Text='<%#Eval("FromNo")+"-"+Eval("ToNo")%>'></asp:Label>
        </ItemTemplate>
        <FooterStyle VerticalAlign="Middle" />
        <HeaderStyle Width="60px" />
        <ItemStyle HorizontalAlign="Center" />
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" HeaderText="Action">
        <ItemTemplate>
          <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
            CssClass="close" ImageUrl="../../../Images/icon/edit_icon.png" />
        </ItemTemplate>
        <HeaderStyle Width="100px" />
        <ItemStyle HorizontalAlign="Center" />
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="ctEdit"
    runat="server" ID="ValidationSummary2" />
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="ct"
    runat="server" ID="ss" />
</asp:Panel>

<script type="text/javascript">  
 function LabelHide() 
 {   
  document.getElementById('<%= lblId3.ClientID %>').style.display = "none";   
 }   
        setTimeout("LabelHide();", 3000);   
</script>

