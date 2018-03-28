<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DCReturnBook_MD.aspx.cs" Inherits="DCReturnBook_MD" Title="DC-Manual ReturnBook" %>

<%@ Register src="UserControls/ODC/uc_DC__Returnbook.ascx" tagname="uc_DC__Returnbook" tagprefix="uc1" %>

<%@ Register src="UserControls/ODC/uc_DC_GenerateCN.ascx" tagname="uc_DC_GenerateCN" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>--%>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>
        Return Book <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
 <p></p>
    <asp:Panel ID="Pnlselect" CssClass="panelDetails" runat="server" Width="963px">
    <table>
   <tr>
    <td width ="120px">
    <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Select Returned Type "></asp:Label>
   </td>
    <td>
        <asp:RadioButtonList ID="RdbtnSelect1" runat="server" RepeatDirection="Horizontal" CssClass="lbl-form"
            Width="150px" OnSelectedIndexChanged="RdbtnSelect1_SelectedIndexChanged" AutoPostBack="True">
              <asp:ListItem Value="DC" Text="DC" Selected="True"></asp:ListItem>
              <asp:ListItem Value="Manual" Text="Manual"></asp:ListItem>
        </asp:RadioButtonList>
    </tr>
    </table>
    </asp:Panel>    
    <asp:Panel ID="PnlDC" runat="server">
    <uc1:uc_DC__Returnbook ID="uc_DC__Returnbook1" runat="server" />
    </asp:Panel>
    <asp:Panel ID="PnlM" runat="server">
    <uc2:uc_DC_GenerateCN ID="uc_DC_GenerateCN1" runat="server" />
    </asp:Panel>
</asp:Content>



