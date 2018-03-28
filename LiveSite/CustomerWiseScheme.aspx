<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="CustomerWiseScheme.aspx.cs" Inherits="CustomerWiseScheme" Title="CustomerWise Scheme" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div">
        <div class="section-header">
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                CustomerWise Scheme<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="590px">
            <table>
                <tr>
                    <td>
                        <asp:Panel ID="pnlcustomer" runat="server">
                            <table>
                                <tr>
                                    <td width="95px">
                                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Scheme"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="DDLScheme" Width="200px" DataTextField="value"
                                            DataValueField="AutoID" TabIndex="3" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                     <td>
                                        <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="3" AutoPostBack="True" CssClass="ddl-form"
                                            DataTextField="ZoneName" DataValueField="ZoneID" Width="200px">
                                        </asp:DropDownList>
                                   </td>
                                    <td>
                                     <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="8" runat="server" Text="Get Data"
                                            Width="80px" ValidationGroup="AZone" OnClick="btnSave_Click" />
                                    </td>
                               </tr>
                               
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
               </table>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <CR:CrystalReportViewer ID="SchemeReportView" runat="server" AutoDataBind="true"
             EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" HasDrillUpButton="false"
            HasPageNavigationButtons="true" HasRefreshButton="true" HasSearchButton="True"
            HasToggleGroupTreeButton="False"  HasZoomFactorList="false"
            Height="1039px"  ShowAllPageIds="True" DisplayGroupTree="False" />
    </div>
</asp:Content>
