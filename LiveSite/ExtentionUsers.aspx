<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="ExtentionUsers.aspx.cs" Inherits="ExtentionUsers" Title="User Extension" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="grdEmpDetails" runat="server" AllowPaging="true" AutoGenerateColumns="False"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="2000"
        Width="600px">
        <Columns>
            <asp:TemplateField HeaderText="Emp Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblEmpCode" runat="server" Text='<%#Eval("EmpCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Emp Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblEID" runat="server" Style="display: none;" Text='<%#Eval("EmpID") %>'></asp:Label>
                    <asp:Label ID="lblFName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                    <asp:Label ID="LblLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dept Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblDeptId" runat="server" Text='<%#Eval("DeptCode")+" :: "+Eval("DeptName") %>'
                        Style="display: none;"></asp:Label>
                    <asp:Label ID="Label26" runat="server" Text='<%#Eval("DeptName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Area" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAreaName" runat="server" Text='<%#Eval("AreaName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="City" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblCity" runat="server" Text='<%#Eval("City")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblEmailID" runat="server" Text='<%#Eval("EmailID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkisActive" runat="server" Enabled="false" Checked='<%#Eval("IsActive") %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sales Portal" HeaderStyle-HorizontalAlign="Center"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSalesPortal" data-id='<%#Eval("EmpID") %>' onclick='javascript:setActive(this,"sales");'
                        runat="server" Checked='<%#Eval("IsMobileUser") %>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
          <asp:TemplateField HeaderText="Expense" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkExpense" data-id='<%#Eval("EmpID") %>' onclick='javascript:setActive(this,"exp");'
                        runat="server" Checked='<%#Eval("IsExpenseUser") %>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <script type="text/javascript">
function setActive(me, val) {

           var id = me.parentElement.getAttribute('data-id');
               var active = me.checked;
                var strac = val + '!' + active.toString();
                AutoComplete.setExtensionActivate("extact", id, strac, function(val) {
                    if (val) {
                        if (active) { alert('Successfully activated!'); }
                        else { alert('Successfully deactivated!'); }
                        
                    } else {
                    if (active) { alert('Failed activated!'); }
                    else { alert('Failed deactivated!'); }
                   
                    }
                });
}
    </script>

</asp:Content>
