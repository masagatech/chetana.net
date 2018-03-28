<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="PendingDC_Count.aspx.cs" Inherits="PendingDC_Count" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" 
Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlzone" runat="server" CssClass="panelDetails" >
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="S.D. Zone"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList  CssClass="ddl-form"  ID="ddlSDZone" width="200px" DataTextField="SDZoneName"
                     DataValueField="SDZoneId"  AutoPostBack="true" runat="server"  TabIndex = "1"
                OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select Super Duper Zone"
                                            InitialValue="0" ValidationGroup="AZone123" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="150px" 
                                            >
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                                            InitialValue="0" ValidationGroup="AZone123" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                                    </td>
                                     <td>
                                        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="8" runat="server" Text="Get Data"
                                            Width="80px" ValidationGroup="AZone" OnClick="btnSave_Click" />
                                    </td>
                                    
                                </tr>
                            </table>
                        </asp:Panel>
                        
                         <cr:crystalreportviewer ID="pendingdcreport" 
    runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" HasDrillUpButton="false"
            HasPageNavigationButtons="true" HasRefreshButton="true" HasSearchButton="True"
            HasToggleGroupTreeButton="False" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" ShowAllPageIds="True" />
</asp:Content>

