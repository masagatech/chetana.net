<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BankBook.aspx.cs" Inherits="Print_BankBook" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank Book </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <cr:crystalreportviewer id="BankLedger" runat="server"
            AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="true" 
            enabledrilldown="false" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="false" hasdrillupbutton="false" hasgotopagebutton="True" 
            haspagenavigationbuttons="True" hasrefreshbutton="true" 
            hassearchbutton="True" hastogglegrouptreebutton="False" hasviewlist="false" 
            haszoomfactorlist="True" height="1039px" width="773px" />
    </div>
    </form>
</body>
</html>
