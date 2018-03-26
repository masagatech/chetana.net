<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintBook.aspx.cs" Inherits="Print_PrintBook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
<link href="../Css/printdata.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="js/printCm.js" type="text/javascript"></script>
    <title>.</title>
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
                    <asp:GridView ID="grdBookDetails" AllowPaging="true" AutoGenerateColumns="false"
            CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="2000" runat="server"
            AlternatingRowStyle-CssClass="alt"  >
            <Columns>
                <asp:TemplateField HeaderText="BookCode" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBkID" runat="server" Text='<%#Eval("BookID")%>' Style="display: none"></asp:Label>
                        <asp:Label ID="lblBkCode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BookName" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBkName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BookType" ItemStyle-Width="80px"  HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBktyp" style="width:60px;overflow:hidden;" runat="server" Text='<%#Eval("BookTypeName")%>'></asp:Label>
                        <asp:Label ID="lblbktypeId" runat="server" Style="display: none" Text='<%#Eval("BookTypeCode")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BookGroup" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBkgrp" runat="server" Text='<%#Eval("BookGroup")%>'></asp:Label>
                        <asp:Label ID="lblbkgroupId" runat="server" Style="display: none" Text='<%#Eval("BookGroupCode")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Standard" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStd" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblMdm" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label> 
                        <asp:CheckBox style="display:none;" ID="chkUR" runat="server" Checked='<%#Eval("UpdateRate") %>' Enabled="false">
                        </asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
             <%--   <asp:TemplateField HeaderText="UpdateRate" HeaderStyle-Width="55px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                       
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="P.Price" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPP" runat="server" Text='<%#Eval("PurchasePrice","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="S.Price" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSP" runat="server" Text='<%#Eval("SellingPrice","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OM.Price" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblOMP" runat="server" Text='<%#Eval("OMPrice","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OI.Price" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblOIP" runat="server" Text='<%#Eval("OIPrice","{0:0.00}")%>'></asp:Label>
                        <asp:CheckBox ID="chkIsActive" style="display:none" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false">
                        </asp:CheckBox>
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
