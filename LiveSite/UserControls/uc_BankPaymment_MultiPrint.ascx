<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_BankPaymment_MultiPrint.ascx.cs"
    Inherits="UserControls_uc_BankPaymment_MultiPrint" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName">Multi-Print</span><a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
</div>
<asp:Panel ID="pnlModule" CssClass="panelDetails" runat="server">
    <table>
        <tr>
            <asp:RadioButtonList runat="server" ID="rdbmodule" RepeatDirection="Horizontal" AutoPostBack="true"
                OnSelectedIndexChanged="rdbmodule_SelectedIndexChanged">
                <asp:ListItem Text=" JV " Value="JV"> </asp:ListItem>
                <asp:ListItem Text=" DN " Value="DN"> </asp:ListItem>
                <asp:ListItem Text=" Bank Payment " Selected="True" Value="Payment"></asp:ListItem>
                <asp:ListItem Text=" Bank Receipt " Value="Receipt"></asp:ListItem>
            </asp:RadioButtonList>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server" Width="600px" Style="z-index: 100;
    top: 60px">
    <asp:Panel ID="pnlfdate" runat="server">
        <table>
            <tr>
                <td width="67px">
                    <asp:Label ID="Label8" runat="server" Text="Bank" CssClass="lbl-form"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtbankcoder" Width="80px" CssClass="inp-form" TabIndex="1" autocomplete="off"
                                runat="server" AutoPostBack="True" OnTextChanged="txtbankcoder_TextChanged"></asp:TextBox>
                            <div id="div3" class="divauto350">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbankcoder"
                                UseContextKey="true" ContextKey="Bank" CompletionListElementID="div3">
                            </ajaxCt:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="Rqfbnkr" runat="server" ErrorMessage="Enter Bank Code"
                                ValidationGroup="rdateft" ControlToValidate="txtbankcoder">.</asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td width="25px">
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblbanknamer" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtbankcoder" EventName="TextChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table>
        <tr>
            <td width="60px">
                <asp:Label ID="Label11" runat="server" Text="From No" CssClass="lbl-form"></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="5px">
            </td>
            <td>
                <asp:TextBox ID="txtFromno" CssClass="inp-form" TabIndex="2" Width="80px" runat="server" Text="0"
                     onkeypress="return CheckNumeric(event)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From No"
                    ValidationGroup="rdateft" ControlToValidate="txtFromno">.</asp:RequiredFieldValidator>
            </td>
            <td width="25px">
            </td>
            <td width="60px">
                <asp:Label ID="Label7" runat="server" Text="To No" CssClass="lbl-form"></asp:Label><font
                    color="red">*</font> &nbsp;
            </td>
            <td width="5px">
            </td>
            <td>
                <asp:TextBox ID="txttono" CssClass="inp-form" TabIndex="3" Width="80px" runat="server" Text="0"
                    onkeypress="return CheckNumeric(event)" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To No"
                    ValidationGroup="rdateft" ControlToValidate="txttono">.</asp:RequiredFieldValidator>
            </td>
            <td width="25px">
            </td>
            <td>
                <asp:Button ID="btnget" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="rdateft"
                    TabIndex="3" Width="50px" OnClick="btnget_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<br />
<%--<asp:Panel ID="Panelrepeater" CssClass="panelDetails" runat="server" Height="140px"
    ScrollBars="Auto" Width="600px">
    <table width="100%" height="auto" cellpadding="0" cellspacing="0">
        <tr>
            <td width="100px;" valign="top">
                <b>Document No.</b>
            </td>
            <td valign="top">
                <div class="menuKey">
                    <asp:CheckBoxList ID="Rptrpending" runat="server" RepeatColumns="9" CssClass="chklist"
                        DataTextField="DocumentNo" CellSpacing="3" CellPadding="2" DataValueField="DocumentNo">
                       
                    </asp:CheckBoxList>
                </div>
            </td>
            <td width="100px" style="display: none">
                <asp:Label ID="Label1" runat="server" Text="Document No."></asp:Label>
                <font color="red">*</font>
            </td>
            <td width="100px" style="display: none">
                <asp:TextBox ID="txtDocno" CssClass="inp-form" Width="80px" runat="server" MaxLength="10"></asp:TextBox>
            </td>
            <td width="100px" style="display: none">
                <asp:RequiredFieldValidator ID="reqdocno" runat="server" ErrorMessage="Require Document No."
                    ValidationGroup="App" ControlToValidate="txtDocno">*</asp:RequiredFieldValidator>
            </td>
            <td width="100px" style="display: none">
                <asp:Button ID="Button1" CssClass="form-submit" runat="server" Width="70px" Text="Get" />
            </td>
        </tr>
        <tr>
            <td colspan="6" align="right">
                <asp:Button ID="btnPrint" CssClass="submitbtn" runat="server" Text="Get Data" OnClick="btnPrint_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>--%>
<br />
<CR:CrystalReportViewer ID="repmultibank" runat="server" HasCrystalLogo="False" HasGotoPageButton="True"
    AutoDataBind="false" HasSearchButton="True" DisplayGroupTree="False" EnableDatabaseLogonPrompt="false"
    EnableDrillDown="false" EnableParameterPrompt="false" 
    EnableTheming="false" EnableToolTips="false"
    HasDrillUpButton="False" HasPageNavigationButtons="True" HasRefreshButton="False"
    HasToggleGroupTreeButton="false" HasViewList="False" HasZoomFactorList="False" 
    Width="773px" />
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="rdateft"
    runat="server" ID="bk" />

<script type="text/javascript">

shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_BankReceipt1_btn_Save').click();
});

</script>

<asp:HiddenField ID="HidFY" runat="server" />
