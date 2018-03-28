<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SendCourier.ascx.cs" Inherits="UserControls_uc_SendCourier" %>
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

  <ContentTemplate><div style="margin: -30px 0 0; position: relative;">
    <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server"  style="float: left; height: 66px; margin: 0 4px 0 0; width: 370px;" >
      <table>
        <tr>
          <td>
            <asp:RadioButtonList runat="server" ID="rdbselect" TabIndex="7" RepeatDirection="Horizontal"
              CssClass="lbl-form" Width="300px" AutoPostBack="true" 
                  onselectedindexchanged="rdbselect_SelectedIndexChanged" >
              <asp:ListItem Value="InvoiceNo" Text="Invoice" Selected="True"></asp:ListItem>
             <%-- <asp:ListItem Value="General" Text="General"></asp:ListItem>--%>
            </asp:RadioButtonList>
          </td>
        </tr>
        
      </table>
      <asp:Panel ID="pnldoc123" runat="server">
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
    <p>
    </p>
  
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="bnkrct"
      runat="server" ID="bk" />
      <div style="float:left; margin: 20px 0 0;">
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
                                    
                                    
                                    <asp:TemplateField HeaderText="CustName" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Address" HeaderStyle-Width="350px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhone1" runat="server" Text='<%#Eval("Phone1")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                </Columns>
      </asp:GridView> 
       <asp:Button ID="btnSave" runat="server" Text="Save & Print" CssClass="submitbtn" Visible="false" TabIndex="24"
                ValidationGroup="pdadoc" Width="80px" onclick="btnSave_Click" />


      </div>
       </div>
  </ContentTemplate>

</asp:UpdatePanel>

<script type="text/javascript">

    shortcut.add("Ctrl+S", function () {
        document.getElementById('ctl00_ContentPlaceHolder1_uc_BankReceipt1_btn_Save').click();
    });

</script>

<asp:HiddenField ID="HidFY" runat="server" />