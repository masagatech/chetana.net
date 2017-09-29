<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingDcReport.aspx.cs" Inherits="Print_PendingDcReport" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR_pending_DC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pending DC Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <CR_pending_DC:CrystalReportViewer ID="PrintDCReport" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="true" EnableDrillDown="True"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="True" HasDrillUpButton="false"
            HasGotoPageButton="True" HasPageNavigationButtons="false" HasRefreshButton="False"
            HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false"
            HasZoomFactorList="false"   />
    </div>
    </form>
</body>
</html>
