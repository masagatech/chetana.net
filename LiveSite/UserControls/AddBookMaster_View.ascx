<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddBookMaster_View.ascx.cs"
    Inherits="UserControls_AddBookMaster_View" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<div class="section-header">
<td>
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="View"/>
        <span runat="server" id="pageName">Book Master View</span>
         <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
 </td>
 <td>
 <div id="filter" runat="server" style="float: right; width: 50%">
    <span>Filter Data:</span>
    <input name="filt" onkeyup="filter(this, 'sf', '<%=grdBookDetails.ClientID%>')" id="filterdata"
        type="text"></div>
 </td>   
</div>
<div style="float: right;  display:none; width: 60%">
    <asp:Button ID="btn_Save" CssClass="submitbtn" TabIndex="13" runat="server" Text="Save"
        ValidationGroup="BookM" Width="80px" OnClick="btn_Save_Click" />
</div>
 <div style="float: right; display:none; width: 10%" >
<asp:Button ID="btnprint" CssClass="submitbtn" TabIndex="12" runat="server" Text="Print"
    Width="80px" Height="26px" onclick="btnprint_Click"/>
     </div>
    <div style="display:none;" >
    <asp:Button ID="btnExport" CssClass="submitbtn" TabIndex="13" runat="server" Text="Export"
    Width="80px" Height="26px" onclick="btnExport_Click" />
    </div>  
    
<asp:Button ID="btnAdd" CssClass="form-submit" TabIndex="12" runat="server" Text="Add"
    Width="80px" OnClick="btnAdd_Click" Style="display: none;" />
<asp:Button ID="btncancel" CssClass="form-submit" TabIndex="14" runat="server" Text="Back"
    Width="80px" OnClick="btncancel_Click" Style="display: none;" />
