<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Auditlock.aspx.cs" Inherits="Auditlock" Title="Chetana:AuditLock" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
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
        <table>
        <tr>
            <td class="style6">
                <asp:Label ID="lbl1" CssClass="lbl-form" runat="server" Text="Financial Year:"></asp:Label>
            </td>
            <td class="style6">
                <asp:Label ID="lblFY" CssClass="lbl-form" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
        <td class="style4">
                        <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Date"></asp:Label>
                    </td>
                    <td class="style5">
                       <asp:TextBox ID="txtDate" CssClass="inp-form" TabIndex="1" Width="100px" runat="server"
                            Enabled="true" Height="22px"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                            Format="MM/dd/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                         <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require From Date"
                            ValidationGroup="book" ControlToValidate="txtDate">.</asp:RequiredFieldValidator>
                        <%--<asp:RangeValidator ID="RangeValidator1"  ControlToValidate="txtDate" runat="server"  ValidationGroup="book" Type="Date">.</asp:RangeValidator>--%>
                    </td>
                    <td class="style5">
                        <asp:Button ID="btnset" TabIndex="4"  runat="server" Width="80px" Text="Set Lock Date" CssClass="submitbtn"
                            ValidationGroup="book" OnClick="btngetset_Click" Style="height: 26px" />
                   </td> 
        </tr>
        </table>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="book" runat="server" ID="ss" />
    </div>
</asp:Content>       



