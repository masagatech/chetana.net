
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_auth.aspx.cs" Inherits="_auth" %>

<%@ Register src="UserControls/uc_Login.ascx" tagname="uc_Login" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="SHORTCUT ICON" href="../Images/icon/favicon.ico"/>

    <title>Chetana:Authentication</title>
     <link rel="stylesheet" href="Css/screen.css" type="text/css" media="screen" title="default" />
    <!--  jquery core -->

    <script src="js/jquery/jquery-1.4.1.min.js" type="text/javascript"></script>

    <!-- Custom jquery scripts -->

    <script src="js/jquery/custom_jquery.js" type="text/javascript"></script>

    <!-- MUST BE THE LAST SCRIPT IN <HEAD></HEAD></HEAD> png fix -->

    <script src="js/jquery/jquery.pngFix.pack.js" type="text/javascript"></script>

    <script type="text/javascript">
$(document).ready(function(){
$(document).pngFix( );
});
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <div>
    
        <uc1:uc_Login ID="uc_Login1" runat="server" />
    
    </div>
    </form>
</body>
</html>
