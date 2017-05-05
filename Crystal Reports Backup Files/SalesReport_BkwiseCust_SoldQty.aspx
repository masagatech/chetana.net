<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="SalesReport_BkwiseCust_SoldQty.aspx.cs" Inherits="SalesReport_BkwiseCust_SoldQty"
    Title="Bookwise Customer Sales Summary" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Bookwise Customer Sold Quantity Summary <a href="Campaigns.aspx" title="back to campaign list">
            </a>
        </div>
    </div>
    <div>
        <asp:Panel ID="pnldt" CssClass="panelDetails" runat="server" Width="735px">
            <table>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="pnlzone" runat="server">
                            <table>
                                <tr>
                                    <td width="110px">
                                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server"
                                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="150px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                    <td width="80px">
                                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="2" CssClass="ddl-form" DataTextField="ZoneName"
                                            DataValueField="ZoneID" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:RadioButtonList ID="RdbtnSelect" runat="server" RepeatDirection="Horizontal"
                            TabIndex="1" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="RdbtnSelect_SelectedIndexChanged">
                            <asp:ListItem Value="Bookwise" Text="Bookwise" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="BookTypewise" Text="BookTypewise"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <%--      <td width="80px" >
                    </td>--%>
                    <%--       <td width="30px" >
                    </td>--%>
                    <td width="60px">
                    </td>
                </tr>
                <div>
                    <tr>
                        <td width="10px">
                        </td>
                        <td>
                            <asp:Label ID="lblbkt" CssClass="lbl-form" runat="server" Text="Book type"></asp:Label>
                        </td>
                        <td >
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtbktype" CssClass="inp-form" AutoPostBack="true" autocomplete="off"
                                        TabIndex="2" runat="server" Enabled="true"></asp:TextBox>
                                    <div id="dvbook" class="divauto">
                                    </div>
                                    <ajaxCt:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                        ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                        CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtbktype"
                                        UseContextKey="true" ContextKey="bktype" CompletionListElementID="dvbook">
                                    </ajaxCt:AutoCompleteExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td width="10px">
                        </td>
                        <td>
                            <asp:Label ID="lblbk" CssClass="lbl-form" runat="server" Text="Book"></asp:Label>
                        </td>
                        <td >
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtbkcod" CssClass="inp-form" AutoPostBack="true" autocomplete="off"
                                        TabIndex="3" runat="server" Enabled="true"></asp:TextBox>
                                    <div id="divwidth" class="divauto">
                                    </div>
                                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                        ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                        ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbkcod"
                                        UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
                                    </ajaxCt:AutoCompleteExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td width="10px">
                        </td>
                        <td width="80px">
                            <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtfromDate" runat="server" CssClass="inp-form" Enabled="true" TabIndex="4"
                                Width="80px"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                TargetControlID="txtfromDate" />
                            <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" AcceptAMPM="true" AutoComplete="true"
                                CultureName="en-US" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                                TargetControlID="txtfromDate" />
                            <asp:RequiredFieldValidator ID="Rfvfdt" runat="server" ControlToValidate="txtfromDate"
                                ErrorMessage="Require From Date" ValidationGroup="bkwSummary">.</asp:RequiredFieldValidator>
                        </td>
                        <td width="50px">
                            <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="To Date"></asp:Label>
                        </td>
                        <td width="60px">
                            <asp:TextBox ID="txttoDate" runat="server" CssClass="inp-form" Enabled="true" 
                                TabIndex="5" Width="80px"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" 
                                Format="dd/MM/yyyy" TargetControlID="txttoDate" />
                            <ajaxCt:MaskedEditExtender ID="toDate" runat="server" AcceptAMPM="true" 
                                AutoComplete="true" CultureName="en-US" Mask="99/99/9999" MaskType="Date" 
                                MessageValidatorTip="false" TargetControlID="txttoDate" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="Rfvtdt" runat="server" ControlToValidate="txttoDate"
                                ErrorMessage="Require To Date" ValidationGroup="bkwSummary">.</asp:RequiredFieldValidator>
                        </td>
                        <td width="30px">
                            <asp:Button ID="btnget" runat="server" CssClass="submitbtn" 
                                OnClick="btnget_Click" Style="height: 26px" TabIndex="6" Text="Get" 
                                ValidationGroup="bkwSummary" Width="80px" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </div>
            </table>
        </asp:Panel>
        <br />
        <br />
        <CR:CrystalReportViewer ID="CrptBookwiseSummary" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" HasDrillUpButton="false"
            HasPageNavigationButtons="true" HasRefreshButton="true" HasSearchButton="True"
            HasViewList="false" HasZoomFactorList="false" Height="1039px" Width="773px" />
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="bkwSummary"
            runat="server" ID="ss" />
    </div>
</asp:Content>
