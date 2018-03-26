<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CustomerMaster_View.ascx.cs"
    Inherits="UserControls_uc_CustomerMaster_View" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%--<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>--%>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details"> Customer 
        View</div>
    <asp:Panel ID="pnlra" runat="server">
        <div style="float: right; width: 58%">
            <div id="filter" runat="server">
                <span>Filter Data:</span>
                <input name="filt" onkeyup="filter(this, 'sf', '<%=grdCustDetails.ClientID%>')" type="text">
            </div>
        </div>
    </asp:Panel>
    <div class="options">
    </div>
</div>
<asp:Repeater ID="repAlfabets" runat="server">
    <ItemTemplate>
        <asp:LinkButton ID="lnkalfabet" CssClass="nav_bar_link" runat="server" Text='<%#Eval("chr") %>'
            OnClick="lnkalfabet_click"></asp:LinkButton>
    </ItemTemplate>
</asp:Repeater>
<asp:Panel ID="PnlDetails" runat="server">
    <br />
    <br />
    <asp:GridView ID="grdCustDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" OnPageIndexChanging="grdCustDetails_PageIndexChanging"
        PageSize="3000" Width="985px" OnSelectedIndexChanging="grdCustDetails_SelectedIndexChanging"
         >
        <Columns>
            <asp:TemplateField HeaderText="Customer Name">
                <ItemTemplate>
                    <asp:Label ID="lblCustID" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("CustID") %>'></asp:Label>
                    <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
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
                   
                    <asp:Label ID="Label17" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("KeyPersonMobile") %>'></asp:Label>
                    <asp:Label ID="LblVIPRemark" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("VIPRemark") %>'></asp:Label>
                    <asp:Label ID="LblMedium" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("Medium") %>'></asp:Label>
                    <asp:CheckBox ID="ChKBList" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("BlackList") %>' />
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
                    <asp:Label ID="lblctype" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("CUSTOMERTYPE") %>'></asp:Label>
                    <asp:Label ID="lblcreditdays" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("CreditDays") %>'></asp:Label>
                    <asp:Label ID="LblKeyPersonName1" runat="server" Style="display: none;"
                     Text='<%#Eval("KeyPersonName") %>'> </asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Rating">
                <ItemTemplate>
                    <asp:Label ID="lblrating" runat="server" CssClass="lbl-form" 
                        Text='<%#Eval("Rating") %>'></asp:Label>
                        <asp:Label ID="lblcustrating" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("CustRating") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Key Mob.">
                <ItemTemplate>
                    <asp:Label ID="LblKeyPersonMobile1" runat="server" Text='<%#Eval("KeyPersonMobile") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Area">
                <ItemTemplate>
                    <asp:Label ID="lblareaName" runat="server" CssClass="lbl-form" Text='<%#Eval("AreaName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Disc%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                 <asp:Label ID="LblAdditinalDis" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("AdditinalDis") %>'></asp:Label>
                    <asp:CheckBox ID="chkisActive" runat="server" Enabled="false" Checked='<%#Eval("IsActive") %>' Style="display: none;" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <script type="text/javascript">
    	                function filter (phrase, _id){
		                var words = phrase.value.toLowerCase().split(" ");
		                var table = document.getElementById('<%=grdCustDetails.ClientID%>');
		                //document.getElementById(_id);
		                var ele;
		                for (var r = 1; r < table.rows.length; r++){
			                ele = table.rows[r].innerHTML.replace(/<[^>]+>/g,"");
		                        var displayStyle = 'none';
		                        for (var i = 0; i < words.length; i++) {
			                    if (ele.toLowerCase().indexOf(words[i])>=0)
				                displayStyle = '';
			                    else {
				                displayStyle = 'none';
				                break;
			                    }
		                        }
			                table.rows[r].style.display = displayStyle;
		                }
		                  if(words != "")
		{
		sloder('search for : '+ words);
		}
		else
		{
		cloder();
		}
	                }
    </script>

</asp:Panel>
<div style="float: right;display:none; width: 45%;">
    <asp:Button ID="BtnAdd" CssClass="submitbtn" runat="server" Style="display: none;"
        Text="Add New" OnClick="BtnAdd_Click" />
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="33" runat="server" Text="Save"
        Width="70px" OnClick="btnSave_Click" ValidationGroup="ct"  />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ct"
        ShowMessageBox="true" ShowSummary="false" />
    <asp:Button ID="btncancel" Style="display: none;" CssClass="submitbtn" TabIndex="4"
        runat="server" Text="Cancel" Width="80px" OnClick="btncancel_Click" />
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
</div>
<br />
<br />
<asp:Panel ID="PnlAdd" CssClass="panelDetails" Visible="false" runat="server" Width="642px">
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
            <tr>
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
                <td>
                </td>
                <td>
                </td>
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
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAdditinalDis" runat="server" CssClass="lbl-form" Text="Additional Discount"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtAdditinalDis" runat="server" CssClass="inp-form" TabIndex="14"></asp:TextBox>
                </td>
                <tr>
                    <td>
                        <asp:Label ID="CustRating" runat="server" CssClass="lbl-form" Text="CustomerRating"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DdlCustRating" runat="server" TabIndex="15"
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
                            DataValueField="SectionID" TabIndex="16">
                        </asp:DropDownList>
                    </td>
                </tr>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel1" CssClass="pnldash" runat="server" GroupingText="Customer Address Details">
        <table width="100%" cellpadding="0" cellspacing="0" style="margin-bottom: 0px">
            <tr>
                <td width="100px">
                    <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="Address"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TxtAddress" runat="server" Height="20px" CssClass="inp-form" TabIndex="17"
                        TextMode="MultiLine" Width="330px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" CssClass="lbl-form" Text="State"></asp:Label>
                </td>
                <td width="130px">
                    <asp:DropDownList CssClass="ddl-form" TabIndex="18" ID="ddLStates" runat="server"
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
                            <asp:DropDownList CssClass="ddl-form" TabIndex="19" ID="ddlCity" runat="server" Width="100px"
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
                    <asp:TextBox ID="TxtZip" runat="server" CssClass="inp-form" TabIndex="20"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
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
                        TextMode="MultiLine" TabIndex="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" CssClass="lbl-form" Text="Active"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ChkIsActive" runat="server" Checked="true" TabIndex="31" />
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" CssClass="lbl-form" Text="BlackList"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ChkBlacklist" runat="server" Checked="false" TabIndex="32" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Panel>
