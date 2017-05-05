<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CN.ascx.cs" Inherits="Godown_CN" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <td>
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
            </a>
        </div>
        <div class="options">
        </div>
    </td>
</div>
<div style="float: left; width: 490px">
    <asp:Button ID="btnClear" Style="float: right; margin: 0px 0px 0px 2px" CssClass="submitbtn"
        OnClientClick="javascript:return confirm('Wish to clear this data');" TabIndex="14"
        ToolTip="Clear all fields" Visible="false" runat="server" Text="Cancel" Width="80px"
        OnClick="btnClear_Click" />
    <asp:Button ID="btnDelete" Style="float: right; color: Red; margin: 0px 2px 0px 2px"
        CssClass="submitbtn" OnClientClick="javascript:return confirm('Wish to delete this data');"
        TabIndex="14" ToolTip="Delete the below data" Visible="false" runat="server"
        Text="Delete" Width="80px" OnClick="btnDelete_Click" ValidationGroup="cn" />
    <asp:Button ID="btn_Edit" Visible="false" Style="float: right; margin: 0px 2px 0px 2px"
        CssClass="submitbtn" OnClientClick="javascript:return openEditPopup();" TabIndex="14"
        ToolTip="Edit the data" runat="server" Text="Edit" Width="80px" />&nbsp;
    <asp:Button ID="btn_Save" Visible="false" Style="float: right; margin: 0px 2px 0px 2px"
        CssClass="submitbtn" TabIndex="14" ToolTip="Save below data"
        runat="server" Text="Save" Width="80px" OnClick="btn_Save_Click" />&nbsp;
    <asp:Label ID="lblmsg0" runat="server" Text=" "></asp:Label>
    <asp:Label ID="lblDocNo" Style="display: none;" runat="server"></asp:Label>
</div>
<br />
<br />
<asp:Panel ID="pnlAddForm" CssClass="panelDetails" DefaultButton="btnSaveDetails" runat="server" Width="450px">
    <asp:UpdatePanel ID="upCustomerName0" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                      <asp:Label ID="lblEditMode" style="display:none;" runat="server" Text="add"></asp:Label>
                            <asp:Label ID="lblGcnId" style="display:none;" runat="server" Text="0"></asp:Label>
                            <asp:Label ID="RowID" style="display:none;" runat="server" Text="0"></asp:Label>
                        <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text="GCN No."></asp:Label>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="txtGCNNo" AutoPostBack="true" CssClass="inp-form" runat="server"
                                    OnTextChanged="txtGCNNo_TextChanged"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="GCN NO. Required"
                            ControlToValidate="txtGCNNo" ValidationGroup="cn">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGCNDate" runat="server" CssClass="inp-form"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtGCNDate" />
                        <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" AcceptAMPM="true" AutoComplete="true"
                            CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                            TargetControlID="txtGCNDate" />
                        (dd/mm/yyyy)
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Sales Representative"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtSalesREp" CssClass="inp-form" runat="server" Width="206px"></asp:TextBox>
                        &nbsp; &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="School"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="txtSchool" CssClass="inp-form" runat="server" OnTextChanged="txtSchool_TextChanged"
                                    AutoPostBack="True" Width="206px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSchool"
                                    ErrorMessage="School Required" ValidationGroup="cn">*</asp:RequiredFieldValidator>
                                <div id="dvcust" class="divauto350">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" CompletionInterval="100"
                                    CompletionListCssClass="AutoExtender" CompletionListElementID="dvcust" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="customer"
                                    DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                                    ServiceMethod="GetGodownCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtSchool"
                                    UseContextKey="true">
                                </ajaxCt:AutoCompleteExtender>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtSchool" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:UpdatePanel ID="upCustomerName" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Label ID="lblCustomer" runat="server" Font-Bold="true" Font-Size="10px" ForeColor="Blue"
                                    Style="font-size: 11px"></asp:Label>
                                <asp:Label ID="lblSchoolID" runat="server" Style="display: none;"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtSchool" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Area"></asp:Label>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="txtArea" CssClass="inp-form" runat="server"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtSchool" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
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
                        <asp:Label ID="Label6" runat="server" Text="Salesman CN. No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSalesManRecNo" CssClass="inp-form" runat="server"></asp:TextBox>
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
                        <asp:Label ID="Label16" runat="server" Text="Narration"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNarration" runat="server" CssClass="inp-form" Height="43px" TextMode="MultiLine"
                            Width="203px"></asp:TextBox>
                    </td>
                    <td valign="bottom" style="padding-left:5px;"> <asp:Button Visible="false" CssClass="submitbtn"  ValidationGroup="strip" ID="btnSaveDetails" runat="server"
                Text="Add" OnClick="btnSaveDetails_Click" /></td>
                </tr>
                
            </table>
           
        </ContentTemplate>    
         <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtSchool" EventName="TextChanged" />
            </Triggers>   
    </asp:UpdatePanel>

    <script type="text/javascript">
        
        
        
                setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+S : Save ]&nbsp;&nbsp;&nbsp;[ Ctrl+E : Edit Order ]&nbsp;&nbsp;&nbsp;[ Ctrl+M : Side Menu(tab) ]";
