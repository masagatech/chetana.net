<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_TargetMaster.ascx.cs" Inherits="UserControls_uc_TargetMaster" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
         <span runat="server" id="pageName"></span>
        <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
</div>

<div style="float: right; width: 70%">
    
            <asp:Button ID="btn_Save"  CssClass="submitbtn" ValidationGroup="target"
                runat="server" Text="Save" Width="80px" OnClick="btn_Save_Click" />
         
       
    <%-- <asp:Button ID="btncancel" CssClass="form-submit" runat="server" Text="Cancel" Width="80px"
        OnClick="btncancel_Click" />--%>
</div>
<br />
<br />
<asp:Panel ID="PnlTarget" CssClass="panelDetails" runat="server">
 <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td >
                <asp:Label ID="lblID" runat="server" CssClass="lbl-form" Text=""  style="display:none"></asp:Label>
                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Target Person"></asp:Label> <font color="red">*</font>
            </td>
             <td>
                  <asp:DropDownList ID="DDLtargetperson" TabIndex="1" DataTextField="Name" CssClass="ddl-form" Width = "150px"
                      DataValueField="EmpID" runat="server" AutoPostBack="true"
                      onselectedindexchanged="DDLtargetperson_SelectedIndexChanged" >
                        </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require Target Person" InitialValue = "0"
                    ValidationGroup="target" ControlToValidate="DDLtargetperson">.</asp:RequiredFieldValidator>       
            </td>
            <td >
                <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="Target Amount"></asp:Label> <font color="red">*</font>
            </td>
            <td >
                <asp:TextBox ID="txttargetamt" CssClass="inp-form" TabIndex="2"  onkeypress="return CheckNumeric(event)" MaxLength="10" Width="120px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Target Amount"
                            ValidationGroup="target" ControlToValidate="txttargetamt">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
         <td >
                <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="Start Date"></asp:Label>   <font color="red">*</font>
            </td>
            <td >
                <asp:TextBox ID="txtstartDate" onblur="ValidInYearDate(this);" CssClass="inp-form" TabIndex="3" Width="120px" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtstartDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtstartDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Start Date" 
                            ValidationGroup="target" ControlToValidate="txtstartDate">.</asp:RequiredFieldValidator>
            </td>
            <td >
                <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="End Date"></asp:Label> <font color="red">*</font>
            </td>
            <td >
                <asp:TextBox ID="txtendate" onblur="ValidInYearDate(this);" CssClass="inp-form" TabIndex="4" Width="120px" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtendate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtendate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select End Date" 
                            ValidationGroup="target" ControlToValidate="txtendate">.</asp:RequiredFieldValidator>
            </td>
            
        </tr>
  </table>      
</asp:Panel>

<asp:Panel ID ="pnlTargetdetails" runat="server">
      <asp:GridView ID="grdtargetDetails" CssClass="product-table" AutoGenerateColumns="False"
            Width="800px" TabIndex="11" runat="server"  AllowPaging="false" 
            AlternatingRowStyle-CssClass="alt" OnRowEditing="grdtargetDetails_RowEditing">
            <Columns>
                <asp:TemplateField HeaderText="Zone" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate> 
                       
                        <asp:Label ID="lblTargetId" Style="display: none;" runat="server" Text='<%#Eval("TargetId")%>'></asp:Label>
                        <asp:Label ID="lblzone"  runat="server" Text='<%#Eval("SuperZoneName")%>'></asp:Label>
                         <asp:Label ID="lblzoneid"  Style="display: none;" runat="server" Text='<%#Eval("Personlevel")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <asp:Label ID="lblTargetPersonId" Style="display: none;" runat="server" Text='<%#Eval("TargetPersonId")%>'></asp:Label>
                             <asp:Label ID="lbltargetperson" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Target Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbltargetamt" Style="text-align: right;"  runat="server" Text='<%#Eval("TargetAmt","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Start Date" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstartdate"  runat="server" Text='<%#Eval("TargetStartDate")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="End Date" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblenddate" Style="text-align: right;" runat="server" Text='<%#Eval("TargetEndDate")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
               </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="target"
    runat="server" ID="ss" />
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
document.getElementById('ctl00_ContentPlaceHolder1_uc_TargetMaster1_btn_Save').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>