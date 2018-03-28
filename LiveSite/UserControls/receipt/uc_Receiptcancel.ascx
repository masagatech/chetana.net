<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Receiptcancel.ascx.cs"
    Inherits="UserControls_Receiptcancel" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
      Transaction > ReceiptCancelBook <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>

<div style="float: left;  width:695px; margin-bottom:5px;">
   
    <asp:Panel ID="pnlbutt" runat="server">
       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <asp:Button ID="btn_Save" CssClass="submitbtn" ValidationGroup="Discount" TabIndex="5"
            runat="server" Text="Cancel" Width="80px" style="float:right" OnClick="btn_Save_Click1" />
            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="ct"
            runat="server" ID="ValidationSummary1" />
        <asp:Button ID="view" CssClass="submitbtn" ValidationGroup="ct" TabIndex="3"  style="float:right; margin-right:5px;" runat="server" Text="Get"
            Width="80px" OnClick="view_Click" />
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Discount"
            runat="server" ID="ss" />
        </ContentTemplate>
           <Triggers>
               <asp:AsyncPostBackTrigger ControlID="redio" EventName="SelectedIndexChanged" />
           </Triggers>
    </asp:UpdatePanel>
    </asp:Panel>
   
</div>
<br />
<br />
<br />
<asp:Panel ID="pnlCust" CssClass="panelDetails" runat="server" Width="658px">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" >
                        <asp:RadioButtonList ID="redio" TabIndex="1" RepeatDirection="Horizontal" runat="server" Width="200px"
                            AutoPostBack="true" Visible="true" OnSelectedIndexChanged="redio_SelectedIndexChanged">
                            <asp:ListItem Selected="True"  Value="Single" Text="SingleCancel">SingleCancel</asp:ListItem>
                            <asp:ListItem  Value="Multiple" Text="MultipleCancel">MultipleCancel</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="MR Code"></asp:Label>
                        <font color="red">*</font>
                        <br />
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtEMcode" autocomplete="off" Width="150px" CssClass="inp-form"
                                    TabIndex="2" runat="server" AutoPostBack="true" OnTextChanged="txtEMcode_TextChanged"></asp:TextBox>
                                <asp:Label ID="lblshow" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"></asp:Label>
                                <div id="dvcust" class="divauto">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                    ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtEMcode"
                                    UseContextKey="true" ContextKey="salesman" CompletionListElementID="dvcust">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="rfvcust" runat="server" ErrorMessage="Enter M R Code"
                                    ValidationGroup="Discount" ControlToValidate="txtEMcode">.</asp:RequiredFieldValidator>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter M R Code"
                                    ValidationGroup="ct" ControlToValidate="txtEMcode">.</asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <asp:Panel ID="PnlCustDiscDetails" runat="server" Width="658px"
        CssClass="pnldash">
        <asp:UpdatePanel ID="Upanelno" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="60px">
                            <asp:Label ID="lblFrom" runat="server" CssClass="lbl-form" Text="FromNo"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="3" Width="82px" AutoPostBack="true"
                                runat="server" AutoComplete="off" onkeypress="return CheckNumeric(event)" OnTextChanged="txtFrom_TextChanged"
                                MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqChequeNo" runat="server" ErrorMessage="Enter From No"
                                ValidationGroup="Discount" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter From No"
                                ValidationGroup="ct" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
                        </td>
                        <td width="35px">
                            <asp:Label ID="lblTo" runat="server" CssClass="lbl-form" Text="ToNo"></asp:Label>
                            <span runat="server" id="restrict" visible="false"><font color="red">*</font></span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTo" Width="82px" CssClass="inp-form" AutoComplete="off" TabIndex="4" runat="server"
                                onkeypress="return CheckNumeric(event)" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqChequeDate" runat="server" ErrorMessage="Enter To No"
                                ValidationGroup="Discount" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter To No"
                                ValidationGroup="ct" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                        </td>
                        <td width="60px">
                            <asp:Label ID="lblReion" runat="server" CssClass="lbl-form" Text="Reason"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtResion" AutoComplete="off" Width="150px" CssClass="inp-form" TabIndex="5" runat="server"
                                TextMode="MultiLine">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Reason"
                                ValidationGroup="Discount" ControlToValidate="txtResion">.</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="redio" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btn_Save" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Panel>
