<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_View_EmployeeMaster.ascx.cs"
    Inherits="UserControls_uc_View_EmployeeMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<script type="text/javascript">
       function ReplaceDefaultImg(source)
       {
        source.src="../images/defavtar.gif";
        source.onerror="";
        return true;
       }
</script>

<div class="section-header">
    <td>
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
            </a>
        </div>
        <div class="options">
        </div>
    </td>
    <td>
        <div id="filter" runat="server" style="float: right; width: 50%">
            <span>Filter Data:</span>
            <input name="filt" id="search" onkeyup="filter(this, 'sf', '<%=grdEmpDetails.ClientID%>')"
                type="text"></div>
    </td>
</div>
<div style="float: right; width: 44%">
    <asp:Button ID="btnSavE" CssClass="submitbtn" TabIndex="28" runat="server" ValidationGroup="Employee"
        Text="Save" Width="80px" OnClick="btnSavE_Click" />
</div>
<asp:Button ID="BtnAdd" CssClass="form-submit" TabIndex="27" runat="server" Text="Add"
    Width="80px" OnClick="BtnAdd_Click" />
<asp:Button ID="btncancel" CssClass="form-submit" TabIndex="29" runat="server" Text="Back"
    Width="80px" OnClick="btncancel_Click" Style="display: none;" />
