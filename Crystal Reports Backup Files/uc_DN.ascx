<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DN.ascx.cs" Inherits="UserControls_uc_DN" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>
       Debit Note <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
 <asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Width="958px">
  <table width="100%" cellpadding="0" cellspacing="0">
  
  <tr>
     <td width="110px">
        <asp:Label ID="LblBookcode" CssClass="lbl-form" runat="server" Text="Book Code"></asp:Label>
        <asp:Label ID="LblDNDetailID" CssClass="inp-form" runat="server" Style="display: none"></asp:Label>
        <asp:Label ID="LblDNMasterID" CssClass="inp-form" runat="server" Style="display: none"></asp:Label>
     </td>
    <td width="110px">
        <asp:TextBox ID="TxtBookcode"  Width="85px" CssClass="inp-form" TabIndex="1" runat="server" 
        Text="D0101" Enabled="false"></asp:TextBox>
     </td>
      <td colspan="2">
        <asp:Label ID="LblBookName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server" 
        Text="Debit Note Register"></asp:Label>
     </td>
 </tr>
 
  <tr>
    <td>
        <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="DN Account Code"></asp:Label>
         <font color="red">*</font>
    </td>
   <td colspan="3">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtDNAccode" Width="85px" CssClass="inp-form" TabIndex="2" autocomplete="off"
                    runat="server" AutoPostBack="True" OnTextChanged="txtDNAccode_TextChanged"></asp:TextBox>
                <div id="div3" class="divauto350">
                </div>
                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtDNAccode"
                    UseContextKey="true" ContextKey="Account" CompletionListElementID="div3">
                </ajaxCt:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="ReqDNacccode" runat="server" ErrorMessage="Enter DN Account Code"
                    ValidationGroup="Entry" ControlToValidate="txtDNAccode">.</asp:RequiredFieldValidator>
                <asp:Label ID="lblDNacname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" 
                    runat="server"></asp:Label>
                 </ContentTemplate>
        </asp:UpdatePanel>
    </td>
  </tr>
 
  <tr>
    <td>
        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Document No"></asp:Label>
    </td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="Txtdocno"  Width="85px" CssClass="inp-form" TabIndex="3" 
                    runat="server" Enabled="false" ontextchanged="Txtdocno_TextChanged"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </td>
    <td width="110px">
        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
       <font color="red">*</font>
    </td>
    <td>
        <asp:TextBox ID="TxtdocDate" CssClass="inp-form" TabIndex="4" Width="85px" runat="server"
            Enabled="true"></asp:TextBox>
        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtdocDate"
            Format="dd/MM/yyyy" />
        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="TxtdocDate"
            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
            AutoComplete="true" CultureName="en-US" />
        (dd/mm/yyyy)
        <asp:RequiredFieldValidator ID="reqdocDate" runat="server" ErrorMessage="Require Document Date"
            ValidationGroup="DN" ControlToValidate="TxtdocDate">.</asp:RequiredFieldValidator>
    </td>
 </tr>
 <tr>
    <td colspan="4" style="padding-bottom: 10px; padding-top: 8px;">
        <hr />
    </td>
