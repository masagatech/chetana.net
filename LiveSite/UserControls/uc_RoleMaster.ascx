<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_RoleMaster.ascx.cs"
    Inherits="UserControls_RoleMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
        Role Add/Edit<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<div style="float: left; width: 260px">
    <asp:UpdatePanel ID="upAction" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Button ID="BtnAdd" Style="display: none;" CssClass="submitbtn" runat="server"
                Text="Add New" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnSave" ValidationGroup="role"  Style="float: right" CssClass="submitbtn" TabIndex="3" runat="server"
                Text="Save" Width="80px" OnClick="btnSave_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<br />
<br />
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlRoleDetails" runat="server">
            <asp:GridView ID="grdRoleDetails" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                CellPadding="4" CssClass="product-table" ForeColor="#333333" OnPageIndexChanging="grdRoleDetails_PageIndexChanging"
                OnRowEditing="grdRoleDetails_RowEditing" AlternatingRowStyle-CssClass="alt" PageSize="100"
                Width="400px" OnRowDeleting="grdRoleDetails_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Role Name">
                        <ItemTemplate>
                            <asp:Label ID="lblRID" runat="server" Style="display: none;" Text='<%#Eval("RoleId") %>'></asp:Label>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("RoleName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Active" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
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
<asp:UpdatePanel ID="UPAddRole" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <asp:Panel ID="PnlAddRole" CssClass="panelDetails" runat="server" Width="221px">
            <table width="100%" cellpadding="5" cellspacing="5">
                <tr>
                    <td>
                        <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Role Name"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRname" CssClass="inp-form" AutoPostBack="true" TabIndex="1" runat="server" 
                            ontextchanged="txtRname_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqRole" runat="server" ErrorMessage="Require Role Name"
                            ValidationGroup="role"  ControlToValidate="txtRname">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="Chekacv" TabIndex="2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel> 
<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="role"  ShowMessageBox="true" ShowSummary="false" runat="server" />
<script type="text/javascript">
     setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
   document.getElementById('status').innerHTML=status;
   }
        </script>
<script type="text/javascript">
      
shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_RoleMaster1_btnSave').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>