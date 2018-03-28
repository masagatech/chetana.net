<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_StockUpdate.ascx.cs" Inherits="UserControls_uc_StockUpdate" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>

<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
         <span runat="server" id="pageName"></span>
            <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>  
</div>

<%--<div style="float: right; width: 81%">
     <div id="filter" runat="server">
        <span>Filter Data:</span>
        <input name="filt" onkeyup="filter(this, 'sf', '<%=GrdStock.ClientID%>')" type="text">
 </div> --%>
 <div style="float: right; width: 68%">
      <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="5" runat="server" Text="Save" 
        ValidationGroup="Stock" Width="80px" OnClick="btnSave_Click" />  
</div>    
<br />
<br />
<asp:Panel ID="PnlAddStock" CssClass="panelDetails" runat="server" Width="401px">
<caption>
    <br />
</caption>      
<table cellpadding="0" cellspacing="0" style="margin-bottom: 0px; ">
<tr>
    <td width="100px">
        <asp:Label ID="LblStockUpdateID" CssClass="lbl-form" runat="server" Style="display: none"></asp:Label>
        <asp:Label ID="LblBookcode" CssClass="lbl-form" runat="server" Text="Book Code"></asp:Label>
        <font color="red">*</font>
    </td>
    <td>
     <asp:TextBox ID="Txtbkcode" autocomplete="off" TabIndex="1" CssClass="inp-form" runat="server"
        OnTextChanged="Txtbkcode_TextChanged" Width="240px" AutoPostBack="True"></asp:TextBox>
        <div id="divwidth" class="divauto">
        </div>
        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="Txtbkcode"
            UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
        </ajaxCt:AutoCompleteExtender>
        <asp:RequiredFieldValidator ID="ReqBkcode5" runat="server" ErrorMessage="Enter Book Code"
                ValidationGroup="Stock" ControlToValidate="Txtbkcode">.</asp:RequiredFieldValidator>
    </td>
</tr>
    <caption>
        <tr>
            <td>
                <asp:Label ID="LblCStock" runat="server" CssClass="lbl-form" 
                    Text="Current Stock"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtCStock" runat="server" CssClass="inp-form" Enabled="false" 
                    TabIndex="1" Width="80px"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblNStock" runat="server" CssClass="lbl-form" Text="New Stock"></asp:Label>
             <font color="red">*</font>            
            </td>
            <td>
                <asp:TextBox ID="TxtNStock" runat="server" AutoPostBack="True" MaxLength="10"
                    CssClass="inp-form" ontextchanged="TxtNStock_TextChanged" TabIndex="2" 
                    Width="80px"></asp:TextBox>
                <ajaxCt:FilteredTextBoxExtender ID="filterns" runat="server" TargetControlID="TxtNStock"
                    FilterType="Custom, Numbers" ValidChars="+-=/*()." />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqStock" runat="server" 
                    ControlToValidate="TxtNStock" ErrorMessage="Enter New Stock" 
                    ValidationGroup="Stock">.</asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblTStock" runat="server" CssClass="lbl-form" Text="Total Stock"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtTStock" runat="server" CssClass="inp-form" TabIndex="3" MaxLength="10"
                    Width="80px" Enabled="false" ></asp:TextBox>
                <ajaxCt:FilteredTextBoxExtender ID="filterts" runat="server" TargetControlID="TxtTStock"
                    FilterType="Custom, Numbers" ValidChars="+-=/*()." />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td valign=top>
                <asp:Label ID="LblCom" runat="server" CssClass="lbl-form" Text="Comment"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtCom" runat="server" CssClass="inp-form" TabIndex="4" Height="40px" 
                    TextMode="MultiLine" Width="191px"></asp:TextBox>
            </td>
        </tr>
    </caption>

</table>
<caption>
    <br />
