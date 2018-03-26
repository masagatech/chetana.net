<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
    AutoEventWireup="true" CodeFile="AdditionalCommissionCal.aspx.cs" Inherits="AdditionalCommissionCal" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <div style="float: right; width: 101%">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Additional Commission Report<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="700px" Height="50px">
            <table>
                <tr>
                    <td colspan="2">
                        <asp:RadioButtonList runat="server" ID="rdAorI" TextAlign="Right" RepeatDirection="Horizontal">
                            <asp:ListItem Value="All"> All</asp:ListItem>
                            <asp:ListItem Value="Individual" Selected="True"> Individual</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                            InitialValue="0" ValidationGroup="AZone" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                        <%--<font color="red">*</font>--%>
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
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Customer Category"
                            Width="100px"></asp:Label>
                        <font color="red"></font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLCC" Width="250px" DataTextField="Name"
                            TabIndex="1" DataValueField="CMID" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblCustomer" runat="server" Text="Customer"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCustmore" runat="server" TabIndex="3" CssClass="ddl-form"
                            Width="200px" DataTextField="CustName" DataValueField="CustID">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" CssClass="submitbtn" runat="server" Text="GetData" Width="60px"
                            ValidationGroup="AZone" OnClick="btnSave_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnExport" CssClass="submitbtn" runat="server" Text="Export" Width="50px"
                            ValidationGroup="AZone" OnClick="btnExport_Click" Visible="false" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div style="float: left; margin: 15px 0 0; text-align: center; width: 70%;">
            <asp:Panel runat="server" ID="pnlGrid" Visible="false">
                <asp:GridView ID="grdAddCommCal" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                    AutoGenerateColumns="false" ShowFooter="true" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Code" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustCode")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Party Name" HeaderStyle-Width="250px">
                            <ItemTemplate>
                                <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SuperZone" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblSuperZoneName" runat="server" Text='<%#Eval("SuperZoneName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ZoneName" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblZoneName" runat="server" Text='<%#Eval("ZoneName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AreaZone" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblAreaZoneName" runat="server" Text='<%#Eval("AreaZoneName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="State" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblSTATE" runat="server" Text='<%#Eval("STATE")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblCITY" runat="server" Text='<%#Eval("CITY")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ADD. DISC" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblAdditinalDis" runat="server" Text='<%#Eval("AdditinalDis")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACT. DISC" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblSchAdditionalDis" runat="server" Text='<%#Eval("SchAdditionalDis")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NET BILL AMT" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblDebitAmount" runat="server" Text='<%#Eval("DebitAmount")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NET CN AMT" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblCNAmt" runat="server" Text='<%#Eval("CNAmt")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NET NETAMT" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblNETAMT" runat="server" Text='<%#Eval("NETAmount")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NET ADD DIS" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblADDDIS" runat="server" Text='<%#Eval("RESULT1")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GROSS BILL AMT" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblDebitAmount2" runat="server" Text='<%#Eval("DebitAmount2")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GROSS CN AMT" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblCNAmt2" runat="server" Text='<%#Eval("CNAmt2")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GROSS NET AMT" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblNETAmount2" runat="server" Text='<%#Eval("NETAmount2")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GROSS ADD DIS" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblRESULT2" runat="server" Text='<%#Eval("RESULT2")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
        <div style="float: left; margin: 0 0 0; text-align: center; width: 70%;">
            <asp:Panel runat="server" ID="pnlIndividual" Visible="true">
                <CR:CrystalReportPartsViewer ID="CrystalReportPartsViewer1" runat="server" AutoDataBind="true"
                    HasPageNavigationLinks="true" />
                <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
                    runat="server" ID="ValidationSummary3" />
                <CR:CrystalReportViewer ID="AdditionalCommission" runat="server" AutoDataBind="true"
                    EnableDatabaseLogonPrompt="false" EnableDrillDown="true" EnableParameterPrompt="false"
                    EnableTheming="false" EnableToolTips="true" HasDrillUpButton="True" HasGotoPageButton="True"
                    HasPageNavigationButtons="True" HasRefreshButton="true" HasSearchButton="false"
                    HasToggleGroupTreeButton="True" HasZoomFactorList="false" DisplayGroupTree="False"
                    OnNavigate="CustomerWiseAmount_Navigate" OnReportRefresh="CustomerWiseAmount_ReportRefresh"
                    OnSearch="CustomerWiseAmount_Search" />
                <asp:HiddenField ID="txtIsExport" runat="server" />

                <script type="text/javascript">
        $("input[title='Export']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
        $("input[title='Print']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
        
                </script>

            </asp:Panel>
        </div>
    </div>
</asp:Content>
