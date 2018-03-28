<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="TargetAchieveMent.aspx.cs" Inherits="TargetAchieveMent" Title="Target Achievement" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Target Achievement <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
    <div>
        <asp:Panel ID="pnlsalesmanwise" CssClass="panelDetails" runat="server" Width="660px">
            <table>
                <tr>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rdbselect" TabIndex="1" RepeatDirection="Horizontal"
                            CssClass="lbl-form" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rdbselect_SelectedIndexChanged">
                            <asp:ListItem Value="Zone" Text="Zone Wise" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="Top" Text="Top Performance"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" Width="250px" DataTextField="SuperZoneName"
                            TabIndex="1" DataValueField="SuperZoneId" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require SuperZone "
                            InitialValue="0" ValidationGroup="S1" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox><font color="red">*</font>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtfromDate"
                            WatermarkText="FromDate">
                        </ajaxCt:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require From Date"
                            ValidationGroup="Date" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" CssClass="inp-form" TabIndex="4" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox><font color="red">*</font>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="toDate" runat="server" TargetControlID="txtToDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <ajaxCt:TextBoxWatermarkExtender ID="wat" runat="server" TargetControlID="txtToDate"
                            WatermarkText="ToDate">
                        </ajaxCt:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To Date"
                            ValidationGroup="Date" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnget" runat="server" Width="60px" Text="Get" ValidationGroup="Date"
                            CssClass="submitbtn" OnClick="btnget_Click" Style="height: 26px;" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Date"
                runat="server" ID="ss" />
            <br />
        </asp:Panel>
    </div>
    <CR:CrystalReportViewer ID="CrTargetAchievement" runat="server" PrintMode="ActiveX"
        AutoDataBind="true" DisplayGroupTree="false" EnableDatabaseLogonPrompt="false"
        EnableDrillDown="false" EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="false"
        HasDrillUpButton="false" HasGotoPageButton="True" HasPageNavigationButtons="True"
        HasRefreshButton="true" HasSearchButton="True" HasToggleGroupTreeButton="True"
        HasViewList="false" HasZoomFactorList="false" Height="1039px" Width="773px" />
</asp:Content>
