<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CompanyMaster.ascx.cs" Inherits="UserControls_CompanyMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
<div class="section-header">
<tr>
<td>
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>
        <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">               
    </div>
</td>
<td>
<div style="float: right; width: 50%">
 <div id="filter" runat="server">
    <span>Filter Data:</span>
    <input name="filt" onkeyup="filter(this, 'sf', '<%=GrdCmpyDetails.ClientID%>')" type="text">
 </div>
 </div>
</td>
</tr>
</div>
 <div style="float: right; width: 44%">
      <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="3" runat="server" Text="Save" 
            ValidationGroup="cmpy" Width="80px" OnClick="btnSave_Click" />  
            
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="cmpy"
  runat="server" ID="VScmpy" />
</div>    
<br />
<br />
     <asp:Panel ID="PnlCmpyDetails" runat="server">
            <asp:GridView ID="GrdCmpyDetails" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="10" 
                Width="600px" onrowdeleting="GrdCmpyDetails_RowDeleting" 
                onrowediting="GrdCmpyDetails_RowEditing">                          
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Company Name"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCmpyID" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("CompanyID") %>'></asp:Label>
                            <asp:Label ID="lblCmpyName" runat="server" CssClass="lbl-form" Text='<%#Eval("CompanyName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Short Form" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblShortForm" runat="server" CssClass="lbl-form" 
                            Text='<%#Eval("CompanyShortform") %>'></asp:Label>                            
                            <asp:Label ID="lblAddress" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("Address") %>'></asp:Label>
                            <asp:Label ID="lblCmpyCode" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("CompanyCode") %>'></asp:Label>                            
                            <asp:Label ID="lblZip" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("Zip") %>'></asp:Label>
                             <asp:Label ID="lblSuperZoneID" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("SuperZoneID")%>'></asp:Label>
                            <asp:Label ID="lblZoneID" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("ZoneID") %>'></asp:Label>                            
                            <asp:Label ID="lblAreaZoneID" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("AreaZoneID")%>'></asp:Label>                            
                            <asp:Label ID="lblAreaID" runat="server" CssClass="lbl-form" Style="display: none;"
                                Text='<%#Eval("AreaID") %>'></asp:Label>  
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
                            <asp:CheckBox ID="chkisActive" runat="server" CssClass="lbl-form" Style="display: none;"
                                Checked='<%#Eval("IsActive") %>' />                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>                  
                            <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                            <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you want to Delete?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>


     <asp:Panel ID="PnlAddCmpy" CssClass="panelDetails" runat="server" Width="670px">
                <caption>
                    <br />
                </caption>      
                <table cellpadding="0" cellspacing="0" style="margin-bottom: 0px; width: 93%;">
                    <tr>
                        <td width="100px" class="style5">
                            <asp:Label ID="LblCmpID" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
                            <asp:Label ID="LblCmpyName" runat="server" CssClass="lbl-form" Text="Company Name "></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="TxtCmpyName" CssClass="inp-form" runat="server" Width="241px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="reqName" runat="server" ErrorMessage="Enter Company Name" 
                             ValidationGroup="cmpy" ControlToValidate="TxtCmpyName">.</asp:RequiredFieldValidator>
                        </td>
                        </tr>                    
                        <tr>
                            <td>
                                <asp:Label ID="LblCSF" CssClass="lbl-form" runat="server" Text="Short Form"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtShortForm" CssClass="inp-form" runat="server" 
                                    MaxLength="30"></asp:TextBox>
                            </td>
                             <td>                            
                            </td>                        
                            <td >
                                <asp:Label ID="LblCC" CssClass="lbl-form" runat="server" Text="Company code"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <ContentTemplate>
                                <asp:TextBox ID="TxtCmpyCode" CssClass="inp-form" runat="server" 
                                     AutoPostBack="True" ontextchanged="TxtCmpyCode_TextChanged" 
                                    MaxLength="25"></asp:TextBox>
        </ContentTemplate>
    </asp:UpdatePanel>
                            </td>
                             <td>
                                <asp:RequiredFieldValidator ID="reqCode" runat="server" ErrorMessage="Enter Company Code" 
                                 ValidationGroup="cmpy" ControlToValidate="TxtCmpyCode">.</asp:RequiredFieldValidator>
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
                                TextMode="MultiLine" Width="138px"></asp:TextBox>
                        </td>
                        <td></td>
                            <td></td>
                        
                        <tr>
                            <td>
                                <asp:Label ID="LblS" runat="server" CssClass="lbl-form" Text="State"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLState" runat="server" AutoPostBack="true" 
                                    DataTextField="Name" DataValueField="DMID" 
                                    onselectedindexchanged="DDLState_SelectedIndexChanged" Width="152px">
                                </asp:DropDownList>
                            </td>
                            <td> </td>
                            <td>
                                <asp:Label ID="LblSZ" runat="server" CssClass="lbl-form" Text="Super Zone"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLsuperzone" runat="server" AutoPostBack="True" 
                                    DataTextField="SuperZoneName" DataValueField="SuperZoneID" 
                                    OnSelectedIndexChanged="DDLsuperzone_SelectedIndexChanged" TabIndex="9" 
                                    Width="152px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblC" runat="server" CssClass="lbl-form" Text="City"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DDLCity" runat="server" DataTextField="Name" 
                                           Enabled="false"  DataValueField="DMID" Width="152px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqDDlCitycmpy" runat="server" 
                                        ControlToValidate="DDLCity" ErrorMessage="Select City" InitialValue="0" 
                                         ValidationGroup="cmpy">.</asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DDLState" 
                                            EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td> </td>
                           
                            <td>
                                <asp:Label ID="LblZ" runat="server" CssClass="lbl-form" Text="Zone"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpDDLzone" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DDLzone" runat="server" AutoPostBack="True" 
                                            DataTextField="ZoneName" DataValueField="ZoneID" Enabled="false" 
                                            OnSelectedIndexChanged="DDLzone_SelectedIndexChanged" TabIndex="10" 
                                            Width="152px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DDLsuperzone" 
                                            EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblPH1" runat="server" CssClass="lbl-form" Text="Phone1 "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtPhone1" runat="server" CssClass="inp-form" MaxLength="12"></asp:TextBox>
                            </td>
                            <td>  </td>
                          
                            <td>
                                <asp:Label ID="LblAZ" runat="server" CssClass="lbl-form" Text="Area Zone"></asp:Label>
                                <font color="red">*</font>&nbsp;
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpDDLareazone" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DDLareazone" runat="server" AutoPostBack="True" 
                                            DataTextField="AreaZoneName" DataValueField="AreaZoneID" Enabled="false" 
                                            OnSelectedIndexChanged="DDLareazone_SelectedIndexChanged" TabIndex="11" 
                                            Width="152px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DDLzone" 
                                            EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <td>
                                </td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblPH2" runat="server" CssClass="lbl-form" Text="Phone2"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtPhone2" runat="server" CssClass="inp-form" MaxLength="12"></asp:TextBox>
                            </td>
                            <td></td>
                            
                            <td>
                                <asp:Label ID="LblA" runat="server" CssClass="lbl-form" Text="Area"></asp:Label>
                                <font color="red">*</font>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="upDDLarea" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DDLarea" runat="server" DataTextField="AreaName" 
                                            DataValueField="AreaID" Enabled="false"  Width="152px">
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="reqDDlAreacmpy" runat="server" 
                                        ControlToValidate="DDLarea" ErrorMessage="Select Area" InitialValue= "0" 
                                         ValidationGroup="cmpy">.</asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblZip" runat="server" CssClass="lbl-form" Text="Zip"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtZip" runat="server" CssClass="inp-form" MaxLength="8"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblEID" runat="server" CssClass="lbl-form" Text="EmailID"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtEmailID" runat="server" CssClass="inp-form"></asp:TextBox>
                            </td>                                                    
                            <td> </td>
                           <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblChk" runat="server" CssClass="lbl-form" Text="Active"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="ChekActive" runat="server" Checked="true" TabIndex="3" />
                            </td>
                        </tr>
                        
                    </tr>
                </table>
                <caption>
                    <br />
                </caption>            
        </asp:Panel>
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
document.getElementById('ctl00_ContentPlaceHolder1_uc_CompanyMaster1_btnSave').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>
