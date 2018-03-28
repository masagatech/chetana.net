<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_FacultyReport.ascx.cs"
    Inherits="UserControls_uc_FacultyReport" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Teachers&#39; Report</div>
    <div class="options">
    </div>
</div>
<div style="padding-bottom: 10px;">
    <table cellpadding="5" cellspacing="5">
        <tr>
            <td>
                <asp:Label ID="lblSDZoneName" runat="server" Text="Super Duper Zone :"></asp:Label>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="160px" DataTextField="SDZoneName"
                            TabIndex="1" DataValueField="SDZoneId" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Super Duper Zone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="ddlSDZone">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblsuperzoe" runat="server" Text="Super Zone :"></asp:Label>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="160px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please Select SuperZone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="DDLSuperZone">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSDZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblZone" runat="server" Text="Zone :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="upanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLZone" runat="server" AutoPostBack="True" CssClass="ddl-form"
                            TabIndex="3" DataTextField="ZoneName" DataValueField="ZoneID" Width="160px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Zone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="DDLZone" Display="None">*</asp:RequiredFieldValidator>
                       --%>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlsumdet" runat="server" CssClass="ddl-form" TabIndex="4"
                            AutoPostBack="True" Width="160px" OnSelectedIndexChanged="ddlsumdet_SelectedIndexChanged">
                            <asp:ListItem Text="Summery" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Details" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="padding-left: 20px;" rowspan="2" valign="top">
                <asp:Button ID="btnGet" runat="server" Text="View" OnClick="btnGet_Click" TabIndex="5"
                    ValidationGroup="savef" CssClass="submitbtn" />
                <asp:ValidationSummary ID="vsummery" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="savef" />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <br />
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Pnlfacultyapproves" CssClass="pnldash" GroupingText="Select" runat="server"
                            Width="370px" Visible="false">
                            <br />
                            <asp:RadioButtonList ID="rdoselect" Width="400px" runat="server" CellPadding="3"
                                CellSpacing="3" RepeatColumns="4" RepeatDirection="Horizontal">
                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Pending"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Approve" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Reject"></asp:ListItem>
                            </asp:RadioButtonList>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlsumdet" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <CR:CrystalReportViewer ID="FacultyReport" runat="server" AutoDataBind="true" DisplayGroupTree="false"
                EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
                EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
                HasRefreshButton="true" HasSearchButton="false" HasViewList="false" HasZoomFactorList="false"
                Height="1039px" Width="773px" ShowAllPageIds="True" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlsumdet" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</div>
