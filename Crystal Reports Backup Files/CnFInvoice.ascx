<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CnFInvoice.ascx.cs" Inherits="CNF_CnFInvoice" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Create CnF Invoice <a href="Campaigns.aspx" title="back to campaign list"></a>
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
                <asp:DropDownList runat="server" ID="ddlCnF" CssClass="ddl-form" TabIndex="1" DataTextField="cnfname"
                    DataValueField="cnfid">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select CnF"
                    ValidationGroup="S" ControlToValidate="ddlCnF" InitialValue="0">.</asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require Date"
                    ValidationGroup="S" ControlToValidate="txtdocDate">.</asp:RequiredFieldValidator>
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
                        <asp:TextBox ID="txttransporter" Width="250px" CssClass="inp-form" TabIndex="5" autocomplete="off"
                            runat="server"></asp:TextBox>
                        <%-- <div id="divtrasport" class="divauto">  AutoPostBack="True" OnTextChanged="txttransporter_TextChanged"
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="ACExttransporter" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txttransporter"
                            UseContextKey="true" ContextKey="transporter" CompletionListElementID="divtrasport">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:Label ID="lbltransporter" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label>--%>
                    </ContentTemplate>
                    <%-- <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txttransporter" EventName="TextChanged" />
                    </Triggers>--%>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Remark"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtremark" TextMode="MultiLine" Width="250px" CssClass="inp-form"
                    TabIndex="6" autocomplete="off" runat="server"></asp:TextBox>
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
                OnRowDeleting="grdBookDetails_RowDeleting" OnRowDataBound="grdBookDetails_RowDataBound"
                ShowFooter="true">
                <Columns>
                    <%--<asp:BoundField DataField="RowNumber" HeaderText="Sr. No." ItemStyle-HorizontalAlign="Center"  />--%>
                    <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtbkcod" onfocus="setfocus('book');" onblur="setfocus('');" autocomplete="off"
                                         CssClass="inp-form" runat="server" OnTextChanged="txtbkcod_TextChanged"
                                        AutoPostBack="true" Width="200px"></asp:TextBox>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                            <asp:TextBox ID="txtbookqty"  Width="35px" AutoComplete="off" CssClass="inp-form"
                                Style="text-align: right;" MaxLength="5" onkeypress="return CheckNumeric(event)"
                                runat="server"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtbookqty"
                                WatermarkText="Qty">
                            </ajaxCt:TextBoxWatermarkExtender>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label Style="display: none" ID="lblTotalqty" CssClass="totalQty" runat="server"
                                Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                           <%-- <asp:UpdatePanel ID="UpdatePanel91" runat="server">
                                <ContentTemplate>--%>
                                    <asp:TextBox ID="txtrate" MaxLength="6"  runat="server" onkeypress="return CheckNumericWithDot(event)"
                                        AutoComplete="off" Style="text-align: right;" Text='<%#Eval("Rate","{0:0.00}")%>'
                                        Width="40px"></asp:TextBox>
                                    <%--  OnTextChanged="txtrate_TextChanged" AutoPostBack="true"<asp:Label ID="lblRate" Style="text-align: right; display: none" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>--%>
                              <%--  </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ButtonAdd" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
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
                            <asp:Label ID="lblTotalamt" Style="display: none" CssClass="totalAmt" runat="server"
                                Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remove" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnRemove" ImageUrl="~/Images/icon/DeleteIcon.gif" CommandName="delete"
                                OnClientClick="return confirm('Are you sure want to remove this book');" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
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
<div id="dialog">
    <%--<asp:GridView ID="grdpreview" CssClass="product-table" AutoGenerateColumns="False"
        TabIndex="21" Width="800px" runat="server" AlternatingRowStyle-CssClass="alt"
        ShowFooter="true">
        <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Sr. No." ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
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
                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                   
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblAmt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
                <FooterTemplate>
                   
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
</div>
<asp:Panel ID="pnlpreview" Width="68%" runat="server">
    <asp:Button ID="btnpreview" Style="float: left; margin-top: -10px" CssClass="submitbtn"
        OnClientClick="showdialog()" TabIndex="22" runat="server" Text="Preview" Width="80px" />
    <asp:Button ID="btn_Save" Style="float: right; margin-top: -10px;" CssClass="submitbtn"
        ValidationGroup="S" TabIndex="22" runat="server" Text="Generate Invoice" Width="120px"
        OnClick="btn_Save_Click" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="S"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Panel>

<script type="text/javascript">

    function multiplyQty(id, id1, id2) {
        var Qty = document.getElementById(id).value;
        var Rate = document.getElementById(id1).value;
        var Amt = 0;
        //  var disc = parseFloat(document.getElementById(disc).value);
        var totalQtyId = "";
        var totalAmtID = "";


        var totalQty = 0;
        var totalAmt = 0;


        //alert(document.getElementById(id).tabIndex)

        //  var adddisc1 = parseFloat(adddisc.innerHTML);
        //  var newdisc = disc;
        //  var discountprice = (Qty * Rate) ;
        //id1.innerHTML * id.value;        
        document.getElementById(id2).innerHTML = (Qty * Rate);
        // document.getElementById(id2).innerHTML = document.getElementById(id2).innerHTML;
       // alert(Qty * Rate);
        totalQtyId = document.getElementById("<%=lblTotalqtyId.ClientID %>").innerHTML;
        totalAmtID = document.getElementById("<%=lblTotalamtId.ClientID %>").innerHTML;

        totalQty = document.getElementById(totalQtyId).innerHTML;
        totalAmt = document.getElementById(totalAmtID).innerHTML;

        if (totalQty >= 0) {
            totalQty = parseInt(totalQty) + parseInt(Qty);
            //  document.getElementById(totalQtyId).innerHTML = totalQty;
        }
        if (totalAmt >= 0) {
            totalAmt = parseFloat(totalAmt) + ((Qty * Rate));

            //document.getElementById(totalAmtID).innerHTML = totalAmt;
            TOTAL();
        }
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

            Qty = $(gridview.rows[r].cells[4]).find('input:text').attr("value");

            totalAmt = totalAmt + parseFloat(gridview.rows[r].cells[6].innerHTML.replace(/<[^>]+>/g, ""));
            ToatalQty = ToatalQty + parseInt(Qty);
            TotalRate = TotalRate + parseFloat(Rate)
        }
        $('.totalQty').html(ToatalQty.toString());
        $('.totalAmt').html(totalAmt.toString());


    }

</script>

<script type="text/javascript">
    function showdialog() {
        $("#dialog").dialog();
    };
</script>

