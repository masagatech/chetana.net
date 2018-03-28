<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DestinationMaster.ascx.cs"
  Inherits="UserControls_uc_DestinationMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
 <div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
        ADD/EDIT Destination <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
        <asp:Button ID="Button1" CssClass="form-submit" TabIndex="4" runat="server" Text="Save"
      Width="80px" OnClick="Btnsave_Click" />
        <asp:Button ID="btncancel" CssClass="form-submit" TabIndex="5" runat="server" Text="Cancel" Width="80px" />
    </div>
</div>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
      <ContentTemplate>
        <asp:Panel ID="Panel1" CssClass="panelDetails" runat="server">
          <table width="50%" cellpadding="0" cellspacing="0">
            <tr>
              <td>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="DM Code"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtDmcode" TabIndex="1" CssClass="inp-form" runat="server" 
                      MaxLength="20"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Name"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtname" TabIndex="2" CssClass="inp-form" runat="server"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
              </td>
              <td>
                <asp:CheckBox ID="ChekActivE" TabIndex="3" runat="server" Checked="true" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </ContentTemplate>
    </asp:UpdatePanel>
 