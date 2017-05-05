<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CnFEditInvoice.ascx.cs"
    Inherits="CNF_UserControl_uc_CnFEditInvoice" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<script src="../js/jquery.keynav.1.1.js" type="text/javascript"></script>

<link href="../Css/chat.css" rel="stylesheet" type="text/css" />
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        CnF Edit Invoice<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<asp:Panel ID="pnlpreview" Width="68%" runat="server">
   
    <asp:Button ID="btn_Save" Style="float: right; margin-top: -10px;" CssClass="submitbtn"
        ValidationGroup="S" TabIndex="22" runat="server" Text="Update Invoice" Width="120px"
        OnClick="btn_Save_Click" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="S"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Panel>
<table width="90%">
    <tr>
        <td width="70%">
            <asp:UpdatePanel ID="updateapprove" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panelrepeater" CssClass="panelDetails" runat="server" Width="600px">
                        <table width="100%" height="auto" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="100px;" valign="top">
                                    <b>Document No.</b>
                                </td>
                                <td valign="top">
                                    <div class="menuKey">
                                        <asp:Repeater ID="Rptrpending" runat="server">
                                            <ItemTemplate>
                                                <a class="nav_bar_link" title="click to get record" href='<%#"javascript:setVal("+Eval("DocumentNo")+")"%>'>
                                                    <%#Eval("DocumentNo")%></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>
                                <td width="100px" style="display: none">
                                    <asp:Label ID="Label1" runat="server" Text="Document No."></asp:Label>
                                    <font color="red">*</font>
                                </td>
                                <td width="100px" style="display: none">
                                    <asp:TextBox ID="txtDocno" CssClass="inp-form" Width="80px" runat="server" MaxLength="10"></asp:TextBox>
                                </td>
                                <td width="100px" style="display: none">
                                    <asp:RequiredFieldValidator ID="reqdocno" runat="server" ErrorMessage="Require Document No."
                                        ValidationGroup="App" ControlToValidate="txtDocno">*</asp:RequiredFieldValidator>
                                </td>
                                <td width="100px" style="display: none">
                                    <asp:Button ID="btnget" OnClick="btnget_Click" CssClass="form-submit" runat="server"
                                        Width="70px" Text="Get" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <asp:UpdatePanel ID="utpanel" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="PnlSpecimenDetails" CssClass="panelDetails" Width="68%" runat="server">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="100px">
                                    <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Document No. "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDocumentno" CssClass="lbl-form" runat="server"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td width="100px">
                                    <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="CnF Code "></asp:Label>
                                    <font color="red">*</font>
                                </td>
                                <td width="110px">
                                    <asp:DropDownList runat="server" ID="ddlCnF" Enabled="false" CssClass="ddl-form"
                                        TabIndex="1" DataTextField="cnfname" DataValueField="cnfid">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select CnF"
                                        ValidationGroup="S" ControlToValidate="ddlCnF" InitialValue="0">.</asp:RequiredFieldValidator>
                                </td>
                                <td width="100px">
                                    <asp:Label ID="Label21" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
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
                                        </ContentTemplate>
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
                    <asp:Panel ID="pnlDetails" runat="server">
                        <div class="actiontab">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                            <asp:GridView ID="grdapproval" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                                ShowFooter="true" AutoGenerateColumns="false" runat="server" OnRowDataBound="grdapproval_RowDataBound"
                                OnRowDeleting="grdapproval_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                            <asp:Label ID="lblivoiceId" Style="display: none;" runat="server" Text='<%#Eval("invoiceId")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Book Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbookN" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                        FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblrate" MaxLength="6" runat="server" onkeypress="return CheckNumericWithDot(event)"
                                                AutoComplete="off" Style="text-align: right;" Text='<%#Eval("Rate","{0:0.00}")%>'
                                                Width="40px"></asp:TextBox>
                                            <%--   <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                                        HeaderStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblqunty" Width="35px" AutoComplete="off" CssClass="inp-form" Style="text-align: right;"
                                                Text='<%#Eval("Quantity")%>' MaxLength="6" onkeypress="return CheckNumeric(event)"
                                                runat="server"></asp:TextBox>
                                            <%-- <asp:Label ID="lblqunty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalqty" runat="server" Text="" CssClass="totalQty"></asp:Label>
                                            <%-- <asp:Label Style="display: none" ID="lblTotalqty" CssClass="totalQty" runat="server"
                                            Text=""></asp:Label>--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                        FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamt" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalAmt" runat="server" CssClass="totalAmt" Text=""></asp:Label>
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
                   
                </asp:UpdatePanel>
                            <%-- <table style="float: right;" cellspacing="2" cellpadding="2">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblt" Style="font-size: 12px; text-align: right; font-weight: bold"
                                            runat="server" Text="  Total Amount  "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltotalamt" CssClass="inp-form" Width="50px" Style="font-size: 12px;
                                            text-align: right; font-weight: bold" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <hr style="background-color: Red" />
                                    </td>
                                </tr>
                            </table>--%>
                    </asp:Panel>
               
            <%-- <asp:Label ID="lblmsg1" CssClass="inp-form" Width="110px" Style="font-size: 12px;
                                            text-align: right; font-weight: bold" runat="server" Text="Add New Books"></asp:Label>--%>
            <asp:Panel ID="pnlgrid" runat="server" DefaultButton="ButtonAdd">
                <asp:UpdatePanel ID="upGridData" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdBookDetails" CssClass="product-table" AutoGenerateColumns="False"
                            TabIndex="21" Width="800px" runat="server" AlternatingRowStyle-CssClass="alt"
                            OnRowDeleting="grdBookDetails_RowDeleting" 
                            ShowFooter="true">
                            <Columns>
                                <%--<asp:BoundField DataField="RowNumber" HeaderText="Sr. No." ItemStyle-HorizontalAlign="Center"  />--%>
                                <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtbkcod" onfocus="setfocus('book');" onblur="setfocus('');" autocomplete="off"
                                                    TabIndex="19" CssClass="inp-form" runat="server" OnTextChanged="txtbkcod_TextChanged"
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
                                        <asp:TextBox ID="txtbookqty" TabIndex="20" Width="35px" AutoComplete="off" CssClass="inp-form"
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
                                        <asp:UpdatePanel ID="UpdatePanel91" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtrate" MaxLength="6" runat="server" onkeypress="return CheckNumericWithDot(event)"
                                                    AutoComplete="off" Style="text-align: right;" Text='<%#Eval("Rate","{0:0.00}")%>'
                                                    OnTextChanged="txtrate_TextChanged" AutoPostBack="true" Width="40px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ButtonAdd" EventName="Click" /> 
                      <%--  <asp:AsyncPostBackTrigger ControlID="btnget" EventName="Click" />  --%>
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" Style="display: none"
                    OnClick="ButtonAdd_Click" />
            </asp:Panel> 
             </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td width="20%" valign="top">
        </td>
    </tr>
</table>

<script>
    function setVal(id) {
        document.getElementById("ctl00_ContentPlaceHolder1_uc_CnFEditInvoice1_txtDocno").value = id;
        document.getElementById("ctl00_ContentPlaceHolder1_uc_CnFEditInvoice1_btnget").click();
    }
</script>

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
       
        var gridview = document.getElementById('<%=grdapproval.ClientID %>')

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

            totalAmt = totalAmt + parseFloat(gridview.rows[r].cells[6].innerHTML.replace(/<[^>]+>/g, ""));
            ToatalQty = ToatalQty + parseInt(Qty);
            TotalRate = TotalRate + parseFloat(Rate)
        }
       
        $('.totalQty').html(ToatalQty.toString());
        $('.totalAmt').html(totalAmt.toString());


    }

</script>

