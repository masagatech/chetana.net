<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintSendCourier.aspx.cs" Inherits="Print_PrintSendCourier" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Print Courier</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <cr:crystalreportviewer id="LocalGodown" runat="server" 
             AutoDataBind="true"  enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" 
            enabletheming="false" hasdrillupbutton="false" 
            haspagenavigationbuttons="true" hasrefreshbutton="true" 
            hassearchbutton="false" 
            haszoomfactorlist="false" height="1039px" width="773px" 
            ShowAllPageIds="True" />
    </div>
    </form>
</body>
</html>
