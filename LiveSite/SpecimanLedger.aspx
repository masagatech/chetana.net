<%@ Page Title="Speciman Ledger" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SpecimanLedger.aspx.cs" Inherits="SpecimanLedger" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .TextBoxWodth
        {
            width: 60px;
        }

        .TextBoxWodths
        {
            width: 84px;
        }

        .panelDetail
        {
            border: 1px solid #9C9C9C;
            background-color: #EEE;
            width: 820px;
            padding: 1.5em 18px;
            background: #008800;
            background: -moz-linear-gradient(top, #BDBDBD, #9C9C9C);
            background: -webkit-gradient(linear, left top, left bottom, from(#BDBDBD), to(#9C9C9C));
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Speciman Ledger<a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
        <asp:Panel ID="pnlra" runat="server">
            <div style="float: right; width: 58%">
                <div id="filter" runat="server">
                </div>
            </div>
        </asp:Panel>
        <div class="options">
        </div>
    </div>

    
            <asp:Panel ID="RdbPanel" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:RadioButton ID="rbtSalesman" Checked="true" AutoPostBack="true" OnCheckedChanged="rbtSalesman_CheckedChanged" runat="server" Text="Salesman" GroupName="TokenRadio" />
                            <asp:RadioButton ID="rbtBookset" runat="server" AutoPostBack="true" OnCheckedChanged="rbtbookset_CheckedChanged" Text="Book Set" GroupName="TokenRadio" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PanelId" runat="server" CssClass="panelDetail">
                <table>
                    <tr>
                        <td>
                            <%--<asp:UpdatePanel ID="ddlupdate" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>--%>
                                            <asp:Label runat="server" ID="lblmrcode">M.R Code</asp:Label>
                                            <asp:TextBox ID="txtMRCode" runat="server" CssClass="inp-form" onfocus="FocusIn()" Style="width: 250px" TabIndex="1"></asp:TextBox>
                                            <ajaxCt:AutoCompleteExtender ID="Title_Get" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList"
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtMRCode"
                                                UseContextKey="true" ContextKey="salesman" CompletionListElementID="dvcust">
                                            </ajaxCt:AutoCompleteExtender>
                                            <div id="dvcust" class="divauto350">
                                            </div>
                                            <asp:Label runat="server" Visible="false" ID="lblbookset">Book Set</asp:Label>
                                            <asp:DropDownList CssClass="ddl-form" Width="295px" Visible="false" ID="DDLSelectSet" TabIndex="9" runat="server"
                                                DataTextField="Value" DataValueField="AutoId">
                                            </asp:DropDownList>
                              <%--  </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="rbtSalesman" EventName="CheckedChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="rbtBookset" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>--%>


                        </td>
                        <%--<td>
                            <asp:Label runat="server" ID="Label1">M.R Code</asp:Label>
                            <asp:DropDownList>

                            </asp:DropDownList>
                        </td>--%>
                        <td>
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="TextBoxWodths" TabIndex="2"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required From Date"
                                ValidationGroup="V" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                            <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="TextBoxWodths" TabIndex="3"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtToDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:CheckBox ID="chk_AmountWise" runat="server" Text="Amount Wise" />
                        </td>
                        <td>
                            <asp:Button ID="btn_get" runat="server" CssClass="submitbtn" Style="width: 80px" TabIndex="4" OnClick="btn_get_Click" Text="Get" />
                        </td>
                        <td></td>
                    </tr>
                </table>
            </asp:Panel>
        
    <CR:CrystalReportViewer ID="SalesmanLedger" runat="server" AutoDataBind="true"
        DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
        Width="773px" ClientTarget="Auto" HasCrystalLogo="False" />
</asp:Content>

