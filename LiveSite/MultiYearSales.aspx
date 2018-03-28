<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
    AutoEventWireup="true" CodeFile="MultiYearSales.aspx.cs" Inherits="MultiYearSales" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: right; width: 101%">
        <div class="section-header">
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Multi Year Sales<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <br />
    <br />
    <asp:Panel ID="pnlzone" runat="server" CssClass="panelDetails" Width="820px">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                        DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="150px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                        InitialValue="0" ValidationGroup="AZone123" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DDLZone" runat="server" TabIndex="3" AutoPostBack="True" CssClass="ddl-form"
                        DataTextField="ZoneName" DataValueField="ZoneID" Width="150px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblCustomer" runat="server" Text="Customer"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCustmore" runat="server" TabIndex="4" CssClass="ddl-form"
                        Width="150px" DataTextField="CustName" DataValueField="CustID">
                    </asp:DropDownList>
                </td>
           
               <%-- <td>
                    <asp:DropDownList ID="ddloption" runat="server" TabIndex="5" CssClass="ddl-form"
                        Width="150px">
                        <asp:ListItem Text="Summary" Value="Summary" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Details" Value="Details"></asp:ListItem>
                    </asp:DropDownList>
                </td>--%>
                <td>
                    <asp:Button ID="btnGet" CssClass="submitbtn" TabIndex="6" runat="server" Text="Get Data"
                        Width="80px" ValidationGroup="AZone" OnClick="btnGet_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
        runat="server" ID="ValidationSummary3" />
    <CR:CrystalReportViewer ID="multiyearsale" runat="server" AutoDataBind="true" DisplayGroupTree="false"
        EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
        EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
        HasRefreshButton="true" HasSearchButton="True" HasToggleGroupTreeButton="False"
        HasViewList="false" HasZoomFactorList="false" Height="1039px" Width="773px" ShowAllPageIds="True" />
</asp:Content>
