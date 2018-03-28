<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_BookVirtualStock.ascx.cs" Inherits="UserControls_uc_BookVirtualStock" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>

<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
            VirtualStock Update Add<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>  
</div>

<%--<div style="float: right; width: 81%">
     <div id="filter" runat="server">
        <span>Filter Data:</span>
        <input name="filt" onkeyup="filter(this, 'sf', '<%=GrdStock.ClientID%>')" type="text">
 </div> --%>
 <div style="float: right; width: 55%">
      <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="Save" 
        ValidationGroup="VStk" Width="80px" OnClick="btnSave_Click" />  
</div>    
<br />
<br />

<asp:Panel ID="PnlVAddStock" CssClass="panelDetails" runat="server" 
    Width="550px">
<caption>
    <br />
</caption> 
   
<table cellpadding="0" cellspacing="0" style="margin-bottom: 0px; ">
<tr>
    <td width="100px">
        <asp:Label ID="LblBookcode" CssClass="lbl-form" runat="server" Text="Book Code"></asp:Label>
        <font color="red">*</font>
    </td>
    <td>
     <asp:TextBox ID="Txtbkcode" autocomplete="off" TabIndex="1" CssClass="inp-form" runat="server"
        OnTextChanged="Txtbkcode_TextChanged" Width="360px" AutoPostBack="True"></asp:TextBox>
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
                ValidationGroup="VStk" ControlToValidate="Txtbkcode">.</asp:RequiredFieldValidator>
    </td>
</tr>
        <tr>
            <td>
                <asp:Label ID="LblCStock" runat="server" CssClass="lbl-form" 
                    Text="Current Stock"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtCStock" runat="server" CssClass="inp-form" Enabled="false" 
                    TabIndex="2" Width="80px"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblCVStock" runat="server" CssClass="lbl-form" 
                    Text="Current VirtualStock"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtCVStock" runat="server" CssClass="inp-form" Enabled="false" 
                    TabIndex="3" Width="80px"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblNStock" runat="server" CssClass="lbl-form" Text=" New VirtualStock"></asp:Label>
             <font color="red">*</font>            
                
            </td>
            <td>
                <asp:TextBox ID="TxtNStock" runat="server" AutoPostBack="True" 
                    CssClass="inp-form" ontextchanged="TxtNStock_TextChanged" TabIndex="4" 
                    Width="80px"></asp:TextBox>
                 <ajaxCt:FilteredTextBoxExtender ID="extender" runat="server" TargetControlID="TxtNStock"
                    FilterType="Custom, Numbers" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqStock" runat="server" ControlToValidate="TxtNStock" 
                ErrorMessage="Enter New Stock" ValidationGroup="VStk">.</asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>
         <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <tr>
                <td>
                    <asp:Label ID="LblTStock" runat="server" CssClass="lbl-form" Text="Total VirtualStock"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtTStock" runat="server" CssClass="inp-form" Enabled="false" TabIndex="5" 
                        Width="80px"></asp:TextBox>
                </td>
                <td>
                </td>
        </tr>

        <tr>
            <td valign=top>
                <asp:Label ID="LblCom" runat="server" CssClass="lbl-form" Text="Comment"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtCom" runat="server" CssClass="inp-form" TabIndex="6" Height="40px" 
                    TextMode="MultiLine" Width="191px" style="margin-left: 0px"></asp:TextBox>
            </td>
        </tr>
        </ContentTemplate>
</asp:UpdatePanel>
</table>

<caption>
    <br />
</caption>            
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="VStk"
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
document.getElementById('ctl00_ContentPlaceHolder1_uc_BookVirtualStock1_btnSave').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

</script>