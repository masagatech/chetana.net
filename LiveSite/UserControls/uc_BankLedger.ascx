<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_BankLedger.ascx.cs"
    Inherits="UserControls_uc_BankLedger" %>
    <%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>Bank Book<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <%-- <div style="float: right; width: 50%">          
 <div id="filter" runat="server">
    <span>Filter Data:</span> 
    <input name="filt" id="find" onkeyup="filter(this, 'sf', '<%=gvBankLedger.ClientID%>')" type="text" />
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
 </div>
</div>--%>
</div>
<asp:Panel ID="pnlDetails" runat="server" CssClass="panelDetails" Width="480px">
    <table style="width: 480px">
        <tr>
            <td>
                <asp:Label ID="lblBank" runat="server" CssClass="lbl-form" Text="Bank"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtBank" onfocus="setfocus('Bank');" autocomplete="off" Width="130px"
                    CssClass="inp-form" TabIndex="1" runat="server" AutoPostBack="true" OnTextChanged="txtBank_TextChanged"></asp:TextBox>
                <div id="dvBank" class="divauto">
                </div>
                <ajaxCt:AutoCompleteExtender ID="Bank_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtBank"
                    UseContextKey="true" ContextKey="Bank" CompletionListElementID="dvBank">
                </ajaxCt:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RFVBank" runat="server" ErrorMessage="Require Bank Code"
                    ValidationGroup="S" ControlToValidate="txtBank">.</asp:RequiredFieldValidator>
                <asp:Label ID="lblBankName" CssClass="lbl-form" ForeColor="Blue" Font-Size="12px"
                    runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require From Date"
                    ValidationGroup="S" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
            </td>
            <td >
                <asp:Label ID="Label2" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
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
             <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" ValidationGroup="S"
        CssClass="submitbtn" TabIndex="4"  OnClick="btnget_Click" />
            </td>
        </tr>
    </table>
   
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="S"
        runat="server" ID="ss" />
</asp:Panel>
<br />
<br />
<asp:Panel ID="pnlLedger" runat="server">
     <cr:crystalreportviewer id="BankLedger" runat="server"
            AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="true" 
            enabledrilldown="false" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="false" hasdrillupbutton="false" hasgotopagebutton="True" 
            haspagenavigationbuttons="True" hasrefreshbutton="true" 
            hassearchbutton="True" hastogglegrouptreebutton="False" hasviewlist="false" 
            haszoomfactorlist="True" height="1039px" width="773px" />
   
    
</asp:Panel>
