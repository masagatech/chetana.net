<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_BranchMaster.ascx.cs"
    Inherits="UserControls_uc_BranchMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
        </a>
    &nbsp;&nbsp;&nbsp;
    </div>
    <div class="options">
        <div id="filter" runat="server">
            <span>Filter Data:</span>
            <input name="filt" onkeyup="filter(this, 'sf', '<%=grdBranchDetails.ClientID%>')"
                type="text"></div>
    </div>
</div>
<div style="float: right; width: 70%">
    <asp:Button ID="btnsave" CssClass="submitbtn" runat="server" Text="Save" ValidationGroup="Branch"
        Width="80px" OnClick="btnsave_Click" TabIndex="50" />
    <%-- </ContentTemplate>--%>
</div>
<br />
<br />
<asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Width="450px">
    <table width="70%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="lblBranchId" CssClass="lbl-form" runat="server" Style="display: none;"  Text="0" />                
                <asp:Label ID="lblBranchcode" CssClass="lbl-form" runat="server" Text="Branch Code" />
                 <font color="red">*</font>
            </td>
            <td>
               <%-- <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="txtbranchCode" CssClass="inp-form" runat="server"
                            Width="82px" Style="margin-left: 12px" MaxLength="20" 
                    TabIndex="5" ></asp:TextBox>
                <%--        </td>
                        <td>--%>
                            <asp:RequiredFieldValidator ID="reqBcode" runat="server" ErrorMessage="Require Branch Code"
                                ValidationGroup="Branch" ControlToValidate="txtbranchCode">*</asp:RequiredFieldValidator>
                   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
    
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBname" CssClass="lbl-form" runat="server" Text="Branch Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtbranchName"  AutoPostBack="True" CssClass="inp-form" 
                            runat="server" Width="186px"
                            Style="margin-left: 11px" ontextchanged="txtbranchName_TextChanged" 
                            MaxLength="100" TabIndex="10"  ></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="ReqbName" runat="server" ErrorMessage="Require Branch Name"
                                ValidationGroup="Branch" ControlToValidate="txtbranchName">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBdesc" CssClass="lbl-form" runat="server" Text="Branch Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtbranchAddress" CssClass="inp-form" runat="server" TextMode="MultiLine"
                    Width="188px" Style="margin-left: 11px" MaxLength="500" TabIndex="15"></asp:TextBox>
            </td>
        </tr>
        <%-- <tr>
      <td>
        <asp:Label ID="lblcountry" CssClass="lbl-form" runat="server" Text="Country"></asp:Label>
        <font color="red">*</font>
      </td>
      <td>
        <asp:TextBox ID="txtcountry" CssClass="inp-form" runat="server" Width="186px" Style="margin-left: 11px"></asp:TextBox>
      </td>
      <td>
        <asp:RequiredFieldValidator ID="Reqcontry" runat="server" ErrorMessage="Require Country"
          ValidationGroup="Branch" ControlToValidate="txtcountry">*</asp:RequiredFieldValidator>
      </td>
    </tr>--%>
        <tr>
            <td>
                <asp:Label ID="lblstate" CssClass="lbl-form" runat="server" Text="State"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="DDLstate" runat="server" Width="150px"
                    Style="margin-left: 11px" DataValueField="DMID" DataTextField="Name" AutoPostBack="true"
                    OnSelectedIndexChanged="DDLstate_SelectedIndexChanged" TabIndex="20">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblcity" CssClass="lbl-form" runat="server" Text="City"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLCity" runat="server" Width="110px" Style="margin-left: 11px"
                            Enabled="false" DataValueField="DMID" DataTextField="Name" TabIndex="25">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLstate" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblchek" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="chekactive" runat="server" Checked="true" TabIndex="30" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlBranch" runat="server">
    <asp:GridView ID="grdBranchDetails" AutoGenerateColumns="false" AllowPaging="true"
        PageSize="10" CellPadding="4" CssClass="product-table" ForeColor="#333333" Width="600px"
        runat="server" OnPageIndexChanging="grdBranchDetails_PageIndexChanging" OnRowEditing="grdBranchDetails_RowEditing"
        OnRowDeleting="grdBranchDetails_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Branch Name" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblBranchID" runat="server" Style="display: none;" Text='<%#Eval("BranchID")%>'></asp:Label>
                    <asp:Label ID="lblBranchCode" runat="server"  Style="display: none;" Text='<%#Eval("BranchCode")%>'></asp:Label>
                    <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("BranchName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Branch Address" HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                     <asp:Label ID="lblBranchAddress" runat="server" Text='<%#Eval("BranchAddress") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkactive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false">
                    </asp:CheckBox>
                   
                    <%--<asp:Label ID="lblcountry" runat="server" Style="display: none;" Text='<%#Eval("Country") %>'></asp:Label>--%>
                    <asp:Label ID="lblstate" runat="server" Style="display: none;" Text='<%#Eval("State") %>'></asp:Label>
                    <asp:Label ID="lblcity" runat="server" Style="display: none;" Text='<%#Eval("City") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Are u sure u wat to Delete?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>

<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Branch" runat="server" ID="ss" />

<script type="text/javascript">
    setTimeout("setSatus()", 2000);
    function setSatus() {
        var status = "[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
        document.getElementById('status').innerHTML = status;
    }
</script>

<script type="text/javascript">

    shortcut.add("Ctrl+S", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_BranchMaster1_btnsave').click();
    });

    shortcut.add("Ctrl+F", function () {
        document.getElementById('filterdata').focus();
    });

</script>
