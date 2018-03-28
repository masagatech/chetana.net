<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_OCancelDC.ascx.cs"
    Inherits="UserControls_ODC_uc_OCancelDC_" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
        Transaction > ORDER > Cancel D.C.  <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
        <div class="options">
            <table>
                <tr>
                    <td width="100px" style="display: none;">
                        <asp:Label ID="Label1" runat="server" Text="Document No."></asp:Label>
                    </td>
                    <td width="100px" style="display: none">
                        <asp:TextBox ID="txtdocno" Width="80px" runat="server"></asp:TextBox>
                    </td>
                    <td style="display: none">
                        <asp:RequiredFieldValidator ID="reqbook" runat="server" ErrorMessage="Require Document No."
                            ValidationGroup="confirm" ControlToValidate="txtdocno">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
        <%--<a onclick="openpopup(2)" class="form-submit" width="80px" style="text-align: center;
            vertical-align: middle;">Edit</a>--%>
        <%--<asp:Button ID="btnsave" CssClass="form-submit" Width="80px" OnClick="Openpopup(2)"
            runat="server" Text="Edit" />--%>
    </div>
</div>
<br />
<asp:Panel ID="Pnlcust" CssClass="panelDetails" runat="server">
    <asp:UpdatePanel ID="Upanelcust" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Customer Code" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLCustomer" DataTextField="CustName" Width="350px" DataValueField="CustID"
                            runat="server" OnSelectedIndexChanged="DDLCustomer_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
                            InitialValue="none" ValidationGroup="DDlcust" ControlToValidate="DDLCustomer">.</asp:RequiredFieldValidator>
                    </td>
                   
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<br />
<asp:UpdatePanel ID="upOrderNO" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlconfirm" CssClass="panelDetails" runat="server">
            <table>
                <tr>
                    <td valign="top" width="80px;">
                        <b>Document No.</b>
                    </td>
                    <td>
                        <asp:Repeater ID="Rptrpending" runat="server">
                            <ItemTemplate>
                                <a class='<%#Eval("classPending")%>' href='<%#"javascript:setVal("+Eval("DocumentNo")+")" %>'>
                                    <%#Eval("DocumentNo") %></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:Panel ID="PnlInsertDocNum" runat="server" DefaultButton="BtnGetOrderDetails"
    Style="text-align: left; width: 250px;">
    <br />
    <div class="content">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbldoc" runat="server" Font-Bold="true" Font-Size="12px" Text="Enter Document No : "
                        Style="display: none" CssClass="lbl-form"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtDocumentno" Width="40px" onkeypress="return CheckNumeric(event)"
                        Style="display: none" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="BtnGetOrderDetails" CssClass="submitbtn" runat="server" Style="display: none"
                        Text="Get Details" OnClick="BtnGetOrderDetails_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
<br />
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<asp:Panel ID="Orderdetails" runat="server">

    <div id = "tabledetails" runat="server">
        <table border="1" cellpadding="2">
            <tr>
                <td class="tbllable">
                    <asp:Label ID="lbldocno" CssClass="lbl-form" Text="Document No." runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbldocumentno" CssClass="lbl-form" runat="server"></asp:Label>
                </td>
                <td class="tbllable">
                    <asp:Label ID="lbldocd" CssClass="lbl-form" Text="Document Date" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbldocdate" CssClass="lbl-form" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="display: none;">
                <td class="tbllable">
                    <asp:Label ID="lblchalan" CssClass="lbl-form" Text="Chalan No." runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblchalanno" CssClass="lbl-form" runat="server"></asp:Label>
                </td>
                <td class="tbllable">
                    <asp:Label ID="lblchalanda" CssClass="lbl-form" Text="Chalan Date" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblchaldate" CssClass="lbl-form" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbllable">
                    <asp:Label ID="lblOrder" CssClass="lbl-form" Text="Order No." runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblorderno" CssClass="lbl-form" runat="server"></asp:Label>
                </td>
                <td class="tbllable">
                    <asp:Label ID="lblOrderd" CssClass="lbl-form" Text="Canceled Date" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblcanceldate" CssClass="lbl-form" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbllable">
                    <asp:Label ID="lblsal" CssClass="lbl-form" Text="Salesman Name" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsalesman" CssClass="lbl-form" runat="server"></asp:Label>
                </td>
                <td class="tbllable">
                    <asp:Label ID="lblCust" CssClass="lbl-form" Text="Customer Name" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCustomer" CssClass="lbl-form" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tbllable">
                    <asp:Label ID="lblremarklbl" CssClass="lbl-form" Text="Remark" runat="server"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="lblremarked" CssClass="lbl-form" runat="server"></asp:Label>
                </td>
                
            </tr>
           
        </table>
    </div>
    <div class="actiontab" style="width: 800px; margin-bottom:7px"  >
        <table width="100%" border="0" cellpadding="2" cellspacing="2" >
            <tr>
             <td>
                    <asp:Label ID="lblremark" Text="Remark" CssClass="lbl-form" runat="server"></asp:Label>
                </td>
            <td>
            <asp:TextBox runat="server" ID="txtRemark" CssClass="inp-form" Width="500px"></asp:TextBox>
            </td>
                <td align="right">
                    <asp:Button ID="btncancel" CssClass="submitbtn" OnClientClick="javascript:return confirm('Are you sure you want to cancel?')"
                        Width="80px" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="grdOrderDetails" CssClass="product-table" AutoGenerateColumns="False"
        Width="800px" TabIndex="11" runat="server" AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lbldcdetailid" runat="server" Text='<%#Eval("DCDetailID")%>' style="display:none"></asp:Label>
                    <asp:Label ID="lblBookCode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Name" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Standard" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Medium" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
          
            <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="right"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                <asp:Label ID="txtquty" onkeypress="return CheckNumeric(event)" Style="text-align: right; display:none" 
                        runat="server" Text='<%#Eval("Quantity")%>' Width="40px"></asp:Label>
                    <asp:Label ID="lblAmt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Available Qty" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblavailable" Style="text-align: right;" runat="server" Width="40px"
                        Text='<%#Eval("RemainQty") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Remove" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnRemove" ImageUrl="~/Images/icon/DeleteIcon.gif" CommandName="delete"
                            OnClientClick="return confirm('Are you sure want to remove this book');" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
    
    
    </asp:Panel>
    </ContentTemplate>
    
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnGetOrderDetails" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="DDLCustomer" 
                EventName="SelectedIndexChanged" />
        </Triggers>
    
    </asp:UpdatePanel>


<script>
         function setVal(id)
         {
             document.getElementById("ctl00_ContentPlaceHolder1_uc_OCancelDC1_txtdocno").value = id;
             document.getElementById("ctl00_ContentPlaceHolder1_uc_OCancelDC1_BtnGetOrderDetails").click();
         
         }
</script>

