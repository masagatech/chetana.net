<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_BrokerMaster.ascx.cs" Inherits="UserControls_uc_BrokerMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>

<div class="section-header">
<td>
   <div class="title">
      <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
      <span runat="server" id="pageName"></span>
        <a href="Campaigns.aspx" title="back to campaign list"></a>
   </div> 
</td> 
<td>
<div style="float: right; width: 50%">
 <div id="filter" runat="server">
    <span>Filter Data:</span>
    <input name="filt" onkeyup="filter(this, 'sf', '<%=GrdBroker.ClientID%>')" type="text">
 </div> 
 </div>
</td>
</div>
 <div style="float: right; width: 41%">
      <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="17" runat="server" Text="Save" 
            ValidationGroup="Broker" Width="80px" OnClick="btnSave_Click" />  
</div>    
<br />
<br />

<asp:Panel ID="PnlAddBroker" CssClass="panelDetails" runat="server" Width="700px">
<caption>
    <br />
</caption>      
<table cellpadding="0" cellspacing="0" style="margin-bottom: 0px; width: 98%;">
    <tr>
        <td >
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <ContentTemplate>
            <asp:Label ID="LblBrokerID" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
            <asp:Label ID="LblBrokerCode" CssClass="lbl-form" runat="server" Text="Broker Code"></asp:Label>
            <font color="red">*</font>
            </ContentTemplate>
    </asp:UpdatePanel>
        </td>
        <td>
            <asp:TextBox ID="TxtBrokerCode" CssClass="inp-form" runat="server" 
            AutoPostBack="True"  TabIndex="1" ontextchanged="TxtBrokerCode_TextChanged"></asp:TextBox>
        </td>

         <td>
            <asp:RequiredFieldValidator ID="reqCode3" runat="server" ErrorMessage="Enter Broker Code" 
             ValidationGroup="Broker" ControlToValidate="TxtBrokerCode">.</asp:RequiredFieldValidator>
        </td> 
        
        <td >
            <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Brokerage Rate"></asp:Label>          
        </td>
        <td>
            <asp:TextBox ID="TxtBrkRate" CssClass="inp-form" runat="server" Width="18px" 
               TabIndex="2"  MaxLength="3">0</asp:TextBox>
        </td>
        <td>                           
        </td>                                                                                                                  
    </tr>   
        
    <tr>
        <td width="100px">
          <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="First Name"></asp:Label>
          <font color="red">*</font>
        </td>
        <td width="160px">
          <asp:TextBox ID="TxtFname" CssClass="inp-form" TabIndex="4" runat="server"></asp:TextBox>
        </td>
        <td>
          <asp:RequiredFieldValidator ID="reqFnam3" runat="server" ErrorMessage="Require First Name"
            ValidationGroup="Broker" ControlToValidate="TxtFname">.</asp:RequiredFieldValidator>
        </td>
        <td>
          <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Middle Name"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="TxtMname" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
        </td>
        <td>
          <asp:Label ID="Label7" CssClass="lbl-form" runat="server" Text="Last Name"></asp:Label>
          <font color="red">*</font>
        </td>
        <td>
          <asp:TextBox ID="TxtLname" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
        </td>
        <td>
          <asp:RequiredFieldValidator ID="reqLnam3" runat="server" ErrorMessage="Require Last Name"
            ValidationGroup="Broker" ControlToValidate="txtLname">.</asp:RequiredFieldValidator>
        </td>
      </tr>           

        <tr>
            <td colspan="7" style="padding-bottom: 10px; padding-top: 8px;">
             <hr />
            </td>
        </tr>
    <tr>
    <td>
        <asp:Label ID="LblAdd" runat="server" CssClass="lbl-form" Text="Address"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TxtAddress" runat="server" CssClass="inp-form" Height="30px" 
          TabIndex="7"  TextMode="MultiLine" Width="138px"></asp:TextBox>
    </td>
    <td></td> 
    </tr>  
    <tr>
        <td>
            <asp:Label ID="LblS" runat="server" CssClass="lbl-form" Text="State"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DDLState" runat="server" AutoPostBack="true" 
                DataTextField="Name" DataValueField="DMID" TabIndex="8"
                onselectedindexchanged="DDLState_SelectedIndexChanged" Width="152px">
            </asp:DropDownList>
        </td>
        <td></td>        
    </tr>
    <tr>
        <td>
            <asp:Label ID="LblC" runat="server" CssClass="lbl-form" Text="City"></asp:Label>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="DDLCity" runat="server" DataTextField="Name" 
                        TabIndex="9" DataValueField="DMID" Width="152px"> 
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="reqDDlCity3" runat="server" 
                ControlToValidate="DDLCity" ErrorMessage="Select City" InitialValue="0"
                ValidationGroup="Broker">.</asp:RequiredFieldValidator>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DDLState" 
                        EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
        <td></td>  
    </tr>
    <tr>
        <td>
            <asp:Label ID="LblPH1" runat="server" CssClass="lbl-form" Text="Phone1 "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtPhone1" runat="server" CssClass="inp-form TabIndex="10"></asp:TextBox>
        </td>
        <td></td>
        
    </tr>
    <tr>
        <td>
            <asp:Label ID="LblPH2" runat="server" CssClass="lbl-form" Text="Phone2"></asp:Label>
        </td>
       <td>
            <asp:TextBox ID="TxtPhone2" runat="server" CssClass="inp-form" TabIndex="11"></asp:TextBox>
        </td>
       <td></td>
        
    </tr>
    <tr>
        <td>
            <asp:Label ID="LblZip0" runat="server" CssClass="lbl-form" Text="Zip"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtZip" runat="server" CssClass="inp-form" TabIndex="12"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LblEID" runat="server" CssClass="lbl-form" Text="EmailID"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtEmailID" runat="server" CssClass="inp-form" TabIndex="13"></asp:TextBox>
        </td>                                                    
        <td></td>       
    </tr>
    <tr>
    <td width="100px">
      <asp:Label ID="Label10" CssClass="lbl-form" runat="server" Text="Gender"></asp:Label>
    </td>
    <td>
      <asp:RadioButtonList ID="Rdgender" RepeatDirection="Horizontal" TabIndex="14" runat="server">
        <asp:ListItem Text="Male"></asp:ListItem>
        <asp:ListItem Text="Female"></asp:ListItem>
      </asp:RadioButtonList>
    </td>
    <td>
    </td>
    <td width="100px">
      <asp:Label ID="Label11" CssClass="lbl-form" runat="server" Text="DOB"></asp:Label>
    </td>
    <td>
      <asp:TextBox ID="TxtDob" CssClass="inp-form" TabIndex="15" runat="server"></asp:TextBox>
      <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDob"
        Format="dd/MM/yyyy" />
      <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtDob"
        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
        AutoComplete="true" CultureName="en-US" />
    </td>        
  </tr>    
    <tr>
        <td>
            <asp:Label ID="LblChk" runat="server" CssClass="lbl-form" Text="Active"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="ChekActive" runat="server" Checked="true" TabIndex="16" />
        </td>
    </tr>        

