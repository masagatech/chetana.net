<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_LoginUserDetails.ascx.cs"
    Inherits="UserControls_uc_LoginUserDetails" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        User Login & Role Details <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<asp:UpdatePanel ID="upPanel" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlEmployee" runat="server">
            <asp:GridView ID="grdEmployeeDetails" runat="server" AutoGenerateColumns="False"
                CellPadding="4" CssClass="product-table" ForeColor="#333333" Width="500px" OnRowDataBound="grdEmployeeDetails_RowDataBound"
                AllowPaging="true" PageSize="300"
                OnPageIndexChanging="grdEmployeeDetails_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Emp Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="30px">
                        <ItemTemplate>
                            <asp:Label ID="lblempcode" runat="server" CssClass="lbl-form" Text='<%#Eval("EmpCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="90px">
                        <ItemTemplate>
                            <asp:Label ID="lblEID" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("EmpID") %>'></asp:Label>
                            <asp:Label ID="lblPassword" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("Password") %>'></asp:Label>

                            <asp:Label ID="lblEName" runat="server" CssClass="lbl-form" Text='<%#Eval("FirstName") +" "+Eval("LastName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Role" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="90px">
                        <ItemTemplate>
                            <asp:Label ID="lblRoleId" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("Roleid") %>'></asp:Label>
                            <asp:Label ID="lblCreateLogin" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("chklogin") %>'></asp:Label>
                            <asp:Label ID="lblIsSysadmin" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%# Eval("enableddl") %>'></asp:Label>

                            <asp:DropDownList ID="ddlrole" AutoPostBack="true" OnSelectedIndexChanged="ddlrole_changed" runat="server" Width="100px" DataValueField="RoleId"
                                DataTextField="RoleName">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="All Rights" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <asp:CheckBox ID="IsSystemAdmin" AutoPostBack="true" Checked='<%#Eval("IsSystemAdmin") %>'
                                runat="server"
                                OnCheckedChanged="IsSystemAdmin_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Block" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <table width="100%">
                                <tr>
                                    <td width="30%" border="0">
                                        <asp:CheckBox ID="chekisblock" Checked='<%#Eval("IsBlocked") %>' Enabled="false"
                                            runat="server" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnLink" runat="server" CommandArgument='<%#Eval("EmpID") %>'
                                            Text='<%#Eval("BlockText") %>' Style='<%#"color:" +Eval("BlockTextCol") %>' OnClick="btnLink_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ChangePassword" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnlpassword" runat="server" CommandArgument='<%#Eval("EmpID") %>'
                                Text="change" OnClick="lnlpassword_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Label ID="lblEID" runat="server" Style="display: none;"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:Panel ID="pnlPassword" runat="server" Style="display: none;">
    <div class="facebox">
        <div class="content">
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:ImageButton OnClientClick="ClosePop()" CssClass="close" ImageUrl="../Images/button-cross.png"
                        ID="ImageButton1" runat="server" />
                    <br />
                    <table>
                        <tr>
                            <td colspan="2">
                                <h2><span class="lbl-form" id="spnname" runat="server">Select Role</span></h2>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="lbl-form">Password :</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="lbl-form" id="selrol" runat="server">Select Role</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRolepop" runat="server" Width="100px" DataValueField="RoleId"
                                    DataTextField="RoleName">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnPasswordsave" CssClass="submitbtn" OnClick="btnPasswordsave_Click" runat="server" Text="Save" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnPasswordsave" EventName="click" />
                </Triggers>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Panel>
<asp:LinkButton ID="lnkbutton" runat="server" Style="display: none;">show </asp:LinkButton>
<ajaxCt:ModalPopupExtender ID="ModalPopUpExMSG" runat="server" TargetControlID="lnkbutton"
    PopupControlID="pnlPassword" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />

<script type="text/javascript">

    function ClosePop() {

        $find('<%=ModalPopUpExMSG.ClientID %>').hide();
  }


</script>

