<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
 CodeFile="G_GetPass_OutstationSpeciman.aspx.cs" Inherits="G_GetPass_OutstationSpeciman" Title="Godown Speciman" %>
 
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       Getpass Outstation Speciman<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <asp:Panel ID="pnlra" runat="server">
        <div style="float: right; width: 58%">
            <div id="filter" runat="server">
            </div>
        </div>
    </asp:Panel>
    <div class="options">
    </div>
</div>
<div style="float: left; width: 555px">
   <asp:Button ID="btnClear" Style="float: right; margin: 0px 0px 0px 2px" CssClass="submitbtn"
        OnClientClick="javascript:return confirm('Wish to clear this data');" TabIndex="120"
        ToolTip="Clear all fields" Visible="true" runat="server" Text="Cancel" 
        Width="80px" onclick="btnClear_Click"
        />
    <asp:Button ID="btnDelete" Style="float: right; color: Red; margin: 0px 2px 0px 2px"
        CssClass="submitbtn" OnClientClick="javascript:return confirm('Wish to delete this data');"
        TabIndex="115" ToolTip="Delete the below data" Visible="false" runat="server"
        Text="Delete" Width="80px" onclick="btnDelete_Click" />
    <asp:Button ID="btn_Edit" Visible="true" Style="float: right; margin: 0px 2px 0px 2px"
        CssClass="submitbtn" OnClientClick="javascript:return openEditPopup();" TabIndex="110"
        ToolTip="Edit the data" runat="server" Text="Edit" Width="80px" 
        />&nbsp;
    <asp:Button ID="btn_Save" Visible="true" Style="float: right; margin: 0px 2px 0px 2px"
        CssClass="submitbtn" ValidationGroup="getpassout" TabIndex="105" ToolTip="Save below data"
        runat="server" Text="Save" Width="80px" onclick="btn_Save_Click"/>&nbsp;
    <asp:Button ID="btn_PrintSave" Visible="true" Style="float: right; margin: 0px 2px 0px 2px"
        CssClass="submitbtn" ValidationGroup="getpassout" TabIndex="100" OnClick="btn_PrintSave_Click" ToolTip="Save below data and Print"
        runat="server" Text="Save & Print" Width="80px"
        />&nbsp;
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
    <asp:Label ID="lblDocNo" Style="display: none;" runat="server"></asp:Label>
