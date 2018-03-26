<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DC_DeleteCN.ascx.cs" Inherits="UserControls_ODC_uc_DC_DeleteCN" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<%@ Register Src="../help/helpctrl.ascx" TagName="helpctrl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>
        Delete CN <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
</div>
<div><p>
    <asp:Label ID="lblCNDate" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
</p>
</div>
<asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server" Width="863px">
    <table>
     <tr>
        <td colspan="4">
            <asp:RadioButtonList ID="RdbtnSelect" runat="server" RepeatDirection="Horizontal"
                TabIndex="1" Width="280px" AutoPostBack="True" 
                OnSelectedIndexChanged="RdbtnSelect_SelectedIndexChanged">
                <asp:ListItem Value="CN" Text="CN" Selected="True"></asp:ListItem>
                <asp:ListItem Value="CustomerwiseCN" Text="Customerwise CN"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
 
    </tr>
        <tr>
            <td width ="60px">
                <asp:Label ID="Label11" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                <font color="red">*</font>
            </td>
            <td Width="5px"></td>
            <td>
<asp:UpdatePanel ID="UpPnldate1" runat="server" >
 <ContentTemplate>
            <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server" 
                Enabled="true" ontextchanged="txtFromDate_TextChanged"></asp:TextBox>
            <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                Format="dd/MM/yyyy" />
            <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtFromDate"
                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                AutoComplete="true" CultureName="en-US" />
            <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From Date"
                ValidationGroup="dateft" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
 </ContentTemplate>
</asp:UpdatePanel>    
            </td>
              <td Width="25px"></td>
            <td width ="60px">
                <asp:Label ID="Label12" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                    color="red">*</font> &nbsp;
            </td>
            <td Width="5px"></td>
            <td>
<asp:UpdatePanel ID="UpPnldate2" runat="server" >
 <ContentTemplate>
                <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server" 
                    Enabled="true" ontextchanged="txttoDate_TextChanged"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttoDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To Date"
                    ValidationGroup="dateft" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
</ContentTemplate>
</asp:UpdatePanel>    
            </td>
              <td Width="25px"></td>
            <td>
                <asp:Button ID="btngetcust" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="dateft"
                     TabIndex="4" Width="50px" OnClick="btngetcust_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
    
 <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="dateft"
        runat="server" ID="ss" />
<p></p> 

<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
 <ContentTemplate>
<asp:Panel ID="Pnl1" CssClass="panelDetails" runat="server" Width="863px" Height="10px">
    <table>
    <tr>
         <td width ="65px">
            <asp:Label ID="Label2" runat="server" Text="Customer " CssClass="lbl-form"></asp:Label>
            <font color="red">*</font>
         </td>
         <td>
            <asp:DropDownList CssClass="ddl-form" ID="DDLCustomer" DataTextField="CustName" DataValueField="CustCode"
            runat="server" TabIndex="1" 
                 OnSelectedIndexChanged="DDLCustomer_SelectedIndexChanged"  AutoPostBack="True" 
                 width="500px">
            </asp:DropDownList>
         </td>
         <%--
         <td>
            <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
            InitialValue="0" ValidationGroup="vpcn1"  ControlToValidate="DDLCustomer">.</asp:RequiredFieldValidator>
        </td>
        --%>
    </tr>
    </table>
</asp:Panel>
    <%--
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="vpcn1"
        runat="server" ID="ss" />
     --%>  
<p></p> 
 <asp:Panel ID="Pnl2" CssClass="panelDetails" runat="server" Width="863px" 
         ScrollBars="Vertical" Height="50px">
     <table width="100%" height="auto" cellpadding="0" cellspacing="0">
    <tr>
         <asp:Panel ID="PnlCNNo" runat="server">
            <td width="70px;" valign="top">
                CN No.<font color="red">*</font>
            </td>
            <td valign="top">
                <asp:Repeater ID="RptrCN" runat="server">
                    <ItemTemplate>
                        <a class='<%#Eval("classReturnMDC")%>' title="click to get record" href='<%#"javascript:setVal("+Eval("CNNo")+")" %>'>
                            <%#Eval("CNNo")%></a>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </asp:Panel>
    </tr>
    <%--<tr>
    <asp:Panel ID="PnlCNNo2" runat="server">
        <td width="80px;" valign="top">
            CN No.
        </td>
        <td valign="top">
            <asp:Repeater ID="RptrCN2" runat="server">
                <ItemTemplate>
                    <a class="nav_bar_link" title="click to get record" href='<%#"javascript:setVal("+Eval("CNNo")+")" %>'>
                        <%#Eval("CNNo")%></a>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </asp:Panel>
    </tr>--%>
    <tr>
        <td width="100px" style="display: none">
            <asp:Label ID="Label1" runat="server" Text="CNNo."></asp:Label>
        </td>
        <td width="100px" style="display: none">
            <asp:TextBox ID="txtCnno" CssClass="inp-form" Width="80px" runat="server"></asp:TextBox>
        </td>
        <td width="100px" style="display: none">
            <asp:RequiredFieldValidator ID="reqcnno" runat="server" ErrorMessage="Require CN No."
                ValidationGroup="vpcn" ControlToValidate="txtCnno">*</asp:RequiredFieldValidator>
        </td>
        <td width="100px" style="display: none">
            <asp:Button ID="btnget" OnClick="btnget_Click" CssClass="form-submit" runat="server"
                Width="70px" Text="Get" ValidationGroup="vpcn" />
        </td>
    </tr>
