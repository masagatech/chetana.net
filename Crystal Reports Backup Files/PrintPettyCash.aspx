<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintPettyCash.aspx.cs" Inherits="Print_PrintPettyCash" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Petty Cash</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <CR:CrystalReportViewer ID="PrintPettyCash" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="true" EnableDrillDown="True"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="True" HasDrillUpButton="false"
            HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="False"
            HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false"
            HasZoomFactorList="false" Height="1039px" Width="773px" />
    </div>
    </form>
</body>
</html>
