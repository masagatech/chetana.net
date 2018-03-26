<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Sales_View_Z.ascx.cs"
    Inherits="UserControls_Salaes_View_Z" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<style>
    .nav_bar_link:focus
    {
        border: 1px solid green;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>Sales Analysis Report<a href="Campaigns.aspx"
            title="back to campaign list"> </a>
    </div>
</div>
<table width="90%">
    <tr>
        <td width="70%" valign="top">
            <asp:Panel ID="Pnldeldate" CssClass="panelDetails" runat="server">
                <table>
                    <tr>
                        <td valign="top">
                            <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="200px" DataTextField="SDZoneName"
                                DataValueField="SDZoneId" AutoPostBack="true" runat="server" TabIndex="1" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Super Duper Zone"
                                InitialValue="0" ValidationGroup="AZone123" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
                        </td>
                        <td valign="top">
                            <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                                DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="150px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please Select SuperZone"
                                InitialValue="0" ValidationGroup="AZone123" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLZone" runat="server" TabIndex="3" AutoPostBack="True" CssClass="ddl-form"
                                DataTextField="ZoneName" DataValueField="ZoneID" Width="150px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Zone"
                                InitialValue="0" ValidationGroup="AZone123" ControlToValidate="DDLZone">.</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <table cellpadding="5" cellspacing="5">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                Enabled="true"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtFromDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="Rqffdate" runat="server" ErrorMessage="Require From Date"
                                ValidationGroup="AZone123" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                                color="red">*</font> &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                Enabled="true"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttoDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require To Date"
                                ValidationGroup="AZone123" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ID="btnfind" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="AZone123"
                                Width="50px" OnClick="btnfind_Click" />
                            <asp:ValidationSummary ID="Summary1" runat="server" ShowMessageBox="true" ShowSummary="false"
                                ValidationGroup="AZone123" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:RadioButtonList ID="rdbselect" runat="server" RepeatDirection="Horizontal" CssClass="lbl-form"
                                Width="200px">
                                <asp:ListItem Value="nonzero" Text=" Active" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="zero" Text=" Non-Active"></asp:ListItem>
                                <asp:ListItem Value="both" Text=" All"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
<br />
<br />
<CR:CrystalReportViewer ID="SalesanalysisReportview" runat="server" AutoDataBind="true"
    EnableDrillDown="true" EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true"
    HasDrillUpButton="True" HasGotoPageButton="True" HasPageNavigationButtons="True"
    HasRefreshButton="true" HasSearchButton="false" HasToggleGroupTreeButton="True"
    HasZoomFactorList="false" DisplayGroupTree="False" Height="1039px" Width="773px"
    HasCrystalLogo="False" HasExportButton="False" HasPrintButton="False" />
