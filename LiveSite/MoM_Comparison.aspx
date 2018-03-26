<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    Debug="true" CodeFile="MoM_Comparison.aspx.cs" Inherits="Report_YoY_Monthly_Comparision"
    Title="Chetana : Monthly_Comparision" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 203px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: right; width: 29%">
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="820px" Height="83px">
            <table>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Super Duper Zone"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" TabIndex="1" runat="server"
                            DataTextField="SDZoneName" DataValueField="SDZoneID" Width="200px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="ReqSuperDuper" runat="server" ErrorMessage="Please select SuperDuperZone"
                            InitialValue="0" ValidationGroup="AZone" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td class="style1">
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                            InitialValue="0" ValidationGroup="AZone" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="Zone"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="2" AutoPostBack="True" CssClass="ddl-form"
                            DataTextField="ZoneName" DataValueField="ZoneID" Width="200px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblCustomer" runat="server" Text="Customer"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:DropDownList ID="ddlCustmore" runat="server" TabIndex="3" CssClass="ddl-form"
                            Width="200px" DataTextField="CustName" DataValueField="CustID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" class="allchkbox">
                        &nbsp;<asp:CheckBox ID="ChkAll" runat="server" Checked="True" OnCheckedChanged="ChkAll_CheckedChanged"
                            Text="All Months" />
                        <asp:CheckBox ID="chkApr" class="grpmonth" runat="server" Text="Apr" />
                        <asp:CheckBox ID="chkMay" class="grpmonth" runat="server" Text="May" />
                        <asp:CheckBox ID="chkJun" class="grpmonth" runat="server" Text="Jun" />
                        <asp:CheckBox ID="chkJul" class="grpmonth" runat="server" Text="Jul" />
                        <asp:CheckBox ID="chkAug" class="grpmonth" runat="server" Text="Aug" />
                        <asp:CheckBox ID="chkSep" class="grpmonth" runat="server" Text="Sep" />
                        <asp:CheckBox ID="chkOct" class="grpmonth" runat="server" Text="Oct" />
                        <asp:CheckBox ID="chkNov" class="grpmonth" runat="server" Text="Nov" />
                        <asp:CheckBox ID="chkDec" class="grpmonth" runat="server" Text="Dec" />
                        <asp:CheckBox ID="chkJan" class="grpmonth" runat="server" Text="Jan" />
                        <asp:CheckBox ID="chkFeb" class="grpmonth" runat="server" Text="Feb" />
                        <asp:CheckBox ID="chkMar" class="grpmonth" runat="server" Text="Mar" />
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnGet" OnClientClick="javascript:return validatecheckbox();" ValidationGroup="AZone" runat="server" OnClick="btnGet_Click"
                            Text="Get" Width="59px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>
        <CR:CrystalReportViewer ID="CrMothlyreport" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false"
            EnableDrillDown="false" EnableParameterPrompt="false" 
            EnableTheming="false" HasDrillUpButton="false"
            HasPageNavigationButtons="true" HasRefreshButton="true" HasSearchButton="false"
            HasZoomFactorList="false" Height="1039px" Width="773px" ShowAllPageIds="True" 
            DisplayGroupTree="False" oninit="CrMothlyreport_Init" />
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
    </div>

    <script>
        $("#<%=ChkAll.ClientID %>").click(function() {
           
            $('.grpmonth input').removeAttr('checked');
        });

        $(".grpmonth input").click(function() {

        $("#<%=ChkAll.ClientID %>").removeAttr('checked');
    });


    function validatecheckbox() {
        var issinglecheck = false;
        $('.allchkbox input[type=checkbox]').each(function() {
            if (this.checked) {
                issinglecheck = true;
            }
        });
        if (issinglecheck) {
            return true;
        } else {
        alert('select atleast one month!');
        return false;
        }
    }       
    </script>

</asp:Content>
