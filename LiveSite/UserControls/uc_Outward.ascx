<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Outward.ascx.cs" Inherits="UserControls_uc_Outward" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>Outward <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
</div>
<p>
</p>
<asp:Panel ID="pnlview" runat="server" CssClass="panelDetails">
    <table>
        <tr>
            <td>
                <asp:RadioButtonList ID="Rdboutward" runat="server" CssClass="lbl-form" RepeatDirection="Horizontal"
                    Width="250px">
                    <asp:ListItem Value="Outward" Text="Outward No."></asp:ListItem>
                    <asp:ListItem Value="Invoice" Text="Invoice"></asp:ListItem>
                    <asp:ListItem Value="Document" Text="Document"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="txtoutwardno1" runat="server" CssClass="inp-form" AutoComplete="off"
                    onkeypress="return CheckNumericWithDot(event)"></asp:TextBox>
                <asp:Button ID="btngetreport" runat="server" CssClass="submitbtn" Width="50px" Text="Get"
                    OnClick="btngetreport_Click" Style="display: none" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnprint" runat="server" CssClass="submitbtn" Width="50px" Text="Print"
                    OnClick="btnprint_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="Pnlselect" CssClass="panelDetails" runat="server" Width="400px">
    <table>
        <tr>
            <%--<td width="5px"></td>--%>
            <td width="100px">
                <asp:Label ID="Label11" runat="server" Text="Outward Date" CssClass="lbl-form"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="5px">
            </td>
            <td width="150px">
                <asp:UpdatePanel ID="UpPnldate" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOutwardDate" CssClass="inp-form" TabIndex="1" Width="85px" runat="server"
                            Enabled="true" AutoPostBack="True"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtOutwardDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtOutwardDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="Rqfow" runat="server" ErrorMessage="Require OutWard Date"
                            ValidationGroup="OD" ControlToValidate="txtOutwardDate">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="110px">
                <asp:Label ID="LblEmp" CssClass="lbl-form" runat="server" Text="Employee Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="5px">
            </td>
            <td width="150px">
                <asp:TextBox ID="TxtEmp" Width="85px" CssClass="inp-form" TabIndex="2" runat="server"> 
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="Rqfemp" runat="server" ErrorMessage="Require Employee Name"
                    ValidationGroup="OD" ControlToValidate="TxtEmp">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblRemark" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
            </td>
            <td width="5px">
            </td>
            <td>
                <asp:TextBox ID="TxtRemark" runat="server" CssClass="inp-form" Height="30px" TextMode="MultiLine"
                    Width="200px" TabIndex="3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqRem" runat="server" ErrorMessage="Enter Comment"
                    ValidationGroup="//Entry" ControlToValidate="TxtRemark">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="100px">
                <asp:RadioButtonList ID="RdbtnSelect" runat="server" RepeatDirection="Horizontal"
                    TabIndex="4" CssClass="lbl-form" Width="150px" OnSelectedIndexChanged="RdbtnSelect_SelectedIndexChanged"
                    AutoPostBack="false">
                    <asp:ListItem Value="Invoice" Text="Invoice"></asp:ListItem>
                    <asp:ListItem Value="Document" Text="Document"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RqfSelect" runat="server" ErrorMessage="Select Option Invoice/Document"
                    ValidationGroup="Entry" ControlToValidate="RdbtnSelect">.</asp:RequiredFieldValidator>
            </td>
            <td width="5px">
                <font color="red">*</font>
            </td>
            <td valign="top">
                <asp:Panel BorderWidth="0" ID="pnladd" runat="server" DefaultButton="btnadd" TabIndex="6">
                    <asp:TextBox ID="Txtno" Width="85px" CssClass="inp-form" runat="server" OnTextChanged="Txtno_TextChanged"
                        TabIndex="5"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter4" runat="server" FilterType="Custom, Numbers"
                        TargetControlID="Txtno" ValidChars="." />
                    <asp:Button ID="btnadd" CssClass="submitbtn" runat="server" ValidationGroup="Entry"
                        Text="Add" Width="70px" TabIndex="5" OnClick="btnadd_Click" Style="display: none" />
                </asp:Panel>
            </td>
            <td width="5px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td width="100px">
            </td>
            <td width="5px">
            </td>
            <td>
                <asp:Label ID="lblCustName" runat="server" CssClass="lbl-form" Font-Size="15px" Style="display: none"
                    ForeColor="Blue" Width="450px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100px">
            </td>
            <td width="5px">
            </td>
            <td>
                <asp:Label ID="lblArea" runat="server" CssClass="lbl-form" Font-Size="15px" Style="display: none"
                    ForeColor="Blue" Width="450px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMsg" Visible="false" runat="server" Text="You can still make this entry by pressing Add button below. Document No is "></asp:Label>
                <asp:Label ID="lblSelectedDoc" Visible="false" runat="server"></asp:Label>
                <asp:Button CssClass="submitbtn" Visible="false" ID="btnForceAdd" runat="server"
                    Text="Add" OnClick="btnForceAdd_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
