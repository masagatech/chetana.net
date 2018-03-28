<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_BankReceiptPayment.ascx.cs" Inherits="UserControls_uc_BankReceiptPayment" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>

<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
            Bank Receipt/Payment Add/Edit<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">               
    </div>
  
</div>
<div id="filter" runat="server">
            <span>Filter Data:</span>
            <input name="filt" onkeyup="filter(this, 'sf', '<%=GrdBankRPDetails.ClientID%>')" type="text">
  </div>
<div style="float: right; width: 31%">
      <asp:Button ID="btnSave" CssClass="form-submit" TabIndex="3" runat="server" Text="Save" 
            ValidationGroup="BRP" Width="80px" onclick="btnSave_Click"  />      
</div>
<br />
<br />
 <asp:Panel ID="PnlAddBankRP" CssClass="panelDetails" runat="server" Width="704px">
 <caption><br /></caption>      
    <table cellpadding="0" cellspacing="0" style="margin-bottom: 0px; width: 672px;">
<tr>
    <td>
        <asp:Label ID="LblBankRPID" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
        <asp:Label ID="LblAccBkCode" CssClass="lbl-form" runat="server" Text="A/c Book Code"></asp:Label>
        <font color="red">*</font>
    </td>
    <td colspan="4">
        <asp:UpdatePanel ID="UpPnl1" runat="server">
        <ContentTemplate>                
            <asp:TextBox ID="TxtAccBkCode" autocomplete="off" Width="80px" CssClass="inp-form"
                TabIndex="7" runat="server" OnTextChanged="TxtAccBkCode_TextChanged" AutoPostBack="true"></asp:TextBox>
            <div id="dvAccBk" class="divauto">
            </div>
            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="TxtAccBkCode"
                UseContextKey="true" ContextKey="AccBook" CompletionListElementID="dvAccBk">
            </ajaxCt:AutoCompleteExtender>
            <asp:RequiredFieldValidator ID="ReqAccBk" runat="server" ErrorMessage="Enter Account Book Code"
                ValidationGroup="S" ControlToValidate="TxtAccBkCode">*</asp:RequiredFieldValidator>
            <asp:Label ID="LblAccBkName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                runat="server"></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
    </td>     
 </tr>
<tr>
    <td>
         <asp:Label ID="LblDocNo" runat="server" CssClass="lbl-form" Text="Document No."></asp:Label>
    </td>
   <td>
        <asp:TextBox ID="TxtDocNo" CssClass="inp-form" TabIndex="1" Width="80px" runat="server" Enabled="false"></asp:TextBox>
    </td>
    <td></td>
    <td width="120px">
        <asp:Label ID="LblDocDt" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
        <font color="red">*</font>
    </td>
    <td>
        <asp:TextBox ID="TxtDt" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
            Enabled="false"></asp:TextBox>
        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtDt"
            Format="dd/MM/yyyy" />
        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="TxtDt"
            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
            AutoComplete="true" CultureName="en-US" />
    </td>
    <td>
        (dd/mm/yyyy)
        <asp:RequiredFieldValidator ID="ReqDt" runat="server" ErrorMessage="Select Date"
            ValidationGroup="BRP" ControlToValidate="TxtDt">*</asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td>
         <asp:Label ID="LblSerialNo" runat="server" CssClass="lbl-form" Text="Serial No."></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TxtSerialNo" CssClass="inp-form" TabIndex="1" Width="80px" 
            runat="server" Enabled="false" MaxLength="20"></asp:TextBox>
    </td>
    <td></td>
</tr>
<tr>
    <td>
        <asp:Label ID="LblCustCode" CssClass="lbl-form" runat="server" Text="Customer Code"></asp:Label>
        <font color="red">*</font>
    </td>
    <td colspan="4">
        <asp:UpdatePanel ID="UpPnl3" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="TxtCustCode" autocomplete="off" Width="80px" CssClass="inp-form"
                TabIndex="7" runat="server" OnTextChanged="TxtCustCode_TextChanged" AutoPostBack="true"></asp:TextBox>
            <div id="dvcustomer" class="divauto">
            </div>
            <ajaxCt:AutoCompleteExtender ID="ReqCmpy" runat="server" DelimiterCharacters=""
                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="TxtCustCode"
                UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcustomer">
            </ajaxCt:AutoCompleteExtender>
            <asp:RequiredFieldValidator ID="ReqCust" runat="server" ErrorMessage="Enter Customer Code"
                ValidationGroup="S" ControlToValidate="TxtCustCode">*</asp:RequiredFieldValidator>
            <asp:Label ID="LblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                runat="server"></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="LblPnI" runat="server" CssClass="lbl-form" Text="Person Incharge"></asp:Label>
        <font color="red">*</font>        
    </td>
    <td>
        <asp:UpdatePanel ID="UpPnl5" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="TxtPnI" CssClass="inp-form" TabIndex="6" Width="80px" 
                    runat="server" AutoPostBack="true" ontextchanged="TxtPnI_TextChanged"></asp:TextBox>
            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" DelimiterCharacters=""
                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="TxtPnI"
                UseContextKey="true" ContextKey="salesman" CompletionListElementID="dvsalesman">
            </ajaxCt:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="ReqPnI" runat="server" ErrorMessage="Require Person Incharge Code"
                    ValidationGroup="BPR" ControlToValidate="TxtPnI">*</asp:RequiredFieldValidator>
                <asp:Label ID="LblPnIName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                    runat="server"></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
    </td>
    <td>
    </td>
