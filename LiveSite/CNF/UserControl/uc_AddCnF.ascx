<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_AddCnF.ascx.cs" Inherits="CNF_UserControl_uc_AddCnF" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <%--<asp:Panel ID="pnlra" runat="server">
        <div style="float: right; width: 58%">
            <div id="filter" runat="server">
                <span>Filter Data:</span>
                <input name="filt" onkeyup="filter(this, 'sf', '<%=grdCustDetails.ClientID%>')" type="text">
            </div>
        </div>
    </asp:Panel>--%>
    <div class="options">
    </div>
</div>
<div style="float: right; width: 46%;">
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="8" runat="server" Text="Save"
        Width="70px" OnClick="btnSave_Click" ValidationGroup="ct" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ct"
        ShowMessageBox="true" ShowSummary="false" />
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
</div>
<br />
<br />
<asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Width="642px">
    <table>
        <tr>
            <td width="100px">
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="CnF Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="180px">
                <asp:TextBox ID="TxtCnFCode" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter CnF code"
                    ControlToValidate="TxtCnFCode" ValidationGroup="ct">.</asp:RequiredFieldValidator>
            </td>
            <td width="100px">
                <asp:Label ID="LblCnFId" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
                <asp:Label ID="Label16" runat="server" CssClass="lbl-form" Text=" Name "></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="180px">
                <asp:TextBox ID="TxtCnFName" CssClass="inp-form" TabIndex="2" runat="server" Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter CnF Name"
                    ControlToValidate="TxtCnFName" ValidationGroup="ct">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="100px">
                <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="Address"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="TxtAddress" runat="server" Height="50px" CssClass="inp-form" TabIndex="3"
                    TextMode="MultiLine" Width="330px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Address"
                    ControlToValidate="TxtAddress" ValidationGroup="ct">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" CssClass="lbl-form" Text="Contact Person"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Txtcp" runat="server" CssClass="inp-form" TabIndex="4" Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Contact Person"
                    ControlToValidate="Txtcp" ValidationGroup="ct">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Mobile"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtmobile" runat="server" CssClass="inp-form" TabIndex="5" Width="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="inp-form" TabIndex="6" Width="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label18" runat="server" CssClass="lbl-form" Text="Super Zone"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:CheckBoxList ID="DDLsuperzone" runat="server" CssClass="ddl-form" TabIndex="7" DataTextField="SuperZoneName"
                    DataValueField="SuperZoneID">
                </asp:CheckBoxList>
                
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlCnFDetails" runat="server">
    <asp:GridView ID="grdCnFDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" OnRowDeleting="grdCnFDetails_RowDeleting"
        OnRowEditing="grdCnFDetails_RowEditing" AlternatingRowStyle-CssClass="alt" PageSize="800"
        Width="600px">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="CnF Code" HeaderStyle-Width="100px"
                ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblCnFID" runat="server" Style="display: none" Text='<%#Eval("CnFID")%>'></asp:Label>
                    <asp:Label ID="lblCnFCode" runat="server" Text='<%#Eval("CnFCode") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CnF Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblCnFname" runat="server" Text='<%#Eval("CnFname")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mobile" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("Mobile")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Contact Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                   
                    <asp:Label ID="lplcperson"  runat="server" Text='<%#Eval("ContactPersonName")%>'></asp:Label>
                    <asp:Label ID="lbladdress" Style="display: none" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                    <asp:Label ID="lblSZoneId" Style="display: none" runat="server" Text='<%#Eval("SuperZoneId")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email Id" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblemail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../../Images/icon/edit_icon.png" />
                   <%-- <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />--%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
