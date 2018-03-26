<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="SalesGraphReport.aspx.cs" Inherits="SalesGraphReport" Title="Sales Graph" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: right; width: 29%">
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" CssClass="panelDetails" Width="820px" Height="83px">
            <table style="display:none;">
                <%--<tr>
                    <td colspan="2">
                        <asp:RadioButtonList CellSpacing="30" ID="rdMode" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Value="collection" Selected="True" Text="Collection"></asp:ListItem>
                            <asp:ListItem Value="sales" Text="Sales"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    
                    <td colspan="4">
                    </td>
                </tr>--%>
                <tr>
                    <td style="width: 100px;">
                        <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="Super Duper Zone"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" TabIndex="1" runat="server"
                            DataTextField="SDZoneName" DataValueField="SDZoneID" Width="200px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                        </asp:DropDownList>
                      <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Super Duper Zone"
                            ValidationGroup="pdateft" InitialValue="0" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>--%>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                   <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Super Duper Zone"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DdlSpZone" TabIndex="2" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" >
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From Date"
                            ValidationGroup="pdateft" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                        <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtFromDate"
                            WatermarkText="From Date">
                        </ajaxCt:TextBoxWatermarkExtender>
                    </td>
                    <td>
                        <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                            Enabled="true"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttoDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttoDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To Date"
                            ValidationGroup="pdateft" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                        <ajaxCt:TextBoxWatermarkExtender ID="txtwatermark" runat="server" TargetControlID="txttoDate"
                            WatermarkText="To Date">
                        </ajaxCt:TextBoxWatermarkExtender>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="Button1" ValidationGroup="pdateft" runat="server" OnClick="btnGet_Click"
                            CssClass="submitbtn" TabIndex="4" Text="Get" Width="59px" />
                    </td>
                    
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>
        <CR:CrystalReportViewer ID="CrCollectionGraph" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
            HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
            HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
            Width="773px" ClientTarget="Auto" HasCrystalLogo="False" OnNavigate="CrCollectionGraph_Bind"
            OnReportRefresh="CrCollectionGraph_Bind" OnSearch="CrCollectionGraph_Bind" />
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="pdateft"
            runat="server" ID="ValidationSummary1" />
    </div>
    <asp:HiddenField ID="txtIsExport" runat="server" />
    <script type="text/javascript">
        $("input[title='Export']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
    </script>
</asp:Content>
