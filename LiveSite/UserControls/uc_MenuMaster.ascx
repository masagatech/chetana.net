<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_MenuMaster.ascx.cs"
    Inherits="UserControls_MenuMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
        Menu ADD/EDIT <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
        <asp:Button ID="BtnAdd" CssClass="form-submit" runat="server" Text="Add New" OnClick="BtnAdd_Click" />
        <asp:Button ID="btnsav" CssClass="form-submit" TabIndex="4" runat="server" ValidationGroup="M"
            Text="Save" Width="80px" OnClick="btnsav_Click" />
        <asp:Button ID="btncancel" CssClass="form-submit" TabIndex="5" runat="server" Text="Cancel"
            Width="80px" OnClick="btncancel_Click" />
    </div>
</div>
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlMenu" runat="server">
            <asp:GridView ID="grdMenuDetails" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                CellPadding="4" CssClass="product-table" ForeColor="#333333" OnPageIndexChanging="grdMenuDetails_PageIndexChanging"
                OnRowDeleting="grdMenuDetails_RowDeleting" OnRowEditing="grdMenuDetails_RowEditing"
                PageSize="10" Width="600px">
                <Columns>
                    <asp:TemplateField HeaderText="Menu Name">
                        <ItemTemplate>
                            <asp:Label ID="lblMID" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("MenuId") %>'></asp:Label>
                            <asp:Label ID="lblName" runat="server" CssClass="lbl-form" Text='<%#Eval("MenuName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Link">
                        <ItemTemplate>
                            <asp:Label ID="lblLink" runat="server" CssClass="lbl-form" Text='<%#Eval("Link") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Active" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                            <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Are u sure u wat to Delete?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <asp:Panel ID="PnlAddMenu" CssClass="panelDetails" runat="server" Width="300px">
            <table width="70%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Menu Name"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMname" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="ReqMName" runat="server" ErrorMessage="Require menu name"
                            ValidationGroup="M" ControlToValidate="txtMname">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Link"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtlink" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="Reqlink" runat="server" ErrorMessage="Require link"
                            ValidationGroup="M" ControlToValidate="txtlink">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chekactive" TabIndex="3" runat="server" Checked="true" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
