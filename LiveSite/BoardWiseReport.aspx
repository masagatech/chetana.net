<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="BoardWiseReport.aspx.cs" Inherits="BoardWiseReport" Title="BoardWise Report" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            BoardWise Report <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
    <div>
        <asp:Panel ID="pnlsalesmanwise" Width="750px" CssClass="panelDetails" runat="server">
            <table border="0" width="750px" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="ddlBoard" Width="250px" DataTextField="Value"
                            DataValueField="AutoId" runat="server" TabIndex="1">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Require Board "
                            InitialValue="0" ValidationGroup="S" ControlToValidate="ddlBoard">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="250px" DataTextField="SDZoneName"
                            DataValueField="SDZoneId" AutoPostBack="true" runat="server" TabIndex="2" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Require Super Duper Zone "
                            InitialValue="0" ValidationGroup="S1" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" Width="250px" DataTextField="SuperZoneName"
                            DataValueField="SuperZoneId" AutoPostBack="true" runat="server" TabIndex="3"
                            OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require SuperZone "
                            InitialValue="0" ValidationGroup="S1" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDlZone" Width="250px" DataTextField="ZoneName"
                            TabIndex="4" DataValueField="ZoneID" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require SuperZone "
                            InitialValue="0" ValidationGroup="S3" ControlToValidate="DDlZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" TabIndex="5" ValidationGroup="S"
                            CssClass="submitbtn" OnClick="btnget_Click" Style="height: 26px" />
                    </td>
                </tr>
            </table>
           </asp:Panel>
        <asp:ValidationSummary ID="Summary1" runat="server" ShowMessageBox="true" ShowSummary="false"
            ValidationGroup="S" />
        <CR:CrystalReportViewer ID="BoardReportview" runat="server" AutoDataBind="true" DisplayGroupTree="false"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="true" EnableParameterPrompt="false"
            EnableTheming="false" EnableToolTips="true" HasDrillUpButton="True" HasGotoPageButton="True"
            HasPageNavigationButtons="True" HasRefreshButton="true" HasSearchButton="false"
            HasToggleGroupTreeButton="True" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" />
    </div>
</asp:Content>