<br />
<br />
<asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Width="660px">
    <asp:Panel ID="Panel3" CssClass="pnldash" Style="border: 1px solid #ccc;" runat="server"
        BorderWidth="1px" GroupingText="Personal Details">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td width="100px">
                    <asp:Label ID="lblform" CssClass="lbl-form" runat="server" Text="Emp Code"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td width="120px">
                    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtempCode" CssClass="inp-form" AutoPostBack="true" TabIndex="1"
                                Text="EMP:" Enabled="false" runat="server" OnTextChanged="txtempCode_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqemp" runat="server" ErrorMessage="Require Emp Code"
                                ValidationGroup="Employee" ControlToValidate="txtempCode">.</asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Profile Pic"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload Width="90px" runat="server" ID="FileUpload1" TabIndex="2" />
                </td>
                <td rowspan="4" valign="top" align="right">
                    <asp:Image ID="imgprof" runat="server" Height="100px" Width="90px" Visible="true" />
                    <br />
                    <asp:Label ID="lblImage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="80px">
                    <asp:Label ID="LblEmpID" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
                    <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="First Name"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:TextBox ID="txtFname" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFnam" runat="server" ErrorMessage="Require First Name"
                        ValidationGroup="Employee" ControlToValidate="txtFname">.</asp:RequiredFieldValidator>
                </td>
                <td width="70px">
                    <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Middle Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMname" CssClass="inp-form" TabIndex="4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="80px">
                    <asp:Label ID="Label7" CssClass="lbl-form" runat="server" Text="Last Name"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:TextBox ID="txtLname" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Reqlnam" runat="server" ErrorMessage="Require Last Name"
                        ValidationGroup="Employee" ControlToValidate="txtLname">.</asp:RequiredFieldValidator>
                </td>
                <td width="80px">
                    <asp:Label ID="Label11" CssClass="lbl-form" runat="server" Text="DOB"></asp:Label>
                    <%--<font color="red">*</font>--%>
                </td>
                <td>
                    <asp:TextBox ID="txtDob" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDob"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtDob"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="Reqdob1" runat="server" ErrorMessage="Require DOB"
                        ValidationGroup="Employee1" ControlToValidate="txtDob">.</asp:RequiredFieldValidator>
                    <asp:Label ID="LblEId" CssClass="lbl-form" runat="server" Style="display: none;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" CssClass="lbl-form" runat="server" Text="Gender"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td width="100px">
                    <asp:RadioButtonList ID="Rdogender" CellPadding="2" RepeatDirection="Horizontal"
                        TabIndex="7" runat="server">
                        <asp:ListItem Text="Male"></asp:ListItem>
                        <asp:ListItem Text="Female"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="Reqgen1" runat="server" ErrorMessage="Require Gender"
                        ValidationGroup="Employee" ControlToValidate="Rdogender">.</asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel2" runat="server" Style="border: 1px solid #ccc;" EnableTheming="True"
        GroupingText="Work Details" CssClass="pnldash">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td width="100px">
                    <asp:Label ID="Label9" CssClass="lbl-form" runat="server" Text="Designation"></asp:Label>
                    <%--<font color="red">*</font>--%>
                </td>
                <td width="80px">
                    <asp:DropDownList CssClass="ddl-form" ID="DDlDesignation" TabIndex="9" runat="server"
                        Width="100px" DataValueField="autoid" DataTextField="value">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="Reqdesig1" runat="server" ErrorMessage="Require Designation"
                        InitialValue="0" ValidationGroup="Employee1" ControlToValidate="DDlDesignation">.</asp:RequiredFieldValidator>
                </td>
                 <td width="80px">
                    <asp:Label ID="Label13" CssClass="lbl-form" runat="server" Text="SuperDuper Zone"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="DDLSDZone" TabIndex="14" runat="server"
                        Width="100px" DataValueField="SDZoneID" DataTextField="SDZoneName" OnSelectedIndexChanged="DDLSDZone_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require SuperDuper Zone"
                        InitialValue="0" ValidationGroup="Employee" ControlToValidate="DDLSDZone">.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label8" CssClass="lbl-form" runat="server" Text="Qualification"></asp:Label>
                    <%--<font color="red">*</font>--%>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="ddlqulification" DataTextField="value"
                        DataValueField="autoid" TabIndex="10" Width="100px" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="Reqqualif1" runat="server" ErrorMessage="Require Qualification"
                        InitialValue="0" ValidationGroup="Employee1" ControlToValidate="ddlqulification">.</asp:RequiredFieldValidator>
                </td>
                <td width="80px">
                    <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                   <%-- <font color="red">*</font>--%>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="DDLsuperzone" TabIndex="15" runat="server"
                        Width="100px" DataValueField="SuperZoneID" DataTextField="SuperZoneName1" OnSelectedIndexChanged="DDLsuperzone_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="Reqsuper" runat="server" ErrorMessage="Require Super Zone"
                        InitialValue="0" ValidationGroup="Employee1" ControlToValidate="DDLsuperzone">.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label19" CssClass="lbl-form" runat="server" Text="Department Code"></asp:Label>
                    <%--<font color="red">*</font>--%>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtDepCode" CssClass="inp-form" autocomplete="off" TabIndex="11"
                                runat="server" OnTextChanged="txtDepCode_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Reqqulification0" runat="server" ControlToValidate="ddlqulification"
                                ErrorMessage="Require Qualification" ValidationGroup="Employee1">.</asp:RequiredFieldValidator>
                            <div id="dvdepartment" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtDepCode"
                                UseContextKey="true" ContextKey="department" CompletionListElementID="dvdepartment">
                            </ajaxCt:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="reqDepcode" runat="server" ErrorMessage="Require Department Code"
                                ValidationGroup="Employee1" ControlToValidate="txtDepCode">.</asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLzone" TabIndex="16" runat="server" Width="100px"
                                DataValueField="ZoneID" DataTextField="ZoneName" OnSelectedIndexChanged="DDLzone_SelectedIndexChanged"
                                AutoPostBack="True" Enabled="false">
                            </asp:DropDownList>
                            <%--  <asp:RequiredFieldValidator ID="Reqzone" runat="server" ErrorMessage="Require Zone"
                                ValidationGroup="Employee" ControlToValidate="DDLzone">.</asp:RequiredFieldValidator>--%>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLsuperzone" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label21" CssClass="lbl-form" runat="server" Text="Join Date"></asp:Label>
                </td>
                <td width="120px">
                    <asp:TextBox ID="txtjoin" CssClass="inp-form" TabIndex="12" runat="server"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtjoin"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtjoin"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                </td>
                <td>
                    <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Area Zone"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="upDDLareazone" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLareazone" TabIndex="17" runat="server"
                                Width="100px" DataValueField="AreaZoneID" DataTextField="AreaZoneName" OnSelectedIndexChanged="DDLareazone_SelectedIndexChanged"
                                AutoPostBack="True" Enabled="false">
                            </asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="Reqareazone" runat="server" ErrorMessage="Require Area Zone"
                                ValidationGroup="Employee" ControlToValidate="DDLareazone">.</asp:RequiredFieldValidator>--%>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLzone" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label23" CssClass="lbl-form" runat="server" Text="Resignation Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtResign" CssClass="inp-form" TabIndex="13" runat="server"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtResign"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtResign"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                </td>
                <td>
                    <asp:Label ID="Label16" CssClass="lbl-form" runat="server" Text="Area"></asp:Label>
                </td>
                <td width="160px">
                    <div style="overflow: auto; height: 100px; width:100px;">
                        <asp:UpdatePanel ID="upDDLarea" runat="server">
                            <ContentTemplate>
                                <asp:CheckBoxList ID="Chkarea" DataTextField="AreaName" DataValueField="AreaID" Width="160px"
                                    TabIndex="18" runat="server" OnSelectedIndexChanged="Chkarea_SelectedIndexChanged"
                                    BorderStyle="Solid">
                                </asp:CheckBoxList>
                                .
                                <%--<asp:DropDownList CssClass="ddl-form" ID="DDLarea" TabIndex="17" runat="server" Width="100px"
                                DataValueField="AreaID" DataTextField="AreaName" Enabled="false" AutoPostBack="True">
                            </asp:DropDownList>--%>
                                <%-- <asp:RequiredFieldValidator ID="Reqarea" runat="server" ErrorMessage="Require area"
                                ValidationGroup="Employee" ControlToValidate="DDLarea">.</asp:RequiredFieldValidator>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label25" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="Chekacv"  runat="server" Checked="true" />
                </td>
            </tr>
            <tr style="display: none;">
                <td colspan="2">
                    <asp:Label ID="Label24" runat="server" CssClass="lbl-form" Text="Create Login"></asp:Label>
                    <asp:CheckBox ID="ChkLogin" runat="server" OnCheckedChanged="ChkLogin_CheckedChanged"
                        AutoPostBack="true" />
                    <asp:Label ID="lblID" runat="server" Style="display: none"></asp:Label>
                </td>
            </tr>
            <tr style="display: none;">
                <td colspan="4">
                    <asp:Panel ID="PnlLoginDetails" runat="server">
                        <table>
                            <tr>
                                <td width="100px">
                                    <asp:Label ID="LblPassword" CssClass="lbl-form" runat="server" Text="Password "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtPassword" CssClass="inp-form" TextMode="Password" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="100px">
                                    <asp:Label ID="LblRole" CssClass="lbl-form" runat="server" Text="Role "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="ddl-form" ID="DdlRole" runat="server" DataTextField="RoleName"
                                        DataValueField="RoleID">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel4" runat="server" Style="border: 1px solid #ccc;" EnableTheming="True"
        GroupingText="Address &amp; Other Details " CssClass="pnldash">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td width="100px">
                    <asp:Label ID="Label12" CssClass="lbl-form" runat="server" Text="Address"></asp:Label>
                </td>
                <td width="120px">
                    <asp:TextBox ID="txtAdd" CssClass="inp-form" TabIndex="19" Height="20px" Width="50px"
                        runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td width="80px" valign="bottom">
                    <asp:Label ID="lblstate" CssClass="lbl-form" runat="server" Text="State"></asp:Label>
                </td>
                <td valign="bottom">
                    <asp:DropDownList CssClass="ddl-form" ID="DDLstate" Width="100px" TabIndex="24" runat="server"
                        DataValueField="DMID" DataTextField="Name" AutoPostBack="true" OnSelectedIndexChanged="DDLstate_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" CssClass="lbl-form" runat="server" Text="Phone No.1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtphne1" CssClass="inp-form" TabIndex="20" runat="server"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="extender" runat="server" TargetControlID="txtphne1"
                        FilterType="Custom, Numbers" ValidChars="+-=/*()." />
                </td>
                <td>
                    <asp:Label ID="lblcity" CssClass="lbl-form" runat="server" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLcity" Width="100px" TabIndex="25" runat="server"
                                DataValueField="DMID" DataTextField="Name">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DDLstate" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label17" CssClass="lbl-form" runat="server" Text="Phone No.2"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtphne2" CssClass="inp-form" TabIndex="21" runat="server"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="Extender1" runat="server" TargetControlID="txtphne2"
                        FilterType="Custom, Numbers" ValidChars="+-=/*()." />
                </td>
                <td>
                    <asp:Label ID="Label20" CssClass="lbl-form" runat="server" Text="Zip Code"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtzipCode" CssClass="inp-form" TabIndex="26" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    <asp:Label ID="Label22" CssClass="lbl-form" runat="server" Text="EmailID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="inp-form" TabIndex="23" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <script type="text/javascript">
    
    shortcut.add("Ctrl+S",function() {
document.getElementById('<%=btnSavE.ClientID %>').click();
});
 setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+S : Save ] ";
   document.getElementById('status').innerHTML=status;
   
   }

    </script>

