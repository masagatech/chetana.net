<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CMSSendEmail.aspx.cs" Inherits="CMSSendEmail" %>

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
                                <asp:TemplateField HeaderText="Ticket Number" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="TktNumber3" runat="server" Text='<%#Eval("TktNumber")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Raised Date" HeaderStyle-Width="140px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="StartDate3" runat="server" Text='<%#Eval("StartDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Ticket Raised by" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="EMCODE3" Style="text-align: right;" runat="server" Text='<%#Eval("EMCODE")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Remarks3" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Party Name" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="CustName3" Style="text-align: right;" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>

</div>

<div id="divLevel1" runat="server" visible = "false">


<asp:GridView ID="gdLevel2" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                            AutoGenerateColumns="false" runat="server" BackColor="AliceBlue" >
                            <Columns>
                                <asp:TemplateField HeaderText="Ticket Number" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="TktNumber3" runat="server" Text='<%#Eval("TktNumber")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Raised Date" HeaderStyle-Width="140px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="StartDate3" runat="server" Text='<%#Eval("StartDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Ticket Raised by" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="EMCODE3" Style="text-align: right;" runat="server" Text='<%#Eval("EMCODE")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Remarks3" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Party Name" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="CustName3" Style="text-align: right;" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>

</div>
<div id="divLevel3" runat="server" visible = "false">


<asp:GridView ID="gdLevel3" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                            AutoGenerateColumns="false" runat="server" BackColor="AliceBlue" >
                            <Columns>
                                <asp:TemplateField HeaderText="Ticket Number" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="TktNumber3" runat="server" Text='<%#Eval("TktNumber")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Raised Date" HeaderStyle-Width="140px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="StartDate3" runat="server" Text='<%#Eval("StartDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Ticket Raised by" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="EMCODE3" Style="text-align: right;" runat="server" Text='<%#Eval("EMCODE")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Remarks3" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Party Name" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="CustName3" Style="text-align: right;" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>

</div>
</form>
</body>
</html>
