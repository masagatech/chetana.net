<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Edit_PurchaseMasterVat.aspx.cs" Inherits="Edit_PurchaseMasterVat" Title="Edit Purchase Entry" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            Edit Purchase Master<a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
    <div style="float: right; width: 53%">
        <asp:Button ID="btn_Save" CssClass="submitbtn" ValidationGroup="ct1" TabIndex="10"
            runat="server" Text="Save" Width="87px" OnClick="btn_Save_Click" />
    </div>
    <br />
    <br />
    <asp:Panel ID="pnlpurch" CssClass="panelDetails" runat="server" Width="800px" Height="160px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="Purchase Code"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td>
                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                            <asp:TextBox ID="txtPurchase" autocomplete="off" Width="150px" CssClass="inp-form"
                                TabIndex="1" runat="server" AutoPostBack="true" Height="15px" OnTextChanged="txtPurchase_TextChanged"></asp:TextBox>
                            <div id="Div2" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtPurchase"
                                UseContextKey="true" ContextKey="VatAccountPur" CompletionListElementID="Div2">
                            </ajaxCt:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="rfvcust" runat="server" ErrorMessage="Require Purchase Name"
                                ValidationGroup="ct1" ControlToValidate="txtPurchase">.</asp:RequiredFieldValidator>
                            <asp:Label ID="lblpurchase" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="100px">
                            <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                            <asp:Label ID="lblID1" runat="server" Style="display: none;"></asp:Label>
                            <asp:Label ID="lblInvoce" runat="server" CssClass="lbl-form" Text="Invoice No."></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInvAlfa" ToolTip="text from invoice no." Width="50px" TabIndex="2"
                                autocomplete="off" MaxLength="8" runat="server" CssClass="inp-form"></asp:TextBox>
                            <asp:TextBox ID="txtInvoiceNo" autocomplete="off" Width="150px" CssClass="inp-form"
                                TabIndex="2" runat="server" Height="15px" AutoPostBack="true" onkeypress="return CheckNumeric(event)"
                                OnTextChanged="txtInvoiceNo_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqfi" runat="server" ValidationGroup="ct1" ErrorMessage="Enter Invoice NO"
                                ControlToValidate="txtInvoiceNo">.</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSupplier" runat="server" CssClass="lbl-form" Text="Supplier Code"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td>
                            <%--<asp:UpdatePanel ID="hh" runat="server">
                    <ContentTemplate>--%>
                            <asp:TextBox ID="txtSupplier" AutoComplete="off" Width="150px" CssClass="inp-form"
                                TabIndex="3" runat="server" Height="15px" AutoPostBack="true" OnTextChanged="txtSupplier_TextChanged1">
                            </asp:TextBox>
                            <div id="Div2" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtSupplier"
                                UseContextKey="true" ContextKey="VatAccountSup" CompletionListElementID="Div2">
                            </ajaxCt:AutoCompleteExtender>
                            <asp:Label ID="lblshow" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Supplier"
                                ValidationGroup="ct1" ControlToValidate="txtSupplier">.</asp:RequiredFieldValidator>
                            <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDate" runat="server" CssClass="lbl-form" Text="Invoice Date"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" onblur="ValidInYearDate(this);" AutoComplete="off" Width="150px"
                                CssClass="inp-form" TabIndex="3" runat="server" Height="15px">
                            </asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                TargetControlID="txtDate" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Date"
                                ValidationGroup="ct1" ControlToValidate="txtDate">.</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="Vat(%)"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlmsoms" Width="120px" TabIndex="3" runat="server" OnSelectedIndexChanged="ddlmsoms_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem Text="MS" Value="MS"></asp:ListItem>
                                        <asp:ListItem Text="OMS" Value="OMS"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlVat" Width="120px" TabIndex="3" DataTextField="value" DataValueField="hidval"
                                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVat_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <br />
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lbl2ID" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="lblCode" runat="server" CssClass="lbl-form" Text="Book Code"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblQuantity" runat="server" CssClass="lbl-form" Text="Quantity"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblRate" runat="server" CssClass="lbl-form" Text="Rate"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblper" runat="server" CssClass="lbl-form" Text="per"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblDisc" runat="server" CssClass="lbl-form" Text="Disc. %"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblAmount" Style="display: none" runat="server" CssClass="lbl-form"
                                Text="Amount"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="Label1" Style="display: none" runat="server" CssClass="lbl-form" Text="Amount"></asp:Label>
                            <asp:Label ID="lblDisc0" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>--%>
                        <td valign="top">
                            <asp:TextBox ID="txtCode" runat="server" autocomplete="off" AutoPostBack="true" CssClass="inp-form"
                                Height="15px" TabIndex="3" Width="100px" OnTextChanged="txtCode_TextChanged"></asp:TextBox>
                            <div id="dvcust" class="divauto350">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                                CompletionListCssClass="AutoExtender" CompletionListElementID="dvcust" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="10" ContextKey="book"
                                DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                                ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtCode"
                                UseContextKey="true">
                            </ajaxCt:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCode"
                                ErrorMessage="Require Book Code" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                            <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtQuantity" onkeypress="return CheckNumeric(event)" Width="100px"
                                CssClass="inp-form" TabIndex="4" Height="15px" runat="server">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuantity"
                                ErrorMessage="Require Quantity" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                        </td>
                        <td valign="top">
                            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                            <asp:TextBox ID="txtRate" runat="server" CssClass="inp-form" Height="15px" onkeypress="return CheckNumericWithDot(event)"
                                TabIndex="5" Width="100px">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRate"
                                ErrorMessage="Require Rate" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                            <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtper" Text="No." runat="server" CssClass="inp-form" Height="15px"
                                TabIndex="6" Width="100px">
                            </asp:TextBox>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtDisc" Text="0.00" onkeypress="return CheckNumericWithDot(event)"
                                runat="server" CssClass="inp-form" Height="15px" TabIndex="7" Width="100px">
                            </asp:TextBox>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtAmount" Style="display: none" onkeypress="return CheckNumericWithDot(event)"
                                runat="server" CssClass="inp-form" Height="15px" TabIndex="333" Width="100px">
                            </asp:TextBox>
                            <asp:TextBox ID="txtremark" runat="server" CssClass="inp-form" Height="15px" TabIndex="8"
                                TextMode="MultiLine" Width="103px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnAdd" CssClass="submitbtn" ValidationGroup="ct" runat="server"
                                Text="Add" TabIndex="9" Width="80px" OnClick="btnAdd_Click" />
                        </td>
                        <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
                    </tr>
                    <tr>
                        <td colspan="6" valign="top">
                            <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                            <asp:Label ID="lblDescriptionofGoods" runat="server" CssClass="lbl-form" Font-Size="15px"
                                ForeColor="Blue"></asp:Label>
                            <asp:Label ID="lblStandard" Visible="false" runat="server" CssClass="lbl-form" Font-Size="15px"></asp:Label>
                            <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="sum" runat="server" ValidationGroup="ct1" ShowMessageBox="true"
        ShowSummary="false" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ct"
        ShowMessageBox="true" ShowSummary="false" />
    <br />
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pndDetails" runat="server" Width="786px">
                <asp:GridView ID="gvPurchasing" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
                    ShowFooter="false" CellPadding="4" CssClass="product-table" ForeColor="#333333"
                    Width="843px" PageSize="100" OnRowDataBound="gvPurchasing_RowDataBound" OnRowDeleting="gvPurchasing_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="left">
                            <ItemTemplate>
                                <asp:Label ID="lblpdetailid" runat="server" Style="display: none" Text='<%#Eval("PurchaseDetailId") %>'></asp:Label>
                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description of Goods" ItemStyle-HorizontalAlign="left">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Standard" ItemStyle-HorizontalAlign="left">
                            <ItemTemplate>
                                <asp:Label ID="lblqtyactual" runat="server" Style="display: none;" Text='<%#Eval("Quantity") %>'></asp:Label>
                                <asp:Label ID="lblstandard" runat="server" Text='<%#Eval("Standard") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:TextBox ID="lblQuantity" runat="server" Width="60px" onkeypress="return CheckNumeric(event)"
                                    Text='<%#Eval("Quantity") %>'></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbltotalQuantity" CssClass="totalQty" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:TextBox ID="lblRate" runat="server" Text='<%#Eval("Rate","{0:0.00}") %>' Width="50px"
                                    onkeypress="return CheckNumeric(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="per" ItemStyle-HorizontalAlign="left" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarksave" runat="server" Text='<%#Eval("Per") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Discount" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:TextBox ID="lblDisc" runat="server" Text='<%#Eval("Discount","{0:0.00}") %>'
                                    Width="50px"></asp:TextBox>
                                <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" TargetControlID="lblDisc"
                                    FilterType="Custom, Numbers" ValidChars="+-=/*()." />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount","{0:0.00}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalAmount" CssClass="totalAmt" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="center"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="lblDeleteExp" runat="server" CausesValidation="false" CommandName="Delete"
                                    CssClass="close" ToolTip="Remove" ImageUrl="Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do You want to Delete?')" />
                                <%--<asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CssClass="close" 
                        ImageUrl="../../Images/icon/save_as.png" CommandName="Edit" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <table style="width: 100%; text-align: right;" runat="server" id="summery">
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Sub Total"></asp:Label>
                        </td>
                        <td style="width: 100px;">
                            <asp:Label ID="lblSubTotal" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblVatper" runat="server" Text="VAT (%)"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblVatAmt" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Font-Bold="true" Text="Grand Total"></asp:Label>
                        </td>
                        <td style="border-top: 2px double #ccc;">
                            <asp:Label ID="lblGrandTot" Font-Bold="true" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlVat" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlmsoms" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
    <br />
    <asp:Label ID="lblTotalqtyId" Style="display: none;" runat="server" CssClass="inp-form"></asp:Label>
    <asp:Label ID="lblTotalamtId" Style="display: none;" runat="server" CssClass="inp-form"></asp:Label>
    <asp:Panel ID="PnlInsertDocNum" runat="server" DefaultButton="BtnGetDCDetails" Style="display: none;
        text-align: left; width: 300px; height: 140px;">
        <div class="facebox" width="300px">
            <asp:Label ID="Label9" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
                ForeColor="White"></asp:Label>
            <a id="A1" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup(2);">
                <img src="Images/button-cross.png" /></a>
            <br />
            <div class="content" width="275px">
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDocNo" runat="server" Font-Bold="true" Font-Size="12px" Text="Document No : "
                                            CssClass="lbl-form"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="TxtDocNo" onkeypress="return CheckNumeric(event)" runat="server"
                                                    AutoComplete="off" MaxLength="10"></asp:TextBox>
                                                <asp:DropDownList CssClass="ddl-form" ID="ddldocno" Style="display: none;" DataTextField="DocumentNo_New"
                                                    Width="150px" DataValueField="DocumentNo" runat="server" AutoPostBack="false">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1" align="left">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="get"
                                            InitialValue="0" ControlToValidate="ddldocno">Select Document No.</asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="1" align="right">
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
        PopupControlID="PnlInsertDocNum" OkControlID="A1" BackgroundCssClass="modalBackground"
        DropShadow="false" EnableViewState="false" />
    <asp:LinkButton ID="LnkBtn" runat="server" Style="display: none;">LinkButton</asp:LinkButton>

    <script type="text/javascript">

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
     //  document.getElementById(totalQtyId).innerHTML = totalQty;
   }
   if(totalAmt >=0)
   {
   totalAmt = parseFloat(totalAmt) + ((Qty * Rate)- discountprice);
    
   //document.getElementById(totalAmtID).innerHTML = totalAmt;
   TOTAL();
   }
}

