<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ConfirmDC.ascx.cs"
    Inherits="UserControls_uc_ConfirmDC" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<script src="js/jquery.keynav.1.1.js" type="text/javascript"></script>

<link href="Css/chat.css" rel="stylesheet" type="text/css" />
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>Pending D. C.<a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
        <table style="display: none;">
            <tr>
                <td width="100px">
                    <asp:Label ID="Label1" runat="server" Text="Document No."></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtdocno" Width="80px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqbook" runat="server" ErrorMessage="Require Document No."
                        ValidationGroup="confirm" ControlToValidate="txtdocno">*</asp:RequiredFieldValidator>
                </td>
                <td width="100px">
                    <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" OnClick="btnget_Click" />
                </td>
            </tr>
        </table>
    </div>
</div>
<table width="90%">
    <tr>
        <td width="70%" valign="top">
            <asp:Panel ID="Panel1" CssClass="panelDetails" runat="server">
                <table>
                    <asp:RadioButtonList ID="RdlView" runat="server" RepeatDirection="Horizontal" CssClass="lbl-form"
                        Width="300px" OnSelectedIndexChanged="RdlView_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="Date" Text="  Date Wise"></asp:ListItem>
                        <asp:ListItem Value="Employee" Text="  Salesman Wise"></asp:ListItem>
                       <%-- <asp:ListItem Value="All" Text="  All "></asp:ListItem>--%>
                    </asp:RadioButtonList>
                </table>
            </asp:Panel>
            <br />
            <asp:Panel ID="Pnlcust" CssClass="panelDetails" runat="server" Visible="false">
                <asp:UpdatePanel ID="Upanelcust" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="M.R. Code" CssClass="lbl-form"></asp:Label>
                                    <font color="red">*</font>
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="ddl-form" ID="DDLEmployee" DataTextField="Name" DataValueField="EmpID"
                                        runat="server" Width="300px" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
                                        InitialValue="0" ValidationGroup="DDlcust" ControlToValidate="DDLEmployee">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btnemployee" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="DDlcust"
                                        Width="50px" OnClick="btnemployee_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Panel ID="pnlDate" CssClass="panelDetails" runat="server" Visible="false">
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
                                    <asp:RequiredFieldValidator ID="Rqffdate" runat="server" ErrorMessage="Require From Date"
                                        InitialValue="none" ValidationGroup="DDlDeldate" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require To Date"
                                        InitialValue="0" ValidationGroup="DDlDelDate" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btnfind" runat="server" TabIndex="3" Text="Get" CssClass="submitbtn"
                                        ValidationGroup="DDlDelDate" Width="50px" OnClick="btnfind_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <br />
            <asp:Panel ID="pnlconfirm" CssClass="panelDetails" Height="100px" ScrollBars="Vertical"
                runat="server">
                <asp:Button ID="btnBookWice" runat="server" CssClass="submitbtn" OnClick="btnBookWice_Click"
                    Text="BookWise" Width="100px" />
                <asp:UpdatePanel ID="upOrderNO" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <div>
                                        <asp:Repeater ID="Rptrpending" runat="server">
                                            <ItemTemplate>
                                                <a class='<%#Eval("classPending")%>' href='<%#"javascript:setVal("+Eval("DocumentNo")+")" %>'>
                                                    <%#Eval("DocumentNo") %></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <br />
            <%--  <asp:UpdatePanel ID="upDetails" runat="server" UpdateMode="Conditional">
                <ContentTemplate>--%>
            <asp:Panel ID="pnlDetails" runat="server">
                <div class="actiontab">
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
                        <tr>
                            <td colspan="2">
                                <span>Sp. Instruction :
                                    <label id="lblspinstruct" style="font-size: 12px; font-weight: bold" runat="server">
                                    </label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span>Description :
                                    <label id="lbldescription" style="font-size: 12px; font-weight: bold" runat="server">
                                    </label>
                                </span>
                            </td>
                        </tr>
                    </table>
                </div>
                <table width="100%">
                    <tr>
                        <td width="60px">
                            <asp:Label ID="lblemp" CssClass="lbl-form" runat="server" Text="EmpCode"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtempc" runat="server" autocomplete="off" AutoPostBack="true" CssClass="inp-form"
                                OnTextChanged="txtempc_TextChanged"></asp:TextBox>
                            <div id="dvCode" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtempc"
                                UseContextKey="true" ContextKey="empCode" CompletionListElementID="dvCode">
                            </ajaxCt:AutoCompleteExtender>
                            <asp:Label ID="lblEmpName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Button ID="btnconfirm" Enabled="false" OnClientClick="return confirm('Are you sure want to confirm?')" CssClass="submitbtn" Visible="false"
                                runat="server" Text="Confirm" Width="100px" OnClick="btnconfirm_Click" />
                            <asp:Button ID="btnDocWice" CssClass="submitbtn" Visible="false" Width="100px" runat="server"
                                Text="Document Wise" OnClick="btnDocWice_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnPrint" Visible="false" runat="server" Text="Print" Style="float: right;"
                                CssClass="submitbtn" ToolTip="click to print" OnClick="btnPrint_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="grdconfirm" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                    ShowFooter="true" AutoGenerateColumns="false" runat="server" OnRowDataBound="grdconfirm_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                            <ItemTemplate>
                                <asp:Label ID="lblbook" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                <asp:Label ID="lblspecidatils" Style="display: none;" runat="server" Text='<%#Eval("SpecimenDetailID")%>'></asp:Label><asp:Label
                                    ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Book Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                            FooterStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotal" align="right" runat="server" Text="Total : "></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                            FooterStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lblqty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalQty" align="right" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Available Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:TextBox ID="lblavailable" Enabled='<%#Convert.ToBoolean(Eval("Enabled"))%>'
                                    onkeypress="return CheckNumeric(event)" onkeyup='<%#"javascript:SetMaxNumber(this,"+Eval("RemainQty")+")"%>'
                                    onblur='<%#"javascript:SetMaxNumber(this,"+Eval("RemainQty")+")"%>' CssClass="lbl-txt"
                                    Style="text-align: right;" runat="server" Width="40px" Text='<%#Eval("RemainQty") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="aa" runat="server" Text="No Data Available"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
            </asp:Panel>
            <%-- </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnget" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>--%>
        </td>
        <td width="20%" valign="top">
        </td>
    </tr>
</table>
<table style="display: none;">
    <tr>
        <td>
            <asp:Label ID="LablEmpCode" runat="server" Text="Emp Code"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtEmpCode" runat="server" OnTextChanged="TxtEmpCode_TextChanged"></asp:TextBox>
        </td>
    </tr>
</table>

<script type="text/javascript">
         function setVal(id)
         {
             document.getElementById('<%=txtdocno.ClientID%>').value = id;
             document.getElementById('<%=btnget.ClientID%>').click();
         
         }
         shortcut.add("Ctrl+S",function() {
document.getElementById('<%=btnconfirm.ClientID %>').click();
});
setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+S : Create Invoice ]";
document.getElementById('status').innerHTML=status;

}
</script>

