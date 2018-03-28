<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Multi_Print_Specimen.ascx.cs"
    Inherits="UserControls_uc_MultiPrintSpecimen" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Print Specimen<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<asp:Panel ID="Panel2" CssClass="panelDetails" runat="server">
    <table>
        <asp:RadioButtonList ID="RdlView" runat="server" RepeatDirection="Horizontal" CssClass="lbl-form"
            Width="300px" OnSelectedIndexChanged="RdlView_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="Date" Text="  Date Wise"></asp:ListItem>
            <asp:ListItem Value="Employee" Text="  Employee Wise"></asp:ListItem>
            <asp:ListItem Value="All" Text="  All "></asp:ListItem>
        </asp:RadioButtonList>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="Pnlcust" CssClass="panelDetails" runat="server" Visible="false">
    <asp:UpdatePanel ID="Upanelcust" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="M.R. Code" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLEmployee" DataTextField="Name" DataValueField="EmpID"
                            runat="server" Width="300px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
                            InitialValue="0" ValidationGroup="DDlcust" ControlToValidate="DDLEmployee">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnemployee" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="DDlcust"
                            Width="50px" OnClick="btnemployee_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<asp:Panel ID="pnlDate" CssClass="panelDetails" runat="server" Visible="false">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtFromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="Rqffdate" runat="server" ErrorMessage="Require From Date"
                            InitialValue="none" ValidationGroup="DDlDeldate" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                            color="red">*</font> &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttoDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require To Date"
                            InitialValue="0" ValidationGroup="DDlDelDate" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnfind" runat="server" TabIndex="3" Text="Get" CssClass="submitbtn"
                            ValidationGroup="DDlDelDate" Width="50px" OnClick="btnfind_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<br />
<table width="90%">
    <tr>
        <td width="70%">
            <%-- <asp:UpdatePanel ID="updateapprove" UpdateMode="Conditional" runat="server">
                <ContentTemplate>--%>
            <asp:Panel ID="Panelrepeater" CssClass="panelDetails" runat="server" Height="140px"
                ScrollBars="Auto" Width="600px">
                <table width="100%" height="auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100px;" valign="top">
                            <b>Document No.</b>
                        </td>
                        <td valign="top">
                            <div class="menuKey">
                                <asp:CheckBoxList ID="Rptrpending" runat="server" RepeatColumns="9" CssClass="chklist"
                                    DataTextField="DocumentNo" CellSpacing="2" CellPadding="2" DataValueField="OriginalDocNo">
                                </asp:CheckBoxList>
                            </div>
                        </td>
                        <td width="100px" style="display: none">
                            <asp:Label ID="Label1" runat="server" Text="Document No."></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td width="150px" style="display: none">
                            <asp:TextBox ID="txtDocno" CssClass="inp-form" Width="80px" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                        <td width="1%" style="display: none">
                            <asp:RequiredFieldValidator ID="reqdocno" runat="server" ErrorMessage="Require Document No."
                                ValidationGroup="App" ControlToValidate="txtDocno">*</asp:RequiredFieldValidator>
                        </td>
                        <td width="5%" style="display: none">
                            <asp:Button ID="btnget" OnClick="btnget_Click" CssClass="form-submit" runat="server"
                                Width="70px" Text="Get" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="right">
                            <asp:Button ID="btnPrint" CssClass="submitbtn" runat="server" Text="Get Data" OnClick="btnPrint_Click1" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <asp:Panel ID="pnlDetails" runat="server">
                <div>
                </div>
            </asp:Panel>
            <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>
        </td>
        <td width="20%" valign="top">
        </td>
    </tr>
</table>
<CR:CrystalReportViewer ID="CrptInvoice" runat="server" AutoDataBind="true" DisplayGroupTree="false"
    EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
    EnableTheming="false" HasDrillUpButton="false" HasCrystalLogo="False" HasPageNavigationButtons="true"
    HasRefreshButton="true" HasSearchButton="false" HasViewList="false" HasZoomFactorList="false"
    Height="1039px" Width="773px" ShowAllPageIds="True" />

<script>
    function setVal(id) {
        document.getElementById("ctl00_ContentPlaceHolder1_uc_Approval1_txtDocno").value = id;
        document.getElementById("ctl00_ContentPlaceHolder1_uc_Approval1_btnget").click();
    }
</script>

