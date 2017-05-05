<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Vehicle.ascx.cs" Inherits="Godown_Vehicle" %>
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
<div style="float: left; width: 48%">
    <%--    <asp:UpdatePanel ID="updatebtn" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <asp:Button ID="btn_Save" Visible="false" Style="float: right;" 
        CssClass="submitbtn" ValidationGroup="G_Vehicle"
        TabIndex="7" runat="server" Text="Save" Width="80px" 
        OnClick="btn_Save_Click" />
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
</div>
<br />
<br />
<asp:Panel ID="pnlAddForm" Visible="false" CssClass="panelDetails" runat="server"
    Width="480px">
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td width="95px">
                <asp:Label ID="lblID" runat="server" Text="0" Style="display: none;"></asp:Label>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Vehicle No."></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox autocomplete="false" ID="txtVNo" CssClass="inp-form" TabIndex="1" runat="server"
                    ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtVNo" ErrorMessage="Reuired" ValidationGroup="G_Vehicle">Reuired</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="95px">
                <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="V. Desc." 
                    ToolTip="Vehicle Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVDisc" runat="server" CssClass="inp-form" TabIndex="2" 
                    TextMode="MultiLine" Width="145px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="95px">
                <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="V. Type" 
                    ToolTip="Vehicle"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVehType" runat="server" CssClass="inp-form" TabIndex="4"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="95px">
                <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="I. M." 
                    ToolTip="I_M"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtIm" runat="server" CssClass="inp-form" TabIndex="4"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" CssClass="lbl-form" ToolTip="Active" runat="server" Text="Active"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkActive" TabIndex="5" Checked="true" runat="server" />
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
document.getElementById('ctl00_ContentPlaceHolder1_uc_DC_Master1_btn_Save').click();
});
    </script>

</asp:Panel>
<asp:Panel ID="pnlViewForm" Visible="false"  runat="server">
    <asp:GridView ID="grdVehicle" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="800" Width="600px"
        AlternatingRowStyle-CssClass="alt" OnRowDeleting="grdVehicle_RowDeleting" 
        OnRowEditing="grdVehicle_RowEditing" >
        <Columns>
            <asp:TemplateField HeaderText="Veh No" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblVehID" runat="server" Text='<%#Eval("Veh_id")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblVehNo" runat="server" Text='<%#Eval("Veh_no") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Veh Desc" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblVehDesc" runat="server" Text='<%#Eval("Veh_desc")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Veh Type" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblVehType" runat="server" Text='<%#Eval("veh_type")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IM" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblIM" runat="server" Text='<%#Eval("I_M")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsActive")) %>'
                        Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
