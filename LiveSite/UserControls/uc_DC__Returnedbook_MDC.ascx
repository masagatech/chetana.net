<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DC__Returnedbook_MDC.ascx.cs" Inherits="UserControls_ODC_uc_DC__Returnedbook_MDC" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
<tr>
    <td>
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
       <span runat="server" id="pageName"></span>
        Returned Book <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</td>
    <td>
        <div style="float: right; width: 50%">
         <div id="filter" runat="server">
            <span>Filter Data:</span>
            <input name="filt" onkeyup="filter(this, 'sf', '<%=GrdCustview.ClientID%>')" type="text">
         </div>
         </div>
    </td>
</tr>
</div> 
<p></p>
<asp:Panel ID="PnlCustview" runat="server" Width="900px">
    <asp:GridView ID="GrdCustview" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" 
       CellPadding="4" CssClass="product-table" onrowediting="Grdcustview_RowEditing" > 
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Customer Code">
                <ItemTemplate>
                    <asp:Label ID="lblCustID1" runat="server" Style="display: none;" 
                        Text='<%#Eval("CustID") %>'></asp:Label>
                    <asp:Label ID="lblCustCode1" runat="server" Text='<%#Eval("CustCode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Customer Name">
                <ItemTemplate>
                    <asp:Label ID="lblCustName1" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="280px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Area">
                <ItemTemplate>
                    <asp:Label ID="lblArea1" runat="server" Text='<%#Eval("AreaName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="City">
                <ItemTemplate>
                    <asp:Label ID="lblCity1" runat="server" Text='<%#Eval("City")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Manually"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblManually1" runat="server" Style="text-align: right;" 
                        Text='<%#Eval("Manually")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="DC" 
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblDC1" runat="server" Style="text-align: right;" 
                        Text='<%#Eval("DC") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" 
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblView1" runat="server" CausesValidation="false" ToolTip ="View"
                        CommandName="Edit" CssClass="close" 
                        ImageUrl="../../Images/icon/view-icon.gif"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<p></p>
<asp:Panel ID="Pnl4" runat="server" Width="900px">
    <asp:Panel ID="Pnl4CustDetails"  runat="server" Width="863px">
    <table width="600px" border="0" cellpadding="2" cellspacing="2">
      <tr>
        <td>
            <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="Customer Name:" Width="110px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbl4CustName" runat="server" CssClass="lbl-form" Width="500px" Font-Bold></asp:Label>
        </td>
      </tr>
       <tr>
        <td>
            <asp:Label ID="Label7" runat="server" CssClass="lbl-form" Text="Customer Address:" Width="110px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbl4CustAddress" runat="server" CssClass="lbl-form" Width="550px" Font-Bold></asp:Label>
        </td>
       </tr>
    </table>
 </asp:Panel>
<p></p> 
    <asp:GridView ID="Grd4" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" onrowediting="Grd4_RowEditing" >
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Book Code">
                <ItemTemplate>
                    <asp:Label ID="lbl4custcode" runat="server" Style="display: none;" Text='<%#Eval("CustCode")%>'></asp:Label>
                    <asp:Label ID="lbl4bkcode" runat="server" Text='<%#Eval("bookcode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Name">
                <ItemTemplate>
                    <asp:Label ID="lbl4Name" runat="server" Text='<%#Eval("bookname")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Returned Qty" 
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lbl4rtqty" runat="server" Style="text-align: right;" Text='<%#Eval("ReturnQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" 
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lbl4Edit" runat="server" CausesValidation="false" ToolTip ="View"
                        CommandName="Edit" CssClass="close" ImageUrl="../../Images/icon/view-icon.gif"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<p></p>
<asp:Panel ID="Pnl5" runat="server" Width="900px">
 <asp:Panel ID="Pnl5CustDetails"  runat="server" Width="863px">
    <table width="600px" border="0" cellpadding="2" cellspacing="2">
      <tr>
        <td>
            <asp:Label ID="Label10" runat="server" CssClass="lbl-form" Text="Customer Name:" Width="110px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbl5CustName" runat="server" CssClass="lbl-form" Width="500px" Font-Bold></asp:Label>
        </td>
      </tr>
       <tr>
        <td>
            <asp:Label ID="Label12" runat="server" CssClass="lbl-form" Text="Customer Address:" Width="110px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbl5CustAddress" runat="server" CssClass="lbl-form" Width="550px" Font-Bold></asp:Label>
        </td>
       </tr>
    </table>
 </asp:Panel>
