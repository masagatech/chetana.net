<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ExpenseHead.ascx.cs"
    Inherits="UserControls_uc_ExpenseHead" %>
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
    <td>
        <div style="float: right; width: 50%">
        </div>
    </td>
</div>
<div style="float: right; width: 68%">
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="Save"
        ValidationGroup="zone" Width="80px" OnClick="btnSave_Click" />
</div>
<br />
<br />
<asp:Panel ID="pnlExpense" CssClass="panelDetails" runat="server" Width="400px">
    <table width="90%" cellpadding="2" cellspacing="2">
        <tr>
            <td width="100px">
                <asp:Label ID="lblID" runat="server"  Style="display: none;"></asp:Label>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Expense Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="200px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtexpenseCode" CssClass="inp-form" TabIndex="1" 
                            AutoComplete="off" runat="server"
                            AutoPostBack="True" ontextchanged="txtexpenseCode_TextChanged"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqFnamZcod" runat="server" ErrorMessage="Require Expense Code"
                    ValidationGroup="expense" ControlToValidate="txtexpenseCode">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Expense Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtexpenseName" CssClass="inp-form" TabIndex="2" AutoComplete="off" runat="server"
                    MaxLength="30"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqZname" runat="server" ErrorMessage="Require Expense Name"
                    ValidationGroup="expense" ControlToValidate="txtexpenseName">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Expense Type"></asp:Label>
                 <font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="DDLexpensetype"  DataTextField="Value" DataValueField="autoID"
                    Width="160px" TabIndex="3" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqDDL" runat="server" ErrorMessage="Select Type"
                    InitialValue="none" ValidationGroup="expense" ControlToValidate="DDLexpensetype">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Expense Group"></asp:Label>
                 <font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="ddlexpensegroup" DataTextField="Value"
                    DataValueField="autoID" Width="160px" TabIndex="4" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Group"
                    InitialValue="none" ValidationGroup="expense" ControlToValidate="ddlexpensegroup">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Description"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtdescription" CssClass="inp-form" TabIndex="5" AutoComplete="off" runat="server"></asp:TextBox>
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
                    shortcut.add("Ctrl+S",function() 
                    {
                        document.getElementById('<%=btnSave.ClientID %>').click();
                    });
                        setTimeout("setSatus()",2000);
                    function setSatus()
                    {
                        var status="[ Ctrl+S : Save ]";
                        document.getElementById('status').innerHTML=status;
                    }   
    </script>

</asp:Panel>
<asp:Panel ID="pnlExpensedetails" runat="server">
    <asp:GridView ID="grdExpense" runat="server" AllowPaging="false" AutoGenerateColumns="false"
        CssClass="product-table" ForeColor="#333333" PageSize="500" Width="600px" 
        AlternatingRowStyle-CssClass="alt" onrowdeleting="grdExpense_RowDeleting" 
        onrowediting="grdExpense_RowEditing">
        <Columns>
            <asp:TemplateField HeaderText="Expense Code">
                <ItemTemplate>
                    <asp:Label ID="lblExpenseid" runat="server" Text='<%#Eval("AutoID")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblExpenseCode" runat="server" Text='<%#Eval("ExpenseCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Expense Name">
                <ItemTemplate>
                    <asp:Label ID="lblExpenseName" runat="server" Text='<%#Eval("ExpenseName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Expense Type">
                <ItemTemplate>
                    <asp:Label ID="lblExpensetypeid" runat="server" Text='<%#Eval("ExpenseType")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblExpenseType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Expense Group">
                <ItemTemplate>
                    <asp:Label ID="lblExpenseGroupid" runat="server" Text='<%#Eval("ExpenseGroup")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblExpenseGroup" runat="server" Text='<%#Eval("[Group]") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false">
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
