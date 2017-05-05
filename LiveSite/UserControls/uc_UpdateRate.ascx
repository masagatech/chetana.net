<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_UpdateRate.ascx.cs"
    Inherits="UserControls_uc_UpdateRate" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>
        Update Rate
        <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    
    </div>
</div>
<asp:Panel ID="Pnlur" CssClass="panelDetails" Width="7%" runat="server">
    <asp:Button ID="btnupdate" CssClass="submitbtn" TabIndex="13" runat="server" Text="Update Rate"
        ValidationGroup="rate" Width="80px" onclick="btnupdate_Click" />
        </asp:Panel>
