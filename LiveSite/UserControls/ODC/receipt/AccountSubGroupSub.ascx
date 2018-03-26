<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccountSubGroupSub.ascx.cs"
    Inherits="UserControls_ODC_receipt_AccountSubGroupSub" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Account SubGroup<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="280" Height="138px">
    <table>
        <tr>
            <td>
                <asp:Label ID="Id" runat="server" Style="display: none"></asp:Label>
                <asp:Label ID="lblmaingroup" runat="server" CssClass="lbl-form" Text="Main Group"></asp:Label>
                <span style="color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlmaingroup" CssClass="ddl-form" Width="200px" runat="server"
                    AutoPostBack="true" DataValueField="AutoId" DataTextField="MAIN_HEAD" OnSelectedIndexChanged="ddlmaingroup_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select MainGroup"
                    ValidationGroup="ct" Text="." InitialValue="0" ControlToValidate="ddlmaingroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSubGroup" runat="server" CssClass="lbl-form" Text="Sub Group"></asp:Label>
                <span style="color: Red">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubGroup" CssClass="ddl-form" Width="200px" runat="server"
                    AutoPostBack="true" DataValueField="Sub_Main_Code" DataTextField="Sub_HEAD" OnSelectedIndexChanged="ddlSubGroup_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select SubGroup"
                    ValidationGroup="ct" Text="." InitialValue="0" ControlToValidate="ddlSubGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblmaindrop" runat="server" CssClass="lbl-form" Text="Sub Group Name"></asp:Label>
                <span style="color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtsub" CssClass="ddl-form" runat="server" Width="200px" Height="17px"
                    TabIndex="3" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Main Head"
                    ValidationGroup="ct" Text="." ControlToValidate="txtsub"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnsave" CssClass="submitbtn" TabIndex="4" runat="server" Text="Save"
                    Width="80px" OnClick="view_Click" ValidationGroup="ct" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:GridView ID="gvmaincode" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
    CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="100" Width="100px">
    <Columns>
        <asp:TemplateField HeaderText="GR HEAD" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <%--<asp:Label ID="lblMainCode" style="display:none" runat="server" Text='<%#Eval("Autoid") %>'></asp:Label>--%>
                <asp:Label ID="Label1" runat="server" Text='<%#Eval("GR_HEAD") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sub HEAD" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="lblMainHead" runat="server" Text='<%#Eval("Sub_HEAD") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:ValidationSummary ID="summ" runat="server" ShowMessageBox="true" ShowSummary="false"
    ValidationGroup="ct" />