</div>
<br />
<br />
<asp:Panel ID="pnlAddForm" CssClass="panelDetails" runat="server" Width="517px">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Doc No"></asp:Label>
                <asp:Label ID="lblSpecId" runat="server" Text="0" Visible="false"></asp:Label>
            </td>
            <td style="padding-left:13px">
                <asp:TextBox ID="txtSpecimanNo" style="text-align: center" runat="server" CssClass="inp-form" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Doc Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSpecDate" runat="server" CssClass="inp-form" TabIndex="1"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtSpecDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" TargetControlID="txtSpecDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                (dd/mm/yyyy)
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
     
     
    </table>
    
      <table cellpadding="1" cellspacing="2">

        <tr>
            <td>
                <asp:Label ID="Label18" runat="server" Text="Branch" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtBranch" runat="server" Width="310px" CssClass="inp-form" TabIndex="2"
                        AutoPostBack="true" ontextchanged="txtBranch_TextChanged"></asp:TextBox>
                        <div id="Div2" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" CompletionInterval="100"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="dvcust" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="branch"
                            DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                            ServiceMethod="GetGodownCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtBranch"
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBranch"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="getpassout">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:UpdatePanel ID="UpdatePanel111" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblBranchName" ForeColor="Blue" Font-Bold="true" Font-Size="10px" runat="server"
                            Style="font-size: 11px"></asp:Label>
                        <asp:Label ID="lblBranchID" Style="display: none;" runat="server" Text="0"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtBranch" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtBillNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label21" runat="server" Text="Transporter"></asp:Label>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txttransporter" runat="server" Width="310px" CssClass="inp-form"
                            TabIndex="3" AutoPostBack="True" ontextchanged="txttransporter_TextChange"></asp:TextBox>
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
                <asp:Label ID="Label22" runat="server" Text="No of Parcels"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNoOfParcels" Style="text-align: right;" onkeypress="return CheckNumeric(event)"
                    runat="server" CssClass="inp-form" TabIndex="4"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:Label ID="Label23" runat="server" Text="Remark"></asp:Label>
            </td>
            <td rowspan="2">
                &nbsp; &nbsp;
                <asp:TextBox ID="txtRemark" runat="server" CssClass="inp-form" Height="64px" MaxLength="500"
                    TextMode="MultiLine" Width="192px" TabIndex="5"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label24" runat="server" Text="Value of Goods" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtValOfGoods" Style="text-align: right;" runat="server" onkeypress="return CheckNumeric(event)"
                    CssClass="inp-form" TabIndex="6"></asp:TextBox>
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
                <asp:Label ID="Label25" runat="server" Text="Sent By" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtSentBy" runat="server" CssClass="inp-form" TabIndex="7" 
                    Width="310px"></asp:TextBox>
                &nbsp; &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label26" runat="server" Text="LR No" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLRNo" runat="server" onkeypress="return CheckNumeric(event)"
                    CssClass="inp-form" TabIndex="8"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label27" runat="server" CssClass="lbl-form" Text="LR Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLrDate" runat="server" CssClass="inp-form" TabIndex="9"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtLrDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtLrDate"
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
                <asp:Label ID="Label28" runat="server" Text="Payment Status" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoPaidStaus" runat="server" RepeatDirection="Horizontal"
                    TabIndex="10">
                    <asp:ListItem Value="0" Selected="True">To Pay</asp:ListItem>
                    <asp:ListItem Value="1">Paid</asp:ListItem>
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
           <%-- <td>
                <asp:Label ID="Label29" runat="server" Text="Amount" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmt" Style="text-align: right;" onkeypress="return CheckNumeric(event)"
                    runat="server" CssClass="inp-form" TabIndex="50"></asp:TextBox>
            </td>--%>
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
                <asp:Label ID="Label30" runat="server" Text="Delivery" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chIsDelivery" runat="server" TabIndex="11" />
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
    
    <hr />
    <asp:Panel ID="pnlFormDetail" DefaultButton="btnSaveDetails" runat="server" Width="100%">
        <asp:UpdatePanel ID="upCustomerName0" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblEditMode" Style="display: none;" runat="server" Text="add"></asp:Label>
                            <asp:Label ID="lblSubDocId" Style="display: none;" runat="server" Text="0"></asp:Label>
                            <asp:Label ID="RowID" Style="display: none;" runat="server" Text="0"></asp:Label>
                            <asp:Label ID="Label7" runat="server" Text="Spec No"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Bill No."></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Customer"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Area"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="No of Bundles"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Delivery"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtDcNo" onkeypress="return CheckNumeric(event)" runat="server"
                                Style="text-align: center" CssClass="inp-form" TabIndex="60" AutoPostBack="True"
                                OnTextChanged="txtDcNo_TextChanged" ValidationGroup="strip"></asp:TextBox>
                            <div id="divDocNo" class="divauto350">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoExtDocno" runat="server" CompletionInterval="100"
                                CompletionListCssClass="AutoExtender" CompletionListElementID="divDocNo" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="Specimen"
                                DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                                ServiceMethod="GetGodownCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDcNo"
                                UseContextKey="true">
                            </ajaxCt:AutoCompleteExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBillNo" runat="server"
                                CssClass="inp-form" TabIndex="65" ValidationGroup="strip"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCust" runat="server" CssClass="inp-form" TabIndex="70"
                                ValidationGroup="strip" Enabled="false"></asp:TextBox>
                            <%--<div id="dvcust" class="divauto350">
                            </div>--%>
                            <%--<ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" CompletionInterval="100"
                                CompletionListCssClass="AutoExtender" CompletionListElementID="dvcust" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="customer"
                                DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="3"
                                ServiceMethod="GetGodownCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtCust"
                                UseContextKey="true">
                            </ajaxCt:AutoCompleteExtender>--%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtArea" runat="server" ValidationGroup="strip" CssClass="inp-form"
                                TabIndex="75"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox Style="text-align: right"
                                ID="txtNoOfBundles" runat="server" ValidationGroup="strip" CssClass="inp-form"
                                TabIndex="80"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkDelivery" runat="server" TabIndex="85" />
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDcNo"
                                ErrorMessage="D/C No is reqired" ValidationGroup="strip">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="center">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBillNo"
                                ErrorMessage="Bill no is required" ValidationGroup="strip1">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="center">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCust"
                                ErrorMessage="Customer is requred" ValidationGroup="strip">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="center">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtArea"
                                ErrorMessage="Area is required" ValidationGroup="strip">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="center">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNoOfBundles"
                                ErrorMessage="No of bundles required" ValidationGroup="strip">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ID="btnClearEdit" CssClass="submitbtn" runat="server" Text="Clear"
                                Visible="False" OnClick="btnClearEdit_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="4">
                            <asp:Label ID="lblCustomer" runat="server" Font-Bold="true" Font-Size="10px" ForeColor="Blue"
                                Style="font-size: 11px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCustID" runat="server" Style="display: none;" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td colspan="6" style="display: none">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="strip" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <asp:Button Style="display: none;" ValidationGroup="strip" ID="btnSaveDetails" runat="server"
                    Text="Button" OnClick="btnSaveDetails_Click"/>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtCust" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Panel>

