<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Get_NotConfirmDcBooks.ascx.cs"
    Inherits="UserControls_uc_Get_NotConfirmDcBooks" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
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
                    Text="BookWise" OnClick="btnBookWice_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnPrint" CommandArgument='<%#Eval("DocumentNo")%>' 
                                                runat="server" Text="Print" Style="float: right;" CssClass="submitbtn"
                                                ToolTip="click to print" onclick="btnPrint_Click" />
            </td>
        </tr>
    </table>
</div>
<asp:GridView AlternatingRowStyle-CssClass="alt" CellPadding="4" AutoGenerateColumns="false" ShowFooter="true"
    Width="700px" CssClass="product-table" ID="grdGetNotConfirmedBooks" 
    runat="server" onrowdatabound="grdGetNotConfirmedBooks_RowDataBound">
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
        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Standard">
            <ItemTemplate>
                <label>
                    <%#Eval("Standard")%></label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Medium" FooterStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <label>
                    <%#Eval("Medium")%></label>
            </ItemTemplate>
            <FooterTemplate>
          <asp:Label ID="lblTotal" align="right"  runat="server" Text="Total :"></asp:Label>
              </FooterTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" HeaderText="QTY">
            <ItemTemplate>
                <asp:Label ID="lblqunty" runat="server"
                   Text='<%#Eval("Quantity")%>'> </asp:Label>
            </ItemTemplate>
            <FooterTemplate>
          <asp:Label ID="lblTotalQty" align="right"  runat="server" Text=""></asp:Label>
              </FooterTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
