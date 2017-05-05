<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="CustomerWiseAmountReport.aspx.cs" Inherits="UserControls_CustomerWiseAmountReport"
    Title="CustomerWise Amount" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <div style="float: right; width: 101%">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                CustomerWise Sales Report<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="745px" Height="90px">
            <table>
            
                <tr>
                    <td>
                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                            InitialValue="0" ValidationGroup="AZone" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="2" AutoPostBack="True" CssClass="ddl-form"
                            DataTextField="ZoneName" DataValueField="ZoneID" Width="200px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                    </td>
                    
                </tr>
                <tr>
            <td>
                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Customer Category" Width="100px"></asp:Label>
                        
                    </td>
            <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="DDLCC" Width="200px" DataTextField="Name"
                                            TabIndex="1" DataValueField="CMID" runat="server" AutoPostBack="true" >
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCMID" runat="server" ErrorMessage="Customer Category "
                                            InitialValue="0" ValidationGroup="S1" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                        <asp:Label ID="lblCustomer" runat="server" Text="Customer"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCustmore" runat="server" TabIndex="3" CssClass="ddl-form"
                            Width="200px" DataTextField="CustName" DataValueField="CustID">
                        </asp:DropDownList>
                    </td>
            </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFromdateCust" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="4" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                            Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Fromdate"
                            ValidationGroup="AZone" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    </td>
                    <td>
                        <asp:Label ID="lblToDateCust" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTo" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                            Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
                            ValidationGroup="AZone" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                        <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtTo" MaskType="Date"
                            Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false" AutoComplete="true"
                            CultureName="en-US" />
                    </td>
                    <td>
                     <asp:TextBox ID="txtpercent" CssClass="inp-form" TabIndex="5" runat="server" Text = "0" onkeypress="return CheckNumeric(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Value"
                             ValidationGroup="AZone" ControlToValidate="txtpercent">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="GetData"
                            Width="80px" ValidationGroup="AZone" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <CR:CrystalReportPartsViewer ID="CrystalReportPartsViewer1" runat="server" AutoDataBind="true"
            HasPageNavigationLinks="true" Height="1039px" Width="773px" />
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <CR:CrystalReportViewer ID="CustomerWiseAmount" runat="server" AutoDataBind="true"
             EnableDatabaseLogonPrompt="false" EnableDrillDown="true"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="True"
            HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
            HasSearchButton="false" HasToggleGroupTreeButton="True"  HasZoomFactorList="false"
            Height="1039px" Width="773px" />
    </div>
</asp:Content>
