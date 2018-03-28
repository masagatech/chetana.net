<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestReportInvoice.aspx.cs"
    Inherits="TestReportInvoice" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chetana : Reports</title>
    
     <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="js/style.css" rel="stylesheet" type="text/css" />
      <script src="js/printCm.js" type="text/javascript"></script>
    
      <script type="text/javascript" language="javascript"> 
        function printThis()
        {			
			hideshowPrintBtn('none');
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
			
        }
		function hideshowPrintBtn(opt)
		{
			if (document.getElementById('printBtnDiv')!=null)
			{
				document.getElementById('printBtnDiv').style.display=opt;
			}
		}
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                </td>
                <td>
                    <asp:Button ID="BtnBookwise" runat="server" Text="Bookwise Report" OnClick="BtnBookwise_Click" />
                </td>
            </tr>
            
                <tr>
                <td>
                     <asp:DropDownList  CssClass="ddl-form" ID="DdlCustomer" runat="server" DataTextField="CustName" DataValueField="CustID">
                    </asp:DropDownList>
                </td>
                   
                <td>
                       <asp:Button ID="BtnCustomerwise" runat="server"   Text="CustomerWise Report" 
                           onclick="BtnCustomerwise_Click" />
                </td>
                <td>
                     <input type="BUTTON" value="Print this Page" onclick="printThis()"/> 
                </td>
            </tr>
        </table>
        <br />
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableDrillDown="False"
            EnableParameterPrompt="False" EnableTheming="False" EnableToolTips="False" HasDrillUpButton="False"
            HasGotoPageButton="False" HasPageNavigationButtons="False"
            HasRefreshButton="True" HasSearchButton="False" HasToggleGroupTreeButton="False"
            HasViewList="False" HasZoomFactorList="False" Height="1039px" 
            Width="773px" />
        <%-- <img src="Images/headmap2.jpg" border="0" height="65" width="541" usemap="#mymap1">
            <map name="mymap1">
            <area shape="rect" coords="80,0,410,20" href="http://www.draac.com/imagemap/index.html" target="_top">

            <!-- sample rectangle1 -->
            <area shape="rect" coords="7,40,92,62" href="http://www.draac.com/imagemap/index.html" target="_top">
            <!-- sample rectangle2 -->
            <area shape="rect" coords="135,40,380,62" href="http://www.draac.com/imagemap/main1.html" target="_top">
            <!-- sample rectangle3 -->
            <area shape="rect" coords="422,40,530,62" href="http://www.draac.com/imagemap/mapper/index.html" target="_top">
            </map>
            --%>
    </div>
    </form>
</body>
</html>
