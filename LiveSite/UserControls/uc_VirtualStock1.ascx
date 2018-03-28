<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_VirtualStock.ascx.cs"
    Inherits="UserControls_uc_VirtualStock" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Add Virtual Stock<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<div style="float: right; width: 53%">
    <asp:Button ID="btn_Save" CssClass="submitbtn" ValidationGroup="ct1" TabIndex="10"
        runat="server" Text="Save" Width="87px" OnClick="btn_Save_Click" />
</div>
<br />
<br />
<asp:Panel ID="pnlVirtual" CssClass="panelDetails" runat="server" Width="580px" Height="100px">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            
                    <td>
                        <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="lblID1" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="lblInvoce" runat="server" CssClass="lbl-form" Text="Purchase Order No."></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInvoiceNo" autocomplete="off" Width="150px" CssClass="inp-form"
                        onkeypress="return CheckNumeric(event)"
                            TabIndex="1" runat="server" Height="15px" AutoPostBack="true" OnTextChanged="txtInvoiceNo_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqfi" runat="server" ValidationGroup="ct12" ErrorMessage="Enter Purchase Order No"
                            ControlToValidate="txtInvoiceNo">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Remark"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemark" AutoComplete="off" Width="150px" CssClass="inp-form"
                            TabIndex="2" runat="server" Height="15px" TextMode="MultiLine">
                        </asp:TextBox>
                    </td>
               
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDate" runat="server" CssClass="lbl-form" Text="Invoice Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtDate" AutoComplete="off" Width="150px" CssClass="inp-form" TabIndex="3"
                    runat="server" Height="15px">
                </asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                    TargetControlID="txtDate" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Date"
                    ValidationGroup="ct1" ControlToValidate="txtDate">.</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="PnlBook" runat="server" DefaultButton="btnAdd" >
    <table cellpadding="0" cellspacing="0">
        <tr>
           
            <td valign="top">
             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtCode" runat="server" autocomplete="off" AutoPostBack="true" CssClass="inp-form"
                    Height="15px" TabIndex="4" Width="100px" OnTextChanged="txtCode_TextChanged"></asp:TextBox>
                <div id="dvcust" class="divauto350">
                </div>
                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="dvcust" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="10" ContextKey="book"
                    DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                    ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtCode"
                    UseContextKey="true">
                </ajaxCt:AutoCompleteExtender>
                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtCode"
                    WatermarkText="Book Code">
                </ajaxCt:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCode"
                    ErrorMessage="Require Book Code" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtQuantity" onkeypress="return CheckNumericWithDash(event)" Width="100px"
                    CssClass="inp-form" TabIndex="5" Height="15px" runat="server">
                </asp:TextBox>
                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkDDlset" runat="server" TargetControlID="txtQuantity"
                    WatermarkText="Quantity">
                </ajaxCt:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuantity"
                    ErrorMessage="Require Quantity" ValidationGroup="ct">.</asp:RequiredFieldValidator>
            </td>
            <td valign="top">
                 <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <asp:Button ID="btnAdd" CssClass="submitbtn" ValidationGroup="ct" runat="server"
                    Text="Add" TabIndex="6" Width="80px" OnClick="btnAdd_Click" Style="display: none;" />
                    </td>
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                <asp:Label ID="lblDescriptionofGoods" runat="server" CssClass="lbl-form" Font-Size="15px"
                    ForeColor="Blue"></asp:Label>
                <asp:Label ID="lblStandard" Visible="false" runat="server" CssClass="lbl-form" Font-Size="15px"></asp:Label>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Panel>
<asp:ValidationSummary ID="sum" runat="server" ValidationGroup="ct1" ShowMessageBox="true"
    ShowSummary="false" />
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ct"
    ShowMessageBox="true" ShowSummary="false" />
<br />
<asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
    ShowFooter="true" CellPadding="4" CssClass="product-table" ForeColor="#333333"
    Width="843px" PageSize="100" onrowdeleting="gvDetails_RowDeleting">
    <Columns>
        <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <asp:Label ID="lblDetailId" runat="server" Text='<%#Eval("DetailId") %>' Style="display: none;"></asp:Label>
                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description of Goods" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Standard" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblstandard" runat="server" Text='<%#Eval("Standard") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lbltotalQuantity" runat="server"></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Virtual Stock" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="lblVQuantity" runat="server" Text='<%#Eval("VQuantity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Stock" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="40px">
            <ItemTemplate>
                <asp:Label ID="lblTQuantity" runat="server" Text='<%#Eval("TQuantity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="center"
            HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:ImageButton ID="lblDeleteExp" runat="server" CausesValidation="false" CommandName="Delete"
                    CssClass="close" ToolTip="Remove" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do You want to Delete?')" />
                <%--<asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CssClass="close" 
                        ImageUrl="../../Images/icon/save_as.png" CommandName="Edit" />--%>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<asp:Panel ID="pnlArea" CssClass="panelDetails" runat="server" Width="300px">
    <table cellpadding="2" cellspacing="2" style="width: 97%">
        <tr>
            
            <td>
                <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Invoice No"></asp:Label>
                
            </td>
            <td>
                <asp:TextBox ID="txtinvoice" CssClass="inp-form" TabIndex="1" runat="server"
                 onkeypress="return CheckNumeric(event)"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtinvoice"
                    ErrorMessage="Require Invoice No" ValidationGroup="date">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnget" runat="server" CssClass="submitbtn" Text="Get" Width="80px"  TabIndex="2"
                    ValidationGroup="date" OnClick="btnget_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:ValidationSummary ID="val" runat="server" ValidationGroup="date" ShowMessageBox="true"
    ShowSummary="false" />
<asp:GridView ID="grdvirualDetails" runat="server" AutoGenerateColumns="false"
    CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="100" Width="450px">
    <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"
            HeaderText="Invoice No." ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <%-- <asp:Label ID="lblAreaID" runat="server" Style="display: none" Text='<%#Eval("AreaID")%>'></asp:Label>--%>
                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%#Eval("InvoiceNo") %>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" Width="80px" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        
       
        <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        
       
    </Columns>
    <AlternatingRowStyle CssClass="alt" />
</asp:GridView>
 <cr:crystalreportviewer id="VirtualstockView" runat="server"
            AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="true" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="true" hasdrillupbutton="True" hasgotopagebutton="True" 
            haspagenavigationbuttons="True" hasrefreshbutton="true" 
            hassearchbutton="false" hastogglegrouptreebutton="True" hasviewlist="false" 
            haszoomfactorlist="false" height="1039px" width="773px" />
            

