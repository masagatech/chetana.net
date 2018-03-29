<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_View_Global_Comm.ascx.cs" Inherits="UserControls_uc_View_Global_Comm" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>

<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        View Global Commission <a href="Campaigns.aspx" title="back to campaign list"></a>
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
                        <td align="right" width="80px"></td>
                    </tr>
                </table>
                <asp:Label ID="Label1" runat="server" Text="CN Per :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtcnper" runat="server" MaxLength="14" Enabled="false" Width="78px"></asp:TextBox>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:GridView ID="GrdComm" runat="server" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
    AutoGenerateColumns="false" CellPadding="4" CssClass="product-table"
    ShowHeader="true">
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
                <asp:Label ID="lblszone" runat="server" Width="100px"
                    Text='<%#Eval("Superzoneid")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Zone"
            ItemStyle-HorizontalAlign="Left" Visible="false">
            <ItemTemplate>
                <asp:Label ID="lblzone" runat="server" Width="80px" Text='<%#Eval("Zoneid")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Dis.From"
            ItemStyle-HorizontalAlign="right">
            <ItemTemplate>
                <asp:Label ID="lblDisF" runat="server" Width="50px" Text='<%#Eval("discfromamt","{0:0.00}")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="80px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Dis.To" ItemStyle-HorizontalAlign="right">
            <ItemTemplate>
                <asp:Label ID="lblDisTo" runat="server" Width="50px" Text='<%#Eval("disctoamt","{0:0.00}")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="80px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Tar.From" ItemStyle-HorizontalAlign="right">
            <ItemTemplate>
                <asp:Label ID="lblTarFrm" runat="server" Width="50px" Text='<%#Eval("targperfrom","{0:0.00}")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Tar.To" ItemStyle-HorizontalAlign="right">
            <ItemTemplate>
                <asp:Label ID="lblTarTo" runat="server" Width="50px" Text='<%#Eval("targperto","{0:0.00}")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Zone.Comm" ItemStyle-HorizontalAlign="right">
            <ItemTemplate>
                <asp:Label ID="lblZComm" runat="server" Width="50px" Text='<%#Eval("zoneprcent","{0:0.00}")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Superzone.Comm" ItemStyle-HorizontalAlign="right">
            <ItemTemplate>
                <asp:Label ID="lblSComm" runat="server" Width="50px" Text='<%#Eval("superzoneprcent","{0:0.00}")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="50px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px" HeaderText="SuperDuperzone.Comm" ItemStyle-HorizontalAlign="right">
            <ItemTemplate>
                <asp:Label ID="lblSDZComm" runat="server" Width="50px" Text='<%#Eval("sdzonepercent","{0:0.00}")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="50px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Active" ItemStyle-HorizontalAlign="center">
            <ItemTemplate>
                <asp:CheckBox ID="chkActive" runat="server" Enabled="false" Checked='<%# Eval("IsActive").ToString() == "True" ? true : false %>' />
            </ItemTemplate>
            <HeaderStyle Width="80px" />
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle CssClass="alt" />
</asp:GridView>




