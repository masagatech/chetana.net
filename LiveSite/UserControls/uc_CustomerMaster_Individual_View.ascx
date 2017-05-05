<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CustomerMaster_Individual_View.ascx.cs"
    Inherits="UserControls_uc_CustomerMaster_Individual_View" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%--<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>--%>
</asp:Panel>

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
        View Customer<a href="Campaigns.aspx" title="back to campaign list"></a>
        <asp:GridView ID="grdCustDetails" runat="server" AutoGenerateColumns="False" Style="display: none;"
            CellPadding="4" CssClass="product-table" ForeColor="#333333" Width="985px">
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
                        <%-- <asp:Label ID="lblboardid" runat="server" CssClass="lbl-form" Style="display: none;"
                            Text='<%#Eval("BoardID") %>'></asp:Label>--%>
                        <asp:Label ID="lblcgp" runat="server" CssClass="lbl-form" Style="display: none;"
                            Text='<%#Eval("CGP") %>'></asp:Label>
                        <asp:Label ID="lblbuisiness" runat="server" CssClass="lbl-form" Style="display: none;"
                            Text='<%#Eval("Business_Potential") %>'></asp:Label>
                        <asp:Label ID="lblassociation" runat="server" CssClass="lbl-form" Style="display: none;"
                            Text='<%#Eval("Association") %>'></asp:Label>
                        <asp:Label ID="Lblblkremark" runat="server" CssClass="lbl-form" Style="display: none;"
                            Text='<%#Eval("BlackListRemark") %>'></asp:Label>
                        <asp:Label ID="Lblblkdate" runat="server" CssClass="lbl-form" Style="display: none;"
                            Text='<%#Eval("BlackListDate") %>'></asp:Label>
                        <asp:Label ID="lblpaymenttrack" runat="server" CssClass="lbl-form" Style="display: none;"
                            Text='<%#Eval("Payment_Track") %>'></asp:Label>
                        <asp:Label ID="lblCUL" runat="server" CssClass="lbl-form" Style="display: none;"
                            Text='<%#Eval("CUL") %>'></asp:Label>
                        <asp:Label ID="lblCLL" runat="server" CssClass="lbl-form" Style="display: none;"
                            Text='<%#Eval("CLL") %>'></asp:Label>
                        <asp:Label ID="lblSUBCode" runat="server" CssClass="lbl-form" Style="display: none;"
                            Text='<%#Eval("SBUCode") %>'></asp:Label>
                        <asp:Label ID="lblPan" runat="server" CssClass="lbl-form" Style="display: none;"
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
<asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Width="650px" Visible="False"
    Style="float: left">
    <asp:Panel ID="Panel3" CssClass="pnldash" runat="server" GroupingText="Customer Details">
        <table width="100%" cellpadding="0" cellspacing="0" style="margin-bottom: 0px">
            <tr>
                <td width="100px">
                    <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Customer code"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td width="130px">
                    <asp:TextBox ID="TxtCustCode" CssClass="inp-form" TabIndex="1" runat="server" AutoPostBack="true"></asp:TextBox>
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
                                AutoComplete="off" runat="server"></asp:TextBox>
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
                    <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="Customer Category"></asp:Label>
                </td>
                <td width="130px">
                    <asp:DropDownList CssClass="ddl-form" TabIndex="18" ID="DDLCC" runat="server" Width="100px"
                        DataValueField="CMID" AutoPostBack="true" DataTextField="Name" OnSelectedIndexChanged="DDLCC_SelectedIndexChanged"
                        Enabled="false">
                    </asp:DropDownList>
                </td>
                <td width="100px">
                    <asp:Label ID="Label25" runat="server" CssClass="lbl-form" Text="Customer Sub Category"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" TabIndex="19" ID="DDLCSC" runat="server" Width="100px"
                                DataValueField="CMID" DataTextField="Name" Enabled="false">
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
                        DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" Enabled="False">
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
                            <asp:DropDownList CssClass="ddl-form" ID="DDLzone" runat="server" TabIndex="9" DataTextField="ZoneName"
                                DataValueField="ZoneID" Width="200px" Enabled="False">
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
                                DataTextField="AreaZoneName" DataValueField="AreaZoneID" Width="200px" Enabled="False">
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
                                DataValueField="AreaID" Width="200px" Enabled="False">
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
            <tr runat="server" id="RowadditionalDisc" visible="false">
                <td>
                    <asp:Label ID="LblAdditinalDis" runat="server" CssClass="lbl-form" Text="Additional Discount"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtAdditinalDis" runat="server" CssClass="inp-form" TabIndex="14"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="lblSchAdditionalDis" CssClass="lbl-form" runat="server" Text="Disc."></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtSchAdditionalDis" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td width="100px">
                    <asp:Label ID="lblTODValue1" CssClass="lbl-form" runat="server" Text="TOD Value"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODValue1" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Label ID="lblTODDisc1" CssClass="lbl-form" runat="server" Text="Disc"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODDisc1" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td width="100px">
                    <asp:Label ID="lblTODValue2" CssClass="lbl-form" runat="server" Text="Value"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODValue2" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Label ID="lblTODDisc2" CssClass="lbl-form" runat="server" Text="Disc"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODDisc2" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td width="100px">
                    <asp:Label ID="lblTODValue3" CssClass="lbl-form" runat="server" Text="Value"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODValue3" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Label ID="lblTODDisc3" CssClass="lbl-form" runat="server" Text="Disc"></asp:Label>
                </td>
                <td width="100px">
                    <asp:TextBox ID="txtTODDisc3" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="CustRating" runat="server" CssClass="lbl-form" Text="CustomerRating"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="DdlCustRating" runat="server" TabIndex="15"
                        Width="100px" DataTextField="Value" DataValueField="AutoId" Enabled="False">
                    </asp:DropDownList>
                    <asp:Label ID="lblrating" runat="server" Text="Label" Style="display: none"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblSection" runat="server" CssClass="lbl-form" Text="Section"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlSection" runat="server" CssClass="ddl-form" DataTextField="SectionName"
                        DataValueField="SectionID" TabIndex="16" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
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
                    <asp:TextBox ID="TxtAddress" runat="server" CssClass="inp-form" TabIndex="17" TextMode="MultiLine"
                        Width="330px" Rows="3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" CssClass="lbl-form" Text="State"></asp:Label>
                </td>
                <td width="130px">
                    <asp:DropDownList CssClass="ddl-form" TabIndex="18" ID="ddLStates" runat="server"
                        Width="200px" DataValueField="DMID" AutoPostBack="true" DataTextField="Name"
                        Enabled="False">
                    </asp:DropDownList>
                </td>
                <td width="100px">
                    <asp:Label ID="Label14" runat="server" CssClass="lbl-form" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" TabIndex="19" ID="ddlCity" runat="server" Width="200px"
                                DataValueField="DMID" DataTextField="Name" Enabled="False">
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
                    <asp:TextBox ID="TxtZip" runat="server" CssClass="inp-form" TabIndex="20"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlCustDetails" GroupingText="Contact Details" CssClass="pnldash"
        runat="server" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Phone1 "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPhone1" runat="server" CssClass="inp-form" TabIndex="21" MaxLength="12"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" CssClass="lbl-form" Text="Phone2"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPhone2" runat="server" CssClass="inp-form" TabIndex="22" MaxLength="12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" CssClass="lbl-form" Text="EmailID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtEmailID" runat="server" CssClass="inp-form" TabIndex="23"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="LblPrincipalName" runat="server" CssClass="lbl-form" Text="Principal Name"></asp:Label>
                </td>
                <td width="130px">
                    <asp:TextBox ID="TxtPrincipalName" runat="server" CssClass="inp-form" TabIndex="24"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Label ID="LblPrincipalMobile" runat="server" CssClass="lbl-form" Text="Principal Mobile"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPrincipalMobile" runat="server" CssClass="inp-form" TabIndex="25"
                        MaxLength="12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPrincipalDOB" runat="server" CssClass="lbl-form" Text="Principal DOB"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPrincipalDOB" runat="server" CssClass="inp-form" TabIndex="26"></asp:TextBox>
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
                    <asp:TextBox ID="TxtKeyPersonName" runat="server" CssClass="inp-form" TabIndex="27"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LblKeyPersonMobile" runat="server" CssClass="lbl-form" Text="P.I. Mobile"
                        Width="90px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtKeyPersonMobile" runat="server" CssClass="inp-form" TabIndex="28"
                        MaxLength="12"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblKeyPersonDOB" runat="server" CssClass="lbl-form" Text="KeyPerson DOB"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtKeyPersonDOB" runat="server" CssClass="inp-form" TabIndex="29"></asp:TextBox>
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
                    <asp:TextBox ID="TxtVIPRemark" runat="server" CssClass="inp-form" Height="45px" Width="330px"
                        TextMode="MultiLine" TabIndex="30" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" CssClass="lbl-form" Text="Active"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ChkIsActive" runat="server" Checked="true" TabIndex="31" Enabled="False" />
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" CssClass="lbl-form" Text="BlackList"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ChkBlacklist" runat="server" Checked="false" TabIndex="32" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblblkremark" runat="server" Text="BlackListRemark"></asp:Label>
                    <font color="red"></font>
                </td>
                <td>
                    <asp:TextBox ID="TxtblkRemark" runat="server" CssClass="inp-form" Height="37px" Width="330px"
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
                    <asp:TextBox ID="txtcgp" runat="server" CssClass="inp-form" TabIndex="22" MaxLength="10"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtcgp"
                        FilterType="Custom, Numbers" ValidChars="." />
                </td>
                <td>
                    <asp:Label ID="Label22" runat="server" CssClass="lbl-form" Text="Buisiness Potential"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbuisiness" runat="server" CssClass="inp-form" TabIndex="22" MaxLength="10"></asp:TextBox>
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
                    <asp:TextBox ID="txtassociation" runat="server" CssClass="inp-form" TabIndex="22"
                        MaxLength="3"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtassociation"
                        FilterType="Custom, Numbers" />
                </td>
                <td width="100px"></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lable" runat="server" Text="Upper Limit"></asp:Label>
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
                    <asp:DropDownList ID="ddlSbucode" CssClass="ddl-form" DataValueField="AutoId" DataTextField="Value"
                        Width="100px" runat="server" Enabled="False">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label28" runat="server" Text="PAN No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPANNo" runat="server" CssClass="inp-form"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Panel>