<p></p> 
 <asp:GridView ID="Grd5" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" onrowediting="Grd5_RowEditing" >
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Book Code">
                <ItemTemplate>
                    <asp:Label ID="lbl5custcode" runat="server" Style="display: none;" Text='<%#Eval("CustCode")%>'></asp:Label>
                    <asp:Label ID="lbl5bkcode" runat="server" Text='<%#Eval("bookcode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Name">
                <ItemTemplate>
                    <asp:Label ID="lbl5Name" runat="server" Text='<%#Eval("bookname")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Returned Qty" 
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lbl5rtqty" runat="server" Style="text-align: right;" Text='<%#Eval("ReturnQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" 
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lbl5Edit" runat="server" CausesValidation="false" ToolTip ="View"
                        CommandName="Edit" CssClass="close" ImageUrl="../../Images/icon/view-icon.gif"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<p></p>
<asp:Panel ID="Pnlview" runat="server" Width="900px">
    <asp:Panel ID="PnlBkdetails"  runat="server" Width="863px">
    <table width="600px" border="0" cellpadding="2" cellspacing="2">
      <tr>
        <td>
            <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Book Code" Width="60px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbbkcode1" runat="server" CssClass="lbl-form" Width="200px" Font-Bold></asp:Label>
        </td>
      </tr>
       <tr>
        <td>
            <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="Book Name" Width="60px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbName1" runat="server" CssClass="lbl-form" Width="380px" Font-Bold></asp:Label>
        </td>
       </tr>
    </table>
 </asp:Panel>
<p></p> 
    <asp:GridView ID="GrdView" CellPadding="4" Width="900px" AlternatingRowStyle-CssClass="alt"
        CssClass="product-table" AutoGenerateColumns="false" runat="server" >
        <Columns>
            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lbdt" Style="text-align: right;" runat="server" Text='<%#Eval("CreatedOn") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="60px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Returned By" HeaderStyle-Width="160px" ItemStyle-HorizontalAlign="left">
                <ItemTemplate>
                    <asp:Label ID="lbrtby" Style="text-align: right;" runat="server" Text='<%#Eval("CreatedBy") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="160px"></HeaderStyle>
            </asp:TemplateField>
        
            <asp:TemplateField HeaderText="Returned Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lbbkcode" runat="server" Style="display: none;" Text='<%#Eval("Bookcode")%>'></asp:Label>
                    <asp:Label ID="lbrtqt" Style="text-align: right;" runat="server" Text='<%#Eval("ReturnQty") %>'
                         class='<%#Eval("classReturnMDC")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Comment" HeaderStyle-Width="100px" >
                <ItemTemplate>
                    <asp:TextBox ID="txt2cmmt" CssClass="inp-form" Width="550px" Height="30px" runat="server"
                        TextMode="MultiLine" Enabled="false" Text='<%#Eval("Comment") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<p></p>
<%--<asp:Panel ID="Pnl4view" runat="server" Width="900px">
    <asp:Panel ID="Pnl4Bkdetails"  runat="server" Width="863px">
    <table width="600px" border="0" cellpadding="2" cellspacing="2">
      <tr>
        <td>
            <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="Book Code" Width="60px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lb4bkcode" runat="server" CssClass="lbl-form" Width="200px" Font-Bold></asp:Label>
        </td>
      </tr>
       <tr>
        <td>
            <asp:Label ID="Label9" runat="server" CssClass="lbl-form" Text="Book Name" Width="60px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lb4Name" runat="server" CssClass="lbl-form" Width="380px" Font-Bold></asp:Label>
        </td>
       </tr>
    </table>
 </asp:Panel>
<p></p> 
    <asp:GridView ID="Grd4View" CellPadding="4" Width="400px" AlternatingRowStyle-CssClass="alt"
        CssClass="product-table" AutoGenerateColumns="false" runat="server" >
        <Columns>
            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lb4dt" Style="text-align: right;" runat="server" Text='<%#Eval("CreatedOn") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="40px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Returned By" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="left">
                <ItemTemplate>
                    <asp:Label ID="lb4bkcode" runat="server" Style="display: none;" Text='<%#Eval("Bookcode")%>'></asp:Label>
                    <asp:Label ID="lb4rtby" Style="text-align: right;" runat="server" Text='<%#Eval("CreatedBy") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="120px"></HeaderStyle>
            </asp:TemplateField>
        
            <asp:TemplateField HeaderText="Returned Qty" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lb4rtqt" Style="text-align: right;" runat="server" Text='<%#Eval("ReturnQty") %>'
                    class='<%#Eval("classReturnMDC")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="40px"></HeaderStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>--%>