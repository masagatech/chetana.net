<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Sales_Analysis_part_II.aspx.cs" Inherits="Sales_Analysis_part_II" Title="Sales Analysis Part II" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Sales Analysis Report Part II <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
    <div width="750px">
        <asp:Panel ID="pnlsalesmanwise" Width="750px" CssClass="panelDetails" runat="server">
            <table border="0" width="750px" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="250px" DataTextField="SDZoneName"
                            DataValueField="SDZoneId" AutoPostBack="true" runat="server" TabIndex="1" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Require Super Duper Zone "
                            InitialValue="0" ValidationGroup="S" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" Width="250px" DataTextField="SuperZoneName"
                            DataValueField="SuperZoneId" AutoPostBack="true" runat="server" TabIndex="2"
                            OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require SuperZone "
                            InitialValue="0" ValidationGroup="S1" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDlZone" Width="250px" DataTextField="ZoneName"
                            TabIndex="2" DataValueField="ZoneID" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require SuperZone "
                            InitialValue="0" ValidationGroup="S3" ControlToValidate="DDlZone">.</asp:RequiredFieldValidator>
                    </td>
                
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtfromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtfromDate"
                            WatermarkText="FromDate">
                        </ajaxCt:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Require From Date "
                            ValidationGroup="S" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" CssClass="inp-form" TabIndex="4" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtToDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <ajaxCt:TextBoxWatermarkExtender ID="wat" runat="server" TargetControlID="txtToDate"
                            WatermarkText="ToDate">
                        </ajaxCt:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Require To date "
                            ValidationGroup="S" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="rdbselect" runat="server" RepeatDirection="Horizontal" CssClass="lbl-form"
                            Width="250px">
                            <asp:ListItem Value="nonzero" Text=" Active" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="zero" Text=" Non-Active"></asp:ListItem>
                            <asp:ListItem Value="both" Text=" All"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" TabIndex="5" ValidationGroup="S"
                            CssClass="submitbtn" OnClick="btnget_Click" Style="height: 26px" />
                    </td>
                </tr>
            </table>
            <input id="btnprint" type="BUTTON" value="Print this Page" style="display: none"
                onclick="printThis()" /></asp:Panel>
        <asp:ValidationSummary ID="Summary1" runat="server" ShowMessageBox="true" ShowSummary="false"
            ValidationGroup="S" />
        <CR:CrystalReportViewer ID="SalesanalysisReportview" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="true"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="True"
            HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
            HasSearchButton="false" HasToggleGroupTreeButton="True" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" />
    </div>
</asp:Content>
