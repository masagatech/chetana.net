<%@ Page Title="Missing Reciept No" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master"
     AutoEventWireup="true" CodeFile="MissingRecieptNo.aspx.cs" Inherits="MissingRecieptNo" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
           Missing Reciept No<a href="Campaigns.aspx" title="back to campaign list"></a>
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
    <asp:Panel ID="pnlnew" runat="server" DefaultButton="btnGet" CssClass="panelDetails" Width="780px" Height="25px" >
        <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
        <asp:TextBox ID="txtFromDate" runat="server" style="width:73px" TabIndex="1"></asp:TextBox>
        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate"
            Format="dd/MM/yyyy" />
        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromDate"
            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
            AutoComplete="true" CultureName="en-US" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required From Date"
            ValidationGroup="V" ControlToValidate="txtFromDate">*</asp:RequiredFieldValidator>
        <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
        <asp:TextBox ID="txtToDate" runat="server" style="width:73px" TabIndex="2"></asp:TextBox>
        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate"
            Format="dd/MM/yyyy" />
        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtToDate"
            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
            AutoComplete="true" CultureName="en-US" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required To Date"
            ValidationGroup="V" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
        <asp:Label ID="Label1" runat="server" Text="Super Zone"></asp:Label>
         <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="3" runat="server"
           DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="150px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
           AutoPostBack="True">
           </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Zone"></asp:Label>
         <asp:DropDownList ID="DDLZone" runat="server" TabIndex="4" CssClass="ddl-form"
          DataTextField="ZoneName" DataValueField="ZoneID" Width="150px">
          </asp:DropDownList>
        <asp:Button ID="btnGet" runat="server" CssClass="submitbtn" Text="Get" Width="53px" TabIndex="5"
            OnClick="Get_Click" ValidationGroup="V" />
    </asp:Panel>
    <br />
    <asp:Panel ID="newPanel" runat="server">
        <CR:CrystalReportViewer ID="crystalMissing" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false"
                    EnableDrillDown="true" EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true"
                    HasDrillUpButton="True" HasGotoPageButton="True" HasPageNavigationButtons="True"
                    HasRefreshButton="true" HasSearchButton="false" HasToggleGroupTreeButton="True"
                    HasZoomFactorList="false" DisplayGroupTree="False"/>
    </asp:Panel>
    
</asp:Content>

