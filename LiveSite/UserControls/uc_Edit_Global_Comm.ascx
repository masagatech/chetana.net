<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Edit_Global_Comm.ascx.cs" Inherits="UserControls_uc_Edit_Global_Comm" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<style type="text/css">
    .style1 {
        width: 88px;
    }
</style>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>

<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Edit Global Commission <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="PnllGrdComm" runat="server" Width="900px">
            <div class="actiontab" style="margin-bottom: 6px; width: 940px;">
                <table align="right" border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;">
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label1" runat="server" Text="CN Per :"></asp:Label></td>
                        <td align="right" width="80px">
                            <asp:TextBox ID="txtcnper" runat="server" Width="80px" MaxLength="14"></asp:TextBox>
                        </td>
                        <td align="right" width="80px"></td>
                        <td align="right" width="80px"></td>
                        <td align="right" width="80px"></td>
                        <td align="right" width="80px"></td>
                        <td align="right" width="80px"></td>
                        <td align="right" width="80px"></td>
                        <td align="right" width="80px"></td>
                        <td align="right" width="80px"></td>
                        <td align="right" width="80px"></td>
                        <td align="left" width="80px">
                            <asp:Button ID="btnUpdate" CssClass="submitbtn" TabIndex="10" runat="server" Text="Update"
                                Width="75px" ValidationGroup="Comm" OnClick="btnUpdate_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:GridView ID="GrdComm" runat="server" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
                    AutoGenerateColumns="false" CellPadding="4" CssClass="product-table" ShowHeader="true">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="AutoId"
                            ItemStyle-HorizontalAlign="Left" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbl1" runat="server" Width="100px" Text='<%#Eval("AutoId")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Superzone"
                            ItemStyle-HorizontalAlign="Left" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblszone" runat="server" Width="100px" Text='<%#Eval("Superzoneid")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Zone"
                            ItemStyle-HorizontalAlign="Left" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblzone" runat="server" Width="100px" Text='<%#Eval("Zoneid")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Dis.From" ItemStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:TextBox ID="TxtDisF" runat="server" AutoPostBack="True" CssClass="inp-form" MaxLength="14"
                                    onkeypress="return CheckNumeric(event)" Style="text-align: right;" Width="90px"
                                    Text='<%#Eval("discfromamt","{0:0.00}")%>'>
                                </asp:TextBox>
                                <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" FilterType="Numbers, Custom" TargetControlID="TxtDisF" ValidChars="." />
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Dis.To"
                            ItemStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:TextBox ID="txtdisTo" runat="server" CssClass="inp-form" MaxLength="14"
                                    Style="text-align: right;" Width="90px" Text='<%#Eval("disctoamt","{0:0.00}")%>'> </asp:TextBox>
                                <ajaxCt:FilteredTextBoxExtender ID="filter5" runat="server"
                                    FilterType="Custom, Numbers" TargetControlID="txtdisTo" ValidChars="." />
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Tar.From"
                            ItemStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:TextBox ID="txttarfrm" runat="server" CssClass="inp-form" MaxLength="14"
                                    Style="text-align: right;" Width="90px" Text='<%#Eval("targperfrom","{0:0.00}")%>'>
                                </asp:TextBox>
                                <ajaxCt:FilteredTextBoxExtender ID="filter6" runat="server"
                                    FilterType="Custom, Numbers" TargetControlID="txttarfrm" ValidChars="." />
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Tar.To">
                            <ItemTemplate>
                                <asp:TextBox ID="txttarto" runat="server" CssClass="inp-form" MaxLength="14"
                                    Style="text-align: right;" Width="90px"
                                    Text='<%#Eval("targperto","{0:0.00}")%>'>
                                </asp:TextBox>
                                <ajaxCt:FilteredTextBoxExtender ID="filter7" runat="server"
                                    FilterType="Custom, Numbers" TargetControlID="txttarto" ValidChars="." />
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Zone.Comm">
                            <ItemTemplate>
                                <asp:TextBox ID="txtzcomm" runat="server" CssClass="inp-form" MaxLength="14"
                                    Style="text-align: right;" Width="90px"
                                    Text='<%#Eval("zoneprcent","{0:0.00}")%>'>
                                </asp:TextBox>
                                <ajaxCt:FilteredTextBoxExtender ID="filter3" runat="server"
                                    FilterType="Custom, Numbers" TargetControlID="txtzcomm" ValidChars="." />
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Superzone.Comm">
                            <ItemTemplate>
                                <asp:TextBox ID="txtscomm" runat="server" CssClass="inp-form" MaxLength="14"
                                    Style="text-align: right;" Width="90px"
                                    Text='<%#Eval("superzoneprcent","{0:0.00}")%>'>
                                </asp:TextBox>
                                <ajaxCt:FilteredTextBoxExtender ID="filter4" runat="server"
                                    FilterType="Custom, Numbers" TargetControlID="txtscomm" ValidChars="." />
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="SuperDuperzone.Comm">
                            <ItemTemplate>
                                <asp:TextBox ID="txtsdzcomm" runat="server" CssClass="inp-form" MaxLength="14"
                                    Style="text-align: right;" Width="90px"
                                    Text='<%#Eval("sdzonepercent","{0:0.00}")%>'>
                                </asp:TextBox>
                                <ajaxCt:FilteredTextBoxExtender ID="fltsdzcomm" runat="server"
                                    FilterType="Custom, Numbers" TargetControlID="txtsdzcomm" ValidChars="." />
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Active">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkActive" runat="server"
                                    Checked='<%# Eval("IsActive").ToString() == "True" ? true : false %>' />
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle CssClass="alt" />
                </asp:GridView>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>



