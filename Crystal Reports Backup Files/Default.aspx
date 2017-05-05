<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CNF_Default" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <asp:gridview ID="Gridview1" runat="server" ShowFooter="true"
                             AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
        <asp:TemplateField HeaderText="Header 1">
            <ItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Header 2">
            <ItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Header 3">
            <ItemTemplate>
                 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </ItemTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
                 <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row"  style="display:none"
                     onclick="ButtonAdd_Click"  />
            </FooterTemplate>
        </asp:TemplateField>
        
        </Columns>
</asp:gridview>
    </div>
    </form>
</body>
</html>
