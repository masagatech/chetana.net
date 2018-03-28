<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="CustomerLabel.aspx.cs" Inherits="CustomerLabel" Title="Label Print" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Customers Label <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
    <br />
    <div>
        <asp:Panel ID="pnlsalesmanwise" CssClass="panelDetails" runat="server" Width="800px">
            <table>
                <tr>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rdbselect" TabIndex="1" RepeatDirection="Horizontal"
                            CssClass="lbl-form" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rdbselect_SelectedIndexChanged">
                            <asp:ListItem Value="Customer" Text="Customer Wise" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="Supplier" Text="Supplier Wise"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlcustomer" runat="server">
                            <table>
                                <tr>
                                <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" Width="250px" DataTextField="SuperZoneName"
                                            TabIndex="1" DataValueField="SuperZoneId" runat="server" AutoPostBack="true"
                                            onselectedindexchanged="DDLSuperZone_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require SuperZone "
                                            InitialValue="0" ValidationGroup="S1" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="ddlZone" Width="250px" DataTextField="ZoneName"
                                            TabIndex="1" DataValueField="ZoneId" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Require Zone "
                                            InitialValue="0" ValidationGroup="S1" ControlToValidate="ddlZone">.</asp:RequiredFieldValidator>
                                    </td></tr>
                                    
                                    <tr>
                                <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="DDLCC" Width="250px" DataTextField="Name"
                                            TabIndex="1" DataValueField="CMID" runat="server" AutoPostBack="true" 
                                            >
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCMID" runat="server" ErrorMessage="Customer Category "
                                            InitialValue="0" ValidationGroup="S1" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnget" runat="server" Width="60px" Text="Get" ValidationGroup="S"
                                            TabIndex="2" CssClass="submitbtn" OnClick="btnget_Click" Style="height: 26px;" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlsupplier" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="ddlSupplier" Width="250px" DataTextField="GR_HEAD"
                                            TabIndex="1" DataValueField="GRID" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Supplier "
                                            InitialValue="0" ValidationGroup="S" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnsupplier" runat="server" Width="60px" Text="Get" ValidationGroup="S"
                                            TabIndex="2" CssClass="submitbtn" OnClick="btnget_Click" Style="height: 26px;" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="S"
                runat="server" ID="ss" />
            <br />
        </asp:Panel>
    </div>
    <CR:CrystalReportViewer ID="CrCustLabel" runat="server" PrintMode="ActiveX" AutoDataBind="true"
         EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="false" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="True"  HasZoomFactorList="false"
        Height="1039px" Width="773px" />
</asp:Content>
