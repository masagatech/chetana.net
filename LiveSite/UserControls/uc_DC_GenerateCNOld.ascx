<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DC_GenerateCN.ascx.cs"
    Inherits="UserControls_ODC_uc_DC_GenerateCN" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<%@ Register Src="../help/helpctrl.ascx" TagName="helpctrl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>Return Book <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
</div>
<p>
</p>
<asp:Panel ID="pnl1" CssClass="panelDetails" runat="server" Width="963px" Height="85px">
    <table>
        <tr>
            <td width="100px">
                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="GCN"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Txtgcn" Width="90px" runat="server" TabIndex="1"></asp:TextBox>
                <ajaxCt:FilteredTextBoxExtender ID="filter4" runat="server" FilterType="Custom, Numbers"
                    TargetControlID="Txtgcn" ValidChars="." />
            </td>
            <td width="20">
            </td>
            <td width="80px">
                <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="CN Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpPnldate1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCNDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                            Enabled="true" AutoPostBack="True" OnTextChanged="txtCNDate_TextChanged"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCNDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtCNDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require CN Date"
                            ValidationGroup="S" ControlToValidate="txtCNDate">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="80px">
                <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="SCN"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Txtscn" Width="90px" runat="server" TabIndex="3"></asp:TextBox>
                <ajaxCt:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers"
                    TargetControlID="Txtscn" ValidChars="." />
            </td>
            <td width="20">
            </td>
            <td width="80px">
             <asp:Label ID="Label5"  runat="server" CssClass="lbl-form"  Text=" L.R. No.  "></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtlrno" CssClass="inp-form" Width="100px" runat="server" Text=""
                                            TabIndex="4"></asp:TextBox>
            </td>
             <td width="80px">
             <asp:Label ID="Label7"  runat="server" CssClass="lbl-form"   Text="  Transporter   "></asp:Label>
                <%-- <asp:Button ID="btngetRec" Style="float: left;" CssClass="submitbtn" runat="server"
                    TabIndex="4" Text="Get Record" OnClick="btngetRec_Click" ValidationGroup="DCRB" />--%>
            </td>
             <td>
             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="lbltransporter" CssClass="inp-form" Width="100px" runat="server"
                                                    Enabled="true" Text="" TabIndex="6" AutoPostBack="true" OnTextChanged="lbltransporter_TextChanged"></asp:TextBox>
                                                <div id="divtrasport" class="divauto">
                                                </div>
                                                <ajaxCt:AutoCompleteExtender ID="ACExttransporter" runat="server" DelimiterCharacters=""
                                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="lbltransporter"
                                                    UseContextKey="true" ContextKey="transporter" CompletionListElementID="divtrasport">
                                                </ajaxCt:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100px">
                <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Customer Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                    Width="80px" CssClass="inp-form" TabIndex="5" runat="server" OnTextChanged="txtcustomer_TextChanged"
                    AutoPostBack="True" MaxLength="15"></asp:TextBox>
                <div id="dvcust" class="divauto350">
                </div>
                <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                    UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                </ajaxCt:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RFVCust1" runat="server" ErrorMessage="Require Customer Code"
                    ValidationGroup="DCRB" ControlToValidate="txtcustomer">.</asp:RequiredFieldValidator>
            </td>
            <td width="20">
            </td>
            <td width="80px">
                <asp:Button ID="btngetRec" Style="float: left;" CssClass="submitbtn" runat="server"
                    TabIndex="7" Text="Add Record" OnClick="btngetRec_Click" ValidationGroup="DCRB" />
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td height="30" width="100px">
                    </td>
                    <td>
                        <asp:Label ID="lblCustName" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"
                            Width="650px"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtcustomer" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>
