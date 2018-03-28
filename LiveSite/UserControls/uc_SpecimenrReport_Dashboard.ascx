<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SpecimenrReport_Dashboard.ascx.cs"
    Inherits="UserControls_uc_SpecimenrReport_Dashboard" %>
<table>
    <tr>
        <td>
            <asp:DataList ID="DLDashboard" CellPadding="0" runat="server" RepeatColumns="3">
                <ItemTemplate>
                    <div class="dashBoard">
                        <table border="0" width="90%" cellpadding="0">
                            <tr>
                                <td valign="top" width="70px" height="70px">
                                    <img src='<%#"Images/dash/"+Eval("Name")+".jpg"%>'/> 
                                </td>
                                <td valign="bottom" align="left">
                                    <asp:LinkButton CssClass="count" ID="lnkgiven" runat="server" Text='<%#Eval("Countr")%>' 
                                    style="font-size:12px; font-stretch:ultra-expanded;"
                                    onclick="lnkgiven_Click" PostBackUrl='<%#"/Website/Specimen_DashboardDetails.aspx?d="+Eval("Name")%>' ></asp:LinkButton>
                                    <asp:Label ID="Label1" CssClass="count" runat="server" Text='<%#Eval("Countr")%>'
                                        Style="display: none"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-top:10px; " align="center">
                                    <span style="font-size:12px; font-stretch:ultra-expanded; font-family:Book Antiqua; " >
                                        <%#Eval("Name")%></span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </td>
        <td>
            <asp:DataList ID="DLDashboard1" CellPadding="0" runat="server" RepeatColumns="3">
                <ItemTemplate>
                    <div class="dashBoard">
                        <table border="0" width="90%" cellpadding="0">
                            <tr>
                                <td valign="top" width="70px" height="70px">
                          
                                    <img src="Images/dash/Money-icon.png" />
                                </td>
                                <td valign="bottom" align="left">
                                    <asp:LinkButton CssClass="count" ID="lnkgiven1" runat="server" Text='<%#Eval("Countr","{0:0.00}")%>'
                                    style="font-size:12px; font-stretch:ultra-expanded;  "
                                    onclick="lnkgiven1_Click" PostBackUrl='<%#"/Website/Specimen_DashboardDetails.aspx?d="+Eval("Name")%>'></asp:LinkButton>
                                    <asp:Label ID="Label2" CssClass="count" runat="server" Text='<%#Eval("Countr")%>'
                                        Style="display: none"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-top: 10px;" align="center">
                                    <span style="font-size:12px; font-stretch:ultra-expanded; font-family:Book Antiqua;">
                                        <%#Eval("Name")%></span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
  