function TOTAL()
   {
 
     var gridview = document.getElementById('<%=gvPurchasing.ClientID %>')
      
     var Qty = 0;
     var ToatalQty = 0 ;
     var amount = 0 ;
     var totalAmt = 0 ;
     var Rate= 0;
     var TotalRate= 0;
     var Disc=0;
     var TotalDisc=0;
                    
		                for (var r = 1; r < gridview.rows.length-1; r++)
		                {
		                
		                    Qty  = $(gridview.rows[r].cells[3]).find('input:text').attr("value");
			                Rate  = $(gridview.rows[r].cells[4]).find('input:text').attr("value");
			               totalAmt = totalAmt + parseFloat(gridview.rows[r].cells[7].innerHTML.replace(/<[^>]+>/g,""));
			             
			                ToatalQty = ToatalQty + parseInt(Qty);
			                TotalRate = TotalRate + parseFloat(Rate)
			               
			                
		                }
		                
		                  	
		                      $('.totalQty').html(ToatalQty.toString());
		                      $('.totalAmt').html(totalAmt.toString());
		           
		             
     
   }

 
                    shortcut.add("Ctrl+S",function() 
                    {
                        document.getElementById('<%=btn_Save.ClientID %>').click();
                    });
                        setTimeout("setSatus()",2000);
                    function setSatus()
                    {
                        var status="[ Ctrl+S : Save ]";
                        document.getElementById('status').innerHTML=status;
                    }   
    </script>

</asp:Content>