<p>
</p>
<asp:Panel ID="PnlAddbk" runat="server" Width="1003px">
    <table>
        <tr>
            <%--         <td colspan="4">
                <asp:Panel runat="server" ID="Panel1" DefaultButton="btngetset">
                    <asp:DropDownList CssClass="ddl-form" Width="160px" ID="DDLSelectSet" TabIndex="15"
                        runat="server" DataTextField="Value" DataValueField="AutoId">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtsetqty" TabIndex="16" Width="30px" CssClass="inp-form" Style="text-align: right;"
                        MaxLength="3" onkeypress="return CheckNumeric(event)" runat="server"></asp:TextBox>
                    <asp:Button ID="btngetset" CssClass="form-submit" TabIndex="17" runat="server" Style="display: none;"
                        ValidationGroup="Date" Text="Get" Width="70px" OnClick="btngetset_Click" />
                </asp:Panel>
            </td>--%>
            <td>
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="PnlAddBook" runat="server" DefaultButton="btnaddBooks">
                            <asp:DropDownList AutoPostBack="true" CssClass="ddl-form" ID="DDLstandard" TabIndex="5"
                                runat="server" DataTextField="Value" DataValueField="AutoId" OnSelectedIndexChanged="DDLstandard_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtbkcod" onfocus="setfocus('book');" onblur="setfocus('');" autocomplete="off"
                                TabIndex="6" CssClass="inp-form" runat="server" OnTextChanged="txtbkcod_TextChanged"
                                Width="240px"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarktxtbook" runat="server" TargetControlID="txtbkcod"
                                WatermarkText="Enter BookCode to add  ">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <asp:TextBox ID="txtbookqty" TabIndex="7" Width="30px" AutoComplete="off" CssClass="inp-form"
                                Style="text-align: right;" MaxLength="4" onkeypress="return CheckNumeric(event)"
                                runat="server"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtbookqty"
                                WatermarkText="Qty">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <div id="divwidth" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbkcod"
                                UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
                            </ajaxCt:AutoCompleteExtender>
                            <asp:Button ID="btnaddBooks" CssClass="form-submit" runat="server" ValidationGroup="Date"
                                Text="Add" Width="70px" TabIndex="8" Style="display: none;" OnClick="btnaddBooks_Click" />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLstandard" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <%--<a href="Javascript:Openpopup(1);">Add Books</a>--%>
            </td>
            <td width="535px">
            </td>
            <td>
                <asp:Button ID="btn_Save" Style="float: right;" CssClass="submitbtn" ValidationGroup="s2"
                    TabIndex="14" runat="server" Text="Save" Width="80px" OnClick="btn_Save_Click" />
            </td>
        </tr>
    </table>
    <p>
    </p>
    <asp:UpdatePanel ID="upGridData" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grdBookDetails" runat="server" AlternatingRowStyle-CssClass="alt"
                AutoGenerateColumns="False" TabIndex="24" CssClass="product-table" Width="1000px"
                OnRowDataBound="grdBookDetails_RowDataBound" OnRowDeleting="grdBookDetails_RowDeleting"
                ShowFooter="false">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Book Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDCDetailID" runat="server" Style="display: none;" Text='<%#Eval("DCDetailID")%>'></asp:Label>
                            <asp:Label ID="lblBookCode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Book Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-Width="20px" HeaderText="Return Qty"
                        ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:TextBox ID="txtretquty" runat="server" MaxLength="3" TabIndex="9" onkeypress="return CheckNumeric(event)"
                                Style="text-align: right;" Text='<%#Eval("ReturnQty")%>' Width="40px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotalretqty" runat="server" CssClass="totalrtQty" Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-Width="20px" HeaderText="Defect Qty"
                         Visible ="false" ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:TextBox ID="txtdefquty" runat="server" MaxLength="3" TabIndex="10" onkeypress="return CheckNumeric(event)"
                                Style="text-align: right;" Text='<%#Eval("DefectQty")%>' Width="40px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotaldefqty" runat="server" CssClass="totaldfQty" Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-Width="20px" HeaderText="CN Qty"
                        ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:TextBox ID="txtquty" runat="server" MaxLength="3" TabIndex="10" onkeypress="return CheckNumeric(event)"
                                Style="text-align: right;" Text='<%#Eval("RemainQty")%>' Width="40px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotalqty" runat="server" CssClass="totalQty" Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"
                        HeaderText="Rate" ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:TextBox ID="txtrate" runat="server" MaxLength="6" TabIndex="11" onkeypress="return CheckNumericWithDot(event)"
                                Style="text-align: right;" Text='<%#Eval("Rate","{0:0.00}")%>' Width="50px"></asp:TextBox>
                            <asp:Label ID="lblRate" runat="server" Style="text-align: right; display: none" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="20px" HeaderText="Dis.(%)" ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDiscount" runat="server" onkeydown="setAmtclass(this)" onkeypress="return CheckNumericWithDot(event)"
                                Style="text-align: right;" TabIndex="12" Text='<%#Eval("Discount")%>' Width="40px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"
                        Visible="true" HeaderStyle-Width="80px" HeaderText="Amount" ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lblAmt" runat="server" Style="text-align: right;" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                            <asp:Label ID="txtAddDiscount" runat="server" Style="text-align: right; display: none;"
                                Text='<%#Eval("AdditionalDiscount")%>' Width="20px"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotalamt" runat="server" CssClass="totalAmt" Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment" HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtcmmt" CssClass="inp-form" TabIndex="13" Width="100px" Height="20px"
                                runat="server" TextMode="MultiLine"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="80px"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Remove" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnRemove" runat="server" CommandName="delete" ImageUrl="~/Images/icon/DeleteIcon.gif"
                                OnClientClick="return confirm('Are you sure want to remove this book');" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblTotalqtyId" Style="display: none" runat="server" CssClass="inp-form"></asp:Label>
            <asp:Label ID="lblTotalamtId" Style="display: none" runat="server" CssClass="inp-form"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnaddBooks" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>
