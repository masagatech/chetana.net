<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SaleHierarchy.ascx.cs" Inherits="UserControls_ODC_SaleHierarchy" %>
<div class="section-header">
<td>
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
       SaleHierarchy<a href="Campaigns.aspx" title="back to campaign list"></a>
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
<asp:Panel ID="pnlbindSale" runat="server">
<asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
                    CellPadding="4" CssClass="product-table" ForeColor="#333333"
                    PageSize="100">
                    <Columns>
                        <asp:TemplateField HeaderText="SuperZone">
                            <ItemTemplate>
                               
                                <asp:Label ID="lblchequeno" runat="server" Text='<%#Eval("SuperZoneName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SuperZone Employee">
                            <ItemTemplate>
                                <asp:Label ID="lblreceipt" runat="server" Text='<%#Eval("SuperZoneNameEmployee")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zone">
                            <ItemTemplate>
                                <asp:Label ID="lblcustomer" runat="server" Text='<%#Eval("ZoneName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zone Employee">
                            <ItemTemplate>
                                <asp:Label ID="lbldeposit" runat="server" Text='<%#Eval("ZoneNameEmployee") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AreaZone">
                            <ItemTemplate>
                                <asp:Label ID="lblcheque" runat="server" Text='<%#Eval("AreaZoneName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AreaZone Employee">
                            <ItemTemplate>
                                <asp:Label ID="lbldepositby" runat="server" Text='<%#Eval("AreaZoneNameEmployee") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Area">
                            <ItemTemplate>
                                <asp:Label ID="lblamount" runat="server" Text='<%#Eval("AreaName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Area Employee">
                            <ItemTemplate>
                                <asp:Label ID="lblbank" runat="server" Text='<%#Eval("AreaNameEmployee") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                <script type="text/javascript">
    	                function filter (phrase, _id){
		                var words = phrase.value.toLowerCase().split(" ");
		                var table = document.getElementById('<%=gvdetails.ClientID%>');
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