</table>
<caption>
    <br />
</caption>            
</asp:Panel>
<br />
<asp:Panel ID="PnlBrokerDetails" runat="server">
<asp:GridView ID="GrdBroker" runat="server" AllowPaging="false" AutoGenerateColumns="False" CellPadding="4"
                CssClass="product-table" ForeColor="#333333" PageSize="10" Width="600px" 
                onrowdeleting="GrdBroker_RowDeleting" onrowediting="GrdBroker_RowEditing">                          
<Columns>
 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Broker Name" ItemStyle-HorizontalAlign="Center">
<ItemTemplate>
    <asp:Label ID="lblBrokerID" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("BrokerID") %>'></asp:Label>
    <asp:Label ID="lblBrokerCode" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("BrokerCode") %>'></asp:Label>
    <asp:Label ID="lblBrokerName" runat="server" CssClass="lbl-form" 
        Text='<%#Eval("FirstName")+" :: "+Eval("LastName") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Brokerage Rate" ItemStyle-HorizontalAlign="Center">
<ItemTemplate> 
    <asp:Label ID="lblFN" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("FirstName") %>'></asp:Label>
    <asp:Label ID="lblMN" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("MiddleName") %>'></asp:Label>
    <asp:Label ID="lblLN" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("LastName")%>'></asp:Label>                              
    <asp:Label ID="lblAddress" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("Address") %>'></asp:Label>
    <asp:Label ID="lblZip" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("Zip") %>'></asp:Label>
    <asp:Label ID="lblStateID" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("StateID")%>'></asp:Label>    
    <asp:Label ID="lblCityID" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("CityID")%>'></asp:Label>                               
    <asp:Label ID="lblPhone1" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("Phone1") %>'></asp:Label>
    <asp:Label ID="lblPhone2" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("Phone2") %>'></asp:Label>
    <asp:Label ID="lblEmailID" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("EmailID") %>'></asp:Label>
    <asp:Label ID="lblGender" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("Gender") %>'></asp:Label>  
    <asp:Label ID="lblDob" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("DOB") %>'></asp:Label> 
    <asp:Label ID="lblBrokerageRate" runat="server" CssClass="lbl-form" 
        Text='<%#Eval("BrokerageRate") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>        
<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Active" ItemStyle-HorizontalAlign="Center">
<ItemTemplate>          
    <asp:CheckBox ID="chkisActive" runat="server" CssClass="lbl-form" Enabled="false" 
        Checked='<%#Eval("IsActive") %>'> </asp:CheckBox>                          
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
<ItemTemplate>                  
    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
    -   
    <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" 
        OnClientClick="return confirm('Do you want to Delete?')" />
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</asp:Panel>

<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Broker"
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
document.getElementById('ctl00_ContentPlaceHolder1_uc_BrokerMaster1_btnSave').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>
   

