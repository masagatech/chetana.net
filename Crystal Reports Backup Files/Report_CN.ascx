<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Report_CN.ascx.cs" Inherits="Godown_GetLocalReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxCt" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Generate Credit Note Report<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<%--<asp:Panel ID="Panel1" runat="server" Width="540px">
<div>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem>DateWise</asp:ListItem>
        <asp:ListItem>GCNNoWise</asp:ListItem>
    </asp:RadioButtonList>
</div>
</asp:Panel>--%>
<%--<asp:Panel ID="pnldate" runat="server" Width="540px">
<table>
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
</tr>
</table>
</asp:Panel>--%>
<div style="width: 558px">
    <asp:Button ID="btnreport" Style="float: right;" runat="server" OnClick="btnreport_Click"
        Text="GenerateReport" CssClass="submitbtn" TabIndex="3" />
</div>
<br />
<br />
<asp:Panel ID="pnlradio" runat="server" Width="520px" CssClass="panelDetails" BorderStyle="None">
    <table cellpadding="3" cellspacing="3">
        <tr>
            <td valign="top">
                <asp:RadioButtonList CellPadding="5" CellSpacing="4" ID="rdoview" runat="server"
                    RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdoview_SelectedIndexChanged">
                    <asp:ListItem Value="Date" Text="Date Wise" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="GCNNO" Text="GCN No Wise"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnldate" runat="server" Width="250px" GroupingText="Select Date" Visible="true"
                    CssClass="pnldash">
                    <table  cellpadding="3" cellspacing="3">
                        <tr>
                            <td>
                                <asp:Label ID="lblFromdate" runat="server" Text="From Date"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTodate" runat="server" Text="To Date"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtfromdate" CssClass="inp-form" runat="server" TabIndex="1"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtfromdate" />
                                <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" AcceptAMPM="true" AutoComplete="true"
                                    CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                                    TargetControlID="txtfromdate" />
                                <asp:RequiredFieldValidator ID="rfvalid" runat="server" ControlToValidate="txtfromdate"
                                    ErrorMessage="Enter From Date!!!" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txttodate" CssClass="inp-form" runat="server" TabIndex="2"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txttodate" />
                                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                                    AutoComplete="true" CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                                    TargetControlID="txttodate" />
                                <asp:RequiredFieldValidator ID="rfvalid1" runat="server" ControlToValidate="txttodate"
                                    ErrorMessage="Enter To Date!!!" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlgcnno" runat="server" Width="250px" GroupingText="Select GCN No"
                    Visible="false" CssClass="pnldash">
                    <table cellpadding="3" cellspacing="3">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="From GCNNo"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="To GCNNo"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" CssClass="inp-form"  runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" CssClass="inp-form"  runat="server"></asp:TextBox>
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
<div>
    <CR:CrystalReportViewer ID="LocalGodown" runat="server" AutoDataBind="true" DisplayGroupTree="false"
        EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
        EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
        HasRefreshButton="true" HasSearchButton="false" HasViewList="false" HasZoomFactorList="false"
        Height="1039px" Width="773px" ShowAllPageIds="True" />
</div>