<asp:Panel ID="PnlPrint" runat="server" Width="900px">
    <%--<div class="actiontab">--%>
    <table width="900px" border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                <asp:Label ID="labelCNNo" runat="server" CssClass="lbl-form" Text="CreditNote No :"
                    Width="110px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCNNo" runat="server" CssClass="lbl-form" Width="30px" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="Customer Name :"
                    Width="110px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCustName1" runat="server" CssClass="lbl-form" Width="500px" Font-Bold></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="Customer Address :"
                    Width="110px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCustAddress" runat="server" CssClass="lbl-form" Width="800px" Font-Bold></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="btnPrint" CssClass="submitbtn" TabIndex="15" runat="server" Text="Print"
                    Width="80px" OnClick="btnPrint_Click" ValidationGroup="DCRB" />
            </td>
        </tr>
    </table>
    <%--</div>--%>
    <p>
    </p>
    <asp:GridView ID="grdcn" CssClass="product-table" AutoGenerateColumns="false" ShowFooter="true"
        runat="server" Width="1000px" CellPadding="2" OnRowDataBound="grdcn_RowDataBound">
        <Columns>
            <%--<asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" >
        <ItemTemplate>
            <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
        </ItemTemplate>
       </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="PARTICULARS" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="450px">
                <ItemTemplate>
                    <asp:Label ID="lblbkname" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbltotal" Style="text-align: right; font-weight: bold;" runat="server"
                        Text="Total: "></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QTY" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Right"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblqty" runat="server" Text='<%#Eval("ReturnQty")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbltqty" Style="text-align: right; font-weight: bold;" runat="server"
                        Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="MEDIUM" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
            </ItemTemplate>
           </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="PRICE" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DISCOUNT(%)" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'
                        HeaderStyle-HorizontalAlign="Left"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AMOUNT" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Right"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblamt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbltamt" Style="text-align: right; font-weight: bold;" runat="server"
                        Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NET AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"
                HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblnamt" Style="text-align: right;" runat="server" Text='<%#Eval("NetAmount","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbltnamt" Style="text-align: right; font-weight: bold;" runat="server"
                        Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="s2"
    runat="server" ID="gcn" />

<script type="text/javascript">

shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_btn_Save').click();
});

shortcut.add("Ctrl+A",function() {
  document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_txtbkcod').focus();
});

shortcut.add("esc",function() {

Closepopup(2)
});

  function Openpopup(id)
   {
    if(id==1)
     {
        $find('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_modalPopupForBooks').show();
         document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_txtbkcod').value="";
        document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_txtbkcod').focus();
     }
     if(id==2)
     {
        $find('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_ModalPopUpDocNum').show();
        document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_TxtDocNo').focus();
     }
   }
   function Closepopup(id)
   {
    if(id==1)
     {
        $find('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_modalPopupForBooks').hide();
     }
     if(id==2)
     {
        $find('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_ModalPopUpDocNum').hide();
     }
   }
   
   function clearAddbook()
   {
       document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_txtbkcod').value="";
       document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_txtbkcod').focus();
       document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_GenerateCN1_txtbookqty').value="";
   }
   
   setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+A : Add book ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
