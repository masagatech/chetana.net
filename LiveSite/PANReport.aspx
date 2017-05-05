<%@ Page Title="Pan Report" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="PANReport.aspx.cs" Inherits="PANReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            PAN Report<a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
        <asp:Panel ID="pnlra" runat="server">
            <div style="float: right; width: 58%">
                <div id="filter" runat="server">
                </div>
            </div>
        </asp:Panel>
        <div class="options">
        </div>
    </div>
    <asp:UpdatePanel ID="updatePen" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlnew" runat="server" DefaultButton="btnGet" CssClass="panelDetails" Width="680px" Height="25px">
                <asp:RadioButton ID="rdbAll" runat="server" GroupName="All" Text="All" OnCheckedChanged="rdbAll_Selected" AutoPostBack="true" />&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="rdbAmount" runat="server" GroupName="All" Text="Amount" OnCheckedChanged="rdbAmount_Selected" AutoPostBack="true"></asp:RadioButton>
                <asp:TextBox ID="txtAmount" runat="server" Visible="false" CssClass="inp-form" onkeypress="return CheckNumeric(event)"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Super Zone"></asp:Label>
                <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server"
                    DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="150px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required Super Zone"
            ValidationGroup="V" ControlToValidate="DDLSuperZone" InitialValue="0">*</asp:RequiredFieldValidator>--%>
                <asp:Label ID="Label2" runat="server" Text="Zone"></asp:Label>
                <asp:DropDownList ID="DDLZone" runat="server" TabIndex="2" CssClass="ddl-form"
                    DataTextField="ZoneName" DataValueField="ZoneID" Width="150px">
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Zone"
            ValidationGroup="V" ControlToValidate="DDLZone" InitialValue="0">*</asp:RequiredFieldValidator>--%>
                <asp:Button ID="btnGet" runat="server" CssClass="submitbtn" Text="Get" Width="53px" TabIndex="3"
                    ValidationGroup="V" OnClick="Get_Click" />
                <%--<asp:Button ID="btnClear" runat="server" CssClass="submitbtn" Text="Clear" Width="53px" TabIndex="4"
            OnClick="btnClear_Click" />--%>
                <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" ValidationGroup="V" runat="server" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


    <br />
    <asp:Panel ID="newPanel" runat="server">
        <CR:CrystalReportViewer ID="CrystalPanReport" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false"
            EnableDrillDown="true" EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true"
            HasDrillUpButton="True" HasGotoPageButton="True" HasPageNavigationButtons="True"
            HasRefreshButton="true" HasSearchButton="false" HasToggleGroupTreeButton="True"
            HasZoomFactorList="false" DisplayGroupTree="False" />
    </asp:Panel>
</asp:Content>

