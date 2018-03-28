<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_UpdatePodCourier.ascx.cs" Inherits="UserControls_uc_UpdatePodCourier" %>
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
    <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server"  style="float: left; height: 28px; margin: 0 4px 0 0; width: 500px;" >
      
      <asp:Panel ID="pnldoc123" runat="server">
        <table>
          <tr>
          <td width="60px">
              <asp:Label ID="Label1" runat="server" Text="Courier Id" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtCourierId" CssClass="inp-form" TabIndex="22" Width="80px" runat="server"></asp:TextBox>
            </td>
             <td width="10px">
            </td>
            <td width="70px">
              <asp:Label ID="Label9" runat="server" Text="Invoice No." CssClass="lbl-form"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtInvoiceNoGet" CssClass="inp-form" TabIndex="22" Width="80px" runat="server"></asp:TextBox>
            </td>
             <td width="10px">
            </td>
            
            <td width="50px">
              <asp:Label ID="Label3" runat="server" Text="Dc No." CssClass="lbl-form"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtDocNoGet" CssClass="inp-form" TabIndex="22" Width="80px" runat="server"></asp:TextBox>
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
      <div style=" float: left; margin: 15px 0 0; text-align: center; width: 70%;">
       
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
          <asp:Repeater ID="RepDetailsConfirm" runat="server" OnItemDataBound="RepDetailsConfirm_ItemDataBound"
                        OnItemCommand="RepDetailsConfirm_ItemCommand">
                        <ItemTemplate>
                            <div class="actiontab">
                                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                    <tr>
                                        <td valign="bottom">
                                            <span>Courier No :
                                                <asp:Label ID="SCMasterAutoId" Style="font-weight: bold; font-size: 13px;" runat="server"
                                                    Text='<%#Eval("SCMasterAutoId")%>'></asp:Label>
                                        </td>
                                        <%-- <td align="right">
                                            <asp:Button ID="btnConfirmed" CommandArgument='<%#Eval("SubConfirmID")%>' OnClick="btnapproval_Click" s
                                                TabIndex="3" runat="server" Text="Create Invoice" CssClass="submitbtn" Width="110px"
                                                Style="float: right;" />
                                        </td>--%>
                                    </tr>
                                </table>
                            </div>
                            <asp:GridView ID="grdCD" AlternatingRowStyle-CssClass="alt" CssClass="product-table"  AutoGenerateColumns="false" ShowFooter="true" runat="server" OnRowDataBound="grdCD_RowDataBound" >
                                   <Columns>
                                    <asp:TemplateField HeaderText="Courier ID" HeaderStyle-Width="50px">
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
                                    <asp:TemplateField HeaderText="Code" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustCode")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Party Name" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Created Date" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedOn" runat="server" Text='<%#Eval("CreatedOn")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="POD" ItemStyle-Width="70px" >
                                        <ItemTemplate>
                                        <asp:Label ID="lblAPODId" Style="text-align: none; display:none;" runat="server" Text='<%#Eval("PODId")%>'></asp:Label>
                                            <asp:TextBox ID="txtPODId" Style="width:70px;" runat="server"
                                                Text='<%#Eval("PODId")%>'></asp:TextBox>
                                            
                                            <asp:Label Style="display: none;" ID="lblPODIdZ" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblBPODId" runat="server" Text=""></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    </Columns>
                            </asp:GridView>
                            <table style="float: left;" cellspacing="2" cellpadding="2">
                                
                            </table>
                            <asp:UpdatePanel ID="updateapprove" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <table style="float: right;" cellspacing="2" cellpadding="2">
                                        
                                        <tr>
                                            <td align="left" colspan="4">
                                                <asp:Button ID="btnUpdate" CommandArgument='<%#Eval("SCMasterAutoId")%>'
                                                    TabIndex="6" runat="server" Text="Update POD" CssClass="submitbtn" Width="110px"
                                                    Style="float: right;" OnClick="btnUpdate_Click"/>
                                                 </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr style="background-color: Red" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:Repeater>
       


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