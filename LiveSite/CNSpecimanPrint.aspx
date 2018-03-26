<%@ Page Title="CN Speciman Print" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="CNSpecimanPrint.aspx.cs" Inherits="CNSpecimanPrint" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            CN Speciman Print<a href="Campaigns.aspx" title="back to campaign list"></a>
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
    <asp:Panel ID="cnprintpanel" runat="server" DefaultButton="btnPrint">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbldoc" runat="server">Document No :</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdocument" CssClass="inp-form" runat="server" onkeypress="return CheckNumeric(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required Document No "
                        ValidationGroup="V" ControlToValidate="txtdocument">*</asp:RequiredFieldValidator>
                </td>
                 <td>
                    <asp:Button ID="btnPrint" runat="server" width="70px" Text="Get" CssClass="submitbtn" ValidationGroup="V"
                        OnClick="btnPrint_Click" />
                </td>
                <td>
                    <asp:ValidationSummary ID="validation" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="V" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <CR:CrystalReportViewer ID="CNPrint" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false"
        EnableDrillDown="true" EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true"
        HasDrillUpButton="True" HasGotoPageButton="True" HasPageNavigationButtons="True"
        HasRefreshButton="true" HasSearchButton="false" HasToggleGroupTreeButton="True"
        HasZoomFactorList="false" DisplayGroupTree="False" />

    <asp:HiddenField ID="txtIsExport" runat="server" />
    <script type="text/javascript">
        $("input[title='Export']").click(function () {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
         });
         $("input[title='Print']").click(function () {
             document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });

    </script>
</asp:Content>

