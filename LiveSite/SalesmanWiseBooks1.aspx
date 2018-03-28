<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SalesmanWiseBooks1.aspx.cs" 
Inherits="SalesmanWiseBooks" Title="Chetana : Salesman Wise Books" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
        <asp:DropDownList  CssClass="ddl-form" ID="DDLSalesman" width="150px" DataTextField="Name" DataValueField="EmpCode" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnget" runat="server" width="80px" Text="Get" 
            onclick="btnget_Click" style="height: 26px" />
             
            <input id="btnprint" type="BUTTON" value="Print this Page" onclick="printThis()"/> 
      <br />
        <br />
    
    <br />
     
<cr:crystalreportviewer id="crystalreportviewer1" runat="server" 
            AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="false" hasdrillupbutton="false" hasgotopagebutton="false" 
            haspagenavigationbuttons="false" hasrefreshbutton="true" 
            hassearchbutton="false" hastogglegrouptreebutton="false" hasviewlist="false" 
            haszoomfactorlist="false" height="1039px" width="773px" />
    </div>
</asp:Content>

