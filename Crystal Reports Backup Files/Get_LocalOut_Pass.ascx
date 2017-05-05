<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Get_LocalOut_Pass.ascx.cs"
    Inherits="Godown_Get_LocalOut_Pass" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Generate Local Out Gate Pass Report<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<div style="width: 558px">
    <asp:Button ID="btnget" Style="float: right; margin: 0px 0px 0px 2px" CssClass="submitbtn"
        TabIndex="3" runat="server" Text="Generate Report" OnClick="btnget_Click" ValidationGroup="v1" />
    <asp:ValidationSummary ID="vsummery" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="v1" />
</div>
<br />
<br />
<asp:Panel ID="pnlradio" CssClass="panelDetails" runat="server" Width="520px">
    <table cellpadding="5" cellspacing="5">
        <tr>
            <td align="left" valign="top">
                <asp:RadioButtonList CellPadding="2" CellSpacing="2" ID="rdoview" runat="server"
                    RepeatDirection="Horizontal" CssClass="lbl-form" OnSelectedIndexChanged="rdoview_SelectedIndexChanged"
                    AutoPostBack="true" Width="168px">
                    <asp:ListItem Value="Local" Text="Local" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="Out" Text="Out Station"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlradio1" CssClass="panelDetails" runat="server" Width="470px">
                    <table cellpadding="5" cellspacing="5">
                        <tr>
                            <td align="left" valign="top">
                                <asp:RadioButtonList CellPadding="2" CellSpacing="2" ID="rdoview1" runat="server"
                                    RepeatDirection="Horizontal" CssClass="lbl-form" OnSelectedIndexChanged="rdoview1_SelectedIndexChanged"
                                    AutoPostBack="true" Width="237px">
                                    <asp:ListItem Value="DocNo" Text="Doc No Wise" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="Date" Text="Date Wise"></asp:ListItem>
                                    <asp:ListItem Value="dcno" Text="DC No. Wise"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnldate" GroupingText="Select Date" CssClass="pnldash" runat="server"
                                    Visible="false" Width="250px">
                                    <table width="100%" cellpadding="3" cellspacing="3">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblFromdate" runat="server" Text="From date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTodate" runat="server" Text="To date"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtfromdate" CssClass="inp-form" runat="server"></asp:TextBox>
                                                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="txtfromdate" />
                                                <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" AcceptAMPM="true" AutoComplete="true"
                                                    CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                                                    TargetControlID="txtfromdate" />
                                                <asp:RequiredFieldValidator ID="rfvalid" runat="server" ControlToValidate="txtfromdate"
                                                    ErrorMessage="Enter From Date!!!" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txttodate" CssClass="inp-form" runat="server"></asp:TextBox>
                                                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="txttodate" />
                                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                                                    AutoComplete="true" CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                                                    TargetControlID="txttodate" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate"
                                                    ErrorMessage="Enter To Date!!!" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnldocno" GroupingText="Enter Doc No" CssClass="pnldash" runat="server"
                                    Height="69px">
                                    <table width="100%" cellpadding="3" cellspacing="3">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="From Doc No"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="To Doc No"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtfdocno" CssClass="inp-form" runat="server" TabIndex="1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfdocno"
                                                    ErrorMessage="Enter From Doc No!!!" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txttdocno" CssClass="inp-form" runat="server" TabIndex="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttdocno"
                                                    ErrorMessage="Enter To Doc No!!!" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<br />
<CR:CrystalReportViewer ID="LocalOutDocNo" runat="server" AutoDataBind="true" DisplayGroupTree="false"
    EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
    EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
    HasRefreshButton="true" HasSearchButton="false" HasViewList="false" HasZoomFactorList="false"
    Height="1039px" Width="773px" ShowAllPageIds="True" />
<%--<asp:Panel ID="pnldocno" GroupingText="Enter Doc No" CssClass="pnldash" runat="server"
                    Height="69px">
                    <table width="100%" cellpadding="3" cellspacing="3">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="From Doc No"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="To Doc No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtfdocno" CssClass="inp-form" runat="server" TabIndex="1"></asp:TextBox>                               
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfdocno"
                                    ErrorMessage="Enter From Doc No!!!" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txttdocno" CssClass="inp-form" runat="server" TabIndex="2"></asp:TextBox>                               
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttdocno"
                                    ErrorMessage="Enter To Doc No!!!" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>--%>