<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SetOfBook.ascx.cs"
    Inherits="UserControls_uc_SetOfBook" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>Add/Edit Set Of Book Details <a href="Campaigns.aspx"
            title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <div style="float: left; width: 66%">
            <div style="float: right">
                <asp:Button ID="BtnSave" CssClass="submitbtn" runat="server" Text="Save" Width="80px"
                    TabIndex="5" Visible="false" OnClick="BtnSave_Click" />
                <asp:Button ID="BtnCancel" Width="70px" CssClass="submitbtn" runat="server" Text="Cancel"
                    Style="display: none" OnClick="BtnCancel_Click" /></div>
        </div>
        <br />
        <br />
        <asp:Panel ID="Pnlsetbook" CssClass="panelDetails" runat="server" Width="700px">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="110px">
                        <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="BookSet Name"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSet" runat="server" DataTextField="Value"
                            Width="300px" TabIndex="1" DataValueField="AutoId" AutoPostBack="true" OnSelectedIndexChanged="DDLSet_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="Rqfddlset" runat="server" ErrorMessage="Select Book Set"
                            InitialValue="0" ValidationGroup="set" ControlToValidate="DDLSet">.</asp:RequiredFieldValidator>
                    </td>
                    <asp:Panel runat="server" ID="Panel1">
                        <td>
                            <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Book Code"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td>
                            <asp:Panel runat="server" ID="pnlbook" DefaultButton="btnadd">
                                <asp:TextBox ID="txtbkcod" autocomplete="off" TabIndex="2" CssClass="inp-form" runat="server"
                                    OnTextChanged="txtbkcod_TextChanged" Width="150px"></asp:TextBox>
                                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtbkcod"
                                    WatermarkText="Enter BookCode to add  ">
                                </ajaxCt:TextBoxWatermarkExtender>
                                <div id="divwidth" class="divauto">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                    ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                    ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbkcod"
                                    UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
                                </ajaxCt:AutoCompleteExtender>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="reqBcode" runat="server" ErrorMessage="Select Book "
                                ValidationGroup="set" ControlToValidate="txtbkcod">.</asp:RequiredFieldValidator>
                        </td>
                    </asp:Panel>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="ChekActive" runat="server" Checked="true" Text="Active" Style="display: none" />
                    </td>
                    <td>
                        <asp:Button ID="btnadd" CssClass="submitbtn" runat="server" Text="ADD" Width="80px"
                            Style="display: none;" TabIndex="3" ValidationGroup="set" OnClick="btnadd_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="BtnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnadd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DDLSet" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
<br />
<table>
    <tr>
        <td>
            <asp:UpdatePanel ID="UpanelDDL" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <div style="float: right; width: 16%">
                        <asp:Button ID="btnprint" CssClass="submitbtn" runat="server" Text="Print" Width="80px"
                            TabIndex="45" OnClick="btnprint_Click" />
                    </div>
                    <br />
                    <br />
                    <asp:GridView ID="grdBooksetDetails" CssClass="product-table" AutoGenerateColumns="False"
                        TabIndex="4" Width="500px" runat="server" OnRowDeleting="grdBooksetDetails_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblBookCode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Book Name" HeaderStyle-Width="350px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                                    <asp:Label ID="lblquty" runat="server" Text="1" Style="display: none;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="STD" HeaderStyle-Width="350px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblstandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SellingPrice" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSellingprice" runat="server" Width="60px" Style="text-align: right"
                                        Text='<%#Eval ("SellingPrice","{0:0.00}")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OMPrice" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOMPrice" runat="server" Width="60px" Style="text-align: right"
                                        Text='<%#Eval ("OMPrice","{0:0.00}")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnRemove" ImageUrl="~/Images/icon/DeleteIcon.gif" CommandName="delete"
                                        OnClientClick="return confirm('Are you sure want to remove this book');" runat="server" />
                                    <asp:Label ID="lblBSDetailId" runat="server" Text='<%#Eval("BookSetDetailId")%>'
                                        Style="display: none;"></asp:Label>
                                    <asp:Label ID="lblBookset" Style="display: none;" runat="server" Text='<%#Eval("BookSet")%>'></asp:Label>
                                    <asp:Label ID="lblBooksetid" runat="server" Text='<%#Eval("BooksetID")%>' Style="display: none;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BtnSave" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnadd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="DDLSet" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="set"
    runat="server" ID="ss" />
