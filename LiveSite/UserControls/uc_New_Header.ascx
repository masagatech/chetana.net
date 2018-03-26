<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_New_Header.ascx.cs"
    Inherits="UserControls_uc_New_Header" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="upNewHeader" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="clear">
            <div id="top_menu" class="clearfix">
                <ul class="sf-menu">
                    <asp:Repeater ID="RepMenuHead" runat="server" OnItemDataBound="RepMenuHead_ItemDataBound">
                        <ItemTemplate>
                            <li class="topmenus"><a href="#" id='<%#"M_"+Eval("MH_Id")%>'>
                                <%#Eval("MH_Name")%></a>
                                <asp:Label ID="spnMHID" Style="display: none;" runat="server" Text='<%#Eval("MH_Id")%>'></asp:Label>
                                <ul onmouseout="document.getElementById('<%#"M_"+Eval("MH_Id")%>').className='Whitecolor' "
                                    onmouseover="document.getElementById('<%#"M_"+Eval("MH_Id")%>').className='select'">
                                    <asp:Repeater ID="RepMenuMain" runat="server" OnItemDataBound="RepMenuMain_ItemDataBound">
                                        <ItemTemplate>
                                            <asp:Label Style="display: none;" ID="lblmainmenuid" runat="server" Text='<%#Eval("mainmenuid")%>'></asp:Label>
                                            <li>
                                                <%--<asp:LinkButton ID="LnkLevel2Menu"  
                                                OnClientClick='<%# String.Format("fillID2({0});", Eval("mainmenuid")) %>'
                                                 class='<%#Eval("CreatedBy")%>' runat="server" CommandArgument='<%#Eval("mainmenuid")%>'
                                                    Text='<%#Eval("mainmenuname")%>'></asp:LinkButton>--%>
                                                    
                                                    <a href="javascript:void(0);" onclick='<%# String.Format("fillID2({0});", Eval("mainmenuid")) %>' class='<%#Eval("CreatedBy")%>'>
                                                    <%#Eval("mainmenuname")%>
                                                    </a>
                                                    
                                                    <%--OnClick="LnkLevel2Menu_Click"--%>
                                                <asp:Repeater ID="RepSubMenu"  runat="server">
                                                    <HeaderTemplate>
                                                        <ul class="width">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <li>
                                                          <%--  <asp:LinkButton ID="LnkLevel3Menu" OnClientClick='<%# String.Format("fillID3({0});", Eval("SubMenuId")) %>'  
                                                            
                                                            runat="server" CommandArgument='<%#Eval("SubMenuId")%>'
                                                                Text='<%#Eval("SubMenuName")%>'></asp:LinkButton>--%>
                                                                <a href="javascript:void(0);" onclick='<%# String.Format("fillID3({0});", Eval("SubMenuId")) %>' class='<%#Eval("CreatedBy")%>'>
                                                    <%#Eval("SubMenuName")%>
                                                    </a>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </ul></FooterTemplate>
                                                </asp:Repeater>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">

function fillID2(val)
{
var val1 = val;
 $(".menuid").val('2~'+val1);
 dopost();
}

function fillID3(val)
{
var val1 = val;
 $(".menuid").val('3~'+val1);
 dopost();
}
</script>
<div id="profile_info">
    <%--<img src="images/avatar.jpg" width="30px;" id="avatar" alt="avatar">--%>
    <p>
        Welcome <strong>
            <asp:Label ID="LblUserName" runat="server"></asp:Label>
        </strong>
        <asp:LinkButton ID="LnkLogOut" runat="server" OnClick="LnkLogOut_Click">Log out</asp:LinkButton><%--<a href="#">Log out?</a>--%></p>
    <p class="last_login">
        Last login: <span id="loginTime" runat="server"></span>
    </p>
   <%-- <p class="last_login" style="margin-left: 2px;">
        IP Address <span id="ipAddress" runat="server"> </span>
    </p>--%>
     <p class="last_login" style="margin-left: 2px;">
        Finacial Year <span class="Fy" id="FP" runat="server"> </span>
         <span id="spnYear" style="display:none;" runat="server" ></span>
    </p>
    
</div>
