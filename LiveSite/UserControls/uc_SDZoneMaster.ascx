<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SDZoneMaster.ascx.cs"
    Inherits="UserControls_uc_SDZoneMaster" %>
<%@ Register TagPrefix="ajaxCt" 
Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <td>
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
         <span runat="server" id="pageName"></span>
         <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</td>
    
    <td>
    <div style ="float: right; width: 50%">
        <div id="filter" runat="server" >
            <span>Filter Data:</span>
            <input name="filt" id="find" onkeyup="filter(this, 'sf', '1')" type="text" />
        </div>
    </div>
    </td>
</div>
<div style ="float: right; width: 77%">
        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="Save"
            Width="80px" OnClick="btnSave_Click" ValidationGroup="SuperZone" />
</div>
<br />
<br />
<asp:Panel ID="pnlSuperZoneDetails" runat="server">
    <asp:Repeater ID="repAlfabets" runat="server" Visible="false">
    <ItemTemplate>
        <asp:LinkButton ID="lnkalfabet" CssClass="nav_bar_link" runat="server" Text='<%#Eval("chr") %>'  
        OnClick="lnkalfabet_click"></asp:LinkButton>
    </ItemTemplate>
    </asp:Repeater>

    <asp:GridView ID="grdSuperZoneDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" OnPageIndexChanging="grdSuperZoneDetails_PageIndexChanging"
        OnRowDeleting="grdSuperZoneDetails_RowDeleting" OnRowEditing="grdSuperZoneDetails_RowEditing"
        AlternatingRowStyle-CssClass="alt" PageSize="800" Width="600px">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SuperZone Code"
                HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblSZID" runat="server" Style="display: none" Text='<%#Eval("SDZoneID")%>'></asp:Label>
                    <asp:Label ID="lblSZCode" runat="server" Text='<%#Eval("SDZoneCode") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SuperZone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblSZName" runat="server" Text='<%#Eval("SDZoneName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IsActive" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <script type="text/javascript">
    	                function filter (phrase, _id){
		                var words = phrase.value.toLowerCase().split(" ");
		                var table = document.getElementById('<%=grdSuperZoneDetails.ClientID%>');
		                //document.getElementById(_id);
		                var ele;
		                for (var r = 1; r < table.rows.length; r++){
			                ele = table.rows[r].innerHTML.replace(/<[^>]+>/g,"");
		                        var displayStyle = 'none';
		                        for (var i = 0; i < words.length; i++) {
			                    if (ele.toLowerCase().indexOf(words[i])>=0)
				                displayStyle = '';
			                    else {
				                displayStyle = 'none';
				                break;
			                    }
		                        }
			                table.rows[r].style.display = displayStyle;
		                }
		                  if(words != "")
		{
		sloder('search for : '+ words);
		}
		else
		{
		cloder();
		}
	  }
	   shortcut.add("Ctrl+F",function() 
                    {
                        document.getElementById('find').focus();
                    });
                        setTimeout("setSatus()",2000);
                    function setSatus()
                        {
                            var status="[ Ctrl+F : Find ]";
                            document.getElementById('status').innerHTML=status;
                        }
    </script>

</asp:Panel>
<asp:Panel ID="pnlSuperZone" CssClass="panelDetails" runat="server" 
    Width="500px">
    <table width="70%" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" 
                    Text="Super Duper Zone Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSZCode" CssClass="inp-form" TabIndex="1" runat="server" AutoPostBack="True"
                            OnTextChanged="txtSZCode_TextChanged" MaxLength="20" Height="22px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqSZCode" runat="server" ErrorMessage="Require SuperZone Code"
                    ValidationGroup="SuperZone" ControlToValidate="txtSZCode">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" 
                    Text="Super Duper Zone Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtSZName" CssClass="inp-form" TabIndex="2" runat="server" 
                    MaxLength="20"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqSZName" runat="server" ErrorMessage="Require Super Duper Zone Name"
                    ValidationGroup="SuperZone" ControlToValidate="txtSZName">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <t>
                    <td>
                        <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="Active"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="Chekacv" runat="server" Checked="true" TabIndex="3" />
                    </td>
        </t>
        </tr>
    </table>
    <script type="text/javascript">
                    shortcut.add("Ctrl+S",function() 
                    {
                        document.getElementById('<%=btnSave.ClientID %>').click();
                    });
                        setTimeout("setSatus()",2000);
                    function setSatus()
                     {
                        var status="[ Ctrl+S : Save ]";
                        document.getElementById('status').innerHTML=status;
                     }   
                    </script>
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="SuperZone"
    runat="server" ID="ss" />
