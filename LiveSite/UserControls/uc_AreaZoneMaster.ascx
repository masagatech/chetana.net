<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_AreaZoneMaster.ascx.cs"
    Inherits="UserControls_uc_AreaZoneMaster" %>
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
    <div id="filter" runat="server" >
        <span>Filter Data:</span>
        <input name="filt" id="find" onkeyup="filter(this, 'sf', '1')" type="text" />
    </div>
 </div>
 </td>    
</div>
    <div style="float: right; width: 68%">
        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="Save"
        Width="80px" OnClick="btnSave_Click" ValidationGroup="AZone" />
    </div>

<br />
<br />
<asp:Panel ID="pnlAreaZoneDetails" runat="server">

    <asp:Repeater ID="repAlfabets" runat="server">
    <ItemTemplate>
        <asp:LinkButton ID="lnkalfabet" CssClass="nav_bar_link" runat="server" Text='<%#Eval("chr") %>'  
        OnClick="lnkalfabet_click"></asp:LinkButton>
    </ItemTemplate>
    </asp:Repeater>
    <asp:GridView ID="grdAreaZoneDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="800" Width="600px"
        OnPageIndexChanging="grdAreaZoneDetails_PageIndexChanging" AlternatingRowStyle-CssClass="alt"
        OnRowDeleting="grdAreaZoneDetails_RowDeleting" OnRowEditing="grdAreaZoneDetails_RowEditing">
        <Columns>
            <asp:TemplateField HeaderText="AreaZone Code" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblAreaZoneID" runat="server" Text='<%#Eval("AreaZoneID")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblAreaZoneCode" runat="server" Text='<%#Eval("AreaZoneCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AreaZone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAreaZoneName" runat="server" Text='<%#Eval("AreaZoneName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Zone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblZoneName" runat="server" Text='<%#Eval("ZoneName")%>'></asp:Label>
                    <asp:Label ID="lblZoneID" runat="server" Text='<%#Eval("ZoneID")%>' Style="display: none"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SuperZone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblSZoneName" runat="server" Text='<%#Eval("SuperZoneName")%>'></asp:Label>
                    <asp:Label ID="lblSuperzoneName" runat="server" Text='<%#Eval("SuperZoneID")%>' Style="display: none"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
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
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <script type="text/javascript">
    	function filter (phrase, _id)
    	{
		    var words = phrase.value.toLowerCase().split(" ");
		    var table = document.getElementById('<%=grdAreaZoneDetails.ClientID%>');
		    //document.getElementById(_id);
		    var ele;
		    for (var r = 1; r < table.rows.length; r++)
		    {
			    ele = table.rows[r].innerHTML.replace(/<[^>]+>/g,"");
		        var displayStyle = 'none';
		        for (var i = 0; i < words.length; i++) 
		        {
			        if (ele.toLowerCase().indexOf(words[i])>=0)
				    displayStyle = '';
			        else 
			        {
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
<%-- </ContentTemplate>
</asp:UpdatePanel>--%>
<asp:Panel ID="PnlAreaZone" CssClass="panelDetails" runat="server" Width="400px">
    <table cellpadding="2" cellspacing="2" style="width: 73%">
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Area Zone Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtAreaZoneCode" CssClass="inp-form" TabIndex="1" runat="server"
                    OnTextChanged="txtAreaZoneCode_TextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqFnam" runat="server" ErrorMessage="Require Area Zone- Code"
                    ValidationGroup="AZone" ControlToValidate="txtAreaZoneCode">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Area Zone Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtAreaZoneName" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqaznam" runat="server" ErrorMessage="Require Area Zone Name"
                    ValidationGroup="AZone" ControlToValidate="txtAreaZoneName">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList  CssClass="ddl-form" ID="DDLSuperZone" TabIndex="3" runat="server" DataTextField="SuperZoneName"
                    DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                    InitialValue="none" ValidationGroup="AZone" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList  CssClass="ddl-form" ID="DDLZone" TabIndex="4" Width="200px" runat="server" DataTextField="ZoneName" DataValueField="ZoneID"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqDDLZ" runat="server" ErrorMessage="Please select Zone"
                    InitialValue="none" ValidationGroup="AZone" ControlToValidate="DDLZone">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="Chekacv" TabIndex="5" runat="server" Checked="true" Enabled="true" />
            </td>
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
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
    runat="server" ID="ss" />
