<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="KycForm_View.aspx.cs" Inherits="KycForm_View" Title="KycForm View" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Kyc Form View<a href="Campaigns.aspx" title="back to campaign list"></a>
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
    <asp:Panel ID="NewHederPanel" runat="server" DefaultButton="btnGet">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblFrom" runat="server">Kyc From :</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFrom" CssClass="inp-form" runat="server" onkeypress="return CheckNumeric(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required Kyc From No"
                        ValidationGroup="V" ControlToValidate="txtFrom">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblTo" runat="server">To :</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTo" CssClass="inp-form" runat="server" onkeypress="return CheckNumeric(event)"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Kyc To No"
                        ValidationGroup="V" ControlToValidate="txtTo">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btnGet" runat="server" Text="Get" Width="270%" CssClass="submitbtn" OnClick="btnGet_Click" ValidationGroup="V" />
                </td>
                <td>
                    <asp:ValidationSummary ID="validation" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="V" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:UpdatePanel ID="UpdateKycPanel" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridKycView" runat="server" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="8" Width="1025px" AlternatingRowStyle-CssClass="alt" ShowFooter="true">
                <Columns>
                    <asp:TemplateField HeaderText="Kyc No" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblKycNo" runat="server" Text='<%#Eval("KycNo") %>'></asp:Label>
                            <asp:Label ID="lblCustAddress" runat="server" Style="display: none" Text='<%#Eval("CustAddress") %>'></asp:Label>
                            <asp:Label ID="lblCity" runat="server" Style="display: none" Text='<%#Eval("City") %>'></asp:Label>
                            <asp:Label ID="lblZipCode" runat="server" Style="display: none" Text='<%#Eval("ZipCode") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kyc Date" HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblKycDate" runat="server" Text='<%#Eval("CreatedOn") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="10px" />
                        <ItemStyle HorizontalAlign="center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Code" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustCode") %>'></asp:Label>
                            <asp:Label ID="lblzodeCode" runat="server" Style="display: none" Text='<%#Eval("ZoneCode") %>'></asp:Label>
                            <asp:Label ID="lblTelNo" runat="server" Style="display: none" Text='<%#Eval("TelNo") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Name" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName") %>'></asp:Label>
                            <asp:Label ID="lblMobile" runat="server" Style="display: none" Text='<%#Eval("MobileNo") %>'></asp:Label>
                            <asp:Label ID="lblDelAddress" runat="server" Style="display: none" Text='<%#Eval("DelAddr") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblArea" runat="server" Text='<%#Eval("Area") %>'></asp:Label>
                            <asp:Label ID="lblTrasport" runat="server" Style="display: none" Text='<%#Eval("Transport") %>'></asp:Label>
                            <asp:Label ID="lblDis" runat="server" Style="display: none" Text='<%#Eval("Dis") %>'></asp:Label>
                            <asp:Label ID="lblTitle" runat="server" Style="display: none" Text='<%#Eval("Titles") %>'></asp:Label>
                            <asp:Label ID="lblSchTr" runat="server" Style="display: none" Text='<%#Eval("SchLTR") %>'></asp:Label>
                            <asp:Label ID="lblAddComm" runat="server" Style="display: none" Text='<%#Eval("AddCommFrm") %>'></asp:Label>
                            <asp:Label ID="lblOS" runat="server" Style="display: none" Text='<%#Eval("OS") %>'></asp:Label>
                            <asp:Label ID="lblAvg" runat="server" Style="display: none" Text='<%#Eval("TotalAvg") %>'></asp:Label>
                            <asp:Label ID="lblIfBkseller" runat="server" Style="display: none" Text='<%#Eval("IfBkseller") %>'></asp:Label>
                            <asp:Label ID="lblDisForm" runat="server" Style="display: none" Text='<%#Eval("DisForm") %>'></asp:Label>
                            <asp:Label ID="lblRemark" runat="server" Style="display: none" Text='<%#Eval("Remark") %>'></asp:Label>
                            <asp:Label ID="lblPrevDis" runat="server" Style="display: none" Text='<%#Eval("PrevDis") %>'></asp:Label>
                            <asp:Label ID="lblPrevtitle" runat="server" Style="display: none" Text='<%#Eval("PrevTitle") %>'></asp:Label>
                            
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Details" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%--<a id="btnView_Click" runat="server" href="javascript:void(0)" style="color: Blue" onserverclick="btnView_Click">View</a>--%>
                            <asp:LinkButton ID="btnView" runat="server" Text="View" Style="color: Blue" OnClick="btnView_Click" />
                            <%--<asp:ImageButton ID="imgbtndetails" runat="server" OnClick="btnView_Click" />--%>
                        </ItemTemplate>
                        <HeaderStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGet" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Panel ID="PnlInsertDocNum" runat="server" Style="display: none; text-align: left;
        height: 140px;">
        <asp:UpdatePanel ID="updetails" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div class="facebox">
                    <asp:Label ID="Label22" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
                        ForeColor="White"></asp:Label>
                    <a id="A1" class="close" style="right: 0;" runat="server" href="javascript:void(0);"
                        onclick="closeEditPopup();">
                        <img src="Images/button-cross.png" /></a>
                    <br />
                    <div class="content">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSrNo" runat="server">Kyc No.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblKycId" runat="server" Visible="true" Text="0"></asp:Label>
                                </td>
                                
                                <td>
                                    <asp:Label ID="lblKycDate" runat="server">Kyc Date</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKycDate" CssClass="inp-form" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <%--<asp:Label ID="lblAutoExtend" runat="server"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label17" runat="server">Party Code</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCustCode" runat="server" TabIndex="3" CssClass="inp-form" autocomplete="off"
                                        AutoPostBack="True">
                                    </asp:TextBox>
                                    <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                        ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                        CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtCustCode"
                                        UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                                    </ajaxCt:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server">Party Name</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCustName" runat="server" TabIndex="4" Style="width: 139%" CssClass="inp-form"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label21" runat="server">Party Add.</asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtCustAdd" runat="server" TabIndex="5" TextMode="MultiLine" Style="width: 100%;"
                                        CssClass="inp-form"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server">City</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCity" runat="server" TabIndex="6" CssClass="inp-form"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server">Area</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtArea" runat="server" TabIndex="7" CssClass="inp-form"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server">Zone Code</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtZoneCode" runat="server" TabIndex="8" CssClass="inp-form"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server">Zip Code</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtZipCode" runat="server" TabIndex="9" CssClass="inp-form"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="4">
                                    <asp:Label ID="lblZoneCode" Style="color: Blue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server">Mobile No.</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMobile" runat="server" TabIndex="10" CssClass="inp-form"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server">Telepone No.</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTelephone" runat="server" TabIndex="11" CssClass="inp-form"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server">If Bookseller</asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbtnChr" runat="server" TabIndex="12" Text="CH RECD" GroupName="rbtnChr" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbtnSch" runat="server" TabIndex="13" Text="SCH" GroupName="rbtnChr" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbtnWcp" runat="server" TabIndex="14" Text="WCP" GroupName="rbtnChr" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbtnCod" runat="server" TabIndex="15" Text="COD" GroupName="rbtnChr" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server">Del.Add</asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtDelAdd" runat="server" TabIndex="16" TextMode="MultiLine" Style="width: 100%"
                                        CssClass="inp-form"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server">Transporter Details</asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList TabIndex="17" Width="100%" CssClass="ddl-form ddlTransport" ID="txtTransport"
                                        DataTextField="Value" DataValueField="AutoId" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server">Outstanding</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOS" Font-Bold="true" runat="server">0</asp:Label>&nbsp;(Current)
                                </td>
                                 <td>
                                    <asp:Label ID="Label13" runat="server">Book Return%</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAvg" Font-Bold="true" runat="server">0</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <b>Prev. Year</b>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <b>Current Year</b>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server">Discount :</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblprvyeardisc" runat="server"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDisYear" runat="server" TabIndex="18" CssClass="inp-form"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label16" runat="server">Titles :</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblpreyeartitles" runat="server"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTitlesYear" runat="server" TabIndex="19" CssClass="inp-form"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server">Attached :</asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="ChkScheme" runat="server" TabIndex="20" Text="Scheme Letter" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="ChkAddComminsion" runat="server" TabIndex="21" Text="Add Commision" />
                                </td>
                                <td style="width: 107px;">
                                    <asp:CheckBox ID="ChkDisForm" runat="server" TabIndex="22" Text="Add Discount Form" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server">Remark</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRemrk" runat="server" TabIndex="23" TextMode="MultiLine" Style="width: 170%"
                                        CssClass="inp-form"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <ajaxCt:ModalPopupExtender ID="ModalPopUpDocNum" runat="server" TargetControlID="LnkBtn"
        PopupControlID="PnlInsertDocNum" BackgroundCssClass="modalBackground" DropShadow="false"
        EnableViewState="false" />
    <asp:LinkButton ID="LnkBtn" runat="server" Style="display: none;">LinkButton</asp:LinkButton>

    <script type="text/javascript">
        function openShowpopMethod()
        {
                    $find('<%=ModalPopUpDocNum.ClientID %>').show();
        }

            shortcut.add("Ctrl+E",function() {
               openShowpopMethod();         
            });

            shortcut.add("esc",function() {
                 closeEditPopup();      
            });

        function openEditPopup()
        {
        openShowpopMethod();
        return false;
        }
        function closeEditPopup()
        {
        $find('<%=ModalPopUpDocNum.ClientID %>').hide();
        }
    </script>

</asp:Content>