document.getElementById('status').innerHTML=status;

}
        
        shortcut.add("Ctrl+S",function() {
            document.getElementById('<%=btn_Save.ClientID %>').click();
});


shortcut.add("Ctrl+E",function() {
   openShowpopMethod();         
});

shortcut.add("esc",function() {
     closeEditPopup();      
});

function openShowpopMethod()
{
            document.getElementById('<%=btn_Edit.ClientID %>').click();
            document.getElementById('<%=txtDocIdEdit.ClientID %>').value="";
            document.getElementById('<%=txtDocIdEdit.ClientID %>').focus();
            $find('<%=ModalPopUpDocNum.ClientID %>').show();
}

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

</asp:Panel>
<br />
<br />
<asp:Panel ID="Panel1" runat="server" Width="480px">
    <asp:UpdatePanel ID="upDetails" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="grdTemp" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alt"
                CellPadding="4" CssClass="product-table" OnRowDeleting="grdTemp_RowDeleting"
                OnRowEditing="grdTemp_RowEditing">
                <Columns>
                    <asp:TemplateField HeaderText="GCN No">
                        <ItemTemplate>
                            <asp:Label runat="server" style="display:none;" ID="lblgID" Text="0"></asp:Label>
                            <asp:Label runat="server" style="display:none;" ID="lblnewid" Text='<%#Eval("GCN_ID") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblGCN_NO" Text='<%#Eval("GCN_NO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="GCN Date">
                        <ItemTemplate>
                            <asp:Label ID="lblGCN_Date" runat="server" Text='<%#Eval("GCN_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sales Reps">
                        <ItemTemplate>
                            <asp:Label ID="lblSALES_REP" runat="server" Text='<%#Eval("SALES_REP") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="School Name">
                        <ItemTemplate>
                         <asp:Label runat="server" style="display:none;" ID="lblSCHL_ID" Text='<%#Eval("SCHL_ID") %>'></asp:Label>
                            <asp:Label ID="lblSCHL_NAME" runat="server" Text='<%#Eval("SCHL_NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area">
                        <ItemTemplate>
                            <asp:Label ID="lblSCHL_AREA" runat="server" Text='<%#Eval("SCHL_AREA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sales CN No" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblSALES_CN_NO" runat="server" Text='<%#Eval("SALES_CN_NO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Narration">
                        <ItemTemplate>
                           <asp:Label ID="lblNAR" runat="server" Text='<%#Eval("NAR") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" ImageUrl="~/Images/icon/edit_icon.png" CommandName="edit"
                                runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
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
<asp:Panel ID="PnlInsertDocNum" runat="server" DefaultButton="BtnGetDCDetails" Style="display: none;
    text-align: left; height: 140px;">
    <div class="facebox">
        <asp:Label ID="Label15" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
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
                                    <asp:Label ID="lblDocNo12" runat="server" Font-Bold="true" Font-Size="12px" Text="GCN No : "
                                        CssClass="lbl-form"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDocIdEdit" ValidationGroup="get" runat="server" MaxLength="10"></asp:TextBox>
                                    <%--onkeypress="return CheckNumeric(event)"--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="get"
                                        ControlToValidate="txtDocIdEdit">Enter Order No.</asp:RequiredFieldValidator>
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