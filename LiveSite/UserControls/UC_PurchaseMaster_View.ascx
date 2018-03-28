<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_PurchaseMaster_View.ascx.cs"
    Inherits="UserControls_UC_PurchaseMaster_View" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Purchase Register<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<asp:Panel ID="pnlSelection" runat="server" CssClass="panelDetails" Width="361px">
    <asp:RadioButtonList ID="rdoGetDetails" CellSpacing="10" runat="server" RepeatDirection="Horizontal"
        AutoPostBack="True" OnSelectedIndexChanged="rdoGetDetails_SelectedIndexChanged">
        <asp:ListItem Text="Book Wise" Value="0"></asp:ListItem>
        <asp:ListItem Text="Other" Value="1"></asp:ListItem>
        <asp:ListItem>All</asp:ListItem>
    </asp:RadioButtonList>
</asp:Panel>
<asp:DataList ID="gvPurchasingDashBoard" Width="400px" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
    CaptionAlign="Bottom" ShowFooter="true" CellPadding="4" CellSpacing="3" ForeColor="#333333" CssClass="purchaseregister"
    PageSize="100">
    <%-- <Columns>
        <asp:TemplateField HeaderText="Month" ItemStyle-HorizontalAlign="Left">--%>
    <ItemTemplate>
        <table width="180px">
            <tr>
                <th colspan="2">
                    <asp:Label ID="lblMonths" runat="server" Text='<%#Eval("monthINword") %>'></asp:Label>
                </th>
                
            </tr>
            <tr>
                <td colspan="2">
                    Rs. <asp:Label ID="lblName"  runat="server" Text='<%#Eval("amount","{0:0.00}") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lnkSummer" CommandArgument='<%#Eval("months") %>' CommandName='<%#Eval("years") %>'
                        runat="server" Visible='<%#Convert.ToBoolean(Eval("enab")) %>' OnClick="lnkSummer_Click">Summary</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton  ID="lnkDetails" CommandArgument='<%#Eval("months") %>' CommandName='<%#Eval("years") %>'
                        runat="server" OnClick="lnkDetails_Click" Visible='<%#Convert.ToBoolean(Eval("enab")) %>'>Detail</asp:LinkButton>
                </td>
            </tr>
        </table>
        <%--</ItemTemplate>--%>
        <%--</asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right">--%>
        <%--<ItemTemplate>--%>
        <%--</ItemTemplate>--%>
        <%--</asp:TemplateField>
        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">--%>
        <%--<ItemTemplate>--%>
        <%--</ItemTemplate>--%>
        <%--</asp:TemplateField>
        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">--%>
        <%-- <ItemTemplate>--%>
    </ItemTemplate>
    <%--</asp:TemplateField>
    </Columns>--%>
</asp:DataList>
<asp:Panel ID="Report" runat="server">
    <CR:CrystalReportViewer ID="crtcustomer" runat="server" AutoDataBind="true" DisplayGroupTree="false"
        EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
        EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
        HasRefreshButton="true" HasSearchButton="false" HasToggleGroupTreeButton="False"
        HasViewList="false" HasZoomFactorList="false" Width="773px" ShowAllPageIds="True" />
</asp:Panel>
<asp:HiddenField ID="hidMonth" runat="server" />
<asp:HiddenField ID="hidYear" runat="server" />
<asp:HiddenField ID="hidflag" runat="server" />
