<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="TrialBalanceReport.aspx.cs" Inherits="UserControls_TrialBalanceReport"
    Title="Trial Balance" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: right; width: 101%">
        <div class="section-header">
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Trial Balance Report<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="800px" Height="100px">
            <table border="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblfromDate" CssClass="lbl-form" runat="server" Text="From Date"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtFromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select FromDate"
                            ValidationGroup="AZone" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblTodate" CssClass="lbl-form" runat="server" Text="To Date"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtToDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please select ToDate"
                            ValidationGroup="AZone" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td >
                        <asp:RadioButtonList TabIndex="3" ID="rdSorD" runat="server" 
                            RepeatDirection="Horizontal" >
                              <asp:ListItem   Text="Detail" Selected="True" Value="Detail" />
                            <asp:ListItem Text="Summary" Value="summary" />
                          
                        </asp:RadioButtonList>
                    </td>
                    <td >Customer
                        <asp:DropDownList  ID="DDLCustomer" runat="server" >
                            <asp:ListItem Selected="True" Text="Yes" Value="Detail" />
                            <asp:ListItem Text="No" Value="summary" />
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAC_Group" runat="server" CssClass="lbl-form" Text="AC Group"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtGroup" autocomplete="off"  CssClass="inp-form" TabIndex="2"
                                    runat="server" ></asp:TextBox>
                                <div id="dvcust" class="divauto">
                                </div>
                                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                    ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtGroup"
                                    UseContextKey="true" ContextKey="GR_HEAD" CompletionListElementID="dvcust">
                                </ajaxCt:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Group Name"
                                    ValidationGroup="Discount12" ControlToValidate="txtGroup">.</asp:RequiredFieldValidator>
                                <asp:Label ID="lblGroup" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td >
                         <asp:CheckBox  runat="server" ID="IsPrint" Checked="true"  Text="  Is Date Print"/>
                       </td>
                    <td>
                         <asp:DropDownList  ID="ddlDebitCredit" runat="server" >
                            <asp:ListItem Selected="True" Text="All" Value="all" />
                            <asp:ListItem Text="Debit" Value="db" />
                             <asp:ListItem Text="Credit" Value="cr" />
                        </asp:DropDownList>
                         </td>
                    <td>
                        <asp:Button ID="btnGet" CssClass="submitbtn" TabIndex="4" runat="server" Text="Get Data"
                            Width="80px" ValidationGroup="AZone" OnClick="btnGet_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btntransfer" CssClass="submitbtn" TabIndex="5" runat="server" Text="Transfer To O.B."
                            Width="100px" Visible="false" Enabled="false" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <br />
        <br />
        <CR:CrystalReportViewer ID="cristTrialBalance" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="false" HasDrillUpButton="false"
            HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
            HasSearchButton="True" HasToggleGroupTreeButton="True" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" />
    </div>
</asp:Content>
