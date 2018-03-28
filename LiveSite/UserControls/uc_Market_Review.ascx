<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Market_Review.ascx.cs"
    Inherits="UserControls_uc_Market_Reviewl" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>Market Review<a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
</div>
<div style="padding-left: 512px; padding-bottom: 7px;">
    <asp:Button ID="btnSave" runat="server" CssClass="submitbtn" Text="Save" ValidationGroup="AZone123" TabIndex="5"
        Width="75" OnClick="btnSave_Click" />
   <%--      <asp:Button ID="btnView" runat="server" CssClass="submitbtn" Text="Save" 
        Width="75" OnClick="btnView_Click" />--%>
    <asp:ValidationSummary ID="vsummery" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="AZone123" />
</div>
<asp:Panel ID="Pnldeldate" CssClass="panelDetails" runat="server" Width="550px">
    <table cellpadding="5" cellspacing="5" width="100%">
        <tr>
            <td>
                <asp:Label ID="lblSDZoneName" runat="server" Text="Super Duper Zone :"></asp:Label>
            </td>
            <td valign="top">
                <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="250px" DataTextField="SDZoneName"
                    DataValueField="SDZoneId" AutoPostBack="true" runat="server" TabIndex="0" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Super Duper Zone"
                    InitialValue="0" ValidationGroup="AZone123" ControlToValidate="ddlSDZone">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblsuperzoe" runat="server" Text="Super Zone :"></asp:Label>
            </td>
            <td valign="top">
                <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server"
                    DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="250px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please Select SuperZone"
                    InitialValue="0" ValidationGroup="AZone123" ControlToValidate="DDLSuperZone">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblZone" runat="server" Text="Zone :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="upanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLZone" runat="server" AutoPostBack="True" CssClass="ddl-form"
                            TabIndex="2" DataTextField="ZoneName" DataValueField="ZoneID" Width="250px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Zone"
                            InitialValue="0" ValidationGroup="AZone123" ControlToValidate="DDLZone">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="lblmarreview" runat="server" Text="Market Review :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtmarketreview" TextMode="MultiLine" Height="80" Width="350" TabIndex="3"
                    runat="server"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="lblcompreview" runat="server" Text="Competitor Review :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcompreview" TextMode="MultiLine" Height="80" Width="350" TabIndex="4"
                    runat="server"></asp:TextBox>
             
            </td>
        </tr>
    </table>
</asp:Panel>
