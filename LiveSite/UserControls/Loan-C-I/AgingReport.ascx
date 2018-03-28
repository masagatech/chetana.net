<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AgingReport.ascx.cs" Inherits="UserControls_Loan_C_I_AgingReport" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Panel ID="pnlzone" CssClass="panelDetails" Width="520px" runat="server">
    <table>
        <tr>
            <td><asp:Label ID="lblFromAmount" CssClass="lbl-form" runat="server" Text="From Amount"></asp:Label></td>
            <td><asp:TextBox ID="txtFromAmount" runat="server" /></td>
            <td><asp:Label ID="lblToAmount" CssClass="lbl-form" runat="server" Text="To Amount"></asp:Label></td>
            <td><asp:TextBox ID="txtToAmount" runat="server" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                    DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                    InitialValue="0" ValidationGroup="AZone123" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
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
        <tr>
            <td width="60px">
                <asp:Label ID="lblToDateCust" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTo" onblur="ValidInYearDate(this);" CssClass="inp-form" TabIndex="6"
                    runat="server"></asp:TextBox>
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
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnget" CssClass="submitbtn" TabIndex="8" runat="server" Text="Get Data"
                    Width="80px" ValidationGroup="AZone" OnClick="btnget_Click" />
            </td>
        </tr>
    </table>
    <div >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
            ValidationGroup="AZone" ControlToValidate="txtTo"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Zone"
            ValidationGroup="AZone" ControlToValidate="DDLZone" InitialValue="0"></asp:RequiredFieldValidator>
    </div>
</asp:Panel>
<CR:CrystalReportViewer ID="crtAgging" runat="server" HasGotoPageButton="True" AutoDataBind="false"
    HasSearchButton="True" DisplayGroupTree="False" EnableDatabaseLogonPrompt="false"
    EnableDrillDown="false" HasCrystalLogo="False" EnableParameterPrompt="false"
    EnableTheming="false" EnableToolTips="false" HasDrillUpButton="False" HasPageNavigationButtons="True"
    HasRefreshButton="False" HasToggleGroupTreeButton="false" HasViewList="False"
    HasZoomFactorList="False" Width="773px" />
