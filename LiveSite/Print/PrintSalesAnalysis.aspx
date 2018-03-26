<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintSalesAnalysis.aspx.cs"
    Inherits="Print_PrintSalesAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Css/printdata.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="js/printCm.js" type="text/javascript"></script>

    <title>. </title>
    <style>
        .grid
        {
            font-size: 11px;
        }
        .grid th
        {
            border-top: 1px solid #000;
            border-bottom: 1px solid #000;
        }
        .gridf
        {
            border-bottom: 1px solid #000;
            border-top: 1px solid #000;
        }
    </style>

    <script type="text/javascript" language="javascript"> 
    
        function printThis()
        {			
			document.getElementById('btnprint').style.display="none";
            var usertype=navigator.userAgent.toLowerCase();
            if (window.print) {
                window.print();
            }
            else if (usertype.indexOf("mac") != -1) {
                alert("Press 'Cmd+p' on your keyboard to print article.");
            }
            else {
                alert("Press 'Ctrl+p' on your keyboard to print article.")
            }
			document.getElementById('btnprint').style.display="visible";
        }
		function hideshowPrintBtn(opt)
		{
			if (document.getElementById('printBtnDiv')!=null)
			{
				document.getElementById('printBtnDiv').style.display=opt;
			}
		}
		
		document.getElementById('btnprint').click();
    </script>

</head>
<body >
    <form id="form1" runat="server">
    <div>
        <br />
        <table width="100%">
            <tr>
                <td>
                    <input type="BUTTON" id="btnprint" value="Print" onclick="printThis()" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <span>
                                    <label style="font-weight: bold; font-size: 15px">
                                       CHETANA BOOK DEPOT
                                    </label>
                        <br />
                             <asp:Label ID="ZoneCode" Style="font-size: 11px" runat="server" Text=" SALES ANALYSIS REPORT"></asp:Label>
                  
                       
                    
                </td>
            </tr>
        </table>
        <asp:Label ID="lblsuperzone" Style="font-size: 11px; font-weight: bold" runat="server"
            Text='<%#Eval("SuperZoneName")%>'></asp:Label>
        <asp:Repeater ID="RepDetails" runat="server" OnItemDataBound="RepDetails_ItemDataBound">
            <ItemTemplate>
                <div class="actiontab" style="margin-bottom: 2px;">
                    <table width="100%" border="0" cellpadding="2" cellspacing="2">
                        <tr>
                            <td valign="bottom">
                                <span>
                                    <label style="font-weight: bold; font-size: 11px">
                                        Zone Code :
                                    </label>
                                    <asp:Label ID="ZoneCode" Style="font-size: 11px" runat="server" Text='<%#Eval("ZoneCode") %>'></asp:Label>
                                     <asp:Label ID="Label1" Style="font-size: 11px" runat="server" Text='<%#" : "+Eval("ZoneName") %>'></asp:Label>
                            </td>
                            <%--<td align="right">
                                            <asp:Button ID="btnPrint" CommandArgument='<%#Eval("SubConfirmID")%>' OnClick="btnPrint_Click"
                                                runat="server" Text="Print" Style="float: right;" CssClass='<%#Eval("class")%>'
                                                ToolTip="click to print" />
                                        </td>--%>
                        </tr>
                    </table>
                </div>
                <asp:GridView ID="grdSalesAnalysis" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                    ShowFooter="true" AutoGenerateColumns="false" runat="server" OnRowDataBound="grdSalesAnalysis_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Cust Code" HeaderStyle-Width="80px">
                            <ItemTemplate>
                                <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustCode")%>' Style="font-size: 11px"></asp:Label>
                                <%--<asp:Label ID="lblspecidatils" Style="display: none;" runat="server" Text='<%#Eval("GanerateinvoiceId")%>'></asp:Label>
                                            <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cust Name">
                            <ItemTemplate>
                                <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Disc %" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign = "Right">
                            <ItemTemplate>
                                <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("discount","{0:0.00}")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Area Name" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblArea" runat="server" Text='<%#Eval("AreaName")%>' Style="font-size: 11px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Op.Bal." HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                            FooterStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblopbal" runat="server" Text='<%#Eval("Openingbalance","{0:0.00}")%>'
                                    HeaderStyle-HorizontalAlign="Left"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTopbal" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bill Amt" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                            FooterStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lbldebtamt" runat="server" Text='<%#Eval("DebitAmount","{0:0.00}")%>'
                                    HeaderStyle-HorizontalAlign="Left"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTBillamt" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Recd. Amt" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                            FooterStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblcramt" runat="server" Text='<%#Eval("CreditAmount","{0:0.00}")%>'
                                    HeaderStyle-HorizontalAlign="Left"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTRecdAmt" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CN. Amt" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                            FooterStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblcnamt" runat="server" Text='<%#Eval("CNAmt","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTRetamt" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bal. Amt." HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                            FooterStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblbalamt" runat="server" Text='<%#Eval("BalanceAmount","{0:0.00}")%>'
                                    HeaderStyle-HorizontalAlign="Left"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTbalamt" runat="server" Text=" Total : "></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqunty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
