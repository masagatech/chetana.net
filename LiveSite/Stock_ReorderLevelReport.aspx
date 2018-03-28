<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Stock_ReorderLevelReport.aspx.cs" Inherits="Stock_ReorderLevelReport"
    Title="Re-order Level Of Stock" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Re-order Level of Stock <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
    <br />
    <div>
        <asp:Panel ID="pnlstock" CssClass="panelDetails" runat="server" Width="660px">
            <table>
                <tr>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLstock" Width="250px" TabIndex="1" runat="server">
                            <asp:ListItem Text="Physical Stock" Value="physical" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Virtual Stock" Value="virtual"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require SuperZone "
                            InitialValue="0" ValidationGroup="S" ControlToValidate="DDLstock">.</asp:RequiredFieldValidator>
                    </td>
                
                    <td>
                        <asp:Label ID="lblfromdate" runat="server" Text="From Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="inp-form" TabIndex="1"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" 
                            format="dd/MM/yyyy" targetcontrolid="txtFromDate" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                            acceptampm="true" autocomplete="true" culturename="en-US" mask="99/99/9999" 
                            masktype="Date" messagevalidatortip="false" targetcontrolid="txtFromDate" />
                        <asp:RequiredFieldValidator ID="Reqtdate" runat="server" 
                            ControlToValidate="txtFromDate" ErrorMessage="Require From date" 
                            ValidationGroup="date1">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="inp-form" TabIndex="2"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" 
                            format="dd/MM/yyyy" targetcontrolid="txtToDate" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                            acceptampm="true" autocomplete="true" culturename="en-US" mask="99/99/9999" 
                            masktype="Date" messagevalidatortip="false" targetcontrolid="txtToDate" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtToDate" ErrorMessage="Require To date" 
                            ValidationGroup="date1">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnget" runat="server" CssClass="submitbtn" 
                            OnClick="btnget_Click" TabIndex="2" Text="Get" ValidationGroup="S" 
                            Width="60px" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="S"
                runat="server" ID="ss" />
            <br />
        </asp:Panel>
    </div>
    <CR:CrystalReportViewer ID="CrStock" runat="server" PrintMode="ActiveX" AutoDataBind="true"
        DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="false" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="True" HasViewList="false" HasZoomFactorList="false"
        Height="1039px" Width="773px" />
</asp:Content>
