<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/NewChetana.master" CodeFile="CmsTicketHistoryReports.aspx.cs" Inherits="CmsTicketHistoryReports" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="ContentTicketHistory" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="section-header">
        <div class="title" id="divtitle" runat="server" visible="false">
            <div style="float: right; width: 101%">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Call Report<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <asp:Panel ID="pnlcust" runat="server" DefaultButton="Button1" CssClass="panelDetails" Width="727px" Height="25px" Visible="false">
            <table id="tblReport" runat="server" visible="false">
                <tr>
                    <%-- <td>
                        <asp:Label ID="lblFromdateCust" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>--%>
                    <td>
                        <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom" Format="dd/MM/yyyy" />
                        <%--<asp:Label ID="lblToDateCust" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label>--%>
                        <font color="red">*</font>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                       
                        <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtTo" MaskType="Date"
                            Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false" AutoComplete="true"
                            CultureName="en-US" />

                    </td>
                    <td>
                        <asp:TextBox ID="txtTo"
                            CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                            Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select To Date"
                            ValidationGroup="AZone" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblTicktNoFrom" Visible="false" runat="server" Text="Ticket From" CssClass="lbl-form"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTicketNoFrom" Visible="false" TabIndex="3" runat="server" CssClass="inp-form"></asp:TextBox>
                        <asp:Label ID="lblTicktNoTrom" Visible="false" runat="server" Text="Ticket To" CssClass="lbl-form"></asp:Label>
                        <%--<font color="red">*</font>--%>
                        <asp:TextBox ID="txtTicketNoTo" Visible="false" TabIndex="4" runat="server" CssClass="inp-form"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCustName" runat="server" Text="Customer Name" CssClass="lbl-form"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <%--  onfocus="setfocus('customer');" --%>
                        <asp:TextBox ID="txtCutomerName" runat="server" onfocus="CustomerClear()" onblur="customerName(this);" autocomplete="off"
                            Width="90px" CssClass="inp-form" TabIndex="5" AutoPostBack="false"></asp:TextBox>
                        <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtCutomerName"
                            UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <div id="dvcust" class="divauto350">
                        </div>

                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Status" CssClass="lbl-form"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="InqSatatus" TabIndex="6" runat="server" CssClass="ddl-form" Style="width: 107%">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button1" CssClass="submitbtn" TabIndex="7" runat="server" Text="Get"
                            Style="width: 80px; margin-left: 24%;" OnClick="Button1_Click1" ValidationGroup="AZone" />
                    </td>
                    <td>
                        <asp:Button ID="cmdCancel" runat="server" CssClass="submitbtn" TabIndex="8" Text="Cancel"
                            Style="margin-left: 25%; Width: 80px" OnClick="cmdCancel_Click" />
                    </td>
                    <%--<td>&nbsp;</td>--%>
                </tr>
                <tr>
                    <td colspan="9">
                    <asp:Label ID="lblCustText" runat="server" style="margin-left:10%;color:blue"></asp:Label>
                    </td>
                </tr>
            </table>

        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select From Date"
            ValidationGroup="AZone" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
        <%-- <CR:CrystalReportViewer ID="crystalreportviewercheque" runat="server"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
            EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
            HasSearchButton="false" HasZoomFactorList="false"
            ShowAllPageIds="True" />--%>
        <CR:CrystalReportViewer ID="crystalreportviewercheque" runat="server"
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

        function customerName(val) {

            var data = $(val).val();
            var splits = data.split("::");
            if (splits.length > 1) {
                $(val).val(splits[0].toString().trim());
                $('#<%=lblCustText.ClientID %>').text(data);
            }

        }
    </script>
</asp:Content>
