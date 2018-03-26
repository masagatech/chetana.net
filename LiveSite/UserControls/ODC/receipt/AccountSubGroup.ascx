<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccountSubGroup.ascx.cs"
    Inherits="UserControls_ODC_receipt_AccountSubGroup" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Account Main SubGroup<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="280" Height="52px">
    <table>
        <tr>
            <td>
                <asp:Label ID="Id" runat="server" Style="display: none"></asp:Label>
                <asp:Label ID="lblmain" runat="server" CssClass="lbl-form" Text="Main Group"></asp:Label>
                <span style="color: Red">*</span>
            </td>
            <td>
            <asp:UpdatePanel ID="up" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddllist" CssClass="ddl-form" width="200px" runat="server"
                AutoPostBack="true" DataValueField="AutoId" DataTextField="MAIN_HEAD">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select MainGroup"
                    ValidationGroup="ct" Text="." InitialValue="0" ControlToValidate="ddllist"></asp:RequiredFieldValidator>
           </ContentTemplate>
           </asp:UpdatePanel>
            </td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="lblmaindrop" runat="server" CssClass="lbl-form" Text="Sub Group"></asp:Label>
                <span style="color: Red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtsub" CssClass="ddl-form" runat="server" width="200px" Height="17px" TabIndex="1" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Main Head"
                    ValidationGroup="ct" Text="." ControlToValidate="txtsub"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnsave" CssClass="submitbtn" TabIndex="2" runat="server" Text="Save"
                    Width="80px" OnClick="view_Click" ValidationGroup="ct" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:GridView ID="gvmaincode" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
    CellPadding="4" CssClass="product-table" ForeColor="#333333" 
    PageSize="100" Width="100px">
    <Columns>
        <asp:TemplateField HeaderText="Main Code" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <%--<asp:Label ID="lblMainCode" style="display:none" runat="server" Text='<%#Eval("Autoid") %>'></asp:Label>--%>
                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Sub_HEAD") %>'></asp:Label>
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
