<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_JVDelete.ascx.cs" Inherits="UserControls_uc_JVDelete" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>
         JV Delete<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
 <asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Width="922px">
  <table width="600px" cellpadding="0" cellspacing="0">
  <tr Style="display: none">
     <td width="110px">
         <asp:Label ID="LblCmpycode" CssClass="lbl-form" runat="server" Text="Company Code"></asp:Label>
         
     </td>
      <td width="150px">
        <asp:TextBox ID="TxtCmpycode"  Width="85px" CssClass="inp-form" TabIndex="1" runat="server" 
         Text= "01" Enabled="false"></asp:TextBox>
     </td>
 </tr>
  <tr Style="display: none">
     <td>
        <asp:Label ID="LblBookcode" CssClass="lbl-form" runat="server" Text="Book Code"></asp:Label>
     </td>
     <td>
        <asp:TextBox ID="TxtBookcode"  Width="85px" CssClass="inp-form" TabIndex="2" runat="server" 
        Text="J0101" Enabled="false"></asp:TextBox>
     </td>
      <td colspan="2">
        <asp:Label ID="LblBookName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server" 
        Text="Journal Book"></asp:Label>
     </td>
 </tr>
  <tr>
    <td width="110px">
        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Document No"></asp:Label>
        <font color="red">*</font>
    </td>
    <td width="110px">
        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Document Date"></asp:Label>
    </td>
    <td width="220px"></td>
    </tr>
    <tr >
    <td width="110px">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="Txtdocno"  Width="85px" CssClass="inp-form" TabIndex="3" 
                    runat="server" Enabled="true" ontextchanged="Txtdocno_TextChanged" 
                    AutoPostBack="True"></asp:TextBox>
                <%--<asp:Label ID="LblJVDetailID" CssClass="inp-form" runat="server" Style="display: none"></asp:Label>--%>
                <asp:Label ID="LblJVMasterID" CssClass="inp-form" runat="server" Style="display: none"></asp:Label>
                <asp:RequiredFieldValidator ID="reqdocno" runat="server" ErrorMessage="Require Document No "
                ValidationGroup="JVdel" ControlToValidate="Txtdocno">.</asp:RequiredFieldValidator>
            </ContentTemplate>
        </asp:UpdatePanel>
    </td>
    
    <td width="180px">
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
        <asp:TextBox ID="TxtdocDate" CssClass="inp-form" TabIndex="4" Width="85px" runat="server"
            Enabled="false"></asp:TextBox>
        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtdocDate"
            Format="dd/MM/yyyy" />
        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="TxtdocDate"
            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
            AutoComplete="true" CultureName="en-US" />
        (dd/mm/yyyy)
        <%--<asp:RequiredFieldValidator ID="reqdocDate" runat="server" ErrorMessage="Require Document Date "
            ValidationGroup="JVdel" ControlToValidate="TxtdocDate">.</asp:RequiredFieldValidator>--%>
         </ContentTemplate>
    </asp:UpdatePanel>
    </td>
    <td width="220px"></td>
 </tr>
 </table>
 </asp:Panel>
    
 <p></p>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
 <asp:Panel ID="PnllGrdJv" runat="server" Width="960px">
   <div class="actiontab" style="margin-bottom: 6px; width: 960px;">
    <table align="right" width="0" border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 6px;" >
    <tr>
    <td align="right" width="80px"></td>
    <td align="right" width="80px">
        <asp:Button ID="btnDelete" OnClientClick="JavaScript:return confirm('Do you really want to delete this record?')" 
        CssClass="submitbtn" TabIndex="5" runat="server" Text="Delete" Width="80px" OnClick="btnDelete_Click" />
    </td>
    </tr>
    </table>
    </div>
    
<%--   <asp:UpdatePanel ID="upGridData" runat="server">
    <ContentTemplate>--%>
   <asp:GridView ID="GrdJV" runat="server" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
        AutoGenerateColumns="false" CellPadding="4" CssClass="product-table"  ShowHeader ="true"
        OnRowDataBound="GrdJV_RowDataBound">
        <Columns>
        
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Account Code">
                <ItemTemplate>
                    <asp:Label ID="LblJVDID" runat="server" style="display: none" Text='<%#Eval("JVDetailID	")%>'></asp:Label>
                    <asp:Label ID="LblJVMID" runat="server" style="display: none" Text='<%#Eval("JVMasterID")%>'></asp:Label>
                    <asp:Label ID="LblAcode" runat="server" Text='<%#Eval("AccountCode")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lbltotal" Style="text-align: right; font-weight: bold;" runat="server"
                        Text="Total: "></asp:Label>
                </FooterTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Account Name"
            ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblAname" runat="server" Width="392px" Text='<%#Eval("AccountName")%>'></asp:Label>
                    <asp:Label ID="LblRcode" runat="server" style="display: none" Text='<%#Eval("ReportCode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderStyle-Width="80px" HeaderText="Report Code">
                <ItemTemplate>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="DebitAmount" 
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="TxtDebit" runat="server" AutoPostBack="True" 
                        CssClass="inp-form" MaxLength="20" 
                        Style="text-align: right;"  Width="90px" Enabled="false"
                        Text='<%#Eval("DebitAmount","{0:0.00}")%>'>
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="TxtDebit" ValidChars="." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                    <asp:Label ID="LblTotalDebit" runat="server" CssClass="totaldebit" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="CreditAmount" 
                ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="TxtCredit" runat="server" AutoPostBack="True" 
                        CssClass="inp-form" MaxLength="20" 
                        Style="text-align: right;"  Width="90px" Enabled="false"
                        Text='<%#Eval("CreditAmount","{0:0.00}")%>'>
                    </asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter2" runat="server" 
                        FilterType="Custom, Numbers" TargetControlID="TxtCredit" ValidChars="." />
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                    <asp:Label ID="LblTotalCredit" runat="server" CssClass="totalcredit" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Comment">
                <ItemTemplate>
                    <asp:TextBox ID="TxtCmmt" runat="server" CssClass="inp-form" Height="20px" 
                         TextMode="MultiLine" Width="200px" Enabled="false"
                         Text='<%#Eval("Comment")%>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
          <%--  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>                  
                <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                    CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" 
                    OnClientClick="return confirm('Do you want to Delete?')" />
            </ItemTemplate>
           </asp:TemplateField>--%>
        </Columns>
        <AlternatingRowStyle CssClass="alt" />
    </asp:GridView>

    </asp:Panel>
</ContentTemplate>
</asp:UpdatePanel>

 <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Entry1"
    runat="server" ID="jvE" />
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="JVdel"
    runat="server" ID="jvdelete" /> 