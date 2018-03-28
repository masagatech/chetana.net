<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SectionMaster.ascx.cs"
    Inherits="UserControls_uc_SectionMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
 
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
        Sections<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>    
</div>
<div style="float: right; width: 77%">  
        <asp:Button ID="btnSave" Enabled="false" CssClass="submitbtn" ValidationGroup="sections" TabIndex="3" runat="server" Text="Save"   
            Width="80px" OnClick="btnSave_Click" />     
</div>
<br />
<br />
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlSectionMasterDetails" runat="server">
            <asp:GridView ID="grdSectionMasterDetails" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="10" Width="600px"
                OnPageIndexChanging="grdSectionMasterDetails_PageIndexChanging" OnRowDeleting="grdSectionMasterDetails_RowDeleting" OnRowDataBound="grdSectionMasterDetails_RowDataBound"
                OnRowEditing="grdSectionMasterDetails_RowEditing">
                <Columns>
                    <asp:TemplateField HeaderText="Section Code" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lblSectionID" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("SectionID") %>'></asp:Label>
                            <asp:Label ID="lblSectioncode" runat="server"  Text='<%#Eval("Sectioncode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Section Name">
                        <ItemTemplate>
                            <asp:Label ID="lblSectionName" runat="server" Text='<%#Eval("SectionName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Active" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <asp:ImageButton Visible="false" ID="lblEdit" ToolTip="Edit" runat="server" CausesValidation="false" CommandName="Edit"
                                CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                            <asp:ImageButton Visible="false" ID="LblDelete" ToolTip="Remove" runat="server" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?')"
                                CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UPAddSection" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <asp:Panel ID="PnlAddSection" CssClass="panelDetails" runat="server" Width="300px">
            <table width="70%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Section code :"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtSectionCode" CssClass="inp-form" TabIndex="1" 
                            runat="server" MaxLength="20"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="ReqSectionCode" runat="server" ErrorMessage="Require Section Code"
                            ValidationGroup="sections" ControlToValidate="TxtSectionCode">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Section name :"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtSectionName" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="ReqTxtSectionName" runat="server" ErrorMessage="Require Section Name"
                            ValidationGroup="sections" ControlToValidate="TxtSectionName">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="Chekacv" TabIndex="2" runat="server" Checked="true" />
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
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="sections" runat="server" ID="ss"/>



<script type="text/javascript">


shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_SectionMaster1_btnSave').click();
});



</script>