</tr>

<%--<tr>
    <td class="style1">
                <asp:Label ID="LblRptCode" runat="server" CssClass="lbl-form" Text="Report Code"></asp:Label>
    </td>
    <td class="style2">
        <asp:TextBox ID="TxtRptCode" CssClass="inp-form" TabIndex="1" Width="80px" runat="server" Enabled="false"></asp:TextBox>
    </td>
    <td class="style3">
    </td>
</tr>--%>
<tr>
    <td>
        <asp:Label ID="LblSMReceipt" CssClass="lbl-form" runat="server" Text="Salesman Receipt"></asp:Label>
        <font color="red">*</font>
    </td>
    <td colspan="4">
        <asp:UpdatePanel ID="UpPnl4" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="TxtSMReceipt" autocomplete="off" Width="80px" CssClass="inp-form"
                TabIndex="7" runat="server" OnTextChanged="TxtSMReceipt_TextChanged" AutoPostBack="true"></asp:TextBox>
            <div id="dvsalesman" class="divauto">
            </div>
            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="TxtSMReceipt"
                UseContextKey="true" ContextKey="salesman" CompletionListElementID="dvsalesman">
            </ajaxCt:AutoCompleteExtender>
            <asp:RequiredFieldValidator ID="ReqSalesman" runat="server" ErrorMessage="Enter Salesman Receipt"
                ValidationGroup="S" ControlToValidate="TxtSMReceipt">*</asp:RequiredFieldValidator>
            <asp:Label ID="LblSMName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                runat="server"></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
    </td>
</tr>

            <tr>
    <td colspan="7" style="padding-bottom: 10px; padding-top: 8px;">
        <hr />
    </td>
</tr>

<tr>
    <td>
        <asp:Label ID="LblCCDD" runat="server" CssClass="lbl-form" Text="Cash/Cheque/DD"></asp:Label>
             <font color="red">*</font>
    </td>
    <td>
        <asp:DropDownList ID="DDLCCDD" runat="server" Enabled="true" Width="100px">
            <asp:ListItem Value="Cash">Cash</asp:ListItem>
            <asp:ListItem Value="DD">DD</asp:ListItem>
            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
        </asp:DropDownList>       
    </td>    
</tr>
<tr>
     <td>
        <asp:Label ID="LblCCDDNo" runat="server" CssClass="lbl-form" Text="Cash/Cheque/DD No."></asp:Label>
             <font color="red">*</font>
    </td>
    <td>
        <asp:TextBox ID="TxtCCDDNo" runat="server" CssClass="inp-form" Height="17px" Width="185px"></asp:TextBox>    
    </td>
    <td>
    </td>
    <td>
        <asp:Label ID="LblType" runat="server" CssClass="lbl-form" Text="Type"></asp:Label>
             <font color="red">*</font>
    <td>
    <td>
        <asp:TextBox ID="TxtType" runat="server" CssClass="inp-form" Height="17px" Width="46px"></asp:TextBox>    
    </td>
</tr>
<tr>
     <td>
        <asp:Label ID="LblAmt" runat="server" CssClass="lbl-form" Text="Amount"></asp:Label>
             <font color="red">*</font>
    </td>
    <td>
        <asp:TextBox ID="TxtAmt" runat="server" CssClass="inp-form" Height="17px" 
            Width="100px" MaxLength="20"></asp:TextBox>    
    </td>
    <td>
    </td>
    <td>
        <asp:Label ID="LblDrawnon" runat="server" CssClass="lbl-form" Text="Drawn On"></asp:Label>
             <font color="red">*</font>
    </td>
    <td>
        <asp:TextBox ID="TxtDrawnon" runat="server" CssClass="inp-form" Height="17px" Width="79px"></asp:TextBox>    
    </td>
