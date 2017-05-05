<%@ Page Title="Additinal Commission" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
    AutoEventWireup="true" CodeFile="AdditionalCommissionReport.aspx.cs" Inherits="AdditionalCommissionReport" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Additional Commission Report <a href="Campaigns.aspx" title="back to campaign list"></a>
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
    <asp:Panel ID="PnRedio" runat="server" CssClass="panelDetails" Width="520px" DefaultButton="btnGet">
        <table>
            <tr>
                <td>
                    <asp:RadioButton ID="rbtnCashCheq" runat="server" GroupName="Cash" Text="Cash/Cheque" TabIndex="0" />
                </td>
                <td>
                    <asp:RadioButton ID="rbtnAmtPaid" runat="server" GroupName="Cash" Text="Amount Paid" TabIndex="1" />
                </td>
                <td>
                    <asp:RadioButton ID="rbtnReemark" runat="server" GroupName="Cash" Text="Remark" TabIndex="2" />
                </td>
                <td>
                    &nbsp
                    <asp:Button ID="btnGet" runat="server" Text="Get" CssClass="submitbtn" TabIndex="3" Width="200%" />
                </td>
                <td>
                    <asp:ValidationSummary ID="validation" runat="server" ShowMessageBox="true" ShowSummary="false"
                         ValidationGroup="V" />
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>

