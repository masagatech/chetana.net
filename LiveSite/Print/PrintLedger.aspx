<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintLedger.aspx.cs" Inherits="Print_PrintLedger" %>

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
    
    <asp:Panel ID="pnlLedger" runat="server">
     
                
 <table width="600px">
            <tr>
                <td>
                    <input  type="BUTTON" id="btnprint" value="Print"  onclick="printThis()" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <h3>
                        CHETANA BOOK DEPOT</h3>
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
                                                Document NO
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
    <br />
        <br />
    <asp:GridView ID="gvLedger" runat="server" AutoGenerateColumns="false" CssClass="product-table"
        ShowFooter="true" ForeColor="#333333" PageSize="100" Width="700px" OnRowDataBound="gvLedger_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Date" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("LedgerDate")%>'></asp:Label>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <HeaderStyle Width="80px" />
                <FooterTemplate>
                    <asp:Label ID="lblTotalAmt" runat="server" Text="Total"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="200px" HeaderText="Client Name">
                <ItemTemplate>
                    <asp:Label ID="lblcust_id" runat="server" Style="display: none" Text='<%#Eval("CustId")%>'></asp:Label>
                    <asp:Label ID="lbl_CustName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
            </asp:TemplateField>
           <%-- <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Opening Balance" ItemStyle-HorizontalAlign="Right"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblopenbal" runat="server" Style="display: none" Text='<%#Eval("Openingbalance","{0:0.00}")%>'></asp:Label>
                    <asp:Label ID="Lbl1" runat="server" Text='<%#Eval("opbalamt")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTotalbalance" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>--%>
             <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Invoice No." ItemStyle-HorizontalAlign="Left"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lbl_Amount"  runat="server" Text='<%#Eval("otherId")%>'></asp:Label>
                    <%--<asp:Label ID="Label2" runat="server" Text='<%#Eval("crAmount")%>'></asp:Label>--%>
                </ItemTemplate>
               
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Invoice Amount" ItemStyle-HorizontalAlign="Right"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblche_no" Style="display: none" runat="server" Text='<%#Eval("DebitAmount","{0:0.00}")%>'></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("DrAmount")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTotaldebitAmt" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
           
            <%--<asp:TemplateField HeaderStyle-Width="80px" HeaderText="CN Amount" ItemStyle-HorizontalAlign="Right"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblCNAmount" runat="server" Style="display: none" Text='<%#Eval("CNAmt","{0:0.00}")%>'></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("CNAmount")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTotalCNAmt" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>--%>
           <%-- <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Years" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lbl_deposit" runat="server" Text='<%#Eval("FinancialYearFrom")+"-"+Eval("FinancialYearTo")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
    <br />
    <div >
     <%--<asp:Label ID="Label5" runat="server" Text="Outstanding : "></asp:Label>
        <asp:Label ID="lblopbal1" Font-Size="12px" Font-Names="Times New Roman"  CssClass ="inp-form" runat="server" Text="" ></asp:Label>
       --%>
    </div>
    <br />
</asp:Panel>
    </div>
    </form>
</body>
</html>
