<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Masterofmaster.ascx.cs"
    Inherits="UserControls_uc_Masterofmaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

   
<div class="section-header">
<td>
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
         <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div> 
</td>  
<td>
 <div style="float: right; width: 50%">      
    <div id="filter" runat="server" style="width:220px; clear:both; float:left;"> <span>Filter Data:</span>
        <input name="filt" id="find" onkeyup="filter(this, 'sf', '1')" type="text"> </div>
</td>
</div>
</td>
</div>

<div style="float: right; width: 72%">
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="5" runat="server" Text="Save"
            Width="70px" onclick="btnSave_Click" ValidationGroup="A" /> 
</div>
<br />
<br />
<asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Width="345px">
            <table cellpadding="2" cellspacing="2" style="width: 100%">
                <tr>
                    <td >
                        <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                        <asp:Label ID="lblkey" runat="server" CssClass="lbl-form" Text="Product Code"></asp:Label>
                        <font color="red">* </font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtkey"  TabIndex="1" runat="server" CssClass="inp-form"
                            Width="82px" style="margin-left: 12px" AutoPostBack="True" 
                            ontextchanged="txtkey_TextChanged" MaxLength="10"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqkeY" runat="server" ErrorMessage="Require Code"
                            ValidationGroup="A" ControlToValidate="txtkey">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblvalue"  runat="server" CssClass="lbl-form" 
                            Text="Product Name"></asp:Label>
                        <font color="red">* </font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtvalue"  TabIndex="2" runat="server" CssClass="inp-form"
                            Width="186px" style="margin-left: 11px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqval" runat="server" ErrorMessage="Require Name"
                            ValidationGroup="A" ControlToValidate="txtvalue">.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblExtra" runat="server" CssClass="lbl-form" Visible="False"></asp:Label>
                    </td>
                    <td><p>
                        <asp:CheckBoxList ID="chExtra" runat="server" RepeatColumns="2" 
                            RepeatDirection="Horizontal" Visible="False">
                        </asp:CheckBoxList></p>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lbldesc" runat="server" CssClass="lbl-form" Text="Description:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdecp" runat="server" CssClass="inp-form" 
                            style="margin-left: 11px" TabIndex="3" TextMode="MultiLine" Width="188px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblBT_BMID" runat="server" CssClass="lbl-form" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList  CssClass="ddl-form" ID="DDLBMID" DataTextField="Value" DataValueField="AutoId" TabIndex="3"
                    runat="server"  Visible ="false" style="width:188px;margin-left: 11px" ></asp:DropDownList>
                    </td>
                </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="Active:"></asp:Label>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkActive" runat="server" Checked="true" TabIndex="4" />
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
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="A" runat="server" ID="ss"/>

<asp:Panel ID="Panel2" runat="server">
<asp:GridView ID="GrdDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="50" 
                Width="600px" onrowediting="GrdDetails_RowEditing" onrowdeleting="GrdDetails_RowDeleting" 
                onpageindexchanging="GrdDetails_PageIndexChanging" AlternatingRowStyle-CssClass="alt" OnRowDataBound="GrdDetails_RowDataBound">                
                <Columns>
                    <asp:TemplateField HeaderText="Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblAutoID" runat="server"  Style="display: none"
                            Text='<%#Eval("AutoId")%>'></asp:Label>                                
                            <asp:Label ID="lblCode" runat="server"  
                            Text='<%#Eval("key") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" 
                            Text='<%#Eval("Value")%>' ></asp:Label>
                            <asp:Label ID="lblGroup" runat="server"  Style="display: none;"
                             Text='<%#Eval("Group")%>' ></asp:Label>
                            <asp:Label ID="lblDesc" runat="server"  Style="display: none;"
                             Text='<%#Eval("Description")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>   
                     <asp:TemplateField HeaderText="Kind" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblBookKind" runat="server" 
                            Text='<%#Eval("OS_OMS")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                   
                    <asp:TemplateField HeaderText="IsActive" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsActive" runat="server"  Enabled="false" 
                            Checked='<%#Eval("IsActive")%>' >
                            </asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                            <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('Do you want to Delete?')"/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
</asp:GridView>
            
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
            
       