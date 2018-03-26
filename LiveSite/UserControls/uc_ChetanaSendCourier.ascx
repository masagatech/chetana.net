<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ChetanaSendCourier.ascx.cs" Inherits="UserControls_uc_ChetanaSendCourier" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
  <tr>
    <td>
      <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list"></a>
      </div>
    </td>
  </tr>
</div>
<asp:UpdatePanel ID="UpdatePanel7" runat="server" >

  <ContentTemplate>
  <div>
   <div  style="margin: -30px 0 0; position: fixed; top: 100px;left: 210.5px;" id="divLevel1" runat="server" >
   <asp:Panel ID="Panel1" CssClass="panelDetails" runat="server"  style="float: left; height: 20px; margin: 0 4px 0 0; width: 210px;" >
      <table>
        <tr>
          <td>
            <asp:RadioButtonList runat="server" ID="rdLevel1" TabIndex="1" RepeatDirection="Horizontal"
              CssClass="lbl-form" Width="300px" AutoPostBack="true" onselectedindexchanged="rdLevel1_SelectedIndexChanged" 
                  >
              <asp:ListItem Value="InvoiceNo" Text="Invoice" Selected="True"></asp:ListItem>
               <asp:ListItem Value="Others" Text="Others" ></asp:ListItem>
             <%-- <asp:ListItem Value="General" Text="General"></asp:ListItem>--%>
            </asp:RadioButtonList>
          </td>
        </tr>
        
      </table></asp:Panel>
      </div>
  <div  style="margin: -30px 0 0; position: fixed; top: 162px;left: 210.5px;width: 250px;" id="divLevel3"  visible="false" runat="server" >
  <asp:Panel ID="Panel3" CssClass="panelDetails" runat="server"  style="float: left; height: 47px; margin: 0 4px 0 0; width: 210px;" >
      <table>
          <tr>
            <td width="60px">
              <asp:Label ID="Label9" runat="server" Text="Invoice No." CssClass="lbl-form"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtInvoiceNoGet" CssClass="inp-form" TabIndex="22" Width="80px" 
                    runat="server" ontextchanged="txtInvoiceNoGet_TextChanged"></asp:TextBox>
            </td>
             <td width="10px">
            </td>
            
            <td width="50px" id="DocNoGetTD1" runat="server" visible ="false">
              <asp:Label ID="Label3" runat="server" Text="Dc No." CssClass="lbl-form"></asp:Label>
            </td>
            <td width="50px" id="DocNoGetTD2" runat="server" visible ="false">
              <asp:TextBox ID="txtDocNoGet" CssClass="inp-form" TabIndex="22" Width="80px" 
                    runat="server" ontextchanged="txtDocNoGet_TextChanged"></asp:TextBox>
            </td>
            <td>
              <asp:Button ID="btnget" runat="server" Text="Get" CssClass="submitbtn" TabIndex="24"
                ValidationGroup="pdadoc" Width="50px" onclick="btnget_Click" />
            </td>
          </tr>
        </table></asp:Panel>
  </div>
  <div style="margin: -30px 0 0; position: fixed; top: 100px;left: 545.5px;" id="divLevel2" runat="server" visible="false">
    <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server"  style="float: left; height: 110px; top: 253px;margin: 0 4px 0 0; width: 435px;" >
     
      <table>
        <tr>
            <td style="width: 472px">
                <asp:Label ID="lblCourier" CssClass="lbl-form" runat="server" Text="Select Courier"></asp:Label>
              </td>
              <td>                  
                  <asp:DropDownList  CssClass="ddl-form" ID="ddlCourier" DataTextField="Value" DataValueField="AutoId" TabIndex="1"
                    runat="server" ></asp:DropDownList>
                    
              </td>
         
        </tr>
        <tr>
            <td style="width: 472px">
                <asp:Label ID="lblBranch" CssClass="lbl-form" runat="server" Text="Select Branch"></asp:Label>
              </td>
              <td>                  
                  <asp:DropDownList  CssClass="ddl-form" ID="ddlBranch" DataTextField="Branch" 
                      DataValueField="EmpID" TabIndex="2"
                    runat="server" onselectedindexchanged="ddlBranch_SelectedIndexChanged" autopostback="true"></asp:DropDownList>
                    
              </td>
         
        </tr>
        <tr id ="trBranchAddress" runat="server" visible="false">
                    <td style="width: 472px" >
                        <asp:Label ID="lblBranchAddress" runat="server" CssClass="lbl-form" Text="Branch Address:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="inp-form" 
                            style="margin-left: 11px" TabIndex="3" TextMode="MultiLine" Width="188px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
        
      </table>
    </asp:Panel>
    
   <div class="message_error" id="message_error" runat="server" visible="false">
    <table>
    <tbody>
    <tr><td>
         <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
         </tr><tr><td>
          <asp:Label ID="lblSCD" runat="server" Text=""></asp:Label></td></tr>
    </tbody>
    </table>
    </div>
         <div  style="margin: -30px 0 0; position: fixed; top: 260px;left: 210.5px;" id="divData" runat="server" >
    <asp:Panel ID="PnlSendCourier" CssClass="panelDetails" Visible="false" runat="server" Width="597px" style="float: left;">
      <table width="100%" cellpadding="0" cellspacing="0" >
     
           <tr>
          <td>
            <asp:Label ID="lblDocumentNoH" CssClass="lbl-form" runat="server" Text="Document No"></asp:Label>
          </td>
          <td>
              <asp:Label ID="lblDocumentNo" runat="server" Text="Label"></asp:Label>
          </td>
          
          <td>
            <asp:Label ID="lblInvoiceNoH" CssClass="lbl-form" runat="server" Text="Invoice No"></asp:Label>
          </td>
          <td>
              <asp:Label ID="lblInvoiceNo" runat="server" Text="Label"></asp:Label>
          </td>
          
        </tr>
        <tr>
        
          <td>
            <asp:Label ID="lblCustomerNameH" CssClass="lbl-form" runat="server" Text="Customer Name"></asp:Label>
          </td>
          <td>
              <asp:Label ID="lblCustomerName" runat="server" Text="Label"></asp:Label>
          </td>
          
          <td>
            <asp:Label ID="lblAddressH" CssClass="lbl-form" runat="server" Text="Address"></asp:Label>
          </td>
          <td>
              <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
          </td>
        </tr>
        
        <tr>
        
          <td>
            <asp:Label ID="lblPhone1H" CssClass="lbl-form" runat="server" Text="Phone 1"></asp:Label>
          </td>
          <td>
              <asp:Label ID="lblPhone1" runat="server" Text="Label"></asp:Label>
            
          </td>
          
          <td>
            <asp:Label ID="lblPersonInchargeH" CssClass="lbl-form" runat="server" Text="Person Incharge"></asp:Label>
          </td>
          <td>
              <asp:Label ID="lblPersonIncharge" runat="server" Text="Label"></asp:Label>
            
          </td>
        </tr>
        <tr>
          <td>
              &nbsp;</td>
          <td>
              
                
            </td>
          
          <td>
          <asp:Button ID="btn_Save" runat="server" Text="Add" CssClass="submitbtn" TabIndex="24"
                ValidationGroup="pdadoc" Width="50px" onclick="btn_Save_Click" />
              
            </td>
          <td>
            
          </td>
        </tr>
      </table>
    </asp:Panel>
    </div>
    <p>
    </p>
  
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="bnkrct"
      runat="server" ID="bk" />
      <div style="margin: -30px 0 0; position: fixed; top: 390px;left: 210.5px;" id="divgrdCD" runat="server">
      <asp:GridView ID="grdCD" AlternatingRowStyle-CssClass="alt" CssClass="product-table"  AutoGenerateColumns="false" ShowFooter="true" runat="server" >
    <Columns>
                                    <asp:TemplateField HeaderText="Document No" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocumentNo" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice No" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceNo" runat="server" Text='<%#Eval("InvoiceNo")%>'></asp:Label>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Party Code" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustCode")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Party Name" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Party Address" HeaderStyle-Width="350px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhone1" runat="server" Text='<%#Eval("Phone1")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <%--<asp:TemplateField HeaderText="CourierID" HeaderStyle-Width="50px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourierID" runat="server" Text='<%#Eval("CourierID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BranchID" HeaderStyle-Width="50px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("BranchID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                  
                                </Columns>
      </asp:GridView> 
       <asp:Button ID="btnSave" runat="server" Text="Save & Print" CssClass="submitbtn" Visible="false" TabIndex="24"
                ValidationGroup="pdadoc" Width="80px" onclick="btnSave_Click" />


      </div>
    </div>
  <div  style="margin: -30px 0 0; position: fixed; top: 162px;left: 210.5px;width: 250px;" id="divLevel4"  visible="false" runat="server" >
  <asp:Panel ID="Panel2" CssClass="panelDetails" runat="server"  style="float: left; height: 200px; margin: 0 4px 0 0; width: 300px;" >
      <table>
          <tr>
                    <td >
                        <asp:Label ID="lblvalue"  runat="server" CssClass="lbl-form" 
                            Text="From Department"></asp:Label>
                        <font color="red">* </font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDepartment"  TabIndex="2" runat="server" CssClass="inp-form"
                            Width="186px" style="margin-left: 11px"></asp:TextBox>
                            <div id="dvcust1" class="divauto350">
                </div>
                 <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender1" runat="server" CompletionListCssClass="AutoExtender"
                    CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    Enabled="True" ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtDepartment"
                    UseContextKey="true" ContextKey="Department" CompletionListElementID="dvcust1">
                </ajaxCt:AutoCompleteExtender>
                    </td>
                    
                </tr>
               <%-- <asp:TextBox ID="txtcustomer" autocomplete="off" Width="300px" CssClass="inp-form"
                    TabIndex="0" runat="server"></asp:TextBox>
                <div id="dvcust1" class="divauto350">
                </div>
                <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender1" runat="server" CompletionListCssClass="AutoExtender"
                    CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    Enabled="True" ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                    UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust1">
                </ajaxCt:AutoCompleteExtender>--%>
                
                <tr id="trAddressGeneral" runat="server" visible="true">
                    <td >
                        <asp:Label ID="lblAddressGeneral" runat="server" CssClass="lbl-form" Text="To Address:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddressGeneral" runat="server" CssClass="inp-form" 
                            style="margin-left: 11px" TabIndex="3" TextMode="MultiLine" Width="188px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblRemark" runat="server" CssClass="lbl-form" Text="Remark:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="inp-form" 
                            style="margin-left: 11px" TabIndex="3" TextMode="MultiLine" Width="188px"></asp:TextBox>
                    </td>
                </tr>
                </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblweight" runat="server" CssClass="lbl-form" Text="Weight:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtweight" runat="server" CssClass="inp-form" Style="margin-left: 11px"
                                    TabIndex="4" Width="188px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Courier Date"></asp:Label>
                              
                            </td>
                            <td>
                                <asp:TextBox ID="txtsdate" runat="server" CssClass="inp-form" TabIndex="1" Style="margin-left: 11px"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtsdate" />
                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptAMPM="true"
                                    AutoComplete="true" CultureName="en-GB" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                                    TargetControlID="txtsdate" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsdate"
                                    ErrorMessage="Please select Fromdate" ValidationGroup="AZone">.</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                <tr>
                    <td >
                    </td>
                    <td>
                    <asp:Button ID="btnGeneralSave" CssClass="submitbtn" TabIndex="5" runat="server" Text="Save"
                  Width="70px" onclick="btnGeneralSave_Click" /> 
                    </td>
                </tr>
                 
        </table>
        
        </asp:Panel>
  </div>

  <div style="margin: -30px 0 0; position: relative; top: 280px;left: -4px;" id="divgrdGeneral" runat="server">
      <asp:GridView ID="grdGeneral" AlternatingRowStyle-CssClass="alt" CssClass="product-table"  AutoGenerateColumns="false" ShowFooter="true" runat="server" >
    <Columns>
                                    
                                    
                                    
                                    <asp:TemplateField HeaderText="Department" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Department")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Address" HeaderStyle-Width="350px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemark1" runat="server" Text='<%#Eval("Remark1")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                  
                                </Columns>
      </asp:GridView> 
       <asp:Button ID="SaveGeneral" runat="server" Text="Save & Print" 
          CssClass="submitbtn" Visible="false" TabIndex="24"
                ValidationGroup="pdadoc" Width="80px" onclick="SaveGeneral_Click"/>


      </div>
  
  </ContentTemplate>

</asp:UpdatePanel>

<script type="text/javascript">

    shortcut.add("Ctrl+S", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_ChetanaSendCourier1_btn_Save').click();
    });

</script>

<asp:HiddenField ID="HidFY" runat="server" />
