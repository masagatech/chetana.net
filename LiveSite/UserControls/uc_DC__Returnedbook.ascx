<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DC__Returnedbook.ascx.cs" Inherits="UserControls_ODC_uc_DC__Returnedbook" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
       <span runat="server" id="pageName"></span>
        Returned Book <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div> 
 <p></p>

<p></p>
<asp:Panel ID="Pnl1" CssClass="panelDetails" runat="server" Width="862px">
    <table>
    <tr>
     <td>
        <asp:Label ID="Label3" runat="server" Text="Customer Code" CssClass="lbl-form"></asp:Label>
        <font color="red">*</font>
     </td>
     <td>
        <asp:DropDownList CssClass="ddl-form" ID="DDLCustomer" DataTextField="CustName" DataValueField="CustCode"
        runat="server" TabIndex="1" 
             OnSelectedIndexChanged="DDLCustomer_SelectedIndexChanged"  AutoPostBack="True" 
             width="500px">
        </asp:DropDownList>
     </td>
         <%--
         <td>
            <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
            InitialValue="0" ValidationGroup="vpcn1"  ControlToValidate="DDLCustomer">.</asp:RequiredFieldValidator>
        </td>
        --%>
    </tr>
    </table>
</asp:Panel>
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="rtdbk"
        runat="server" ID="ss" />
<p></p> 
<asp:Panel ID="Pnl3" runat="server" Width="900px">
    <asp:Panel ID="PnlCustDetails"  runat="server" Width="863px">
    <table width="600px" border="0" cellpadding="2" cellspacing="2">
      <tr>
        <td>
            <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="Customer Name:" Width="110px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblCustName" runat="server" CssClass="lbl-form" Width="500px" Font-Bold></asp:Label>
        </td>
      </tr>
       <tr>
        <td>
            <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="Customer Address:" Width="110px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblCustAddress" runat="server" CssClass="lbl-form" Width="550px" Font-Bold></asp:Label>
        </td>
       </tr>
    </table>
 </asp:Panel>
<p></p>
    <asp:GridView ID="Grd3" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" onrowediting="Grd3_RowEditing" >
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Book Code">
                <ItemTemplate>
                    <asp:Label ID="lbl1bkcode" runat="server" Text='<%#Eval("bookcode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Name">
                <ItemTemplate>
                    <asp:Label ID="lbl1Name" runat="server" Text='<%#Eval("bookname")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Qty" 
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lbl1qty" runat="server" Style="text-align: right;" Text='<%#Eval("Qty")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Returned Qty" 
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lbl1available" runat="server" Style="display: none;" Text='<%#Eval("AvailableQty") %>'></asp:Label>
                    <asp:Label ID="lbl1rtqty" runat="server" Style="text-align: right;" Text='<%#Eval("ReturnedQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" 
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" ToolTip ="View"
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
            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lbdt" Style="text-align: right;" runat="server" Text='<%#Eval("CreatedOn") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Returned By" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="left">
                <ItemTemplate>
                    <asp:Label ID="lbrtby" Style="text-align: right;" runat="server" Text='<%#Eval("CreatedBy") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
        
            <asp:TemplateField HeaderText="Returned Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lbbkcode" runat="server" Style="display: none;" Text='<%#Eval("Bookcode")%>'></asp:Label>
                    <asp:Label ID="lbrtqt" Style="text-align: right;" runat="server" Text='<%#Eval("ReturnQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Comment" HeaderStyle-Width="120px" >
                <ItemTemplate>
                    <asp:TextBox ID="txt2cmmt" CssClass="inp-form" Width="600px" Height="30px" runat="server"
                        TextMode="MultiLine" Enabled="false" Text='<%#Eval("Comment") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
</asp:Panel>