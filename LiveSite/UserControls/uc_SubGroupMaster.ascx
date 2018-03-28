<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SubGroupMaster.ascx.cs" Inherits="UserControls_uc_SubGroupMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">

    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
         <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div> 

 <div style="float: right; width: 50%">      
    <div id="filter" runat="server" style="width:220px; clear:both; float:left;"> <span>Filter Data:</span>
        <input name="filt" id="find" onkeyup="filter(this, 'sf', '1')" type="text"> </div>

</div>
<div style="float: right; width: 72%">
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="5" runat="server" Text="Save"
            Width="70px"  ValidationGroup="A" /> 
</div>
<br />
<br />
<asp:Panel ID="pnlsubgrpmaster" CssClass="panelDetails" runat="server" Width="345px">


</asp:Panel>


