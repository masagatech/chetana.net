<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_PurchaseMaster_Ind_View.ascx.cs"
  Inherits="UserControls_uc_PurchaseMaster_Ind_View" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
  Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
  <div class="title">
    <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
    Purchase Master View<a href="#" title="back to campaign list"></a>
  </div>
</div>
<asp:Panel ID="pnlArea" CssClass="panelDetails" runat="server" Width="710px">
  <table cellpadding="2" cellspacing="2" style="width: 60%">
    <tr>
      <td>
        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="From Date"></asp:Label>
        <font color="red">*</font>
      </td>
      <td>
        <asp:TextBox ID="txtfromdate" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
        <ajaxct:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txtfromdate"
          format="dd/MM/yyyy" />
        <ajaxct:maskededitextender id="meeRequestDate" runat="server" targetcontrolid="txtfromdate"
          masktype="Date" mask="99/99/9999" acceptampm="true" messagevalidatortip="false"
          autocomplete="true" culturename="en-US" />
      </td>
      <td>
        <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="To Date"></asp:Label>
        <font color="red">*</font>
      </td>
      <td>
        <asp:TextBox ID="txttodate" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
        <ajaxct:calendarextender id="CalendarExtender12" runat="server" targetcontrolid="txttodate"
          format="dd/MM/yyyy" />
        <ajaxct:maskededitextender id="MaskedEditExtender1" runat="server" targetcontrolid="txttodate"
          masktype="Date" mask="99/99/9999" acceptampm="true" messagevalidatortip="false"
          autocomplete="true" culturename="en-US" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Invoice No"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtinvoice" CssClass="inp-form" TabIndex="3" runat="server"></asp:TextBox>
      </td>
      <td>
      </td>
      <td>
        <asp:Button ID="btnget" runat="server" TabIndex="4" CssClass="submitbtn" Text="Get"
          Width="80px" ValidationGroup="date" OnClick="btnget_Click" />
      </td>
    </tr>
  </table>
</asp:Panel>
<CR:CrystalReportViewer ID="repPurchaseMasterView" runat="server" AutoDataBind="true"
  DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
  EnableParameterPrompt="false" HasCrystalLogo="False" HasSearchButton="True" EnableTheming="false"
  HasDrillUpButton="false" HasPageNavigationButtons="true" HasRefreshButton="true"
  HasToggleGroupTreeButton="False" HasViewList="false" HasZoomFactorList="false"
  Width="773px" ShowAllPageIds="True" />
