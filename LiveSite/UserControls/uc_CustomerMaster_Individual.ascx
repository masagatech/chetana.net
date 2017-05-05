<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CustomerMaster_Individual.ascx.cs"
    Inherits="UserControls_uc_CustomerMaster_Individual" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%--<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>--%>
<style type="text/css">
    .inp-formNew {
        border: 1px solid #adadad;
        color: #393939;
        height: 15px;
        width: 30px;
        padding: 3px 6px 3px 6px;
        background-color: ThreeDFace;
    }

    .inp-formNewBook {
        border: 1px solid #adadad;
        color: #393939;
        height: 15px;
        width: 110px;
        padding: 3px 6px 3px 6px;
        background-color: ThreeDFace;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Edit Customer<a href="Campaigns.aspx" title="back to campaign list"></a>
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
<asp:Panel ID="PnlDetails" runat="server">
    <%--  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>--%>
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtcustomer" autocomplete="off" Width="300px" CssClass="inp-form"
                    TabIndex="0" runat="server"></asp:TextBox>
                <div id="dvcust1" class="divauto350">
                </div>
                <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender1" runat="server" CompletionListCssClass="AutoExtender"
                    CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    Enabled="True" ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                    UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust1">
                </ajaxCt:AutoCompleteExtender>
                <%--<asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                            ValidationGroup="S" ControlToValidate="txtcustomer">.</asp:RequiredFieldValidator>--%>
            </td>
            <td>
                <asp:Button ID="btnGetData" runat="server" ValidationGroup="pdateft1" Text="Get Details"
                    OnClick="btnGetData_Click" TabIndex="0" />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload"
                    OnClick="btnUpload_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                    runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <br />
</asp:Panel>
<div style="float: right; width: 45%;">
    <asp:Button ID="BtnAdd" CssClass="submitbtn" runat="server" Style="display: none;"
        Text="Add New" OnClick="BtnAdd_Click" />
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="55" runat="server" Text="Save"
        Width="70px" OnClick="btnSave_Click" ValidationGroup="ct" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ct"
        ShowMessageBox="true" ShowSummary="false" />
    <asp:Button ID="btncancel" Style="display: none;" CssClass="submitbtn" TabIndex="4"
        runat="server" Text="Cancel" Width="80px" OnClick="btncancel_Click" />
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
</div>
<asp:GridView ID="grdCustDetails" runat="server" AllowPaging="true" AutoGenerateColumns="False"
    Style="display: none;" CellPadding="4" CssClass="product-table" ForeColor="#333333"
    OnPageIndexChanging="grdCustDetails_PageIndexChanging" OnRowDeleting="grdCustDetails_RowDeleting"
    Width="985px" OnSelectedIndexChanging="grdCustDetails_SelectedIndexChanging"
    OnRowEditing="grdCustDetails_RowEditing">
    <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Cust Code">
            <ItemTemplate>
                <asp:Label ID="lblShortForm" runat="server" Style="display: none;" Text='<%#Eval("ShortForm") %>'></asp:Label>
                <asp:Label ID="lblFamilyCode" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("FamilyCode") %>'></asp:Label>
                <asp:Label ID="lblAddress" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Address") %>'></asp:Label>
                <asp:Label ID="lblCustCode" runat="server" CssClass="lbl-form" Text='<%#Eval("CustCode") %>'></asp:Label>
                <asp:Label ID="lblZip" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Zip") %>'></asp:Label>
                <asp:Label ID="lblPhone1" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Phone1") %>'></asp:Label>
                <asp:Label ID="lblPhone2" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Phone2") %>'></asp:Label>
                <asp:Label ID="lblEmailID" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("EmailID") %>'></asp:Label>
                <asp:Label ID="lblCreditLimit" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CreditLimit") %>'></asp:Label>
                <asp:Label ID="LblPrincipalName" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("PrincipalName") %>'></asp:Label>
                <asp:Label ID="LblPrincipalMobile" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("PrincipalMobile") %>'></asp:Label>
                <asp:Label ID="LblPrincipalDOB" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("PrincipalDOB") %>'></asp:Label>
                <asp:Label ID="LblKeyPersonName" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("KeyPersonName") %>'></asp:Label>
                <asp:Label ID="LblKeyPersonMobile" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("KeyPersonMobile") %>'></asp:Label>
                <asp:Label ID="LblKeyPersonDOB" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("KeyPersonDOB") %>'></asp:Label>
                <asp:Label ID="LblAdditinalDis" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("AdditinalDis") %>'></asp:Label>
                <asp:Label ID="Label17" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("KeyPersonMobile") %>'></asp:Label>
                <asp:Label ID="LblVIPRemark" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("VIPRemark") %>'></asp:Label>
                <asp:Label ID="LblMedium" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Medium") %>'></asp:Label>
                <asp:CheckBox ID="ChKBList" runat="server" CssClass="lbl-form" Style="display: none;"
                    Checked='<%#Eval("BlackList") %>' />
                <asp:Label ID="LblSuperZoneID" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("SuperZoneID") %>'></asp:Label>
                <asp:Label ID="LblZoneID" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("ZoneID") %>'></asp:Label>
                <asp:Label ID="LblAreaZoneID" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("AreaZoneID") %>'></asp:Label>
                <asp:Label ID="LblAreaID" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("AreaID") %>'></asp:Label>
                <asp:Label ID="LblCustDetailID" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CustDetailID") %>'></asp:Label>
                <asp:Label ID="lblstate1" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Dmid") %>'></asp:Label>
                <asp:Label ID="lblCity" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("city") %>'></asp:Label>
                <asp:Label ID="lblCMID" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CMID") %>'></asp:Label>
                <asp:Label ID="lblSchAdditionalDis" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("SchAdditionalDis") %>'></asp:Label>
                <asp:Label ID="lblTODValue1" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("TODValue1") %>'></asp:Label>
                <asp:Label ID="lblTODValue2" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("TODValue2") %>'></asp:Label>
                <asp:Label ID="lblTODValue3" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("TODValue3") %>'></asp:Label>
                <asp:Label ID="lblTODDisc1" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("TODDisc1") %>'></asp:Label>
                <asp:Label ID="lblTODDisc2" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("TODDisc2") %>'></asp:Label>
                <asp:Label ID="lblTODDisc3" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("TODDisc3") %>'></asp:Label>
                <asp:Label ID="lblCMIDSUB" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CMIDsub") %>'></asp:Label>
                <asp:Label ID="lblctype" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CUSTOMERTYPE") %>'></asp:Label>
                <asp:Label ID="lblcreditdays" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CreditDays") %>'></asp:Label>
                <asp:Label ID="lblboardid" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("BoardID") %>'></asp:Label>
                <asp:Label ID="lblcgp" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CGP") %>'></asp:Label>
                <asp:Label ID="lblbuisiness" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Business_Potential") %>'></asp:Label>
                <asp:Label ID="lblassociation" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Association") %>'></asp:Label>
                <asp:Label ID="lblpaymenttrack" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Payment_Track") %>'></asp:Label>
                <asp:Label ID="Label26" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Association") %>'></asp:Label>
                <asp:Label ID="Label27" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("Association") %>'></asp:Label>
                <asp:Label ID="Lblblkremark" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("BlackListRemark") %>'></asp:Label>
                <asp:Label ID="Lblblkdate" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("BlackListDate") %>'></asp:Label>
                <asp:Label ID="lblCUL" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CUL") %>'></asp:Label>
                <asp:Label ID="lblCLL" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CLL") %>'></asp:Label>
                <asp:Label ID="lblSUBCode" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("SBUCode") %>'></asp:Label>
                <asp:Label ID="lblPANNO" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("PAN") %>'></asp:Label>
                <asp:CheckBox ID="chk_isSplit" runat="server" CssClass="lbl-form" Style="display: none;"
                    Checked='<%#Eval("isSplit") %>' />
                <asp:Label ID="LblKeyPersonName1" runat="server" Style="display: none;" Text='<%#Eval("KeyPersonName") %>'> </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Customer Name">
            <ItemTemplate>
                <asp:Label ID="lblCustID" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CustID") %>'></asp:Label>
                <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Rating">
            <ItemTemplate>
                <asp:Label ID="lblrating" runat="server" CssClass="lbl-form" Text='<%#Eval("Rating") %>'></asp:Label>
                <asp:Label ID="lblcustrating" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("CustRating") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Key Mob.">
            <ItemTemplate>
                <asp:Label ID="LblKeyPersonMobile1" runat="server" Text='<%#Eval("KeyPersonMobile") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Area">
            <ItemTemplate>
                <asp:Label ID="lblareaName" runat="server" CssClass="lbl-form" Text='<%#Eval("AreaName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="IsActive" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:CheckBox ID="chkisActive" runat="server" Enabled="false" Checked='<%#Eval("IsActive") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:ImageButton ID="lblEdit" runat="server" ToolTip="Edit" CausesValidation="false"
                    CommandName="Edit" CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                <asp:ImageButton ID="LblDelete" runat="server" ToolTip="Delete" CausesValidation="false"
                    CommandName="Delete" CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif"
                    OnClientClick="return confirm('Are u sure u wat to Delete?')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<br />
<asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Width="600px" Style="float: left">
    <asp:Panel ID="Panel3" CssClass="pnldash" runat="server" GroupingText="Customer Details">
        <table width="100%" cellpadding="0" cellspacing="0" style="margin-bottom: 0px">
            <tr>
                <td width="100px">
                    <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Customer code"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td width="130px">
                    <asp:TextBox ID="TxtCustCode" CssClass="inp-form" TabIndex="1" runat="server" AutoPostBack="true"
                        OnTextChanged="TxtCustCode_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Customer code"
                        ControlToValidate="TxtCustCode" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                    <asp:Label ID="LblCustDetailID1" runat="server" Text="Label" Style="display: none"></asp:Label>
                </td>
                <td width="100px">
                    <asp:Label ID="LblCustId" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
                    <asp:Label ID="Label16" runat="server" CssClass="lbl-form" Text="Customer Name "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtCustName" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Short Form"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="TxtShortForm" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="FamilyCode"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtFamilyCode" CssClass="inp-form" TabIndex="4" runat="server" AutoComplete="off"></asp:TextBox>
                    <div id="Div1" class="divauto">
                    </div>
                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                        ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                        CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="TxtFamilyCode"
                        UseContextKey="true" ContextKey="Family" CompletionListElementID="Div1">
                    </ajaxCt:AutoCompleteExtender>
                </td>
            </tr>
            <tr id="tdold" runat="server" visible="false">
                <td width="100px">
                    <asp:Label ID="LblCustomerType" runat="server" CssClass="lbl-form" Text="Customer Type"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtCustomerType" CssClass="inp-form" TabIndex="5" AutoPostBack="true"
                                AutoComplete="off" runat="server" OnTextChanged="TxtCustomerType_TextChanged"></asp:TextBox>
                            <div id="dvCustType" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="TxtCustomerType"
                                UseContextKey="true" ContextKey="custType" CompletionListElementID="dvCustType">
                            </ajaxCt:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Label ID="LblMedium" runat="server" CssClass="lbl-form" Text="Medium"></asp:Label>
                </td>
                <td>
                    <div id="dvmedium" class="divauto">
                    </div>
                    <asp:TextBox ID="TxtMedium" runat="server" AutoComplete="off" CssClass="inp-form"
                        TabIndex="6"></asp:TextBox>
                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100"
                        CompletionListCssClass="AutoExtender" CompletionListElementID="dvmedium" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                        CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="medium"
                        DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                        ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="TxtMedium"
                        UseContextKey="true">
                    </ajaxCt:AutoCompleteExtender>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="Customer Type"></asp:Label>
                </td>
                <td width="130px">
                    <asp:DropDownList CssClass="ddl-form" TabIndex="5" ID="DDLCC" runat="server" Width="100px"
                        DataValueField="CMID" AutoPostBack="true" DataTextField="Name" OnSelectedIndexChanged="DDLCC_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td width="100px">
                    <asp:Label ID="Label25" runat="server" CssClass="lbl-form" Text="Medium"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" TabIndex="6" ID="DDLCSC" runat="server" Width="100px"
                                DataValueField="CMID" DataTextField="Name">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLCC" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label18" runat="server" CssClass="lbl-form" Text="Super Zone"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="DDLsuperzone" runat="server" TabIndex="8"
                        AutoPostBack="True" DataTextField="SuperZoneName" DataValueField="SuperZoneID"
                        OnSelectedIndexChanged="DDLsuperzone_SelectedIndexChanged" Width="100px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0"
                        ErrorMessage="select SuperZone" ControlToValidate="DDLsuperzone" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                    <asp:Label ID="LblSuperzone" runat="server" Text="Label" Style="display: none"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label19" runat="server" CssClass="lbl-form" Text="Zone"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLzone" runat="server" TabIndex="9" AutoPostBack="True"
                                DataTextField="ZoneName" DataValueField="ZoneID" OnSelectedIndexChanged="DDLzone_SelectedIndexChanged"
                                Width="100px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0"
                                ErrorMessage="select ZoneName" ControlToValidate="DDLzone" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLsuperzone" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:Label ID="Lblzone" runat="server" Text="Label" Style="display: none"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label20" runat="server" CssClass="lbl-form" Text="Area Zone"></asp:Label>
                    <font color="red">*</font>&nbsp;
                </td>
                <td>
                    <asp:UpdatePanel ID="upDDLarea" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLareazone" runat="server" TabIndex="10"
                                AutoPostBack="True" DataTextField="AreaZoneName" DataValueField="AreaZoneID"
                                OnSelectedIndexChanged="DDLareazone_SelectedIndexChanged" Width="100px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                ErrorMessage="select AreaZoneName" ControlToValidate="DDLareazone" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                            <asp:Label ID="LblAreazone" runat="server" Text="Label" Style="display: none"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLzone" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="DDLsuperzone" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="DDLzone" EventName="DataBinding" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Area"></asp:Label>
                    <span style="color: Red">*</span>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLarea" runat="server" TabIndex="11" DataTextField="AreaName"
                                DataValueField="AreaID" AutoPostBack="true" Width="100px" OnSelectedIndexChanged="DDLarea_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="0"
                                ErrorMessage="select AreaName" ControlToValidate="DDLarea" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLareazone" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="DDLzone" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="DDLsuperzone" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:Label ID="LblArea" runat="server" Text="Label" Style="display: none"></asp:Label>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label21" runat="server" CssClass="lbl-form" Text="Credit Limit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtCreditLimit" runat="server" CssClass="inp-form" TabIndex="12"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" CssClass="lbl-form" Text="Credit Days"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcreditdays" runat="server" CssClass="inp-form" TabIndex="13"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAdditinalDis" runat="server" CssClass="lbl-form" Text="Additional Discount"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtAdditinalDis" runat="server" CssClass="inp-form" TabIndex="14"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Label ID="lblSchAdditionalDis" CssClass="lbl-form" runat="server" Text="Disc."></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtSchAdditionalDis" CssClass="inp-form" TabIndex="15" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td width="100px">
                    <asp:Label ID="lblTODValue1" CssClass="lbl-form" runat="server" Text="Value"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODValue1" Visible="false" CssClass="inp-form" TabIndex="16"
                        runat="server"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Label ID="lblTODDisc1" Visible="false" CssClass="lbl-form" runat="server" Text="Disc"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODDisc1" Visible="false" CssClass="inp-form" TabIndex="17" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td width="100px">
                    <asp:Label ID="lblTODValue2" CssClass="lbl-form" runat="server" Text="Value"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODValue2" CssClass="inp-form" TabIndex="18" runat="server"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Label ID="lblTODDisc2" CssClass="lbl-form" runat="server" Text="Disc"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODDisc2" CssClass="inp-form" TabIndex="19" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td width="100px">
                    <asp:Label ID="lblTODValue3" CssClass="lbl-form" runat="server" Text="Value"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODValue3" CssClass="inp-form" TabIndex="20" runat="server"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Label ID="lblTODDisc3" CssClass="lbl-form" runat="server" Text="Disc"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODDisc3" CssClass="inp-form" TabIndex="21" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="CustRating" runat="server" CssClass="lbl-form" Text="CustomerRating"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="DdlCustRating" runat="server" TabIndex="22"
                        Width="100px" DataTextField="Value" DataValueField="AutoId">
                    </asp:DropDownList>
                    <asp:Label ID="lblrating" runat="server" Text="Label" Style="display: none"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblSection" runat="server" CssClass="lbl-form" Text="Section"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlSection" runat="server" CssClass="ddl-form" DataTextField="SectionName"
                        DataValueField="SectionID" TabIndex="23">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label37" runat="server" CssClass="lbl-form" Text="Split DC"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chk_splitdc" TabIndex="3" runat="server" Checked="true" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" CssClass="pnldash" runat="server" GroupingText="Customer Address Details">
        <table width="100%" cellpadding="0" cellspacing="0" style="margin-bottom: 0px">
            <tr>
                <td width="100px">
                    <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="Address"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TxtAddress" runat="server" Height="20px" CssClass="inp-form" TabIndex="24"
                        TextMode="MultiLine" Width="330px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" CssClass="lbl-form" Text="State"></asp:Label>
                </td>
                <td width="130px">
                    <asp:DropDownList CssClass="ddl-form" TabIndex="25" ID="ddLStates" runat="server"
                        Width="100px" DataValueField="DMID" AutoPostBack="true" DataTextField="Name"
                        OnSelectedIndexChanged="ddLStates_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td width="100px">
                    <asp:Label ID="Label14" runat="server" CssClass="lbl-form" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" TabIndex="26" ID="ddlCity" runat="server" Width="100px"
                                DataValueField="DMID" DataTextField="Name">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddLStates" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" CssClass="lbl-form" Text="Zip"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtZip" runat="server" CssClass="inp-form" TabIndex="27"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlCustDetails" GroupingText="Contact Details" CssClass="pnldash"
        runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Phone1 "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPhone1" runat="server" CssClass="inp-form" TabIndex="28" MaxLength="12"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" CssClass="lbl-form" Text="Phone2"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPhone2" runat="server" CssClass="inp-form" TabIndex="29" MaxLength="12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" CssClass="lbl-form" Text="EmailID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtEmailID" runat="server" CssClass="inp-form" TabIndex="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="LblPrincipalName" runat="server" CssClass="lbl-form" Text="Principal Name"></asp:Label>
                </td>
                <td width="130px">
                    <asp:TextBox ID="TxtPrincipalName" runat="server" CssClass="inp-form" TabIndex="31"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Label ID="LblPrincipalMobile" runat="server" CssClass="lbl-form" Text="Principal Mobile"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPrincipalMobile" runat="server" CssClass="inp-form" TabIndex="32"
                        MaxLength="12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPrincipalDOB" runat="server" CssClass="lbl-form" Text="Principal DOB"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPrincipalDOB" runat="server" CssClass="inp-form" TabIndex="33"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter PrincipalDOB"
                                ControlToValidate="TxtPrincipalDOB" ValidationGroup="ct">.</asp:RequiredFieldValidator>--%>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtPrincipalDOB"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="TxtPrincipalDOB"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblKeyPersonName" runat="server" CssClass="lbl-form" Text="Person Incharge"
                        Width="30px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtKeyPersonName" runat="server" CssClass="inp-form" TabIndex="34"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LblKeyPersonMobile" runat="server" CssClass="lbl-form" Text="P.I. Mobile"
                        Width="90px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtKeyPersonMobile" runat="server" CssClass="inp-form" TabIndex="35"
                        MaxLength="12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblKeyPersonDOB" runat="server" CssClass="lbl-form" Text="KeyPerson DOB"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtKeyPersonDOB" runat="server" CssClass="inp-form" TabIndex="36"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Select KeyPersonDOB"
                                ControlToValidate="TxtKeyPersonDOB" ValidationGroup="ct">.</asp:RequiredFieldValidator>--%>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TxtKeyPersonDOB"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TxtKeyPersonDOB"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="LblVIPRemark" runat="server" CssClass="lbl-form" Text="VIPRemark"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TxtVIPRemark" runat="server" CssClass="inp-form" Height="45px" Width="270px"
                        TextMode="MultiLine" TabIndex="37"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" CssClass="lbl-form" Text="Active"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ChkIsActive" runat="server" Checked="true" TabIndex="38" />
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" CssClass="lbl-form" Text="BlackList"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ChkBlacklist" runat="server" Checked="false" TabIndex="39" OnCheckedChanged="ChkBlacklist_CheckedChanged"
                        AutoPostBack="True" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblblkremark" runat="server" Text="BlackListRemark"></asp:Label>
                    <font color="red"></font>
                </td>
                <td>
                    <asp:TextBox ID="TxtblkRemark" runat="server" CssClass="inp-form" Height="37px" Width="270px"
                        TextMode="MultiLine" TabIndex="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblblkDate" runat="server" Text="BlackListDate"></asp:Label>
                    <font color="red"></font>
                </td>
                <td>
                    <asp:TextBox ID="TxtblkDate" runat="server" CssClass="inp-form" TabIndex="36"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TxtblkDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="TxtblkDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" CssClass="pnldash" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label23" runat="server" CssClass="lbl-form" Text="CGP"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcgp" runat="server" CssClass="inp-form" TabIndex="40" MaxLength="10"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtcgp"
                        FilterType="Custom, Numbers" ValidChars="." />
                </td>
                <td>
                    <asp:Label ID="Label22" runat="server" CssClass="lbl-form" Text="Buisiness Potential"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbuisiness" runat="server" CssClass="inp-form" TabIndex="41" MaxLength="10"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="extender" runat="server" TargetControlID="txtbuisiness"
                        FilterType="Custom, Numbers" ValidChars="." />
                </td>
            </tr>
            <%--<tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="Board "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="ddl-form" ID="DDLBoard" Width="200px" DataTextField="value"
                                        DataValueField="AutoID" TabIndex="3" runat="server">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblboardid" runat="server" Text="Label" Style="display: none"></asp:Label>
                                </td>
                            </tr>--%>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label24" runat="server" CssClass="lbl-form" Text="Association With CBD"></asp:Label>
                </td>
                <td width="130px">
                    <asp:TextBox ID="txtassociation" runat="server" CssClass="inp-form" TabIndex="42"
                        MaxLength="3"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtassociation"
                        FilterType="Custom, Numbers" />
                </td>
                <td width="100px"></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label28" runat="server" Text="Upper Limit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUpperlimit" runat="server" CssClass="inp-form" TabIndex="43"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtUpperlimit"
                        FilterType="Custom, Numbers" ValidChars="." />
                </td>
                <td>
                    <asp:Label ID="Label26" runat="server" Text="Lower Limit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLowerlimit" runat="server" CssClass="inp-form" TabIndex="44"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtLowerlimit"
                        FilterType="Custom, Numbers" ValidChars="." />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label27" runat="server" Text="SBU Code"></asp:Label>
                </td>
                <td>
                    <%--<asp:TextBox ID="txtSbuCode" runat="server" CssClass="inp-form" TabIndex="45"></asp:TextBox>--%>
                    <asp:Label ID="lblSBUCodeNone" runat="server" Text="Label" Style="display: none"></asp:Label>
                    <asp:DropDownList ID="ddlSbucode" TabIndex="45" CssClass="ddl-form" DataValueField="AutoId"
                        DataTextField="Value" Width="100px" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label36" runat="server" Text="PAN No"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPAN" runat="server" Text="Label" Style="display: none"></asp:Label>
                    <asp:TextBox ID="txtPAN" runat="server" TabIndex="46" CssClass="inp-form"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                        ErrorMessage="Please enter PAN no" ControlToValidate="txtPAN" ValidationGroup="ct">.</asp:RequiredFieldValidator>--%>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="MainPanelId" runat="server" Style="display: none; text-align: left; height: 140px;">
        <div class="facebox">
            <asp:Label ID="Label29" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
                ForeColor="White"></asp:Label>
            <a id="A1" class="close" style="right: 0;" runat="server" href="javascript:void(0);"
                onclick="closeEditPopup();">
                <img src="Images/button-cross.png" /></a>
            <br />
        </div>
    </asp:Panel>
</asp:Panel>
<asp:Panel ID="NewPanel" Visible="false" CssClass="panelDetails" Style="float: left"
    runat="server" Width="312px">
    <asp:UpdatePanel ID="UpdateTOD" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel4" CssClass="pnldash" Height="330px" runat="server" DefaultButton="btnAddTOD">
                <fieldset>
                    <legend>Tod Details </legend>
                </fieldset>
                <table width="100%" cellpadding="2" cellspacing="0" style="margin-bottom: 8px">
                    <tr>
                        <td>
                            <asp:Label ID="lblAutoId" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="lblTest" runat="server">Tod Amount</asp:Label>
                            <asp:TextBox ID="txtTODAmount" runat="server" TabIndex="47" CssClass="inp-form" onkeypress="return CheckNumericWithDot(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="TodGroup"
                                ControlToValidate="txtTODAmount">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label33" runat="server">Tod Dis.%</asp:Label>
                            <asp:TextBox ID="txtTodDis" runat="server" TabIndex="48" CssClass="inp-form" onkeypress="return CheckNumericWithDot(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="TodGroup"
                                ControlToValidate="txtTodDis">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label30" runat="server">Active</asp:Label>
                            <asp:CheckBox ID="checkAction" TabIndex="49" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID="btnAddTOD" TabIndex="50" runat="server" Text="Add" ValidationGroup="TodGroup"
                                OnClick="btnAddTOD_Click" CssClass="submitbtn" />
                        </td>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary10" runat="server" ShowMessageBox="false"
                                ShowSummary="false" ValidationGroup="TodGroup" />
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="panel5" runat="server" ScrollBars="Vertical" Height="259px" Width="310px">
                    <asp:Panel ID="panelTod" runat="server">
                        <asp:GridView ID="TODGridview" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alt"
                            CellPadding="4" CssClass="product-table" Visible="true" OnRowDeleting="TODGridview_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Tod Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAutoId" runat="server" Style="display: none" Text='<%#Eval("AutoId")%>'></asp:Label>
                                        <asp:TextBox ID="lblTodAmount" runat="server" CssClass="inp-form" Text='<%#Eval("TodAmount")%>'
                                            onkeypress="return CheckNumericWithDot(event)" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dis. %">
                                    <ItemTemplate>
                                        <asp:TextBox ID="lblTodPercentage" runat="server" CssClass="inp-form" Text='<%#Eval("TodPercentage")%>'
                                            onkeypress="return CheckNumericWithDot(event)" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="lblAction" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsAction"))%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%--<asp:ImageButton ID="btnEdit" ImageUrl="~/Images/icon/edit_icon.png" CommandName="edit"
                                        runat="server" OnClick="btnEdit_click" />--%>
                                        <asp:ImageButton ID="btnDelete" ImageUrl="~/Images/icon/DeleteIcon.gif" CommandName="Delete"
                                            OnClick="btn_Delete_Click" OnClientClick="return confirm('Do you want to permanent delete this record');"
                                            runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<asp:Panel ID="AssortedPanel" Visible="false" CssClass="panelDetails" Style="float: left"
    runat="server" Width="365px">
    <asp:UpdatePanel ID="UpdatePanel8" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel6" CssClass="pnldash" Height="322px" runat="server" DefaultButton="btnAddAccess">
                <table width="100%" cellpadding="2" cellspacing="0" style="margin-bottom: 8px">
                    <caption>
                        <fieldset style="float: left">
                            <legend>Assorted Discount</legend>
                        </fieldset>
                        <tr>
                            <td>
                                <asp:Label ID="lblautoIdAssorteddiscount" runat="server" Style="display: none"></asp:Label>
                                <asp:Label ID="Label31" runat="server">Book Type</asp:Label>
                                <%-- <asp:TextBox ID="txtBookType" runat="server" TabIndex="50" CssClass="inp-form"></asp:TextBox>--%>
                                <asp:TextBox ID="txtBookType" runat="server" autocomplete="off" AutoPostBack="true"
                                    CssClass="inp-form" onblur="setfocus('');" onfocus="setfocus('book');" OnTextChanged="txtBookType_TextChange"
                                    TabIndex="50" Width="138px"></asp:TextBox>
                                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarktxtbook" runat="server" TargetControlID="txtBookType"
                                    WatermarkText="Enter BookCode to add  ">
                                </ajaxCt:TextBoxWatermarkExtender>
                                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="bktype"
                                    DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                                    ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtBookType"
                                    UseContextKey="true">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBookType"
                                    ValidationGroup="AssessDis">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 20px">
                                <asp:Label ID="Label32" runat="server">Fr. Qty</asp:Label>
                                <asp:TextBox ID="txtFromQty" runat="server" CssClass="inp-form inp-formNew" onkeypress="return CheckNumeric(event)"
                                    TabIndex="51"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFromQty"
                                    ValidationGroup="AssessDis">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="Label34" runat="server">To Qty</asp:Label>
                                <asp:TextBox ID="txtToQty" runat="server" CssClass="inp-form inp-formNew" onkeypress="return CheckNumeric(event)"
                                    TabIndex="52"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtToQty"
                                    ValidationGroup="AssessDis">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="Label35" runat="server">Dis.</asp:Label>
                                <asp:TextBox ID="txtDiscount" runat="server" CssClass="inp-form inp-formNew" onkeypress="return CheckNumeric(event)"
                                    TabIndex="53"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtDiscount"
                                    ValidationGroup="AssessDis">*</asp:RequiredFieldValidator>
                            </td>
                            <%--<td>
                            <asp:Label ID="Label31" runat="server">Active</asp:Label>
                            <asp:CheckBox ID="CheckBox1" TabIndex="48" runat="server" />
                        </td>--%>
                            <td>
                                <asp:Button ID="btnAddAccess" runat="server" CssClass="submitbtn" OnClick="btnAddAccess_Click"
                                    Style="padding-top: 4%" TabIndex="54" Text="Add" ValidationGroup="AssessDis" />
                            </td>
                            <td>
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="false"
                                    ShowSummary="false" ValidationGroup="AssessDis" />
                            </td>
                        </tr>
                    </caption>
                </table>
                <asp:Panel ID="panel7" runat="server" ScrollBars="Vertical" Height="239px">
                    <asp:GridView ID="GridAssorted" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alt"
                        CellPadding="4" CssClass="product-table" Visible="true" OnRowDeleting="GridAssorted_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="BookType" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblBookType" runat="server" CssClass="inp-form inp-formNewBook"
                                        OnTextChanged="lblBookType_TextChanged" AutoPostBack="true" Text='<%#Eval("BookType")%>' />
                                    <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarktxtbook" runat="server" TargetControlID="lblBookType"
                                        WatermarkText="Enter BookCode to add  ">
                                    </ajaxCt:TextBoxWatermarkExtender>
                                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                                        CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="bktype"
                                        DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                                        ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="lblBookType"
                                        UseContextKey="true">
                                    </ajaxCt:AutoCompleteExtender>
                                    <asp:Label ID="lblAutoIdAssored" runat="server" Style="display: none" Text='<%#Eval("AutoId")%>'></asp:Label>
                                    <asp:Label ID="bookId" runat="server" Style="display: none" Text='<%#Eval("Bookid") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FromQty.">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblFromQty" runat="server" CssClass="inp-form inp-formNew" Text='<%#Eval("FromQty")%>'
                                        onkeypress="return CheckNumeric(event)" OnTextChanged="txtFromQty_TextChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ToQty.">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblToQty" runat="server" CssClass="inp-form inp-formNew" Text='<%#Eval("ToQty")%>'
                                        onkeypress="return CheckNumeric(event)" OnTextChanged="txtToQty_TextChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dis.%">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblDiscount" runat="server" CssClass="inp-form inp-formNew" Text='<%#Eval("Discount")%>'
                                        onkeypress="return CheckNumeric(event)" OnTextChanged="txtDiscount_TextChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%-- <asp:ImageButton ID="btnEdit" ImageUrl="~/Images/icon/edit_icon.png" CommandName="edit"
                                        runat="server" />--%>
                                    <asp:ImageButton ID="btnDelete" ImageUrl="~/Images/icon/DeleteIcon.gif" CommandName="Delete"
                                        OnClick="btn_DeleteAssorted_Click" OnClientClick="return confirm('Do you want to permanent delete this record');"
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DDLCC" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>