</tr>
<tr>
    <td>    
        <asp:Label ID="LblNar" runat="server" CssClass="lbl-form" Text="Narration"></asp:Label>
         <font color="red">*</font>
    </td>
    <td>
        <asp:TextBox ID="TxtNar" runat="server" CssClass="inp-form" Height="40px" TextMode="MultiLine" Width="191px"></asp:TextBox>
    </td> 
</tr>
<tr>
    <td>
        <asp:Label ID="LblChk" runat="server" CssClass="lbl-form" Text="Active"></asp:Label>
    </td>
    <td>
        <asp:CheckBox ID="ChekActive" runat="server" Checked="false" TabIndex="3" />
    </td>
</tr>
</table>
 <caption><br /></caption>  
 </asp:Panel>
 
 <asp:Panel ID="PnlBankRPDetails" runat="server">
<asp:GridView ID="GrdBankRPDetails" runat="server" AllowPaging="true" AutoGenerateColumns="False"
    CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="10" 
    Width="600px" onrowdeleting="GrdBankRPDetails_RowDeleting" 
    onrowediting="GrdBankRPDetails_RowEditing">                          
    <Columns>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="AccBook Code" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblBankRPID" runat="server" CssClass="lbl-form" Style="display: none;"
                Text='<%#Eval("Bank_RecPayID") %>'></asp:Label>
            <asp:Label ID="lblAccBookID" runat="server" CssClass="lbl-form" Style="display: none;"
                Text='<%#Eval("AccBookID") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
  <%--  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="AccBook Name" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblAccBookName" runat="server" CssClass="lbl-form" 
                 Text='<%#Eval("AccBookName") %>'></asp:Label> 
        </ItemTemplate>
    </asp:TemplateField>  --%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Document No." ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblAccDocNo" runat="server" CssClass="lbl-form" 
                 Text='<%#Eval("AccDocumentNo") %>'></asp:Label> 
            <%--<asp:Label ID="lblAccDocDt" runat="server" CssClass="lbl-form" Style="display: none;"
                 Text='<%#Eval("AccDocumentdate") %>'></asp:Label> --%>     
        </ItemTemplate>
    </asp:TemplateField>                        
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Document S.No." ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>                                         
            <asp:Label ID="lblAccSNo" runat="server" CssClass="lbl-form" 
                Text='<%#Eval("AccDocSerialNo") %>'></asp:Label>
       </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Customer" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblCustID" runat="server" CssClass="lbl-form" 
                Text='<%#Eval("CustomerID") %>'></asp:Label>
                                
            <asp:Label ID="lblPnI" runat="server" CssClass="lbl-form" Style="display: none;"
                Text='<%#Eval("PersonInchargeID") %>'></asp:Label>
                
             <asp:Label ID="lblSMReceipt" runat="server" CssClass="lbl-form" Style="display: none;"
                Text='<%#Eval("SalesmanReceipt")%>'></asp:Label>
            <asp:Label ID="lblCCDD" runat="server" CssClass="lbl-form" Style="display: none;"
                Text='<%#Eval("Cash_Cheque_DD") %>'></asp:Label>                            
            <asp:Label ID="lblCCDDNo" runat="server" CssClass="lbl-form" Style="display: none;"
                Text='<%#Eval("Cheque_DDNo")%>'></asp:Label>                            
            <asp:Label ID="lblType" runat="server" CssClass="lbl-form" Style="display: none;"
                Text='<%#Eval("Type") %>'></asp:Label>  
            <asp:Label ID="lblAmt" runat="server" CssClass="lbl-form" Style="display: none;"
                Text='<%#Eval("Amount")%>'></asp:Label>    
            <asp:Label ID="lblDrawnon" runat="server" CssClass="lbl-form" Style="display: none;"
                Text='<%#Eval("DrawnOn")%>'></asp:Label>                               
            <asp:Label ID="lblNar" runat="server" CssClass="lbl-form" Style="display: none;"
                Text='<%#Eval("NarrationID") %>'></asp:Label>                               
            <asp:CheckBox ID="chkisActive" runat="server" CssClass="lbl-form" Style="display: none;"
                Checked='<%#Eval("IsActive") %>' />                          
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>                  
            <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
            <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you want to Delete?')" />
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Panel>

<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="S"
  runat="server" ID="ss" />