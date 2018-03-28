<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="TStyleReport.aspx.cs" Inherits="TStyleReport" Title="TStyle Report" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hiddenfildYear" runat="server" />
    <asp:Panel ID="pnlsalesman_customer" CssClass="panelDetails" runat="server">
        <table width="100%">
            <tr>
                <td valign="top">
                    <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label><br />
                    <asp:DropDownList CssClass="ddl-form" ID="ddlZone" Width="180px" DataTextField="ZoneName"
                        DataValueField="ZoneID" runat="server" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                    </asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Zone"
                        ValidationGroup="balancecReport" ControlToValidate="ddlZone" InitialValue="0">.</asp:RequiredFieldValidator>--%>
                </td>
                <td>
                    <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Customer"></asp:Label><br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:TextBox OnTextChanged="txtcustomer_TextChanged" ID="txtcustomer" onfocus="setfocus('customer');"
                                autocomplete="off" Width="80px" CssClass="inp-form" TabIndex="2" runat="server"
                                AutoPostBack="true"></asp:TextBox>
                            <div id="dvcust" class="divauto350">
                            </div>
                             <ajaxct:autocompleteextender id="Cust_AutoCompleteExtender" runat="server" delimitercharacters=""
              completionlistcssclass="AutoExtender" completionlistitemcssclass="AutoExtenderList"
              completionlisthighlighteditemcssclass="AutoExtenderHighlight" enabled="True" servicemethod="GetCodes"
              completionsetcount="20" servicepath="~/AutoComplete.asmx" completioninterval="100"
              minimumprefixlength="1" enablecaching="false" targetcontrolid="txtcustomer" usecontextkey="true"
              contextkey="customer" completionlistelementid="dvcust">
                            </ajaxct:autocompleteextender>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlZone" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="From Date"></asp:Label><br />
                    <asp:TextBox ID="txtFromdate" autocomplete="off"  Width="80px" CssClass="inp-form"
                        TabIndex="2" runat="server"></asp:TextBox>
                      <ajaxct:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txtFromdate"
                        format="dd/MM/yyyy" />
                    <ajaxct:maskededitextender id="MaskedEditExtender1" runat="server" targetcontrolid="txtFromdate"
                        masktype="Date" mask="99/99/9999" messagevalidatortip="false" autocomplete="false" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require Date"
                        ValidationGroup="balancecReport" ControlToValidate="txtFromdate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="To Date"></asp:Label><br />
                    <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                        Enabled="true"></asp:TextBox>
                    <ajaxct:calendarextender id="CalendarExtender3" runat="server" targetcontrolid="txttoDate"
                        format="dd/MM/yyyy" />
                    <ajaxct:maskededitextender id="MaskedEditExtender2" runat="server" targetcontrolid="txttoDate"
                        masktype="Date" mask="99/99/9999" messagevalidatortip="false" autocomplete="false" />
                    <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require Date"
                        ValidationGroup="balancecReport" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                </td>
                <td valign="top">
                    <br />
                    <asp:Button ID="btnget" OnClick="Button1_Click" runat="server" Width="80px" Text="Get" ValidationGroup="balancecReport"
                        CssClass="submitbtn" TabIndex="3" Style="height: 26px" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtcustomer" EventName="TextChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <ajaxct:maskededitvalidator validationgroup="balancecReport" id="MaskedEditValidator1"
                        runat="server" controltovalidate="txttoDate" controlextender="MaskedEditExtender2"
                        cssclass="RedLabel" display="Dynamic" emptyvalueblurredtext="Select to date"
                        invalidvalueblurredmessage="Invalid Date" isvalidempty="false" style="color: #000;
                        font-size: 12px;" validationexpression="^\d{2}/\d{2}/\d{4}$">    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </ajaxct:maskededitvalidator>
                </td>
            </tr>
        </table>
    </asp:Panel>
   
    <CR:CrystalReportViewer ID="crtcustomer" runat="server" HasCrystalLogo="False" HasGotoPageButton="True"
        AutoDataBind="false" HasSearchButton="True" DisplayGroupTree="False" EnableDatabaseLogonPrompt="false"
        EnableDrillDown="false" EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="false"
        HasDrillUpButton="False" HasPageNavigationButtons="True" HasRefreshButton="False"
         HasToggleGroupTreeButton="false" HasViewList="False"
        HasZoomFactorList="False" Width="773px" />
</asp:Content>
