<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Edit_Individual_Comm.ascx.cs" Inherits="UserControls_Edit_Indivisual_Comm" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<style type="text/css">
    .ddl-form
    {
        margin-left: 0px;
    }
    .style1
    {
        width: 200px;
    }
    .style2
    {
        width: 85px;
    }
    .submitbtn
    {
        margin-left: 0px;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>
       Edit Individual Commission <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>

<asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Width="958px">
  <table width="100%" cellpadding="0" cellspacing="0">
 <tr>
            <td class="style2">
                 <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                 <font color="red">*</font>
            </td>
            <td class="style1">
                <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                    DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
               <%--  <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                    InitialValue="0" ValidationGroup="comm" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>--%>
            </td>
            <td>
                     <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                            InitialValue="0" ValidationGroup="AZone" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
            </td>
            <td width="50px">
                <asp:Label ID="lblzone" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                <font color="red">*</font>
            </td>
            <td class="style1">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="3" AutoPostBack="True" CssClass="ddl-form"
                            DataTextField="ZoneName" DataValueField="ZoneID" Width="200px">
                        </asp:DropDownList>
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Zone"
                            InitialValue="0" ValidationGroup="AZone" ControlToValidate="DDLZone">.</asp:RequiredFieldValidator>
            </td>
            <td>
            <asp:Button ID="btnget" CssClass="submitbtn" runat="server" Text="Get" 
             Width="74px" TabIndex="9" onclick="btnget_Click"/>
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

   <asp:Panel ID="PnlAddEntry" runat="server" DefaultButton="btnget">
  </asp:Panel>

   <div class="actiontab" style="margin-bottom: 6px; width: 940px;">
    <table align="right"  border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;" >
    <tr>
    <td align="right" width="80px">
    <asp:Button ID="btnUpdate" CssClass="submitbtn" TabIndex="10" runat="server" Text="Save"
            Width="75px" ValidationGroup="Comm" onclick="btnUpdate_Click" /> 
    </td>
    <td align="left" width="80px">
       
    </td>
    </tr>
    </table>
       <asp:Label ID="Label6" runat="server" Text="CN Per :"></asp:Label>
       &nbsp;
       <asp:TextBox ID="txtcnper" runat="server" MaxLength="14" Height="20px" 
           Width="90px"></asp:TextBox>
    </div>
    <div>
<%--   <asp:UpdatePanel ID="upGridData" runat="server">
    <ContentTemplate>--%>
   <asp:GridView ID="GrdComm" runat="server" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
        AutoGenerateColumns="false" CellPadding="4" CssClass="product-table"  ShowHeader ="true"
        > 
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
                    <asp:Label ID="lblszone" runat="server" Width="100px" Text='<%#Eval("Superzoneid")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Zone"
            ItemStyle-HorizontalAlign="Left" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblzone" runat="server" Width="100px" Text='<%#Eval("Zoneid")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
         <%--   <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Report Code">
                <ItemTemplate>
                    <asp:Label ID="LblRcode" runat="server" Text='<%#Eval("Reportcode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Dis.From" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="TxtDisF" runat="server" AutoPostBack="True" CssClass="inp-form" MaxLength="14" 
                    onkeypress="return CheckNumeric(event)" Style="text-align: right;"  Width="90px"
                        Text='<%#Eval("discfromamt","{0:0.00}")%>'>
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" FilterType="Custom, Numbers" TargetControlID="TxtDisF" ValidChars="." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
             </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Dis.To" 
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="txtdisTo" runat="server" CssClass="inp-form" MaxLength="14" 
                        Style="text-align: right;"  Width="90px" Text='<%#Eval("disctoamt","{0:0.00}")%>'> </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter5" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="txtdisTo" ValidChars="." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Tar.From" 
            ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="txttarfrm" runat="server" CssClass="inp-form" MaxLength="14" 
                        Style="text-align: right;"  Width="90px" Text='<%#Eval("targperfrom","{0:0.00}")%>'>
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter6" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="txttarfrm" ValidChars="." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Tar.To">
                <ItemTemplate>
                    <asp:TextBox ID="txttarto" runat="server" CssClass="inp-form" MaxLength="14" 
                        Style="text-align: right;"  Width="90px" 
                        Text='<%#Eval("targperto","{0:0.00}")%>'>
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter7" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="txttarto" ValidChars="." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Zone.Comm">
                <ItemTemplate>
                    <asp:TextBox ID="txtzcomm" runat="server" CssClass="inp-form" MaxLength="14" 
                        Style="text-align: right;"  Width="90px" 
                        Text='<%#Eval("zoneprcent","{0:0.00}")%>'>
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter3" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="txtzcomm" ValidChars="." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Superzone.Comm">
                <ItemTemplate>
                    <asp:TextBox ID="txtscomm" runat="server" CssClass="inp-form" MaxLength="14" 
                        Style="text-align: right;"  Width="90px" 
                        Text='<%#Eval("superzoneprcent","{0:0.00}")%>'>
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter4" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="txtscomm" ValidChars="." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Active">
                <ItemTemplate>
                    <asp:CheckBox ID="chkActive" runat="server"  Checked='<%# Eval("IsActive").ToString() == "True" ? true : false %>' />
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
    </asp:UpdatePanel>--%></asp:Panel>
 
</ContentTemplate>
</asp:UpdatePanel>
<div>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
</div>
