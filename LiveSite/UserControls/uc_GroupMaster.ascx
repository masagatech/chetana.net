<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_GroupMaster.ascx.cs" Inherits="UserControls_uc_GroupMaster" %>
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
</div>

<div style="float: right; width: 72%">
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="5" runat="server" Text="Save"
            Width="70px" onclick="btnSave_Click" ValidationGroup="A" /> 
</div>
<br />
<br />
<asp:Panel ID="pnlgroup" CssClass="panelDetails" runat="server" Width="345px">
            <table cellpadding="2" cellspacing="2" style="width: 100%">
                <tr>
                    <td >
                        <asp:Label ID="lblGrpID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="lblGrpCode" runat="server" CssClass="lbl-form" Text="Group Code"></asp:Label>
                        <font color="red">* </font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGrpCode"  TabIndex="1" runat="server" CssClass="inp-form"
                            Width="82px" style="margin-left: 12px" AutoPostBack="True" 
                            ontextchanged="txtGrp_TextChanged" MaxLength="10"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqCode" runat="server" ErrorMessage="Require Code"
                            ValidationGroup="Grp" ControlToValidate="txtGrpCode">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblGrpName"  runat="server" CssClass="lbl-form" Text="Group Name"></asp:Label>
                        <font color="red">* </font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGrpName"  TabIndex="2" runat="server" CssClass="inp-form"
                            Width="186px" style="margin-left: 11px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqGrpName" runat="server" ErrorMessage="Require Name"
                            ValidationGroup="Grp" ControlToValidate="txtGrpName">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblRemark" runat="server" CssClass="lbl-form" Text="Remark:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server"  TabIndex="3" CssClass="inp-form"
                            TextMode="MultiLine" Width="188px" style="margin-left: 11px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="Active:"></asp:Label>
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkActive" runat="server" TabIndex="4" Checked="true" />
                        &nbsp;</td>
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
            <asp:GridView ID="GrdDetails" runat="server" AllowPaging="true" 
                AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" CellPadding="4" 
                CssClass="product-table" ForeColor="#333333" 
                onpageindexchanging="GrdDetails_PageIndexChanging" 
                onrowdeleting="GrdDetails_RowDeleting" onrowediting="GrdDetails_RowEditing" 
                PageSize="50" 
                Width="600px">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Code" 
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblGID" runat="server" Style="display: none" 
                                Text='<%#Eval("GrpID")%>'></asp:Label>
                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("GrpCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("GrpName")%>'></asp:Label>
                            <asp:Label ID="lblGroup" runat="server" Style="display: none;" 
                                Text='<%#Eval("Group")%>'></asp:Label>
                            <asp:Label ID="lblRemark" runat="server" Style="display: none;" 
                                Text='<%#Eval("Remark")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="IsActive" 
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive")%>' 
                                Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Action" 
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" 
                                CommandName="Edit" CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                            <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" 
                                CommandName="Delete" CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" 
                                OnClientClick="return confirm('Do you want to Delete?')" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="A" runat="server" ID="ss"/>

<asp:Panel ID="pnlgroupdetails" runat="server">
            
            <script type="text/javascript">
    	                function filter (phrase, _id){
		                var words = phrase.value.toLowerCase().split(" ");
		                var table = document.getElementById('<%=GrdDetails.ClientID%>');
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