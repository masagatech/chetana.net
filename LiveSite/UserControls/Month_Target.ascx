<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Month_Target.ascx.cs"
    Inherits="Godown_Month_Target" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Month Target<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<br />
<br />
<div style="padding-left: 483px; padding-bottom: 7px;">
    <asp:Button ID="btnSave" runat="server" CssClass="submitbtn" Text="Save" Width="75"
        OnClick="btnSave_Click" />
</div>
<asp:Panel ID="pnlradio" CssClass="panelDetails" runat="server" Width="520px">
 <asp:GridView ID="grdTarget" runat="server" AutoGenerateColumns="false" CellPadding="0" CssClass="product-table"
       RowStyle-HorizontalAlign="Center" CellSpacing="0">
        <Columns>
            <asp:TemplateField HeaderText="Month">
                <ItemTemplate>
                <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("Month") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Target">
                <ItemTemplate>
                <asp:TextBox ID="txtTarget" runat="server" Text='<%#Eval("Target") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
