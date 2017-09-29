<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_StockReport.ascx.cs"
    Inherits="UserControls_StockReport" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<script src="js/ScrollableGrid.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
        $('#<%=Grdstockreport.ClientID %>').Scrollable();
        }
)
</script>
<div class="section-header" style="display:block">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>Stock Report <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>

    
    <div class="options">
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <div style="float: right; width: 58%">
            <div id="filter" runat="server">
                <span>Filter Data:</span>
                <input name="filt" onkeyup="filter(this, 'sf', '<%=Grdstockreport.ClientID%>')" type="text">
            </div>
        </div>
    </asp:Panel>
</div>
<div style="float: right; width: 8%">
    <asp:Button ID="btnExport" TabIndex="4" CssClass="submitbtn" runat="server" Text="Export" Width="80px"
        OnClick="btnExport_Click" />
</div>
<br />
<br />
<br />
<div style="float: right; width: 18%">
    <asp:Label runat="server" ID="Label1" Text="Total Physical Stock" CssClass="inp-form"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label runat="server" ID="lblTotalBooksInGodown" CssClass="product-table"></asp:Label>
</div>
<br />
<br />
<asp:Panel ID="pnl" runat="server">
    <asp:Panel ID="pnldate" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblfromdate" runat="server" Text="From Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtFromDate" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="Reqtdate" runat="server" ErrorMessage="Require To date"
                        ValidationGroup="date" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDate" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtToDate" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtToDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To date"
                        ValidationGroup="date" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                <asp:Button ID="btngetdate" TabIndex="3" CssClass="submitbtn" runat="server" Text="Get Data" 
                        Width="80px" ValidationGroup="date" onclick="btngetdate_Click"
        />
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    <asp:ValidationSummary ID="vald" runat="server" ValidationGroup="date" ShowMessageBox="true" ShowSummary="false"/>
    <asp:GridView ID="Grdstockreport" Width="915px" runat="server" PageSize="2000" AlternatingRowStyle-CssClass="alt"
        AutoGenerateColumns="false" CellPadding="4" CssClass="product-table">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Book Code" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblbkcode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="339px" HeaderText="Book Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                </ItemTemplate>
  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Type" HeaderStyle-BorderColor="Blue" ItemStyle-BorderColor="Blue" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("BookType")%>'></asp:Label>
                </ItemTemplate>
               
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Standard" HeaderStyle-BorderColor="Green" ItemStyle-BorderColor="Green" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px"  HeaderStyle-BorderColor="red" ItemStyle-BorderColor="Red" HeaderText="Op. Stock" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblVstock" runat="server" Style="text-align: right;" Text='<%#Eval("OpeningStock")%>'></asp:Label>
                </ItemTemplate>
              
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-BorderColor="#800000" ItemStyle-BorderColor="#800000" HeaderStyle-Width="80px" HeaderText="Rec. Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblReceived_Qty" runat="server" Style="text-align: right;" Text='<%#Eval("Received_Qty") %>'></asp:Label>
                </ItemTemplate>
               
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-BorderColor="Yellow" ItemStyle-BorderColor="Yellow" HeaderStyle-Width="80px" HeaderText="Total Stock" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblstock" runat="server" Style="text-align: right;" Text='<%#Eval("TotalStock") %>'></asp:Label>
                </ItemTemplate>
               
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Inv Qty" HeaderStyle-BorderColor="Aqua" ItemStyle-BorderColor="Aqua" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblSold" runat="server" Text='<%#Eval("INVOICE_QTY") %>'></asp:Label>
                </ItemTemplate>
               
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="Green" ItemStyle-BorderColor="Green" HeaderText="CN" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblrtqty" runat="server" Style="text-align: right;" Text='<%#Eval("ReturnedQty") %>'></asp:Label>
                </ItemTemplate>
               
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="Brown" ItemStyle-BorderColor="Brown" HeaderText="Balance QTY" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblnetSale" runat="server" Text='<%#Eval("NetSale_Qty") %>'></asp:Label>
                </ItemTemplate>
               
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="Blue" ItemStyle-BorderColor="Blue" HeaderText="Spe Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblSold" runat="server" Text='<%#Eval("Specimen_QTY") %>'></asp:Label>
                </ItemTemplate>
               
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="Blue" ItemStyle-BorderColor="Blue" HeaderText="Spe. CN" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblSpeCn" runat="server" Text='<%#Eval("SpeCn") %>'></asp:Label>
                </ItemTemplate>
               
            </asp:TemplateField>
           
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="red" ItemStyle-BorderColor="Red" HeaderText="Net Available" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblavailable" runat="server" Text='<%#Eval("Balance QTY") %>'></asp:Label>
                </ItemTemplate>
               
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <script type="text/javascript">
    	                function filter (phrase, _id){
		                var words = phrase.value.toLowerCase().split(" ");
		                var table = document.getElementById('<%=Grdstockreport.ClientID%>');
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

</asp:Panel><%--
<script type = "text/javascript">
    var GridId = "<%=Grdstockreport.ClientID %>";
    var ScrollHeight = 300;
    window.onload = function () {
        var grid = document.getElementById(GridId);
        var gridWidth = grid.offsetWidth;
        var gridHeight = grid.offsetHeight;
        var headerCellWidths = new Array();
        for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
            headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
        }
        grid.parentNode.appendChild(document.createElement("div"));
        var parentDiv = grid.parentNode;
 
        var table = document.createElement("table");
        for (i = 0; i < grid.attributes.length; i++) {
            if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
            }
        }
        table.style.cssText = grid.style.cssText;
        table.style.width = gridWidth + "px";
        table.appendChild(document.createElement("tbody"));
        table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
        var cells = table.getElementsByTagName("TH");
 
        var gridRow = grid.getElementsByTagName("TR")[0];
        for (var i = 0; i < cells.length; i++) {
            var width;
            if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                width = headerCellWidths[i];
            }
            else {
                width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
            }
            cells[i].style.width = parseInt(width) + "px";
            gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width) + "px";
        }
        parentDiv.removeChild(grid);
 
        var dummyHeader = document.createElement("div");
        dummyHeader.appendChild(table);
        parentDiv.appendChild(dummyHeader);
        var scrollableDiv = document.createElement("div");
        if(parseInt(gridHeight) > ScrollHeight){
             gridWidth = parseInt(gridWidth);
        }
        scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
        scrollableDiv.appendChild(grid);
        parentDiv.appendChild(scrollableDiv);
    }
</script>--%>