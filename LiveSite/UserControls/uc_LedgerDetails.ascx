<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_LedgerDetails.ascx.cs"
    Inherits="UserControls_LedgerDetails" %>
    <%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
       <span runat="server" id="pageName"></span>
        LedgerDetails<a href="Campaigns.aspx" title="back to campaign list"></a>
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
<div style="float: right; width: 70%">
    <asp:Button ID="lblSave" CssClass="submitbtn" TabIndex="3" runat="server" Text="Save"
        Width="80px" ValidationGroup="ct" onclick="lblSave_Click"/>
        
        </div>
        
        <div>
        
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="ct"
        runat="server" ID="ss"/>
</div>
<br />
<br />

<asp:Panel ID="pnlLedgerDetails" CssClass="panelDetails" runat="server" Width="380px" GroupingText="LedgerDetails" >
    
    <table cellpadding="0" cellspacing="0" style="margin-bottom: 0px; width: 93%;">
        <tr>
            <td width="110px" class="style1">
                <asp:Label ID="lblLedgID" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
                <asp:Label ID="lblParticulas" runat="server" Text="Particulas"></asp:Label>
                <font color="red">*</font>
            </td>
            <td colspan="2" class="style1">
                <asp:TextBox ID="txtperticulas" CssClass="inp-form" runat="server" Height="15px"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="reqName" runat="server" ErrorMessage="Enter Particulas"
                    ValidationGroup="ct" ControlToValidate="txtperticulas">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDebitAmount" runat="server" Text="DebitAmount"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDebitAmount" CssClass="inp-form" runat="server" 
                    Height="15px" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="debam" runat="server" ErrorMessage="Enter DebitAmount"
                    ValidationGroup="ct" ControlToValidate="txtDebitAmount">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCreditamount" runat="server" Text="CreditAmount"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="TxtCreditAmount" CssClass="inp-form" runat="server" 
                    Height="15px" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="credamount" runat="server" ErrorMessage="Enter CreditAmount"
                    ValidationGroup="cmpy" ControlToValidate="TxtCreditAmount">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblbalance" runat="server" Text="Balance"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtBalance" runat="server" CssClass="inp-form" Height="15px" 
                    MaxLength="20"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Balance"
                    ValidationGroup="ct" ControlToValidate="txtBalance">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCreatedDate" runat="server" Text="CreatedDate"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtCreatedDate" runat="server" CssClass="inp-form" Height="15px"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCreatedDate"
                   Format="dd/MM/yyyy" />
               <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtCreatedDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US"/>
                
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter CreatedDate"
                    ValidationGroup="ct" ControlToValidate="txtCreatedDate">.</asp:RequiredFieldValidator>
            </td>
           
            </tr>
            <tr>
            <td>
                <asp:Label ID="lblFinancialYearsFrom" runat="server" Text="FinancialYearsFrom"></asp:Label>
                <font color="red">*</font>
               
            </td>
            <td>
                <asp:TextBox ID="txtFinancialYearsFrom" runat="server" CssClass="inp-form" Height="15px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter FinancialYearsFrom"
                    ValidationGroup="ct" ControlToValidate="txtFinancialYearsFrom">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFinancialYearsTo" runat="server" Text="FinancialYearsTo"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtFinancialYearsTo" runat="server" CssClass="inp-form" Height="15px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter FinancialYearsTo"
                    ValidationGroup="ct" ControlToValidate="txtFinancialYearsTo">.</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</asp:Panel>
