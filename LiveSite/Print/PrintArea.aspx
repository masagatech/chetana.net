<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintArea.aspx.cs" Inherits="Print_PrintArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Css/printdata.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="js/printCm.js" type="text/javascript"></script>

  <title>. </title>
    <style>
        .grid
        {
            font-size: 11px;
        }
        .grid th
        {
            border-top: 1px solid #000;
            border-bottom: 1px solid #000;
        }
        .gridf
        {
            border-bottom: 1px solid #000;
            border-top: 1px solid #000;
        }
    </style>

    <script type="text/javascript" language="javascript"> 
    
        function printThis()
        {			
			document.getElementById('btnprint').style.display="none";
            var usertype=navigator.userAgent.toLowerCase();
            if (window.print) {
                window.print();
            }
            else if (usertype.indexOf("mac") != -1) {
                alert("Press 'Cmd+p' on your keyboard to print article.");
            }
            else {
                alert("Press 'Ctrl+p' on your keyboard to print article.")
            }
			document.getElementById('btnprint').style.display="visible";
        }
		function hideshowPrintBtn(opt)
		{
			if (document.getElementById('printBtnDiv')!=null)
			{
				document.getElementById('printBtnDiv').style.display=opt;
			}
		}
		
		document.getElementById('btnprint').click();
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="pnlLedger" runat="server">
      <input type="BUTTON" id="btnprint" value="Print" onclick="printThis()" />
    <asp:GridView ID="grdAreaDetails" runat="server" AllowPaging="false" AutoGenerateColumns="false"
        CellPadding="4" CssClass="product-table" ForeColor="#333333" PageSize="2000" Width="600px" 
              AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:TemplateField HeaderText="Area Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblAreaID" runat="server" Text='<%#Eval("AreaID")%>' Style="display: none"></asp:Label>
                    <asp:Label ID="lblAreaCode" runat="server" Text='<%#Eval("AreaCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Area Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAreaName" runat="server" Text='<%#Eval("AreaName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AreaZone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAreaZone" runat="server" Text='<%#Eval("AreaZoneName")%>'></asp:Label>
                    <asp:Label ID="lblAreaZoneID" runat="server" Text='<%#Eval("AreaZoneID")%>' Style="display: none"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Zone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblZone" runat="server" Text='<%#Eval("ZoneName")%>'></asp:Label>
                    <asp:Label ID="lblZoneID" runat="server" Text='<%#Eval("ZoneID")%>' Style="display: none"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SuperZone Name" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblsuperZone" runat="server" Text='<%#Eval("SuperZoneName")%>'></asp:Label>
                    <asp:Label ID="lblSuperZoneID" runat="server" Text='<%#Eval("SuperZoneID")%>' Style="display: none"></asp:Label>
                    <asp:CheckBox ID="chkIsActive" style="display:none;" runat="server" Checked='<%#Eval("IsActive") %>' Enabled="false">
                </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            
        </Columns>
    </asp:GridView>
    
    </asp:Panel>

    </div>
    </form>
</body>
</html>
