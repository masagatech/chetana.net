<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DC__Returnbook.ascx.cs"
    Inherits="UserControls_ODC_uc_DC__Returnbook" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Src="../help/helpctrl.ascx" TagName="helpctrl" TagPrefix="uc1" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>Return Book <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
        <asp:GridView ID="GrdRD" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
            CellPadding="4" CssClass="product-table">
            <Columns>
                 <asp:TemplateField HeaderStyle-Width="80px" HeaderText="HSN Code">
                    <ItemTemplate>
                        <asp:Label ID="lblHSNCode" runat="server" Text='<%#Eval("HSNCode")%>'></asp:Label>
                        <asp:Label ID="lblGST" runat="server" Style="display: none;" Text='<%#Eval("GST")%>'></asp:Label>
                        <asp:Label ID="lblGstPer" runat="server" Style="display: none;" Text='<%#Eval("GSTPer")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Book Code">
                    <ItemTemplate>
                        <asp:Label ID="lblbkcode1" runat="server" Text='<%#Eval("bookcode")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Book name">
                    <ItemTemplate>
                        <asp:Label ID="lblname1" runat="server" Text='<%#Eval("bookname")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="60px" HeaderText="Price" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:Label ID="lblrate1" runat="server" HeaderStyle-HorizontalAlign="Left" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Discount(%)" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:Label ID="lbldiscount1" runat="server" HeaderStyle-HorizontalAlign="Left" Text='<%#Eval("Discount","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="40px" HeaderText="Qty" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:Label ID="lblqty1" runat="server" Style="text-align: right;" Text='<%#Eval("Qty")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Returned Qty" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:Label ID="lblrqty1" runat="server" Style="text-align: right;" Text='<%#Eval("ReturnQty") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="80px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
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
                <asp:TextBox ID="Txtgcn" CssClass="inp-form" Width="90px" runat="server" TabIndex="1"></asp:TextBox>
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
                        <asp:RequiredFieldValidator ID="Rqf1" runat="server" ErrorMessage="Require CN Date"
                            ValidationGroup="s1" ControlToValidate="txtCNDate">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100px">
                <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="SCN"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Txtscn" CssClass="inp-form" Width="90px" runat="server" TabIndex="2"></asp:TextBox>
                <ajaxCt:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers"
                    TargetControlID="Txtscn" ValidChars="." />
            </td>
            <td width="20">
            </td>
            <td width="80px">
                <asp:Label ID="Label4"  runat="server" CssClass="lbl-form"  Text=" L.R. No.  "></asp:Label>
            </td>
            <td>
                 <asp:TextBox ID="txtlrno" CssClass="inp-form" Width="100px" runat="server" Text=""
                                            TabIndex="2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="100px">
                <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Customer Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                    Width="90px" CssClass="inp-form" TabIndex="3" runat="server" OnTextChanged="txtcustomer_TextChanged"
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
             <asp:Label ID="Label5"  runat="server" CssClass="lbl-form"   Text="  Transporter   "></asp:Label>
                <%-- <asp:Button ID="btngetRec" Style="float: left;" CssClass="submitbtn" runat="server"
                    TabIndex="4" Text="Get Record" OnClick="btngetRec_Click" ValidationGroup="DCRB" />--%>
            </td>
            <td>
             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="lbltransporter" CssClass="inp-form" Width="100px" runat="server"
                                                    Enabled="true" Text="" TabIndex="1" AutoPostBack="true" OnTextChanged="lbltransporter_TextChanged"></asp:TextBox>
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
        <td></td>
           <td valign="top">
                <asp:TextBox ID="txtComment" TabIndex="1" Height="15px" ToolTip="Return Qty" Width="200px"
                    TextMode="MultiLine" CssClass="inp-form" runat="server"></asp:TextBox>
                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtComment"
                    WatermarkText="Comment">
                </ajaxCt:TextBoxWatermarkExtender>
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
<asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<asp:Panel ID="PnlAddBook" runat="server" DefaultButton="btnaddBooks">
    <table>
        <tr>
            <td valign="top">
            <asp:DropDownList AutoPostBack="true" CssClass="ddl-form" ID="DDLstandard" TabIndex="5"
                                runat="server" DataTextField="Value" DataValueField="AutoId" OnSelectedIndexChanged="DDLstandard_SelectedIndexChanged">
                            </asp:DropDownList>
                <asp:TextBox ID="txtbkcod" onfocus="setfocus('book');" onblur="setfocus('');" autocomplete="off"
                    TabIndex="4" CssClass="inp-form" runat="server" OnTextChanged="txtbkcod_TextChanged"
                    Width="240px"></asp:TextBox>
                <div id="divwidth" class="divauto">
                </div>
                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarktxtbook" runat="server" TargetControlID="txtbkcod"
                    WatermarkText="Enter BookCode to add  ">
                </ajaxCt:TextBoxWatermarkExtender>
                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbkcod"
                    UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
                </ajaxCt:AutoCompleteExtender>
            </td>
            <td valign="top">
                <asp:TextBox ID="txRetqty" TabIndex="5" ToolTip="Return Qty" Width="35px" AutoComplete="off"
                    CssClass="inp-form" Style="text-align: right;" MaxLength="6" onkeypress="return CheckNumeric(event)"
                    runat="server"></asp:TextBox>
                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txRetqty"
                    WatermarkText="Ret. Qty">
                </ajaxCt:TextBoxWatermarkExtender>
            </td>
          <%--  <td valign="top">
                <asp:TextBox ID="txtComment" TabIndex="6" Height="15px" ToolTip="Return Qty" Width="200px"
                    TextMode="MultiLine" CssClass="inp-form" runat="server" Visible="false"></asp:TextBox>
                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtComment"
                    WatermarkText="Comment">
                </ajaxCt:TextBoxWatermarkExtender>
            </td>--%>
            <td valign="top">
                <asp:Button ID="btnaddBooks" CssClass="submitbtn" runat="server" ValidationGroup="Date"
                    Text="Add" Width="70px" TabIndex="7" OnClick="btnaddBooks_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" Width="1000px">
    <div class="actiontab" style="margin-bottom: 6px;">
        <table align="right" width="300px" border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;">
            <tr>
                <td>
                    <asp:Label ID="LblPrintCN" runat="server" Width="65px" Text="Create CN : " Visible="false"
                        ></asp:Label>
                </td>
                <td align="left">
                    <asp:RadioButtonList ID="RdbtnYN" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                        Visible="false" Width="80px" OnSelectedIndexChanged="RdbtnYN_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="right" width="70px">
                    <asp:Button ID="btnClearGrid" CssClass="submitbtn" TabIndex="100" runat="server"
                        Text="Clear Grid" Width="80px" OnClick="btnClearGrid_Click" />
                    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="19" runat="server" Text="Save" OnClientClick="javascript:onSaveClick(this);" 
                        Width="80px" OnClick="btnSave_Click" ValidationGroup="s1" />
                    <asp:Button ID="btnGSTSave" CssClass="submitbtn" TabIndex="19" runat="server" Text="Save GST" OnClientClick="javascript:onSaveClick(this);" 
                        Width="80px" OnClick="btnGSTSave_Click" ValidationGroup="s1" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="Grd2" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" OnRowDataBound="Grd2_RowDataBound" TabIndex="8" 
        OnRowDeleting="Grd2_RowDeleting">
        <Columns>
             <asp:TemplateField HeaderStyle-Width="80px" HeaderText="HSN Code">
                <ItemTemplate>
                    <asp:Label ID="lblHSNCode" runat="server" Text='<%#Eval("HSNCode")%>'></asp:Label>
                    <asp:Label ID="lblGST" runat="server" Style="display: none;" Text='<%#Eval("GST")%>'></asp:Label>
                    <asp:Label ID="lblGstPer" runat="server" Style="display: none;" Text='<%#Eval("GSTPer")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Book Code">
                <ItemTemplate>
                    <asp:Label ID="lblbkcode" runat="server" Text='<%#Eval("bookcode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Book name">
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("bookname")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
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
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"
                HeaderText="Price">
                <ItemTemplate>
                    <asp:DropDownList ID="DDLR" runat="server" CssClass="ddl-form" DataTextField="Rate"
                        DataTextFormatString="{0:0.00}" Style="text-align: right;" TabIndex="11" Width="80px">
                    </asp:DropDownList>
                    <%--<asp:Label ID="lblrate"  runat="server" Text='<%#Eval("Rate","{0:0.00}") %>'></asp:Label>--%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="70px"
                HeaderText="Discount(%)">
                <ItemTemplate>
                    <asp:DropDownList ID="DDLD" runat="server" CssClass="ddl-form" DataTextField="Discount"
                        DataTextFormatString="{0:0.00}" Style="text-align: right;" TabIndex="11" Width="60px">
                    </asp:DropDownList>
                    <%--<asp:Label ID="lbldiscount"  runat="server" Text='<%#Eval("Discount","{0:0.00}") %>'></asp:Label>--%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="View" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:UpdatePanel ID="up11" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CssClass="close"
                                ImageUrl="../../Images/icon/view-icon.gif" OnClick="lblEdit_Click" ToolTip="View" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="60px" HeaderText="Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblqty2" runat="server" Style="text-align: right;" Text='<%#Eval("Qty")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="60px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Returned Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblavailable" runat="server" Style="display: none;" Text='<%#Eval("AvailableQty") %>'></asp:Label>
                    <asp:Label ID="lblrqty" runat="server" Style="text-align: right;" Text='<%#Eval("ReturnedQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Return Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="txtreturn" runat="server" AutoPostBack="True" CssClass="inp-form"
                        MaxLength="5" onblur='<%#"javascript:MsgMaxNumber(this,"+Eval("AvailableQty")+")"%>'
                        onkeypress="return CheckNumeric(event)" OnTextChanged="txtreturn_TextChanged"
                        Style="text-align: right;" TabIndex="12" Text='<%#Eval("AddedrQty") %>' Width="30px"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server"  FilterType="Custom, Numbers"
                        TargetControlID="txtreturn" ValidChars="+-=/*()." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Defect Qty" Visible="false"
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="txtDefect" runat="server" CssClass="inp-form" MaxLength="5" Style="text-align: right;"
                        TabIndex="13" Text="0" Width="30px">
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter1" runat="server" FilterType="Custom, Numbers"
                        TargetControlID="txtDefect" ValidChars="+-=/*()." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="CN Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="txtCN" runat="server" CssClass="inp-form" Text='<%#Eval("AddeCnQty") %>'  MaxLength="5" Style="text-align: right;"
                        TabIndex="14"  Width="30px">
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter2" runat="server" FilterType="Custom, Numbers"
                        TargetControlID="txtCN" ValidChars="+-=/*()." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Comment">
                <ItemTemplate>
                    <asp:TextBox ID="txtcmmt" Text='<%#Eval("Comment") %>' runat="server" CssClass="inp-form" Height="35px" TabIndex="15"
                        TextMode="MultiLine" Width="200px"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
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
        <AlternatingRowStyle CssClass="alt" />
    </asp:GridView>
