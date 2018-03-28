<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Customer_BlackList.ascx.cs"
    Inherits="UserControls_uc_Customer_BlackList" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Customer Blacklist<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<asp:Panel ID="pnlfalse" runat="server" CssClass="panelDetails" Width="743px" Height="30px">
    <table style="width: 580px">
        <tr>
            <td width="50px">
                <asp:Label ID="lblcust" runat="server" CssClass="lbl-form" Text="Above(Rs.)"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtRs" onfocus="setfocus('customer');" autocomplete="off" Text="0"
                    Width="130px" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                <ajaxCt:FilteredTextBoxExtender ID="Amount" runat="server" TargetControlID="txtRs"
                    FilterType="Custom, Numbers" ValidChars=".">
                </ajaxCt:FilteredTextBoxExtender>
            </td>
            <td>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="To Date"></asp:Label>
                <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttoDate"
                    Format="dd/MMM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttoDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require Date"
                    ValidationGroup="pdateft1" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnGetData" runat="server" CssClass="submitbtn" ValidationGroup="pdateft1" Text="Get Details"
                    TabIndex="4" OnClick="btnGetData_Click" />
                    <asp:Button ID="btnGetHistory" runat="server" CssClass="submitbtn"  style="display:none;" ValidationGroup="pdateft1" Text="Get last blacklisted details"
                    TabIndex="4" OnClick="btnGetHistoryData_Click" />
                <asp:ValidationSummary ID="validateAll" runat="server" ValidationGroup="pdateft1"
                    ShowMessageBox="true" ShowSummary="false" />
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="pnlLedger" runat="server" Width="700px">
    <asp:Label runat="server" CssClass="lbl-form" Style="font-weight: bold;" ID="lblCustomerCount"></asp:Label>
    <asp:Label runat="server" CssClass="lbl-form" ID="lblTotalOS" Style="font-weight: bold;
        float: right; text-align: right;"></asp:Label>
    <div style="float: right; padding-right:75px">
        <asp:Button ID="btnSetBlackList" runat="server" 
        CssClass="submitbtn" OnClientClick="return confirm('Are you sure you want to blacklist customer?')" Text="Black List" TabIndex="5" OnClick="btnGetData1_Click" />
    </div>
    <br />
    <br />
    <asp:GridView ID="gvBlackListCustomer" runat="server" AutoGenerateColumns="true"
        CssClass="product-table" Width="100%" ShowFooter="false" FooterStyle-BackColor="DarkKhaki"
        FooterStyle-Font-Bold="true" ForeColor="#333333">
    </asp:GridView>
</asp:Panel>
