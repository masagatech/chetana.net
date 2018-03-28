<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_FacultySummeryDetails.ascx.cs"
    Inherits="UserControls_uc_FacultySummeryDetails" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Teachers&#39; View</div>
    <div class="options">
    </div>
</div>
<div style="padding-bottom: 10px;">
    <table cellpadding="5" cellspacing="5">
        <tr>
            <td>
                <asp:Label ID="lblSDZoneName" runat="server" Text="Super Duper Zone :"></asp:Label>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="160px" DataTextField="SDZoneName"
                            TabIndex="1" DataValueField="SDZoneId" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Super Duper Zone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="ddlSDZone">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblsuperzoe" runat="server" Text="Super Zone :"></asp:Label>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="160px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please Select SuperZone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="DDLSuperZone">*</asp:RequiredFieldValidator>
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
                            TabIndex="3" DataTextField="ZoneName" DataValueField="ZoneID" Width="160px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Zone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="DDLZone" Display="None">*</asp:RequiredFieldValidator>
                       --%>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlsumdet" runat="server" CssClass="ddl-form" TabIndex="4"
                            AutoPostBack="True" Width="160px" OnSelectedIndexChanged="ddlsumdet_SelectedIndexChanged">
                            <asp:ListItem Text="Summery" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Details" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="padding-left: 20px;" rowspan="2" valign="top">
                <asp:Button ID="btnGet" runat="server" Text="View" OnClick="btnGet_Click" TabIndex="5"
                    ValidationGroup="savef" CssClass="submitbtn" />
                <asp:ValidationSummary ID="vsummery" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="savef" />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <br />
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Pnlfacultyapproves" CssClass="pnldash" GroupingText="Select" runat="server"
                            Width="370px" Visible="false">
                            <br />
                            <asp:RadioButtonList ID="rdoselect" Width="400px" runat="server" CellPadding="3"
                                CellSpacing="3" RepeatColumns="4" RepeatDirection="Horizontal">
                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Pending"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Approve" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Reject"></asp:ListItem>
                            </asp:RadioButtonList>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlsumdet" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlsummery" CssClass="panelDetails" runat="server" Width="955px" Visible="false">
                <br />
                <center>
                    <asp:Label ID="lblheading" runat="server" Text="Faculty Summery View" Font-Underline="true"
                        Font-Bold="true" Font-Size="Medium"></asp:Label></center>
                <br />
                <asp:GridView ID="grdsummery" runat="server" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center"
                    CssClass="product-table">
                    <Columns>
                        <asp:TemplateField HeaderText="Super Zone">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("SuperZoneName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zone">
                            <ItemTemplate>
                                <asp:Label ID="lblsi" runat="server" Text='<%#Eval("ZoneName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="lbladd" runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Accept">
                            <ItemTemplate>
                                <asp:Label ID="lblcont" runat="server" Text='<%#Eval("Acpt") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <center>
                            <asp:Label ID="lblempty" runat="server" Text="No Data Available!!!" ForeColor="Red"
                                Font-Bold="true" Font-Size="Medium"></asp:Label></center>
                    </EmptyDataTemplate>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlsumdet" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlfacultyview" CssClass="panelDetails" runat="server" Width="955px"
                Visible="false">
                <br />
                <center>
                    <asp:Label ID="Label1" runat="server" Text="Faculty Detail View" Font-Underline="true"
                        Font-Bold="true" Font-Size="Medium"></asp:Label></center>
                <br />
                <asp:GridView ID="grdfacultyview" runat="server" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center"
                    CssClass="product-table">
                    <Columns>
                        <asp:TemplateField HeaderText="Super Zone">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("SuperZoneName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zone">
                            <ItemTemplate>
                                <asp:Label ID="lblsi" runat="server" Text='<%#Eval("ZoneName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="School / Institute">
                            <ItemTemplate>
                                <asp:Label ID="lblsi" runat="server" Text='<%#Eval("Schl_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lbladd" runat="server" Text='<%#Eval("Res_Add") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact No">
                            <ItemTemplate>
                                <asp:Label ID="lblcont" runat="server" Text='<%#Eval("Contact") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qualification">
                            <ItemTemplate>
                                <asp:Label ID="lblquf" runat="server" Text='<%#Eval("Qualification") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Exp">
                            <ItemTemplate>
                                <asp:Label ID="lblexp" runat="server" Text='<%#Eval("Tch_Exp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Specialised">
                            <ItemTemplate>
                                <asp:Label ID="lblspec" runat="server" Text='<%#Eval("Spec_Sub") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Writing<br/> Intrest">
                            <ItemTemplate>
                                <asp:Label ID="lblwint" runat="server" Text='<%#Eval("Sub_Intrs_Wrt") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Previous<br/>  Writing<br/>  Intrest">
                            <ItemTemplate>
                                <asp:Label ID="lblpwi" runat="server" Text='<%#Eval("Prvs_Exp_Wrt") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <center>
                            <asp:Label ID="lblempty" runat="server" Text="No Data Available!!!" ForeColor="Red"
                                Font-Bold="true" Font-Size="Medium"></asp:Label></center>
                    </EmptyDataTemplate>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlsumdet" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</div>