</asp:Panel>
</ContentTemplate>
 </asp:UpdatePanel>
<asp:Panel ID="PnlRD" runat="server" Style="display: none;">
    <div class="facebox" width="300px">
        <asp:Label ID="Label9" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
            ForeColor="White"></asp:Label>
        <asp:ImageButton ID="lblEdit1" runat="server" CausesValidation="false" ToolTip="View"
            CssClass="close" OnClientClick="Closepopup()" ImageUrl="../../Images/button-cross.png" />
        <br />
       
    </div>
</asp:Panel>
<ajaxCt:ModalPopupExtender ID="modalPopupForRD" runat="server" TargetControlID="LinkBtn1"
    PopupControlID="PnlRD" OkControlID="lblEdit1" BackgroundCssClass="modalBackground"
    DropShadow="false" EnableViewState="false" />
<asp:LinkButton ID="LinkBtn1" Style="display: none;" runat="server">LinkButton</asp:LinkButton>
<asp:Panel ID="PnlPrint" runat="server" Width="900px">
    <%--<div class="actiontab">--%>
    <table width="900px" border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                <asp:Label ID="labelCNNo" runat="server" CssClass="lbl-form" Text="CreditNote No:"
                    Width="90px" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblCNNo" runat="server" CssClass="lbl-form" Width="30px"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="btnPrint" CssClass="submitbtn" TabIndex="12" runat="server" Text="Print"
                    Width="80px" OnClick="btnPrint_Click" ValidationGroup="DCRB" />
            </td>
        </tr>
    </table>
    <%--</div>--%>
    <p>
    </p>
    <asp:GridView ID="grdcn" CssClass="product-table" AutoGenerateColumns="false" ShowFooter="true"
        runat="server" Width="900px" CellPadding="2" OnRowDataBound="grdcn_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="HSN Code">
                <ItemTemplate>
                    <asp:Label ID="lblHSNCode" runat="server" Text='<%#Eval("HSNCode")%>'></asp:Label>
                    <asp:Label ID="lblGST" runat="server" Style="display: none;" Text='<%#Eval("GST")%>'></asp:Label>
                    <asp:Label ID="lblGstPer" runat="server" Style="display: none;" Text='<%#Eval("GSTPer")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
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
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="DCRB"
    runat="server" ID="ss" />
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="s1"
    runat="server" ID="cn" />

<script type="text/javascript">


shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_DC__Returnbook1_btnSave').click();
});

  function Closepopup()
   {
   
        $find('<%=modalPopupForRD.ClientID %>').hide();
    
   }

   function onSaveClick(id) {

       id.style.display = "none";
       return true;
   }
   
   
</script>

