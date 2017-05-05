<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Token_Register_Edit.aspx.cs" Inherits="Token_Register_Edit" Title="Token Register Edit" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .TextBoxWodth
        {
            width: 60px;
        }
        .TextBoxWodths
        {
            width: 84px;
        }
        .panelDetail
        {
            border: 1px solid #9C9C9C;
            background-color: #EEE;
            width: 993px;
            padding: 1.5em 18px;
            background: #008800;
            background: -moz-linear-gradient(top, #BDBDBD, #9C9C9C);
            background: -webkit-gradient(linear, left top, left bottom, from(#BDBDBD), to(#9C9C9C));
        }
        .submitbtn
        {
            margin-top: 10px;
            color: #FFFFFF;
            font: 12px ARIAL;
            background-color: #fed;
            padding: 2px;
            border: 1px solid #9C9C9C;
            background: #008800;
            background: -moz-linear-gradient(top, #C6C6C6, #9C9C9C);
            background: -webkit-gradient(linear, left top, left bottom, from(#C6C6C6), to(#9C9C9C));
            -webkit-box-shadow: 0 8px 15px rgba(0, 0, 0, 0.7);
            -webkit-box-shadow: 0 2px 2px rgba(0, 0, 0, 0.7);
            -webkit-box-shadow: 0 2px 2px rgba(0, 0, 0, 0.7);
        }
        .ddlReceiveWidth
        {
            width: 100%;
        }
        .customercss
        {
            width: 205px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       Edit Token Register<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <asp:Panel ID="pnlra" runat="server">
        <div style="float: right; width: 58%">
            <div id="filter" runat="server">
            </div>
        </div>
    </asp:Panel>
    <div class="options">
    </div>
</div>
    <asp:UpdatePanel ID="KycAndDateWise" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:RadioButton ID="rbtnToken" AutoPostBack="true" runat="server" Text="Token No"
                            GroupName="TokenRadio" OnCheckedChanged="rbtnKyc_CheckedChanged" />
                        <asp:RadioButton ID="rbtnKyc" AutoPostBack="true" runat="server" Text="Kyc No" GroupName="TokenRadio"
                            OnCheckedChanged="rbtnKyc_CheckedChanged" />
                        <asp:RadioButton ID="rbtDatewise" runat="server" AutoPostBack="true" Text="Date Wise"
                            GroupName="TokenRadio" OnCheckedChanged="rbtnKyc_CheckedChanged" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Panel ID="TokenWise" runat="server">
                            <asp:Label ID="Label1" runat="server" Text="Token No"></asp:Label>
                            <asp:TextBox ID="txtTokenFind" CssClass="TextBoxWodth" runat="server" TabIndex="9"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required Token No"
                                ValidationGroup="Token" ControlToValidate="txtTokenFind">.</asp:RequiredFieldValidator>
                            <asp:Button ID="btnToken" runat="server" CssClass="submitbtn" Text="Get" Width="53px" TabIndex="10"
                                OnClick="Get_Click" ValidationGroup="Token" />
                        </asp:Panel>
                        <asp:Panel ID="KycNoWise" runat="server" Visible="false">
                            <asp:Label ID="lblKycFind" runat="server" Text="Kyc No"></asp:Label>
                            <asp:TextBox ID="txtKycFind" CssClass="TextBoxWodth" runat="server" TabIndex="11"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required Kyc No"
                                ValidationGroup="Kyc" ControlToValidate="txtKycFind">.</asp:RequiredFieldValidator>
                            <asp:Button ID="kycbtnGet" runat="server" CssClass="submitbtn" TabIndex="12" Text="Get" Width="53px"
                                OnClick="Get_Click" ValidationGroup="Kyc" />
                        </asp:Panel>
                        <asp:Panel ID="DateWise" runat="server" Visible="false">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="TextBoxWodths" TabIndex="13"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required From Date"
                                ValidationGroup="V" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                            <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="TextBoxWodths" TabIndex="14"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtToDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required To Date"
                                ValidationGroup="V" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                            <asp:Button ID="btnGet" runat="server" CssClass="submitbtn" Text="Get" Width="53px" TabIndex="15"
                                OnClick="Get_Click" ValidationGroup="V" />
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                            ValidationGroup="V" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary2" ShowMessageBox="true" ShowSummary="false"
                            ValidationGroup="Kyc" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary3" ShowMessageBox="true" ShowSummary="false"
                            ValidationGroup="Token" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpGridData" runat="server">
        <ContentTemplate>
            <br />
            <asp:Panel ID="PanelId" runat="server" CssClass="panelDetail">
                <table style="width: 100%;">
                    <tr>
                     <td style="padding-top: 18px">
                            <asp:Label ID="lblCustomer" runat="server" Text="Customer Name"></asp:Label>
                            <asp:TextBox ID="txtCustomerName" CssClass="customercss" onblur="customerName(this);"
                                autocomplete="off" TabIndex="1" runat="server"></asp:TextBox>
                            <div id="dvcust" class="divauto350">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtCustomerName"
                                UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                            </ajaxCt:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                                ValidationGroup="S" ControlToValidate="txtCustomerName">.</asp:RequiredFieldValidator>
                        </td>
                        <td style="padding-top: 6px; width: 6%">
                            <asp:Label ID="lblTokenNo" runat="server" Style="display: none;" Text="0"></asp:Label>
                            <asp:Label ID="lblKycno" runat="server" Text="Kyc No"></asp:Label>
                            <asp:TextBox ID="txtKycNo" CssClass="TextBoxWodth" runat="server" TabIndex="2"
                             ></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Require Kyc No"
                                ValidationGroup="S" ControlToValidate="txtKycNo">.</asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="padding-top: 18px; width: 90px;">
                            <asp:Label ID="lblOrderReceived" runat="server" Text="Order Received"></asp:Label>
                            <asp:TextBox ID="txtOrderDate" runat="server" CssClass="TextBoxWodths" TabIndex="3"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtOrderDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtOrderDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require Order Date"
                                ValidationGroup="S" ControlToValidate="txtOrderDate">.</asp:RequiredFieldValidator>
                        </td>
                        <td style="padding-top: 16px; width: 93px;">
                            <asp:Label ID="lblDeliveryDate" runat="server" Text="Delivery Date"></asp:Label>
                            <asp:TextBox ID="txtDeliveryDate" CssClass="TextBoxWodths" runat="server" TabIndex="4"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDeliveryDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDeliveryDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Delivery Date"
                                ValidationGroup="S" ControlToValidate="txtDeliveryDate">.</asp:RequiredFieldValidator>
                        </td>
                        <td style="padding-top: 18px">
                            <asp:Label ID="lblReceived" runat="server" Text="Received Via"></asp:Label>
                            <asp:DropDownList CssClass="ddl-form ddlReceiveWidth" ID="ddlReceived" TabIndex="5"
                                runat="server">
                                <asp:ListItem Enabled="true" Text="Select Received" Value="-1"></asp:ListItem>
                                <asp:ListItem Enabled="true" Text="Email" Value="Email"></asp:ListItem>
                                <asp:ListItem Enabled="true" Text="Phone" Value="Phone"></asp:ListItem>
                                <asp:ListItem Enabled="true" Text="Fax" Value="Fax"></asp:ListItem>
                                <asp:ListItem Enabled="true" Text="Other" Value="Other"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required Received Via Selected"
                                ValidationGroup="S" ControlToValidate="ddlReceived" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="padding-top: 9px">
                            <asp:Label ID="lblHandedOver" runat="server" Text="Order No"></asp:Label>
                            <asp:TextBox ID="txtHandedOverTo" Style="width: 96%;" runat="server" TabIndex="6"></asp:TextBox>
                        </td>
                        <td style="padding-top: 3%">
                            <asp:Label ID="lblRemark" runat="server" Text="Remark"></asp:Label>
                            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" TabIndex="7"></asp:TextBox>
                        </td>
                        <td style="padding-left: 9px">
                            <asp:Button ID="btnAdd" runat="server" CssClass="submitbtn" Text="Save" TabIndex="8"
                                ValidationGroup="S" Width="53px" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ValidationSummary ID="validation" ShowMessageBox="true" ShowSummary="false" ValidationGroup="S"
                                runat="server" />
                        </td>
                        <td>
                        </td>
                        <td colspan="6">
                            <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <asp:GridView ID="grdTokenRegister" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="8" Width="1025px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="true" OnRowEditing="grdTokenRegister_RowEditing" OnSelectedIndexChanged="grdTokenRegister_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Token No" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTokenNo" runat="server" Text='<%#Eval("TokenNo")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kyc No" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTokenId" Style="display: none;" runat="server" Text='<%#Eval("TokenNo")%>'></asp:Label>
                            <asp:Label ID="lblKycNo" runat="server" Text='<%#Eval("KYC_No")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Received Date" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblOrderRecDate" runat="server" Text='<%#Eval("Ord_Rec_Date")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCustomer" runat="server" Text='<%#Eval("CustCode")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Name" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDeliveryDate" runat="server" Text='<%#Eval("DeliveryDate")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Received Via" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblReceived" runat="server" Text='<%#Eval("ReceivedVia")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblHanded" runat="server" Text='<%#Eval("HandOver")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remark")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdits" ImageUrl="~/Images/icon/edit_Icon.png" runat="server"
                                OnClick="btnEdits_Click" />
                          <asp:ImageButton ID="btnRemove" ImageUrl="~/Images/icon/DeleteIcon.gif" OnClick="btnRemove_Click"
                                OnClientClick="return confirm('Are you sure want to remove this book');" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="alt" />
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGet" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="kycbtnGet" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">
    
        function customerName(val)
        {
            var data = $(val).val();
            var splits = data.split("::");
            $(val).val(splits[0].toString().trim());
            
            $('#<%=lblCustName.ClientID %>').text(data);
        }
        
      function check(val)
      {
        var KycNo=$(val).attr('value');
      }
    </script>

</asp:Content>
