<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_TeamMaster.ascx.cs"
    Inherits="UserControls_uc_TeamMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    &nbsp;<td>
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
            </a>
        </div>
    </td>
    <td>
        <div style="float: right; width: 50%">
            <div id="filter" runat="server" style="width: 220px; clear: both; float: left;">
                <span>Filter Data:</span>
                <input name="filt" id="find" onkeyup="filter(this, 'sf', '1')" type="text">
            </div>
        </div>
    </td>
</div>
<div style="float: right; width: 76%">
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="3" runat="server" Text="Save"
        Width="80px" ValidationGroup="st1" OnClick="btnSave_Click" />
</div>
<br />
<br />
<asp:Panel ID="PnlCCDetails" runat="server">
    <asp:GridView ID="GrdCCDetails" runat="server" AllowPaging="false" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
        PageSize="10" Width="600px" OnRowDeleting="GrdCCDetails_RowDeleting" OnRowEditing="GrdCCDetails_RowEditing"
        DataKeyNames="TeamID">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Team Name" HeaderStyle-Width="100px"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblTMID" runat="server" Style="display: none" Text='<%#Eval("TeamID")%>'></asp:Label>
                    <asp:Label ID="lblTMNAME" runat="server" Text='<%#Eval("TeamName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Team Desc" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lbltdesc" runat="server" Text='<%#Eval("TeamDesc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IsActive" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
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
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <script type="text/javascript">
        function filter(phrase, _id) {
            var words = phrase.value.toLowerCase().split(" ");
            var table = document.getElementById('<%=GrdCCDetails.ClientID%>');
            //document.getElementById(_id);
            var ele;
            for (var r = 1; r < table.rows.length; r++) {
                ele = table.rows[r].innerHTML.replace(/<[^>]+>/g, "");
                var displayStyle = 'none';
                for (var i = 0; i < words.length; i++) {
                    if (ele.toLowerCase().indexOf(words[i]) >= 0)
                        displayStyle = '';
                    else {
                        displayStyle = 'none';
                        break;
                    }
                }
                table.rows[r].style.display = displayStyle;
            }
            if (words != "") {
                sloder('search for : ' + words);
            }
            else {
                cloder();
            }
        }
        shortcut.add("Ctrl+F", function () {
            document.getElementById('find').focus();
        });
        setTimeout("setSatus()", 2000);
        function setSatus() {
            var status = "[ Ctrl+F : Find ]";
            document.getElementById('status').innerHTML = status;
        }
    </script>
</asp:Panel>
<script type="text/javascript">
    function filter(phrase, _id) {
        var words = phrase.value.toLowerCase().split(" ");
        var table = document.getElementById('<%=GrdCCDetails.ClientID%>');
        //document.getElementById(_id);
        var ele;
        for (var r = 0; r < table.rows.length; r++) {
            ele = table.rows[r].innerHTML.replace(/<[^>]+>/g, "");
            var displayStyle = 'none';
            for (var i = 0; i < words.length; i++) {
                if (ele.toLowerCase().indexOf(words[i]) >= 0)
                    displayStyle = '';
                else {
                    displayStyle = 'none';
                    break;
                }
            }
            table.rows[r].style.display = displayStyle;
        }
        if (words != "") {
            sloder('search for : ' + words);
        }
        else {
            cloder();
        }
    }
</script>
<asp:Panel ID="PnlAddCC" CssClass="panelDetails" runat="server" Width="310px">
    <asp:Label ID="lblTMID" runat="server" Text="0" Style="display: none;"></asp:Label>
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Team Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txttname" TabIndex="1" CssClass="inp-form" runat="server" 
                    MaxLength="20" ontextchanged="txttname_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqname" runat="server" ErrorMessage="Require Team Name"
                    ValidationGroup="st1" ControlToValidate="txttname">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Team Desc"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtdesc" runat="server" Height="40px" CssClass="inp-form" TabIndex="2"
                    TextMode="MultiLine" Width="140px"></asp:TextBox>
            </td>
            <tr>
                <td>
                    <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="ChekActive" TabIndex="3" runat="server" Checked="true" />
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
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="st1"
    runat="server" ID="ss" />
