<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="SuperZone_WeeklyCollection.aspx.cs" Inherits="SuperZone_WeeklyCollection"
    Title="SuperZoneWise Weekly Collection" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <div class="section-header">
        <tr>
            <td>
                <div class="title">
                    <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
                    <span runat="server" id="pageName">SuperZone Wise Weekly Collection</span><a href="Campaigns.aspx"
                        title="back to campaign list"> </a>
                </div>
                <div class="options">
                </div>
            </td>
            <td>
                <div style="float: right; width: 50%">
                    <div id="filter" runat="server">
                        <span></span>
                        <%-- <input name="filt" onkeyup="filter(this, 'sf', '<%=GrdBankRDetails.ClientID%>')"
                        type="text">--%>
                    </div>
                </div>
            </td>
        </tr>
    </div>
    <br />
    <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server" Width="862px" Style="position: fixed;
        z-index: 100; top: 90px">
        <table>
            <tr>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="250px" DataTextField="SDZoneName"
                        DataValueField="SDZoneId" AutoPostBack="true" runat="server" TabIndex="1" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Require Super Duper Zone "
                        InitialValue="0" ValidationGroup="rdateft1" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
                </td>
                <td width="67px">
                    <asp:Label ID="Label8" runat="server" Text="SuperZone" CssClass="lbl-form"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" Width="250px" DataTextField="SuperZoneName"
                        DataValueField="SuperZoneId" runat="server" TabIndex="1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require SuperZone "
                        InitialValue="0" ValidationGroup="rdateft12" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td width="60px">
                    <asp:Label ID="Label11" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td width="5px">
                </td>
                <td>
                    <%--<asp:UpdatePanel ID="UpPnldate1" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>--%>
                    <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                        Enabled="true"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From Date"
                        ValidationGroup="rdateft" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                    <%--   </ContentTemplate>
                        </asp:UpdatePanel>--%>
                </td>
                <td width="25px">
                </td>
                <td width="60px">
                    <asp:Label ID="Label7" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                        color="red">*</font> &nbsp;
                </td>
                <td width="5px">
                </td>
                <td>
                    <%-- <asp:UpdatePanel ID="UpPnldate2" runat="server">
                            <ContentTemplate>--%>
                    <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                        Enabled="true"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttoDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttoDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To Date"
                        ValidationGroup="rdateft" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                    <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                </td>
                <td width="25px">
                </td>
                <td>
                    <asp:Button ID="btnget" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="rdateft"
                        TabIndex="5" Width="50px" OnClick="btnget_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="rdateft"
        runat="server" ID="ss" />
    <br />
    <p>
    </p>
    <asp:Panel ID="PnlBankRDetails" runat="server">
        <CR:CrystalReportViewer ID="repBankReceipt" runat="server" HasCrystalLogo="False"
            HasGotoPageButton="True" AutoDataBind="false" HasSearchButton="True" DisplayGroupTree="False"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
            EnableTheming="false" EnableToolTips="false" HasDrillUpButton="False" HasPageNavigationButtons="True"
            HasRefreshButton="True" HasToggleGroupTreeButton="false" HasViewList="False"
            HasZoomFactorList="False" Width="773px" />
    </asp:Panel>
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="bnkrct"
        runat="server" ID="bk" />

    <script type="text/javascript">

shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_BankReceipt1_btn_Save').click();
});

    </script>

    <asp:HiddenField ID="HidFY" runat="server" />
</asp:Content>
