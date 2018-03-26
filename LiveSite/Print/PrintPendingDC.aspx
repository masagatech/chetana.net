<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintPendingDC.aspx.cs" Inherits="Print_PrintPendingDC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Css/printdata.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/printCm.js" type="text/javascript"></script>

    <title>Print</title>
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
		function clickbtn(){
		document.getElementById('btnprint').click();}
    </script>

</head>
<body onunload="clickbtn()">
    <form id="form1" runat="server">
    <div>
        <table width="780px">
            <tr>
                <td>
                    <input type="BUTTON" id="btnprint" value="Print" style="display:none;" onclick="printThis()" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <h3>
                        CHETANA BOOK DEPOT
                    </h3>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" rowspan="5">
                    <div style="float: left; width: 340px; font-size: 13px;">
                        <span id="MRname" runat="server" style="font-weight: bold;"></span>
                        <br />
                        <span id="spnaddress" runat="server"></span>
                        <br />
                         <label style="font-weight: bold; font-size: 13px;">
                                                Sp.Instruction : 
                                            </label>
                        <span id="spinstruction" style="font-size: 13px; font-weight: normal;" runat="server"></span>
                        <br />
                        <label style="font-weight: bold; font-size: 13px">
                                               Description :
                                            </label>
                        <span id="Description" style="font-size: 13px; font-weight: normal;" runat="server"></span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td align="left" valign="top">
                                <table>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px">
                                                SPECIMEN NO
                                            </label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <span id="DocumentNo" style="font-size: 13px" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label style="font-weight: bold; font-size: 13px">
                                                DATE
                                            </label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td colspan="2">
                                            <span id="Todaydate" style="font-size: 13px" runat="server"></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="780px">
            <tr>
                <td>
                    <asp:GridView ID="grdpending" CssClass="product-table" AutoGenerateColumns="false"
                        FooterStyle-CssClass="gridf" runat="server" Width="780px" ShowFooter="true" GridLines="None"
                        CellPadding="2" OnRowDataBound="grdpending_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PARTICULARS">
                                <ItemTemplate>
                                    <asp:Label ID="lblbookN" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="STANDARD" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MEDIUM" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="QUANTITY" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Right"
                                FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblqunty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalQty" Style="text-align: right;" runat="server" Text=""></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Price" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Right"
                                FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" Style="text-align: right;" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Available Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAqty" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
