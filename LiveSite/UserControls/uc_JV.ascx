<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_JV.ascx.cs" Inherits="UserControls_uc_JV" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
  <div class="title">
    <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
    <span runat="server" id="pageName"></span>Journal Voucher <a href="Campaigns.aspx"
      title="back to campaign list"></a>
  </div>
  <div class="options">
  </div>
</div>
<asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Width="922px" DefaultButton="btnaddEntry">
  <table width="600px" cellpadding="0" cellspacing="0">
    <tr style="display: none">
      <td width="110px">
        <asp:Label ID="LblCmpycode" CssClass="lbl-form" runat="server" Text="Company Code"></asp:Label>
      </td>
      <td width="150px">
        <asp:TextBox ID="TxtCmpycode" Width="85px" CssClass="inp-form" TabIndex="1" runat="server"
          Text="01" Enabled="false"></asp:TextBox>
      </td>
    </tr>
    <tr style="display: none">
      <td>
        <asp:Label ID="LblBookcode" CssClass="lbl-form" runat="server" Text="Book Code"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="TxtBookcode" Width="85px" CssClass="inp-form" TabIndex="2" runat="server"
          Text="J0101" Enabled="false"></asp:TextBox>
      </td>
      <td colspan="2">
        <asp:Label ID="LblBookName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
          runat="server" Text="Journal Book"></asp:Label>
      </td>
    </tr>
    <tr>
      <td width="110px">
        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Document No"></asp:Label>
        <asp:Label ID="LblJVDetailID" CssClass="inp-form" runat="server" Style="display: none"></asp:Label>
        <asp:Label ID="LblJVMasterID" CssClass="inp-form" runat="server" Style="display: none"></asp:Label>
      </td>
      <td width="110px">
        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
        <font color="red">*</font>
      </td>
      <td width="220px">
      </td>
    </tr>
    <tr>
      <td width="110px">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
          <ContentTemplate>
            <asp:TextBox ID="Txtdocno" Width="85px" CssClass="inp-form" TabIndex="3" runat="server"
              Enabled="false"></asp:TextBox>
          </ContentTemplate>
        </asp:UpdatePanel>
      </td>
      <td width="180px">
        <asp:TextBox ID="TxtdocDate" onblur="ValidInYearDate(this);" CssClass="inp-form"
          TabIndex="4" Width="85px" runat="server" Enabled="true"></asp:TextBox>
        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtdocDate"
          Format="dd/MM/yyyy" />
        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="TxtdocDate"
          MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
          AutoComplete="true" CultureName="en-US" />
        (dd/mm/yyyy)
        <asp:RequiredFieldValidator ID="reqdocDate" runat="server" ErrorMessage="Require Document Date"
          ValidationGroup="JV" ControlToValidate="TxtdocDate">.</asp:RequiredFieldValidator>
      </td>
      <td width="220px">
      </td>
    </tr>
  </table>
  <tr>
    <td colspan="4" style="padding-bottom: 10px; padding-top: 8px;">
      <hr />
    </td>
  </tr>
  <table width="650px" cellpadding="0" cellspacing="0">
    <tr>
      <td width="110px">
        <asp:Label ID="Label16" CssClass="lbl-form" runat="server" Text="Account Code"></asp:Label>
        <font color="red">*</font>
      </td>
      <td width="110px">
        <asp:Label ID="Lbldebitamt" CssClass="lbl-form" runat="server" Text="Debit Amount"></asp:Label>
      </td>
      <td width="110px">
        <asp:Label ID="Lblcreditamt" CssClass="lbl-form" runat="server" Text="Credit Amount"></asp:Label>
      </td>
      <td>
        <asp:Label ID="LblComment" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
      </td>
      <td width="180">
      </td>
    </tr>
    <tr>
      <td>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>
            <asp:TextBox ID="txtAccode" Width="85px" CssClass="inp-form" TabIndex="5" autocomplete="off"
              runat="server" AutoPostBack="True" OnTextChanged="txtAccode_TextChanged"></asp:TextBox>
            <div id="div1" class="divauto350">
            </div>
            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
              CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
              CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True" ServiceMethod="GetCodes"
              CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
              EnableCaching="false" TargetControlID="txtAccode" UseContextKey="true" ContextKey="Account1"
              CompletionListElementID="div1">
            </ajaxCt:AutoCompleteExtender>
            <asp:RequiredFieldValidator ID="ReqAccode" runat="server" ErrorMessage="Enter Account Code"
              ValidationGroup="Entry" ControlToValidate="txtAccode">.</asp:RequiredFieldValidator>
          </ContentTemplate>
        </asp:UpdatePanel>
      </td>
      <td width="110px">
        <asp:TextBox ID="Txtdebitamt" Width="85px" CssClass="inp-form" TabIndex="7" runat="server"
          OnTextChanged="Txtdebitamt_TextChanged"></asp:TextBox>
        <ajaxCt:FilteredTextBoxExtender ID="filter4" runat="server" FilterType="Custom, Numbers"
          TargetControlID="Txtdebitamt" ValidChars="." />
      </td>
      <td>
        <asp:TextBox ID="Txtcreditamt" Width="85px" CssClass="inp-form" TabIndex="8" runat="server"
          OnTextChanged="Txtcreditamt_TextChanged"></asp:TextBox>
        <ajaxCt:FilteredTextBoxExtender ID="filter3" runat="server" FilterType="Custom, Numbers"
          TargetControlID="Txtcreditamt" ValidChars="." />
      </td>
      <td>
        <asp:TextBox ID="TxtComment" runat="server" CssClass="inp-form" Height="15px" TextMode="MultiLine"
          Width="160px" TabIndex="9"></asp:TextBox>
      </td>
      <td width="180">
        <asp:Button ID="btnaddEntry" CssClass="submitbtn" runat="server" ValidationGroup="Entry"
          Text="Add" Width="70px" TabIndex="10" OnClick="btnaddEntry_Click" />
      </td>
    </tr>
    <tr style="display: none">
      <td>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
          <ContentTemplate>
            <asp:TextBox ID="txtreportcode" Width="85px" CssClass="inp-form" TabIndex="6" autocomplete="off"
              runat="server" AutoPostBack="True" OnTextChanged="txtreportcode_TextChanged"></asp:TextBox>
            <div id="div3" class="divauto350">
            </div>
            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
              CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
              CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True" ServiceMethod="GetCodes"
              CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
              EnableCaching="false" TargetControlID="txtreportcode" UseContextKey="true" ContextKey="Account"
              CompletionListElementID="div3">
            </ajaxCt:AutoCompleteExtender>
            <asp:RequiredFieldValidator ID="Reqrepcode" runat="server" ErrorMessage="Enter Report Code"
              ValidationGroup="//Entry" ControlToValidate="txtreportcode">.</asp:RequiredFieldValidator>
            <asp:Label ID="lblacname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
          </ContentTemplate>
        </asp:UpdatePanel>
      </td>
    </tr>
    <tr>
      <td height="30" colspan="4">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
          <ContentTemplate>
            <asp:Label ID="lblaccname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
              runat="server"></asp:Label>
          </ContentTemplate>
        </asp:UpdatePanel>
      </td>
    </tr>
  </table>
