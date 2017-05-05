<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
    AutoEventWireup="true" CodeFile="CustomerTODReport.aspx.cs" Inherits="CustomerTODReport" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <div style="float: right; width: 101%">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Customer TOD Report<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="700px" Height="90px">
            <table>
                <tr>
                    <td colspan="2">
                        <asp:RadioButtonList runat="server" ID="rdAorI" TextAlign="Right" RepeatDirection="Horizontal">
                            <asp:ListItem Value="All"> All</asp:ListItem>
                            <asp:ListItem Value="Individual" Selected="True"> Individual</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                            InitialValue="0" ValidationGroup="AZone" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="2" AutoPostBack="True" CssClass="ddl-form"
                            DataTextField="ZoneName" DataValueField="ZoneID" Width="200px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Height="16px" Text="Customer Category"
                            Width="100px"></asp:Label>
                        <font color="red"></font>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLCC" runat="server" AutoPostBack="true" CssClass="ddl-form"
                            DataTextField="Name" DataValueField="CMID" OnSelectedIndexChanged="DDLCC_SelectedIndexChanged"
                            TabIndex="1" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--<font color="red">*</font>--%>
                        <asp:Label ID="lblCustomer" runat="server" Text="Customer"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCustmore" runat="server" CssClass="ddl-form" DataTextField="CustName"
                            DataValueField="CustID" TabIndex="3" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="GetData"
                            Width="80px" ValidationGroup="AZone" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <CR:CrystalReportPartsViewer ID="CrystalReportPartsViewer1" runat="server" AutoDataBind="true"
            HasPageNavigationLinks="true" Height="1039px" Width="773px" OnInit="CrystalReportPartsViewer1_Init" />
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <CR:CrystalReportViewer ID="CustomerWiseAmount" runat="server" AutoDataBind="true"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="true" EnableParameterPrompt="false"
            EnableTheming="false" EnableToolTips="true" HasDrillUpButton="True" HasGotoPageButton="True"
            HasPageNavigationButtons="True" HasRefreshButton="true" HasSearchButton="false"
            HasToggleGroupTreeButton="True" HasZoomFactorList="false" DisplayGroupTree="False"
            OnNavigate="CustomerWiseAmount_Navigate" OnReportRefresh="CustomerWiseAmount_ReportRefresh"
            OnSearch="CustomerWiseAmount_Search" />
        <asp:HiddenField ID="txtIsExport" runat="server" />

        <script type="text/javascript">
        $("input[title='Export']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
        $("input[title='Print']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
        
        </script>

    </div>
</asp:Content>
