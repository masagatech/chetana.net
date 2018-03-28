<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_InquiryStatusMaster.ascx.cs" Inherits="UserControls_uc_InquiryStatusMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<div class="section-header">
<td>
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
         <span runat="server" id="pageName"></span>
         <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>    
</td>
<td>
    <div style="float: right; width: 50%">       
       <div id="filter" runat="server" style="width:220px; clear:both; float:left;">  <span>Filter Data:</span>
        <input name="filt" id="find" onkeyup="filter(this, 'sf', '1')" type="text"> </div>
</div>
</td>
</div>

<div style="float: right; width: 76%">
    
</div>
<br />
<br />

<asp:Panel runat="server" ID="PnlISDetails" Width="100%">
                  
                    <asp:GridView ID="GrdIStatus" runat="server" AllowPaging="false" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
        PageSize="10" Width="300px" onrowdeleting="GrdIStatus_RowDeleting" 
        onrowediting="GrdIStatus_RowEditing" >
        <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Inquiry Status"
                HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblStatus_ID" runat="server"  Style="display: none" Text='<%#Eval("Status_ID")%>'></asp:Label>                        
                    <asp:Label ID="lblStatus_Name" runat="server"  Text='<%#Eval("Status_Name") %>'></asp:Label>
                </ItemTemplate>             
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="IsDefault" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsDefault" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsDefault")) %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>        
    </asp:GridView>
                    <div>
                    </div>
                    &nbsp;</asp:Panel>
    
     <script type="text/javascript">
         function filter(phrase, _id) {
             var words = phrase.value.toLowerCase().split(" ");
             var table = document.getElementById('<%=GrdIStatus.ClientID%>');
             //document.getElementById(_id);
             var ele;
             for (var r = 1; r < table.rows.length; r++) {
                 ele = table.rows[r].innerHTML.replace(/<[^>]+>/g, "");
                 var displayStyle = 'none';
                 for (var i = 0; i < words.length; i++) {
                     if (ele.toLowerCase().indexOf(words[i]) >= 0)
                         displayStyle = '';
                     else {
                         displayStyle = 'none';
                         break;
                     }
                 }
                 table.rows[r].style.display = displayStyle;
             }
             if (words != "") {
                 sloder('search for : ' + words);
             }
             else {
                 cloder();
             }
         }
    </script>
    
    <asp:Panel ID="PnlISAdd" CssClass="panelDetails" runat="server" Width="310px">
           <asp:Label ID="lblStatus_ID"  runat="server" Text="0" style="display:none;"></asp:Label>
        <table cellpadding="0" cellspacing="0" style="width: 94%">
            <tr>
              <td >
                <asp:Label ID="lblInquiryStatus" CssClass="lbl-form" runat="server" Text="Inquiry Status"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtInquiryStatus" TabIndex="1" CssClass="inp-form" runat="server" 
                      MaxLength="100" 
                      ontextchanged="txtInquiryStatus_TextChanged" Height="20px" Width="150px"></asp:TextBox>
              </td>
              <td>
                <asp:RequiredFieldValidator ID="reqCode" runat="server" ErrorMessage="Require Inquiry Status" 
                    ValidationGroup="st1" ControlToValidate="txtInquiryStatus">.</asp:RequiredFieldValidator>
             </td>
            </tr>
            
            <tr>
              <td >
                <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Is Default" Height="20px"></asp:Label>
              </td>
              <td style="Height: 35px">
                <asp:CheckBox ID="ChekIsDefault" TabIndex="3" runat="server" Checked="true" Height="20px" Width="150px" />
              </td>
               
              <td id="tdChekActive" runat="server" visible="false">
                <asp:CheckBox ID="ChekActive" TabIndex="3" runat="server" Checked="true" />
              </td>
            </tr>
            <tr>
            <td style="Height: 20px">
            
            </td>
            </tr>
            <tr style="Height: 20px">
            <td>
             <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="3" runat="server" Text="Save"
        Width="80px" Height="30px" ValidationGroup="st1" onclick="btnSave_Click" />
            </td>
            </tr>
          </table>
          </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="st1" 
    runat="server" ID="ss" />