</asp:Panel>
<p>
</p>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <asp:Panel ID="PnllGrdJv" runat="server" Width="900px">
      <asp:Panel ID="PnlAddEntry" runat="server">
      </asp:Panel>
      <div class="actiontab" style="margin-bottom: 6px; width: 960px;">
        <table align="right" border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;">
          <tr>
            <td align="right" width="80px">
            </td>
            <td align="right" width="80px">
              <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="11" runat="server" Text="Save"
                Width="80px" OnClick="btnSave_Click" ValidationGroup="JV" />
            </td>
          </tr>
        </table>
      </div>
      <%--   <asp:UpdatePanel ID="upGridData" runat="server">
    <ContentTemplate>--%>
      <asp:GridView ID="GrdJV" runat="server" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
        AutoGenerateColumns="false" CellPadding="4" CssClass="product-table" ShowHeader="true"
        OnRowDataBound="GrdJV_RowDataBound" OnRowDeleting="GrdJV_RowDeleting">
        <Columns>
          <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Account Code">
            <ItemTemplate>
              <asp:Label ID="LblJVDID" runat="server" Style="display: none;" Text='<%#Eval("JVDetailID	")%>'></asp:Label>
              <asp:Label ID="LblJVMID" runat="server" Style="display: none;" Text='<%#Eval("JVMasterID")%>'></asp:Label>
              <asp:Label ID="LblAcode" runat="server" Text='<%#Eval("Accountcode")%>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
              <asp:Label ID="lbltotal" Style="text-align: right; font-weight: bold;" runat="server"
                Text="Total: "></asp:Label>
            </FooterTemplate>
            <HeaderStyle Width="80px" />
          </asp:TemplateField>
          <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Account Name"
            ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
              <asp:Label ID="LblAname" runat="server" Width="392px" Text='<%#Eval("Accountname")%>'></asp:Label>
              <asp:Label ID="LblRcode" runat="server" Style="display: none" Text='<%#Eval("Reportcode")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
          </asp:TemplateField>
          <%-- <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Report Code">
                <ItemTemplate>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>--%>
          <asp:TemplateField HeaderStyle-Width="80px" HeaderText="DebitAmount" ItemStyle-HorizontalAlign="right">
            <ItemTemplate>
              <asp:TextBox ID="TxtDebit" runat="server" AutoPostBack="True" CssClass="inp-form"
                MaxLength="5" Enabled="false" onkeypress="return CheckNumeric(event)" OnTextChanged="TxtDebit_TextChanged"
                Style="text-align: right;" Width="90px" Text='<%#Eval("DebitAmount","{0:0.00}")%>'>
              </asp:TextBox>
              <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" FilterType="Custom, Numbers"
                TargetControlID="TxtDebit" ValidChars="." />
            </ItemTemplate>
            <HeaderStyle Width="80px" />
            <ItemStyle HorizontalAlign="Right" />
            <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
              <asp:Label ID="LblTotalDebit" runat="server" CssClass="totaldebit" Text=""></asp:Label>
            </FooterTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderStyle-Width="80px" HeaderText="CreditAmount" ItemStyle-HorizontalAlign="right">
            <ItemTemplate>
              <asp:TextBox ID="TxtCredit" runat="server" CssClass="inp-form" MaxLength="5" Style="text-align: right;"
                Width="90px" Enabled="false" OnTextChanged="TxtCredit_TextChanged" Text='<%#Eval("CreditAmount","{0:0.00}")%>'>
              </asp:TextBox>
              <ajaxCt:FilteredTextBoxExtender ID="filter2" runat="server" FilterType="Custom, Numbers"
                TargetControlID="TxtCredit" ValidChars="." />
            </ItemTemplate>
            <HeaderStyle Width="80px" />
            <ItemStyle HorizontalAlign="Right" />
            <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
              <asp:Label ID="LblTotalCredit" runat="server" CssClass="totalcredit" Text=""></asp:Label>
            </FooterTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Comment">
            <ItemTemplate>
              <asp:TextBox ID="TxtCmmt" runat="server" CssClass="inp-form" Height="20px" TextMode="MultiLine"
                Width="200px" Text='<%#Eval("Comment")%>'></asp:TextBox>
            </ItemTemplate>
            <HeaderStyle Width="80px" />
          </asp:TemplateField>
          <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
              <%-- <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                    CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                -   --%>
              <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you want to Delete?')" />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle CssClass="alt" />
      </asp:GridView>
      <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnaddEntry" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%></asp:Panel>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Entry"
  runat="server" ID="jv1" />

<script type="text/javascript">

shortcut.add("Ctrl+S",function() 
{
    document.getElementById('ctl00_ContentPlaceHolder1_uc_JV1_btnSave').click();
}
);

</script>

