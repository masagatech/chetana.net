<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ZoneMaster.ascx.cs"
    Inherits="UserControls_uc_ZoneMaster" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
<td>
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
         <span runat="server" id="pageName"></span>
         <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</td>
<td>
<div style ="float: right; width: 50%">
    <div id="filter" runat="server">
        <span>Filter Data:</span>
        <input name="filt" id="find" onkeyup="filter(this, 'sf', '1')" type="text" />
    </div>
</div>
</td>
</div>
<div style="float: right; width: 68%">
    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="Save"
        ValidationGroup="zone" Width="80px" OnClick="btnSave_Click" />
</div>

<br /> <br />
<asp:Panel ID="pnlZoneDetails" runat="server">
    <asp:Repeater ID="repAlfabets" runat="server">
    <ItemTemplate>
        <asp:LinkButton ID="lnkalfabet" CssClass="nav_bar_link" runat="server" Text='<%#Eval("chr") %>'  
        OnClick="lnkalfabet_click"></asp:LinkButton>
    </ItemTemplate>
    </asp:Repeater>

    <asp:GridView ID="grdZoneDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="800" Width="600px"
        OnPageIndexChanging="grdZoneDetails_PageIndexChanging" OnRowDeleting="grdZoneDetails_RowDeleting"
        OnRowEditing="grdZoneDetails_RowEditing" AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:TemplateField HeaderText="Zone Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblZID" runat="server" Text='<%#Eval("ZoneID")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblZCode" runat="server" Text='<%#Eval("ZoneCode")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Zone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblZName" runat="server" Text='<%#Eval("ZoneName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SuperZone" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblSZID" runat="server" Text='<%#Eval("SuperZoneID")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblSZName" runat="server" Text='<%#Eval("SuperZoneName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive")%>' Enabled="false">
                    </asp:CheckBox>
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
   	function filter (phrase, _id){
		var words = phrase.value.toLowerCase().split(" ");
		var table = document.getElementById('<%=grdZoneDetails.ClientID%>');
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
	 shortcut.add("Ctrl+F",function() { document.getElementById('find').focus(); });
          setTimeout("setSatus()",2000);
          function setSatus()
          {
             var status="[ Ctrl+F : Find ]";
             document.getElementById('status').innerHTML=status;
          }
    </script>

</asp:Panel>
<asp:Panel ID="pnlZone" CssClass="panelDetails" runat="server" Width="400px">
    <table width="70%" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Zone Code"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtZoneCode" CssClass="inp-form" TabIndex="1" runat="server" AutoPostBack="True"
                            OnTextChanged="txtZoneCode_TextChanged" MaxLength="10"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqFnamZcod" runat="server" ErrorMessage="Require Zone Code"
                    ValidationGroup="zone" ControlToValidate="txtZoneCode">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Zone Name"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtZoneName" CssClass="inp-form" TabIndex="2" runat="server" 
                    MaxLength="30"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqZname" runat="server" ErrorMessage="Require Zone Name"
                    ValidationGroup="zone" ControlToValidate="txtZoneName">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
            </td>
            <td>
                <asp:DropDownList  CssClass="ddl-form" ID="DDLSuperZone" DataTextField="SuperZoneName" DataValueField="SuperZoneID"
                   width="200px" TabIndex="3" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqDDL" runat="server" ErrorMessage="Select Super Zone"
                    InitialValue="none" ValidationGroup="zone" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Active"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="Chekacv" TabIndex="4" runat="server" Checked="true" />
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
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="zone"
    runat="server" ID="ss" />
