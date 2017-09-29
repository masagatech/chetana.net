<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Get_Packing.ascx.cs" Inherits="Godown_Get_Packing" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Generate Packing Report<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<div style="width: 558px">
    <asp:Button ID="btnget" Style="float: right; margin: 0px 0px 0px 2px" CssClass="submitbtn"
        TabIndex="3" runat="server" Text="Generate Report" OnClick="btnget_Click" ValidationGroup="v1" />
    <asp:ValidationSummary ID="vsummery" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="v1" />
</div>
<br />
<br />
<asp:Panel ID="pnlradio" CssClass="panelDetails" runat="server" Width="520px">
    <table cellpadding="5" cellspacing="5">
        <tr>
            <td align="left" valign="top">
                <asp:RadioButtonList CellPadding="2" CellSpacing="2" ID="rdoview" runat="server"
                    RepeatDirection="Horizontal" CssClass="lbl-form" OnSelectedIndexChanged="rdoview_SelectedIndexChanged"
                    AutoPostBack="true" Width="168px">
                    <asp:ListItem Value="Local" Text="Local" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="Out" Text="Out Station"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnldate" GroupingText="Select Date" CssClass="pnldash" runat="server"
                    Width="250px">
                    <table width="100%" cellpadding="3" cellspacing="3">
                        <tr>
                            <td>
                                <asp:Label ID="lblFromdate" runat="server" Text="From date"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTodate" runat="server" Text="To date"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtfromdate" CssClass="inp-form" runat="server" TabIndex="1"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtfromdate" />
                                <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" AcceptAMPM="true" AutoComplete="true"
                                    CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                                    TargetControlID="txtfromdate" />
                                <asp:RequiredFieldValidator ID="rfvalid" runat="server" ControlToValidate="txtfromdate"
                                    ErrorMessage="Enter From Date!!!" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txttodate" CssClass="inp-form" runat="server" TabIndex="2"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txttodate" />
                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                                    AutoComplete="true" CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                                    TargetControlID="txttodate" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate"
                                    ErrorMessage="Enter To Date!!!" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<%--<asp:Panel ID="pnlFormDetail" Visible="false" runat="server">
    <asp:UpdatePanel ID="upCustomerName0" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Customer"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCust" runat="server" AutoPostBack="True" CssClass="inp-form"
                            OnTextChanged="txtCust_TextChanged" Style="margin-bottom: 0px" TabIndex="8" 
                            Width="259px"></asp:TextBox>
                        <div id="dvcust" class="divauto350">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" CompletionInterval="100"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="dvcust" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="customer"
                            DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="3"
                            ServiceMethod="GetGodownCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtCust"
                            UseContextKey="true">
                        </ajaxCt:AutoCompleteExtender>
                    </td>
                   
                    <td> <asp:Button ID="btnAddRecords" TabIndex="8" CssClass="submitbtn" runat="server" Text="Add" OnClick="btnAddRecords_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Label ID="lblCustID" runat="server" Style="display: none;" Text="0"></asp:Label>
                        <asp:Label ID="lblCustomer" runat="server" Font-Bold="true" Font-Size="10px" ForeColor="Blue"
                            Style="font-size: 11px"></asp:Label>
                    </td>
                </tr>
            </table>
           
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<br />
<br />
<asp:Panel ID="Panel1" runat="server" Width="480px">
   <asp:UpdatePanel ID="upDetails" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="grdTemp" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alt"
                CellPadding="4" CssClass="product-table" OnRowDeleting="grdTemp_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Code">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCustid" Text='<%#Eval("SCHL_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="School Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Style="display: none;" ID="lblCustid" Text='<%#Eval("SCHL_ID") %>'></asp:Label>
                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("SCHL_NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area">
                        <ItemTemplate>
                            <asp:Label ID="lblArea" runat="server" Text='<%#Eval("SCHL_AREA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCustid" Text='<%#Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Del." HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnRemove" ToolTip="Delete this record" ImageUrl="~/Images/icon/DeleteIcon.gif"
                                CommandName="Delete" 
                                runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
      </ContentTemplate>
       <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddRecords" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>--%>
<br />
<CR:CrystalReportViewer ID="PackingReport" runat="server" AutoDataBind="true" DisplayGroupTree="false"
    EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
    EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
    HasRefreshButton="true" HasSearchButton="false" HasViewList="false" HasZoomFactorList="false"
    Height="1039px" Width="773px" ShowAllPageIds="True" />
