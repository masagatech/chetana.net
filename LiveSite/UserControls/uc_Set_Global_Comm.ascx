<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Set_Global_Comm.ascx.cs" Inherits="UserControls_uc_Set_Comm" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>
       Add Global Commission <a href="Campaigns.aspx" title="back to campaign list"></a>
        <br />
    </div>
</div>

<asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Width="958px">
  <table width="100%" cellpadding="0" cellspacing="0">
  
  <tr>
   <td colspan="5">
       <asp:Label ID="Label2" runat="server" Text="CN Perc:" Font-Bold="True"></asp:Label> &nbsp;
       <asp:TextBox ID="txtcnper" runat="server" Width="76px" MaxLength="14"></asp:TextBox>
   </td>
  </tr>
  <tr>
  <%--
     <td width="110px" style="display:none;">
     </td>
     <td width="110px" style="display:none;">
     </td>
      --%>
     <td colspan="2" align="center">
     Discount(%)
     </td>
      <td colspan="2" align="center">
        Target(%)
     </td>
      <td colspan="2" align="center">
        Commission(%)
     </td>
     <td width="110px">
     </td>
     <td width="110px">
     </td>
  </tr>
  <tr>
  <%-- 
     <td width="110px" style="display:none;">
         SuperZone
     </td>
     <td width="110px" style="display:none;">
        Zone
     </td>
     --%>
     <td width="110px" align="center">
        From
     </td>
     <td width="110px" align="center">
        To
     </td>
     <td width="110px" align="center">
        From
     </td>
     <td width="110px" align="center">
        To
     </td>
     <td width="110px" align="center">
        Zone
     </td>
     <td width="110px" align="center">
        SuperZone
     </td>
     <td width="110px" align="center">
        Active
     </td>
     <td width="110px" align="center">
        <asp:Button ID="btnadd" CssClass="submitbtn" runat="server" Text="Save" 
             Width="74px" TabIndex="9" onclick="btnadd_Click" OnClientClick="return confirm('Do you want to Save?')" />
     </td>
  </tr>
  <tr>
  <%--
       <td style="display:none;">
         <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server" 
           DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="150px" AutoPostBack="True">
          </asp:DropDownList>
      </td>
     <td style="display:none;">
      <asp:DropDownList ID="DDLZone" runat="server" TabIndex="2" AutoPostBack="True" CssClass="ddl-form" DataTextField="ZoneName" DataValueField="ZoneID" Width="150px">
      </asp:DropDownList>
     </td>
      --%>
     <td align="center">
         <asp:TextBox ID="txtDisFrm" runat="server" Width="70px" TabIndex="0"></asp:TextBox>
     </td>
     <td align="center">
         <asp:TextBox ID="txtDisTo" runat="server" Width="70px"></asp:TextBox>
     </td>
     <td align="center">
         <asp:TextBox ID="txtTarFrm" runat="server" Width="70px"></asp:TextBox>
     </td>
     <td align="center">
         <asp:TextBox ID="txtTarTo" runat="server" Width="70px"></asp:TextBox>
     </td>
     <td align="center">
            <asp:TextBox ID="txtCommZone" runat="server" Width="70px"></asp:TextBox>
         
     </td>
     <td align="center">
         <asp:TextBox ID="txtCommSZone" runat="server" Width="70px"></asp:TextBox>
     </td>
     <td align="center">
         <asp:CheckBox ID="chkActive" runat="server" Text="" 
             oncheckedchanged="chkActive_CheckedChanged" Checked="True" />
     </td>
  </tr>
  </table>
</asp:Panel>     
  
  <p></p>
  <hr />
  <p></p>
  
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
 <asp:Panel ID="PnllGrdComm" runat="server" Width="900px">

     <div class="actiontab" style="margin-bottom: 6px; width: 940px;">
    <table align="right"  border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;" >
    <tr>
    <td align="right" width="80px"></td>
    <td align="left" width="80px">
        
    </td>
    </tr>
    </table>
    </div>
    <div>
<%--   <asp:UpdatePanel ID="upGridData" runat="server">
    <ContentTemplate>--%>
   <asp:GridView ID="GrdComm" runat="server" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
        AutoGenerateColumns="false" CellPadding="4" CssClass="product-table"  
            ShowHeader ="true"> 
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="AutoId"
            ItemStyle-HorizontalAlign="Left" Visible="false" >
                <ItemTemplate>
                    <asp:Label ID="lbl1" runat="server" Width="100px" Text='<%#Eval("AutoId")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Superzone"
            ItemStyle-HorizontalAlign="Left" Visible="false" >
                <ItemTemplate>
                    <asp:Label ID="lblszone" runat="server" Width="100px" 
                        Text='<%#Eval("Superzoneid")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Zone"
            ItemStyle-HorizontalAlign="Left" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblzone" runat="server" Width="80px" Text='<%#Eval("Zoneid")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
         
            <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Dis.From" 
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                
                        <asp:Label ID="lblDisF" runat="server" Width="50px" Text='<%#Eval("discfromamt","{0:0.00}")%>'></asp:Label>
                        
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
             </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Dis.To" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                
                    <asp:Label ID="lblDisTo" runat="server" Width="50px" Text='<%#Eval("disctoamt","{0:0.00}")%>'></asp:Label>
                                    
                 </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Tar.From" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                        <asp:Label ID="lblTarFrm" runat="server" Width="50px" Text='<%#Eval("targperfrom","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Tar.To" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblTarTo" runat="server" Width="50px" Text='<%#Eval("targperto","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Zone.Comm" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblZComm" runat="server" Width="50px" Text='<%#Eval("zoneprcent","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Superzone.Comm" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                        <asp:Label ID="lblSComm" runat="server" Width="50px" Text='<%#Eval("superzoneprcent","{0:0.00}")%>'></asp:Label>
               </ItemTemplate>
                <HeaderStyle Width="50px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Active" ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkActive" Enabled="false" runat="server"  Checked='<%# Eval("IsActive").ToString() == "True" ? true : false %>' />
               </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
          </Columns>
        <AlternatingRowStyle CssClass="alt" />
    </asp:GridView>
    </div>
    <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnaddEntry" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>
    </asp:Panel>
 
</ContentTemplate>
</asp:UpdatePanel>



