<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CustomerByEmployee.ascx.cs"
    Inherits="UserControls_uc_CustomerByEmployee" %>
<asp:GridView ID="grdCustomerDetails" runat="server" AutoGenerateColumns="false" CssClass="product-table"
 AlternatingRowStyle-CssClass="alt"
     >
    <Columns>
        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Book Code" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <asp:Label ID="lblBookcode" runat="server" Text='<%#Eval("CustCode")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Book Name" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <asp:Label ID="lblBookname" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
