<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HelpDesk.aspx.cs" Inherits="Css_HelpDesk" %>

<%@ Register src="UserControls/HelpDesk.ascx" tagname="HelpDesk" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Help Desk</title>
    <link href="Css/dashcssFrontdesk.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    
    <uc1:HelpDesk ID="HelpDesk1" runat="server" />
    
    
    </form>
</body>
</html>
