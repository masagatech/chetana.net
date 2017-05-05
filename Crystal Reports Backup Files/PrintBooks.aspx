<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintBooks.aspx.cs" Inherits="Print_PrintBooks" %>

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
		function clickbtn(){
		document.getElementById('btnprint').click();}
    </script>

</head>
<body onunload="clickbtn()">
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <input type="BUTTON" id="btnprint" value="Print" onclick="printThis()" />
                </td>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="BookSet : " Style="font-size: small"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblBookSet" runat="server" Font-Bold CssClass="lbl-form" Text=""></asp:Label>
                    </td>
                </tr>
            </tr>
        </table>
        <asp:GridView ID="grdBooksetDetails" CssClass="product-table" AutoGenerateColumns="False"
            TabIndex="4" Width="500px" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBookCode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Book Name" HeaderStyle-Width="350px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                        <asp:Label ID="lblquty" runat="server" Text="1" Style="display: none;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SellingPrice" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="txtSellingprice" runat="server" Width="60px" Style="text-align: right"
                            Text='<%#Eval ("SellingPrice","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OMPrice" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="txtOMPrice" runat="server" Width="60px" Style="text-align: right"
                            Text='<%#Eval ("OMPrice","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
