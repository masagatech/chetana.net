<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Token_Transfer_Register.aspx.cs" Inherits="Token_Transfer_Register"
    Title="Token Transfer Register" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .TextBoxWodth
        {
            width: 60px;
        }
        .TextBoxWodths
        {
            width: 84px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Token Transfered
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
    <table>
        <tr>
            <td>
                <asp:Panel ID="DateWise" runat="server">
                    <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="TextBoxWodths" TabIndex="50"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required From Date"
                        ValidationGroup="V" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                    <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="TextBoxWodths" TabIndex="51"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtToDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required To Date"
                        ValidationGroup="V" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                    <asp:Button ID="btnGet" runat="server" CssClass="submitbtn" Text="Get" Width="53px"
                        OnClick="Get_Click" ValidationGroup="V" />
                    <asp:Button ID="btnPrintDateWise" runat="server" CssClass="submitbtn" Text="Print"
                        Width="53px" OnClick="btnPrintChecked_Click" />
                </asp:Panel>
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="V" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <%--<asp:UpdatePanel ID="UpGridData" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelUpdate" runat="server" Height="100px" ScrollBars="Vertical" CssClass="panelDetails">
                <table>
                    <tr>
                        <td>
                            <asp:Repeater ID="Rptrpending" runat="server">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRepeater" Text='<%#Eval("TokenNo")%>' runat="server" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <CR:CrystalReportViewer ID="TokenTransferReportView" runat="server" AutoDataBind="true"
        DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
        Width="773px" ClientTarget="Auto" HasCrystalLogo="False" />
    <asp:HiddenField ID="txtIsExport" runat="server" />

    <script type="text/javascript">
        $("input[title='Export']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
        $("input[title='Print']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
        
    </script>

</asp:Content>
