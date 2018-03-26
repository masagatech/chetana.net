<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CnFInvoice.ascx.cs" Inherits="CNF_CnFInvoice" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Create CnFInvoice <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<asp:Panel ID="PnlSpecimenDetails" CssClass="panelDetails" Width="68%" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td width="100px">
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="CnF Code "></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="110px">
                <asp:DropDownList runat="server" ID="ddlCnF" TabIndex = "1">
                </asp:DropDownList>
            </td>
            <td width="100px">
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="110px">
                <asp:TextBox ID="txtdocDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdocDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtdocDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <%--<asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require Date"
                    ValidationGroup="S" ControlToValidate="txtdocDate">.</asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text=" L.R. No.  "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtlrno" CssClass="inp-form" Width="100px" runat="server" Text=""
                    TabIndex="3"></asp:TextBox>
            </td>
            <td width="100px">
                <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="LR Date"></asp:Label>
            </td>
            <td width="110px">
                <asp:TextBox ID="txtLRDate" CssClass="inp-form" TabIndex="4" Width="80px" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtLRDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtLRDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label15" CssClass="lbl-form" runat="server" Text="Transporter"></asp:Label>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txttransporter" Width="100px" CssClass="inp-form" TabIndex="5"
                            autocomplete="off" runat="server" AutoPostBack="True" OnTextChanged="txttransporter_TextChanged"></asp:TextBox>
                        <div id="divtrasport" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="ACExttransporter" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txttransporter"
                            UseContextKey="true" ContextKey="transporter" CompletionListElementID="divtrasport">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:Label ID="lbltransporter" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txttransporter" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Remark"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtremark" TextMode="MultiLine" Width="250px" CssClass="inp-form" TabIndex="6" autocomplete="off"
                    runat="server" ></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="pnlgrid" runat="server" DefaultButton="ButtonAdd">
    <asp:UpdatePanel ID="upGridData" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grdBookDetails" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="21" Width="800px" runat="server" AlternatingRowStyle-CssClass="alt"
                OnRowDataBound="grdBookDetails_RowDataBound" ShowFooter="true">
                <Columns>
                    <asp:BoundField DataField="RowNumber" HeaderText="Sr. No." ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtbkcod" onfocus="setfocus('book');" onblur="setfocus('');" autocomplete="off"
                                TabIndex="19" CssClass="inp-form" runat="server" OnTextChanged="txtbkcod_TextChanged"
                                Width="200px"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarktxtbook" runat="server" TargetControlID="txtbkcod"
                                WatermarkText="Enter BookCode to add  ">
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
                    <asp:TemplateField HeaderText="Standard" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Medium" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtbookqty" TabIndex="20" Width="35px" AutoComplete="off" CssClass="inp-form"
                                Style="text-align: right;" MaxLength="5" onkeypress="return CheckNumeric(event)"
                                runat="server"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtbookqty"
                                WatermarkText="Qty">
                            </ajaxCt:TextBoxWatermarkExtender>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalqty" CssClass="totalQty" runat="server" Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtrate" MaxLength="6" runat="server" onkeypress="return CheckNumericWithDot(event)"
                                AutoComplete="off" Style="text-align: right;" Text='<%#Eval("Rate","{0:0.00}")%>'
                                Width="40px"></asp:TextBox>
                            <%--<asp:Label ID="lblRate" Style="text-align: right; display: none" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Dis.(%)" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDiscount" onkeydown="setAmtclass(this)" MaxLength="6" Style="text-align: right;"
                                AutoComplete="off" Text='<%#Eval("Discount")%>' onkeypress="return CheckNumericWithDot(event)"
                                runat="server" Width="40px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                        FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblAmt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotalamt" CssClass="totalAmt" runat="server" Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblTotalqtyId" Style="display: none;" runat="server" CssClass="inp-form"></asp:Label>
            <asp:Label ID="lblTotalamtId" Style="display: none;" runat="server" CssClass="inp-form"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ButtonAdd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" Style="display: none"
        OnClick="ButtonAdd_Click" />
