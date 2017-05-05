<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_MenuesByRoleId.ascx.cs"
    Inherits="UserControls_uc_MenuesByRoleId" %>
<link href="Css/MenuCss.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="upMenuRoleById"  runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="LeftMenu">
            <h2>
                <span id="HeadDetails" runat="server">Actions</span>
            </h2>
            <asp:Repeater ID="RepGetMenu" runat="server" OnItemDataBound="RepGetMenu_ItemDataBound">
                <HeaderTemplate>
                    <table width="100%">
                        <tr id="dash">
                            <td>
                                <a href="dashboard.aspx?m=dash">Home</a>
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbllink" style="display:none" runat="server" Text='<%#Eval("Link")+"m=M" + Eval("MenuID")+"~"+ Eval("MenuLink") %>'></asp:Label>
                    <tr id='<%#"M" + Eval("MenuID") %>' title='<%#Eval("MenuLink") %>'>
                        <td>
                            <a href='<%#Eval("Link")+"m=M" + Eval("MenuID")%>'>
                                <%#Eval("MenuName") %></a>
                             
                        </td>
                    </tr>
                    
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div id="showmsg" runat="server" visible="false">
                <h2 style="color: Red">
                     Access Denied!!!
                </h2>
            </div>
        </div>
<asp:TextBox ID="txtId" style="display:none" class="menuid" runat="server"></asp:TextBox>
   </ContentTemplate>
</asp:UpdatePanel>
<%--<script type="text/javascript">
        $(document).ready(function() {
                panelsLoaded = 1;
                Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded)
        });

        function PageLoaded(sender, args) {
                console.log("I have occured " + panelsLoaded++ + " times!");

                var panelsCreated = args.get_panelsCreated();
                for (var i = 0; i < panelsCreated.length; i++) {
                        console.log("Panels Updating: " + panelsCreated[i].id);
                }

                var panelsUpdated = args.get_panelsUpdated();
                for (var i = 0; i < panelsUpdated.length; i++) {
                        console.log("Panels Updating: " + panelsUpdated[i].id);
                }
        }
    </script>--%>

<script type="text/javascript">
function dopost()

{

  sloder('Loading menues..');
setTimeout("__doPostBack('ctl00_uc_MenuesByRoleId1_upMenuRoleById', '');", 500);
setTimeout("cloder();", 600);
document.getElementById('innerCt').style.display='block';
document.getElementById('innerMain').style.display='none';
  

}




function getQuerystring(key, default_)
{
  if (default_==null) default_=""; 
  key = key.replace(/[\[]/,"\\\[").replace(/[\]]/,"\\\]");
  var regex = new RegExp("[\\?&]"+key+"=([^&#]*)");
  var qs = regex.exec(window.location.href);
  if(qs == null)
    return default_;
  else
    return qs[1];
}


var str=getQuerystring('m').toString();
document.getElementById(str).className='act';

function getme()
{
alert();
}

</script>

