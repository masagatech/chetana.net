<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccountMainGroup.ascx.cs"
    Inherits="UserControls_ODC_receipt_AccountMain" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Account Main Group<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="280" Height="52px">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblMainHead" runat="server" Style="display: none"></asp:Label>
                <asp:Label ID="lblchedate" runat="server" CssClass="lbl-form" Text="Main Head"></asp:Label>
                <span style="color: Red">*</span>
            </td>
            <td valign="middle">
                <asp:TextBox ID="txtmain" runat="server" Height="17px" TabIndex="1" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Main Head"
                    ValidationGroup="ct" Text="." ControlToValidate="txtmain"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="view" CssClass="submitbtn" TabIndex="2" runat="server" Text="Save"
                    Width="80px" OnClick="view_Click" ValidationGroup="ct" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:GridView ID="gvmaincode" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
    CellPadding="4" CssClass="product-table" ForeColor="#333333" 
    PageSize="100" Width="100px" onrowediting="gvmaincode_RowEditing">
    <Columns>
        <asp:TemplateField HeaderText="Main Code" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <asp:Label ID="lblMainCode" runat="server" Text='<%#Eval("Autoid") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Main Head" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="lblMainHead" runat="server" Text='<%#Eval("MAIN_HEAD") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
      <%--  <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                 <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                            CssClass="close" ImageUrl="../../../Images/icon/edit_icon.png" />
            </ItemTemplate>
        </asp:TemplateField>--%>
    </Columns>
</asp:GridView>
<asp:ValidationSummary ID="summ" runat="server" ShowMessageBox="true" ShowSummary="false"
    ValidationGroup="ct" />
