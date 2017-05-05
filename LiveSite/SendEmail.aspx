<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendEmail.aspx.cs" Inherits="SendEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
<title></title>
</head>
<body>
<form id="form1" runat="server">
<asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
<div id="divMail" runat="server" visible = "false">


<asp:GridView ID="grdconfirm" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                            AutoGenerateColumns="false" runat="server" BackColor="AliceBlue" >
                            <Columns>
                                <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbook" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                       <%-- <asp:Label ID="lblDCdatils" Style="display: none;" runat="server" Text='<%#Eval("DCDetailID")%>'></asp:Label>
                                        <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Book Name" HeaderStyle-Width="350px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="QTY" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblqty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DISC%" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiscount" Style="text-align: right;" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RATE" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprice" Style="text-align: right;" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeliveryDate" Style="text-align: right;" runat="server" Text='<%#Eval("DeliveryDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Available Qty" HeaderStyle-Width="40px" ItemStyle-Width="40px"
                                    ItemStyle-HorizontalAlign="Center" Visible="false">
                                    <ItemTemplate>
                                         <asp:Label ID="lblDeliveryDate" Style="text-align: right;" runat="server" Text='<%#Eval("RemainQty")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

</div>
</form>
</body>
</html>
