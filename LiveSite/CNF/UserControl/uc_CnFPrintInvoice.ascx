<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CnFPrintInvoice.ascx.cs"
    Inherits="CNF_uc_CnFPrintInvoice" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        CnFPrint Invoice<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
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
                    <asp:Panel ID="pnlDetails" runat="server">
                        <div class="actiontab">
                            <table>
                                <tr>
                                    <td width="110px">
                                        <span style="font-weight: bold">Document No :
                                            <label id="docno" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                    <td width="210px">
                                        <span style="font-weight: bold">MR Name :
                                            <label id="lblempname1" style="font-size: 12px; font-weight: normal" runat="server">
                                                <asp:Label ID="lbldocnewno" runat="server" Style="display: none"></asp:Label>
                                            </label>
                                        </span>
                                    </td>
                                    <td width="510px">
                                        <span style="font-weight: bold">Customer Name :
                                            <label id="lblcustname" style="font-size: 12px; font-weight: normal" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <span style="font-weight: bold">Sp. Instruction :
                                            <label id="lblspinstruction" style="font-size: 12px; font-weight: normal" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                </tr>
                            </table>
                            <asp:Repeater ID="RepDetailsApprove" runat="server" OnItemDataBound="RepDetailsConfirm_ItemDataBound"
                                OnItemCommand="RepDetailsApprove_ItemCommand">
                                <ItemTemplate>
                                    <div class="actiontab" style="margin-bottom: 2px;">
                                        <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                            <tr>
                                                <td valign="bottom">
                                                    <span>Invoice No :
                                                        <asp:Label ID="SubConfirmID" Style="font-weight: bold; font-size: 13px;" runat="server"
                                                            Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Button ID="btnPrint" CssClass="submitbtn" OnClick="btnPrint_Click" runat="server" Text="Print" Style="float: right;
                                                        margin-right: 10px;" CommandArgument='<%#Eval("DocumentNo")%>'  ToolTip="click to print" />
                                                     <asp:Button ID="btnform" CssClass="submitbtn" OnClick="btnform_Click" runat="server" Text="Form Print" Style="float: right;
                                                        margin-right: 10px;" CommandArgument='<%#Eval("DocumentNo")%>'  ToolTip="Form Print" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:GridView ID="grdapproval" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                                        ShowFooter="true" AutoGenerateColumns="false" runat="server" OnRowDataBound="grdapproval_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                                    <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
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
                                                    <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Discount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'
                                                        HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblT" runat="server" Text=" Total : "></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>--%>
                                            <%-- <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqunty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Qty" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                                                HeaderStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblqunty" Style=" text-align: right;" runat="server"
                                                        Text='<%#Eval("Quantity")%>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalqty" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamt" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalAmt" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <table style="float: right;" cellspacing="2" cellpadding="2">
                                        <%--<tr>
                                            <td valign="bottom">
                                                <asp:Label ID="lbl1" Style="font-size: 12px; font-weight: bold;" runat="server" Text="  Freight   "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblfright" CssClass="inp-form" Width="50px" Style="font-size: 12px;
                                                    text-align: right; font-weight: bold" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl2" Style="font-size: 12px; text-align: right; font-weight: bold"
                                                    runat="server" Text="  Tax   "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbltax" CssClass="inp-form" Width="50px" Style="font-size: 12px; text-align: right;
                                                    font-weight: bold" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>--%>
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
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
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
        document.getElementById("ctl00_ContentPlaceHolder1_uc_CnFPrintInvoice1_txtDocno").value = id;
        document.getElementById("ctl00_ContentPlaceHolder1_uc_CnFPrintInvoice1_btnget").click();
    }
</script>

