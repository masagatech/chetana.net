<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Copy of uc_Customer_Discount_Mapping.ascx.cs"
    Inherits="UserControls_uc_Customer_Discount_Mapping" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<style type="text/css">
    .style1
    {
        width: 268435488px;
        height: 68px;
    }
    .style2
    {
        height: 68px;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
       <span runat="server" id="pageName"></span>
        Customer-Disount Mapping <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
</div>
<div style="float: right; width: 70%">
    <asp:UpdatePanel ID="upSAve" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="btn_Save" CssClass="submitbtn" ValidationGroup="Discount" TabIndex="3"
                runat="server" Text="Save" Width="80px" OnClick="btn_Save_Click" /></ContentTemplate>
    </asp:UpdatePanel>
</div>
<br />
<br />
<asp:Panel ID="pnlCust" CssClass="panelDetails" runat="server" Width="693px">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="Customer Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtcustomer" autocomplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="1" runat="server" AutoPostBack="true" OnTextChanged="txtcustomer_TextChanged"></asp:TextBox>
                        <div id="dvcust" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                            UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="rfvcust" runat="server" ErrorMessage="Require Customer"
                            ValidationGroup="Discount" ControlToValidate="txtcustomer">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label></ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<br />
<asp:Panel ID="PnlCustDiscDetails" CssClass="panelDetails" runat="server" Height="54px"
    Width="697px">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td width="90px">
                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Booktype"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList  CssClass="ddl-form" ID="DDlBooktype" DataTextField="Value" DataValueField="Autoid"
                            TabIndex="2" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqBooktype" runat="server" ErrorMessage="Require Booktype"
                            InitialValue="0" ValidationGroup="Discount" ControlToValidate="DDlBooktype">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="90px">
                <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="Discount"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtdiscount" CssClass="inp-form" TabIndex="3" Width="80px" 
                    runat="server" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Discount"
                    ValidationGroup="Discount" ControlToValidate="txtdiscount">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="90px">
                <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="Additional Discount"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtAdiscount" Width="80px" CssClass="inp-form" TabIndex="4" 
                    runat="server" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqAdiscount" runat="server" ErrorMessage="Require Add. Disc."
                    InitialValue="0" ValidationGroup="Discount" ControlToValidate="txtAdiscount">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="LblActive" runat="server" Text="Active " CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="ChkActive" Checked="true" runat="server" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:UpdatePanel ID="UpanelGrd" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <table width="100%">
            <asp:GridView ID="GrdViewCustDisDetails" runat="server" CssClass="product-table"
                AutoGenerateColumns="false" Width="650px" OnRowEditing="GrdViewCustDisDetails_RowEditing">
                <Columns>
                    <asp:TemplateField HeaderText="Book Type" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblBKTYPCustDisID" runat="server" Style="display: none;" Text='<%#Eval("BKTYPCustDisID")%>'></asp:Label>
                            <asp:Label ID="LblCustId" runat="server" Style="display: none;" Text='<%#Eval("CustID")%>'></asp:Label>
                            <asp:Label ID="lblCustName" runat="server" Style="display: none;" Text='<%#Eval("CustName")%>'></asp:Label>
                            <asp:Label ID="lblBookType" runat="server" Text='<%#Eval("BookType")%>'></asp:Label>
                            <asp:Label ID="lblBookTypeCode" runat="server" Style="display: none" Text='<%#Eval("Booktypeid")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Discount %" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:TextBox ID="lblDiscount" runat="server" Width="60px" Style="text-align: right"
                                MaxLength="10" Text='<%#Eval("Discount","{0:0.00}")%>'></asp:TextBox>
                            <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" TargetControlID="lblDiscount"
                                FilterType="Custom, Numbers" ValidChars="+-=/*()." />
                           <asp:Label ID="lblAdDiscount" runat="server" Style="text-align: right;display: none;"  Text="0"></asp:Label>
                         <asp:CheckBox ID="chkisActive" runat="server" Checked='<%#Eval("IsActive") %>' style="display:none" Enabled="true">
                            </asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                   <%--<asp:TemplateField HeaderText="IsActive" ItemStyle-HorizontalAlign="Center" style="display:none">
                        <ItemTemplate>
                           

                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--  <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" CssClass="close" runat="server" CausesValidation="false"
                        CommandName="Edit" ToolTip="Edit" ImageUrl="../Images/icon/edit_icon.png" />&nbsp;&nbsp;
                     </ItemTemplate>
            </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Discount"
    runat="server" ID="ss" />
