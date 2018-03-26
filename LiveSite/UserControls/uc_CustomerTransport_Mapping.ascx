<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CustomerTransport_Mapping.ascx.cs"
    Inherits="UserControls_uc_CustomerTransport_Mapping" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<style type="text/css">
    .style1
    {
        height: 68px;
    }
    .style2
    {
        height: 68px;
        width: 125px;
    }
    .style3
    {
        width: 125px;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
       <span runat="server" id="pageName"></span>
        Customer-Transport Mapping <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
    <div style="float: right; width: 70%">
    </div>
</div>
<div style="float: right; width: 50%">
    <asp:Button ID="btn_Save" CssClass="submitbtn" ValidationGroup="S" runat="server"
        Text="Save" Width="80px" OnClick="btn_Save_Click" />
</div>
<br />
<br />
<asp:Panel ID="PnlCustTransDetails" CssClass="panelDetails" runat="server">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="Customer Code"></asp:Label>
                <font color="red">*</font>
            </td>
             <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                            Width="80px" CssClass="inp-form" TabIndex="7" runat="server" AutoPostBack="true"
                            OnTextChanged="txtcustomer_TextChanged"></asp:TextBox>
                        <div id="dvcust" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                            UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                            ValidationGroup="S" ControlToValidate="txtcustomer">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label></ContentTemplate>
                </asp:UpdatePanel>
            </td>
          
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Transporter Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="110px" colspan="6">
                <asp:DropDownList CssClass="ddl-form" ID="DDlTransport" DataTextField="Value" DataValueField="AutoId"
                    runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqDDlTrans" runat="server" ErrorMessage="Require Transpotrt"
                    InitialValue="none" ValidationGroup="S" ControlToValidate="DDlTransport">.</asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="pnlAreaDetails" runat="server">
    <asp:GridView ID="grdTransportDetails" runat="server" AllowPaging="false" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" Width="600px"
        AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:TemplateField HeaderText="Customer Name" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("CustID")%>' Style="display: none"></asp:Label>
                    <%--  <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustName") %>' ></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Transporter" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblTransporter" runat="server" Text='<%#Eval("TransportID")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false">
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<asp:Panel ID="pnlGet_TransDetails" runat="server">
<asp:UpdatePanel ID="uptdetail" runat="server">
<ContentTemplate>
  <asp:GridView ID="grdget" runat="server" AllowPaging="false" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="5" Width="150px"
        AlternatingRowStyle-CssClass="alt">
    <columns>
    <asp:TemplateField HeaderText="Customer Name" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                 <asp:Label ID="lblCust_ID" runat="server" Text='<%#Eval("CustCode")%>' Style="display: none"></asp:Label>
                    
                     <asp:Label ID="lbl_Value" runat="server" Text='<%#Eval("CustCode")+" : "+Eval("Custname")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Value" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                 <asp:Label ID="lblCust_ID" runat="server" Text='<%#Eval("CustID")%>' Style="display: none"></asp:Label>
                    
                     <asp:Label ID="lbl_Value" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            </columns>
   </asp:GridView>
   </ContentTemplate>
   
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtcustomer" EventName="TextChanged" />
    </Triggers>
   
</asp:UpdatePanel>

</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="S"
    runat="server" ID="ss" />
