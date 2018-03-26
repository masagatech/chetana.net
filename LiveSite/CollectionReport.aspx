<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="CollectionReport.aspx.cs" Inherits="CollectionReport" Title="Collection Report" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: right; width: 101%">
        <div class="section-header">
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Collection reced agst Target for the month<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="820px">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                            InitialValue="0" ValidationGroup="AZone1" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td width="60px">
                        <asp:Label ID="Label11" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
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
                    <td width="60px">
                        <asp:Label ID="Label7" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                            color="red">*</font> &nbsp;
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
                    <td>
                        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="8" runat="server" Text="Get Data"
                            Width="80px" ValidationGroup="AZone" OnClick="btnSave_Click" />
                        <asp:Button ID="btnexport" CssClass="submitbtn" TabIndex="8" runat="server" Text="Export to Excel"
                            Width="100px" ValidationGroup="AZone" OnClick="btnexport_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="rdWeek" Checked="true" runat="server" AutoPostBack="true" OnCheckedChanged="rdWeek_CheckedChanged" Text="Week" GroupName="week" />
                    </td>
                    <td>
                        <asp:RadioButton ID="rdMonth" runat="server" Text="Month" AutoPostBack="true" OnCheckedChanged="rdMonth_CheckedChanged" GroupName="week" />
                        <asp:DropDownList CssClass="ddl-form" Visible="false" ID="ddlMonth" TabIndex="10" runat="server" Width="200px">
                            <asp:ListItem Value="mc">Details</asp:ListItem>
                            <asp:ListItem Value="mcSummary" Selected="True">Summary</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
        <CR:CrystalReportViewer ID="collectionReportView" runat="server" AutoDataBind="true" DisplayGroupTree="false"
            EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
            EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
            HasRefreshButton="true" HasSearchButton="True" HasToggleGroupTreeButton="False"
            OnUnload="collectionReportView_Unload" HasViewList="false" HasZoomFactorList="false"
            Height="1039px" Width="773px" ShowAllPageIds="True" />
    </div>
    <asp:Panel ID="panelGridview" runat="server">
        <asp:DataList ID="months" runat="server" RepeatDirection="Horizontal" OnItemDataBound="months_ItemDataBound">
            <ItemTemplate>
                <asp:Label runat="server" ID="lblmonth" Visible="false" Text='<%#Eval("months") %>'></asp:Label>
                <asp:GridView ID="Monthgrid" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                    ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound="grdapproval_RowDataBound"
                    runat="server">
                    <Columns>
                        <%--<asp:TemplateField HeaderText="Sr.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField> --%>
                        <asp:TemplateField HeaderText="Month">
                            <ItemTemplate>
                                <asp:Label ID="lblmonths" runat="server" Text='<% #Eval("monthnames")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Super zone">
                            <ItemTemplate>
                                <asp:Label ID="lblSuperzoneName" runat="server" Text='<% #Eval("SuperzoneName")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Superzone" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSuperzone" runat="server" Text='<% #Eval("Superzone")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zone" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblZone" runat="server" Text='<% #Eval("Zone")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zone">
                            <ItemTemplate>
                                <asp:Label ID="lblZoneName" runat="server" Text='<% #Eval("ZoneName")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Outstanding">
                            <ItemTemplate>
                                <asp:Label ID="lbloutstanding" Style="float: right" runat="server" Text='<% #Eval("totaloutstanding", "{0:0.00}")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Target Amount">
                            <ItemTemplate>
                                <asp:Label ID="lbltargetamt" Style="float: right" runat="server" Text='<% #Eval("targetamt", "{0:0.00}")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Collection Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblcollectionAmt" Style="float: right" runat="server" Text='<% #Eval("collectionAmt", "{0:0.00}")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Weeks" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblweeks" runat="server" Text='<% #Eval("weeks")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Target percent">
                            <ItemTemplate>
                                <asp:Label ID="lbltargetpercent" Style="float: right" runat="server" Text='<% #Eval("targetpercent", "{0:0.00}")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="50%">
                            <ItemTemplate>
                                <asp:Label ID="lblfiftypercent" Style="float: right" runat="server" Text='<% #Eval("fiftypercent", "{0:0.00}")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="100 %">
                            <ItemTemplate>
                                <asp:Label ID="lblhundredpercent" Style="float: right" runat="server" Text='<% #Eval("hundredpercent", "{0:0.00}")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total count">
                            <ItemTemplate>
                                <asp:Label ID="lbltotalccount" Style="float: right" runat="server" Text='<% #Eval("totalccount")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="toDateofprev">
                    <ItemTemplate>
                        <asp:Label ID="lbltoDateofprev" runat="server" Text='<% #Eval("toDateofprev")%>'>'</asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="fromdateprev">
                    <ItemTemplate>
                        <asp:Label ID="lblfromdateprev" runat="server" Text='<% #Eval("fromdateprev")%>'>'</asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="From date" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblfdate" runat="server" Text='<% #Eval("fdate", "{0:dd/MM/yyyy}")%>'>'</asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                            <ItemStyle Width="80px"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="To date">
                            <ItemTemplate>
                                <asp:Label ID="lbltdate" runat="server" Text='<% #Eval("tdate", "{0:dd/MM/yyyy}")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Deficit percent">
                            <ItemTemplate>
                                <asp:Label ID="lblDeficitpercent" runat="server" Text='<% #Eval("Deficitpercent", "{0:0.00}")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Deficit Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblDeficitAmount" runat="server" Text='<% #Eval("DeficitAmt", "{0:0.00}")%>'>'</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <footertemplate>
				            <div style="text-align: right;">
				           <b><asp:Label ID="lblTotal" runat="server" /></b>
				            </div>
			           </footertemplate>
                    </Columns>
                </asp:GridView>
            </ItemTemplate>
        </asp:DataList>


    </asp:Panel>
</asp:Content>
