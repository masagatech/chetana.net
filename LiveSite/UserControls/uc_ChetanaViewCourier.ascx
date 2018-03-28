<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ChetanaViewCourier.ascx.cs" Inherits="UserControls_uc_ChetanaViewCourier" %>
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
    <div  style="margin: -30px 0 0; position: fixed; top: 164px;left: 210.5px;" id="divLevel2" runat="server" >
   <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server"  style="float: left; height: 84px; margin: 0 4px 0 0; width: 680px;" >
      
      <asp:Panel ID="pnldoc123" runat="server">
        

          <table>          <tr>
             
            <td>
              <asp:Label ID="Label2" runat="server" Text="Courier Company" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
           <asp:DropDownList  CssClass="ddl-form" ID="ddlCourierI" DataTextField="Value" DataValueField="AutoId" TabIndex="1"
                    runat="server" ></asp:DropDownList> </td>
             
            
            <td>
              <asp:Label ID="Label11" runat="server" Text="Branch" CssClass="lbl-form"></asp:Label>
            </td>
            <td>                  
                  <asp:DropDownList  CssClass="ddl-form" ID="ddlBranchI" DataTextField="Branch" 
                      DataValueField="EmpID" TabIndex="2"
                    runat="server" ></asp:DropDownList>
                    
              </td>
            
          </tr>
          
        </table>
        <table>
          <tr>
          <td width="60px" id="CID" runat="server" visible="true">
              <asp:Label ID="Label1" runat="server" Text="Courier Id" CssClass="lbl-form"></asp:Label>
            </td>
            <td id="CIDT" runat="server" visible="true">
              <asp:TextBox ID="txtCourierId" CssClass="inp-form" TabIndex="22"  runat="server"></asp:TextBox>
            </td>
             
            <td>
              <asp:Label ID="Label9" runat="server" Text="Invoice No." CssClass="lbl-form"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtInvoiceNoGet" CssClass="inp-form" TabIndex="22" runat="server"></asp:TextBox>
            </td>
             
            
            <td>
              <asp:Label ID="Label3" runat="server" Text="Dc No." CssClass="lbl-form"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtDocNoGet" CssClass="inp-form" TabIndex="22" runat="server"></asp:TextBox>
            </td>
            
          </tr>
          
          
          <tr>
          <td>
                                        <asp:Label ID="lblFromdateCust" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Fromdate"
                                            ValidationGroup="AZone" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblToDateCust" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTo" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
                                            ValidationGroup="AZone" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
              <asp:Button ID="btnget" runat="server" Text="Get" CssClass="submitbtn" TabIndex="24"
                ValidationGroup="pdadoc" Width="50px" onclick="btnget_Click" />
            </td>
          </tr>
          </table>
      </asp:Panel>
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
        
    
    <p>
    </p>
  
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="bnkrct"
      runat="server" ID="bk" />
      
       </div>
       <div  style="margin: -30px 0 0; position: fixed; top: 164px;left: 210.5px;" id="divGeneral" runat="server" >
   <asp:Panel ID="Panel2" CssClass="panelDetails" runat="server"  style="float: left; height: 84px; margin: 0 4px 0 0; width: 690px;" >
      
      <asp:Panel ID="Panel3" runat="server">
        <table>
        <tr>
        <td width="60px" id="Td1" runat="server" visible="true">
              <asp:Label ID="lblGeneralCourierID" runat="server" Text="Courier Id" CssClass="lbl-form"></asp:Label>
            </td>
            <td id="Td2" runat="server" visible="true">
              <asp:TextBox ID="txtGeneralCourierID" CssClass="inp-form" TabIndex="22"  runat="server"></asp:TextBox>
            </td>
            </tr>
          <tr>
             
            <td width="70px">
              <asp:Label ID="Label4" runat="server" Text="Courier Company" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
           <asp:DropDownList  CssClass="ddl-form" ID="ddlCourier" DataTextField="Value" DataValueField="AutoId" TabIndex="1"
                    runat="server" ></asp:DropDownList> </td>
             
            
            <td width="50px">
              <asp:Label ID="Label5" runat="server" Text="Branch" CssClass="lbl-form"></asp:Label>
            </td>
            <td>                  
                  <asp:DropDownList  CssClass="ddl-form" ID="ddlBranch" DataTextField="Branch" 
                      DataValueField="EmpID" TabIndex="2"
                    runat="server" ></asp:DropDownList>
                    
              </td>
            
          </tr>
          <tr>
          <td>
                                        <asp:Label ID="Label6" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromGeneral" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromGeneral"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtFromGeneral"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select Fromdate"
                                            ValidationGroup="AZone" ControlToValidate="txtFromGeneral">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToGeneral" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToGeneral"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtToGeneral"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select ToDate"
                                            ValidationGroup="AZone" ControlToValidate="txtToGeneral">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
              <asp:Button ID="Button1" runat="server" Text="Get" CssClass="submitbtn" TabIndex="24"
                ValidationGroup="pdadoc" Width="50px" onclick="btnget_Click" />
            </td>
          </tr>
        </table>
      </asp:Panel>
    </asp:Panel>
   <div class="message_error" id="Div2" runat="server" visible="false">
    <table>
    <tbody>
    <tr><td>
         <asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
         </tr><tr><td>
          <asp:Label ID="Label10" runat="server" Text=""></asp:Label></td></tr>
    </tbody>
    </table>
    </div>
        
    
    <p>
    </p>
  
   
      
       </div>
       
  <div  style="margin: -30px 0 0; position: relative; top: 190px;left: -7.5px;" id="divGridInvoice" runat="server" >
         
                                
                            <asp:GridView ID="grdCD" AlternatingRowStyle-CssClass="alt" CssClass="product-table"  AutoGenerateColumns="false" ShowFooter="true" runat="server" OnRowDataBound="grdapproval_RowDataBound"
                              >
    <Columns>
    <asp:TemplateField HeaderText="Sr. No." HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                      <%#Container.DataItemIndex+1 %>  </ItemTemplate>
                                    </asp:TemplateField>
    <asp:TemplateField HeaderText="Courier ID" HeaderStyle-Width="50px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSCMasterAutoId" runat="server" Text='<%#Eval("SCMasterAutoId")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document No" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocumentNo" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice No" HeaderStyle-Width="50px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceNo" runat="server" Text='<%#Eval("InvoiceNo")%>'></asp:Label>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    
                                    <asp:TemplateField HeaderText="Party Code" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustCode")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Party Name" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Party Address" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Party Phone" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    

                                    
                                    <asp:TemplateField HeaderText="Courier Company" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblValue" runat="server" Text='<%#Eval("Value")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Name" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("Branch")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Address" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchAdd" runat="server" Text='<%#Eval("BranchAdd")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Courier Date" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedOn" runat="server" Text='<%#Eval("CreatedOn")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="POD" ItemStyle-Width="70px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPOD" runat="server" Text='<%#Eval("PODId")%>' ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Weight" ItemStyle-Width="70px" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPODss" runat="server" Text='<%#Eval("Weight")%>' ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Remark" ItemStyle-Width="70px" HeaderStyle-Width="200px"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblremark" runat="server" Text='<%#Eval("REMARK1")%>' ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Email Sent" ItemStyle-Width="70px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text="Yes" ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>--%>

                                    
                                    
                                  
                                </Columns>
      </asp:GridView>
                            
                            
       


      </div>
      <div  style="margin: -30px 0 0; position: relative; top: 190px;left: -7.5px;" id="divGridGeneral" runat="server" >
         
                                
                            <asp:GridView ID="gdGeneral" AlternatingRowStyle-CssClass="alt" CssClass="product-table"  AutoGenerateColumns="false" ShowFooter="true" runat="server" OnRowDataBound="grdapproval_RowDataBound"
                              >
    <Columns>
    <asp:TemplateField HeaderText="Sr. No." HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                      <%#Container.DataItemIndex+1 %>  </ItemTemplate>
                                    </asp:TemplateField>
    <asp:TemplateField HeaderText="Courier ID" HeaderStyle-Width="50px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSCMasterAutoId" runat="server" Text='<%#Eval("SCMasterAutoId")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    

                                    
                                    <asp:TemplateField HeaderText="Courier Company" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblValue" runat="server" Text='<%#Eval("Value")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Name" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("Branch")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Address" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchAdd" runat="server" Text='<%#Eval("BranchAdd")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Department" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Department")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Courier Date" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedOn" runat="server" Text='<%#Eval("CreatedOn")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="POD" ItemStyle-Width="70px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPOD" runat="server" Text='<%#Eval("PODId")%>' ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Weight" ItemStyle-Width="70px" HeaderStyle-Width="200px"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPODs" runat="server" Text='<%#Eval("Weight")%>' ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                             <asp:TemplateField HeaderText="Remark" ItemStyle-Width="70px" HeaderStyle-Width="200px"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblremark" runat="server" Text='<%#Eval("REMARK1")%>' ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    

                                    
                                    
                                  
                                </Columns>
      </asp:GridView>
                            
                            
       


      </div>
       
  </ContentTemplate>

</asp:UpdatePanel>

<script type="text/javascript">

    shortcut.add("Ctrl+S", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_BankReceipt1_btn_Save').click();
    });

</script>

<asp:HiddenField ID="HidFY" runat="server" />