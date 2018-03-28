<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Specimen_DashboardDetails.aspx.cs" Inherits="Specimen_DashboardDetails"
    Title="Chetana : Dashboard Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
         <asp:Label ID="lblqstring" runat="server" style="font-size:12px;"></asp:Label> <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
    <div id="filter"  runat="server" style="width: 27%; text-align: right;">
    <%--<asp:Button ID="btnEdit" CssClass="submitbtn" Width="80px" runat="server" Text="Back" PostBackUrl="/Website/SpecimenReport_Dashboard.aspx?"
                ></asp:Button>--%>
        <span>Filter Data:</span>
        <input name="filt" id="find"  onkeyup="filter(this, 'sf', '<%=grdEmployeedetails.ClientID%>')" type="text" />
    </div>
     
    <br />
    <asp:Panel ID="pnlDetails" runat="server">
    <%--<asp:Label ID="lblqstring" runat="server" style="font-size:12px;"></asp:Label>--%>
    
    <asp:GridView ID="grdEmployeedetails" runat="server" AutoGenerateColumns="false" PageSize="200"
        CssClass="product-table" AlternatingRowStyle-CssClass="alt" Width="300px" Style="margin-right: 0px">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Employee Name" ItemStyle-HorizontalAlign="left">
                <ItemTemplate>
                      <asp:Label ID="lblempname" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px" HeaderText="Details" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lbldetails" runat="server" Text='<%#Eval("Number")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="20px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
          </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lblEmpty" runat="server" CssClass="headings" Text="No data available"
                Visible="<%#bool.Parse((grdEmployeedetails.Rows.Count==0).ToString()) %>"></asp:Label>
        </EmptyDataTemplate>
        <AlternatingRowStyle CssClass="alt" />
    </asp:GridView>
    <script type="text/javascript">
      shortcut.add("Ctrl+F",function() { document.getElementById('find').focus(); });
          setTimeout("setSatus()",2000);
          function setSatus()
          {
             var status="[ Ctrl+F : Find ]";
             document.getElementById('status').innerHTML=status;
          }
        </script>
     
     </asp:Panel>
     
     
</asp:Content>

