<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintReceiptBookDetails.aspx.cs" Inherits="Print_PrintReceiptBookDetails" Title="Print ReceiptBook" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">




<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

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
function btnprint_onclick() {

}

    </script>
</head>
<body onunload="clickbtn()">
    <form id="form1" runat="server">
    <div>
          
          <table width="600px">
            <tr>
                <td>
                    <input type="BUTTON" id="btnprint" value="Print" onclick="printThis()" onclick="return btnprint_onclick()" />
                </td>
            </tr>
            <tr>
                
               
                <td>
                    <asp:GridView ID="gvshow" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
                            CellPadding="4" CssClass="product-table" ForeColor="#333333"
                            PageSize="100">
                            <Columns>
                                <asp:TemplateField HeaderText="Receipt Nos">
                                    <ItemTemplate>
                                        <asp:Label ID="lblid" runat="server" Style="display: none" Text='<%#Eval("ReceiptBookID") %>'></asp:Label>
                                        <asp:Label ID="lblempid" runat="server" Style="display: none" Text='<%#Eval("EmpId") %>'></asp:Label>
                                        <asp:Label ID="lblFromNo" runat="server" Text='<%#Eval("FromNo")+"-"+Eval("ToNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Used">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkused" runat="server" Text='<%#Eval("Used") %>' CommandArgument='<%#Eval("FromNo")+"-"+Eval("ToNo") %>' CommandName="Used">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cancel">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkCancel" runat="server" Text='<%#Eval("Cancel") %>' CommandArgument='<%#Eval("FromNo")+"-"+Eval("ToNo") %>' CommandName="CancelReceipt">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pending">
                                    <ItemTemplate>
                                        <asp:Label ID="lnkPending" runat="server" Text='<%#Eval("Pending") %>'  CommandName="Pending"></asp:Label>
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