</table>
 </asp:Panel>

<p></p> 
<asp:Panel ID="PnlPrint" runat="server" Width="860px">

 <div class="actiontab" style="margin-bottom: 2px;">
     <table width="900px" border="0" cellpadding="2" cellspacing="2">
            <tr>
                <td>
                    <asp:Label ID="lblCNNo" runat="server" CssClass="lbl-form" Style="display: none;" ></asp:Label>
                    <asp:Label ID="lblAuditMsg" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                </td>
                
            </tr>
        </table>
 </div>
 
 <asp:Panel ID="PnlCustDetails"  runat="server" Width="900px">
     <div class="actiontab" style="margin-bottom: 2px;">
    <table width="700px" border="0" cellpadding="2" cellspacing="2">
    <tr>
     <td>
        <asp:Label ID="label3" runat="server" CssClass="lbl-form"  Text="CN No :" Width="100px"></asp:Label>
     </td>
     <td align="left" width="850px">
        <asp:Label ID="lblviewCNNo" runat="server" CssClass="lbl-form" Width="40px" Font-Bold="True"></asp:Label>
     </td>
    </tr>
      <tr>
        <td>
            <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="Customer Name:" Width="100px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblCustName" runat="server" CssClass="lbl-form" Width="500px" Font-Bold></asp:Label>
        </td>
      </tr>
       <tr>
        <td>
            <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="Customer Address:" Width="100px"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblCustAddress" runat="server" CssClass="lbl-form" Width="710px" Font-Bold></asp:Label>
        </td>
        <td align="right">
             <asp:Button ID="btnDelete" CssClass="submitbtn" TabIndex="9" runat="server" Text="Delete"
             Width="80px" OnClick="btnDelete_Click" ValidationGroup="DCRB" Height="26px" 
             OnClientClick="JavaScript:return confirm('Do you really want to delete this record?')"/>
        </td>
       </tr>
    </table>
    </div>
 </asp:Panel>
 <p></p> 
<asp:GridView ID="grdcn" CssClass="product-table" AutoGenerateColumns="false" ShowFooter="true"
        runat="server" Width="900px" CellPadding="2" 
        onrowdatabound="grdcn_RowDataBound" >
    <Columns>
        <%--<asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" >
        <ItemTemplate>
            <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
        </ItemTemplate>
       </asp:TemplateField>--%>
                            
        <asp:TemplateField HeaderText="PARTICULARS" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="450px">
            <ItemTemplate>
                <asp:Label ID="lblbkname" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lbltotal" Style="text-align: right; font-weight: bold;" runat="server"
                    Text="Total: "></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="QTY" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="lblqty" runat="server" Text='<%#Eval("ReturnQty")%>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lbltqty" Style="text-align: right; font-weight: bold;" runat="server"
                    Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="MEDIUM" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>--%>
        
        <asp:TemplateField HeaderText="PRICE" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right"
            HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="AMOUNT" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Right"
            FooterStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="lblamt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lbltamt" Style="text-align: right; font-weight: bold;" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="DISCOUNT(%)" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="right"
            FooterStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'
                    HeaderStyle-HorizontalAlign="Left"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="NET AMOUNT"  ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"
              HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="lblnamt" Style="text-align: right;" runat="server" Text='<%#Eval("NetAmount","{0:0.00}")%>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lbltnamt" Style="text-align: right; font-weight: bold;" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Panel>
 </ContentTemplate>
</asp:UpdatePanel>  
<script>
         function setVal(id)
         {
         document.getElementById("ctl00_ContentPlaceHolder1_uc_DC_DeleteCN1_txtCnno").value = id;
         document.getElementById("ctl00_ContentPlaceHolder1_uc_DC_DeleteCN1_btnget").click();
         }
</script>