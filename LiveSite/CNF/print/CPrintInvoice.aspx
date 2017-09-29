<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CPrintInvoice.aspx.cs" Inherits="CNF_print_CPrintInvoice" %>

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
            <%--   <CR:CrystalReportViewer ID="CrptInvoice" runat="server" AutoDataBind="true" DisplayGroupTree="false"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
            EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
            HasRefreshButton="true" HasSearchButton="false" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" ShowAllPageIds="True" /> --%>

            <CR:CrystalReportViewer ID="CrptInvoice" runat="server"
                AutoDataBind="true" displaygrouptree="false" EnableDatabaseLogonPrompt="false"
                EnableDrillDown="false" EnableParameterPrompt="false"
                EnableTheming="false" HasDrillUpButton="false"
                HasPageNavigationButtons="true" HasRefreshButton="true"
                HasSearchButton="false" hasviewlist="false"
                HasZoomFactorList="false" Height="1039px" Width="773px"
                ShowAllPageIds="True" />
        </div>
    </form>
</body>
</html>