<asp:Panel ID="PnllGrdOD" runat="server" Width="900px">
    <div class="actiontab" style="margin-bottom: 6px; width: 960px;">
        <table align="right" border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;">
            <tr>
                <td align="right" width="80px">
                </td>
                <td align="right" width="80px">
                    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="6" runat="server" Text="Save"
                        Width="80px" OnClick="btnSave_Click" ValidationGroup="OD" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
<%--   <asp:UpdatePanel ID="upGridData" runat="server">
    <ContentTemplate>--%>
<asp:GridView ID="GrdOD" runat="server" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
    AutoGenerateColumns="false" CellPadding="4" CssClass="product-table" ShowHeader="true"
    Width="960px" OnRowDataBound="GrdOD_RowDataBound" OnRowDeleting="GrdOD_RowDeleting">
    <Columns>
        <%-- <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Invoice/Doc">
                <ItemTemplate>
                  
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>--%>
        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Invoice/Doc No.">
            <ItemTemplate>
                <asp:Label ID="lbldetailid" runat="server" Text='<%#Eval("OdDAutoId")%>' Style="display: none"></asp:Label>
                <asp:Label ID="LblFlag" runat="server" Text='<%#Eval("Flag")%>' Style="display: none"></asp:Label>
                <asp:Label ID="LblInvoiceNo" runat="server" Text='<%#Eval("Invoice")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Customer Name"
            ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="LblCustN" runat="server" Width="392px" Text='<%#Eval("CustName")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Area Name" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="LblArea" runat="server" Width="150px" Text='<%#Eval("AreaName")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <%-- <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                    CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                -   --%>
                <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                    CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you want to Delete?')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle CssClass="alt" />
</asp:GridView>
<%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnaddEntry" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>
<%--</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnadd" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>--%>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Entry"
    runat="server" ID="OD1" />
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="OD"
    runat="server" ID="OD2" />
<%-- <asp:GridView ID="GrdDetail" runat="server" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
                    AutoGenerateColumns="false" CellPadding="4" CssClass="product-table" 
                    ShowHeader="true" onrowdeleting="GrdDetail_RowDeleting" >
                    <Columns>
                       
                        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Invoice/Doc No.">
                            <ItemTemplate>
                                <asp:Label ID="lbldetailid" runat="server" Text='<%#Eval("Flag")%>' Style="display: none"></asp:Label>
                                <asp:Label ID="LblFlag" runat="server" Text='<%#Eval("Flag")%>' Style="display: none"></asp:Label>
                                <asp:Label ID="LblInvoiceNo" runat="server" Text='<%#Eval("Invoice")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Customer Name"
                            ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="LblCustN" runat="server" Width="392px" Text='<%#Eval("CustName")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Area Name" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="LblArea" runat="server" Width="150px" Text='<%#Eval("AreaName")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                    CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />--%>
<%--<asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                    CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you want to Delete?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle CssClass="alt" />
                </asp:GridView>--%>

<script type="text/javascript">


shortcut.add("Ctrl+S",function() {
document.getElementById("<%=btnSave.ClientID %>").click();
});
</script>

