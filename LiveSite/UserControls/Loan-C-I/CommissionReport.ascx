<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommissionReport.ascx.cs"
    Inherits="UserControls_Loan_C_I_CommissionReport" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<style type="text/css">
    .style1 {
        width: 24px;
    }
</style>

<asp:Panel ID="pnlzone" runat="server" CssClass="panelDetails" Width="570px">
    <table>
        <tr>
            <td colspan="2">
                <asp:RadioButtonList ID="RdbtnSelect" runat="server" RepeatDirection="Horizontal"
                    TabIndex="1" Width="294px" AutoPostBack="True"
                    OnSelectedIndexChanged="RdbtnSelect_SelectedIndexChanged">
                    <asp:ListItem Value="Commission_Report" Text="Commission Report" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="Commission_Summary" Text="Commission Summary"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
            </td>
            <td class="style1">
                <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                    DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <%--  <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                    InitialValue="0" ValidationGroup="comm" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>--%>
            </td>
            <td>
                <asp:Label ID="lblzone" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                <%--<font color="red">*</font>--%>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="3" AutoPostBack="True" CssClass="ddl-form"
                            DataTextField="ZoneName" DataValueField="ZoneID" Width="200px">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblFromdateCust" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-GB" />
                <%-- <ajaxCt:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlToValidate="txtFrom"
                                            ControlExtender="MaskedEditExtender1" CssClass="RedLabel" Display="Dynamic" EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="Invalid Date"
                                            IsValidEmpty="False" ValidationExpression="^\d{2}/\d{2}/\d{4}$">  
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                        </ajaxCt:MaskedEditValidator>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Fromdate"
                    ValidationGroup="comm" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblToDateCust" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtTo" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-GB" />
                <%-- <ajaxCt:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlToValidate="txtTo"
                                            ControlExtender="MaskedEditExtender2" CssClass="RedLabel" Display="Dynamic" EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="Invalid Date" IsValidEmpty="False" ValidationExpression="^\d{2}/\d{2}/\d{4}$">  
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                        </ajaxCt:MaskedEditValidator>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
                    ValidationGroup="comm" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnget" CssClass="submitbtn" TabIndex="8" runat="server" Text="Get Data"
                    Width="80px" ValidationGroup="comm" OnClick="btnget_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:ValidationSummary ID="VSCommission" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="comm" />

<CR:CrystalReportViewer ID="CustomerReportView" runat="server" AutoDataBind="true"
    DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
    EnableParameterPrompt="false" EnableTheming="false" HasDrillUpButton="false"
    HasPageNavigationButtons="true" HasRefreshButton="true" HasSearchButton="true"
    HasToggleGroupTreeButton="False" HasViewList="false" HasZoomFactorList="false"
    Height="1039px" Width="773px" ShowAllPageIds="True" />