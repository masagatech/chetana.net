<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="PrintDN.aspx.cs" Inherits="PrintDN" Title="PrintDN" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="section-header">

    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
      Debit Note Report
         <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
 </div>
<div>
<asp:Panel ID ="pnldt" CssClass="panelDetails" runat ="server" Width="735px">
    <table>
   <%-- <tr>
        <td width="60px">
            <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxct:calendarextender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                    Format="dd/MM/yyyy" />
                <ajaxct:maskededitextender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Rfvfdt" runat="server" ErrorMessage="Require From Date"
                    ValidationGroup="DNprint" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
        </td>
       <td width="30px"></td>
        <td width="60px">
            <asp:Label ID="Label2" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxct:calendarextender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                    Format="dd/MM/yyyy" />
                <ajaxct:maskededitextender ID="toDate" runat="server" TargetControlID="txttoDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Rfvtdt" runat="server" ErrorMessage="Require To Date"
                    ValidationGroup="DNprint" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
        </td>
      </tr>--%>
      <tr>
      <td>
        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Document No"></asp:Label>
    </td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="Txtdocno"  Width="85px" CssClass="inp-form" TabIndex="3" 
                    runat="server" Enabled="true" ontextchanged="Txtdocno_TextChanged" 
                    AutoPostBack="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqdocno" runat="server" ErrorMessage="Require Document No "
                ValidationGroup="DNprint" ControlToValidate="Txtdocno">.</asp:RequiredFieldValidator>
            </ContentTemplate>
        </asp:UpdatePanel>
    </td>
     <td width="30px"></td>
        <td>
             <asp:Button ID="btnget" runat="server" width="80px" Text="Get" CssClass="submitbtn" ValidationGroup="DNprint"
                onclick="btnget_Click" style="height: 26px" />
        </td>
    </tr>
</table>
</asp:Panel>
<br />
<br />
<cr:crystalreportviewer id="CrptDN" runat="server" 
            AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" 
            enabletheming="false" hasdrillupbutton="false" 
            haspagenavigationbuttons="true" hasrefreshbutton="true" 
            hassearchbutton="false" hasviewlist="false" 
            haszoomfactorlist="false" height="1039px" width="773px" 
            ShowAllPageIds="True" />
            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="DNprint"
    runat="server" ID="ss" />
</div>
</asp:Content>