<asp:Panel ID="Panel1" runat="server" Width="480px">
    <asp:UpdatePanel ID="upDetails" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
             <asp:GridView ID="grdTemp" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alt"
                CellPadding="4" CssClass="product-table" OnRowDeleting="grdBookDetails_RowDeleting"
                OnRowEditing="grdTemp_RowEditing">
                <Columns>
                    <asp:TemplateField HeaderText="Spec. No">
                        <ItemTemplate>
                            <asp:Label runat="server" Style="display: none;" ID="lblSubID" Text='<%#Eval("SpecAutoId") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblDcNo" Text='<%#Eval("SpecNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bill No">
                        <ItemTemplate>
                            <asp:Label ID="lblBillNo" runat="server" Text='<%#Eval("BillNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="School Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Style="display: none;" ID="lblCustid" Text='<%#Eval("CustId") %>'></asp:Label>
                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustNam") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area">
                        <ItemTemplate>
                            <asp:Label ID="lblArea" runat="server" Text='<%#Eval("Area") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bundles" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNoOfBundles" runat="server" Text='<%#Eval("NoOfbundel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delivery">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkDelivery" runat="server" Checked='<%#Convert.ToBoolean(Eval("Delviery")) %>'>
                            </asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" ImageUrl="~/Images/icon/edit_icon.png" CommandName="edit"
                                runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Del." HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnRemove" ToolTip="Delete this record" ImageUrl="~/Images/icon/DeleteIcon.gif"
                                CommandName="delete" OnClientClick="return confirm('Are you sure want to remove this book');"
                                runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSaveDetails" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>


  <script type="text/javascript">
        function openShowpopMethod()
        {
                    document.getElementById('<%=btn_Edit.ClientID %>').click();
                    document.getElementById('<%=txtDocIdEdit.ClientID %>').value="";
                    document.getElementById('<%=txtDocIdEdit.ClientID %>').focus();
                    $find('<%=ModalPopUpDocNum.ClientID %>').show();
        }

            shortcut.add("Ctrl+E",function() {
               openShowpopMethod();         
            });

            shortcut.add("esc",function() {
                 closeEditPopup();      
            });

        function openEditPopup()
        {
        openShowpopMethod();
        return false;
        }
        function closeEditPopup()
        {
        $find('<%=ModalPopUpDocNum.ClientID %>').hide();
        }
    </script>
  <asp:Panel ID="PnlInsertDocNum" runat="server" Style="display: none;
        text-align: left; height: 140px;" DefaultButton="BtnGetDCDetails">
        <div class="facebox">
            <asp:Label ID="Label2" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
                ForeColor="White"></asp:Label>
            <a id="A1" class="close" style="right: 0;" runat="server" href="javascript:void(0);"
                onclick="closeEditPopup();">
                <img src="Images/button-cross.png" /></a>
            <br />
            <div class="content">
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDocNo12" runat="server" Font-Bold="true" Font-Size="12px" Text="Enter Speciman No : "
                                            CssClass="lbl-form"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDocIdEdit" ValidationGroup="get" onkeypress="return CheckNumeric(event)"
                                            runat="server" MaxLength="10" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="get"
                                            ControlToValidate="txtDocIdEdit">Enter Speciman No.</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="BtnGetDCDetails" CssClass="submitbtn" runat="server" ValidationGroup="get"
                                            Text="Get Details" OnClick="BtnGetDCDetails_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <ajaxCt:ModalPopupExtender ID="ModalPopUpDocNum" runat="server" TargetControlID="LnkBtn"
        PopupControlID="PnlInsertDocNum" BackgroundCssClass="modalBackground" DropShadow="false"
        EnableViewState="false" />
    <asp:LinkButton ID="LnkBtn" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
</asp:Content>

