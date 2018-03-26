<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="TokenRegisterPending.aspx.cs" Inherits="TokenRegisterPending" Title="Token Registe Pending" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Token Pending Transfer
        </div>
        <asp:Panel ID="pnlra" runat="server">
            <div style="float: right; width: 58%">
                <div id="filter" runat="server">
                </div>
            </div>
        </asp:Panel>
        <div class="options">
        </div>
    </div>
    <asp:Button ID="btnprint" runat="server" CssClass="submitbtn" Text="Transfer Token Register" OnClientClick="javascript:confirm('Do you want to transfer selected tokens?')" OnClick="btnprint_Click"
        Width="175px" />
    <br />
    <br />
    <asp:UpdatePanel ID="Updateid" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelUpdate" runat="server" Height="100px" ScrollBars="Vertical" CssClass="panelDetails">
                <table>
                    <tr>
                        <td>
                            <asp:Repeater ID="Rptrpending" runat="server">
                                <ItemTemplate>
                                <asp:CheckBox ID="chkRepeater" Text='<%#Eval("TokenNo")%>' runat="server" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
        <%--<Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnprint" EventName="click" />
        </Triggers>--%>
    </asp:UpdatePanel>
    
    
    <%--Report for transfered --%>
    <CR:CrystalReportViewer ID="TokeRegisterReport" runat="server" AutoDataBind="true"
        DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
        Width="773px" ClientTarget="Auto" HasCrystalLogo="False" />
        <asp:HiddenField ID="txtIsExport" runat="server" />
    
     <script type="text/javascript">
        $("input[title='Export']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
        $("input[title='Print']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
        
        </script>
</asp:Content>
