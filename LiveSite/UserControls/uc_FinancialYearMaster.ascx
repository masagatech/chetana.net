<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_FinancialYearMaster.ascx.cs" Inherits="UserControls_uc_Financial_YearMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
        <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>    
</div>
<div style="float: right; width: 70%">       
        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="3" runat="server" Text="Save" ValidationGroup= "year"
            Width="80px" onclick="btnSave_Click"  />
</div>
<br />
<br />
          <asp:Panel ID="PnlYear" CssClass="panelDetails" runat="server" Width="400px">
           <table>
                <tr>
                    <td>
                        <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="Label1" runat="server" CssClass="lbl-form"  Text="From Year" ></asp:Label>
                         <font color="red">*</font>
                   </td>
                   <td>
                       <asp:TextBox ID="txtfrmyr" CssClass="inp-form" TabIndex="1" onkeypress="return CheckNumeric(event)" runat="server"></asp:TextBox>
                   </td>
                     <td>
                        <asp:RequiredFieldValidator ID="Reqfrmyr" runat="server" ErrorMessage="Require 'From Year' "
                            ValidationGroup="year" ControlToValidate="txtfrmyr">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" CssClass="lbl-form" runat="server"  Text="To Year" ></asp:Label>
                         <font color="red">*</font>
                   </td>
                   <td>
                       <asp:TextBox ID="txttoyr" CssClass="inp-form" TabIndex="2" onkeypress="return CheckNumeric(event)"  runat="server"></asp:TextBox>
                   </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqtoyr" runat="server" ErrorMessage="Require 'To year'"
                            ValidationGroup="year" ControlToValidate="txttoyr">*</asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                    <td>
                        <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="Chekacv" TabIndex="2" runat="server" Checked="true" Enabled="true" />
                    </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlFinYearDetails" runat="server">
            <asp:GridView ID="grdyearDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="5" Width="500px"
                AlternatingRowStyle-CssClass="alt" 
                onpageindexchanging="grdyearDetails_PageIndexChanging" 
                onrowediting="grdyearDetails_RowEditing" >
                <Columns>
                    <asp:TemplateField HeaderText="Year" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblYearID" runat="server" Text='<%#Eval("yearAutoId")%>' Style="display: none"></asp:Label>
                              <asp:Label ID="lblfrmyr" runat="server" Text='<%#Eval("FromYear") %>' Style="display:none"></asp:Label>
                              <asp:Label ID="lbltoyr" runat="server" Text='<%#Eval("ToYear")%>' Style="display:none"></asp:Label>
                            <asp:Label ID="lblfrmyr1" runat="server" Text='<%#Eval("FromYear") +"-"+ Eval("ToYear")%>'></asp:Label>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Active" HeaderStyle-Width="15px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="15px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
         </asp:Panel>
        
   <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="year" runat="server" ID="ss"/>
   <script type="text/javascript">
     setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
   document.getElementById('status').innerHTML=status;
   }
        </script>
<script type="text/javascript">
      
shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_Financial1_btnSave').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>