    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

    <%@ Register Src="UserControls/uc_New_Header.ascx" TagName="uc_New_Header" TagPrefix="uc1" %>
    <%@ Register src="UserControls/myMenu/keybordmenu.ascx" tagname="keybordmenu" tagprefix="uc2" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Untitled Page</title>


       <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>

        <script src="js/jquery.keynav.1.1.js" type="text/javascript"></script>

    </head>
    <body>
        <form id="form1" runat="server">
        <style type="text/css">
           
        </style>
        <div id="demo1" style="position: relative; height: 200px; width: 100%;">
            <div class="keynav_box" onclick="alert(&quot;foo&quot;);" >
                0:0</div>
            <div class="keynav_box" onclick="alert(&quot;foo&quot;);" >
                0:1</div>
            <div class="keynav_box" onclick="alert(&quot;foo&quot;);">
                0:2</div>
        </div>
    <table width="200px">
    <tr><td>
    <a class="keynav_box" onclick="alert(&quot;foo&quot;);" >
                0:0</a>
    </td></tr>
    <tr><td><a class="keynav_box" onclick="alert(&quot;foo&quot;);" >
                0:0</a></td></tr>
    <tr><td><a class="keynav_box" onclick="alert(&quot;foo&quot;);" >
                0:0</a></td></tr>
    <tr><td><a class="keynav_box" onclick="alert(&quot;foo&quot;);" >
                0:0</a></td></tr>
    <tr><td><a class="keynav_box" onclick="alert(&quot;foo&quot;);" >
                0:0</a></td></tr>
    </table>
        

        <uc2:keybordmenu ID="keybordmenu1" runat="server" />
    <script type="text/javascript">
      $(document).ready(function() {
        // Initialize jQuery keyboard navigation
        $('#abc a').keynav('keynav_focusbox','keynav_box');

        // Set the first div as the one with focus, this is optional
        $('#abc a:first').removeClass().addClass('keynav_focusbox');

        // Initialize jQuery keyboard navigation
       // $('#demo2 div').keynav('keynav_focusbox','keynav_box');

        // Set the first div as the one with focus, this is optional
       // $('#demo2 div:first').removeClass().addClass('keynav_focusbox')
      });
      
      shortcut.add("Ctrl+Shift+O",function() {
document.getElementById('content').style.marginLeft = '232px';
document.getElementById('sidebar').style.display = 'block';

});
        </script>
        </form>
    </body>
    </html>
