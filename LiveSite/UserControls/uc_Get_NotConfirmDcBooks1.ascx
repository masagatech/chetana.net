<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Get_NotConfirmDcBooks1.ascx.cs"
    Inherits="UserControls_uc_Get_NotConfirmDcBooks" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Transaction > Specimen > BookWise<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<div class="actiontab">
    <table width="700px" border="0" cellpadding="2" cellspacing="2">
        <tr>
            
            <td align="right">
                <asp:Button ID="btnDocWice" CssClass="submitbtn" Width="100px" runat="server" Text="Document Wise"
                    OnClick="btnDocWice_Click" />
                <asp:Button ID="btnBookWice" Visible="false" CssClass="submitbtn" Width="100px" runat="server"
                    Text="BookWise" OnClick="btnBookWice_Click" />
            </td>
        </tr>
    </table>
</div>
<asp:GridView AlternatingRowStyle-CssClass="alt" CellPadding="4" AutoGenerateColumns="false"
    Width="700px" CssClass="product-table" ID="grdGetNotConfirmedBooks" runat="server">
    <Columns>
        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Book Code">
            <ItemTemplate>
                <label>
                    <%#Eval("BookCode")%></label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Book Name">
            <ItemTemplate>
                <label>
                    <%#Eval("BookName")%></label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Medium">
            <ItemTemplate>
                <label>
                    <%#Eval("Medium")%></label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Publisher">
            <ItemTemplate>
                <label>
                    <%#Eval("Publisher")%></label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Right" HeaderText="QTY">
            <ItemTemplate>
                <label>
                    <%#Eval("Quantity")%></label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
