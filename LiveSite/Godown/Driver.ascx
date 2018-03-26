<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Driver.ascx.cs" Inherits="Godown_Driver" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <td>
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
            </a>
        </div>
        <div class="options">
        </div>
    </td>
</div>
<div style="float: left; width: 480px">
    <%--<asp:UpdatePanel ID="updatebtn" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <asp:Button ID="btn_Save" Visible="false" Style="float: right;" CssClass="submitbtn"
        ValidationGroup="v_Driver" TabIndex="14" ToolTip="Save" runat="server" Text="Save"
        Width="80px" OnClick="btn_Save_Click" />
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</div>
<br />
<br />
<asp:Panel ID="pnlAddForm" CssClass="panelDetails" runat="server" Width="480px">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td width="110px">
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtName" Width="153px" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Required" ValidationGroup="v_Driver">Required</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="50px">
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Vehicle"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList Width="153px" DataTextField="Veh_no" DataValueField="Veh_id" CssClass="inp-ddl"
                    ID="ddlVehicle" TabIndex="2" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Add 1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAdd1" Width="153px" CssClass="inp-form" runat="server" TabIndex="3"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" CssClass="lbl-form" runat="server" Text="Add 2"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAdd2" Width="153px" CssClass="inp-form" runat="server" TabIndex="4"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" CssClass="lbl-form" runat="server" Text="Add 3"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAdd3" Width="153px" CssClass="inp-form" runat="server" TabIndex="5"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Area"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtArea" Width="153px" CssClass="inp-form" runat="server" TabIndex="6"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="City"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCity" Width="153px" CssClass="inp-form" runat="server" TabIndex="7"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" CssClass="lbl-form" runat="server" Text="Mobile"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMobile" Width="153px" CssClass="inp-form" runat="server" TabIndex="8"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" CssClass="lbl-form" runat="server" Text="Mobile 1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMobile1" Width="153px" CssClass="inp-form" runat="server" TabIndex="9"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" CssClass="lbl-form" runat="server" Text="Licence No"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtLicence" Width="153px" CssClass="inp-form" runat="server" TabIndex="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLicence"
                    ErrorMessage="Required" ValidationGroup="v_Driver">Required</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label12" CssClass="lbl-form" runat="server" Text="Licence Expiry Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtLicenceExpDate" Width="153px" CssClass="inp-form" runat="server"
                    TabIndex="11"></asp:TextBox>(dd/mm/yyyy)
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLicenceExpDate"
                    ErrorMessage="Required" ValidationGroup="v_Driver">Required</asp:RequiredFieldValidator>
                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtLicenceExpDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" TargetControlID="txtLicenceExpDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" CssClass="lbl-form" ToolTip="Active" runat="server" Text="Active"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkActive" TabIndex="13" Checked="true" runat="server" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <%--
        <script type="text/javascript">
     setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
   document.getElementById('status').innerHTML=status;
   }
        </script>--%>

    <script type="text/javascript">
        
        shortcut.add("Ctrl+S",function() {
            document.getElementById('<%=btn_Save.ClientID %>').click();
});
    </script>

</asp:Panel>
<asp:Panel ID="pnlViewForm"  runat="server">
    <asp:GridView ID="grdDriver" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="800" Width="600px"
        AlternatingRowStyle-CssClass="alt" OnRowDeleting="grdDriver_RowDeleting" OnRowEditing="grdDriver_RowEditing">
        <Columns>
            <asp:TemplateField HeaderText="Driver Name" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblDrID" runat="server" Text='<%#Eval("DR_ID")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblDriverName" runat="server" Text='<%#Eval("NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VehVehicle" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblVehId" Style="display: none" runat="server" Text='<%#Eval("VEH_ID")%>'></asp:Label>
                    <asp:Label ID="lblVehicle" runat="server" Text='<%#Eval("VEHICLE")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mobile" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAdd1" Style="display: none" runat="server" Text='<%#Eval("ADD1")%>'></asp:Label>
                    <asp:Label ID="lblAdd2" Style="display: none" runat="server" Text='<%#Eval("ADD2")%>'></asp:Label>
                    <asp:Label ID="lblAdd3" Style="display: none" runat="server" Text='<%#Eval("ADD3")%>'></asp:Label>
                    <asp:Label ID="lblAreaCode" Style="display: none" runat="server" Text='<%#Eval("AREACODE")%>'></asp:Label>
                    <asp:Label ID="lblCityCode" Style="display: none" runat="server" Text='<%#Eval("City")%>'></asp:Label>
                    <asp:Label ID="lblMob" runat="server" Text='<%#Eval("MOBILE")%>'></asp:Label>
                    <asp:Label ID="lblMob1" Style="display: none;" runat="server" Text='<%#Eval("TEL1")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Licence No" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblLicence" runat="server" Text='<%#Eval("Licence")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lic. Exp Date" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblLicExpDate" runat="server" Text='<%#Eval("LicenceExpDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("VEH_ID")%>'
                        CommandName="Delete" CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif"
                        OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
