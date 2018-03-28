<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_BankMaster.ascx.cs"
  Inherits="UserControls_uc_BankMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
      <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
     <div id="filter" runat="server">
      <span>Filter Data:</span>
      <input name="filt" onkeyup="filter(this, 'sf', '<%=grdBankDetails.ClientID%>')" type="text"></div>
  </div>
    </div>
<div style="float: right; width: 70%">
            <asp:Button ID="btnsave" CssClass="submitbtn" runat="server" Text="Save" ValidationGroup="Bank"
      Width="80px" OnClick="btnsave_Click" />
      </ContentTemplate>
</div>
<br />
<br />
<asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Width="450px">
  <table width="70%" cellpadding="0" cellspacing="0">
    <tr>
      <td>
        <asp:Label ID="lblBankId" CssClass="lbl-form" runat="server" Style="display: none;"
          Text="0"></asp:Label>
        <asp:Label ID="lblBcode" CssClass="lbl-form" runat="server" Text="Bank Code"></asp:Label>
        <font color="red">*</font>
      </td>
      <td>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
          <ContentTemplate>
            <asp:TextBox ID="txtbankCode" CssClass="inp-form" AutoPostBack="True" runat="server"
              Width="82px" Style="margin-left: 12px" OnTextChanged="txtbankCode_TextChanged"></asp:TextBox>
            </td>
            <td>
              <asp:RequiredFieldValidator ID="reqBcode" runat="server" ErrorMessage="Require Bank Code"
                ValidationGroup="Bank" ControlToValidate="txtbankCode">*</asp:RequiredFieldValidator>
          </ContentTemplate>
        </asp:UpdatePanel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblBname" CssClass="lbl-form" runat="server" Text="Bank Name"></asp:Label>
        <font color="red">*</font>
      </td>
      <td>
        <asp:TextBox ID="txtbankName" CssClass="inp-form" runat="server" Width="186px" Style="margin-left: 11px"></asp:TextBox>
      </td>
      <td>
        <asp:RequiredFieldValidator ID="ReqbName" runat="server" ErrorMessage="Require Bank Name"
          ValidationGroup="Bank" ControlToValidate="txtbankName">*</asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblBdesc" CssClass="lbl-form" runat="server" Text="Bank Description"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtbDesc" CssClass="inp-form" runat="server" TextMode="MultiLine"
          Width="188px" Style="margin-left: 11px"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblcountry" CssClass="lbl-form" runat="server" Text="Country"></asp:Label>
        <font color="red">*</font>
      </td>
      <td>
        <asp:TextBox ID="txtcountry" CssClass="inp-form" runat="server" Width="186px" Style="margin-left: 11px"></asp:TextBox>
      </td>
      <td>
        <asp:RequiredFieldValidator ID="Reqcontry" runat="server" ErrorMessage="Require Country"
          ValidationGroup="Bank" ControlToValidate="txtcountry">*</asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblstate" CssClass="lbl-form" runat="server" Text="State"></asp:Label>
      </td>
      <td>
        <asp:DropDownList  CssClass="ddl-form" ID="DDLstate" runat="server" Width="150px" Style="margin-left: 11px" DataValueField="DMID"
          DataTextField="Name" AutoPostBack="true" OnSelectedIndexChanged="DDLstate_SelectedIndexChanged">
        </asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblcity" CssClass="lbl-form" runat="server" Text="City"></asp:Label>
      </td>
      <td>
        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
          <ContentTemplate>
            <asp:DropDownList  CssClass="ddl-form" ID="DDLCity" runat="server" Width="110px" Style="margin-left: 11px" Enabled="false" DataValueField="DMID"
              DataTextField="Name">
            </asp:DropDownList>
          </ContentTemplate>
          <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DDLstate" EventName="SelectedIndexChanged" />
          </Triggers>
        </asp:UpdatePanel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblchek" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
      </td>
      <td>
        <asp:CheckBox ID="chekactive" runat="server" Checked="true" />
      </td>
    </tr>
  </table>
</asp:Panel>
<asp:Panel ID="pnlBank" runat="server">
  <asp:GridView ID="grdBankDetails" AutoGenerateColumns="false" AllowPaging="true"
    PageSize="10" CellPadding="4" CssClass="product-table" ForeColor="#333333" Width="600px"
    runat="server" OnPageIndexChanging="grdBankDetails_PageIndexChanging" OnRowEditing="grdBankDetails_RowEditing"
    OnRowDeleting="grdBankDetails_RowDeleting">
    <Columns>
      <asp:TemplateField HeaderText="Bank Code" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Left">
        <ItemTemplate>
          <asp:Label ID="lblbankID" runat="server" Style="display: none;" Text='<%#Eval("BankID")%>'></asp:Label>
          <asp:Label ID="lblBnkCode" runat="server" Text='<%#Eval("BankCode")%>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Bank Name" HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Left">
        <ItemTemplate>
          <asp:Label ID="lblBnkName" runat="server" Text='<%#Eval("BankName")%>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Active" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
          <asp:CheckBox ID="chkactive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false">
          </asp:CheckBox>
          <asp:Label ID="lblbankdecp" runat="server" Style="display: none;" Text='<%#Eval("BankDescription") %>'></asp:Label>
          <asp:Label ID="lblcountry" runat="server" Style="display: none;" Text='<%#Eval("Country") %>'></asp:Label>
          <asp:Label ID="lblstate" runat="server" Style="display: none;" Text='<%#Eval("State") %>'></asp:Label>
          <asp:Label ID="lblcity" runat="server" Style="display: none;" Text='<%#Eval("City") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="center"
        HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
          <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
            CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
          &nbsp;&nbsp;&nbsp;
          <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
            CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Are u sure u wat to Delete?')" />
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Bank"
  runat="server" ID="ss" />
  <script type="text/javascript">
     setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
   document.getElementById('status').innerHTML=status;
   }
        </script>
<script type="text/javascript">
      
shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_BankMaster1_btnsave').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>
