<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Market_View.ascx.cs"
    Inherits="UserControls_Market_View" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>Market View<a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
</div>
<div id="divall" runat="server" style="padding-bottom: 5px;">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblSDZoneName" runat="server" Text="Super Duper Zone :"></asp:Label>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="160px" DataTextField="SDZoneName"
                            DataValueField="SDZoneId" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Super Duper Zone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblsuperzoe" runat="server" Text="Super Zone :"></asp:Label>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" runat="server" DataTextField="SuperZoneName"
                            DataValueField="SuperZoneID" Width="160px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please Select SuperZone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSDZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblZone" runat="server" Text="Zone :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="upanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLZone" runat="server" AutoPostBack="True" CssClass="ddl-form"
                            TabIndex="0" DataTextField="ZoneName" DataValueField="ZoneID" Width="160px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Zone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="DDLZone" Display="None">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="padding-left: 30px;">
                <asp:DropDownList ID="ddlSummery" runat="server" CssClass="ddl-form" Width="160px">
                    <asp:ListItem Text="Summery" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Details" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="padding-left: 30px;">
                <asp:Button ID="btnAllReport" runat="server" CssClass="submitbtn" Text="Get Report"
                    Width="75" OnClick="btnAllReport_Click" />
                <%-- <asp:ValidationSummary ID="vsummery" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="savef" />--%>
            </td>
        </tr>
    </table>
</div>
<asp:Panel ID="Pnlgrdview" CssClass="panelDetails" runat="server" Width="955px" Visible="false">
    <br />
    <asp:GridView ID="grdView" CssClass="product-table" runat="server" AutoGenerateColumns="false"
        RowStyle-HorizontalAlign="Center">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:TemplateField HeaderText="Super Duper Zone">
                <ItemTemplate>
                    <asp:LinkButton ID="lblzone" runat="server" Text='<%#Eval("SuperZoneName")%>' OnClick="lblzone_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Super Zone">
                <ItemTemplate>
                    <asp:LinkButton ID="lblzone" runat="server" Text='<%#Eval("SDZoneName")%>' OnClick="lblzone_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Zone">
                <ItemTemplate>
                    <asp:Label ID="lblzoneid" runat="server" Style="display: none;" Text='<%#Eval("ZoneID")%>'></asp:Label>
                    <asp:Label ID="lblsupzoneid" runat="server" Style="display: none;" Text='<%#Eval("SuperZoneID")%>'></asp:Label>
                    <asp:Label ID="lblsupdupzoneid" runat="server" Style="display: none;" Text='<%#Eval("SDZoneID")%>'></asp:Label>
                    <asp:LinkButton ID="lblzone" runat="server" Text='<%#Eval("ZoneName")%>' OnClick="lblzone_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Market Reviews">
                <ItemTemplate>
                    <asp:Label ID="lblmark" runat="server" Text='<%#Eval("markcount")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Competitor Reviews">
                <ItemTemplate>
                    <asp:Label ID="lblcom" runat="server" Text='<%#Eval("comcount")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lblempty" runat="server" Text="No Data Available!!!" ForeColor="Red"
                Font-Bold="true" Font-Size="Medium"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Panel>
<div id="divbutton" runat="server" style="padding-left: 570px; padding-bottom: 7px;"
    visible="false">
    <asp:Button ID="btnBack" runat="server" CssClass="submitbtn" Text="Back" Width="75"
        OnClick="btnBack_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnReport" runat="server" CssClass="submitbtn" Text="Get Report"
        Width="75" OnClick="btnReport_Click" />
</div>
<asp:Panel ID="pnlgrdDeatils" CssClass="panelDetails" runat="server" Width="700px"
    Visible="false">
    <br />
    <div style="font-size: 10pt;">
        <center>
            <table cellpadding="3" cellspacing="3">
                <tr>
                    <td>
                        <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Super Duper Zone : "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMSDZ" runat="server" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" Font-Bold="true" runat="server" Text="Super Zone : "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMSZ" runat="server" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" Font-Bold="true" runat="server" Text="Zone : "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMZ" runat="server" ForeColor="White"></asp:Label>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <br />
    <asp:GridView ID="grdDeatils" CssClass="product-table" RowStyle-Wrap="true" Width="700px"
        runat="server" AutoGenerateColumns="false">
        <RowStyle Wrap="True" />
        <Columns>
            <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="Chkselect" runat="server"></asp:CheckBox>
                    <asp:Label ID="lblmarkid" runat="server" Style="display: none;" Text='<%#Eval("Market_ID")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Market Review" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:Label ID="lblmarkreview" runat="server" Text='<%#Eval("Market_View")%>' Width="150px"
                        Style="overflow: hidden;"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Competitor Reviews" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:Label ID="lblcomreview" runat="server" Text='<%#Eval("Competitor_View")%>' Width="150px"
                        Style="overflow: hidden;"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lblView" runat="server" Text="View" OnClick="lblView_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
          <EmptyDataTemplate>
            <asp:Label ID="lblempty" runat="server" Text="No Data Available!!!" ForeColor="Red"
                Font-Bold="true" Font-Size="Medium"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Panel>
<br />
<CR:CrystalReportViewer ID="MarketReview" runat="server" AutoDataBind="true" DisplayGroupTree="false"
    EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
    EnableTheming="false" HasDrillUpButton="false" HasPageNavigationButtons="true"
    HasRefreshButton="true" HasSearchButton="false" HasViewList="false" HasZoomFactorList="false"
    Height="1039px" Width="773px" ShowAllPageIds="True" />
<br />
<asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Width="700px">
    <br />
    <asp:ImageButton ID="imgbtn" runat="server" ImageUrl="../Images/button-cross.png"
        Style="float: right; border: ridge 2px #ccc; background-color: Maroon;" />
    <asp:GridView ID="GridView1" CssClass="product-table" RowStyle-Wrap="true" Width="700px"
        runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Market Review" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <div style="width: 300px; height: auto; white-space: normal; padding: 3px 0px 3px 5px;">
                        <asp:Label ID="lblmarkreview" runat="server" Text='<%#Eval("Market_View")%>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Competitor Reviews" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <div style="white-space: normal; width: 300px; height: auto; padding: 3px 0px 3px 5px;">
                        <asp:Label ID="lblcomreview" runat="server" Text='<%#Eval("Competitor_View")%>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<asp:LinkButton ID="lblcontrol" runat="server" Style="display: none;"></asp:LinkButton>
<ajaxCt:ModalPopupExtender ID="mdpextender" runat="server" PopupControlID="Panel1"
    CancelControlID="imgbtn" TargetControlID="lblcontrol">
</ajaxCt:ModalPopupExtender>
