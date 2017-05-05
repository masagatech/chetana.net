<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="CustomerOutStanding.aspx.cs" Inherits="UserControls_CustomerOutStanding"
    Title="Customet Outstanding" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: right; width: 101%">
        <div class="section-header">
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Customer Outstanding<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="820px" Height="110px">
            <table>
                <tr>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rdbselect" TabIndex="1" RepeatDirection="Horizontal"
                            CssClass="lbl-form" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rdbselect_SelectedIndexChanged">
                            <asp:ListItem Value="Customer" Text="Customer Wise" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="Area" Text="Area Wise"></asp:ListItem>
                            <asp:ListItem Value="Analysis" Text="Analysis Report"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlcustomer" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Customer Code"></asp:Label>
                                    </td>
                                    <td colspan="4">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                                                    Width="80px" CssClass="inp-form" TabIndex="2" runat="server" AutoPostBack="true"
                                                    OnTextChanged="txtcustomer_TextChanged"></asp:TextBox>
                                                <div id="dvcust" class="divauto350">
                                                </div>
                                                <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                                    ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                                                    UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                                                </ajaxCt:AutoCompleteExtender>
                                                <asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                                                    ValidationGroup="S123" ControlToValidate="txtcustomer">.</asp:RequiredFieldValidator>
                                                <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                                    runat="server"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlzone" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                                            InitialValue="0" ValidationGroup="AZone123" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                                        <%--<font color="red">*</font>--%>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="3" AutoPostBack="True" CssClass="ddl-form"
                                            DataTextField="ZoneName" DataValueField="ZoneID" Width="200px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCustomer" runat="server" Text="Customer"></asp:Label>
                                        <%--<font color="red">*</font>--%>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCustmore" runat="server" TabIndex="4" CssClass="ddl-form"
                                            Width="200px" DataTextField="CustName" DataValueField="CustID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnldate" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFromdateCust" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        <%-- <ajaxCt:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlToValidate="txtFrom"
                                            ControlExtender="MaskedEditExtender1" CssClass="RedLabel" Display="Dynamic" EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="Invalid Date"
                                            IsValidEmpty="False" ValidationExpression="^\d{2}/\d{2}/\d{4}$">  
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                        </ajaxCt:MaskedEditValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Fromdate"
                                            ValidationGroup="AZone" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblToDateCust" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTo" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        <%-- <ajaxCt:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlToValidate="txtTo"
                                            ControlExtender="MaskedEditExtender2" CssClass="RedLabel" Display="Dynamic" EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="Invalid Date" IsValidEmpty="False" ValidationExpression="^\d{2}/\d{2}/\d{4}$">  
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                        </ajaxCt:MaskedEditValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
                                            ValidationGroup="AZone" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbldetails" runat="server" Text="Details/Summary" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDetails" runat="server" TabIndex="7" CssClass="ddl-form"
                                            Width="200px" DataTextField="CustName" DataValueField="CustID">
                                            <asp:ListItem Text="Customer Details" Value="details"></asp:ListItem>
                                            <asp:ListItem Text="Customer Summary" Value="summary" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select ToDate"
                                            ValidationGroup="AZone" InitialValue="0" TabIndex="6" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblInvoiceDate" runat="server" Text="Invoice Date" CssClass="lbl-form"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInvoicedate" CssClass="inp-form" TabIndex="7" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtInvoicedate"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtInvoicedate"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:RadioButtonList runat="server" ID="rdbselectnull" TabIndex="1" RepeatDirection="Horizontal"
                                            CssClass="lbl-form">
                                            <asp:ListItem Value="outstanding" Text="Without Zero" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                        </asp:RadioButtonList>
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
            <table>
            </table>
        </asp:Panel>
        <%-- <CR:CrystalReportPartsViewer ID="CrystalReportPartsViewer1" runat="server" AutoDataBind="true" 
        HasPageNavigationLinks="true" Height="1039px" Width="773px"/>--%>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <CR:CrystalReportViewer ID="CustomerReportView" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" HasDrillUpButton="false"
            HasPageNavigationButtons="true" HasRefreshButton="true" HasSearchButton="True"
            HasToggleGroupTreeButton="False" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" ShowAllPageIds="True" />
    </div>
</asp:Content>
