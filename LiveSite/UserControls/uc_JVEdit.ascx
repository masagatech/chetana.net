<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_JVEdit.ascx.cs" Inherits="UserControls_uc_JVEdit" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>Edit Journal Voucher <a href="Campaigns.aspx"
            title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Width="922px" DefaultButton="btnaddEntry">
<p>
    &nbsp;</p>
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
            <td>
                <asp:Label ID="LblBookName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                    runat="server" Text="Journal Book"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="110px">
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Document No"></asp:Label>
                <font color="red">*</font>
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
                            Enabled="true" OnTextChanged="Txtdocno_TextChanged" AutoPostBack="True"></asp:TextBox>
                        <%--<asp:Label ID="LblJVDetailID" CssClass="inp-form" runat="server" Style="display: none"></asp:Label>--%>
                        <asp:Label ID="LblJVMasterID" CssClass="inp-form" runat="server" Style="display: none"></asp:Label>
                        <asp:RequiredFieldValidator ID="reqdocno" runat="server" ErrorMessage="Require Document No "
                            ValidationGroup="JVedit" ControlToValidate="Txtdocno">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="180px">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtdocDate" onblur="ValidInYearDate(this);" CssClass="inp-form"
                            TabIndex="4" Width="85px" runat="server" Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtdocDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="TxtdocDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        (dd/mm/yyyy)
                        <asp:RequiredFieldValidator ID="reqdocDate" runat="server" ErrorMessage="Require Document Date "
                            ValidationGroup="JVedit" ControlToValidate="TxtdocDate">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
    <table width="600px" cellpadding="0" cellspacing="0">
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
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtAccode"
                            UseContextKey="true" ContextKey="Account" CompletionListElementID="div1">
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
            <td width="180">
            </td>
        </tr>
        <tr style="display: none">
            <td>
                <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Report Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtreportcode" Width="85px" CssClass="inp-form" TabIndex="6" autocomplete="off"
                            runat="server" AutoPostBack="True" OnTextChanged="txtreportcode_TextChanged"></asp:TextBox>
                        <div id="div3" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtreportcode"
                            UseContextKey="true" ContextKey="Account" CompletionListElementID="div3">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="Reqrepcode" runat="server" ErrorMessage="Enter Report Code"
                            ValidationGroup="//Entry" ControlToValidate="txtreportcode">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblacname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="display: none">
            <td>
                <asp:Label ID="LblComment" runat="server" CssClass="lbl-form" Text="Comment"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtComment" runat="server" CssClass="inp-form" Height="40px" TextMode="MultiLine"
                    Width="250px" TabIndex="9"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCmt" runat="server" ErrorMessage="Enter Comment"
                    ValidationGroup="//Entry" ControlToValidate="TxtComment">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="30" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblaccname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="display: none">
            <td>
                <asp:Button ID="btnaddEntry" CssClass="submitbtn" runat="server" ValidationGroup="Entry"
                    Text="Add" Width="70px" TabIndex="10" OnClick="btnaddEntry_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="PnllGrdJv" runat="server" Width="900px">
            <asp:Panel ID="PnlAddEntry" runat="server">
                <asp:Label ID="lblmsg1" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
            </asp:Panel>
            <div class="actiontab" style="margin-bottom: 6px; width: 960px;">
                <table align="right" width="0" border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;">
                    <tr>
                        <td align="right" width="80px">
                            &nbsp;</td>
                        <td align="right" width="80px">
                            <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="11" runat="server" Text="Save"
                                Width="80px" OnClick="btnSave_Click" ValidationGroup="JVedit" />
                        </td>
                    </tr>
                </table>
            </div>
            <%--   <asp:UpdatePanel ID="upGridData" runat="server">
    <ContentTemplate>--%>
            <asp:GridView ID="GrdJV" runat="server" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
                AutoGenerateColumns="false" CellPadding="4" CssClass="product-table" ShowHeader="true"
                OnRowDataBound="GrdJV_RowDataBound" OnRowDeleting="GrdJV_RowDeleting" 
                >
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Account Code">
                        <%--<EditItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtcode" Text='<%#Eval("AccountCode")%>' Width="85px" CssClass="inp-form" TabIndex="5" autocomplete="off"
                                        runat="server" AutoPostBack="True"  OnTextChanged="txtcode_TextChanged" ></asp:TextBox>
                                    <div id="div1" class="divauto350">
                                    </div>
                                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                        ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                        ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtcode"
                                        UseContextKey="true" ContextKey="Account" CompletionListElementID="div1">
                                    </ajaxCt:AutoCompleteExtender>
                                    <asp:RequiredFieldValidator ID="Reqcode" runat="server" ErrorMessage="Enter Account Code"
                                        ValidationGroup="Entry" ControlToValidate="txtcode">.</asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                             <asp:Label ID="LblJVDIDedit" runat="server" Style="display: none" Text='<%#Eval("JVDetailID")%>'></asp:Label>
                        </EditItemTemplate>--%>
                        <ItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtcode" Text='<%#Eval("AccountCode")%>' Width="85px" CssClass="inp-form"
                                        TabIndex="5" autocomplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtcode_TextChanged"></asp:TextBox>
                                    <div id="div1" class="divauto350">
                                    </div>
                                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                        ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                        ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtcode"
                                        UseContextKey="true" ContextKey="Account" CompletionListElementID="div1">
                                    </ajaxCt:AutoCompleteExtender>
                                    <asp:RequiredFieldValidator ID="Reqcode" runat="server" ErrorMessage="Enter Account Code"
                                        ValidationGroup="Entry" ControlToValidate="txtcode">.</asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%-- <asp:Label ID="LblAcode" runat="server" Text='<%#Eval("AccountCode")%>'></asp:Label>--%>
                            <asp:Label ID="LblJVDID" runat="server" Style="display: none" Text='<%#Eval("JVDetailID")%>'></asp:Label>
                            <asp:Label ID="LblJVMID" runat="server" Style="display: none" Text='<%#Eval("JVMasterID")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotal" Style="text-align: right; font-weight: bold;" runat="server"
                                Text="Total: "></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Account Name"
                        ItemStyle-HorizontalAlign="Left">
                        <%-- <EditItemTemplate>
                        <asp:Label ID="LblAname1" runat="server" Width="392px" Text='<%#Eval("AccountName")%>'></asp:Label>
                        </EditItemTemplate>--%>
                        <ItemTemplate>
                            <asp:Label ID="LblAname1" runat="server" Width="392px" Text='<%#Eval("AccountName")%>'></asp:Label>
                            <asp:Label ID="LblRcode" runat="server" Style="display: none" Text='<%#Eval("ReportCode")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderStyle-Width="80px" HeaderText="Report Code">
                <ItemTemplate>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="DebitAmount" ItemStyle-HorizontalAlign="right">
                        <%-- <EditItemTemplate>
                            <asp:TextBox ID="TxtDebit" runat="server" AutoPostBack="True" CssClass="inp-form"
                                MaxLength="20" OnTextChanged="TxtDebit_TextChanged" Style="text-align: right;"
                                Width="90px" Text='<%#Eval("DebitAmount","{0:0.00}")%>'>
                            </asp:TextBox>
                            <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" FilterType="Custom, Numbers"
                                TargetControlID="TxtDebit" ValidChars="." />
                                
                                                            <asp:Label ID="lblDebit" runat="server" CssClass="lbl-form" Style="text-align: right;"
                                Width="90px" Text='<%#Eval("DebitAmount","{0:0.00}")%>'>
                            </asp:Label>
                        </EditItemTemplate>--%>
                        <ItemTemplate>
                            <asp:TextBox ID="TxtDebit" runat="server"  CssClass="inp-form"
                                MaxLength="20" Style="text-align: right;"
                                Width="90px" Text='<%#Eval("DebitAmount","{0:0.00}")%>'>
                            </asp:TextBox>
                            <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" FilterType="Custom, Numbers"
                                TargetControlID="TxtDebit" ValidChars="." />
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                              <asp:TextBox ID="LblTotalDebit" runat="server" CssClass="totaldebit" Enabled="false" style="text-align:right; border:0;" Text="0"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="CreditAmount" ItemStyle-HorizontalAlign="right">
                        <%-- <EditItemTemplate>
                            <asp:TextBox ID="TxtCredit" runat="server" AutoPostBack="True" CssClass="inp-form"
                                MaxLength="20" Style="text-align: right;" Width="90px" OnTextChanged="TxtCredit_TextChanged"
                                Text='<%#Eval("CreditAmount","{0:0.00}")%>'>
                            </asp:TextBox>
                            <ajaxCt:FilteredTextBoxExtender ID="filter2" runat="server" FilterType="Custom, Numbers"
                                TargetControlID="TxtCredit" ValidChars="." />
                        </EditItemTemplate>--%>
                        <ItemTemplate>
                            <asp:TextBox ID="TxtCredit" runat="server"  CssClass="inp-form"
                                MaxLength="20" Style="text-align: right;" Width="90px" 
                                Text='<%#Eval("CreditAmount","{0:0.00}")%>'>
                            </asp:TextBox>
                            <ajaxCt:FilteredTextBoxExtender ID="filter2" runat="server" FilterType="Custom, Numbers"
                                TargetControlID="TxtCredit" ValidChars="." />
                            <%--<asp:Label ID="LblCredit" runat="server" CssClass="lbl-form" Style="text-align: right;"
                                Width="90px" Text='<%#Eval("CreditAmount","{0:0.00}")%>'>
                            </asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:TextBox ID="LblTotalCredit" runat="server" CssClass="totalcredit" style="text-align:right; border:0;" Enabled="false" Text="0"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Comment">
                        <%-- <EditItemTemplate>
                            <asp:TextBox ID="TxtCmmt" runat="server" CssClass="inp-form" Height="20px" TextMode="MultiLine"
                                Width="200px" Text='<%#Eval("Comment")%>'></asp:TextBox>
                                
                                 <asp:Label ID="LBlCmmt" runat="server" CssClass="lbl-form" Height="20px" Width="200px"
                                Text='<%#Eval("Comment")%>'></asp:Label>
                        </EditItemTemplate>--%>
                        <ItemTemplate>
                            <asp:TextBox ID="TxtCmmt" runat="server" CssClass="inp-form" Height="20px" TextMode="MultiLine"
                                Width="200px" Text='<%#Eval("Comment")%>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                        <%--<EditItemTemplate>
                            <asp:ImageButton ID="lnkUpdate" runat="server" CommandName="Update" ImageUrl="../Images/icon/save_as.png"
                                ToolTip="Update"></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="lnkCancel" runat="server" CommandName="Cancel" ImageUrl="../Images/icon/cancel.png"
                                ToolTip="Cancel"></asp:ImageButton>
                        </EditItemTemplate>--%>
                        <ItemTemplate>
                            <%-- &nbsp;&nbsp;
                            <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                ToolTip="Edit" CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                            &nbsp;&nbsp;&nbsp;--%>
                            <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                ToolTip="Delete" CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you want to Delete?')" />
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
    runat="server" ID="jvE" />
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="JVedit"
    runat="server" ID="jvS" />

