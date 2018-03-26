<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintPattyCash.aspx.cs" Inherits="Print_PrintPattyCash" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../Css/printdata.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="js/printCm.js" type="text/javascript"></script>
    <title>Petty Cash</title>
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
    <table width="500px">
            <tr>
                <td>
                    <input type="Button" id="btnprint" value="Print" onclick="printThis()" onclick="return btnprint_onclick()" />
                </td>
            </tr>
            <tr>
                <td>
                        <asp:GridView ID="gvAllPettyCash" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" Width="100px" PageSize="100">
        <Columns>
            <asp:TemplateField HeaderText="Voucher No" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    
                    <asp:Label ID="lblVoucherNo" runat="server" Text='<%#Eval("VoucherNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Party/Employee Name" ItemStyle-HorizontalAlign="Left"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <asp:Label ID="lblEmpId" Style="display: none" runat="server" Text='<%#Eval("EmpId") %>'></asp:Label>
                    <asp:Label ID="lblEmpname" runat="server" Text='<%#Eval("FirstName")+" "+Eval("MiddleName")+" "+Eval("LastName") %>'></asp:Label>
       <asp:Label ID="lblemp" runat="server" Text='<%#Eval("Name") %>'></asp:Label>        
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VoucherBill SubmitDate" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblVoucherdate" runat="server" Text='<%#Eval("VoucherBillSubmitDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount","{0:0.00}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Payment Date" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("PaymentDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Paid Amount" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("PaidAmount","{0:0.00}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Given From" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("GivenFrom") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <asp:Label ID="lbltype" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                </ItemTemplate>
               
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Expense Head" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <asp:Label ID="Label1" runat="server" style="display:none" Text='<%#Eval("ExpenseHead") %>'></asp:Label>
                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("Value") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
