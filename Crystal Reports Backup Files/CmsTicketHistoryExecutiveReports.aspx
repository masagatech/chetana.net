<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="CmsTicketHistoryExecutiveReports.aspx.cs" Inherits="CmsTicketHistoryExecutiveReports" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="ContentTicketHistory" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <div style="float: right; width: 101%">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Call Report<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" DefaultButton="Button1" Visible="false" CssClass="panelDetails" Style="height: 26px; width: 960px; margin: -46px 3px 0px 0px;">
            <table id="tblReport" runat="server" visible="false">
                <tr>
                     <td>
                        <asp:Label ID="lblFromdateCust" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="1" runat="server" ValidationGroup="AZone"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFrom"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    </td>
                     <td>
                        <asp:Label ID="lblToDateCust" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTo"
                            CssClass="inp-form" TabIndex="2" runat="server" ValidationGroup="AZone"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTo"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    </td>
                    <td>
                        <asp:Label ID="lblTicktNoFrom" Visible="false" runat="server" Text="TicketNoFrom" CssClass="lbl-form"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTicketNoFrom" Visible="false" runat="server" CssClass="inp-form"></asp:TextBox>
                        <asp:Label ID="lblTicktNoTrom" Visible="false" runat="server" Text="TicketNoTo" CssClass="lbl-form"></asp:Label>
                        <%--<font color="red">*</font>--%>
                        <asp:TextBox ID="txtTicketNoTo" Visible="false" runat="server" CssClass="inp-form"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCustName" runat="server" Text="Customer Name" CssClass="lbl-form"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCutomerName" runat="server" onfocus="CustomerClear()" onblur="customerName(this);" autocomplete="off"
                            Width="90px" CssClass="inp-form" TabIndex="3" AutoPostBack="false"></asp:TextBox>
                        <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtCutomerName"
                            UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <div id="dvcust" class="divauto350">
                        </div>
                        <%--<asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                            ValidationGroup="customer" ControlToValidate="txtCutomerName">.</asp:RequiredFieldValidator>--%>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Status" CssClass="lbl-form"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:DropDownList ID="InqSatatus" TabIndex="4" CssClass="ddl-form" runat="server" Style="margin: 0 0 0 1px; padding: 0 9px 3px 0px;">
                        </asp:DropDownList>

                    </td>
                    <td>
                        <asp:Label ID="lblExecutive" runat="server" CssClass="lbl-form"
                            Text="Executive"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtExeutiveName" TabIndex="5" runat="server" CssClass="inp-form"
                            onfocus="EmployeeClear()" onblur="EmployeeTeam(this);" autocomplete="off"
                            Width="90px" AutoPostBack="false"></asp:TextBox>
                        <ajaxCt:AutoCompleteExtender ID="Emp_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtExeutiveName"
                            UseContextKey="true" ContextKey="empCode" CompletionListElementID="DisEmp">
                        </ajaxCt:AutoCompleteExtender>
                        <div id="DisEmp" style="width: 50px" class="divauto350">
                        </div>
                        <%--<asp:DropDownList ID="DDlEscalation" runat="server" CssClass="ddl-form" DataTextField="Value" DataValueField="Value">
                        </asp:DropDownList>--%>
                    </td>
                    <td>
                        <asp:Button ID="Button1" CssClass="submitbtn" TabIndex="8" runat="server" Text="Get" ValidationGroup="AZone"
                            Style="Width: 80px" OnClick="Button1_Click1" />
                    </td>
                    <td>
                        <asp:Button ID="cmdCancel" runat="server" CssClass="submitbtn" TabIndex="8" Text="Cancel"
                            Style="margin-left: 4%; Width: 80px" OnClick="cmdCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="9">
                        <asp:Label ID="lblCustText" runat="server" Style="margin-left: 10%; color: blue"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEmployee" runat="server" Style="margin-left: -60%; color: blue"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select To Date"
            ValidationGroup="AZone" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select From Date"
            ValidationGroup="AZone" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>

        <CR:CrystalReportPartsViewer ID="CrystalReportPartsViewer1" runat="server" AutoDataBind="true"
            HasPageNavigationLinks="true" Height="1039px" Width="773px" />
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <%-- <CR:CrystalReportViewer ID="CustomerWiseAmount" runat="server" AutoDataBind="true"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="true"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="True"
            HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
            HasSearchButton="false" HasToggleGroupTreeButton="True" HasZoomFactorList="false"
            Height="1039px" Width="773px" />--%>
        <CR:CrystalReportViewer ID="CustomerWiseAmount" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
            HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
            HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
            Width="773px" ClientTarget="Auto" HasCrystalLogo="False" />
    </div>
    <script type="text/javascript">
        function CustomerClear() {
            document.getElementById('<%=txtCutomerName.ClientID %>').value = "";
        }

        function EmployeeClear() {
            document.getElementById('<%=txtExeutiveName.ClientID %>').value = "";
        }

        function customerName(val) {

            var data = $(val).val();
            var splits = data.split("::");
            if (splits.length > 1) {
                $(val).val(splits[0].toString().trim());
                $('#<%=lblCustText.ClientID %>').text(data);
            }

        }

        function EmployeeTeam(val) {
            var data = $(val).val();
            var Split = data.split(":");
            if (Split.length > 1) {
                $(val).val(Split[0].toString().trim());
                $('#<%=lblEmployee.ClientID %>').text(data);
            }
        }
    </script>
</asp:Content>
