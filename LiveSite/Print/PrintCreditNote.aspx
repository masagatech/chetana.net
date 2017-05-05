<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintCreditNote.aspx.cs"
    Inherits="Print_PrintCreditNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../Css/printdata.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="js/printCm.js" type="text/javascript"></script>

    <title>Print</title>
    <style>
        .grid
        {
            font-size: 12px;
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
<body>
    <form id="form1" runat="server">
    <div>
        <table width="600px">
            <tr>
                <td>
                    <input type="BUTTON" id="btnprint" value="Print" onclick="printThis()" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <h3>
                        CREDIT NOTE
                        <br />
                    </h3>
                    <%--<h6 style="font-weight: normal">
                        <br />
                    </h6>
                    <h4></h4>--%>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <div style="float: left; width: 480px; font-size: 11px;">
                        <table>
                            <tr>
                                <td>
                                    <b>CN No: </b>
                                </td>
                                <td>
                                    <span id="crnno" runat="server"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Created On:</b>
                                </td>
                                <td>
                                    <span id="CreatedOn" runat="server"></span>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <span id="custname" runat="server"></span>
                        <br />
                        <span id="custadd" runat="server"></span>
                        <br />
                        <span id="spnaddress" runat="server"></span>
                    </div>
                    <h6 style="float: right; font-weight: normal">
                        <table>
                            <tr>
                                <td>
                                    <b>DATE </b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td colspan="2">
                                    <span id="Todaydate" runat="server"></span>
                                </td>
                            </tr>
                        </table>
                    </h6>
                </td>
            </tr>
            <tr>
                <td height="5px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdPcn" CssClass="product-table" AutoGenerateColumns="false" FooterStyle-CssClass="gridf"
                        runat="server" Width="700px" ShowFooter="true" GridLines="None" CellPadding="2"
                        OnRowDataBound="grdPcn_RowDataBound">
                        <Columns>
                            <%--<asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" >
                    <ItemTemplate>
                        <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                        <asp:Label ID="lblspecidatils" Style="display: none;" runat="server" Text='<%#Eval("SpecimenDetailID")%>'></asp:Label>
                        <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
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
                            <asp:TemplateField HeaderText="QTY" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Right"
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
                            <asp:TemplateField HeaderText="RATE" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                                HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AMOUNT" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Right"
                                FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblamt" Style="text-align: right;" runat="server" Text='<%#Eval("Amount","{0:0.00}")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lbltamt" Style="text-align: right; font-weight: bold;" runat="server"
                                        Text=""></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DISCOUNT(%)" HeaderStyle-Width="84px" ItemStyle-HorizontalAlign="right"
                                FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'
                                        HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NET AMOUNT" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="100px"
                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="right">
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
                </td>
            </tr>
            <tr>
                <td align="left">
                    Remark:
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
