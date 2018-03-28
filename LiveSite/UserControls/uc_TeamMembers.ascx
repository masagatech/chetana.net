<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_TeamMembers.ascx.cs"
    Inherits="UserControls_uc_TeamMembers" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    &nbsp;<td>
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
            </a>
        </div>
    </td>
    <td>
        <div style="float: right; width: 50%">
            <div id="filter" runat="server" style="width: 220px; clear: both; float: left;">
                <span>Filter Data:</span>
                <input name="filt" id="find" onkeyup="filter(this, 'sf', '1')" type="text">
            </div>
        </div>
    </td>
</div>
<asp:Panel ID="PnlAddCC" CssClass="panelDetails" runat="server" Width="310px">
    <table cellpadding="2" cellspacing="2" style="width: 97%">
        <tr>
            <td>
                <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Team Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="DDLTeamName" Width="200px" DataTextField="TeamName"
                    DataValueField="TeamID" TabIndex="1" runat="server" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Team Member"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTeamMember" onfocus="setfocus('customer');" autocomplete="off"
                    Width="80px" CssClass="inp-form" TabIndex="2" runat="server" AutoPostBack="true"
                    OnTextChanged="txtTeamMember_TextChanged"></asp:TextBox>
                <div id="dvcust" class="divauto350">
                </div>
                <ajaxCt:AutoCompleteExtender ID="Team_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetGodownCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtTeamMember"
                    UseContextKey="true" ContextKey="GodownTeam" CompletionListElementID="dvcust">
                </ajaxCt:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RFVTeam" runat="server" ErrorMessage="Require Dept"
                    ValidationGroup="S123" ControlToValidate="txtTeamMember">.</asp:RequiredFieldValidator>
                <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                    runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="panel4"  runat="server" Width="310px">
<asp:GridView ID="Grdteamview" runat="server" AutoGenerateColumns="false" CellPadding="4"
        CssClass="product-table" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
        PageSize="10" Width="600px" onrowdeleting="Grdteamview_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sr No" HeaderStyle-Width="100px"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Team MemberId" HeaderStyle-Width="100px"
                ItemStyle-HorizontalAlign="Center" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="TMemberId" runat="server" Text='<%#Eval("TeamMemberID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sr No" HeaderStyle-Width="100px"
                ItemStyle-HorizontalAlign="Center" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblempid" runat="server" Text='<%#Eval("EmpID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lbltdesc" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Team Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lbltID" runat="server" Text='<%#Eval("TeamName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <script type="text/javascript">

        function filter(phrase, _id) {
            debugger;
            var words = phrase.value.toLowerCase().split(" ");
            var table = document.getElementById('<%=Grdteamview.ClientID%>');
            //document.getElementById(_id);
            var ele;
            for (var r = 1; r < table.rows.length; r++) {
                ele = table.rows[r].innerHTML.replace(/<[^>]+>/g, "");
                var displayStyle = 'none';
                for (var i = 0; i < words.length; i++) {
                    if (ele.toLowerCase().indexOf(words[i]) >= 0)
                        displayStyle = '';
                    else {
                        displayStyle = 'none';
                        break;
                    }
                }
                table.rows[r].style.display = displayStyle;
            }
            if (words != "") {
                sloder('search for : ' + words);
            }
            else {
                cloder();
            }
        }
        shortcut.add("Ctrl+F", function () {
            document.getElementById('find').focus();
        });
        setTimeout("setSatus()", 2000);
        function setSatus() {
            var status = "[ Ctrl+F : Find ]";
            document.getElementById('status').innerHTML = status;
        }
    </script>

   
</asp:Panel>
<asp:Panel ID="Pnlteam" CssClass="panelDetails" Visible="false" runat="server" Width="597px" style="float: left;">
      <table width="100%" cellpadding="0" cellspacing="0" >
     
           <tr>
          <td>
            <asp:Label ID="lblEmpNameH" CssClass="lbl-form" runat="server" Text="Employee Name"></asp:Label>
          </td>
          <td>
              <asp:Label ID="lblEmpName" runat="server" Text="Label"></asp:Label>
          </td>
        </tr>
          <tr>
          <td>
            <asp:Label ID="grpteamcode" CssClass="lbl-form" runat="server" Text="Team code"></asp:Label>
          </td>
          <td>
              <asp:Label ID="Lblgrpcode" runat="server" Text="Label"></asp:Label>
          </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="Empidh" CssClass="lbl-form" runat="server" Text="Emp Code" ></asp:Label>
        </td>
        <td>
         <asp:Label ID="empid" runat="server" Text="Label" ></asp:Label>
        </td>
        
        </tr>
        <tr>
          <td>
              &nbsp;</td>
          <td>
              
                
            </td>
          
          <td>
          <asp:Button ID="btn_Save" runat="server" Text="Add" CssClass="submitbtn" TabIndex="24"
                ValidationGroup="pdadoc" Width="50px" onclick="btn_Save_Click" />
              
            </td>
          <td>
            
          </td>
        </tr>
      </table>
    </asp:Panel>
<asp:Panel ID="PnlCCDetails" runat="server">
    <asp:GridView ID="Grdteammber" runat="server" AutoGenerateColumns="false" CellPadding="4"
        CssClass="product-table" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
        PageSize="10" Width="600px" OnRowDeleting="Grdteammber_RowDeleting" OnRowDataBound="Grdteammber_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sr No" HeaderStyle-Width="100px"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sr No" HeaderStyle-Width="100px"
                ItemStyle-HorizontalAlign="Center" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblempid" runat="server" Text='<%#Eval("EmpID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lbltdesc" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
     <asp:Button ID="Btnsave" runat="server" CssClass="submitbtn" Text="Save" OnClick="Btnsave_Click" />
    <%--<asp:GridView ID="GrdCCDetails" runat="server" AllowPaging="false" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
        PageSize="10" Width="600px">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sr No" HeaderStyle-Width="100px"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lbltdesc" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        CssClass="close" ImageUrl="../Images/icon/DeleteIcon.gif" OnClientClick="return confirm('You really want to Delete?')" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
</asp:Panel>

    

<%--<script type="text/javascript">
    function filter(phrase, _id) {
        var words = phrase.value.toLowerCase().split(" ");
        var table = document.getElementById('<%=Grdteammber.ClientID%>');
        //document.getElementById(_id);
        var ele;
        for (var r = 0; r < table.rows.length; r++) {
            ele = table.rows[r].innerHTML.replace(/<[^>]+>/g, "");
            var displayStyle = 'none';
            for (var i = 0; i < words.length; i++) {
                if (ele.toLowerCase().indexOf(words[i]) >= 0)
                    displayStyle = '';
                else {
                    displayStyle = 'none';
                    break;
                }
            }
            table.rows[r].style.display = displayStyle;
        }
        if (words != "") {
            sloder('search for : ' + words);
        }
        else {
            cloder();
        }
    }
    </script>--%>
