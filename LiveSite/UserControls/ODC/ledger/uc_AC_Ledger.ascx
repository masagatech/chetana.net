<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_AC_Ledger.ascx.cs"
    Inherits="UserControls_ODC_ledger_uc_AC_Ledger" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Ledger Details<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<style type="text/css">
    .submitbtn
    {
        height: 26px;
    }
    .inp-form
    {
        margin-left: 0px;
    }
</style>
<%--<div style="float: left; width: 71%">
    <asp:Button ID="btnPrint"  OnClick="btnPrint_Click"
               runat="server" Text="Print" Style="float: right;" 
                                                ToolTip="click to print" />
</div>--%>
<%--<asp:Panel ID="pnlfilter" runat="server">
    <div id="filter" runat="server" style="width: 61%; clear: both; float: right;">
        <span>Filter Data:</span>
        <input name="filt" id="find" onkeyup="filter(this, 'sf', '<%=gvLedger.ClientID%>')"
            type="text" />
        <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
    </div>
</asp:Panel>--%>
<%--<asp:Panel ID="Panel1" runat="server">
   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                            Width="120px" CssClass="inp-form" TabIndex="7" runat="server" AutoPostBack="true"  ></asp:TextBox>
                        <div id="dvcust" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                            UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                            ValidationGroup="S" ControlToValidate="txtcustomer">.</asp:RequiredFieldValidator>
                        <asp:Label ID="Label4" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label></ContentTemplate>
                </asp:UpdatePanel>
</asp:Panel>--%>
<asp:Panel ID="pnlfalse" runat="server" CssClass="panelDetails" Width="630px" Height="30px">
    <table style="width: 631px">
        <tr>
            <td width="50px">
                <asp:Label ID="lblcust" runat="server" CssClass="lbl-form" Text="Client"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcustomerid" onfocus="setfocus('customer');" autocomplete="off"
                    Width="130px" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                <div id="dvcust" class="divauto">
                </div>
                <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomerid"
                    UseContextKey="true" ContextKey="Account" CompletionListElementID="dvcust">
                </ajaxCt:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                    ValidationGroup="S" ControlToValidate="txtcustomerid">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From Date"
                    ValidationGroup="pdateft" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtFromDate"
                    WatermarkText="From Date">
                </ajaxCt:TextBoxWatermarkExtender>
            </td>
            <td>
                <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttoDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttoDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To Date"
                    ValidationGroup="pdateft" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                <ajaxCt:TextBoxWatermarkExtender ID="txtwatermark" runat="server" TargetControlID="txttoDate"
                    WatermarkText="To Date">
                </ajaxCt:TextBoxWatermarkExtender>
            </td>
            <td>
             <asp:CheckBox  runat="server" ID="IsPrint" Checked="true"  Text="  Is Date Print"/>
                <asp:Button ID="btnGetData" runat="server" Text="Get Details" TabIndex="4" 
                    OnClick="btnGetData_Click" CssClass="submitbtn" />
            </td>
        </tr>
        <tr>
            <td width="50px">
                &nbsp;
            </td>
            <td colspan="4">
                <asp:Label ID="lblCustName" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
<div>
    <asp:Button ID="btnPrint" OnClick="btnPrint_Click" runat="server" Text="Print" Style="float: right;
        display: none;" ToolTip="click to print" />
</div>
<br />
<br />
<asp:Panel ID="pnlLedger" runat="server">
    <div style="float: right; display: none;" runat="server" id="totAlAmt">
        <asp:Label ID="Label4" runat="server" Style="font-size: 12px; font-family: Times New Roman;"
            Text="Outstanding : "></asp:Label>
        <asp:Label ID="lbloutstndamt" Font-Size="12px" Font-Names="Times New Roman" CssClass="inp-form"
            runat="server" Text=""></asp:Label>
    </div>
    <CR:CrystalReportViewer ID="accountingledger" runat="server" AutoDataBind="true"
        DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
        Width="773px" ClientTarget="Auto" HasCrystalLogo="False" />
    <%--  <asp:GridView ID="gvLedger" runat="server" AutoGenerateColumns="true" CssClass="product-table"
        FooterStyle-BackColor="DarkKhaki" FooterStyle-Font-Bold="true" ShowFooter="true"
        ForeColor="#333333" PageSize="100" Width="100%" >
    </asp:GridView>--%>
    <br />
    <div runat="server" id="totAlAmt1" style="display: none;">
        <asp:Label ID="Label5" runat="server" Text="Outstanding : "></asp:Label>
        <asp:Label ID="lblopbal1" Font-Size="12px" Font-Names="Times New Roman" CssClass="inp-form"
            runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" OnClick="btnPrint_Click" runat="server" Text="Print" Style="float: left;"
            ToolTip="click to print" />
    </div>
    <br />
</asp:Panel>
