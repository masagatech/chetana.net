<%@ Control Language="C#" AutoEventWireup="true" 
    CodeFile="uc_CustomerMasterExport.ascx.cs"
    Inherits="UserControls_uc_CustomerMasterExport" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
 <td>
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
         <span runat="server" id="Span1"></span>
         <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">            
    </div>
</td>
 <td>
  <div style="float: right; width: 50%">          
 <div id="Div1" runat="server">
    <span>Filter Data:</span>
    <input name="filt" id="Text1" onkeyup="filter(this, 'sf', '<%=grdCustomerMaster.ClientID%>')" type="text" />
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
 </div>
</div>
 </td>   
    
</div>

<div> 
    <asp:Button ID="btnExport" CssClass="submitbtn" TabIndex="13" runat="server" Text="Export" Width="80px" Height="26px" OnClick="btnExport_Click" />
</div>
<br />
<br />
<asp:Panel ID="pnlCustomerMaster" runat="server">
<table width="100%">
<tr>
<td>
    <asp:Repeater ID="repAlfabets" runat="server">
    <ItemTemplate>
        <asp:LinkButton ID="lnkalfabet" CssClass="nav_bar_link" runat="server" Text='<%#Eval("chr") %>'  
        OnClick="lnkalfabet_click"></asp:LinkButton>
    </ItemTemplate>
    </asp:Repeater>
</td>
</tr>
<tr>
<td>
    <div style="overflow:visible ;width:50%;height:50%">
    <asp:GridView   ID="grdCustomerMaster" runat="server" 
                    AllowPaging="true" AutoGenerateColumns="false"
                    CellPadding="4" CssClass="product-table" ForeColor="#333333"
                    HeaderStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-CssClass="alt" PageSize="800" Width="100%" Height="100%">
        <Columns>
       
        <asp:BoundField Visible="true"  HeaderText="Customer Code" DataField="CustCode"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Customer Name" DataField="CustName"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Short Form" DataField="ShortForm"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Family Code" DataField="FamilyCode"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Address" DataField="Address"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Zip" DataField="Zip"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Phone 1" DataField="Phone1"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Phone 2" DataField="Phone2"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Email ID" DataField="EmailID"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Customer Type" DataField="CUSTOMERTYPE"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Super Zone " DataField="SuperZoneName"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Zone " DataField="ZoneName"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Area Name" DataField="AreaName"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="City" DataField="City"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="StateName" DataField="StateName"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Credit Limit" DataField="CreditLimit"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Black List" DataField="BlackList"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Principal Name" DataField="PrincipalName"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Principal Mobile" DataField="PrincipalMobile"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Principal DOB" DataField="PrincipalDOB"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Key Person Name" DataField="KeyPersonName"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Key Person Mobile" DataField="KeyPersonMobile"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Key Person DOB" DataField="KeyPersonDOB"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Add. Disc." DataField="AdditinalDis"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="VIP Remark" DataField="VIPRemark"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Credit Days" DataField="CreditDays"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Customer Rating" DataField="CustRating"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Association" DataField="Association"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Business_Potential" DataField="Business_Potential"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="CGP" DataField="CGP"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Payment_Track" DataField="Payment_Track"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
         <asp:BoundField Visible="true"  HeaderText="Category" DataField="Category"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="Sub Category" DataField="SubCategory"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>

        
        <asp:BoundField Visible="true"  HeaderText="SchAdditionalDis" DataField="SchAdditionalDis"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="TODValue1" DataField="TODValue1"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="TODValue2" DataField="TODValue2"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="TODValue3" DataField="TODValue3"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="TODDisc1" DataField="TODDisc1"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
         <asp:BoundField Visible="true"  HeaderText="TODDisc2" DataField="TODDisc2"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
        <asp:BoundField Visible="true"  HeaderText="TODDisc3" DataField="TODDisc3"> <HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
      

        </Columns>
    </asp:GridView>
    </div>
</td>
</tr>
</table>
    
    
    <%--OnPageIndexChanging="grdSuperZoneDetails_PageIndexChanging" OnRowDeleting="grdSuperZoneDetails_RowDeleting" OnRowEditing="grdSuperZoneDetails_RowEditing"--%>
    <script type="text/javascript">
    function filter(phrase, _id)
    {
	    var words = phrase.value.toLowerCase().split(" ");
	    var table = document.getElementById('<%=grdCustomerMaster.ClientID%>');
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
