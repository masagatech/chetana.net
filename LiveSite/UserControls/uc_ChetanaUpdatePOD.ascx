<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ChetanaUpdatePOD.ascx.cs" Inherits="UserControls_uc_ChetanaUpdatePOD" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <tr>
        <td>
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
                <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </td>
    </tr>
</div>
<asp:UpdatePanel ID="UpdatePanel7" runat="server">

    <ContentTemplate>
        <div style="margin: -30px 0 0; position: fixed; top: 100px; left: 210.5px;" id="divLevel1" runat="server">
            <asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Style="float: left; height: 20px; margin: 0 4px 0 0; width: 210px;">
                <table>
                    <tr>
                        <td>
                            <asp:RadioButtonList runat="server" ID="rdLevel1" TabIndex="1" RepeatDirection="Horizontal"
                                CssClass="lbl-form" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rdLevel1_SelectedIndexChanged">
                                <asp:ListItem Value="InvoiceNo" Text="Invoice" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="Others" Text="Others"></asp:ListItem>
                                <%-- <asp:ListItem Value="General" Text="General"></asp:ListItem>--%>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

                </table>
            </asp:Panel>
        </div>
        <div style="margin: -30px 0 0; position: fixed; top: 164px; left: 210.5px;" id="divLevel2" runat="server">
            <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server" Style="float: left; height: 84px; margin: 0 4px 0 0; width: 680px;">

                <asp:Panel ID="pnldoc123" runat="server">


                    <table>
                        <tr>

                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Courier Company" CssClass="lbl-form"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList CssClass="ddl-form" ID="ddlCourierI" DataTextField="Value" DataValueField="AutoId" TabIndex="1"
                                    runat="server">
                                </asp:DropDownList>
                            </td>


                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Branch" CssClass="lbl-form"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList CssClass="ddl-form" Width="104%" ID="ddlBranchI" DataTextField="Branch"
                                    DataValueField="EmpID" TabIndex="2"
                                    runat="server">
                                </asp:DropDownList>

                            </td>

                        </tr>

                    </table>
                    <table>
                        <tr>
                            <td width="60px" id="CID" runat="server" visible="true">
                                <asp:Label ID="Label1" runat="server" Text="Courier Id" CssClass="lbl-form"></asp:Label>
                            </td>
                            <td id="CIDT" runat="server" visible="true">
                                <asp:TextBox ID="txtCourierId" CssClass="inp-form" TabIndex="22" runat="server"></asp:TextBox>
                            </td>

                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Invoice No." CssClass="lbl-form"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInvoiceNoGet" CssClass="inp-form" TabIndex="22" runat="server"></asp:TextBox>
                            </td>


                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Dc No." CssClass="lbl-form"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDocNoGet" CssClass="inp-form" TabIndex="22" runat="server"></asp:TextBox>
                            </td>

                        </tr>


                        <tr>
                            <td>
                                <asp:Label ID="lblFromdateCust" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                                    Format="dd/MM/yyyy" />
                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                    AutoComplete="true" CultureName="en-GB" />

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Fromdate"
                                    ValidationGroup="AZone" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblToDateCust" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTo" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                                    Format="dd/MM/yyyy" />
                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                    AutoComplete="true" CultureName="en-GB" />

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
                                    ValidationGroup="AZone" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="POD" CssClass="lbl-form"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txtpod" CssClass="inp-form" onkeypress="return CheckNumeric(event)" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnget" runat="server" Text="Get" CssClass="submitbtn" TabIndex="24"
                                    ValidationGroup="AZone" Width="50px" OnClick="btnget_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
            <div class="message_error" id="message_error" runat="server" visible="false">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSCD" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
            </div>


            <p>
            </p>

            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
                runat="server" ID="bk" />
             <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Other"
                runat="server" ID="ValidationSummary1" />


        </div>
        <div style="margin: -30px 0 0; position: fixed; top: 164px; left: 210.5px;" id="divGeneral" runat="server">
            <asp:Panel ID="Panel2" CssClass="panelDetails" runat="server" Style="float: left; height: 84px; margin: 0 4px 0 0; width: 690px;">

                <asp:Panel ID="Panel3" runat="server">
                    <table>
                        <tr>
                            <td width="60px" id="Td1" runat="server" visible="true">
                                <asp:Label ID="lblGeneralCourierID" runat="server" Text="Courier Id" CssClass="lbl-form"></asp:Label>
                            </td>
                            <td id="Td2" runat="server" visible="true">
                                <asp:TextBox ID="txtGeneralCourierID" CssClass="inp-form" TabIndex="22" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>

                            <td width="70px">
                                <asp:Label ID="Label4" runat="server" Text="Courier Company" CssClass="lbl-form"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList CssClass="ddl-form" ID="ddlCourier" DataTextField="Value" DataValueField="AutoId" TabIndex="1"
                                    runat="server">
                                </asp:DropDownList>
                            </td>


                            <td width="50px">
                                <asp:Label ID="Label5" runat="server" Text="Branch" CssClass="lbl-form"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList CssClass="ddl-form" Width="104%" ID="ddlBranch" DataTextField="Branch"
                                    DataValueField="EmpID" TabIndex="2"
                                    runat="server">
                                </asp:DropDownList>

                            </td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromGeneral" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromGeneral"
                                    Format="dd/MM/yyyy" />
                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtFromGeneral"
                                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                    AutoComplete="true" CultureName="en-GB" />

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select Fromdate"
                                    ValidationGroup="Other" ControlToValidate="txtFromGeneral">.</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToGeneral" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToGeneral"
                                    Format="dd/MM/yyyy" />
                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtToGeneral"
                                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                    AutoComplete="true" CultureName="en-GB" />

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select ToDate"
                                    ValidationGroup="Other" ControlToValidate="txtToGeneral">.</asp:RequiredFieldValidator>
                            </td>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="POD" CssClass="lbl-form"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtpod1" CssClass="inp-form" runat="server" onkeypress="return CheckNumeric(event)"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="Get" CssClass="submitbtn" TabIndex="24"
                                        ValidationGroup="Other" Width="50px" OnClick="btnget_Click" />
                                </td>
                            </tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
            <div class="message_error" id="Div2" runat="server" visible="false">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
            </div>


            <p>
            </p>



        </div>
        <div style="margin: -30px 0 0; position: relative; top: 194px; left:-1.5px;" id="divGrid" runat="server">



            <asp:Repeater ID="RepDetailsConfirm" runat="server" OnItemDataBound="RepDetailsConfirm_ItemDataBound"
                OnItemCommand="RepDetailsConfirm_ItemCommand">
                <ItemTemplate>
                    <div class="actiontab">
                        <table width="100%" border="0" cellpadding="2" cellspacing="2">
                            <tr>
                                <td valign="bottom">
                                    <%--   <span>Courier No :
                                                <asp:Label ID="SCMasterAutoId" Style="font-weight: bold; font-size: 13px;" runat="server"
                                                    Text='<%#Eval("SCMasterAutoId")%>'></asp:Label>--%>
                                </td>

                            </tr>
                        </table>
                    </div>
                    <div style="margin: -30px 0 0; position: relative; top: 30px; left: -7.5px;" id="divGridInvoice" runat="server">



                        <asp:GridView ID="grdCD" AlternatingRowStyle-CssClass="alt" CssClass="product-table" AutoGenerateColumns="false" ShowFooter="true" runat="server" OnRowDataBound="grdCD_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Is Active" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkIsActive" runat="server" Enabled="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sr. No." HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSCMasterAutoId" runat="server" Style="display: none" Text='<%#Eval("SCDetailAutoId")%>'></asp:Label>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Courier ID" HeaderStyle-Width="50px" Visible="false">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Document No" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocumentNo" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice No" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoiceNo" runat="server" Text='<%#Eval("InvoiceNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Party Code" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Party Name" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Party Address" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Party Phone" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Courier Company" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblValue" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Name" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("Branch")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Address" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchAddress" runat="server" Text='<%#Eval("BranchAdd")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Courier Date" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedOn" runat="server" Text='<%#Eval("CreatedOn")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="POD" ItemStyle-Width="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAPODId" Style="text-align:center; display: none;" runat="server" Text='<%#Eval("PODId")%>'></asp:Label>
                                        <asp:TextBox ID="txtPODId" Style="width: 70px;" runat="server"
                                            Text='<%#Eval("PODId")%>'></asp:TextBox>

                                        <asp:Label Style="display: none;" ID="lblPODIdZ" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblBPODId" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Weight" ItemStyle-Width="70px" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPODss" runat="server" Text='<%#Eval("Weight")%>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="margin: -30px 0 0; position: relative; top: 30px; left: -7.5px;" id="divGridGeneral" runat="server">



                        <asp:GridView ID="gdGeneral" AlternatingRowStyle-CssClass="alt" CssClass="product-table" AutoGenerateColumns="false" ShowFooter="true" runat="server" OnRowDataBound="gdGeneral_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Is Active" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkIsActive1" runat="server" Enabled="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sr. No." HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUNIQ" runat="server" Style="display: none" Text='<%#Eval("UNIQ")%>'></asp:Label>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Courier ID" HeaderStyle-Width="50px" Visible="false">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UNIQ" HeaderStyle-Width="50px" Visible="false">
                                    <ItemTemplate>
                                              <%--<asp:Label ID="lblUNIQ" runat="server" Text='<%#Eval("SCDetailAutoId")%>'></asp:Label>--%>
                                        <asp:Label ID="lblSCMasterAutoIdGeneral" runat="server" Style="display: none" Text='<%#Eval("SCDetailAutoId")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>




                                <asp:TemplateField HeaderText="Courier Company" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblValue" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Name" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("Branch")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="To Address" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchAdd" runat="server" Text='<%#Eval("BranchAdd")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark1")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Department" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Department")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Courier Date" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedOng" runat="server" Text='<%#Eval("CreatedOn")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="POD" ItemStyle-Width="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAPODIdG" Style="text-align:center; display: none;" runat="server" Text='<%#Eval("PODId")%>'></asp:Label>
                                        <asp:TextBox ID="txtPODIdG" Style="width: 70px;" runat="server" onkeypress="return CheckNumeric(event)"
                                            Text='<%#Eval("PODId")%>'></asp:TextBox>

                                        <asp:Label Style="display: none;" ID="lblPODIdZ11" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblBPODId11" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Weight" ItemStyle-Width="70px" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPODs" runat="server" Text='<%#Eval("Weight")%>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <table style="float: left;" cellspacing="2" cellpadding="2">
                    </table>
                    <asp:UpdatePanel ID="updateapprove" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <div style="margin: -30px 0 0; position: relative; top: -5px; left: -7.5px;" id="div1" runat="server">


                                <table style="float: right;" cellspacing="2" cellpadding="2">

                                    <tr>
                                        <td align="left" colspan="4">
                                            <asp:Button ID="btnUpdate" CommandArgument='<%#Eval("SCMasterAutoId")%>' CommandName="update"
                                                TabIndex="6" runat="server" Text="Update POD" CssClass="submitbtn" Width="110px"
                                                Style="float: right; margin: 47px 0 30px 0px" OnClick="btnUpdate_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnDelte" CommandName="delete" CommandArgument='<%#Eval("SCMasterAutoId")%>' TabIndex="6"
                                                runat="server" Text="Delete POD" CssClass="submitbtn" Width="110px" Style="float: right; margin: 47px 0 30px 0px"
                                                OnClick="btnDelte_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <hr style="background-color: Red" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ItemTemplate>
            </asp:Repeater>



        </div>
    </ContentTemplate>

</asp:UpdatePanel>

<script type="text/javascript">

    shortcut.add("Ctrl+S", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_ChetanaUpdatePOD1_btn_Save').click();
    });

</script>

<asp:HiddenField ID="HidFY" runat="server" />
