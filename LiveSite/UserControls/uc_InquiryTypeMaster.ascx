<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_InquiryTypeMaster.ascx.cs" Inherits="UserControls_uc_InquiryTypeMaster" %>
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

<asp:Panel ID="PnlITDetails" runat="server">
    <asp:GridView ID="GrdIStatus" runat="server" AllowPaging="false" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
        PageSize="10" Width="550px" onrowdeleting="GrdIStatus_RowDeleting" 
        onrowediting="GrdIStatus_RowEditing" >
        <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Inquiry Type" 
                HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblITM_ID" runat="server"  Style="display: none" Text='<%#Eval("ITM_ID")%>'></asp:Label>                        
                    <asp:Label ID="lblITM_Name" runat="server"  Text='<%#Eval("ITM_Name") %>'></asp:Label>
                </ItemTemplate>             
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="Is Default" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsDefault" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsDefault")) %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Email From"
                HeaderStyle-Width="700px" ItemStyle-HorizontalAlign="Center" >
                <ItemTemplate>
                                
                    <asp:Label ID="lblEmailFrom" runat="server"  Text='<%#Eval("EmailFrom") %>'></asp:Label>
                </ItemTemplate>             
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="Email Sub" HeaderStyle-Width="700px" ItemStyle-HorizontalAlign="Center" >
                <ItemTemplate>
                 <asp:Label ID="lblEmailSub" runat="server"  Text='<%#Eval("EmailSub") %>'></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Email Body"
                HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" Visible="false">
                <ItemTemplate>
                     <asp:Label ID="lblEmailBody" runat="server"  Text='<%#Eval("EmailBody") %>'></asp:Label>
                </ItemTemplate>             
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="EmailSign" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblEmailSign" runat="server"  Text='<%#Eval("EmailSign") %>'></asp:Label>
                  </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
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
        shortcut.add("Ctrl+F", function () {
            document.getElementById('find').focus();
        });
        setTimeout("setSatus()", 2000);
        function setSatus() {
            var status = "[ Ctrl+F : Find ]";
            document.getElementById('status').innerHTML = status;
        }
    </script>
    </asp:Panel>
    
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
    
    <asp:Panel ID="PnlITAdd" CssClass="panelDetails" runat="server" Width="400px">
            <asp:Label ID="lblITM_ID"  runat="server" Text="0" style="display:none;"></asp:Label>
          
          <table cellpadding="0" cellspacing="0" style="width: 94%">
            <tr>
              <td >
                <asp:Label ID="lblInquiryType" CssClass="lbl-form" runat="server" Text="Inquiry Type"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtInquiryType" TabIndex="1" CssClass="inp-form" runat="server" 
                        MaxLength="20" ontextchanged="txtInquiryType_TextChanged"  Height="20px" Width="150px"></asp:TextBox>
              </td>
              <td>
                <asp:RequiredFieldValidator ID="reqCode" runat="server" ErrorMessage="Require Inquiry Type" 
                    ValidationGroup="st1" ControlToValidate="txtInquiryType">.</asp:RequiredFieldValidator>
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
              <td >
                <asp:Label ID="lblEmailTo" CssClass="lbl-form" runat="server" Text="Email To"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtEmailTo" TabIndex="1" CssClass="inp-form" runat="server" 
                        MaxLength="100" Height="20px" Width="150px"></asp:TextBox>
              </td>
              <td>
               
             </td>
            </tr>
            <tr>
              <td >
                <asp:Label ID="lblEmailSubject" CssClass="lbl-form" runat="server" Text="Email Subject"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtEmailSubject" TabIndex="1" CssClass="inp-form" runat="server" 
                        MaxLength="20" Height="20px" Width="300px"></asp:TextBox>
              </td>
              <td>
               
             </td>
            </tr>
            <tr>
                            <td>
                             <asp:Label ID="lblEmailBody" CssClass="lbl-form" runat="server" Text="Email Body"></asp:Label>
                                </td>
                            <td>
                                <asp:TextBox ID="txtEmailBody" runat="server" 
                                    CssClass="inp-form"  style = "resize:none" TextMode="MultiLine" 
                                    Height="100px" Width="300px"></asp:TextBox>
                            </td>
                           
                        </tr>
            <tr>
              <td >
                <asp:Label ID="lblEmailSignature" CssClass="lbl-form" runat="server" Text="Email Signature"></asp:Label>
              </td>
              <td>
               <asp:TextBox ID="txtEmailSignature" runat="server" 
                                    CssClass="inp-form"  style = "resize:none" TextMode="MultiLine" 
                                    Height="40px" Width="150px"></asp:TextBox>
                
              </td>
              <td>
              
             </td>
            </tr>
            <tr>
            <td style="Height: 20px">
            
            </td>
            </tr>
            <tr style="Height: 20px">
            <td>
             <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="3" runat="server" Text="Save"
        Width="100px" Height="30px" ValidationGroup="st1" onclick="btnSave_Click" />
            </td>
            <td >
             <asp:Button ID="btnCancel" CssClass="submitbtn" TabIndex="3" runat="server" Text="Cancel"
        Width="100px" Height="30px" ValidationGroup="st1" onclick="btnCancel_Click"/>
            </td>
            </tr>
            </table>
          <script type="text/javascript">
              shortcut.add("Ctrl+S", function () {
                  document.getElementById('<%=btnSave.ClientID %>').click();
              });
              setTimeout("setSatus()", 2000);
              function setSatus() {
                  var status = "[ Ctrl+S : Save ]";
                  document.getElementById('status').innerHTML = status;

              }   
                    </script>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="st1" 
    runat="server" ID="ss" />
