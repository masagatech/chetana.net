
    <script src="js/jquery.tabSlideOut.v1.3.js" type="text/javascript"></script>

<script type="text/javascript">
     $(function(){
             $('.slide-out-div').tabSlideOut({
                 tabHandle: '.handle',                              //class of the element that will be your tab
                 pathToTabImage: 'images/contactusfortr.jpg',          //path to the image for the tab *required*
                 imageHeight: '170px',                               //height of tab image *required*
                 imageWidth: '27px',                               //width of tab image *required*    
                 tabLocation: 'right',                               //side of screen where tab lives, top, right, bottom, or left
                 speed: 400,                                        //speed of animation
                 action: 'click',                                   //options: 'click' or 'hover', action to trigger animation
                 topPos: '50px',                                   //position from the top
                 fixedPosition: true,                               //options: true makes it stick(fixed position) on scroll
                 onLoadSlideOut: false
             });
         });
</script>
<div class="slide-out-div">
    <a class="handle" id="slide" href="http://link-for-non-js-users">Content</a>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="keybordmenu.ascx.cs" Inherits="UserControls_myMenu_keybordmenu" %>

<script src="js/jquery.keynav.1.1.js" type="text/javascript"></script>

<script src="js/jquery.tabSlideOut.v1.3.js" type="text/javascript"></script>

<link href="Css/chat.css" rel="stylesheet" type="text/css" />



    <div id="keymenu">
        <div id="abc">
            <asp:Repeater ID="RepMenuHead" runat="server" OnItemDataBound="RepMenuHead_ItemDataBound">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><a href="#" id='<%#"M_"+Eval("MH_Id")%>'>
                        <%#Eval("MH_Name")%></a>
                        <asp:Label ID="spnMHID" Style="display: none;" runat="server" Text='<%#Eval("MH_Id")%>'></asp:Label>
                        <asp:Repeater ID="RepMenuMain" runat="server" OnItemDataBound="RepMenuMain_ItemDataBound">
                            <HeaderTemplate>
                                <ul class="width">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label Style="display: none;" ID="lblmainmenuid" runat="server" Text='<%#Eval("mainmenuid")%>'></asp:Label>
                                <li><a href="#" class="keynav_box" onclick="callmenu(this);" rel='<%#"2~"+Eval("mainmenuid")%>'
                                    id='<%#"MM_"+Eval("mainmenuid")%>'>
                                    <%#Eval("mainmenuname")%></a>
                                    <asp:Repeater ID="RepSubMenu" runat="server">
                                        <HeaderTemplate>
                                            <ul>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li><a href="#" class="keynav_box" onclick="callmenu(this);" rel='<%#"3~"+Eval("SubMenuId")%>'
                                                id='<%#"MS_"+Eval("SubMenuId")%>'>
                                                <%#Eval("SubMenuName")%></a> </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>

<div style="display: none;">
    <asp:TextBox ID="TextBox1" class="prod" runat="server"></asp:TextBox><asp:UpdatePanel
        ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>

<script type="text/javascript">
function callmenu(id)
{
var string = id.rel;
$('.prod').val(string);
document.getElementById('<%=LinkButton1.ClientID %>').click();
}

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
      
      shortcut.add("Ctrl+M",function() {

document.getElementById('keymenu').style.display = 'block';

});
</script>

</div>