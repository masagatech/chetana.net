<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="CNFPendingInvoice.aspx.cs" Inherits="CNFPendingInvoice" Title="CnF Pending Invoice" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .panelDetailsNew
        {
            border: 1px solid #9C9C9C;
            background-color: #EEE;
            width: 346px;
            padding: 1.5em 18px;
            background: #008800;
            background: -moz-linear-gradient(top, #BDBDBD, #9C9C9C);
            background: -webkit-gradient(linear, left top, left bottom, from(#BDBDBD), to(#9C9C9C));
        }
    </style>
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            CnF Pending Invoice<a href="Campaigns.aspx" title="back to campaign list"></a>
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
    <asp:Panel ID="Pnd" CssClass="panelDetailsNew" DefaultButton="btnGetData" runat="server">
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="DDLCnfInvoice" DataTextField="CnFName" DataValueField="cnfid"
                        runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="DDLCNFReq" Style="display: none;" runat="server"
                        InitialValue="0" ErrorMessage="Kindly Select CnF from the list" ValidationGroup="V"
                        ControlToValidate="DDLCnfInvoice">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblStar" runat="server" Style="color: Red">*</asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnGetData" OnClick="btnGetData_click" runat="server" CssClass="submitbtn"
                        Text="Get" ValidationGroup="V" Style="width: 200%" />
                </td>
                <td>
                    <asp:ValidationSummary ID="validation" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="V" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table width="90%">
        <tr>
            <td width="70%">
                <asp:UpdatePanel ID="upDocNo" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" Visible="false" CssClass="panelDetails" runat="server">
                            <table width="100%" height="auto" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="100px;" valign="top">
                                        <b>Document No.</b>
                                    </td>
                                    <td valign="top">


                                        <asp:Panel ID="Panel3" Visible="false" runat="server">
                                            <asp:Repeater ID="Rptrpending" runat="server">
                                                <ItemTemplate>
                                                    <a title="Click to view details" class="nav_bar_link" href='<%#"javascript:setVal("+Eval("DocumentNo")+")" %>'>
                                                        <%#Eval("DocumentNo") %></a>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </asp:Panel>
                                    </td>
                                    <td width="100px" style="display: none">
                                        <asp:Label ID="Label1" runat="server" Text="Document No."></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td width="100px" style="display: none">
                                        <asp:TextBox ID="txtDocno" CssClass="inp-form" Width="80px" runat="server"></asp:TextBox>
                                    </td>
                                    <td width="100px" style="display: none">
                                        <asp:RequiredFieldValidator ID="reqdocno" runat="server" ErrorMessage="Require Document No."
                                            ValidationGroup="App" ControlToValidate="txtDocno">*</asp:RequiredFieldValidator>
                                    </td>
                                    <%--<td width="100px" style="display: none">
                                
                            </td>--%>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnGetData" EventName="click" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Button ID="btnget" Style="display: none" CssClass="form-submit" runat="server" Width="70px" Text="Get"
                    OnClick="btnget_Click" />
                <br />
                <asp:UpdatePanel ID="updategenerate" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlDetails" runat="server">
                            <table>
                                <tr>
                                    <td width="110px">
                                        <span>Document No :
                                            <label id="docno" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                    <td width="210px">
                                        <span>MR Name :
                                            <label id="lblempname1" style="font-size: 12px; font-weight: bold" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                    <td width="310px">
                                        <span>Customer Name :
                                            <label id="lblcustname" style="font-size: 12px; font-weight: bold" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <label id="lblmessage" runat="server">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="hidsaved" runat="server" />
                            <asp:Repeater ID="RepDetailsConfirm" runat="server" OnItemDataBound="RepDetailsConfirm_ItemDataBound"
                                OnItemCommand="RepDetailsConfirm_ItemCommand">
                                <ItemTemplate>
                                    <div class="actiontab">
                                        <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                            <tr>
                                                <td valign="bottom">
                                                    <span>Invoice No :
                                                        <asp:Label ID="SubConfirmID" Style="font-weight: bold; font-size: 13px;" runat="server"
                                                            Text='<%#Eval("SubConfirmID")%>'></asp:Label>
                                                        <asp:Label ID="lblCustId1" runat="server" Style="display: none;" Text="0"></asp:Label>
                                                </td>
                                                <%-- <td align="right">
                                            <asp:Button ID="btnConfirmed" CommandArgument='<%#Eval("SubConfirmID")%>' OnClick="btnapproval_Click" s
                                                TabIndex="3" runat="server" Text="Create Invoice" CssClass="submitbtn" Width="110px"
                                                Style="float: right;" />
                                        </td>--%>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:GridView ID="grdapproval" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                                        ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound="grdapproval_RowDataBound"
                                        runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                                    <asp:Label ID="lblspecidatils" Style="display: none;" runat="server" Text='<%#Eval("DCDetailID")%>'></asp:Label>
                                                    <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Book Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbookN" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Qty" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqunty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtrate" MaxLength="6" runat="server" onkeypress="return CheckNumericWithDot(event)"
                                                        Enabled="false" Style="text-align: right;" Text='<%#Eval("Rate","{0:0.00}")%>'
                                                        Width="45px" CssClass="TotalBox"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Discount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtdiscount" runat="server" MaxLength="6" Text='<%#Eval("Discount","{0:0.00}")%>'
                                                        Enabled="false" Width="45px" HeaderStyle-HorizontalAlign="Left" Style="text-align: right;"
                                                        onkeypress="return CheckNumericWithDot(event)"></asp:TextBox>
                                                    <asp:Label Style="display: none;" ID="lblTotalAmtForFright" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblqunty" Style="text-align: right; display: none;" runat="server"
                                                        Text='<%#Eval("Quantity")%>'></asp:Label>
                                                    <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>' Style="display: none"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblT" runat="server" Text=" Total : "></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAqty" Style="text-align: right;" runat="server" Text='<%#Eval("AvailableQty")%>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalqty" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamt" runat="server" Text='<%#Eval("RevisedAmt","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalAmt" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <table style="float: left;" cellspacing="2" cellpadding="2">
                                        <tr>
                                            <td valign="bottom">
                                                <asp:Label ID="Label2" Style="font-size: 12px; font-weight: bold;" runat="server"
                                                    Text="  Transporter   "></asp:Label>
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
                                            <td>
                                                <asp:Label ID="Label4" Style="font-size: 12px; font-weight: bold" runat="server"
                                                    Text=" Invoice Date  "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdateabc" onblur="ValidInYearDate(this);" CssClass="inp-form"
                                                    Width="100px" runat="server" TabIndex="3"></asp:TextBox>
                                                <ajaxCt:CalendarExtender Animated="true" PopupPosition="Right" ID="CalendarExtender3"
                                                    runat="server" TargetControlID="txtdateabc" Format="dd/MM/yyyy" />
                                                <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" TargetControlID="txtdateabc"
                                                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                                    AutoComplete="true" CultureName="en-US" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtbundles" CssClass="inp-form" Width="50px" runat="server" Text=""
                                                    TabIndex="4"></asp:TextBox>
                                                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkDDlset" runat="server" TargetControlID="txtbundles"
                                                    WatermarkText="Bundles">
                                                </ajaxCt:TextBoxWatermarkExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" Style="font-size: 12px; font-weight: bold" runat="server"
                                                    Text=" L.R. No.  "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtlrno" CssClass="inp-form" Width="100px" runat="server" Text=""
                                                    TabIndex="2"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label6" Style="font-size: 12px; font-weight: bold" runat="server"
                                                    Text=" L.R. Date :  "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtlrdate" CssClass="inp-form" Width="100px" runat="server" TabIndex="4"></asp:TextBox>
                                                <ajaxCt:CalendarExtender Animated="true" PopupPosition="Right" ID="CalendarExtender1"
                                                    runat="server" TargetControlID="txtlrdate" Format="dd/MM/yyyy" />
                                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtlrdate"
                                                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                                    AutoComplete="true" CultureName="en-US" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" Style="font-size: 12px; font-weight: bold" runat="server"
                                                    Text=" Remark :  "></asp:Label>
                                            </td>
                                            <td colspan="7" width="150px" rowspan="3">
                                                <asp:Label ID="LblRemark" Style="font-size: 13px;" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:UpdatePanel ID="updateapprove" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <table style="float: right;" cellspacing="2" cellpadding="2">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:Label ID="lblfright" Style="font-size: 12px; font-weight: bold;" runat="server"
                                                            Text="  Freight   "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtfrieght" CssClass="inp-form" Width="70px" MaxLength="6" onkeypress="return CheckNumeric(event)"
                                                            onblur="if(this.value==''){this.value='0'}" Text="" runat="server" TabIndex="5"
                                                            Style="text-align: right;" OnTextChanged="txtfrieght_TextChanged"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbltax" Style="font-size: 12px; font-weight: bold" runat="server"
                                                            Text="  Tax   "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttax" CssClass="inp-form" Width="70px" runat="server" MaxLength="6"
                                                            onkeypress="return CheckNumeric(event)" onblur="if(this.value==''){this.value='0'}"
                                                            Text="" TabIndex="6" Style="text-align: right;" OnTextChanged="txttax_TextChanged"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblt" Style="font-size: 12px; font-weight: bold" runat="server" Text="  Total Amount  "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbltotalAmtget" Style="display: none;" Width="50px" runat="server"
                                                            Text=""></asp:Label>
                                                        <asp:Label ID="lbltotalamt" CssClass="inp-form" Width="70px" Style="font-size: 12px; text-align: right; font-weight: bold"
                                                            runat="server" Text=""></asp:Label>
                                                        <asp:Label ID="lbltotalAmtJS" Style="display: none;" Width="50px" runat="server"
                                                            Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4">
                                                        <asp:Button ID="btnConfirmed" Visible="false" CommandArgument='<%#Eval("SubConfirmID")%>' OnClick="btnapproval_Click"
                                                            TabIndex="7" runat="server" Text="Create Invoice" CssClass="submitbtn" Width="110px"
                                                            Style="float: right;" OnClientClick="return confirm('Do you want to Create Invoice ?');" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <hr style="background-color: Red" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ItemTemplate>
                            </asp:Repeater>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnGetData" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td width="20%" valign="top"></td>
        </tr>
    </table>
    <asp:Label ID="lblMobNo" Style="display: none;" runat="server" Text="noContact"></asp:Label>
    <asp:Label ID="lblEmail" runat="server" Style="display: none;" Text="noContact"></asp:Label>
    <asp:Label ID="tamount" runat="server" Style="display: none;" Text="0"></asp:Label>
    <asp:Label ID="SMSSend" runat="server" Style="display: none;" Text="No"></asp:Label>

    <script type="text/javascript">
        function setVal(id) {
            document.getElementById("ctl00_ContentPlaceHolder1_txtDocno").value = id;
            document.getElementById("ctl00_ContentPlaceHolder1_btnget").click();
        }

        function sumCharges(frigt, tax, totalamt, setTotal) {
            var frieghtchrgs = 0;
            var taxamt = 0;
            var total = 0;
            var totalgetAmt = 0;
            frieghtchrgs = document.getElementById(frigt).value;
            taxamt = document.getElementById(tax).value;
            totalgetAmt = document.getElementById(totalamt).innerHTML;
            total = parseFloat(frieghtchrgs) + parseFloat(taxamt) + parseFloat(totalgetAmt);
            document.getElementById(setTotal).innerHTML = total;


        }


        function multiplyQty(id, id1, disc, id2, gridview, txtfrieght, txttax, totallable, totallableorg, lbltotalAmtJS) {
            var Qty = document.getElementById(id).innerHTML;


            var gridview1 = gridview;

            //alert(Qty);
            var Rate = document.getElementById(id1).value;
            //alert(Rate);
            var Amt = 0;
            var disc = parseFloat(document.getElementById(disc).value);
            //alert(disc);
            //  var adddisc1 = parseFloat(adddisc.innerHTML);
            var newdisc = disc;
            var discountprice = (Qty * Rate) * (disc / 100);
            //id1.innerHTML * id.value;        
            document.getElementById(id2).innerHTML = (Qty * Rate) - discountprice;
            document.getElementById(id2).innerHTML = document.getElementById(id2).innerHTML;
            var totalAmt = Calcutate(gridview1, txtfrieght, txttax, totallable, totallableorg, lbltotalAmtJS);

        }
        function Calcutate(gridview, txtfrieght, txttax, totallable, totallableorg, lbltotalAmtJS) {

            var tablea = document.getElementById(gridview);
            var txtfrightchrg = document.getElementById(txtfrieght);
            var txttaxchrg = document.getElementById(txttax);
            var totallableamt = totallable;




            var QtyLabel = gridview + 'qty';
            var AmtLabel = gridview + 'amt';

            var rate = 0;
            var Totalrate = 0;
            var TotalAmt = 0;
            var TotalQty = 0

            for (var r = 1; r < tablea.rows.length - 1; r++) {
                rate = $(tablea.rows[r].cells[4]).find('input:text').attr("value");

                TotalQty = TotalQty + parseInt(tablea.rows[r].cells[6].innerHTML.replace(/<[^>]+>/g, ""));
                // alert(rate);
                TotalAmt = TotalAmt + parseFloat(tablea.rows[r].cells[7].innerHTML.replace(/<[^>]+>/g, ""));
                //Totalrate  = Totalrate  + parseFloat(rate);

            }


            //alert( $('.'+AmtLabel).text());
            $('.' + QtyLabel).html(TotalQty.toString());
            $('.' + AmtLabel).html(TotalAmt.toString());

            //alert(totallableamt.innerHTML);
            // alert ($('#'+ totallableorg).text());
            $('#' + totallableamt).html((parseFloat(txtfrightchrg.value) + parseFloat(txttaxchrg.value) + parseFloat(TotalAmt.toString())).toString());
            $('#' + totallableorg).html($('#' + totallableamt).text());
            $('#' + lbltotalAmtJS).html($('#' + totallableamt).text());


            //alert(Totalrate.toString());
            //     var total = 0;
            //     $('.TotalBox').each(function() {
            //         total = parseFloat(this.val()) +  total;
            //     });

            //alert(total.toString());
            //$('.TotalLabel').html(total.toString());

            return TotalAmt.toString();
        }
    </script>

</asp:Content>
