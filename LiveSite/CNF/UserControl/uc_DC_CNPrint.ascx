<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DC_CNPrint.ascx.cs"
    Inherits="UserControls_ODC_uc_DC_CNPrint" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>View / Print CN <a href="Campaigns.aspx"
            title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
       
        <asp:Panel ID="Pnl2" CssClass="panelDetails" runat="server" Width="863px" ScrollBars="Vertical"
            Height="50px">
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
        <p>
        </p>
        <asp:Panel ID="PnlPrint" runat="server" Width="860px">
            <div class="actiontab" style="margin-bottom: 2px;">
                <table width="900px" border="0" cellpadding="2" cellspacing="2">
                    <tr>
                        <td>
                            <asp:Label ID="lblCNNo" runat="server" CssClass="lbl-form" Style="display: none;"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel ID="PnlCustDetails" runat="server" Width="900px">
                <div class="actiontab" style="margin-bottom: 2px;">
                    <table width="700px" border="0" cellpadding="2" cellspacing="2">
                        <tr>
                            <td>
                                <asp:Label ID="label3" runat="server" CssClass="lbl-form" Text="CN No :" Width="100px"></asp:Label>
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
                                <asp:Label ID="Label6" runat="server" CssClass="lbl-form" Text="Customer Address:"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCustAddress" runat="server" CssClass="lbl-form" Width="710px" Font-Bold></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Button ID="btnPrint" CssClass="submitbtn" TabIndex="9" runat="server" Text="Print"
                                    Width="80px" OnClick="btnPrint_Click" ValidationGroup="DCRB" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <p>
            </p>
            <asp:GridView ID="grdcn" CssClass="product-table" AutoGenerateColumns="false" ShowFooter="true"
                runat="server" Width="900px" CellPadding="2" OnRowDataBound="grdcn_RowDataBound">
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
                    <asp:TemplateField HeaderText="STANDARD" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblstandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QTY" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right"
                        FooterStyle-HorizontalAlign="Right">
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
                  <%--  <asp:TemplateField HeaderText="AMOUNT" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblamt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltamt" Style="text-align: right; font-weight: bold;" runat="server"
                                Text=""></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>--%>
                   <%-- <asp:TemplateField HeaderText="DISCOUNT(%)" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'
                                HeaderStyle-HorizontalAlign="Left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="NET AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"
                        HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblnamt" Style="text-align: right;" runat="server" Text='<%#Eval("NetAmount","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltnamt" Style="text-align: right; font-weight: bold;" runat="server"
                                Text=""></asp:Label>
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
         document.getElementById("ctl00_ContentPlaceHolder1_uc_DC_CNPrint1_txtCnno").value = id;
         document.getElementById("ctl00_ContentPlaceHolder1_uc_DC_CNPrint1_btnget").click();
         }
</script>

