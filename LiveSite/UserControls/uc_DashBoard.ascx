<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Dashboard.ascx.cs"
    Inherits="UserControls_uc_Dashboard" %>
<asp:DataList ID="DLDashboard" CellPadding="0" runat="server" RepeatColumns="4">
    <ItemTemplate>
        <div class="dashBoard">
            <table border="0" width="90%" cellpadding="0">
                <tr>
                    <td valign="top" width="70px"  height="70px">
                        <img src='<%#"Images/dash/"+Eval("Name")+".png"%>' />
                       
                    </td>
                    <td valign="bottom" align="left"> <asp:Label ID="Label1" CssClass="count" runat="server" Text='<%#Eval("Countr")%>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top:10px;" align="center">
                        <span>
                            <%#Eval("Name")%></span>
                    </td>
                </tr>
            </table>
        </div>
    </ItemTemplate>
</asp:DataList>
<asp:Label ID="lblMsg" runat="server" Text="Label" Visible="False"></asp:Label>

