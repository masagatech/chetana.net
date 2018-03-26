<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CnFCreateLogin.ascx.cs"
    Inherits="CNF_UserControl_uc_CnFCreateLogin" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <asp:Panel ID="pnlra" runat="server">
        <div style="float: right; width: 58%">
            <div id="filter" runat="server">
                <%--<span>Filter Data:</span>--%>
                <%--<input name="filt" onkeyup="filter(this, 'sf', '<%=grdCustDetails.ClientID%>')" type="text">--%>
            </div>
        </div>
    </asp:Panel>
    <div class="options">
    </div>
</div>
<div style="float: right; width: 71%;">
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="4" runat="server" Text="Save"
        Width="70px" ValidationGroup="ct" OnClick="btnSave_Click" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ct"
        ShowMessageBox="true" ShowSummary="false" />
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
</div>
<br />
<br />
<asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Width="360px">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text=" CnF"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="ddlCnF" runat="server" TabIndex="1" DataTextField="cnfname"
                    DataValueField="cnfid" Width="150px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0"
                    ErrorMessage="select CnF" ControlToValidate="ddlCnF" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                <asp:Label ID="Label5" runat="server" Text="Label" Style="display: none"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100px">
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="User Id"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="180px">
                <asp:TextBox ID="txtuserid" CssClass="inp-form" TabIndex="2" runat="server" Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter User Id"
                    ControlToValidate="txtuserid" ValidationGroup="ct">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="100px">
                <asp:Label ID="LblCnFId" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
                <asp:Label ID="Label16" runat="server" CssClass="lbl-form" Text=" Password"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="180px">
                <asp:TextBox ID="Txtpassword" CssClass="inp-form" TabIndex="3" runat="server" TextMode="Password"
                    Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Password"
                    ControlToValidate="Txtpassword" ValidationGroup="ct">.</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlLoginDetails" runat="server">
    <asp:GridView ID="grdCnFLogin" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" OnRowDeleting="grdCnFLogin_RowDeleting"
        OnRowEditing="grdCnFLogin_RowEditing" AlternatingRowStyle-CssClass="alt" PageSize="800"
        Width="600px">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="User Name" HeaderStyle-Width="100px"
                ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAutoID" runat="server" Style="display: none" Text='<%#Eval("AutoId")%>'></asp:Label>
                    <asp:Label ID="lblUsername" runat="server" Text='<%#Eval("EmpID") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CnF Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblCnFname" runat="server" Text='<%#Eval("CnFname")%>'></asp:Label>
                    <asp:Label ID="lblCnfid" Style="display: none" runat="server" Text='<%#Eval("CnFId")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Password" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblpassword" runat="server" Text='<%#Eval("Password")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../../Images/icon/edit_icon.png" />
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
