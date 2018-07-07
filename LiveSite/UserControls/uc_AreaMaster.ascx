<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_AreaMaster.ascx.cs"
    Inherits="UserControls_uc_AreaMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <td>
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            <span runat="server" id="pageName"></span>
            <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
        <div class="options">
        </div>
    </td>
    <td>
        <div style="float: right; width: 50%">
            <div id="filter" runat="server">
                <span>Filter Data:</span>
                <input name="filt" id="find" onkeyup="filter(this, 'sf', '<%=grdAreaDetails.ClientID%>')" type="text" />
                <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
            </div>
        </div>
    </td>

</div>
<div style="float: right; width: 68%">
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="Save"
        Width="80px" OnClick="btnSave_Click" ValidationGroup="Area" />
    <asp:Button ID="Button1" CssClass="submitbtn"
        runat="server" Text="Export" Style="display: none"
        Width="80px" OnClick="Button1_Click" />

</div>
<div style="float: right; width: 15%">
    <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="submitbtn"
        Width="80px" OnClick="btnprint_Click" />
</div>
<br />
<br />
<asp:Panel ID="pnlAreaDetails" runat="server">

    <asp:GridView ID="grdAreaDetails" runat="server" AllowPaging="false"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" CellPadding="4"
        CssClass="product-table" ForeColor="#333333"
        OnPageIndexChanging="grdAreaDetails_PageIndexChanging"
        OnRowCreated="grdAreaDetails_RowCreated"
        OnRowDeleting="grdAreaDetails_RowDeleting"
        OnRowEditing="grdAreaDetails_RowEditing" PageSize="500" Width="600px">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                HeaderStyle-Width="80px" HeaderText="Area Code"
                ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAreaID" runat="server" Style="display: none"
                        Text='<%#Eval("AreaID")%>'></asp:Label>
                    <asp:Label ID="lblAreaCode" runat="server" Text='<%#Eval("AreaCode") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Area Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAreaName" runat="server" Text='<%#Eval("AreaName")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AreaZone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAreaZone" runat="server" Text='<%#Eval("AreaZoneName")%>'></asp:Label>
                    <asp:Label ID="lblAreaZoneID" runat="server" Style="display: none"
                        Text='<%#Eval("AreaZoneID")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Zone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblZone" runat="server" Text='<%#Eval("ZoneName")%>'></asp:Label>
                    <asp:Label ID="lblZoneID" runat="server" Style="display: none"
                        Text='<%#Eval("ZoneID")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SuperZone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblsuperZone" runat="server" Text='<%#Eval("SuperZoneName")%>'></asp:Label>
                    <asp:Label ID="lblSuperZoneID" runat="server" Style="display: none"
                        Text='<%#Eval("SuperZoneID")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>'
                        Enabled="false" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false"
                        CommandName="Edit" CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false"
                        CommandName="Delete" CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif"
                        OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle CssClass="alt" />
    </asp:GridView>

    <asp:Repeater ID="repAlfabets" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="lnkalfabet" CssClass="nav_bar_link" runat="server" Text='<%#Eval("chr") %>'
                OnClick="lnkalfabet_click"></asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>

    <script type="text/javascript">

        window.onload = function () {
            UpperBound = parseInt('<%= this.grdAreaDetails.Rows.Count %>') - 1;
        LowerBound = 0;
        SelectedRowIndex = -1;
    }
    shortcut.add("Ctrl+F", function () { document.getElementById('find').focus(); });
    setTimeout("setSatus()", 2000);
    function setSatus() {
        var status = "[ Ctrl+F : Find ]";
        document.getElementById('status').innerHTML = status;
    }
    </script>

</asp:Panel>
<asp:Panel ID="pnlArea" CssClass="panelDetails" runat="server" Width="400px">
    <table cellpadding="2" cellspacing="2" style="width: 97%">
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Area Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAreaCode" CssClass="inp-form" TabIndex="1" runat="server" AutoPostBack="True"
                            OnTextChanged="txtAreaCode_TextChanged"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqFnam" runat="server" ErrorMessage="Require Area Code"
                    ValidationGroup="Area" ControlToValidate="txtAreaCode">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Area Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtAreaName" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqAname" runat="server" ErrorMessage="Require Area Name"
                    ValidationGroup="Area" ControlToValidate="txtAreaName">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="SuperZone"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" Width="200px" DataTextField="SuperZoneName" DataValueField="SuperZoneID"
                    TabIndex="3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Require SuperZone"
                    InitialValue="none" ValidationGroup="Area" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLZone" DataTextField="ZoneName" DataValueField="ZoneID" runat="server"
                            TabIndex="4" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RfZ" runat="server" ErrorMessage="Require Zone" InitialValue="none"
                    ValidationGroup="Area" ControlToValidate="DDLZone">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Area Zone"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLAreaZone" DataTextField="AreaZoneName" DataValueField="AreaZoneID"
                            TabIndex="5" runat="server" Width="200px" OnSelectedIndexChanged="DDLAreaZone_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLZone"
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone"
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFAZ" runat="server" ErrorMessage="Require Area Zone"
                    InitialValue="none" ValidationGroup="Area" ControlToValidate="DDLAreaZone">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="Chekacv" TabIndex="6" runat="server" Checked="true" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        shortcut.add("Ctrl+S", function () {
            document.getElementById('<%=btnSave.ClientID %>').click();
                    });
                    setTimeout("setSatus()", 2000);
                    function setSatus() {
                        var status = "[ Ctrl+S : Save ]";
                        document.getElementById('status').innerHTML = status;
                    }
    </script>
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Area"
    runat="server" ID="ss" />
