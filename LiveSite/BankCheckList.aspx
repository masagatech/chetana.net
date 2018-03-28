<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="BankCheckList.aspx.cs" Inherits="BankCheckList" Title="Bank/Cash Check List" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            <span runat="server" id="pageName"></span>Bank/Cash Receipt CheckList<a href="Campaigns.aspx"
                title="back to campaign list"></a>
        </div>
        <%-- <div style="float: right; width: 50%">          
 <div id="filter" runat="server">
    <span>Filter Data:</span> 
    <input name="filt" id="find" onkeyup="filter(this, 'sf', '<%=gvBankLedger.ClientID%>')" type="text" />
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
 </div>
</div>--%>
    </div>

    <asp:Panel ID="pnlDetails" runat="server" CssClass="panelDetails" Width="732px">
        <table style="width: 480px">
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Super Zone"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="3" runat="server"
                        DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="150px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Zone"></asp:Label>
                </td>
                <td>

                    <asp:DropDownList ID="DDLZone" runat="server" TabIndex="4" CssClass="ddl-form"
                        DataTextField="ZoneName" DataValueField="ZoneID" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table style="width: 480px">
            <tr>
                <td>
                    <asp:RadioButtonList ID="rdbselect" runat="server" CssClass="lbl-form" TabIndex="1"
                        RepeatDirection="Horizontal" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rdbselect_SelectedIndexChanged">
                        <asp:ListItem Value="Bank" Text="Bank Check List" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Cash" Text="Cash Check List"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlbanktext" runat="server" Width="480px">
            <table style="width: 480px">
                <tr>
                    <td width="80px">
                        <asp:Label ID="lblBank" runat="server" CssClass="lbl-form" Text="Bank"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtBank" onfocus="setfocus('Bank');" autocomplete="off" Width="130px"
                            CssClass="inp-form" TabIndex="2" runat="server" AutoPostBack="true" OnTextChanged="txtBank_TextChanged"></asp:TextBox>
                        <div id="dvBank" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="Bank_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True" ServiceMethod="GetCodes"
                            CompletionSetCount="20" ServicePath="~/AutoComplete.asmx" CompletionInterval="100"
                            MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtBank" UseContextKey="true"
                            ContextKey="Bank" CompletionListElementID="dvBank">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:Label ID="lblBankName" CssClass="lbl-form" ForeColor="Blue" Font-Size="12px"
                            runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table style="width: 700px">
            <tr>
                <td width="80px">
                    <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                        Enabled="true"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require From Date"
                        ValidationGroup="S" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="4" Width="80px" runat="server"
                        Enabled="true"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="toDate" runat="server" TargetControlID="txttoDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To Date"
                        ValidationGroup="S" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtsubgroup" Width="180px" CssClass="inp-form" TabIndex="5" autocomplete="off"
                        runat="server"></asp:TextBox>
                    <div id="div4" class="divauto350">
                    </div>
                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" DelimiterCharacters=""
                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                        ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                        ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtsubgroup"
                        UseContextKey="true" ContextKey="GR_HEAD" CompletionListElementID="div4">
                    </ajaxCt:AutoCompleteExtender>
                    <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtsubgroup"
                        WatermarkText="Group">
                    </ajaxCt:TextBoxWatermarkExtender>
                </td>
                <td>
                    <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" ValidationGroup="S"
                        CssClass="submitbtn" TabIndex="5" OnClick="btnget_Click" />
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="S"
            runat="server" ID="ss" />
    </asp:Panel>
    <CR:CrystalReportViewer ID="Bankchecklist" runat="server" AutoDataBind="true" DisplayGroupTree="false"
        EnableDatabaseLogonPrompt="true" EnableDrillDown="false" EnableParameterPrompt="false"
        EnableTheming="false" EnableToolTips="false" HasDrillUpButton="false" HasGotoPageButton="True"
        HasPageNavigationButtons="True" HasRefreshButton="true" HasSearchButton="True"
        HasToggleGroupTreeButton="False" HasViewList="false" HasZoomFactorList="True" Height="1039px"
        Width="773px" />
</asp:Content>
