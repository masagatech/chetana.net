<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Scheme_CustomerMapping.ascx.cs"
    Inherits="UserControls_uc_Scheme_CustomerMapping" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <td>
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
            </a>
        </div>
        <div class="options">
        </div>
    </td>
</div>
<div style="float: right; width: 60%">
    <asp:Button ID="btn_Save" CssClass="submitbtn" TabIndex="11" runat="server" Text="Save"
        ValidationGroup="Schememap" Width="80px" OnClick="btn_Save_Click" />
</div>
<br />
<br />
<asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Width="480px">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td width="95px">
                <asp:Label ID="lblID" runat="server" Text="0" Style="display: none;"></asp:Label>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Scheme"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="DDLScheme" Width="200px" DataTextField="value"
                    DataValueField="AutoID" TabIndex="1" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqa" runat="server" ErrorMessage="Require Scheme"
                    InitialValue="0" ValidationGroup="Schememap" ControlToValidate="DDLScheme">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="Customer Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                            Width="80px" CssClass="inp-form" TabIndex="2" runat="server" AutoPostBack="true"
                            OnTextChanged="txtcustomer_TextChanged"></asp:TextBox>
                        <div id="dvcust" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                            UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                            ValidationGroup="Schememap" ControlToValidate="txtcustomer">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label></ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label12" CssClass="lbl-form" runat="server" Text="Amount"></asp:Label>
                 <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtamount" CssClass="inp-form" autocomplete="off" onkeypress="return CheckNumericWithDot(event)"
                    TabIndex="3" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Amount"
                    ValidationGroup="Schememap" ControlToValidate="txtamount">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Discount"></asp:Label>
                 <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtdiscount" CssClass="inp-form" autocomplete="off" onkeypress="return CheckNumericWithDot(event)"
                    TabIndex="4" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require Discount"
                    ValidationGroup="Schememap" ControlToValidate="txtdiscount">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Years"></asp:Label>
                 <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtyear" CssClass="inp-form" autocomplete="off" onkeypress="return CheckNumeric(event)"
                    TabIndex="5" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Require Year"
                    ValidationGroup="Schememap" ControlToValidate="txtyear">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Start Year From"></asp:Label>
                 <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtstartYear" CssClass="inp-form" autocomplete="off" onkeypress="return CheckNumeric(event)"
                    TabIndex="6" runat="server"></asp:TextBox> 
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Require Start Year"
                    ValidationGroup="Schememap" ControlToValidate="txtstartYear">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr >
            <td>
                <asp:CheckBox ID="chkIsDelivered" TabIndex="7" runat="server" Text="   Delivered" />
            </td>
            <td>
                <asp:TextBox ID="txtdeldate" runat="server" autocomplete="off" 
                    CssClass="inp-form" onkeypress="return CheckNumeric(event)" TabIndex="8"></asp:TextBox>
                     <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtdeldate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtdeldate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="chkIsReceived" runat="server" TabIndex="9" 
                    Text="   Received" />
            </td>
            <td>
                <asp:TextBox ID="txtrdate" runat="server" autocomplete="off" 
                    CssClass="inp-form" onkeypress="return CheckNumeric(event)" TabIndex="10"></asp:TextBox>
                      <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtrdate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtrdate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Schememap"
    runat="server" ID="ss" />
<asp:Panel ID="Panel2" runat="server">
    <asp:GridView ID="GrdDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="50" Width="600px"
        OnRowEditing="GrdDetails_RowEditing" 
        OnRowDeleting="GrdDetails_RowDeleting" AlternatingRowStyle-CssClass="alt" 
        onpageindexchanging="GrdDetails_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Scheme Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblAutoID" runat="server" Style="display: none" Text='<%#Eval("SchemeMappingID")%>'></asp:Label>
                    <asp:Label ID="lblSchemeID" runat="server" Style="display: none" Text='<%#Eval("SchemeID") %>'></asp:Label>
                     <asp:Label ID="lbldeldate" runat="server" Style="display: none" Text='<%#Eval("DeliveredDate") %>'></asp:Label>
                      <asp:Label ID="lblrecdate" runat="server" Style="display: none" Text='<%#Eval("ReceivedDate") %>'></asp:Label>
                    <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("Value") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Cust Code" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    
                    <asp:Label ID="lblCustCode" runat="server"  Text='<%#Eval("CustCode")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cust Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Area Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAreaName" runat="server" Text='<%#Eval("AreaName")%>'></asp:Label>
                  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'></asp:Label>
                    <asp:CheckBox ID="chkIss" runat="server" Enabled="false" Checked='<%#Eval("ISS")%>'
                        Style="display: none;"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Years" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblYears" runat="server" Text='<%#Eval("Years")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="StartYear" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblStartYear" runat="server" Text='<%#Eval("StartYear")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="IsDelivered" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkDelivered" runat="server" Enabled="false" Checked='<%#Eval("IsDelivered")%>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="IsReceived" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkReceived" runat="server" Enabled="false" Checked='<%#Eval("IsReceived")%>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you want to Delete?')" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
