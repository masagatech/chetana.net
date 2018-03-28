<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_LoanPartyMaster.ascx.cs"
    Inherits="UserControls_uc_LoanPartyMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<style type="text/css">
    .style1
    {
        width: 96px;
    }
    .style2
    {
        width: 16px;
    }
    .inp-form
    {
        margin-left: 0px;
    }
    .style3
    {
        width: 32px;
    }
</style>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
        LoanParty Add/Edit<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<div style="float: right; width: 65%">
    <div id="filter" runat="server">
        <span>Filter Data:</span>
        <input name="filt" onkeyup="filter(this, 'sf', '<%=GrdLoanParty.ClientID%>')" type="text">
    </div>
    <div style="float: right; width: 75%">
        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="3" runat="server" Text="Save"
            ValidationGroup="Party" Width="80px" OnClick="btnSave_Click" />
    </div>
</div>
<br />
<br />
<asp:Panel ID="PnlAddLoanParty" CssClass="panelDetails" runat="server" Width="644px">
    <caption>
        <br />
    </caption>
    <table cellpadding="0" cellspacing="0" style="margin-bottom: 0px; width: 98%;">
        <tr>
            <td>
                <asp:Label ID="LblPartyID" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
                <asp:Label ID="LblPartyCode" CssClass="lbl-form" runat="server" Text="Party Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="TxtPartyCode" MaxLength="20" CssClass="inp-form" runat="server" AutoPostBack="True"
                    OnTextChanged="TxtPartyCode_TextChanged"></asp:TextBox>
            </td>
            <td class="style2">
                <asp:RequiredFieldValidator ID="reqCode3" runat="server" ErrorMessage="Enter Party Code"
                    ValidationGroup="Party" ControlToValidate="TxtPartyCode">.</asp:RequiredFieldValidator>
            </td>
            <td class="style1">
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Interest Rate"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="TxtIRate" CssClass="inp-form" runat="server" Width="18px" 
                    MaxLength="5"></asp:TextBox>
            </td>
            <td>
            </td>           
        </tr>
        <tr>
            <td width="100px">
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Party Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="120px">
                <asp:TextBox ID="TxtPartyName" CssClass="inp-form" TabIndex="4" runat="server"></asp:TextBox>
            </td>
            <td class="style2">
                <asp:RequiredFieldValidator ID="reqFnam3" runat="server" ErrorMessage="Require Party Name"
                    ValidationGroup="Party" ControlToValidate="TxtPartyname">.</asp:RequiredFieldValidator>
            </td>
            <td class="style1">
            </td>
        </tr>
        <tr>
            <td colspan="7" style="padding-bottom: 10px; padding-top: 8px;">
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblAdd" runat="server" CssClass="lbl-form" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtAddress" runat="server" CssClass="inp-form" Height="30px" TextMode="MultiLine"
                    Width="134px"></asp:TextBox>
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblS" runat="server" CssClass="lbl-form" Text="State"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DDLState" runat="server" AutoPostBack="true" DataTextField="Name"
                    DataValueField="DMID" OnSelectedIndexChanged="DDLState_SelectedIndexChanged"
                    Width="100px">
                </asp:DropDownList>
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblC" runat="server" CssClass="lbl-form" Text="City"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLCity" runat="server" DataTextField="Name" DataValueField="DMID"
                            Width="100px">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLState" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="style2">
                <asp:RequiredFieldValidator ID="reqDDlCity3" runat="server" ControlToValidate="DDLCity"
                    ErrorMessage="Select City" InitialValue="none" ValidationGroup="Party">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblPH1" runat="server" CssClass="lbl-form" Text="Phone1 "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtPhone1" runat="server" CssClass="inp-form" MaxLength="12"></asp:TextBox>
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblPH2" runat="server" CssClass="lbl-form" Text="Phone2"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtPhone2" runat="server" CssClass="inp-form" MaxLength="12"></asp:TextBox>
            </td>
            <td class="style2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblZip" runat="server" CssClass="lbl-form" Text="Zip"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtZip" runat="server" CssClass="inp-form" MaxLength="8"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblEID" runat="server" CssClass="lbl-form" Text="EmailID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtEmailID" runat="server" CssClass="inp-form"></asp:TextBox>
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="CreditLimit"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtCreditLimit" runat="server" CssClass="inp-form" 
                    MaxLength="20"></asp:TextBox>
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="CreditDays"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtCreditDays" runat="server" CssClass="inp-form" 
                    MaxLength="5"></asp:TextBox>
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td width="100px">
                <asp:Label ID="Label10" CssClass="lbl-form" runat="server" Text="Loan"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RdRG" RepeatDirection="Horizontal" TabIndex="7" runat="server">
                    <asp:ListItem Text="Received"></asp:ListItem>
                    <asp:ListItem Text="Given">Given</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblChk" runat="server" CssClass="lbl-form" Text="Active"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="ChekActive" runat="server" Checked="false" TabIndex="3" />
            </td>
        </tr>
    </table>
    <caption>
        <br />
    </caption>
</asp:Panel>
<br />
<asp:Panel ID="PnlLoanPartyDetails" runat="server">
    <asp:GridView ID="GrdLoanParty" runat="server" AllowPaging="true" AutoGenerateColumns="False"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="10" Width="600px"
        OnRowDeleting="GrdLoanParty_RowDeleting" OnRowEditing="GrdLoanParty_RowEditing">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Party Name" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblPartyID" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("PartyID") %>'></asp:Label>
                    <asp:Label ID="lblPartyCode" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("PartyCode") %>'></asp:Label>
                    <asp:Label ID="lblPartyName" runat="server" CssClass="lbl-form" Text='<%#Eval("PartyName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Interest Rate"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblLoanRG" runat="server" CssClass="lbl-form" Text='<%#Eval("LoanReceivedGiven") %>'></asp:Label>
                    <asp:Label ID="lblAddress" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("Address") %>'></asp:Label>
                    <asp:Label ID="lblZip" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("Zip") %>'></asp:Label>
                    <asp:Label ID="lblStateID" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("StateID")%>'></asp:Label>
                    <asp:Label ID="lblCityID" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("CityID")%>'></asp:Label>
                    <asp:Label ID="lblPhone1" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("Phone1") %>'></asp:Label>
                    <asp:Label ID="lblPhone2" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("Phone2") %>'></asp:Label>
                    <asp:Label ID="lblEmailID" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("EmailID") %>'></asp:Label>
                    <asp:Label ID="lblCreditLimit" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("CreditLimit") %>'></asp:Label>
                    <asp:Label ID="lblCreditDays" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("CreditDays") %>'></asp:Label>
                    <asp:Label ID="lblIRate" runat="server" CssClass="lbl-form" Text='<%#Eval("InterestRate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Active" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkisActive" runat="server" CssClass="lbl-form" Checked='<%#Eval("IsActive") %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    -
                    <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you want to Delete?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Party"
    runat="server" ID="ss" />