<div id="div" runat="server"></div>
    <asp:Panel ID="UpanelGrd" UpdateMode="Conditional" runat="server" CssClass="panelDetails"
        Width="631px" Height="18px">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle">
                    <asp:Label ID="lblname" runat="server" Style="display: none"></asp:Label>
                    <asp:Label ID="lblempid" runat="server" CssClass="lbl-form" Text="MR Code"></asp:Label>
                    <span style="color: Red">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="True" Height="22px" Style="margin-left: 0px"
                        OnTextChanged="txtempcode_TextChanged"></asp:TextBox>
                    <asp:Label ID="lblempname" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                        runat="server"></asp:Label>
                    <div id="Div2" class="divauto">
                    </div>
                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                        ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                        CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtempcode"
                        UseContextKey="true" ContextKey="salesman" CompletionListElementID="dvsalesman">
                    </ajaxCt:AutoCompleteExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter MR Code"
                        ValidationGroup="ct" Text="." ControlToValidate="txtempcode"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GrdViewRegion" runat="server" CssClass="product-table" AutoGenerateColumns="false"
                        ForeColor="#333333" PageSize="100" Width="650px">
                        <Columns>
                            <asp:TemplateField HeaderText="Receipt No" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("AutoCancelRecNo") %>' Style="display: none"></asp:Label>
                                    <asp:Label ID="lblEmpId" runat="server" Style="display: none" Text='<%#Eval("EmpID")%>'></asp:Label>
                                    <asp:Label ID="lblFromNo" runat="server" Text='<%#Eval("ReciptNo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                             <asp:TemplateField HeaderText="Canceled Date" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblToNo" runat="server" Text='<%#Eval("CreatedOn")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Canceled By" HeaderStyle-Width="60px" >
                                <ItemTemplate>
                                    <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("CreatedBy")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Reason" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:Label ID="lblToNo" runat="server" Text='<%#Eval("Resion")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

</asp:Panel>
<br />
<asp:UpdatePanel ID="multipal" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="Pnlmultiplecancel" runat="server">
            <asp:GridView ID="gvMultipleCancel" runat="server" CssClass="product-table" AutoGenerateColumns="false"
                ForeColor="#333333" PageSize="100" Width="650px" OnSelectedIndexChanged="gvMultipleCancel_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Select" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox Visible='<%#Convert.ToBoolean(Eval("forcancel")) %>' ID="check" runat="server" Checked='<%#Convert.ToBoolean(Eval("checkStatus"))%>'
                                Enabled='<%#Convert.ToBoolean(Eval("forcancel")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ReceiptNo" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%--  <asp:Label ID="lblid" runat="server" Text='<%#Eval("EmpID") %>' Style="display: none"></asp:Label>--%>
                            <asp:Label ID="lblEmpId" runat="server" Style="display: none" Text='<%#Eval("EmpCode")%>'></asp:Label>
                            <asp:Label ID="lblFromNo" runat="server" Text='<%#Eval("RNo")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblreceipt" runat="server" Text='<%#Eval("RStatus")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reason" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="remarktext" Visible='<%#Convert.ToBoolean(Eval("textvisible")) %>' Text='<%#Eval("Comment")%>' Enabled='<%#Convert.ToBoolean(Eval("forcancel")) %>'
                                runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px">
                        <ItemTemplate>
                            
                            <asp:ImageButton ID="imgview" runat="server" ImageUrl="../../../Images/icon/view-icon.gif"
                                CssClass="close" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
              
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="redio" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="btn_Save" EventName="Click" />
         <asp:AsyncPostBackTrigger ControlID="view" EventName="Click" />
    </Triggers>
   
</asp:UpdatePanel>

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
document.getElementById('ctl00_ContentPlaceHolder1_uc_Receiptcancel1_btn_Save').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>