</tr>
 </table>

  <table width="100%" cellpadding="0" cellspacing="0" >
           <tr>
            <td width="110px">
                <asp:Label ID="Label16" CssClass="lbl-form" runat="server" Text="Account Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAccode" Width="85px" CssClass="inp-form" TabIndex="5" autocomplete="off"
                            runat="server" AutoPostBack="True" OnTextChanged="txtAccode_TextChanged"></asp:TextBox>
                        <div id="div1" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtAccode"
                            UseContextKey="true" ContextKey="Account" CompletionListElementID="div1">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="ReqAccode" runat="server" ErrorMessage="Enter Account Code"
                            ValidationGroup="Entry" ControlToValidate="txtAccode">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblaccname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label></ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    
    <tr>
    <td>
        <asp:Label ID="Lbldebitamt" CssClass="lbl-form" runat="server" Text="Debit Amount"></asp:Label>
     </td>
    <td>
        <asp:TextBox ID="Txtdebitamt"  Width="85px" CssClass="inp-form" TabIndex="6" enabled="false"
            runat="server" ontextchanged="Txtdebitamt_TextChanged"></asp:TextBox>
        <ajaxCt:FilteredTextBoxExtender ID="filter4" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="Txtdebitamt" ValidChars="." /> 
     </td>
    </tr>   
    <tr>
    <td>
        <asp:Label ID="Lblcreditamt" CssClass="lbl-form" runat="server" Text="Credit Amount"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="Txtcreditamt"  Width="85px" CssClass="inp-form" TabIndex="7" 
            runat="server" ontextchanged="Txtcreditamt_TextChanged"></asp:TextBox> 
        <ajaxCt:FilteredTextBoxExtender ID="filter3" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="Txtcreditamt" ValidChars="." />
     </td>
    </tr>
    <tr>
            <td>
                <asp:Label ID="LblComment" runat="server" CssClass="lbl-form" Text="Comment"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtComment" runat="server" CssClass="inp-form" Height="40px" TextMode="MultiLine"
                   Width="250px" TabIndex="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCmt" runat="server" ErrorMessage="Enter Comment"
                   ValidationGroup="//Entry" ControlToValidate="TxtComment">.</asp:RequiredFieldValidator> 
            </td>
        </tr>  
    <tr>
        <td>
            <asp:Button ID="btnaddEntry" CssClass="submitbtn" runat="server" ValidationGroup="Entry"
             Text="Add" Width="70px" TabIndex="9" OnClick="btnaddEntry_Click" />
        </td>
    </tr>

  </table>
 </asp:Panel>
  
    
 <p></p>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
 <asp:Panel ID="PnllGrdDN" runat="server" Width="900px">

   <asp:Panel ID="PnlAddEntry" runat="server" DefaultButton="btnaddEntry">
  </asp:Panel>

   <div class="actiontab" style="margin-bottom: 6px; width: 997px;">
    <table align="right"  border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;" >
    <tr>
    <td align="right" width="80px"></td>
    <td align="right" width="80px">
        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="10" runat="server" Text="Save"
            Width="80px" OnClick="btnSave_Click" ValidationGroup="DN" />
    </td>
    </tr>
    </table>
    </div>
    
<%--   <asp:UpdatePanel ID="upGridData" runat="server">
    <ContentTemplate>--%>
   <asp:GridView ID="GrdDN" runat="server" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
        AutoGenerateColumns="false" CellPadding="4" CssClass="product-table"  ShowHeader ="true"
        OnRowDataBound="GrdDN_RowDataBound"  onrowdeleting="GrdDN_RowDeleting"> 
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Account Code">
                <ItemTemplate>
                    <asp:Label ID="LblDNDID" runat="server" style="display:none;" Text='<%#Eval("DNDetailID	")%>'></asp:Label>
                    <asp:Label ID="LblDNMID" runat="server" style="display:none;" Text='<%#Eval("DNMasterID")%>'></asp:Label>
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
                    <asp:Label ID="LblAname" runat="server" Width="430px" Text='<%#Eval("Accountname")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
         <%--   <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Report Code">
                <ItemTemplate>
                    <asp:Label ID="LblRcode" runat="server" Text='<%#Eval("Reportcode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="DebitAmount" 
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="TxtDebit" runat="server" AutoPostBack="True" 
                        CssClass="inp-form" MaxLength="20" Enabled="false"
                        onkeypress="return CheckNumeric(event)" ontextchanged="TxtDebit_TextChanged" 
                        Style="text-align: right;"  Width="90px"
                        Text='<%#Eval("DebitAmount","{0:0.00}")%>'>
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="TxtDebit" ValidChars="." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                    <asp:Label ID="LblTotalDebit" runat="server" CssClass="totaldebit" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="CreditAmount" 
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="TxtCredit" runat="server" CssClass="inp-form" MaxLength="20" 
                        Style="text-align: right;"  Width="90px" 
                        ontextchanged="TxtCredit_TextChanged" Enabled="false"
                        Text='<%#Eval("CreditAmount","{0:0.00}")%>'>
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter2" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="TxtCredit" ValidChars="." />
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
                    <asp:TextBox ID="TxtCmmt" runat="server" CssClass="inp-form" Height="20px" 
                         TextMode="MultiLine" Width="200px"
                         Text='<%#Eval("Comment")%>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>                  
            <%-- <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                    CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                -   --%>
                <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                    CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" 
                    OnClientClick="return confirm('Do you want to Delete?')" />
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
    runat="server" ID="DN1" />
<script type="text/javascript">

shortcut.add("Ctrl+S",function() 
{
    document.getElementById('ctl00_ContentPlaceHolder1_uc_DN_btnSave').click();
}
);

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
document.getElementById('ctl00_ContentPlaceHolder1_uc_DN1_btnaddEntry').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>