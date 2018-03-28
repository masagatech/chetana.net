<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Print_Invoice_Multi.ascx.cs"
    Inherits="UserControls_ODC_uc_Print_Invoice_Multi" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Transaction > ORDER > Print Invoice<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<table width="90%">
    <tr>
        <td width="70%">
            <asp:Panel ID="pnlradio" CssClass="panelDetails" runat="server">
                <table>
                    <asp:RadioButtonList ID="RdlView" runat="server" RepeatDirection="Horizontal" CssClass="lbl-form"
                        Width="300px" OnSelectedIndexChanged="RdlView_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="invoiceDate" Text="  Date Wise"></asp:ListItem>
                        <asp:ListItem Value="Customer" Text="  Customer Wise"></asp:ListItem>
                        <asp:ListItem Value="All" Text="  All "></asp:ListItem>
                    </asp:RadioButtonList>
                </table>
            </asp:Panel>
            <br />
            <asp:Panel ID="Pnlcust" CssClass="panelDetails" runat="server">
                <%--<asp:UpdatePanel ID="Upanelcust" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>--%>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Customer Code" CssClass="lbl-form"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLCustomer" DataTextField="CustName" DataValueField="CustID"
                                runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
                                InitialValue="0" ValidationGroup="DDlcust" ControlToValidate="DDLCustomer">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ID="btncustomer" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="DDlcust"
                                Width="50px" OnClick="btncustomer_Click" />
                        </td>
                    </tr>
                </table>
                <%--     </ContentTemplate>
                </asp:UpdatePanel>--%>
            </asp:Panel>
            <asp:ValidationSummary ID="ss" ShowMessageBox="true" ShowSummary="false" runat="server"
                ValidationGroup="DDlcust" />
            <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server">
                <%--  <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>--%>
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
                            <asp:RequiredFieldValidator ID="Rqffdate" runat="server" ErrorMessage="Require Date"
                                ValidationGroup="DDlDeldate" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require Date"
                                ValidationGroup="DDlDelDate" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ID="btnDate" runat="server" Text="Get" TabIndex="3" CssClass="submitbtn"
                                ValidationGroup="DDlDelDate" Width="50px" OnClick="btnDate_Click" />
                        </td>
                    </tr>
                </table>
                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
            </asp:Panel>
            <asp:ValidationSummary ID="ss1" ShowMessageBox="true" ShowSummary="false" runat="server"
                ValidationGroup="DDlDelDate" />
            <br />
            <%--<asp:UpdatePanel ID="updateapprove" UpdateMode="Conditional" runat="server">
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
                                    DataTextField="DocumentNo" CellSpacing="3" CellPadding="2" DataValueField="OriginalDocNo">
                                    <%--<a class="nav_bar_link" title="click to get record" href='<%#"javascript:setVal("+Eval("DocumentNo")+")"%>'>--%>
                                    <%--</a>--%>
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
            <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>
            <br />
            <br />
            <%--   <asp:UpdatePanel ID="utpanel" runat="server">
                <ContentTemplate>--%>
            <asp:Panel ID="pnlDetails" runat="server">
                <div>
                    <CR:CrystalReportViewer  ID="CrptInvoice" runat="server" AutoDataBind="true" DisplayGroupTree="false"
                        EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
                        EnableTheming="false" HasDrillUpButton="false" HasCrystalLogo="False" HasPageNavigationButtons="true"
                        HasRefreshButton="true" HasSearchButton="false" HasViewList="false" HasZoomFactorList="false"
                        Height="1039px" Width="773px" ShowAllPageIds="True" />
                </div>
            </asp:Panel>
            <%--</ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnPrint" EventName="Click" />
                   
                </Triggers>
            </asp:UpdatePanel>--%>
        </td>
        <td width="20%" valign="top">
        </td>
    </tr>
</table>

<script>
         function setVal(id)
         {
         document.getElementById("ctl00_ContentPlaceHolder1_uc_Print_Invoice1_txtDocno").value = id;
         document.getElementById("ctl00_ContentPlaceHolder1_uc_Print_Invoice1_btnget").click();
         }
</script>