document.getElementById('status').innerHTML=status;

}
function multiplyQty(id,id1,id2,disc)
{
var Qty = document.getElementById(id).value;
var Rate = document.getElementById(id1).value;

var Amt = 0;
var disc = parseFloat(document.getElementById(disc).value);

var totalQtyId = "";
var totalAmtID = "";

var totalQty = 0;
var totalAmt = 0;


    //  var adddisc1 = parseFloat(adddisc.innerHTML);
    var newdisc = disc;
    var discountprice= (Qty * Rate) * (disc /100);
   
      //id1.innerHTML * id.value;        
   document.getElementById(id2).innerHTML  = (Qty * Rate)- discountprice;
   
   document.getElementById(id2).innerHTML =document.getElementById(id2).innerHTML ;
   
   totalQtyId = document.getElementById("<%=lblTotalqtyId.ClientID %>").innerHTML;
   totalAmtID = document.getElementById("<%=lblTotalamtId.ClientID %>").innerHTML;
   
   totalQty = document.getElementById(totalQtyId).innerHTML;
   totalAmt = document.getElementById(totalAmtID).innerHTML;
   
   if(totalQty >=0)
   {
       totalQty = parseInt(totalQty) + parseInt(Qty);
       document.getElementById(totalQtyId).innerHTML = totalQty;
   }
   if(totalAmt >=0)
   {
   totalAmt = parseFloat(totalAmt) + ((Qty * Rate)- discountprice);
   document.getElementById(totalAmtID).innerHTML = totalAmt;
   TOTAL();
   }
}

</script>

<script type="text/javascript">

 function TOTAL()
   {
     var gridview = document.getElementById('<%=grdBookDetails.ClientID %>')
     
     var RtQty =0;
     var DfQty =0;
     var TotalRtQty =0; 
     var TotalDfQty =0;
     
     var Qty = 0;
     var ToatalQty = 0 ;
     var amount = 0 ;
     var totalAmt = 0
     var Rate= 0;
     var TotalRate= 0;
     var Disc=0;
     var TotalDisc=0;
     
		                for (var r = 1; r < gridview.rows.length-1; r++){
		                
		                    RtQty  = $(gridview.rows[r].cells[4]).find('input:text').attr("value");
		                  //  DfQty  = $(gridview.rows[r].cells[5]).find('input:text').attr("value");
		                
		                    Qty  = $(gridview.rows[r].cells[6]).find('input:text').attr("value");
			                Rate  = $(gridview.rows[r].cells[7]).find('input:text').attr("value");
			               // Disc  = $(gridview.rows[r].cells[7]).find('input:text').attr("value");
			               
			                totalAmt = totalAmt + parseFloat(gridview.rows[r].cells[9].innerHTML.replace(/<[^>]+>/g,""));
			               // TotalDisc = TotalDisc + parseFloat(Disc);
			               TotalRtQty = TotalRtQty + parseInt(RtQty);
			             //  TotalDfQty = TotalDfQty + parseInt(DfQty);
			               
			                ToatalQty = ToatalQty + parseInt(Qty);
			                TotalRate = TotalRate + parseFloat(Rate)
			               // totalAmt = totalAmt + parseFloat((ToatalQty * TotalRate) - ((ToatalQty * TotalRate) * (TotalDisc/100)));
			                
			               // ele  = $(gridview.rows[r].cells[4]).find('input:text').attr("value");
		          //            alert(ele);
		                }
		                   // amount = ((ToatalQty * TotalRate * TotalDisc)/100)
		                    //totalAmt =(ToatalQty * TotalRate) - amount
		                
		                      $('.totalrtQty').html(TotalRtQty.toString());
		                     // $('.totaldfQty').html(TotalDfQty.toString());
		                
		                      $('.totalQty').html(ToatalQty.toString());
		                      $('.totalAmt').html(totalAmt.toString());
                                
   }

</script>

<script type="text/javascript">
function SetMaxNum(id01,id0)
{   
    var q1 = document.getElementById(id01).value;
    var q2 = document.getElementById(id0).value;
   
    var max = q2;
     if(q1 > max)
     {
        //sloder('Quantity Exceeds Return Qty..')
        alert('Quantity Exceeds Return Qty..')
        
        q1 = max;
         document.getElementById(id01).value = max
        id01.focus();
     } 
}
</script>

