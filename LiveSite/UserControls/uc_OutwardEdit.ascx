<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_OutwardEdit.ascx.cs"
    Inherits="UserControls_uc_OutwardEdit" %>
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
<asp:Panel ID="Pnlselect" CssClass="panelDetails" runat="server" Width="400px">
    <table>
        <tr>
            <td width="120px">
                <asp:Label ID="Label1" runat="server" Text="Dcoument No" CssClass="lbl-form"></asp:Label>
                <font color="red">*</font>
                <asp:Label ID="LblODMID" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
            </td>
            <td width="5px">
            </td>
            <td width="150px">
                <asp:TextBox ID="Txtdocno" runat="server" CssClass="inp-form" OnTextChanged="Txtdocno_TextChanged"
                    TabIndex="2" Width="85px" AutoPostBack="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtEmp"
                    ErrorMessage="Require Employee Name" ValidationGroup="OD">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="120px">
                <asp:Label ID="Label11" CssClass="lbl-form" runat="server" Text="Outward Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="5px">
            </td>
            <td width="150px">
                <asp:UpdatePanel ID="UpPnldate" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOutwardDate" runat="server" AutoPostBack="True" CssClass="inp-form"
                            Enabled="true" TabIndex="1" Width="85px"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtOutwardDate" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" AcceptAMPM="true" AutoComplete="true"
                            CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                            TargetControlID="txtOutwardDate" />
                        <asp:RequiredFieldValidator ID="Rqfow" runat="server" ControlToValidate="txtOutwardDate"
                            ErrorMessage="Require OutWard Date" ValidationGroup="OD">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="120px">
                <asp:Label ID="LblEmp" runat="server" CssClass="lbl-form" Text="Employee Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="5px">
            </td>
            <td width="150px">
                <asp:TextBox ID="TxtEmp" runat="server" CssClass="inp-form" Width="85px" TabIndex="2"> </asp:TextBox>
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
                <asp:TextBox ID="TxtRemark" runat="server" CssClass="inp-form" Height="30px" TabIndex="3"
                    TextMode="MultiLine" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqRem" runat="server" ControlToValidate="TxtRemark"
                    ErrorMessage="Enter Comment" ValidationGroup="//Entry">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="100px">
                <asp:RadioButtonList ID="RdbtnSelect" runat="server" AutoPostBack="false" CssClass="lbl-form"
                    OnSelectedIndexChanged="RdbtnSelect_SelectedIndexChanged" RepeatDirection="Horizontal"
                    TabIndex="4" Width="150px">
                    <asp:ListItem Text="Invoice" Value="Invoice"></asp:ListItem>
                    <asp:ListItem Text="Document" Value="Document"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="Reqrdb" runat="server" ControlToValidate="RdbtnSelect"
                    ErrorMessage="Select Invoice/Document" ValidationGroup="Entry">.</asp:RequiredFieldValidator>
            </td>
            <td width="5px">
                <font color="red">*</font>
            </td>
            <td>
                <asp:Panel ID="pnladd" runat="server" DefaultButton="btnadd" TabIndex="5">
                    <asp:TextBox ID="Txtno" runat="server" CssClass="inp-form" OnTextChanged="Txtno_TextChanged"
                        Width="85px"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter4" runat="server" FilterType="Custom, Numbers"
                        TargetControlID="Txtno" ValidChars="." />
                    <asp:RequiredFieldValidator ID="Reqno" runat="server" ControlToValidate="Txtno"
                        ErrorMessage="Enter Invoice/Document " ValidationGroup="Entry">.</asp:RequiredFieldValidator>
                    <asp:Button ID="btnadd" runat="server" CssClass="submitbtn" OnClick="btnadd_Click"
                        Style="display: none" TabIndex="5" Text="Add" ValidationGroup="Entry" Width="70px" />
                </asp:Panel>
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
                <asp:Label ID="lblArea" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"
                    Style="display: none" Width="450px"></asp:Label>
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
                    CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="JavaScript:return confirm('Do you really want to delete this record?')" />
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