﻿<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SalesmanWiseBooks.aspx.cs" 
Inherits="SalesmanWiseBooks" Title="Chetana : Salesman Wise Books" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <%-- <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="js/style.css" rel="stylesheet" type="text/css" />
    <script src="js/printCm.js" type="text/javascript"></script>--%>
    
     <%-- <script type="text/javascript" language="javascript"> 
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
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
     <asp:Panel ID ="pnlsalesmanwise" CssClass="panelDetails" runat ="server">
        <table>
        <tr>
        <td>
            <asp:DropDownList  CssClass="ddl-form" TabIndex="1"  ID="DDLSalesman" width="150px" DataTextField="Name" DataValueField="EmpCode" runat="server">
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require M R" InitialValue="0"
                    ValidationGroup="S" ControlToValidate="DDLSalesman">.</asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                      <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require From Date"
                    ValidationGroup="S" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
        </td>
        
        <td>
            <asp:Label ID="Label2" runat="server" Text="TO Date" CssClass="lbl-form"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="toDate" runat="server" TargetControlID="txttoDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To Date"
                    ValidationGroup="S" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
        </td>
        </tr>
        </table>
        
        <asp:Button ID="btnget" runat="server" width="80px" Text="Get" TabIndex="4"  ValidationGroup="S" CssClass="submitbtn"
            onclick="btnget_Click" style="height: 26px" />
             
            <input id="btnprint" type="BUTTON" value="Print this Page" style="display: none" onclick="printThis()"/> 
            </asp:Panel>
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
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="S"
    runat="server" ID="ss" />

</asp:Content>

