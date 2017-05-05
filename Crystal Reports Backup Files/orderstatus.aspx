<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderstatus.aspx.cs" Inherits="adminpages_orderstatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="data">
        <style type="text/css">
            .trs
            {
            	width:100%;
            	}
            .style1
            {
                width: 86px;
                font-weight:bold;
                
            }
            .trs tr
            {
            	border:1px solid #ccc;
            	height:54px;
            
            	}
            	.Yes
            	{
            		color:Green;
            		}
            		
            		.No
            	{
            		color:Red;
            		}
            	
        </style>
        
        <asp:Panel ID="pnlconfirm" CssClass="pnldash" Width="300px" Height="300px" ScrollBars="Vertical"
            runat="server">
            <table class="trs" cellpadding="5">
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label1" runat="server" Text="Order No"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:Repeater ID="rep_DC_Details" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("OrderNo")+ " / "+ Eval("OrderDate","{0:dd-MMM-yyyy}") %>'></asp:Label><br />
                                 
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label2" runat="server" Text="Confirmed"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:Repeater ID="rep_Confirmed" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("SubConfirmID") %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label3" runat="server" Text="Get Pass Issued"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:Repeater ID="rep_Godown" runat="server">
                            <ItemTemplate>
                                 <asp:Label ID="Label5" CssClass='<%#Eval("Status") %>' runat="server" Text='<%#Eval("SubConfirmID")+ " / "+ Eval("Status") %>'></asp:Label>&nbsp;<img
                                    src='<%#"Images/"+Eval("Status") +".png"%>' /><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label4" runat="server" Text="Invoice"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:Repeater ID="rep_Invoice" runat="server">
                            <ItemTemplate>
                                
                                <asp:Label ID="Label5" CssClass='<%#Eval("Status") %>' runat="server" Text='<%#Eval("SubDocId")+ " / "+ Eval("InvoiceDate","{0:dd-MMM-yyyy}") %>'></asp:Label>&nbsp;<img
                                    src='<%#"Images/"+Eval("Status") +".png"%>' /><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
               <tr>
                    <td class="style1">
                        <asp:Label ID="Label5" runat="server" Text="Signed copy received"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:Repeater ID="rep_Cust_Status" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Label6" CssClass='<%#Eval("Status") %>' runat="server" Text='<%#Eval("SubConfirmID")+ " / "+ Eval("Status") %>'></asp:Label>&nbsp;<img
                                    src='<%#"Images/"+Eval("Status") +".png"%>' /><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
