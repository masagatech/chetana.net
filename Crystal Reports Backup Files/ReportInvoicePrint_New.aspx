<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportInvoicePrint_New.aspx.cs" Inherits="Print_ReportInvoicePrint_New" Title="Print Invoice"%>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Invoice</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <cr:crystalreportviewer id="CrptInvoice" runat="server" 
            AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" HasPrintButton = "False" HasExportButton="False"
            enabletheming="false" hasdrillupbutton="false" HasToggleGroupTreeButton="False"
            haspagenavigationbuttons="False" hasrefreshbutton="true" 
            hassearchbutton="false" hasviewlist="false" 
            haszoomfactorlist="false" height="1039px" width="773px" 
            ShowAllPageIds="True" />
    </div>
    </form>
</body>
</html>
