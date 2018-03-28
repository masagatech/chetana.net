<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_MenuRoleMapping.ascx.cs"
    Inherits="UserControls_RoleMapping" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       <span runat="server" id="pageName"></span>
        MenuRole Mapping ADD/EDIT <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
</div>
<div style="float: right; width: 60%">
    <asp:Button ID="btnsave" CssClass="submitbtn" runat="server" Text="Save" Width="85px"
        OnClick="btnsave_Click" />
</div>
<br />
<br />
<asp:Panel ID="Panel1" CssClass="panelDetails" runat="server" Width="500px">
    <table>
        <tr>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="ddlrole" runat="server" Width="200px" DataValueField="RoleId"
                    DataTextField="RoleName" AutoPostBack="True" OnSelectedIndexChanged="ddlrole_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <div id="filter" runat="server" style="width: 220px; clear: both; float: left;display:none">
                    <span>Filter Data:</span>
                    <input name="filt" onkeyup="filter(this, 'sf', '1')" type="text" />
                </div>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<br />
<asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel2" runat="server">
            <asp:DataList ID="RepGroup" runat="server" OnItemDataBound="RepGroup_ItemDataBound">
                <ItemTemplate>
                   <asp:Panel ID="Panel1" GroupingText='<%#Eval("GroupName") %>' CssClass="pnldash" runat="server">
                    <asp:Label ID="lblGroupName" runat="server" Text='<%#Eval("GroupName") %>' style="display:none;"></asp:Label>
                    <asp:GridView ID="Grdmenurole" AutoGenerateColumns="false" CellPadding="4"
                         runat="server" Width="300px" AlternatingRowStyle-CssClass="alt">
                        <Columns>
                            <asp:TemplateField HeaderText="Menu" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblMID" runat="server" CssClass="lbl-form" Style="display: none;"
                                        Text='<%#Eval("UserMenuMappId") %>'></asp:Label>
                                    <asp:Label ID="lblName" runat="server" Style="margin-left: 10px;" Text='<%#Eval("MenuName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Access" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:CheckBox ID="Chekshow" CssClass="" Checked='<%#Eval("show") %>' runat="server" />
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td>
                                                <asp:CheckBox Style="display: none;" ID="Chekall" Text="All" runat="server" />
                                                <asp:CheckBox ID="chekview" Text="View" Checked='<%#Eval("View") %>' runat="server" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="Cheksave" Text="Add" Checked='<%#Eval("Add") %>' runat="server" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="Chekedit" Text="Edit" Checked='<%#Eval("Edit") %>' runat="server" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="Chekdelete" Text="Delete" Checked='<%#Eval("Delete") %>' runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </asp:Panel>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:GridView ID="grdMenuRoleMapping" runat="server" OnDataBound="grdMenuRoleMapping_DataBound"
                OnRowDataBound="grdMenuRoleMapping_RowDataBound" Style="display: none;">
            </asp:GridView>
        </td>
    </tr>
</table>
<%--<table width="50%" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Label ID="Label1" CssClass="comlbl" runat="server" Text="Role"></asp:Label>
        </td>
        <td>
            <asp:DropDownList  CssClass="ddl-form" ID="ddlrole" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:GridView AutoGenerateColumns="false" ID="GridView1" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="SelectMenu">
                        <ItemTemplate>
                            <asp:CheckBox ID="Cheksmenu" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
         
        </td>
    </tr>
</table>--%><script type="text/javascript">
   	function filter (phrase, _id){
		var words = phrase.value.toLowerCase().split(" ");
		//
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
</script>