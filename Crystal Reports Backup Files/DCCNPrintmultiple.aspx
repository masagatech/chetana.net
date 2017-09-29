<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="DCCNPrintmultiple.aspx.cs" Inherits="DCCNPrintmultiple" Title="CN Print" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            CN Print <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
    <p>
    </p>
    <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server" Width="863px">
        <table>
            <tr>
                <td>
                    <asp:RadioButtonList ID="RdbtnSelect" runat="server" RepeatDirection="Horizontal"
                        TabIndex="1" Width="280px" AutoPostBack="True" OnSelectedIndexChanged="RdbtnSelect_SelectedIndexChanged">
                        <%--<asp:ListItem Value="All" Text="All"></asp:ListItem>--%>
                        <asp:ListItem Value="CN" Text="DateWise" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="CustomerwiseCN" Text="Customerwise CN"></asp:ListItem>
                    </asp:RadioButtonList>
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
                    <asp:UpdatePanel ID="UpPnldate1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                Enabled="true" AutoPostBack="True" OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtFromDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From Date"
                                ValidationGroup="dateft" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td width="25px">
                </td>
                <td width="60px">
                    <asp:Label ID="Label12" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                        color="red">*</font> &nbsp;
                </td>
                <td width="5px">
                </td>
                <td>
                    <asp:UpdatePanel ID="UpPnldate2" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                Enabled="true" AutoPostBack="True" OnTextChanged="txttoDate_TextChanged"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttoDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To Date"
                                ValidationGroup="dateft" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td width="25px">
                </td>
                <td>
                    <asp:Button ID="btngetcust" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="dateft"
                        Width="50px" OnClick="btngetcust_Click" />
                   
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="dateft"
        runat="server" ID="ss" />
    <p>
    </p>
    <asp:Panel ID="Pnl1" CssClass="panelDetails" runat="server" Width="863px" Height="10px">
        <table>
            <tr>
                
                <td width="65px">
                    <asp:Label ID="Label2" runat="server" Text="Customer " CssClass="lbl-form"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="DDLCustomer" DataTextField="CustName" DataValueField="CustCode"
                        runat="server" TabIndex="1" OnSelectedIndexChanged="DDLCustomer_SelectedIndexChanged"
                        AutoPostBack="True" Width="500px">
                    </asp:DropDownList>
                </td>
                <%--
         <td>
            <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
            InitialValue="0" ValidationGroup="vpcn1"  ControlToValidate="DDLCustomer">.</asp:RequiredFieldValidator>
        </td>
                --%>
            </tr>
        </table>
    </asp:Panel>
    <%--
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="vpcn1"
        runat="server" ID="ss" />
    --%>
    <p>
    </p>
    <asp:Panel ID="Pnl2" CssClass="panelDetails" runat="server" Width="863px">
        <table width="80%" height="auto" cellpadding="0" cellspacing="0">
            <tr>
                <asp:Panel ID="PnlCNNo" runat="server">
                    <td width="80px;" valign="top">
                        CN No.<font color="red">*</font>
                    </td>
                    <td valign="top">
                        <%--<asp:Repeater ID="RptrCN" runat="server">
                    <ItemTemplate>
                        <a class='<%#Eval("classReturnMDC")%>' title="click to get record" href='<%#"javascript:setVal("+Eval("CNNo")+")" %>'>
                            <%#Eval("CNNo")%></a>
                    </ItemTemplate>
                </asp:Repeater>--%>
                        <asp:Panel ID="Panel1" runat="server" Width="700px" ScrollBars="Vertical" Height="80px">
                            <asp:CheckBoxList ID="Chkbxlstcn" runat="server" RepeatColumns="14" DataTextField="CNNo"
                                CellSpacing="5" CellPadding="4" DataValueField="CNNo">
                            </asp:CheckBoxList>
                        </asp:Panel>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnget" OnClick="btnget_Click" CssClass="submitbtn" runat="server"
                            Width="70px" Text="Get" />
                         <asp:Button ID="btnGST" runat="server" Text="Get GST" CssClass="submitbtn" ValidationGroup="dateft"
                        Width="50px" OnClick="btnGST_Click" />
                    </td>
                </asp:Panel>
            </tr>
        </table>
    </asp:Panel>
    <table>
        <tr>
            <td width="100px">
                <asp:Label ID="Label1" runat="server" Style="display: none;" Text="CNNo."></asp:Label>
            </td>
            <td width="100px">
                <asp:TextBox Style="display: none;" ID="txtCnno" CssClass="inp-form" Width="80px"
                    runat="server"></asp:TextBox>
            </td>
            <td width="100px" style="display: none;">
                <asp:RequiredFieldValidator ID="reqcnno" runat="server" ErrorMessage="Require CN No."
                    ValidationGroup="vpcn" ControlToValidate="txtCnno">*</asp:RequiredFieldValidator>
            </td>
            <td width="100px">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <CR:CrystalReportViewer ID="Crptcnprint" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false"
        EnableDrillDown="false" EnableParameterPrompt="false" EnableTheming="false" HasDrillUpButton="false"
        HasPageNavigationButtons="true" HasRefreshButton="true" HasSearchButton="false"
        HasZoomFactorList="false" Height="1039px" Width="773px" ShowAllPageIds="True" />
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="cnp"
        runat="server" ID="Validationcnp" />
</asp:Content>
