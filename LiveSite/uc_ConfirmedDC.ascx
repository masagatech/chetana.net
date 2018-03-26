<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ConfirmedDC.ascx.cs"
    Inherits="UserControls_uc_ConfirmedDC" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>Generate Invoice<a href="Campaigns.aspx"
            title="back to campaign list"></a>
    </div>
    <div class="options">
        <asp:Button ID="btnapproval" ToolTip="Click to Approve and create Invoice" Visible="false"
            Style="display: none;" CssClass="form-submit" runat="server" Text="Create Invoice"
            OnClick="btnapproval_Click" />
    </div>
</div>
<table width="90%">
    <tr>
        <td width="70%">
            <asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Height="100px" ScrollBars="Vertical">
                <table width="100%" height="auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100px;" valign="top">
                            <b>Document No.</b>
                        </td>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server" >
                                <asp:UpdatePanel ID="upDocNo" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <asp:Repeater ID="Rptrpending" runat="server">
                                            <ItemTemplate>
                                                <a title="Click to view details" class="nav_bar_link" href='<%#"javascript:setVal("+Eval("DocumentNo")+")" %>'>
                                                    <%#Eval("DocumentNo") %></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnapproval" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
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
                        <td width="100px" style="display: none">
                            <asp:Button ID="btnget" OnClick="btnget_Click" CssClass="form-submit" runat="server"
                                Width="70px" Text="Get" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <asp:UpdatePanel ID="updateapprove" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td width="110px">
                                <span>Document No :
                                    <label id="docno" style="font-size: 12px; font-weight: bold" runat="server">
                                    </label>
                                </span>
                            </td>
                            <td>
                                <span>MR Name :
                                    <label id="lblempname1" style="font-size: 12px; font-weight: bold" runat="server">
                                    </label>
                                </span>
                            </td>
                        </tr>
                    </table>
                    <asp:Repeater ID="RepDetailsConfirm" runat="server" OnItemDataBound="RepDetailsConfirm_ItemDataBound"
                        OnItemCommand="RepDetailsConfirm_ItemCommand">
                        <ItemTemplate>
                            <div class="actiontab">
                                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                    <tr>
                                        <td valign="bottom">
                                            <span>Invoice No :
                                                <asp:Label ID="SubConfirmID" Style="font-weight: bold; font-size: 13px;" runat="server"
                                                    Text='<%#Eval("SubConfirmID")%>'></asp:Label></span>
                                        </td>
                                        <%--<td align="right">
                                            <asp:Button ID="btnConfirmed" CommandArgument='<%#Eval("SubConfirmID")%>' OnClick="btnapproval_Click"
                                                runat="server" Text="Create Invoice" CssClass="submitbtn" Width="110px" Style="float: right;" />
                                        </td>--%>
                                    </tr>
                                </table>
                            </div>
                            <asp:GridView ID="grdapproval" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                                ShowFooter="true" AutoGenerateColumns="false" runat="server" OnRowDataBound="grdapproval_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                            <asp:Label ID="lblspecidatils" Style="display: none;" runat="server" Text='<%#Eval("SpecimenDetailID")%>'></asp:Label>
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
                                    <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left"
                                        FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblT" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                                        FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqunty" Style="text-align: right; display: none;" runat="server"
                                                Text='<%#Eval("Quantity")%>'></asp:Label>
                                            <asp:Label ID="lblAqty" Style="text-align: right;" runat="server" Text='<%#Eval("AvailableQty")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalqty" runat="server" Text=""></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                        FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
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
                            <table width="100%">
                                <tr>
                                    <td valign="bottom">
                                        <asp:Label ID="Label2" Style="font-size: 12px; font-weight: bold" runat="server"
                                            Text="  Transporter  "></asp:Label>
                                    </td>
                                    <td valign="bottom">
                                        <asp:Label ID="Label3" Style="font-size: 12px; font-weight: bold" runat="server"
                                            Text="  LR No.  "></asp:Label>
                                    </td>
                                    <td valign="bottom">
                                        <asp:Label ID="Label4" Style="font-size: 12px; font-weight: bold" runat="server"
                                            Text="  Bundles  "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" Style="font-size: 12px; font-weight: bold" runat="server"
                                            Text=" Date  "></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtTransporter" CssClass="inp-form" Width="200px" runat="server"
                                                    Enabled="true" Text="" AutoPostBack="true" OnTextChanged="lbltransporter_TextChanged"></asp:TextBox>
                                                <div id="divtrasport" class="divauto">
                                                </div>
                                                <ajaxCt:AutoCompleteExtender ID="ACExttransporter" runat="server" DelimiterCharacters=""
                                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtTransporter"
                                                    UseContextKey="true" ContextKey="transporter" CompletionListElementID="divtrasport">
                                                </ajaxCt:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtlrno" CssClass="inp-form" Width="80px" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbundles" CssClass="inp-form" Width="80px" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdateabc" CssClass="inp-form" Width="100px" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender Animated="true" PopupPosition="Right" ID="CalendarExtender3"
                                            runat="server" TargetControlID="txtdateabc" Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" TargetControlID="txtdateabc"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-US" />
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="updateapprove1" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnConfirmed" CommandArgument='<%#Eval("SubConfirmID")%>' OnClick="btnapproval_Click"
                                                    runat="server" Text="Create Invoice" CssClass="submitbtn" Width="110px" Style="float: right;" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td width="20%" valign="top">
        </td>
    </tr>
</table>
<table>
    <tr>
        <td valign="bottom">
            <asp:Label ID="lblfright" Style="font-size: 12px; font-weight: bold" runat="server"
                Text="  Frieght %  "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtfrieght" CssClass="inp-form" Width="80px" runat="server" OnTextChanged="txtfrieght_TextChanged"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="lbltax" Style="font-size: 12px; font-weight: bold" runat="server"
                Text="  Tax %  "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txttax" CssClass="inp-form" Width="80px" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="lbltotalamt" Style="font-size: 12px; font-weight: bold" runat="server"
                Text=""></asp:Label>
        </td>
    </tr>
</table>

<script>
         function setVal(id)
         {
         document.getElementById("ctl00_ContentPlaceHolder1_uc_ConfirmedDC1_txtDocno").value = id;
         document.getElementById("ctl00_ContentPlaceHolder1_uc_ConfirmedDC1_btnget").click();
         }
function chkleave()
{
    if (!confirm("Your Leave days are exceeding pending leaves. \n Your extra leaves will be considered 'Leave Without Pay'. \n Are you sure you want to send it for approval."))
    return false;
}
</script>