<br />
<br />
<div id="window" style="height:700px">
    <asp:Panel ID="Panel1" style="display:none" CssClass="panelDetails" runat="server" Width="480px">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td width="95px">
                    <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                    <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Book Code"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtcode"  CssClass="inp-form" TabIndex="1" runat="server" AutoPostBack="True"
                                OnTextChanged="txtcode_TextChanged1"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqbook" runat="server" ErrorMessage="Require Book Code"
                        ValidationGroup="BookM" ControlToValidate="txtcode">.</asp:RequiredFieldValidator>
                </td>
                <td width="95px">
                    <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Book Name"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtbknam" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqbkname" runat="server" ErrorMessage="Require Book Name"
                        ValidationGroup="BookM" ControlToValidate="txtbknam">.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" CssClass="lbl-form" runat="server" Text="Book Type"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1"  runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtbktpe" CssClass="inp-form" AutoPostBack="true" autocomplete="off"
                                TabIndex="3" runat="server" OnTextChanged="txtbktpe_TextChanged"></asp:TextBox>
                            <div id="dvbook" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtbktpe"
                                UseContextKey="true" ContextKey="bktype" CompletionListElementID="dvbook">
                            </ajaxCt:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Book Group"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2"  runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtbkgrp" CssClass="inp-form" AutoPostBack="true" autocomplete="off"
                                TabIndex="4" runat="server" OnTextChanged="txtbkgrp_TextChanged"></asp:TextBox>
                            <div id="dvgroup" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtbkgrp"
                                UseContextKey="true" ContextKey="bkgroup" CompletionListElementID="dvgroup">
                            </ajaxCt:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Standard"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtstd" CssClass="inp-form" autocomplete="off" TabIndex="5" runat="server"
                                AutoPostBack="True" OnTextChanged="txtstd_TextChanged"></asp:TextBox>
                            <div id="dvstandard" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtstd"
                                UseContextKey="true" ContextKey="standard" CompletionListElementID="dvstandard">
                            </ajaxCt:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="Label6" CssClass="lbl-form" runat="server" Text="Medium"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtmedm" CssClass="inp-form" autocomplete="off" TabIndex="6" runat="server"
                                AutoPostBack="True" OnTextChanged="txtmedm_TextChanged"></asp:TextBox>
                            <div id="dvmedium" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtmedm"
                                UseContextKey="true" ContextKey="medium" CompletionListElementID="dvmedium">
                            </ajaxCt:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" CssClass="lbl-form" runat="server" Text="Purchase Price"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:TextBox ID="txtprchse" MaxLength="12" CssClass="inp-form" TabIndex="7" runat="server"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="Extender1" runat="server" TargetControlID="txtprchse"
                        FilterType="Custom, Numbers" ValidChars="." />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqpurchase" runat="server" ErrorMessage="Require Purchase Price"
                        ValidationGroup="BookM" ControlToValidate="txtprchse">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label10" CssClass="lbl-form" runat="server" Text="Selling Price"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:TextBox ID="txtsel" MaxLength="12" CssClass="inp-form" TabIndex="8" runat="server"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="extender" runat="server" TargetControlID="txtsel"
                        FilterType="Custom, Numbers" ValidChars="." />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqselling" runat="server" ErrorMessage="Require Selling Price"
                        ValidationGroup="BookM" ControlToValidate="txtsel">.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" CssClass="lbl-form" runat="server" Text="OM Price"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:TextBox ID="txtompce" MaxLength="12" CssClass="inp-form" TabIndex="9" runat="server"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="Filtered" runat="server" TargetControlID="txtompce"
                        FilterType="Custom, Numbers" ValidChars="." />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqOm" runat="server" ErrorMessage="Require OM Price"
                        ValidationGroup="BookM" ControlToValidate="txtompce">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="OI Price"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:TextBox ID="txtOIprice" MaxLength="12" CssClass="inp-form" TabIndex="10" runat="server"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="Extenders" runat="server" TargetControlID="txtOIprice"
                        FilterType="Custom, Numbers" ValidChars="." />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="ReqOI" runat="server" ErrorMessage="Require OI Price"
                        ValidationGroup="BookM" ControlToValidate="txtOIprice">.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" CssClass="lbl-form" runat="server" Text="Update Rate"></asp:Label>
                    <font color="red">*</font>
                </td>
                <td>
                    <asp:DropDownList  CssClass="ddl-form" ID="ddlupderte" TabIndex="11" runat="server">
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="Label7" CssClass="lbl-form" runat="server" Text="New Quantity"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtqty" MaxLength="10" CssClass="inp-form" TabIndex="12" 
                        runat="server">0</asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtqty"
                        FilterType="Custom, Numbers" ValidChars="." />
                </td>
            </tr>
            <tr height="1px">
            <td></td><td></td><td></td>
                <td height="2px">
                    <asp:Label ID="Label13" CssClass="lbl-form" runat="server" Text="   +   "></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="chekIsactive" TabIndex="13" runat="server" Text="Active" Checked="true" />
                </td>
                <td></td>
                <td></td>
                <td>
                    <asp:Label ID="Label14" CssClass="lbl-form"  runat="server" Text="Old Quantity"></asp:Label>
                </td>
              <td>
                <asp:Label ID="LblOldqty" CssClass="inp-form"  runat="server" width="80"></asp:Label>
                   
                </td>
            </tr>
        </table>

        <script type="text/javascript">
     setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
   document.getElementById('status').innerHTML=status;
   }
        </script>
    </asp:Panel>
    
    <asp:Panel ID="pnlBookDetails" runat="server">
    <asp:Repeater ID="repAlfabets" runat="server">
    <ItemTemplate>
        <asp:LinkButton ID="lnkalfabet" CssClass="nav_bar_link" runat="server" Text='<%#Eval("chr") %>'  
        OnClick="lnkalfabet_click"></asp:LinkButton>
    </ItemTemplate>
    </asp:Repeater>
        <asp:GridView ID="grdBookDetails" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" CssClass="product-table" ForeColor="#333333" 
            PageSize="500" runat="server"
            AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="grdBookDetails_PageIndexChanging"
           
            OnRowCreated="grdBookDetails_RowCreated">
            <Columns>
                <asp:TemplateField HeaderText="BookCode" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBkID" runat="server" Text='<%#Eval("BookID")%>' Style="display: none"></asp:Label>
                        <asp:Label ID="lblBkCode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BookName" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBkName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BookType" ItemStyle-Width="80px"  HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBktyp" style="width:60px;overflow:hidden;" runat="server" Text='<%#Eval("BookTypeName")%>'></asp:Label>
                        <asp:Label ID="lblbktypeId" runat="server" Style="display: none" Text='<%#Eval("BookTypeCode")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BookGroup" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBkgrp" runat="server" Text='<%#Eval("BookGroup")%>'></asp:Label>
                        <asp:Label ID="lblbkgroupId" runat="server" Style="display: none" Text='<%#Eval("BookGroupCode")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Standard" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStd" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblMdm" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label> 
                        <asp:CheckBox style="display:none;" ID="chkUR" runat="server" Checked='<%#Eval("UpdateRate") %>' Enabled="false">
                        </asp:CheckBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
             <%--   <asp:TemplateField HeaderText="UpdateRate" HeaderStyle-Width="55px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                       
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="P.Price" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPP" runat="server" Text='<%#Eval("PurchasePrice","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="S.Price" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSP" runat="server" Text='<%#Eval("SellingPrice","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OM.Price" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblOMP" runat="server" Text='<%#Eval("OMPrice","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OI.Price" ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblOIP" runat="server" Text='<%#Eval("OIPrice","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IsActive" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false">
                        </asp:CheckBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                
            </Columns>
            <AlternatingRowStyle CssClass="alt" />
        </asp:GridView>

        <script type="text/javascript">
     setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+F : Find Books ]&nbsp;";
   document.getElementById('status').innerHTML=status;
   
   }
        </script>

    </asp:Panel>
    <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="BookM"
        runat="server" ID="ss" />

    <script type="text/javascript">
      
shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_AddBookMaster1_btn_Save').click();
});

shortcut.add("Ctrl+F",function() {
document.getElementById('filterdata').focus();
});

      
      
    
   	   

    </script>

    <script type="text/javascript">
    window.onload = function()
    {
        UpperBound = parseInt('<%= this.grdBookDetails.Rows.Count %>') - 1;
        LowerBound = 0;
        SelectedRowIndex = -1;     
        
        
     //shortcut.add("Delete",function() {
       //alert(document.getElementById('ctl00_ContentPlaceHolder1_AddBookMaster1_grdBookDetails_ctl'+SelectedRowIndex  +'_lblDelete'));
     //RowIndex1 = RowIndex1 + 1; 
     
//     if(RowIndex1<=9)
//     {
//        document.getElementById('ctl00_ContentPlaceHolder1_AddBookMaster1_grdBookDetails_ctl0'+ RowIndex1+'_lblDelete').click();
//     
//     }
//     else
//     {
//        document.getElementById('ctl00_ContentPlaceHolder1_AddBookMaster1_grdBookDetails_ctl'+ RowIndex1 +'_lblDelete').click();
//     
//     }
//      
//        
//      alert(RowIndex1);   
//    });

    }
    </script>
<script type="text/javascript">
    	                function filter (phrase, _id){
		                var words = phrase.value.toLowerCase().split(" ");
		                var table = document.getElementById('<%=grdBookDetails.ClientID%>');
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
</div>
