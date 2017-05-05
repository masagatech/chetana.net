<%@ Page Title="Commission : Bk. Seller" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
     AutoEventWireup="true" CodeFile="CommissionBkSeller.aspx.cs" Inherits="CommissionBkSeller" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 24px;
    }
</style>

    <div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Commission Book Seller<a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
</div>


    <asp:Panel ID="pnlzone" runat="server" CssClass="panelDetails" Width="570px">
    <table>
   <%-- <tr>
        <td colspan="2">
            <asp:RadioButtonList ID="RdbtnSelect" runat="server" RepeatDirection="Horizontal"
                            TabIndex="1" Width="294px" AutoPostBack="True" 
                            OnSelectedIndexChanged="RdbtnSelect_SelectedIndexChanged">
                            <asp:ListItem Value="Commission_Report" Text="Commission Report" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="Commission_Summary" Text="Commission Summary"></asp:ListItem>
            </asp:RadioButtonList>   
        </td>
        <td>
        </td>
    </tr>--%>
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
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="3" AutoPostBack="false" CssClass="ddl-form"
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
                <ajaxct:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txtFrom"
                    format="dd/MM/yyyy" />
                <ajaxct:maskededitextender id="MaskedEditExtender1" runat="server" targetcontrolid="txtFrom"
                    masktype="Date" mask="99/99/9999" acceptampm="true" messagevalidatortip="false"
                    autocomplete="true" culturename="en-GB" />
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
                <ajaxct:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtTo"
                    format="dd/MM/yyyy" />
                <ajaxct:maskededitextender id="MaskedEditExtender2" runat="server" targetcontrolid="txtTo"
                    masktype="Date" mask="99/99/9999" acceptampm="true" messagevalidatortip="false"
                    autocomplete="true" culturename="en-GB" />
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
                    Width="80px" ValidationGroup="comm" onclick="btnget_Click"  />
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
</asp:Content>

