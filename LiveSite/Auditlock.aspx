<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Auditlock.aspx.cs" Inherits="Auditlock" Title="Chetana:AuditLock" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style4
        {
            width: 85px;
            height: 24px;
        }
        .style5
        {
            height: 24px;
        }
        .style6
        {
            width: 85px;
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Panel ID="pnlbooks" CssClass="panelDetails" runat="server" Width="643px">
            <table style="width: 100%">
                <tr>
                    <td class="style6">
                        <asp:Label ID="lbl1" CssClass="lbl-form" runat="server" Text="Financial Year:"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:Label ID="lblFY" CssClass="lbl-form" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="width: 20px;">
                    </td>
                    <td colspan="2"> 
                        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Last configured audit lock date : "></asp:Label><asp:Label ID="lblAditCheckDate" CssClass="lbl-form" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Date"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtDate" CssClass="inp-form" TabIndex="1" Width="100px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Date is required!"
                            ValidationGroup="book" ControlToValidate="txtDate" Display="None">.</asp:RequiredFieldValidator>
                      <%--  <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtDate" runat="server"
                            Display="None" ValidationGroup="book" Type="Date">.</asp:RangeValidator>--%>
                    </td>
                    <td class="style5">
                        <asp:Button ID="btnset" TabIndex="4" runat="server" OnClientClick="confirm('Are you sure you want to set audit lock date.');" Width="80px" Text="Set Lock Date"
                            CssClass="submitbtn" ValidationGroup="book" OnClick="btngetset_Click" />
                    </td>
                    <td style="width: 20px;">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="book"
            runat="server" ID="ss" />
    </div>
</asp:Content>