</asp:Panel>
<asp:Panel ID="pnlEmployeeDetails" runat="server">
    <asp:GridView ID="grdEmpDetails" runat="server" AllowPaging="true" AutoGenerateColumns="False"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="2000"
        Width="600px" OnPageIndexChanging="grdEmpDetails_PageIndexChanging" OnRowEditing="grdEmpDetails_RowEditing"
        OnRowDeleting="grdEmpDetails_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Emp Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblEmpCode" runat="server" Text='<%#Eval("EmpCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Emp Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblEID" runat="server" Style="display: none;" Text='<%#Eval("EmpID") %>'></asp:Label>
                    <asp:Label ID="lblFName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                    <asp:Label ID="LblLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dept Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblDeptId" runat="server" Text='<%#Eval("DeptCode")+" :: "+Eval("DeptName") %>'
                        Style="display: none;"></asp:Label>
                    <asp:Label ID="Label26" runat="server" Text='<%#Eval("DeptName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Area" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAreaID" runat="server" Text='<%#Eval("AreaID")%>' Style="display: none;"></asp:Label>
                    <asp:Label ID="lblAreaName" runat="server" Text='<%#Eval("AreaName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="City" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblCity" runat="server" Text='<%#Eval("City")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblEmailID" runat="server" Text='<%#Eval("EmailID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkisActive" runat="server" Enabled="false" Checked='<%#Eval("IsActive") %>'>
                    </asp:CheckBox>
                    <asp:Label ID="lblMiddleName" runat="server" Style="display: none;" Text='<%#Eval("MiddleName") %>'></asp:Label>
                    <asp:Label ID="LblAddress" runat="server" Style="display: none;" Text='<%#Eval("Address") %>'></asp:Label>
                    <asp:Label ID="LblZip" runat="server" Style="display: none;" Text='<%#Eval("Zip") %>'></asp:Label>
                    <asp:Label ID="LblPhone1" runat="server" Style="display: none;" Text='<%#Eval("Phone1") %>'></asp:Label>
                    <asp:Label ID="LblPhone2" runat="server" Style="display: none;" Text='<%#Eval("Phone2") %>'></asp:Label>
                    <asp:Label ID="LblGender" runat="server" Style="display: none;" Text='<%#Eval("Gender") %>'></asp:Label>
                    <asp:Label ID="LblDOB" runat="server" Style="display: none;" Text='<%#Eval("DOB") %>'></asp:Label>
                    <asp:Label ID="LblQualification" runat="server" Style="display: none;" Text='<%#Eval("Qualification") %>'></asp:Label>
                    <asp:Label ID="LblDesignation" runat="server" Style="display: none;" Text='<%#Eval("Designation") %>'></asp:Label>
                    <asp:Label ID="lblZoneID" runat="server" Style="display: none;" Text='<%#Eval("ZoneID") %>'></asp:Label>
                    <asp:Label ID="lblSuperZoneID" runat="server" Text='<%#Eval("SuperZoneID")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblAreaZoneID" runat="server" Text='<%#Eval("AreaZoneID")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblState" runat="server" Text='<%#Eval("State")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="LblJoinDate" runat="server" Style="display: none;" Text='<%#Eval("JoinDate") %>'></asp:Label>
                    <asp:Label ID="LblResignationDate" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("ResignationDate") %>'></asp:Label>
                    <asp:Label ID="lblpassword" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("Password") %>'></asp:Label>
                    <asp:Label ID="lblroleid" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("RoleId") %>'></asp:Label>
                    <asp:Label ID="lblphoto" runat="server" CssClass="lbl-form" Style="display: none;"
                        Text='<%#Eval("Photo") %>'></asp:Label>
                    <asp:Label ID="LblSDZoneId" runat="server" Text='<%#Eval("SDZoneID")%>' Style="display: none"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Are u sure u want to Delete?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <script type="text/javascript">
    
    shortcut.add("Ctrl+F",function() {
document.getElementById('search').focus();

});
 setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+F : Find ] ";
   document.getElementById('status').innerHTML=status;
   
   }




    </script>

</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Employee"
    runat="server" ID="ss" />