</asp:Panel>
<asp:Panel ID="pnlpreview" CssClass="panelDetails" Width="68%" runat="server">
    <asp:Button ID="btnpreview" Style="float: left; margin-top: -10px" CssClass="submitbtn"
        ValidationGroup="S" TabIndex="22" runat="server" Text="Preview" Width="80px" />
    <asp:Button ID="btn_Save" Style="float: right; margin-top: -10px;" CssClass="submitbtn"
        ValidationGroup="S" TabIndex="22" runat="server" Text="Generate Invoice" Width="120px"
        OnClick="btn_Save_Click" />
</asp:Panel>

<script type="text/javascript">

    function multiplyQty(id, id1, id2, disc) {
        var Qty = document.getElementById(id).value;
        var Rate = document.getElementById(id1).value;
        var Amt = 0;
      //  var disc = parseFloat(document.getElementById(disc).value);
        var totalQtyId = "";
        var totalAmtID = "";


        var totalQty = 0;
        var totalAmt = 0;



        //  var adddisc1 = parseFloat(adddisc.innerHTML);
      //  var newdisc = disc;
      //  var discountprice = (Qty * Rate) ;
        //id1.innerHTML * id.value;        
        document.getElementById(id2).innerHTML = (Qty * Rate) ;
        document.getElementById(id2).innerHTML = document.getElementById(id2).innerHTML;

        totalQtyId = document.getElementById("<%=lblTotalqtyId.ClientID %>").innerHTML;
        totalAmtID = document.getElementById("<%=lblTotalamtId.ClientID %>").innerHTML;

        totalQty = document.getElementById(totalQtyId).innerHTML;
        totalAmt = document.getElementById(totalAmtID).innerHTML;

        if (totalQty >= 0) {
            totalQty = parseInt(totalQty) + parseInt(Qty);
            //  document.getElementById(totalQtyId).innerHTML = totalQty;
        }
        if (totalAmt >= 0) {
            totalAmt = parseFloat(totalAmt) + ((Qty * Rate) );

            //document.getElementById(totalAmtID).innerHTML = totalAmt;
            TOTAL();
        }
    }
    function setAmtclass() {
    }


</script>

<script type="text/javascript">
    function TOTAL() {

        var gridview = document.getElementById('<%=grdBookDetails.ClientID %>')

        var Qty = 0;
        var ToatalQty = 0;
        var amount = 0;
        var totalAmt = 0
        var Rate = 0;
        var TotalRate = 0;
     //   var Disc = 0;
    //    var TotalDisc = 0;

        for (var r = 1; r < gridview.rows.length - 1; r++) {

            Qty = $(gridview.rows[r].cells[5]).find('input:text').attr("value");
         //   alert(Qty);
          //  Rate = $(gridview.rows[r].cells[6]).find('input:text').attr("value");
            // Disc  = $(gridview.rows[r].cells[7]).find('input:text').attr("value");
           // alert(Rate);
            totalAmt = totalAmt + parseFloat(gridview.rows[r].cells[7].innerHTML.replace(/<[^>]+>/g, ""));
           // alert(totalAmt);
            // TotalDisc = TotalDisc + parseFloat(Disc);
            ToatalQty = ToatalQty + parseInt(Qty);
            TotalRate = TotalRate + parseFloat(Rate)
            // totalAmt = totalAmt + parseFloat((ToatalQty * TotalRate) - ((ToatalQty * TotalRate) * (TotalDisc/100)));

            // ele  = $(gridview.rows[r].cells[4]).find('input:text').attr("value");
            //   alert(ele);

        }

        // amount = ((ToatalQty * TotalRate * TotalDisc)/100)
        //totalAmt =(ToatalQty * TotalRate) - amount


        $('.totalQty').html(ToatalQty.toString());
        $('.totalAmt').html(totalAmt.toString());



    }

</script>