<asp:Panel ID="PanelTod" Visible="false" CssClass="panelDetails" Style="float: left"
    runat="server" Width="300px">
    <asp:Panel ID="PanelTodNew" CssClass="pnldash" runat="server" ScrollBars="Vertical"
        Height="220px">
        <fieldset>
            <legend>Tod Details </legend>
        </fieldset>
        <asp:Panel ID="PanelTodNew1" runat="server">
            <asp:UpdatePanel ID="UpdateTOD" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="TODGridview" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alt"
                        CellPadding="4" CssClass="product-table" Visible="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Tod Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblTodAmount" runat="server" CssClass="lbl-form" Text='<%#Eval("TodAmount")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dis. %">
                                <ItemTemplate>
                                    <asp:Label ID="lblTodPercentage" runat="server" CssClass="lbl-form" Text='<%#Eval("TodPercentage")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:CheckBox ID="lblAction" runat="server" Enabled="false" Checked='<%#Convert.ToBoolean(Eval("IsAction"))%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </asp:Panel>
</asp:Panel>

<asp:Panel ID="AssortedPanel" Visible="false" CssClass="panelDetails" Style="float: left" runat="server"
    Width="364px">
    <contenttemplate>
            <asp:Panel ID="Panel6" CssClass="pnldash" Height="274px" runat="server">
                    <fieldset>
                        <legend>Assorted Discount</legend>
                    </fieldset>
               <asp:Panel ID="panel7" runat="server" ScrollBars="Vertical" Height="248px">
                    <asp:UpdatePanel ID="AssortedUpdatePane" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridAssorted" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alt"
                                CellPadding="4" CssClass="product-table" Visible="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="BookType" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookType" runat="server" CssClass="lbl-form" Text='<%#Eval("BookType")%>'></asp:Label>
                                            <asp:Label ID="lblAutoIdAssored" runat="server" Style="display: none" Text='<%#Eval("AutoId")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FromQty.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromQty" runat="server" CssClass="lbl-form" Text='<%#Eval("FromQty")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="ToQty.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToQty" runat="server" CssClass="lbl-form" Text='<%#Eval("ToQty")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Dis.%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDiscount" runat="server" CssClass="lbl-form" Text='<%#Eval("Discount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                      <%-- <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAddTOD" EventName="Click" />
                        </Triggers>--%>
                    </asp:UpdatePanel>
                </asp:Panel>
            </asp:Panel>
        </contenttemplate>
</asp:Panel>
<br />
<br />