</caption>            
</asp:Panel>
<p></p>
<asp:Panel ID ="PnlBkCode" CssClass="panelDetails" runat ="server" Width="860px">
  <table>
        <tr>
        <td width="100px">
        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Book Code"></asp:Label>
    </td>
        <td> 
        <asp:TextBox ID="Txtbkcode1" autocomplete="off" TabIndex="1" CssClass="inp-form" runat="server"
         Width="240px" AutoPostBack="True" ontextchanged="Txtbkcode1_TextChanged"></asp:TextBox>
        <div id="div1" class="divauto">
        </div>
        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="Txtbkcode1"
            UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
        </ajaxCt:AutoCompleteExtender>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Book Code"
            ValidationGroup="Stockr" ControlToValidate="Txtbkcode1">.</asp:RequiredFieldValidator>   --%>    
    </td>   
          <td>
        <asp:Label ID="LblCustName" CssClass="lbl-form" runat="server" ></asp:Label>
          </td>      
       </tr>
       </table>
</asp:Panel>        
<p></p>
<asp:Panel ID="PnlStockDetails" runat="server" Width="900px">
<asp:GridView ID="GrdStock" runat="server" AllowPaging="true" AutoGenerateColumns="False" 
    CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="10" Width="900px"> 
<Columns>
 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Book Code" ItemStyle-HorizontalAlign="left">
<ItemTemplate>
    <%--<asp:Label ID="lblStockUpdateID" runat="server" CssClass="lbl-form" Style="display: none;"
        Text='<%#Eval("StockUpdateID") %>'></asp:Label>--%>
    <asp:Label ID="lblBkCode" runat="server" CssClass="lbl-form" Text='<%#Eval("BookCode") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Book Name" ItemStyle-HorizontalAlign="left">
<ItemTemplate>
    <asp:Label ID="lblBkName" runat="server" CssClass="lbl-form" Text='<%#Eval("BookName") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Medium" ItemStyle-HorizontalAlign="left">
<ItemTemplate>
    <asp:Label ID="lblBkMedium" runat="server" CssClass="lbl-form" Text='<%#Eval("Medium") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Standard" ItemStyle-HorizontalAlign="left">
<ItemTemplate>
    <asp:Label ID="lblBkStd" runat="server" CssClass="lbl-form" Text='<%#Eval("Standard") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Old Stock" ItemStyle-HorizontalAlign="right">
<ItemTemplate>
    <asp:Label ID="lblCStock" runat="server" CssClass="lbl-form" Text='<%#Eval("OldStock") %>'></asp:Label>  
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="New Stock" ItemStyle-HorizontalAlign="right">
<ItemTemplate>
    <asp:Label ID="lblNStock" runat="server" CssClass="lbl-form" Text='<%#Eval("NewStock") %>'></asp:Label>  
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total Stock" ItemStyle-HorizontalAlign="right">
<ItemTemplate>
    <asp:Label ID="lblTStock" runat="server" CssClass="lbl-form" Text='<%#Eval("TotalStock") %>'></asp:Label>  
</ItemTemplate>
</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Comment" HeaderStyle-Width="100px">
<ItemTemplate>
    <asp:TextBox ID="txt1cmmt" CssClass="inp-form" Width="200px" Height="40px" runat="server"
         TextMode="MultiLine" Enabled="false" Text='<%#Eval("Comment") %>'></asp:TextBox>
</ItemTemplate>
    <HeaderStyle Width="80px"></HeaderStyle>
</asp:TemplateField>--%>

<%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action" 
        ItemStyle-HorizontalAlign="Center">
<ItemTemplate>                  
    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
 
   <asp:ImageButton ID="LblDelete" runat="server" CausesValidation="false" CommandName="Delete"
        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" 
        OnClientClick="return confirm('Do you want to Delete?')" />
</ItemTemplate>
</asp:TemplateField>--%>

</Columns>
</asp:GridView>
</asp:Panel>

<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Stock"
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
document.getElementById('ctl00_ContentPlaceHolder1_uc_StockUpdate1_btnSave').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>