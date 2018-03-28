<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Print_Invoice_Z.ascx.cs"
    Inherits="UserControls_ODC_uc_Print_Invoice_Z" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Transaction > ORDER > Print Invoice<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<table width="90%">
    <tr>
        <td width="70%">
            <asp:Panel ID="pnlradio" Visible="false" CssClass="panelDetails" runat="server">
                <table>
                    <asp:RadioButtonList ID="RdlView" runat="server" RepeatDirection="Horizontal" CssClass="lbl-form"
                        Width="300px" OnSelectedIndexChanged="RdlView_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="invoiceDate" Text="  Date Wise"></asp:ListItem>
                        <asp:ListItem Value="Customer" Text="  Customer Wise"></asp:ListItem>
                        <asp:ListItem Value="All" Text="  All "></asp:ListItem>
                    </asp:RadioButtonList>
                </table>
            </asp:Panel>
            <br />
            <asp:Panel ID="Pnlcust" CssClass="panelDetails" runat="server">
                <table>
                    <tr>
                        <td valign="top">
                            <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="200px" DataTextField="SDZoneName"
                                DataValueField="SDZoneId" AutoPostBack="true" runat="server" TabIndex="1" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select Super Duper Zone"
                                InitialValue="0" ValidationGroup="AZone123" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
                        </td>
                        <td valign="top">
                            <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                                DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="150px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                                InitialValue="0" ValidationGroup="AZone123" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLZone" runat="server" TabIndex="3" AutoPostBack="True" CssClass="ddl-form"
                                DataTextField="ZoneName" DataValueField="ZoneID" Width="150px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="Upanelcust" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Customer Code" CssClass="lbl-form"></asp:Label>
                                    <font color="red">*</font>
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="ddl-form" ID="DDLCustomer" DataTextField="CustName" DataValueField="CustID"
                                        runat="server" Width="300px" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
                                        InitialValue="0" ValidationGroup="DDlcust" ControlToValidate="DDLCustomer">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btncustomer" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="DDlcust"
                                        Width="50px" OnClick="btncustomer_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:ValidationSummary ID="ss" ShowMessageBox="true" ShowSummary="false" runat="server"
                ValidationGroup="DDlcust" />
            <asp:Panel ID="Pnldate" Visible="false" CssClass="panelDetails" runat="server">
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                                    <font color="red">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                        Enabled="true"></asp:TextBox>
                                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                        Format="dd/MM/yyyy" />
                                    <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtFromDate"
                                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                        AutoComplete="true" CultureName="en-US" />
                                    <asp:RequiredFieldValidator ID="Rqffdate" runat="server" ErrorMessage="Require Date"
                                        ValidationGroup="DDlDeldate" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                                        color="red">*</font> &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                        Enabled="true"></asp:TextBox>
                                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                                        Format="dd/MM/yyyy" />
                                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttoDate"
                                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                        AutoComplete="true" CultureName="en-US" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require Date"
                                        ValidationGroup="DDlDelDate" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btnDate" runat="server" Text="Get" TabIndex="3" CssClass="submitbtn"
                                        ValidationGroup="DDlDelDate" Width="50px" OnClick="btnDate_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:ValidationSummary ID="ss1" ShowMessageBox="true" ShowSummary="false" runat="server"
                ValidationGroup="DDlDelDate" />
            <br />
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
                                    <td colspan="2">
                                        <span style="font-weight: bold">Document No :
                                            <label id="docno" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
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
                                    <td colspan="2">
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
                                                    <span>Invoice No :</span>
                                                    <asp:Label ID="SubConfirmID" Style="font-weight: bold; font-size: 13px;" runat="server"
                                                        Text='<%#Eval("SubConfirmID")%>'></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <span>Lr No :</span>
                                                    <asp:Label ID="lrNo" runat="server" Style="font-weight: bold; font-size: 13px;" Text="Label"></asp:Label>
                                                    <%--<asp:Button ID="btnPrint" CommandArgument='<%#Eval("SubConfirmID")%>' OnClick="btnPrint_Click"
                                                        runat="server" Text="Print" Style="float: right;" CssClass='<%#Eval("class")%>'
                                                        ToolTip="click to print" />--%>
                                                </td>
                                                <td>
                                                    <span>Transporter :</span>
                                                    <asp:Label ID="transporter" runat="server" Style="font-weight: bold; font-size: 13px;" Text="Label"></asp:Label>
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
                                                    <asp:Label ID="lblspecidatils" Style="display: none;" runat="server" Text='<%#Eval("GanerateinvoiceId")%>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="Discount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                                FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'
                                                        HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblT" runat="server" Text=" Total : "></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqunty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Qty" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                                                HeaderStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblqunty" Style="display: none; text-align: right;" runat="server"
                                                        Text='<%#Eval("Quantity")%>'></asp:Label>
                                                    <asp:Label ID="lblAqty" Style="text-align: right;" runat="server" Text='<%#Eval("AvailableQty")%>'
                                                        ToolTip="show details"></asp:Label>
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
                                    <table style="float: right;" cellspacing="2" cellpadding="2">
                                        <tr>
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
                                        </tr>
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
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnget" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btncustomer" />
                    <asp:AsyncPostBackTrigger ControlID="btnDate" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
        <td width="20%" valign="top">
        </td>
    </tr>
</table>

<script>
         function setVal(id)
         {
         document.getElementById("ctl00_ContentPlaceHolder1_uc_Print_Invoice1_txtDocno").value = id;
         document.getElementById("ctl00_ContentPlaceHolder1_uc_Print_Invoice1_btnget").click();
         }
</script>