<script type="text/javascript">

shortcut.add("Ctrl+S",function() 
{
    document.getElementById('ctl00_ContentPlaceHolder1_uc_JVEdit1_btnSave').click();
}
);

</script>


<script type="text/javascript">
 function TOTAL()
   {
 
     var gridview = document.getElementById('<%=GrdJV.ClientID %>')
      
     var debit = 0;
     var credit = 0 ;
     
     var Totaldebit = 0;
     var Totalcredit = 0 ;
     
		                for (var r = 1; r < gridview.rows.length-1; r++)
		                {
		                
		                    debit  = $(gridview.rows[r].cells[2]).find('input:text').attr("value");
		                    //alert(Qty);
			                credit  = $(gridview.rows[r].cells[3]).find('input:text').attr("value");
			               // Disc  = $(gridview.rows[r].cells[7]).find('input:text').attr("value");
			               
			               
			               // TotalDisc = TotalDisc + parseFloat(Disc);
			                Totaldebit = Totaldebit + parseInt(debit);
			                Totalcredit = Totalcredit + parseFloat(credit)
			               // totalAmt = totalAmt + parseFloat((ToatalQty * TotalRate) - ((ToatalQty * TotalRate) * (TotalDisc/100)));
			                
			               // ele  = $(gridview.rows[r].cells[4]).find('input:text').attr("value");
		                    //   alert(ele);

		                }
		               
		                   // amount = ((ToatalQty * TotalRate * TotalDisc)/100)
		                    //totalAmt =(ToatalQty * TotalRate) - amount
		                    
		                
		                      $('.totaldebit').val(Totaldebit.toString());
		                      $('.totalcredit').val(Totalcredit.toString());
		           
		             
     
   }

</script>
