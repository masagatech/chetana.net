<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintInvoice.aspx.cs" Inherits="Print_PrintInvoice" %>

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
            font-size: 13px;
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
        <table width="780px">
            <tr>
                <td>
                    <input type="BUTTON" id="btnprint" value="Print" onclick="printThis()" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <h3>
                    </h3>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" rowspan="9">
                    <div style="float: left; width: 340px; font-size: 13px;">
                        <span id="custname" runat="server" style="font-weight: bold;"></span>
                        <br />
                        <span id="custadd" runat="server"></span>
                        <br />
                        <span id="spnaddress" runat="server">asdsadsa</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td width="400px">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px">
                                                INVOICE NO
                                            </label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td width="150px">
                                            <span id="Subconfirmid" style="font-size: 13px" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px">
                                                LR NO</label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td width="100px">
                                            <span id="lrno" style="font-size: 13px" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px">
                                                DELIVERED BY
                                            </label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <span id="lbldelivered" style="font-size: 13px" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px">
                                                SALES. REP.
                                            </label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <span id="lblsales" style="font-size: 13px" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px">
                                                TRANSPORTER</label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td colspan="2">
                                            <span id="lbltransporter" style="font-size: 13px" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px">
                                                PERSON INCHARGE
                                            </label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td colspan="2">
                                            <span id="lblpersonincharge" style="font-size: 13px" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px">
                                                DATE</label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <span id="lbldate" style="font-size: 13px;" runat="server"></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="400px" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px;">
                                                D.C. NO.</label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td width="100px">
                                            <span id="orderno" style="font-size: 13px;" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px;">
                                                DATED</label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <span id="Todaydate" style="font-size: 13px;" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px;">
                                                T. NO.
                                            </label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <span id="lbltno" style="font-size: 13px;" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px;">
                                                BUNDLES</label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <span id="LBLBUNDLES" runat="server"></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="780">
            <tr>
                <td>
                    <asp:GridView ID="grdapproval" CssClass="product-table" AutoGenerateColumns="false"
                        FooterStyle-CssClass="gridf" runat="server" Width="780px" ShowFooter="true" GridLines="None"
                        CellPadding="2" OnRowDataBound="grdapproval_RowDataBound">
                        <Columns>
                            <%--<asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" >
                    <ItemTemplate>
                        <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                        <asp:Label ID="lblspecidatils" Style="display: none;" runat="server" Text='<%#Eval("SpecimenDetailID")%>'></asp:Label>
                        <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Copies" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Right"
                                FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblqunty" Style="text-align: right;" runat="server" Text='<%#Eval("AvailableQty")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%--<asp:Label ID="Label4" Style="text-align: right;" runat="server" Text="Total: "></asp:Label>--%>
                                    <asp:Label ID="lblTotalQty" Style="text-align: right;" runat="server" Text=""></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PARTICULARS" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="450px">
                                <ItemTemplate>
                                    <asp:Label ID="lblbookN" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="STD" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                                    <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>' Style="display: none"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="MEDIUM" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="  %  " HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'
                                        HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="Label42" Style="text-align: right; font-weight: bold;" runat="server"
                                        Text=" "></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                                HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GROSS AMT" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="100px"
                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="right">
                                <ItemTemplate>
                                    <asp:Label ID="lblgrAmount" Style="text-align: right;" runat="server" Text='<%#Eval("gramount","{0:0.00}")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalgramt" Style="text-align: right;" runat="server" Text=""></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Net AMOUNT" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="100px"
                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="right">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" Style="text-align: right;" runat="server" Text='<%#Eval("RevisedAmt","{0:0.00}")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalQty12" Style="text-align: right;" runat="server" Text=""></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td width="600px">
                    <label style="font-weight: bold; font-size: 13px; float: left">
                        Rupees In Words :
                    </label>
                    <span id="lblrupees" runat="server" style="float: left; font-size: 13px"></span>
                </td>
                <td>
                    <div style="float: right; padding-top: 0; font-weight: normal; font-size: 13px">
                        <table>
                            <tr>
                                <td>
                                    <b>Add. Charges/Freight</b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <span id="lblfreight" runat="server" style="float: right"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Add. Charges/Tax</b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <span id="lbltax" runat="server" style="float: right"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Total Amount</b>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <span id="Lbltotalamt" runat="server" style="float: right"></span>
                                </td>
                            </tr>
                        </table>
                    </div>
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
