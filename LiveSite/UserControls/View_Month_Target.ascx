<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View_Month_Target.ascx.cs"
    Inherits="View_Month_Target" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        View Edit Month Target<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<br />
<br />
<div style="padding-bottom: 7px; width: 558px;">
    <asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Width="520px" Height="50px">
        <asp:UpdatePanel ID="updatepnl" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <%--<asp:DropDownList ID="ddlmonth" runat="server" Style="float: left;"  >
                </asp:DropDownList>--%>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Super Zone"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Zone"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlsuperzoneid" runat="server" AutoPostBack="true" Height="23px"
                                OnSelectedIndexChanged="ddlsuperzoneid_SelectedIndexChanged" Width="187px" TabIndex="1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                                InitialValue="0" ValidationGroup="AZone" ControlToValidate="ddlsuperzoneid">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLZone" runat="server" CssClass="ddl-form" DataTextField="ZoneName"
                                DataValueField="ZoneID" Height="23px" Width="177px" TabIndex="2">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Zone"
                                InitialValue="0" ValidationGroup="AZone" ControlToValidate="DDLZone">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ID="btnget" runat="server" CssClass="submitbtn" OnClick="btnget_Click"
                                Text="Get" Width="75" TabIndex="3" ValidationGroup="AZone" />
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="submitbtn" OnClick="btnSave_Click"
                                Text="Update" Visible="false" Width="75" />
                            <asp:Button ID="btnUpdate" runat="server" CssClass="submitbtn" OnClick="btnUpdate_Click"
                                Text="Edit" Visible="false" Width="75" TabIndex="4" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</div>
<br />
<br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlradio" CssClass="panelDetails" runat="server" Width="520px" Visible="false">
            <asp:GridView ID="grdTarget" runat="server" AutoGenerateColumns="false" CellPadding="0"
                CssClass="product-table" RowStyle-HorizontalAlign="Center" CellSpacing="0">
                <RowStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="Month">
                        <ItemTemplate>
                            <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("MonthName") %>'></asp:Label>
                            <asp:Label ID="lblmonthno" runat="server" Text='<%#Eval("monthno") %>' Style="display: none;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Target (%)">
                        <ItemTemplate>
                            <asp:TextBox ID="txtTarget" runat="server" Enabled="false" AutoPostBack="true" onkeypress="return CheckNumericWithDot(event)"
                                Text='<%#Eval("TargetPercent","{0:00}") %>' OnTextChanged="txtTarget_TextChanged"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Target Amount">
                        <ItemTemplate>
                            <asp:TextBox ID="txtTargetAmt" runat="server" Enabled="false" onkeypress="return CheckNumericWithDot(event)"
                                Text='<%#Eval("TargetAmt","{0:0.00}") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ss" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlsuperzoneid" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnget" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
